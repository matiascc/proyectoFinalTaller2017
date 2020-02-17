using System.Linq;
using System.Windows.Forms;
using Questionnaire.Controlers;
using System;

namespace UI
{
    public partial class HighScores : Form
    {
        private readonly UserController _usrController;
        private readonly static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public HighScores(UserController usrController)
        {
            _usrController = usrController;

            InitializeComponent();

            try
            {
                logger.Debug("Getting highscores");
                dgw_HighScores.DataSource = _usrController.GetHighScores().Select(o => new
                { Username = o.Username, Score = o.ScoreValue, TimeOnSeconds = o.SecondsUsed, DateOfScore = o.DateOfScore }).ToList();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Couldn't access highscores: ", exc.Message);
                logger.Debug("Couldn't access highscores: " + exc.Message);
            }
        }
    }
}