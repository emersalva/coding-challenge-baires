using System;
using System.Collections.Generic;
using EmailMarketing.Data.Interfaces;
using EmailMarketing.utils;
using EmailMarketing.Models;
using System.Configuration;

namespace EmailMarketing.Data
{
    public class LocalDataAccess : IDataAccess
    {

        #region Properties

        /// <summary>
        /// File delimiter
        /// </summary>
        private string Delimiter
        {
            get
            {
                return ConfigurationManager.AppSettings["delimiter"];
            }
        }

        /// <summary>
        /// File to be processed
        /// </summary>
        private static string InputFile
        {
            get
            {
                return ConfigurationManager.AppSettings["inputFile"];
            }
        }

        /// <summary>
        /// File to be processed
        /// </summary>
        private static string OutputFile
        {
            get
            {
                return ConfigurationManager.AppSettings["outputFile"];
            }
        }

        /// <summary>
        /// File with the role matches
        /// </summary>
        private static string RoleMatchesFile
        {
            get
            {
                return ConfigurationManager.AppSettings["roleMatches"];
            }
        }

        /// <summary>
        /// File with the country matches
        /// </summary>
        private static string CountryMatchesFile
        {
            get
            {
                return ConfigurationManager.AppSettings["countryMatches"];
            }
        }

        /// <summary>
        /// File with the industry matches
        /// </summary>
        private static string IndustryMatchesFile
        {
            get
            {
                return ConfigurationManager.AppSettings["industryMatches"];
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the people records
        /// </summary>
        /// <returns></returns>
        public List<PersonRecord> ReadPeopleRecords()
        {
            var result = new List<PersonRecord>();
            var reader = new FileReader(InputFile, Delimiter);
            var records = reader.Read();
            if(records != null && records.Count > 0)
            {
                foreach (var record in records)
                {
                    result.Add(RecordMapper.MapRecord(record));
                }
            }
            return result;
        }

        /// <summary>
        /// Write results
        /// </summary>
        /// <param name="records"></param>
        public void WriteResults(List<string[]> records)
        {
            var writer = new FileWriter(OutputFile, Delimiter);
            writer.Write(records);
        }

        /// <summary>
        /// Get the collection of matches for the role field
        /// </summary>
        /// <returns></returns>
        public List<string> ReadRolesMatchesCollection()
        {
            return ReadMatchesCollection(RoleMatchesFile);
        }

        /// <summary>
        /// Get the collection of matches for the country field
        /// </summary>
        /// <returns></returns>
        public List<string> ReadCountriesMatchesCollection()
        {
            return ReadMatchesCollection(CountryMatchesFile);
        }

        /// <summary>
        /// Get the collection of matches for the industry field
        /// </summary>
        /// <returns></returns>
        public List<string> ReadIndustriesMatchesCollection()
        {
            return ReadMatchesCollection(IndustryMatchesFile);
        }

        #endregion

        #region Private

        /// <summary>
        /// Reads a collection from the file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private List<string> ReadMatchesCollection(string fileName)
        {
            var result = new List<string>();
            var reader = new FileReader(fileName);
            var records = reader.Read();
            if (records != null && records.Count > 0)
            {
                foreach (var record in records)
                {
                    result.AddRange(record);
                }
            }
            return result;
        }

        #endregion

    }
}
