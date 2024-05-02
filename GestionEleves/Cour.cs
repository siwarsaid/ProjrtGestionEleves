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
            
                  
        public Cour() { }
        public Cour(int idCour, string nom)
        {
            IdCour = idCour;
            Nom = nom;
            
        }  
    }
}
