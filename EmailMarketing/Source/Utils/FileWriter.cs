using System;
using System.Collections.Generic;
using System.IO;

namespace EmailMarketing.utils
{
    public class FileWriter
    {
        #region Properties

        /// <summary>
        /// Record delimiter
        /// </summary>
        private string _delimiter;

        /// <summary>
        /// File to be write
        /// </summary>
        private string _fileName;

        #endregion

        #region Constructor

        public FileWriter(string fileName, string delimiter = "")
        {
            _delimiter = delimiter;
            _fileName = fileName;
        }

        #endregion
        
        #region Public

        /// <summary>
        /// Writes the records to the file
        /// </summary>
        /// <returns></returns>
        public void Write(List<string[]> records)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_fileName))
                {
                    foreach(var record in records)
                    {
                        writer.WriteLine(GetRecordLine(record));
                    }
                }                
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error writing file {0}.{1}Detail: {2}", _fileName, Environment.NewLine, e.Message));
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// Get the record separated by the delimiter
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private string GetRecordLine(string[] record)
        {
            return string.Join(_delimiter, record);
        }

        #endregion
    }
}
