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
        public OpentdbSource()
        {
            this.Url = "https://opentdb.com/api.php?";   //opentdb.com/api.php?amount=10&category=9&difficulty=easy&type=multiple
            this.Name = "opentdb";
        }

        public List<Question> GetQuestions(string pDificulty, int pCategory, int pAmount)
        {
            this.Url = "https://opentdb.com/api.php?" + "amount=" + pAmount + "&category=" + pCategory+9 + "&difficulty=" + pDificulty.ToLower() + "&type=multiple";

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
                            dificulty = (int)Enum.Parse(typeof(Dificulty), pDificulty),
                            category = pCategory,
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
            catch(Exception ex)
            {
                System.Console.WriteLine("Error: {0}", ex.Message);
            }

            return (questionsList);
        }
    }
}
