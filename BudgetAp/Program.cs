using System;
using System.Windows.Forms;

namespace BudgetAp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);       

            //Use AppContext to maintain broad program context needs (i.e., creating DB pathway before loading form1, and setting up on exit event to delete DB on program exit).
            AppContext context = new AppContext();
            Application.Run(context);
        }
    }
}
