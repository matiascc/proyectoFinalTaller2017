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
using Questionnaire.DTOs;

namespace UI
{
    public partial class Login : Form
    {
        private readonly UserController _usrController;
        private readonly SetController _setController;
        private readonly QuestionController _questController;
        private readonly SourceController _sourceController;
        public Login(UserController usrController, SetController setController, QuestionController questController, SourceController sourceController)
        {
            _usrController = usrController;
            _setController = setController;
            _questController = questController;
            _sourceController = sourceController;

            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        
        private void b_login_Click(object sender, EventArgs e)
        {
            //try
            //{
                UserDTO usr = _usrController.GetUser(tb_username.Text);
                if(usr.password == tb_password.Text)
                {
                    if (usr.admin)
                    {
                        AdminMain ventana = new AdminMain(_setController, _questController, _sourceController);
                        this.Hide();
                        ventana.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario logeado correctamente (sin permisos)");
                    }
                        
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta");
                }
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show("Nombre de usario incorrecto", exc.Message);
            //}
        }

        private void b_createUser_Click(object sender, EventArgs e)
        {
            CreateUser ventana = new CreateUser(_usrController, _setController, _questController, _sourceController);
            this.Hide();
            ventana.Show();
        }

        private void tb_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.b_login_Click(this, new EventArgs());
            }
        }
    }
}
