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


        public double CalcMoyenne()
        {
            if (ResultatsScolaires == null || ResultatsScolaires.Count == 0)
            {
                return 0;
            }
            else
            {
                double som = 0;
                foreach (var resultat in ResultatsScolaires)
                {
                    som += resultat.Note;
                }
                double moyenne = som / ResultatsScolaires.Count;

                double partieDeci = moyenne - Math.Truncate(moyenne);
                if(partieDeci >= 0.3 && partieDeci <= 0.7)
                {
                    moyenne=Math.Floor(moyenne) +0.5;
                }
                if (partieDeci > 0.7)
                {
                    moyenne = Math.Ceiling(moyenne);
                }
                return moyenne;
            }

        }
       
        public class ResultatScolaire
        {
            public string Cours { get; set; }
            public double Note { get; set; }
            public string Appreciation { get; set; }
            public double Moyenne { get; set; }

            public ResultatScolaire(string cours, double note, string appreciation, double moyenne)
            {
                Cours = cours;
                Note = note;
                Appreciation = appreciation;
                Moyenne = moyenne;
            }
        }
    }
}

 