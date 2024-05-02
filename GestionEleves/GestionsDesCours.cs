using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEleves;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
namespace GestionEleves
{
    internal class GestionsMenuDesCours : MenuPrincipal
    {
        public GestionsMenuDesCours(Campus campus) : base(campus)
        {
          
        }


        public void AfficheMenuCour()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("1. Lister les cours existants :");
            Console.WriteLine("2. Ajouter un nouveau cours au programme :");
            Console.WriteLine("3. Supprimer un cours par son identifiant : ");
            Console.WriteLine("0. Revenir au menu principal : ");
            Console.WriteLine();
            Console.Write(" Entez votre choix : ");

            RevenirMenuPrincipale();

            int option = -1;
            while (option != 0)
            {
                string input = Console.ReadLine();
                int.TryParse(input, out option);
                if (option==0)
                {
                    Console.Clear();
                    AfficheChoixMenu();
                    break;
                }
                else if (option == 1)
                {

                    AfficherListeCours();
                    RevenirMenuPrincipale();

                }
                else if (option == 2)
                {
                    AjouterCour();
                    RevenirMenuPrincipale();
                }
                else if (option == 3)
                {
                    SupprimerCourParId();
                    RevenirMenuPrincipale();
                }
            }
        }

        public void AjouterCour()
        {
            
            Console.Write("ID du cours : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalide. Veuillez entrer un nombre entier.");
               
            }
            Console.Write("Nom du cours : ");
            string nom = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nom))
            {
                Console.Write("Veuillez entrer le nom du cours !");
               
            }

            Cour nouveauCour = new Cour(id, nom);

            bool existe = MonCampus.ListeCours.Any(c => c.IdCour == nouveauCour.IdCour || c.Nom == nouveauCour.Nom);
            Console.Write($"Voulez-vous ajouter cour  {nouveauCour.Nom} de ID {nouveauCour.IdCour} ? Y/N : ");
            var input = Console.ReadLine();
            Console.WriteLine();
            
            if (input.ToUpper() == "Y" && !existe)
            {
                MonCampus.ListeCours.Add(nouveauCour);
       
                MonCampus.SauvgarderEleveFichierJSON();
                Console.WriteLine("Cours ajouté avec succes !");
            }
            else
            {
                Console.WriteLine("Cei ID existe déjà !");
            }

        }



        public void AfficherListeCours()
        {

            if (MonCampus.ListeCours.Count > 0)
            {   
                Console.Clear();
                Console.WriteLine(" Liste de cours existant : \n");
                Console.WriteLine($" ID:".PadRight(10) + "   Nom:".PadRight(8));
                Console.WriteLine();
                foreach (Cour cours in MonCampus.ListeCours)
                {
                    Console.WriteLine($" {cours.IdCour.ToString().PadRight(10,' ')}  {cours.Nom}");
                }
            }
            else
            {
                Console.WriteLine("aucaun cours existants !!");
            }

        }

        public void SupprimerCourParId()
        {
            Console.Write("Entrez l'ID du cours à supprimer : ");
            if (!int.TryParse(Console.ReadLine(), out int idCour))
            {
                Console.WriteLine("Veuillez entrer un ID de cours valide!!");
                return;
            }

            var courASupp = MonCampus.ListeCours.FirstOrDefault(c => c.IdCour == idCour);
            if (courASupp != null)
            {
                Console.WriteLine("Etes-vous sur de vouloir supprimer ce cours ? (Y/N)");
                char inputSupp = char.ToUpper(Console.ReadKey().KeyChar);
                Console.ReadLine();

                if (inputSupp == 'Y')
                {
                    MonCampus.ListeCours.Remove(courASupp);
                    Console.WriteLine("Cours supprimé avec succès !");
                }
                else
                {
                    Console.WriteLine("Suppression annulée.");
                }
            }
            else
            {
                Console.WriteLine("Aucun cours trouvé avec cet ID.");
               
            }
        }

        



    }
}