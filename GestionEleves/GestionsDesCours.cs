using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEleves; 
namespace GestionEleves
{
    internal class GestionsDesCours : Menu
    {


        public List<Cour> ListeCours { get; set; } = new List<Cour>();


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


        public void AjouterCour()
        {

            Console.WriteLine("Voulez-vous ajouter un cour? Y/N");
            char input = char.Parse(Console.ReadLine());
            if (input == 'Y')
            {
                Console.Write("ID du cours : ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Nom du cours : ");
                string nom = Console.ReadLine();

                Console.Write("Matière : ");
                string matiere = Console.ReadLine();
                Cour nouveauCour = new Cour(id, nom, matiere);


                bool existe = false;
                foreach (Cour cour in ListeCours)
                {
                    if (cour.IdCour == nouveauCour.IdCour || cour.Nom == nouveauCour.Nom || cour.Matiere == nouveauCour.Matiere)
                    {
                        existe = true;
                        Console.WriteLine("Ce cours existe déja !");
                        break;

                    }
                }
                if (!existe)
                {
                    ListeCours.Add(nouveauCour);
                    Console.WriteLine("Cours ajouté avec succes !");
                }
            }
            else
            {
                //MenuPrincipal();
            }
        }
        
        public void DeleteCours(Cour cours)
        {
            bool deletee = false;
            foreach (Cour  cour in ListeCours)
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
        public void MenuPrincipal(GestionsDesEleves gestionsDesEleves)
        {
            Menu menu1 = new Menu();
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
                else
                {
                    
                    choixMenus = false;
                }
            }
        }
    }
}

