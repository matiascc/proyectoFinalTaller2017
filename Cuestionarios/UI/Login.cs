using System;
using System.Windows.Forms;
using Questionnaire.Controlers;
using Questionnaire.DTOs;
using Npgsql;

namespace UI
{
    public partial class Login : Form
    {
        private readonly UserController _usrController;
        private readonly SetController _setController;
        private readonly QuestionController _questController;
        private readonly SourceController _sourceController;
        private readonly GameController _gameController;

        private readonly static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Login(UserController usrController, SetController setController, QuestionController questController, SourceController sourceController, GameController gameController)
        {
        _usrController = usrController;
        _setController = setController;
        _questController = questController;
        _sourceController = sourceController;
        _gameController = gameController;

        InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
        
        private void b_login_Click(object sender, EventArgs e)
        {
            try
            {
                UserDTO usr = _usrController.GetUser(tb_username.Text);
                
                logger.Debug("Trying to log in as username:" + tb_username.Text);
                
                if (usr == null)
                {
                    MessageBox.Show("Couldn't log in: incorrect username");
                    logger.Debug("Couldn't log in: incorrect username");
                }
                else if(usr.Password != tb_password.Text)
                {
                    MessageBox.Show("Couldn't log in: incorrect password");
                    logger.Debug("Couldn't log in: incorrect password");
                }
                else
                {
                    logger.Debug("User logged in successfully");

                    if (usr.Admin)
                    {
                        AdminMain ventana = new AdminMain(_setController, _questController, _sourceController);
                        ventana.Owner = this;
                        ventana.Show();
                        this.Hide();
                    }
                    else
                    {
                        Game ventana = new Game(_usrController, _questController, _sourceController, _gameController, usr);
                        ventana.Owner = this;
                        ventana.Show();
                        this.Hide();
                    }
                }
            }
            catch (NpgsqlException exc)
            {
                MessageBox.Show("Error on the database operation:", exc.Message);
                logger.Debug("Error on the database operation:", exc.Message);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Unknown Error:", exc.Message);
                logger.Debug("Unknown Error:", exc.Message);
            }
        }

        private void b_createUser_Click(object sender, EventArgs e)
        {
            CreateUser ventana = new CreateUser(_usrController);
            ventana.ShowDialog();
        }

        /// <summary>
        /// Try to login when the Enter Key is pressed
        /// </summary>
        private void tb_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.b_login_Click(this, new EventArgs());
            }
        }
    }
}
