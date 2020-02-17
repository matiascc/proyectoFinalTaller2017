using System;
using System.Windows.Forms;
using Questionnaire.Controlers;
using Questionnaire.Source;
using Npgsql;

namespace UI
{
    public partial class AdminMain : Form
    {
        private readonly SetController _setController;
        private readonly QuestionController _questionController;
        private readonly SourceController _sourceController;
        private ISource sourceSelected;
        private readonly static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public AdminMain(SetController setControler, QuestionController questionController, SourceController sourceControler)
        {
            _setController = setControler;
            _questionController = questionController;
            _sourceController = sourceControler;
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
            logger.Debug("Getting new questions from server");

            try
            {
                _questionController.SaveQuestions(sourceSelected, cb_dificulty.Text, cb_category.SelectedIndex, Decimal.ToInt32(nud_amount.Value));

                MessageBox.Show("Questions saved successfully");
                logger.Debug("Questions saved successfully");
            }
            catch(ArgumentNullException ex)
            {
                MessageBox.Show("Error trying to access the questions' API :", ex.ToString());
                logger.Debug("Error trying to access the questions' APIs :" + ex.Message);
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

        /// <summary>
        /// Delete all questions from the DB
        /// </summary>
        private void b_eraseQuestions_Click(object sender, EventArgs e)
        {
            logger.Debug("Deleating all questions from database");

            try
            {
                _questionController.DeleteQuestions();
                MessageBox.Show("Questions deleted successfully");
                logger.Debug("Questions deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't delete questions: ", ex.ToString());
                logger.Debug("Couldn't delete questions: " + ex.Message);
            }
        }

        private void b_LogOut_Click(object sender, EventArgs e)
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
