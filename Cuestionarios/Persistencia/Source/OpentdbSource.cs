using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using Questionnaire.Domain;

namespace Questionnaire.Source
{
    public class OpentdbSource : ISource
    {
        public string Url { get; private set; }
        public string Name { get; private set; }
        public Dictionary<int, string> categoryDictionary { get; private set; }
        public Dictionary<int, string> difficultyDictionary { get; private set; }
        public OpentdbSource()
        {
            this.Url = "https://opentdb.com/api.php?";   //Url example: opentdb.com/api.php?amount=10&category=9&difficulty=easy&type=multiple
            this.Name = "opentdb";
            this.categoryDictionary = GetCategories();
            this.difficultyDictionary = new Dictionary<int, string>()
                                            {
                                                {0,"easy"},
                                                {1,"medium"},
                                                {2,"high"},
                                                {3,"any dificulty"},
                                            }; ;
        }

        /// <summary>
        /// Get Questions
        /// </summary>
        public List<Question> GetQuestions(string pDificulty, int pCategory, int pAmount)
        {
            //Creates the url
            string category, dificulty;
            if (pCategory == 0)
            {
                category = "";
            }
            else
            {
                category = "&category=" + pCategory;
            }
            if (pDificulty == "any dificulty")
            {
                dificulty = "";
            }
            else
            {
                dificulty = "&difficulty=" + pDificulty.ToLower();
            }
            this.Url = "https://opentdb.com/api.php?" + "amount=" + pAmount + category + dificulty + "&type=multiple";

            dynamic mResponseJSON = CallTheQuestionAPI(this.Url);

            List<Question> questionsList = new List<Question>();

            foreach (var bResponseItem in mResponseJSON.results)
            {
                List<Option> optionList = new List<Option>();
                        
                //Mark the correct answer
                optionList.Add(new Option
                {
                    Answer = bResponseItem.correct_answer,
                    Correct = true
                });

                //Adds the other answers
                foreach (var opt in bResponseItem.incorrect_answers)
                {
                    optionList.Add(new Option
                    {
                        Answer = opt,
                        Correct = false
                    });
                }

                questionsList.Add(new Question
                {
                    QuestionSentence = bResponseItem.question,
                    Difficulty = difficultyDictionary.FirstOrDefault(x => x.Value == bResponseItem.difficulty.ToString()).Key,
                    Category = categoryDictionary.FirstOrDefault(x => x.Value == bResponseItem.category.ToString()).Key,
                    Options = optionList
                });
            }

            return (questionsList);
        }

        private Dictionary<int, string> GetCategories()
        {
            this.Url = "https://opentdb.com/api_category.php";

            dynamic mResponseJSON = CallTheQuestionAPI(this.Url);

            Dictionary<int, string> categoriesDictionary = new Dictionary<int, string>
            {
                { 0, "Any Category" }
            };

            //Each of the results is iterated
            foreach (var category in mResponseJSON.trivia_categories)
            {
                int id = category.id;
                string name = category.name;
                categoriesDictionary.Add(id, name);
            }

            return (categoriesDictionary);

        }

        /// <summary>
        /// Gets a response form the URL
        /// </summary>
        private dynamic CallTheQuestionAPI(string pUrl)
        {
            // Establishment of the transport ssl protocol
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // The request http is created
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(pUrl);

            try
            {
                // The query is executed
                WebResponse mResponse = mRequest.GetResponse();

                // The response data is obtained
                using (Stream responseStream = mResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                    // The response is parsed and JSON is serialized to a dynamic object
                    dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());

                    System.Console.WriteLine("Código de respuesta: {0}", mResponseJSON.response_code);

                    if (mResponseJSON == null)
                    {
                        throw new ArgumentNullException(nameof(mResponseJSON));
                    }

                    return mResponseJSON;
                }
            }
            catch (WebException ex)
            {
                WebResponse mErrorResponse = ex.Response;
                using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                {
                    StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                    String mErrorText = mReader.ReadToEnd();

                    System.Console.WriteLine("Error: {0}", mErrorText);
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: {0}", ex.Message);
                return null;
            }
        }
    }
}
