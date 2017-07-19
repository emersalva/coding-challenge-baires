using EmailMarketing.Controllers;
using System;
using System.Configuration;

namespace EmailMarketing.UI
{
    /// <summary>
    /// Main window
    /// </summary>
    public class MainWindow
    {
        #region Properties

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
        /// Bussiness logic controller
        /// </summary>
        private MainController _controller;

        #endregion

        #region Constructor

        public MainWindow()
        {
            _controller = new MainController();
        }

        #endregion
       
        #region Public

        /// <summary>
        /// Shows the principal window
        /// </summary>
        public void ShowMainWindow()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("************************ EMAIL MARKETING PROGRAM ************************");
            Console.WriteLine("*************************************************************************");
            Console.Write(Environment.NewLine);
            Console.WriteLine("INPUT FILE TO BE PROCESSED: {0}", InputFile);
            Console.Write(Environment.NewLine);
            Console.WriteLine("EXECUTING...");
            Console.Write(Environment.NewLine);
            try
            {
                _controller.ExecuteProcess(InputFile, OutputFile);
                Console.WriteLine("YOU CAN FIND THE RESULT FILE AT: {0}", OutputFile);
            }
            catch(Exception e)
            {
                Console.WriteLine("AN ERROR OCCURRED:");
                Console.WriteLine(e.Message);
            }
            Console.Write(Environment.NewLine);
            Console.WriteLine("ENTER ANY KEY TO EXIT");
            Console.ReadKey();
        }

        #endregion

    }


}
