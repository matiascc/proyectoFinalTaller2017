using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;
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
            this.Url = "https://opentdb.com/api.php?";   //opentdb.com/api.php?amount=10&category=9&difficulty=easy&type=multiple
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

        public List<Question> GetQuestions(string pDificulty, int pCategory, int pAmount)
        {
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

            List<Question> questionsList = new List<Question>();

            // Establecimiento del protocolo ssl de transporte
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Se crea el request http
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(Url);

            try
            {
                // Se ejecuta la consulta
                WebResponse mResponse = mRequest.GetResponse();

                // Se obtiene los datos de respuesta
                using (Stream responseStream = mResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                    // Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                    dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());

                    System.Console.WriteLine("Código de respuesta: {0}", mResponseJSON.response_code);

                    // Se iteran cada uno de los resultados.
                    foreach (var bResponseItem in mResponseJSON.results)
                    {
                        List<Option> optionList = new List<Option>();

                        optionList.Add(new Option
                        {
                            answer = bResponseItem.correct_answer,
                            correct = true
                        });

                        foreach (var opt in bResponseItem.incorrect_answers)
                        {
                            optionList.Add(new Option
                            {
                                answer = opt,
                                correct = false
                            });
                        }

                        questionsList.Add(new Question
                        {
                            question = bResponseItem.question,
                            difficulty = difficultyDictionary.FirstOrDefault(x => x.Value == bResponseItem.difficulty.ToString()).Key,
                            category = categoryDictionary.FirstOrDefault(x => x.Value == bResponseItem.category.ToString()).Key,
                            options = optionList
                        });

                    }
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
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: {0}", ex.Message);
            }

            return (questionsList);
        }

        private Dictionary<int, string> GetCategories()
        {
            Dictionary<int, string> categoriesDictionary = new Dictionary<int, string>();
            categoriesDictionary.Add(0, "Any Category");

            this.Url = "https://opentdb.com/api_category.php";

            // Establecimiento del protocolo ssl de transporte
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Se crea el request http
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(Url);

            try
            {
                // Se ejecuta la consulta
                WebResponse mResponse = mRequest.GetResponse();

                // Se obtiene los datos de respuesta
                using (Stream responseStream = mResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                    // Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                    dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());

                    System.Console.WriteLine("Código de respuesta: {0}", mResponseJSON.response_code);

                    // Se iteran cada uno de los resultados.
                    foreach (var category in mResponseJSON.trivia_categories)
                    {
                        int id = category.id;
                        string name = category.name;
                        categoriesDictionary.Add(id, name);
                    }
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
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: {0}", ex.Message);
            }

            return (categoriesDictionary);
        }
    }
}
