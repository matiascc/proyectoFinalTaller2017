using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Questionnaire.Controlers;
using Questionnaire.DTOs;
using Questionnaire.Domain;
using Questionnaire.Source;
using System.Diagnostics;

namespace UI
{
    public partial class Game : Form
    {
        private readonly UserController _usrController;
        private readonly SetController _setController;
        private readonly QuestionController _questController;
        private readonly SourceController _sourceController;

        private List<QuestionDTO> questionsList;
        private int actualQuestion;
        private int totalQuestions;
        private int correctAnswers;
        private int difficulty;

        private static Random rng = new Random();
        private Stopwatch sw;

        public Game(UserController usrController, SetController setController, QuestionController questController, SourceController sourceController, UserDTO user) //ISource pSource, string pDificulty, int pCategory, int pAmount, 
        {
            _usrController = usrController;
            _setController = setController;
            _questController = questController;
            _sourceController = sourceController;

            //Datos inicializacion provisorios ¡¡¡Borrar luego!!!
            ////Borrar
            ///Borrar
            ISource pSource = _sourceController.GetSourceByName("opentdb");
            string pDificulty = "easy";
            int pCategory = 0;
            int pAmount = 5;

            InitializeComponent();

            //Start Timer
            sw = new Stopwatch();
            timer1.Start();
            sw.Start();

            //Initialize Values
            difficulty = pSource.difficultyDictionary.FirstOrDefault(x => x.Value == pDificulty).Key;
            l_username.Text = user.Username;
            totalQuestions = pAmount;
            actualQuestion = 1;
            correctAnswers = 0;
            questionsList = _questController.GetQuestions(pSource, pDificulty, pCategory, pAmount);
            
            ShowQuestion();
        }

        /// <summary>
        /// Increase timer
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            l_time.Text = sw.Elapsed.TotalSeconds.ToString().Substring(0, 4) + " sec";
        }

        /// <summary>
        /// Shuffle array of options
        /// </summary>
        private void Shuffle(IList<Option> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Option value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void ShowQuestion()
        {
            if(actualQuestion <= totalQuestions)
            {
                l_question.Text = questionsList[actualQuestion - 1].QuestionSentence;

                Shuffle(questionsList[actualQuestion - 1].Options);

                b_opt1.Text = questionsList[actualQuestion - 1].Options[0].Answer;
                b_opt2.Text = questionsList[actualQuestion - 1].Options[1].Answer;
                b_opt3.Text = questionsList[actualQuestion - 1].Options[2].Answer;
                b_opt4.Text = questionsList[actualQuestion - 1].Options[3].Answer;

                l_numQuestion.Text = "Question " + actualQuestion + "/" + totalQuestions + ":";
            }
            else
            {
                timer1.Stop();
                sw.Stop();
                double score = CalculateScore(correctAnswers, totalQuestions, difficulty, Convert.ToInt32(sw.Elapsed.Seconds.ToString()));
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

            ++actualQuestion;
            ShowQuestion();
        }

        private double CalculateScore(int correctAnswers, int totalQuestions, int difficulty, double time)
        {
            int difficultyFactor, timeFactor;
            switch (difficulty)
            {
                case 0:
                    difficultyFactor = 1;
                    break;
                case 1:
                    difficultyFactor = 3;
                    break;
                default:
                    difficultyFactor = 5;
                    break;
            }

            if (time < 5)
            {
                timeFactor = 5;
            }
            else if(time >= 5 && time <= 20)
            {
                timeFactor = 3;
            }
            else
            {
                timeFactor = 1;
            }

            return ((double)correctAnswers / (double)totalQuestions * (double)difficultyFactor * (double)timeFactor);
        }

        private new void FormClosed(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }

        private void b_quit_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
