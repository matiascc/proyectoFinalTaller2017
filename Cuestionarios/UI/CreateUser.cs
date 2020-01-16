using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Questionnaire.Controlers;

namespace UI
{
    public partial class CreateUser : Form
    {
        private readonly UserController _usrController;
        private readonly SetController _setController;
        private readonly QuestionController _questController;
        private readonly SourceController _sourceController;

        public CreateUser(UserController usrController, SetController setController, QuestionController questController, SourceController sourceController)
        {
            _usrController = usrController;
            _setController = setController;
            _questController = questController;
            _sourceController = sourceController;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _usrController.AddUser(tb_username.Text, tb_password.Text, false);
                MessageBox.Show("Usuario agregado correctamente");
                Login ventana = new Login(_usrController, _setController, _questController, _sourceController);
                this.Hide();
                ventana.Show();
            }
            catch(Exception exc)
            {
                MessageBox.Show("No se pudo crear el usuario", exc.Message);
            }            
        }
    }
}
