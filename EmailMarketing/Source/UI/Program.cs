using System;

namespace EmailMarketing.UI
{
    /// <summary>
    /// Main program
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                new MainWindow().ShowMainWindow();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro has ocurred. Detail:");
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
