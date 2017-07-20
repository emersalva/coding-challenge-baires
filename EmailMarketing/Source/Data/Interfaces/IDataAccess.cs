using EmailMarketing.Models;
using System.Collections.Generic;

namespace EmailMarketing.Data.Interfaces
{
    public interface IDataAccess
    {
        /// <summary>
        /// Get the people records
        /// </summary>
        /// <returns></returns>
        List<PersonRecord> ReadPeopleRecords();

        /// <summary>
        /// Write result
        /// </summary>
        /// <param name="records"></param>
        void WriteResults(List<string[]> records);

        /// <summary>
        /// Get the collection of matches for the role field
        /// </summary>
        /// <returns></returns>
        List<string> ReadRolesMatchesCollection();

        /// <summary>
        /// Get the collection of matches for the country field
        /// </summary>
        /// <returns></returns>
        List<string> ReadCountriesMatchesCollection();

        /// <summary>
        /// Get the collection of matches for the industry field
        /// </summary>
        /// <returns></returns>
        List<string> ReadIndustriesMatchesCollection();
    }
}
