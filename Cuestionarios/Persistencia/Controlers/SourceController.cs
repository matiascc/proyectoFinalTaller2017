using System.Collections.Generic;
using Questionnaire.Source;

namespace Questionnaire.Controlers
{
    public class SourceController
    {
        public List<ISource> SourcesList { get; private set; }

        public SourceController()
        {
            SourcesList = new List<ISource>();
            //Adds each one of the Sources' clases to SourcesList
            this.SourcesList.Add(new OpentdbSource());
            //Must add to the list here each source that is implemented in the future
        }

        public ISource GetSourceByName(string pName)
        {
            return (SourcesList.Find(s => s.Name == pName));
        }
    }
}
