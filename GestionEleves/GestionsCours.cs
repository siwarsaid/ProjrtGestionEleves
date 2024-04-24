using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEleves; 
namespace GestionEleves
{
    internal class GestionsCours :Menu
    {

       
        private List<Cours> ListeCours { get; set; } = new List<Cours>();


        public void AfficherListeCours( int choix)
        {
            Console.WriteLine("Appuiez sur * pour lister tous les cours existants :");
            string saisie = Console.ReadLine();
            if (saisie != "*")
            {
                Console.WriteLine("Pour lister les cours ,appuiez sur la touche * ");
            }
            if (saisie == "*")
            {
                if (ListeCours.Count > 0)
                {
                    Console.WriteLine("Liste de cours existant : ");
                    foreach (Cours cours in ListeCours)
                    {
                        Console.WriteLine($" {cours.Nom}");
                    }
                }
                else
                {
                    Console.WriteLine("aucaun cours existants !!");
                }
            }
        }
        public void AddCours(Cours cours)
        {

            bool existe = false;
            foreach (Cours cour in ListeCours)
            {
                if (cour.IdCour == cours.IdCour || cour.Nom == cours.Nom)
                {
                    existe = true;
                    Console.WriteLine("Ce cours existe déja !");
                    break;

                }
            }
            if (!existe)
            {
                ListeCours.Add(cours);
                Console.WriteLine("Cours ajouté avec succes !");
            }
        }

        public void DeleteCours(Cours cours)
        {
            bool deletee = false;
            foreach (Cours cour in ListeCours)
            {
                if (cour.IdCour == cours.IdCour)
                {
                    deletee = true;
                    Console.WriteLine("cours supprimer avec succes");
                    break;
                }
                if (!deletee)
                {
                    Console.WriteLine("Ce cours n'existe pas !");
                }
            }
        }
        public void MenuPrincipal(Menu menuCours)
        {
            Console.WriteLine("Si vous voulez revenir au menus principale appuiez sur 0 ");
            string menuPrincipal = Console.ReadLine();
            bool choixMenus = true;
            while (choixMenus)
            {
                if (menuPrincipal != "0")
                {
                    Console.WriteLine("Vouz avez pas appuiez sur la bonne touche!!!, appuiez sur 0 ");
                    menuPrincipal = Console.ReadLine();
                }
                //else
                //{

                //    Menu menu = new Menu();
                //    menuCours.AfficherMenu(gestionsDesEleves);
                //    choixMenus = false;
                //}
            }
        }
    }
}

