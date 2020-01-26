using System;
using System.Windows.Forms;
using Questionnaire.Controlers;

namespace UI
{
    public partial class CreateUser : Form
    {
        private readonly UserController _usrController;

        public CreateUser(UserController usrController)
        {
            _usrController = usrController;

            InitializeComponent();
        }

        private void b_register_Click(object sender, EventArgs e)
        {
            try
            {
                _usrController.AddUser(tb_username.Text, tb_password.Text, false);
                MessageBox.Show("Usuario agregado correctamente");
                this.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show("No se pudo crear el usuario", exc.Message);
            }            
        }
    }
}
