using System;
using System.Collections.Generic;
using System.IO;

namespace EmailMarketing.utils
{
    public class FileReader
    {
        #region Properties

        /// <summary>
        /// Record delimiter
        /// </summary>
        private string _delimiter;

        /// <summary>
        /// File to be read
        /// </summary>
        private string _fileName;

        #endregion

        #region Constructor

        public FileReader(string fileName, string delimiter = "")
        {
            _delimiter = delimiter;
            _fileName = fileName;
        }

        #endregion
        
        #region Public

        /// <summary>
        /// Reads the file and returns the list of records splited
        /// </summary>
        /// <returns></returns>
        public List<string[]> Read()
        {
            try
            {
                var result = new List<string[]>();
                using (StreamReader reader = new StreamReader(_fileName))
                {
                    string record;
                    while ((record = reader.ReadLine()) != null)
                    {
                        result.Add(GetSplitRecord(record));
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error reading file {0}.{1}Detail: {2}", _fileName, Environment.NewLine, e.Message));
            }
        } 

        #endregion

        #region Private

        /// <summary>
        /// Splits the line and returns the record
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string[] GetSplitRecord(string line)
        {
            var record = new string[] { line };
            if (!string.IsNullOrEmpty(_delimiter))
            {
                record = line.Split(new [] { _delimiter }, StringSplitOptions.None);
            }
            return record;
        }

        #endregion
    }
}
