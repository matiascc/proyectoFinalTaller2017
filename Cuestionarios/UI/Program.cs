using System;
using System.Windows.Forms;
using Questionnaire.Controlers;

namespace UI
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

            UserController usrController = new UserController();
            SetController setController = new SetController();
            QuestionController questController = new QuestionController();
            SourceController sourceController = new SourceController();
            GameController gameController = new GameController();

            Application.Run(new Login(usrController, setController, questController, sourceController, gameController));
        }
    }
}
