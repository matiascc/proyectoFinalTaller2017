using System;
using System.Windows.Forms;
using Questionnaire.Controlers;
using Npgsql;

namespace UI
{
    public partial class CreateUser : Form
    {
        private readonly UserController _usrController;
        private readonly static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public CreateUser(UserController usrController)
        {
            _usrController = usrController;

            InitializeComponent();
        }

        private void b_register_Click(object sender, EventArgs e)
        {
            try
            {
                logger.Debug("Trying to create a new user");

                _usrController.AddUser(tb_username.Text, tb_password.Text, false);

                MessageBox.Show("User added successfully");
                logger.Debug("User added successfully");

                this.Close();
            }
            catch (NpgsqlException exc)
            {
                MessageBox.Show("Error on the database operation: ", exc.Message);
                logger.Debug("Error on the database operation: " + exc.Message);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Unknown Error: ", exc.Message);
                logger.Debug("Unknown Error: " + exc.Message);
            }
        }
    }
}
