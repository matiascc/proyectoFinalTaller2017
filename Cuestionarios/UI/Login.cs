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
        private readonly UserControler _usrControler;
        public Login(UserControler usrControler)
        {
            _usrControler = usrControler;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        
        private void b_login_Click(object sender, EventArgs e)
        {
            try
            {
                UserDTO usr = _usrControler.GetUser(tb_username.Text);
                if(usr.password == tb_password.Text)
                {
                    if (usr.admin)
                    {
                        AdminMain ventana = new AdminMain();
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
            }
            catch (Exception exc)
            {
                MessageBox.Show("Nombre de usario incorrecto", exc.Message);
            }
        }

        private void b_createUser_Click(object sender, EventArgs e)
        {
            CreateUser ventana = new CreateUser(_usrControler);
            this.Hide();
            ventana.Show();
        }
    }
}
