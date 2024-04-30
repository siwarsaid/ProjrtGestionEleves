namespace GestionEleves
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

            bool choix = true;
            while (choix)
            {
                string input = Console.ReadLine();

                int option;
                if (!int.TryParse(input, out option))
                {
                    Console.WriteLine("Option invalide!! Veuillez saisir un nombre(1 ou 2 ou 0");
                    Console.ReadKey();
                    Console.Clear();
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



        //protected void RevenirMenuPrincipale()
        //{
        //    do
        //    {
        //        Console.WriteLine();
        //        Console.WriteLine("0. Revenir au menu principal.");
        //        string menuPrincipal = Console.ReadLine();

        //        if (menuPrincipal != "0")
        //        {
        //            Console.WriteLine("Veuillez appuyer sur la touche '0' pour revenir au menu principal.");
        //        }
        //        else
        //        {
        //            break; 
        //        }
        //    } while (true); 
        //}



        protected void RevenirMenuPrincipale()
        {
            Console.WriteLine();
            Console.WriteLine("0. Revenir au menu principal.\n");
           
        }

        
    }
}
 
