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

            try
            {
                res = JsonConvert.DeserializeObject<GestionsDesEleves>(File.ReadAllText("Eleves.json"));
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
            catch (JsonException)
            {
                Console.WriteLine("Erreur de lecture du fichier JSON.");
                return;
            }
            Menu menuPrincipale = new Menu();
            menuPrincipale.AfficherMenu(res);
        }

       


      



       
    }
}