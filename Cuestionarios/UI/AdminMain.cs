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

namespace UI
{
    public partial class AdminMain : Form
    {
        public AdminMain()
        {
            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(Dificulty)))
            {
                cb_dificulty.Items.Add(item.ToString());
            }
            foreach (string item in Enum.GetNames(typeof(Category)))
            {
                cb_category.Items.Add(item);
            }
        }

        private void b_loadQuestions_Click(object sender, EventArgs e)
        {

        }

        private void b_saveQuestions_Click(object sender, EventArgs e)
        {

        }

        private void b_eraseQuestions_Click(object sender, EventArgs e)
        {

        }
    }
}
