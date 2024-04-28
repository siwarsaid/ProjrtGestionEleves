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

        public List<Cour> ListeCours { get; set; } = new List<Cour>();


        public void AjouterCour()
        {
            Console.Write("ID du cours : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalide. Veuillez entrer un nombre entier.");
                return;
            }
            Console.Write("Nom du cours : ");
            string nom = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nom))
            {
                Console.Write("Veuillez entrer le nom du cours !");
                return;
            }

            Cour nouveauCour = new Cour(id, nom);


            bool existe = ListeCours.Any(c => c.IdCour == nouveauCour.IdCour || c.Nom == nouveauCour.Nom);
            Console.Write($"Voulez-vous ajouter ce cour  {nouveauCour.Nom} de ID {nouveauCour.IdCour} ? Y/N : ");

            char input = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            if (input == 'Y' && !existe)
            {
                ListeCours.Add(nouveauCour);
                Console.WriteLine("Cours ajouté avec succes !");
                //  SauvgarderCourFichierJSON();
            }
            else
            {
                Console.WriteLine("Ce cours existe déjà !");
            }

        }



        public void AfficherListeCours()
        {

            if (ListeCours.Count > 0)
            {
                Console.WriteLine("Liste de cours existant : ");
                foreach (Cour cours in ListeCours)
                {
                    Console.WriteLine($" {cours.Nom}");
                }
            }
            else
            {
                Console.WriteLine("aucaun cours existants !!");
            }

        }
       
        public void DeleteCours(Cour idcours)
        {
            var courASupp=ListeCours.FirstOrDefault(cour=>cour.IdCour==idcours.IdCour);
            if (courASupp != null)
            {
                Console.WriteLine("Avez-vous sur du suppression du cour?? 'Y/N ");
                char inputSupp = char.Parse(Console.ReadLine());
                if (inputSupp == 'Y')
                {
                    ListeCours.Remove(courASupp);
                    Console.WriteLine("Cour supprime avec succe ! ");
                }
                else
                {
                    Console.WriteLine("Appuiez sur '0' pour retourner au menu principal ");
                    RevenirMenuPrincipale();
                }
            }
            else
            {
                Console.WriteLine("Cour n'existe pas ");
            }
        }

        public void MenuPrincipal(Campus campus)
        {
            MenuPrincipal menu1 = new MenuPrincipal (MonCampus);
            Console.WriteLine("Si vous voulez revenir au menu principale appuiez sur 0 ");
            string menuPrincipal = Console.ReadLine();
            bool choixMenus = true;
            while (choixMenus)
            {
                if (menuPrincipal != "0")
                {
                    Console.WriteLine(" Appuiez-vous sur la bonne touche!!!, appuiez sur 0 ");
                    menuPrincipal = Console.ReadLine();
                }
                else
                {
                    choixMenus = false;
                }
            }
        }
        public void AfficheMenuCour()
        {
            Console.WriteLine();
            Console.WriteLine("1. Lister les cours existants :");
            Console.WriteLine("2. Ajouter un nouveau cours au programme :");
            Console.WriteLine("3. Supprimer un cours par son identifiant : ");
            Console.WriteLine("0. Revenir au menu principal : ");
            Console.WriteLine();
            Console.Write(" Entez votre choix : ");

            int option;
            var input = Console.ReadLine();
            int.TryParse(input, out option);
            
            if (option == 1)
            {
                AfficherListeCours();
            }
            else if (option == 2)
            {

                AjouterCour();
            }
            else if (option == 3)
            {
                Console.Write("Entrez l'ID du cour a supprime : ");
                int idCour;
                if (!int.TryParse(Console.ReadLine(), out idCour))
                {
                    Console.WriteLine("Veuillez entrer un ID de cours valide!!");
                    return;
                }
                var courASupp = ListeCours.FirstOrDefault(c => c.IdCour == idCour);
                if (courASupp != null)
                {
                    ListeCours.Remove(courASupp);

                    Console.WriteLine("Cours supprimé avec succès !");
                }
                else
                {
                    Console.WriteLine("Aucun cours trouvé avec cet ID.");
                }
            }
           // DeleteCours(cours);

            int choixCours;
            if (!int.TryParse(Console.ReadLine(), out choixCours))
            {
                Console.WriteLine("Veuillez entrer un nombre valide !!");
                return;
            }
            else if (option == 0)
            {
                
            }
            else
            {
                Console.WriteLine(" Option invalide!! Veuillez saisir une option valide!!");
            } 
            Console.WriteLine("");
            Console.WriteLine("Appuyer sur une touche pour revenir au menu principal");
            Console.ReadLine();
            Console.Clear();
            AfficheChoixMenu();

            
        }
    }
}
