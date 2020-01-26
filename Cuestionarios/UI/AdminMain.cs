using System;
using System.Windows.Forms;
using Questionnaire.Controlers;
using Questionnaire.Source;

namespace UI
{
    public partial class AdminMain : Form
    {
        private readonly SetController _setController; 
        private readonly QuestionController _questionController;
        private readonly SourceController _sourceController;
        private readonly UserController _usrController;
        private ISource sourceSelected;

        public AdminMain(SetController setControler, QuestionController questionController, SourceController sourceControler, UserController usrController)
        {
            _setController = setControler;
            _questionController = questionController;
            _sourceController = sourceControler;
            _usrController = usrController;
            InitializeComponent();

            //Load the sets into the comboBox
            foreach (var item in _setController.GetAllSet())
            {
                cb_set.Items.Add(item.Name.ToString());
            }

        }

        /// <summary>
        /// When the set comboBox is changed
        /// </summary>
        private void cb_setChanged(object sender, EventArgs e)
        {
            cb_category.Enabled = true;
            cb_dificulty.Enabled = true;
            nud_amount.Enabled = true;
            b_loadQuestions.Enabled = true;
            b_eraseQuestions.Enabled = true;

            cb_category.Items.Clear();

            this.sourceSelected = _sourceController.GetSourceByName(cb_set.Text);

            foreach (string name in sourceSelected.categoryDictionary.Values)
            {
                cb_category.Items.Add(name);
            }

            foreach (string name in sourceSelected.difficultyDictionary.Values)
            {
                cb_dificulty.Items.Add(name);
            }
        }

        private void b_loadQuestions_Click(object sender, EventArgs e)
        {
            _questionController.SaveQuestions(sourceSelected, cb_dificulty.Text, cb_category.SelectedIndex, Decimal.ToInt32(nud_amount.Value));
            MessageBox.Show("Questions loaded correctly");
        }

        /// <summary>
        /// Delete all questions from the DB
        /// </summary>
        private void b_eraseQuestions_Click(object sender, EventArgs e)
        {
            _questionController.DeleteQuestions();
            MessageBox.Show("Questions erased correctly");
        }

        private void b_LogOut_Click(object sender, EventArgs e)
        {
            Login ventana = new Login(_usrController, _setController, _questionController, _sourceController);
            this.Close();
            ventana.Show();
        }
    }
}
