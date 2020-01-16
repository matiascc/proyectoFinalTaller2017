using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Questionnaire.Controlers;
using AutoMapper;

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
            IMapper mapper = Questionnaire.AutoMapper.AutoMapper.ConfigureAutomapper(); 

            UserController usrController = new UserController(mapper);
            SetController setController = new SetController(mapper);
            QuestionController questController = new QuestionController(mapper,setController);
            SourceController sourceController = new SourceController(mapper);

            Application.Run(new Login(usrController, setController, questController, sourceController));
        }
    }
}
