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

       
        public void CreerNouvelEleve()
        {
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

            Eleve nouvelEleve = new Eleve { Nom = nom, Prenom = prenom, DateDeNaissance = dateNaissance };

            MonCampus.Eleves.Add(nouvelEleve);
            MonCampus.SauvgarderEleveFichierJSON();
            
            Console.WriteLine("Nouvel éleve crée avec succès ! \n");

        }

       
        public void AfficherListEleves()
        {
            Console.Clear();
            Console.WriteLine("Liste des élèves :\n");
            Console.WriteLine($"ID :".PadRight(10) + "Nom : ".PadRight(18) + " Prénom : \n");
            foreach (var eleve in MonCampus.Eleves)
            {
                Console.WriteLine($"{eleve.IdEleve.ToString().PadRight(8, ' ')}   {eleve.Nom.PadRight(10, ' ')}         {eleve.Prenom}");//aligner les prenoms
            }
            
        }

        public void AjouterResultatScolaire(Eleve eleve,string cours, double note, string appreciation,double moyenne)
        {
           
            if (eleve.ResultatsScolaires == null)
            {
                eleve.ResultatsScolaires = new List<Eleve.ResultatScolaire>();
            }

            ResultatScolaire nouveauResultat = new ResultatScolaire(cours, note, appreciation,moyenne)
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
            Console.Write("Entez l'ID de l'eleve pour ajouter une note : ");
            string input=Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Veuillez entrer l'ID de l'eleve !");
                return;
            }
            
            if (!int.TryParse(input, out int ideleve))
            {
                Console.WriteLine("L'ID entrer n'est pas valide!! Entrez un nombre.");
                return;
            }
            Console.WriteLine();

            Eleve eleve=MonCampus.Eleves.FirstOrDefault(e => e.IdEleve == ideleve);
            if(eleve == null)
            {
                Console.WriteLine("Aucun élève trouvé avec cet ID.");
                Console.WriteLine();
                return;
            }

            Console.Write("Entrez le nom du cours pour saisir une note : ");
            
               string cours = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(cours))
            {
                Console.Write("Veuillez entrer le nom du cours !");
                return;
            }
            Console.WriteLine(); 

            Console.Write("Ajoutez la note : ");
            double note;
            while (!double.TryParse(Console.ReadLine(), out note) || note<0 || note>20)
            {
                        
                Console.WriteLine(" Veuillez entrer une note valide entre 0 et 20!!");
            }

            Console.Write("Ajouter une appreciation (facultative) : ");
            string appreciation = Console.ReadLine();
           double moyenne= eleve.CalcMoyenne();
            AjouterResultatScolaire(eleve,cours, note,appreciation,moyenne);
            MonCampus.SauvgarderEleveFichierJSON();

            
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
           if(eleve == null)
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

            } Console.WriteLine("Aucun resultat scolaire disponible poue cet eleve");

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
            Console.WriteLine("----------------------------------------------------------------------\r\nInformations sur l'élève : ");
            Console.WriteLine() ;
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
            Console.WriteLine();
            Console.Write(" Entez votre choix : ");
            int option=-1;
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
                    RevenirMenuPrincipale() ;
                }
                
            }
        }
    }
}
