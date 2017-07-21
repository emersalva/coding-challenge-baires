using EmailMarketing.Controllers.Interfaces;
using EmailMarketing.Data;
using EmailMarketing.Data.Interfaces;
using EmailMarketing.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Controllers
{
    public class MainController : IController
    {
        #region Properties

        /// <summary>
        /// Data access
        /// </summary>
        private IDataAccess _dataAccess;

        /// <summary>
        /// List of word matches for the role field
        /// </summary>
        private List<string> _roleMatchesCollection;

        /// <summary>
        /// List of word matches for the country field
        /// </summary>
        private List<string> _countriesMatchesCollection;

        /// <summary>
        /// List of word matches for the industry field
        /// </summary>
        private List<string> _industryMatchesCollection;

        /// <summary>
        /// Result limit
        /// </summary>
        private int ResultLimit
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["resultsLimit"]);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainController()
        {
            _dataAccess = new LocalDataAccess();
            _roleMatchesCollection = _dataAccess.ReadRolesMatchesCollection();
            _countriesMatchesCollection = _dataAccess.ReadCountriesMatchesCollection();
            _industryMatchesCollection = _dataAccess.ReadIndustriesMatchesCollection();
        }

        #endregion

        #region Public

        /// <summary>
        /// Execute the main process
        /// </summary>
        /// <returns></returns>
        public void ExecuteProcess()
        {
            var records = ReadRecords();
            if (records == null || records.Count == 0) throw new Exception("No records found");
            WriteResult(records.Where(r => RecordMatch(r)).ToList());
        }

        #endregion

        #region Private

        /// <summary>
        /// Read the records to be processed
        /// </summary>
        /// <returns></returns>
        private List<PersonRecord> ReadRecords()
        {
            try
            {
                return _dataAccess.ReadPeopleRecords();
            }
            catch (Exception e)
            {
                throw new Exception("Error reading records to be processed", e);
            }
        }

        /// <summary>
        /// True if record is a match
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private bool RecordMatch(PersonRecord record)
        {
            try
            {
                //if it is a match in the role or the industry, for the selected countries
                return MatchByCountry(record.Country) && (MatchByRole(record.Role) || MatchByIndustry(record.Industry));
            }
            catch (Exception e)
            {
                throw new Exception("Error matching record", e);
            }
        }

        /// <summary>
        /// True if there is a match by role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        private bool MatchByRole(string role)
        {
            //if any word of the role match in the list
            var words = role.Split(null);
            return words.Where(w => _roleMatchesCollection.Contains(w.ToLower())).Any();
        }

        /// <summary>
        /// True if there is a match by country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        private bool MatchByCountry(string country)
        {
            return _countriesMatchesCollection.Contains(country.ToLower());
        }

        /// <summary>
        /// True if there is a match by industry
        /// </summary>
        /// <param name="industry"></param>
        /// <returns></returns>
        private bool MatchByIndustry(string industry)
        {
            //if any word of the industry match in the list
            var words = industry.Split(null);
            return words.Where(w => _industryMatchesCollection.Contains(w.ToLower())).Any();
        }

        /// <summary>
        /// Write the results to output
        /// </summary>
        /// <param name="resultsRecords"></param>
        private void WriteResult(List<PersonRecord> resultsRecords)
        {
            try
            {
                var finalResult = GetFinalRecords(resultsRecords);
                _dataAccess.WriteResults((finalResult.Select(r => new string[] { r.PersonId.ToString() })).ToList());
            }
            catch (Exception e)
            {
                throw new Exception("Error writing result", e);
            }
        }

        /// <summary>
        /// Filter the final result
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private List<PersonRecord> GetFinalRecords(List<PersonRecord> result)
        {
            return ((result.OrderByDescending(i => i.Recomendations).ThenByDescending(i => i.Connections)).Take(ResultLimit)).ToList();
        }

        #endregion
    }
}
