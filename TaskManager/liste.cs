using System;
using System.Text;
using taskmanager; 
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ListeTask
{
    public class Liste 
    {

        private List<Taches> list_task;


        // création d'une liste en utilisans l'objet List déja existant. 
        // on utilisara certain de ces méthodes.
        public Liste()
        {
            this.list_task = new List<Taches>();

        }

       
//------------------------------------------------------------------------------------------------------------------------------
        //methodes 
//------------------------------------------------------------------------------------------------------------------------------
    

        // permet de connaitre le nombre d'element dans la liste.
        public int nb_element_liste()
        {
            return list_task.Count;
        }
      
        // la tache as besoin d'un identifiant pour être créer.
        // pour qu'il ce créer de manière automatique et unique on parcour notre liste pour obtenir l'élément avec le plus grand identifiant
        // on incrémente ensuite cette identifiant de 1.
        public int identifiantzzz()
        {

            int max=0;
            foreach (Taches tasks in this.list_task)
            {
                if (max<tasks.GetIdentifiant()) 
                {
                    max=tasks.GetIdentifiant();
                }       
            }
            return (max+1);
        }

        // on parcour la liste et on fais appel a la fonction presentation() contenue dans l'objet task
        public  void presentation_tache()
        {
            foreach (Taches tasks in this.list_task)
            {
                Console.WriteLine(tasks.presentation());
            }
            Console.WriteLine("taper sur une touche pour revenir au menue principale !");
            Console.ReadLine();
        }

        // on parcour la liste et on fais appel a la fonction presentation_detailler() contenue dans l'objet task     
        public void presentation_detailler(int identifiant)
        { 
            foreach (Taches tasks in list_task){
                if (identifiant==tasks.GetIdentifiant()){
                    tasks.presentation_detailler();break;
                }else {
                    Console.WriteLine("élément inexistant"); break;
                }
            }
            Console.WriteLine("taper sur une touche pour revenir au menue principale !");
            Console.ReadLine();
            
        }

        // utilisation de la m"htode Add de l'objet LIST
        public void ajouter_taches(int ident,string nom, string descriptif, DateTime  deadline,string types)
        {
            
        Taches test = new Taches(ident, nom, descriptif, deadline, types);
        this.list_task.Add(test);

        }

   
        // methode permetant de suppriemer une tache 
        public string supression(int identifiant)
        {
            
            foreach (Taches tasks in this.list_task)
            {
                if (identifiant==tasks.GetIdentifiant()){
                    this.list_task.Remove(tasks);  
                    return (String.Format("élément supprimer"));
                }
            }

            return (String.Format("élément inexistant"));
        
            
        }



        // pour les modification pour chaque types on parcour notre liste pour trouver l'élément correspondant en utilisant sont ID
        // Si on le trouve alors on fais appel a nos setter de l'objet TASK.
        public string modification_nom(int identifiant,string nom)
        {
             foreach (Taches tasks in this.list_task)
            {
                if (identifiant==tasks.GetIdentifiant()){
                    tasks. SetNom(nom);
                    return (String.Format("élément modifier"));
                   
                }
            }
             return (String.Format("élément inexistant"));
     
        }

        public string modification_descriptif(int identifiant,string nom)
        {
             foreach (Taches tasks in this.list_task)
            {
                if (identifiant==tasks.GetIdentifiant()){
                    tasks. SetDescriptif(nom);
                    return (String.Format("élément modifier"));
                }
            }
            return (String.Format("élément inexistant"));
        }

        public string modification_types(int identifiant,string nom)
        {
             foreach (Taches tasks in this.list_task)
            {
                if (identifiant==tasks.GetIdentifiant()){
                    tasks.SetTypes(nom);
                    return (String.Format("élément modifier"));
                }
            }
            return (String.Format("élément inexistant"));
        }

        public string modification_deadline(int identifiant,ref DateTime date)
        {
            foreach (Taches tasks in this.list_task)
            {
                if (identifiant==tasks.GetIdentifiant()){
                    tasks.SetDeadline(date);
                    return (String.Format("élément modifier"));
                }
            }
            return (String.Format("élément inexistant"));
        }


        // lors de la fermeture de notre programme on viendrat enregistrer nos tache en mémoire dans notre fichier texte.
        public void enregistrer_taches(ref String path)
        { 
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (Taches tasks in list_task){
                    sw.WriteLine(tasks.ToString());
                }     
            }
        }

        // permet lors du démarage du programme de recharger les taches précédament rentrer en mémoire.
        public void lecture_taches(ref String path)
        {
             using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] words = s.Split(',');
   
                    int ident =int.Parse(words[0]);
                    DateTime date1 = DateTime.Parse(words[3]);

                    Taches test = new Taches(ident, words[1], words[2], date1, words[4]);
                    this.list_task.Add(test);
                }
            }
        }

        // méthode permetant d'analyser quelle chaine de tache es terminer.
        public string date_limite()
        {
            DateTime jj= DateTime.Today;
            foreach (Taches tasks in this.list_task)
            {
                if (jj>tasks.GetDeadline()){
                    return (String.Format("Vous avez une taches ou la date es finie !! penser à la supprimer"));
                }

            }
             return (String.Format("Aucun tache n'as de date finie"));
        }
    }
}
