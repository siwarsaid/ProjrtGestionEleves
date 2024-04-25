using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves
{
    public class Cour
    {
            public int IdCour {  get; set; }
            public string Nom { get; set; }
            public string Matiere { get; set; }
                  
        public Cour() { }
        public Cour(int idCour, string nom, string matiere)
        {
            IdCour = idCour;
            Nom = nom;
            Matiere = matiere;
                   }

        
        
    }
}
