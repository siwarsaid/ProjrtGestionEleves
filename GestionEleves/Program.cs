using Newtonsoft.Json;
using System.ComponentModel.Design;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace GestionEleves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestionsDesEleves res;
            GestionsDesCours gesCour= new GestionsDesCours();
           

            try
            {
                res = JsonConvert.DeserializeObject<GestionsDesEleves>(File.ReadAllText(JSON.fichierJson));
                if (res == null)
                {
                    res = new GestionsDesEleves();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Fichier 'Eleves.json' introuvable");
                res = new GestionsDesEleves();

            }
            catch (JsonException ex)
            {
                Console.WriteLine("Erreur de lecture du fichier JSON." + ex.Message + " ---- stack ----" + ex.StackTrace);
                return;
            }
            Menu menuPrincipale = new Menu();
            menuPrincipale.AfficherMenu(res,gesCour);
        }

       


      



       
    }

}
public static class JSON
{
    public static string fichierJson = @"C:\Users\Siwar\formation\QuetesC#\GestionEleves\GestionEleves\Eleves.json";

}