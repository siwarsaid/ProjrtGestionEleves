namespace GestionEleves
{
    using Microsoft.VisualBasic.FileIO;
    using System;
    using System.Linq;
    using static System.Runtime.InteropServices.JavaScript.JSType;
    using System.Text;
    using System.Runtime.InteropServices.Marshalling;
    using static GestionEleves.Eleve;


    internal class GestionMenuEleve : MenuPrincipal
    {

        public GestionMenuEleve(Campus campus) : base(campus)
        {
        }


        public void AfficherEleve()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("1. Lister les élèves.");
            Console.WriteLine("2. Créer un nouvel élève. ");
            Console.WriteLine("3. Consulter un élève existant.");
            Console.WriteLine("4. Ajouter une note et une appréciation pour un cours sur un élève existant.");

            RevenirMenuPrincipale();

            Console.Write(" Entez votre choix : ");
            int option = -1;
            while (option != 0)
            {
                string input = Console.ReadLine();

                int.TryParse(input, out option);

                if (option == 1)
                {
                    AfficherListEleves();
                    RevenirMenuPrincipale();
                }
                else if (option == 2)
                {
                    CreerNouvelEleve();
                    RevenirMenuPrincipale();

                }
                else if (option == 3)
                {

                    ConsulterEleveId();
                    RevenirMenuPrincipale();
                }
                else if (option == 4)
                {

                    AjouterNotes();
                    RevenirMenuPrincipale();
                }

            }
        }

        public void CreerNouvelEleve()
        {
            Console.WriteLine();
            Console.WriteLine("Entrez le nom de l'eleve : ");
            string nom = Console.ReadLine();

            Console.WriteLine("Entrez le prenom de l'eleve : ");
            string prenom = Console.ReadLine();

            DateTime dateNaissance;
            bool dateValide;
            do
            {
                Console.WriteLine("Entrez la date de naissnace de l'eleve de forma (dd/mm/yyyy)");
                string inputDate = Console.ReadLine();
                if (inputDate == "0")
                {
                    RevenirMenuPrincipale();
                    return;
                }
                dateValide = DateTime.TryParseExact(inputDate, "dd/mm/yyyy", null, System.Globalization.DateTimeStyles.None, out dateNaissance);
                if (!dateValide)
                {
                    Console.WriteLine("Date invalide! Entrez une date au format dd/mm/yyyy ou appuyez sur 0 pour revenir au menu principal.");
                }
            }
            while (!dateValide);

            int nextId = 1;
            if (MonCampus.Eleves.Count() > 0)
            {
                nextId = MonCampus.Eleves.Max(e => e.IdEleve) + 1;
            }

            Eleve nouvelEleve = new Eleve { IdEleve = nextId, Nom = nom, Prenom = prenom, DateDeNaissance = dateNaissance };

            MonCampus.Eleves.Add(nouvelEleve);
            MonCampus.SauvgarderEleveFichierJSON();
            Console.WriteLine();
            Console.WriteLine("Nouvel éleve crée avec succès ! \n");

        }


        public void AfficherListEleves()
        {
            Console.Clear();
            Console.WriteLine(" Liste des élèves :\n");
            if (MonCampus.Eleves == null || MonCampus.Eleves.Count == 0)
            {
                Console.WriteLine("Aucun éleve dans la liste.");
            }
            else
            {
                Console.WriteLine($" ID :".PadRight(10) + "   Nom : ".PadRight(20) + "  Prénom : \n");
                foreach (var eleve in MonCampus.Eleves)
                {
                    if (eleve != null)
                    {
                        Console.WriteLine($" {eleve.IdEleve.ToString().PadRight(8, ' ')}    {eleve.Nom.PadRight(10, ' ')}         {eleve.Prenom}");//aligner les prenoms
                    }

                }
            }
        }

        public void AjouterResultatScolaire(Eleve eleve, string cours, double note, string appreciation, double moyenne)
        {

            if (eleve.ResultatsScolaires == null)
            {
                eleve.ResultatsScolaires = new List<Eleve.ResultatScolaire>();
            }

            ResultatScolaire nouveauResultat = new ResultatScolaire(cours, note, appreciation, moyenne)
            {
                Cours = cours,
                Note = note,
                Appreciation = appreciation,
                Moyenne = moyenne
            };
            eleve.ResultatsScolaires.Add(nouveauResultat);
            Console.WriteLine();
            Console.WriteLine("Note ajoutée avec succée.");
        }

        public void AjouterNotes()
        {
            Eleve eleve = null;
            int ideleve;
            do
            {
                Console.Write("Entrez l'ID de l'élève : ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Veuillez entrer l'ID de l'élève !\n");
                    continue;
                }

                if (!int.TryParse(input, out ideleve))
                {
                    Console.WriteLine("L'ID entré n'est pas valide. Veuillez entrer un nombre entier.\n");
                    continue;
                }

                 eleve = MonCampus.Eleves.FirstOrDefault(e => e.IdEleve == ideleve);
                if (eleve == null)
                {
                    Console.WriteLine("Aucun élève trouvé avec cet ID.");
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
            } while (true);
            
            if(eleve== null)
            {
                Console.WriteLine("Il n'y a aucun éleve dans la liste.\n");
                return;
            }
            else
            {
                bool courExist = false;
                do
                {
                    Console.Write("Entrez le nom du cours pour saisir une note : ");
                    string cours = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(cours))
                    {
                        Console.Write("Veuillez entrer le nom du cours ! \n");
                        continue;
                    }
                    courExist = MonCampus.ListeCours.Any(c => c.Nom.ToLower() == cours.ToLower());

                    if (!courExist)
                    {
                        Console.WriteLine(" Ce cour n'existe pas !!  ");

                    }
                    else
                    {
                        Console.Write("Ajoutez la note : ");
                        double note;
                        while (!double.TryParse(Console.ReadLine(), out note) || note < 0 || note > 20)
                        {

                            Console.WriteLine(" Veuillez entrer une note valide entre 0 et 20!!");
                        }

                        Console.Write("Ajouter une appreciation (facultative) : ");
                        string appreciation = Console.ReadLine();
                        double moyenne = eleve.CalcMoyenne();
                        AjouterResultatScolaire(eleve, cours, note, appreciation, moyenne);
                        MonCampus.SauvgarderEleveFichierJSON();
                        break; //sortor de la boucle si l'ajout de note sera effectuee avec succ
                    }
                }
                while (true);
            }
        }
        public void ConsulterEleveId()
        {
            Console.Clear();
            Console.WriteLine("entrez l'ID de l'eleve : ");
            int ideleve = Int32.Parse(Console.ReadLine());
            if (MonCampus == null || MonCampus.Eleves == null)
            {
                Console.WriteLine("Aucun éleve à afficher ");
                return;
            }

            var eleve = MonCampus.Eleves.FirstOrDefault(e => e.IdEleve == ideleve);
            if (eleve == null)
            {
                Console.WriteLine("Aucun eleve trouve avec cet ID \n");

                return;
            }
            Console.WriteLine("----------------------------------------------------------------------\r\nInformations sur l'élève : ");
            Console.WriteLine();
            Console.WriteLine($"Nom               : {eleve.Nom}");
            Console.WriteLine($"Prénom            : {eleve.Prenom}");
            Console.WriteLine($"Date de naissance : {eleve.DateDeNaissance:dd/mm/yyyy}");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Résultats scolaires:");
            Console.WriteLine();
            Console.WriteLine();
            if (eleve.ResultatsScolaires == null || eleve.ResultatsScolaires.Count == 0)
            {
                Console.WriteLine("Aucun resultat scolaire disponible pour cet eleve");
            }
            if (eleve.ResultatsScolaires != null) 
            { 

               foreach (var resultat in eleve.ResultatsScolaires)
               {
                Console.WriteLine($"     Cours : {resultat.Cours}");
                Console.WriteLine($"        Note : {resultat.Note}");
                Console.WriteLine($"        Appréciation : {resultat.Appreciation}");
                Console.WriteLine();
               }
            eleve.CalcMoyenne();
            Console.WriteLine($"     Moyenne : {eleve.CalcMoyenne()}");
            Console.WriteLine();
            MonCampus.SauvgarderEleveFichierJSON();
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
            }
        }
       
    }
}
