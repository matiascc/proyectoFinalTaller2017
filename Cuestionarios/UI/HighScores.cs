using System.Linq;
using System.Windows.Forms;
using Questionnaire.Controlers;

namespace UI
{
    public partial class HighScores : Form
    {
        private readonly UserController _usrController;
        public HighScores(UserController usrController)
        {
            _usrController = usrController;

            InitializeComponent();

            dgw_HighScores.DataSource = _usrController.GetHighScores().Select(o => new
            { Username = o.Username, Score = o.ScoreValue, TimeOnSeconds = o.SecondsUsed, DateOfScore = o.DateOfScore }).ToList();
        }
    }
}