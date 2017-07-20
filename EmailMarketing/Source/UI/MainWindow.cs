using Controllers;
using EmailMarketing.Controllers.Interfaces;
using System;
using System.Configuration;
using System.IO;

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
        private static string InputFileDisplay
        {
            get
            {
                return Path.GetFileName(ConfigurationManager.AppSettings["inputFile"]);
            }
        }

        /// <summary>
        /// File to be processed
        /// </summary>
        private static string OutputFileDisplay
        {
            get
            {
                return Path.GetFileName(ConfigurationManager.AppSettings["outputFile"]);
            }
        }

        /// <summary>
        /// Bussiness logic controller
        /// </summary>
        private IController _controller;

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
            Console.WriteLine("INPUT FILE TO BE PROCESSED: {0}", InputFileDisplay);
            Console.Write(Environment.NewLine);
            Console.WriteLine("EXECUTING...");
            Console.Write(Environment.NewLine);
            try
            {
                _controller.ExecuteProcess();
                Console.WriteLine("YOU CAN FIND THE RESULT FILE AT: {0}", OutputFileDisplay);
            }
            catch(Exception e)
            {
                Console.WriteLine("AN ERROR OCCURRED:");
                Console.WriteLine("Details: {0}", e.Message);
                if(e.InnerException != null)
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
            }
            Console.Write(Environment.NewLine);
            Console.WriteLine("ENTER ANY KEY TO EXIT");
            Console.ReadKey();
        }

        #endregion

    }


}
