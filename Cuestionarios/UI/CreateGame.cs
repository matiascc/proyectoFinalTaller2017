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
using Questionnaire.Domain;
using Questionnaire.Source;
using Npgsql;
using Questionnaire.DTOs;

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
        private SetDTO   _setSelected;
        private readonly static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly UserDTO _usr;

        public CreateGame(UserController usrController, GameController gameController ,SetController setControler, QuestionController questionController, SourceController sourceControler, UserDTO usr)
        {
            _setController = setControler;
            _questionController = questionController;
            _sourceController = sourceControler;
            _usrController = usrController;
            _gameController = gameController;
            _usr = usr;

            InitializeComponent();
            NewGame.Enabled = false;

            //Load the sets into the comboBox
            foreach (var item in _setController.GetAllSet())
            {
                cb_set.Items.Add(item.Name.ToString());
            }
        }


        private void Cb_set_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_category.Enabled = true;
            pSource = _sourceController.GetSourceByName(cb_set.Text);
            cb_category.Items.Clear();
            var lCategory = new List<string>();

            _setSelected = _setController.GetAllSet().Find(x => x.Name == cb_set.Text);

            foreach (Question question in _setSelected.Questions)
            {
                lCategory.Add(pSource.categoryDictionary.FirstOrDefault(x => x.Key == question.Category).Value);             
            }

            foreach (string category in lCategory.Distinct())
            {
                cb_category.Items.Add(category);
            }
        }
        
        private void Cb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCategory = cb_category.Text;
            cb_difficulty.Enabled = true;

            cb_difficulty.Items.Clear();
            var lDifficulty = new List<string>();

            foreach (Question question in _setSelected.Questions)
            {
                if (pSource.categoryDictionary.FirstOrDefault(x => x.Key == question.Category).Value == cb_category.Text)
                {
                  lDifficulty.Add(pSource.difficultyDictionary.FirstOrDefault(x => x.Key == question.Difficulty).Value);
                }
            }

            foreach (string difficulty in lDifficulty.Distinct())
            {
                cb_difficulty.Items.Add(difficulty);
            }

        }
        private void Cb_difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            nud_amount.Enabled = true;
            var lQuestions = new List<Question>();

            foreach (Question question in _setSelected.Questions)
            {
                if ((pSource.categoryDictionary.FirstOrDefault(x => x.Key == question.Category).Value == cb_category.Text)
                    && (pSource.difficultyDictionary.FirstOrDefault(x => x.Key == question.Difficulty).Value == cb_difficulty.Text))
                {
                    lQuestions.Add(question);
                }
            }
            nud_amount.Maximum = lQuestions.Count();
        }
        private void Nud_amount_ValueChanged(object sender, EventArgs e)
        {
            NewGame.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Game ventana = new Game(_usrController, _questionController, _sourceController, _gameController, _usr, cb_set.Text , cb_difficulty.Text , cb_category.Text , nud_amount.Value);
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

    }
}
