using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves
{
    internal class Menu 
    {
        public void AfficherMenu(GestionsDesEleves gestionsDesEleves, GestionsDesCours gestionsDesCours)
        {
            Cour cours = new Cour();
            AfficheChoixMenu();
            
            bool choix = true;
            while (choix)
            {
                string input = Console.ReadLine();

                int option;
                if (!int.TryParse(input, out option))
                {
                    Console.WriteLine("Option invalide!! Veuillez saisir un nombre(1 ou 2 ou 0");
                    Console.WriteLine("Appuyez sur une touche pour continuer.. ");

                    Console.ReadKey();

                    Console.Clear();
                    continue;
                }


                if (option == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Lister les élèves");
                    Console.WriteLine("2. Créer un nouvel élève");
                    Console.WriteLine("3. Consulter un élève existant :");
                    Console.WriteLine("4. Ajouter une note et une appréciation pour un cours sur un élève existant : \n");
                    Console.WriteLine("0. Revenir au menu principal :");
                    Console.Write(" Entez votre choix : ");

                   input = Console.ReadLine();
                   int.TryParse(input, out option);
                        if (option == 1)
                        {

                           gestionsDesEleves.AfficherListEleves();

                        }
                        else if (option == 2)
                        {
                        gestionsDesEleves.CreerNouvelEleve();
                        }
                        else if(option == 3)
                        {
                        Console.WriteLine("Entrez l'ID de l'eleve que souhaitez-vous : ");
                         int idEleve=Int32.Parse( Console.ReadLine());

                        }

                }


                else if (option == 2)
                {
                    Console.WriteLine("1. Lister les cours existants :");
                    Console.WriteLine("2. Ajouter un nouveau cours au programme :");
                    Console.WriteLine("3. Supprimer un cours par son identifiant : ");
                    Console.WriteLine("0. Revenir au menu principal : ");
                    Console.WriteLine();
                    Console.Write(" Entez votre choix : ");

                    GestionsDesCours gestionsCours = new GestionsDesCours();
                    input= Console.ReadLine();
                    int.TryParse(input, out option);

                    if(option == 1) 
                    {
                        gestionsCours.AfficherListeCours();
                    }
                    else if (option == 2)
                    {
                      
                       gestionsCours.AjouterCour();
                    }
                    else if (option == 3)
                    {
                        Console.Write("Entrez l'ID du cour a supprime : ");
                        int idCour=Int32.Parse( Console.ReadLine());
                        gestionsCours.ListeCours.First(c => c.IdCour == idCour);
                        gestionsCours.DeleteCours(cours);
                    }
                      int choixCours=int.Parse(Console.ReadLine());
                      gestionsCours.AfficherListeCours();
                }
                else if (option == 0)
                {
                    choix = false;
                }
                else
                {
                    Console.WriteLine(" Option invalide!! Veuillez saisir une option valide!!");
                }

                Console.WriteLine("");
                Console.WriteLine("Appuyer sur une touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear ();
                AfficheChoixMenu();


            }



        }

        private static void AfficheChoixMenu()
        {
            Console.WriteLine("Le menus : \n ");
            Console.WriteLine("    1: Eleves");
            Console.WriteLine("    2: Cours");
            Console.WriteLine("    0: Quitter");
            Console.Write("    Entrez votre choix : ");
           
        }
    }
}