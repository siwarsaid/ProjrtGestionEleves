using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves
{
    internal class Campus 
    {
        public List<Eleve> Eleves { get; set; }
        public List<Cour> ListeCours { get; set; }
        public Campus() 
        {
             Eleves = new List<Eleve>();
            ListeCours = new List<Cour>();
        }
     
        public void SauvgarderEleveFichierJSON()
        {
            string jsonElev=JsonConvert.SerializeObject(this,Formatting.Indented);
            File.WriteAllText(JSON.fichierJson,jsonElev);
        }
        
       
    }
}