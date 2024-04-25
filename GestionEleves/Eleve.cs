using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public Eleve()
        {
            
        }
        public Eleve(string nom, string prenom, DateTime dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            DateDeNaissance = dateNaissance;
            ResultatsScolaires = new List<ResultatScolaire>();
        }
        public void AjouterResultatScolaire(string cours, double note, string appreciation)
        {
            ResultatScolaire nouveauResultat = new ResultatScolaire
            {
                Cours = cours,
                Note = note,
                Appreciation = appreciation
            };
            ResultatsScolaires.Add(nouveauResultat);
        }
    
        public double CalcMoyenne()
        {
            if (ResultatsScolaires == null || ResultatsScolaires.Count == 0)
            {
                return 0;
            }
            else
            {
                double som = 0;
                foreach(var resultat in ResultatsScolaires)
                {
                    som += resultat.Note;
                }
                double moyenne=som/ResultatsScolaires.Count;
                return moyenne;
            }

       
        
        }
    
      public class ResultatScolaire
      {
        public string Cours { get; set; }
        public double Note { get; set; }
        public string Appreciation { get; set; }
        public double Moyenne { get; set; }
      }

}   }

