using System;
using System.Windows.Forms;

namespace BudgetAp
{
    class AppContext : ApplicationContext
    {        
        //Constructor
        public AppContext()
        {
            //To handle the application exit event
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            //Makes sure the directory pathway for the DB exists. Deletes DB (should only exist at the start of the program if the program did not close properly).
            Utils.StartStopRoutine();

            //Create main form. Assign it an on close event handler. Then show it.
            Form1 oForm = new Form1();
            oForm.Closed += new EventHandler(OnFormClosed);
            oForm.StartPosition = FormStartPosition.CenterScreen;
            oForm.Show();
            oForm = null;
        }

        /// <summary>
        /// When the primary form closes call on the Exit Thread method.
        /// </summary>
        private void OnFormClosed(object sender, EventArgs e)
        {
            ExitThread();
        }

        /// <summary>
        /// Delete the budget DB by reusing the StartStopRoutine. Don't want to leave this on the user's device as the .bak file is what is being used for data storage.
        /// </summary>
        private void OnApplicationExit(object sender, EventArgs e)
        {
            Utils.StartStopRoutine();
        }
    }
}
