using System;
using System.IO;
using System.Linq;



namespace taskmanager
{
    public class Taches
    {
        private int ident;
        private string nom;
        private string descriptif;
        private DateTime  deadline;
        private string types;

        public Taches(int ident,  string nom, string descriptif, DateTime  deadline, string types)
        {
            this.ident = ident;
            this.nom = nom;
            this.descriptif = descriptif;
            this.deadline = deadline;
            this.types = types;
        }
     
        //---------------------------------------------------
        // Nos attribut sont en privé pour en controler la modification nous devons donc créer des GETteur pour obtenir leur donner.
       
        public string GetNom()
        {
            return this.nom;
        }
         public int GetIdentifiant()
        {
            return this.ident;
        }

        public string GetDescriptif()
        {
            return this.descriptif;
        }

        public DateTime  GetDeadline()
        {
            return this.deadline;
        }

        public string GetTypes()
        {
            return this.types;
        }


        //---------------------------------------------------
        // Nos attribut sont en privé pour en controler la modification nous aurons donc certain Setteur permtant de modifier des elements.

        public void SetNom(string nom)
        {
            this.nom = nom;
        }

        public void SetDescriptif(string descriptif)
        {
            this.descriptif= descriptif;
        }

        public void SetTypes(string types)
        {
            this.types = types;
        }

        public void SetDeadline(DateTime  deadline)
        {
            this.deadline = deadline;
        }



        //--------------------------------------------------
        // Les METHODES.
    
        // méthode permetant de présenter la taches avec ces éléments essentielles.
        public string presentation()
        {
             return string.Format("La tache {0} porte le Numero {1} et dois ce finir le {2}", this.nom, this.ident, this.deadline);
        }

        // méthode permetant de présenter toutes la taches
        public void presentation_detailler()
        {
            Console.WriteLine("identifiant = {0}" ,this.ident);
            Console.WriteLine("nom = {0}" ,this.nom);
            Console.WriteLine("descriptif = {0}" ,this.descriptif);
            Console.WriteLine("date limite  = {0}" ,this.deadline);
            Console.WriteLine("types = {0}" ,this.types);
        }


        // méthode qui onvertie les composant de notre taches en chaine de caractère. 
        // chaine qui sera stocker ensuite dans un ficier texte à la fermeture de notre taches.
         public override string ToString()
        {
            return this.ident.ToString() + "," + this.nom + "," +  this.descriptif + "," + this.deadline.ToString() + "," + this.types;
        }
        

}
}
