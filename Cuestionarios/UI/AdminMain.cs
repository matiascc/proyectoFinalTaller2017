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

            foreach (var item in Enum.GetValues(typeof(Dificulty)))
            {
                cb_dificulty.Items.Add(item.ToString());
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

            foreach (string item in Enum.GetNames(typeof(Category)))
            {
                cb_category.Items.Add(item);
            }
        }

        private void b_loadQuestions_Click(object sender, EventArgs e)
        {
            ISource sourceSelected = _sourceControler.GetSourceByName(cb_set.Text); 
            _questionController.SaveQuestions(sourceSelected, cb_dificulty.Text, cb_category.SelectedIndex, Decimal.ToInt32(nud_amount.Value));
        }

        private void b_eraseQuestions_Click(object sender, EventArgs e)
        {
            _questionController.DeleteQuestions();
        }
    }
}
