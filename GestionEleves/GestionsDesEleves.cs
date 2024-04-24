using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves
{
    internal class GestionsDesEleves :Menu
    {
        public List<Eleve> Eleves { get; set; }
        public GestionsDesEleves() 
        {
             Eleves = new List<Eleve>();
        }
        
        public void CreerNouvelEleve()
        {
            Console.WriteLine("Entrez le nom de l'eleve : ");
            string nom = Console.ReadLine();

            Console.WriteLine("Entrez le prenom de l'eleve : ");
            string prenom = Console.ReadLine();

            Console.WriteLine("Entrez la datte de naissnace de l'eleve de forma (dd/mm/yyyy)");
            DateTime dNaissance;

            while(!DateTime.TryParseExact(Console.ReadLine(),"dd/mm/yyyy", null,System.Globalization.DateTimeStyles.None, out dNaissance))
             {
                Console.WriteLine("Format date invalide!! entrez une date de format dd/mm/yyyy SVP!! ");
             }

            Eleve nouvelEleve = new Eleve { Nom = nom, Prenom = prenom, DateDeNaissance = dNaissance };
            Eleves.Add(nouvelEleve);
            Console.WriteLine("Nouvel éleve crée avec succès !");
        }

         public static void AfficherListEleves(GestionsDesEleves res)
        {

            Console.WriteLine("Liste des élèves :");
            foreach (var eleve in res.Eleves)
            {
                Console.WriteLine($"Nom : {eleve.Nom}, Prénom : {eleve.Prenom}");
            }
            //AfficherListEleves(res);
        }
         public static void AfficheEleve(GestionsDesEleves res)
        {
            if (res == null || res.Eleves == null)
            {
                Console.WriteLine("Aucun éleve à afficher ");
                return;
            }
            Console.WriteLine("----------------------------------------------------------------------\r\nInformations sur l'élève : ");
            Console.WriteLine();
            foreach (var eleve in res.Eleves)
            {
                Console.WriteLine($"Nom               : {eleve.Nom}");
                Console.WriteLine($"Prénom            : {eleve.Prenom}");
                Console.WriteLine($"Date de naissance : {eleve.DateDeNaissance:dd/MM/yyyy}");
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Résultats scolaires:");
                Console.WriteLine();
                Console.WriteLine();

                foreach (var resultat in eleve.ResultatsScolaires)
                {
                    Console.WriteLine($"     Cours : {resultat.Cours}");
                    Console.WriteLine($"        Note : {resultat.Note}");
                    Console.WriteLine($"        Appréciation : {resultat.Appreciation}");
                    Console.WriteLine();
                    Console.WriteLine($"   Moyenne : {resultat.Moyenne}");
                    Console.WriteLine();
                }
                AfficheEleve(res);
            }


        }

    }
}