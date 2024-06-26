﻿namespace GestionEleves
{
    using System;

    internal class MenuPrincipal
    {
        public Campus MonCampus { get; set; }


        public MenuPrincipal(Campus campus)
        {
            MonCampus = campus;
        }

        public void AfficherMenu(Campus campus)
        {
            AfficheChoixMenu();
            GestionMenuEleve gestionMenuEleve = new GestionMenuEleve(campus);
            GestionsMenuDesCours gestionsDesCours = new GestionsMenuDesCours(campus);

        
            while (true)
            {
                string input = Console.ReadLine();

                int option;
                if (!int.TryParse(input, out option))
                {
                    Console.WriteLine();
                    Console.WriteLine("Option invalide!! saisir '1' ou '2' ");
                    //Console.Clear();
                    continue;
                }
                if (option == 0)
                {
                    AfficheChoixMenu();
                }
                if (option == 1)
                {
                    gestionMenuEleve.AfficherEleve();
                    AfficheChoixMenu();
                }
                else if (option == 2)
                {
                    gestionsDesCours.AfficheMenuCour();

                    AfficheChoixMenu();
                }
            }
        }

        protected void AfficheChoixMenu()
        {
            Console.Clear();
            Console.WriteLine("Le menus : \n ");
            Console.WriteLine("    1: Eleves");
            Console.WriteLine("    2: Cours \n");
            Console.WriteLine();
            Console.Write("    Entrez votre choix : ");
        }

        
        protected void RevenirMenuPrincipale()
        {
            Console.WriteLine();
            Console.WriteLine("0. Revenir au menu principal.\n");
           
        }

        
    }
}
 
