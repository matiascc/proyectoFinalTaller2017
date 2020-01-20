using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Questionnaire.Domain;
using Questionnaire.Controlers;
using Questionnaire.DTOs;
using Questionnaire.Source;

namespace UI
{
    public partial class AdminMain : Form
    {
        private readonly SetController _setControler; 
        private readonly QuestionController _questionController;
        private readonly SourceController _sourceControler;
        private ISource sourceSelected;

        public AdminMain(SetController setControler, QuestionController questionController, SourceController sourceControler)
        {
            _setControler = setControler;
            _questionController = questionController;
            _sourceControler = sourceControler;
            InitializeComponent();

            foreach (var item in _setControler.GetAllSet())
            {
                cb_set.Items.Add(item.name.ToString());
            }

        }

        private void cb_setChanged(object sender, EventArgs e)
        {
            cb_category.Enabled = true;
            cb_dificulty.Enabled = true;
            nud_amount.Enabled = true;
            b_loadQuestions.Enabled = true;
            b_eraseQuestions.Enabled = true;

            cb_category.Items.Clear();

            this.sourceSelected = _sourceControler.GetSourceByName(cb_set.Text);

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
        }

        private void b_eraseQuestions_Click(object sender, EventArgs e)
        {
            _questionController.DeleteQuestions();
        }
    }
}
