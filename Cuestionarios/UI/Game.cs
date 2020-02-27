using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Questionnaire.Controlers;
using Questionnaire.Domain;
using Questionnaire.Source;
using System.Diagnostics;
using Npgsql;

namespace UI
{
    public partial class Game : Form
    {
        private readonly UserController _usrController;
        private readonly QuestionController _questController;
        private readonly SourceController _sourceController;
        private readonly GameController _gameController;

        private readonly int totalQuestions;
        private readonly int difficulty;
        private readonly int category;
        private List<Question> questionsList;
        private int actualQuestion;
        private int correctAnswers;
        private Stopwatch sw;
        private ISource pSource;
        private readonly static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Game(UserController usrController, QuestionController questController, SourceController sourceController, GameController gameController, User user, String setName, String pDifficulty, String pCategory, decimal pAmount) //ISource pSource, string pDificulty, int pCategory, int pAmount, 
        {
            _usrController = usrController;
            _questController = questController;
            _sourceController = sourceController;
            _gameController = gameController;
            pSource = _sourceController.GetSourceByName(setName);
            InitializeComponent();

            logger.Debug("Starting new game");
            //Start Timer
            sw = new Stopwatch();
            timer1.Start();
            sw.Start();

            //Initialize Values
            l_username.Text = user.Username;
            difficulty = pSource.DifficultyDictionary.FirstOrDefault(x => x.Value == pDifficulty).Key;
            category = pSource.CategoryDictionary.FirstOrDefault(x => x.Value == pCategory).Key;
            totalQuestions = Decimal.ToInt32(pAmount);
            actualQuestion = 1;
            correctAnswers = 0;

            try
            {
                logger.Debug("Getting questions from database");
                questionsList = _questController.GetQuestions(pSource, difficulty, category, totalQuestions);
            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show("Error: couldn't find enough questions with those characteristics: ", exc.Message);
                logger.Debug("Error: couldn't find enough questions with those characteristics: " + exc.Message);
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

            

            //Show first question
            ShowQuestion();
        }

        /// <summary>
        /// Increase timer
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            l_time.Text = sw.Elapsed.TotalSeconds.ToString().Substring(0, 4) + " sec";
        }

        private void ShowQuestion()
        {
            if(actualQuestion <= totalQuestions)
            {
                l_question.Text = questionsList[actualQuestion - 1].QuestionSentence;

                b_opt1.Text = questionsList[actualQuestion - 1].Options[0].Answer;
                b_opt2.Text = questionsList[actualQuestion - 1].Options[1].Answer;
                b_opt3.Text = questionsList[actualQuestion - 1].Options[2].Answer;
                b_opt4.Text = questionsList[actualQuestion - 1].Options[3].Answer;

                l_numQuestion.Text = "Question " + actualQuestion + "/" + totalQuestions + ":";
            }
            else
            {
                logger.Debug("Game ended");
                timer1.Stop();
                sw.Stop();
                double time = Convert.ToDouble(sw.Elapsed.Seconds.ToString());

                double score = _gameController.CalculateScore(pSource, correctAnswers, totalQuestions, difficulty, time);
                
                try
                {
                    logger.Debug("Saving new Score");
                    _usrController.SaveScore(l_username.Text, score, time);
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
                
                MessageBox.Show("Final Score: " + score.ToString());

                this.Owner.Show();
                this.Close();
            }
        }

        private void b_opt1_Click(object sender, EventArgs e)
        {
            CheckAnswer(1);
        }

        private void b_opt2_Click(object sender, EventArgs e)
        {
            CheckAnswer(2);
        }

        private void b_opt3_Click(object sender, EventArgs e)
        {
            CheckAnswer(3);
        }

        private void b_opt4_Click(object sender, EventArgs e)
        {
            CheckAnswer(4);
        }

        private void CheckAnswer(int optionSelected)
        {
            if (questionsList[actualQuestion - 1].Options[optionSelected - 1].Correct)
            {
                MessageBox.Show("Correct Answer");
                correctAnswers += 1;
            }
            else
            {
                MessageBox.Show("Incorrect Answer");
            }

            //Show next question
            ++actualQuestion;
            ShowQuestion();
        }

        private new void FormClosed(object sender, FormClosingEventArgs e)
        {
            logger.Debug("Game quit");
            this.Owner.Show();
        }

        private void b_quit_Click(object sender, EventArgs e)
        {
            logger.Debug("Game quit");
            this.Owner.Show();
            this.Close();
        }

    }
}
