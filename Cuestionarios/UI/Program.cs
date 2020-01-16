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
            UserControler usrControler = new UserControler(mapper);
            Application.Run(new Login(usrControler));
        }
    }
}
