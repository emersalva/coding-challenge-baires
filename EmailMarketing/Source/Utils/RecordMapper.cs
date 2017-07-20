using EmailMarketing.Models;
using System;

namespace EmailMarketing.utils
{
    public static class RecordMapper
    {
        #region Constants

        //Indexes for the record
        private const int ID_INDEX = 0;
        private const int NAME_INDEX = 1;
        private const int LASTNAME_INDEX = 2;
        private const int ROLE_INDEX = 3;
        private const int COUNTRY_INDEX = 4;
        private const int INDUSTRY_INDEX = 5;
        private const int RECOMMENDATIONS_INDEX = 6;
        private const int CONNECTIONS_INDEX = 7;

        #endregion

        #region Methods

        /// <summary>
        /// Maps a string array record to the object
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static PersonRecord MapRecord(string[] record)
        {
            int id;
            if(!int.TryParse(record[ID_INDEX], out id))
            {
                throw new Exception(string.Format("Invalid id in record: {0}", record[ID_INDEX]));
            }
            int recomendations;
            if (!int.TryParse(record[RECOMMENDATIONS_INDEX], out recomendations))
            {
                recomendations = 0;
            }
            int connections;
            if (!int.TryParse(record[CONNECTIONS_INDEX], out connections))
            {
                connections = 0;
            }
            return new PersonRecord
            {
                PersonId = id,
                Name = record[NAME_INDEX],
                LastName = record[LASTNAME_INDEX],
                Role = record[ROLE_INDEX],
                Country = record[COUNTRY_INDEX],
                Industry = record[INDUSTRY_INDEX],
                Recomendations = recomendations,
                Connections = connections
            };
        }

    #endregion

    }
}
