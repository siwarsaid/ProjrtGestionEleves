using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves
{
    public class Eleve
    {
        public int IdEleve { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public List<ResultatScolaire> ResultatsScolaires { get; set; }
       
    }

    public class ResultatScolaire
    {
        public string Cours { get; set; }
        public string Note { get; set; }
        public string Appreciation { get; set; }
        public double Moyenne { get; set; }
    }

}
   

