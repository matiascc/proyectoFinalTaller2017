using System;
using System.Windows.Forms;
using Questionnaire.Controlers;
using Questionnaire.Domain;
using Questionnaire.Source;

namespace UI
{
    public partial class CreateGame : Form
    {
        private readonly SetController _setController;
        private readonly QuestionController _questionController;
        private readonly SourceController _sourceController;
        private readonly UserController _usrController;
        private readonly GameController _gameController;
        private ISource pSource;
        private readonly static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly User _usr;

        public CreateGame(UserController usrController, GameController gameController ,SetController setControler, QuestionController questionController, SourceController sourceControler, User usr)
        {
            _setController = setControler;
            _questionController = questionController;
            _sourceController = sourceControler;
            _usrController = usrController;
            _gameController = gameController;
            _usr = usr;

            InitializeComponent();
            b_NewGame.Enabled = false;

            /// Load the sets into the comboBox
            foreach (var item in _setController.GetAllSet())
            {
                cb_set.Items.Add(item.Name.ToString());
            }
        }

        /// <summary>
        /// Load the categories comboBox when a set is selected
        /// </summary>
        private void Cb_set_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_category.Enabled = true;
            pSource = _sourceController.GetSourceByName(cb_set.Text);

            cb_category.DataSource = _questionController.GetCategoriesOfSet(pSource);
        }

        /// <summary>
        /// Load the difficulty comboBox when a category is selected
        /// </summary>
        private void Cb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_difficulty.Enabled = true;

            cb_difficulty.DataSource = _questionController.GetDifficultiesOfCategory(pSource, cb_category.Text);
        }

        /// <summary>
        /// Establish the maximum amount of questions to select when a difficulty is selected
        /// </summary>
        private void Cb_difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            nud_amount.Enabled = true;

            nud_amount.Maximum = _questionController.GetAmountOfQuestions(pSource, cb_category.Text, cb_difficulty.Text);

            b_NewGame.Enabled = true;
        }
        
        private void b_NewGame_Click(object sender, EventArgs e)
        {
            Game ventana = new Game(_usrController, _questionController, _sourceController, _gameController, _usr, cb_set.Text, cb_difficulty.Text, cb_category.Text, nud_amount.Value);
            ventana.Owner = this;
            ventana.Show();
            this.Hide();
        }

        private void B_LogOut_Click(object sender, EventArgs e)
        {
            logger.Debug("User logged out");
            this.Owner.Show();
            this.Close();
        }
        private new void FormClosed(object sender, FormClosingEventArgs e)
        {
            logger.Debug("User logged out");
            this.Owner.Show();
        }

        private void b_HighScores_Click(object sender, EventArgs e)
        {
            HighScores ventana = new HighScores(_usrController);
            ventana.ShowDialog();
        }
    }
}
