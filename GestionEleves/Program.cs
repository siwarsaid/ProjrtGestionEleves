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
            Campus campus;
            try
            {
                campus = JsonConvert.DeserializeObject<Campus>(File.ReadAllText(JSON.fichierJson));
                if (campus == null)
                {
                    campus = new Campus();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Fichier 'Eleves.json' introuvable");
                campus = new Campus();

            }
            catch (JsonException ex)
            {
                Console.WriteLine("Erreur de lecture du fichier JSON." + ex.Message + " ---- stack ----" + ex.StackTrace);
                return;
            }

            MenuPrincipal menuPrincipale = new MenuPrincipal(campus);
            menuPrincipale.AfficherMenu(campus);

            

        }
        public static void ChargerJson(Campus campus)
        {
            if (File.Exists(JSON.fichierJson))
            {
                string json=File.ReadAllText(JSON.fichierJson);
                for(int i = 0; i < campus.Eleves.Count; i++)
                {
                     campus.Eleves[i].IdEleve = i + 1; 
                }
            }
        }
    }
}
public static class JSON
{
    public static string fichierJson = @"C:\Users\Siwar\formation\QuetesC#\GestionEleves\GestionEleves\Eleves.json";

}
