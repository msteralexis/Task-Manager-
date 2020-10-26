using System;
using System.Collections.Generic;
using taskmanager;
using ListeTask;
using System.IO;
using System.Linq;

namespace tp_console
{


    class Program
    {

        // Fonction permetant de faire une pause au moment de l'affichage
        public static void systheme_pause (){
            Console.WriteLine("taper sur une touche pour revenir au menue principale !");
            Console.ReadLine();
        }

        // nous stockons dans un tableau la saisi de la date (3 case corresponddant au année,moi,jour)
        // on viens vérifier la saisi de l'utilisateur avec l'objet VerificationSaisie.
        public static void date(ref int[] tab)
        {
            tab[0] = VerificationSaisie.verife_annee();
            tab[1] = VerificationSaisie.verife_moi();
            tab[2] = VerificationSaisie.verife_jour(tab[1]);
        }
//------------------------------------------------------------------------------------------------------------------------------
//      BLOQUE CORRESPONDANT 0 LA SAISI D UNE TACHE
//------------------------------------------------------------------------------------------------------------------------------
        // fonction servant à la saisi des chaines de caractères nécésaire à la construction de l'objet tache.
        public static void saisi_creation(ref string[] tab)
        {
            Console.WriteLine("rentrer un nom");
            tab[0] = Console.ReadLine();

            Console.WriteLine("rentrer un descriptif");                
            tab[1] = Console.ReadLine();
            Console.WriteLine("rentrer un types");
            tab[2] = Console.ReadLine();
        }

        //on viens créer notre tache en appelant les fonctions nécésaires
        // on insère ensuite cette éléments dans notre liste.
        public static void creation(ref Liste task)
        {
            int ident = task.identifiantzzz();
            string[] tab =new string[3];
            saisi_creation(ref tab);


            int[] tab_ident = new int[3];
            date(ref tab_ident);
            DateTime gg = new DateTime(tab_ident[0], tab_ident[1], tab_ident[2]);

         
            task.ajouter_taches(ident, tab[0], tab[1], gg, tab[2]);
        }

//------------------------------------------------------------------------------------------------------------------------------
//                  PRESENTATION DETAILLER D UN ELEMENT DU TABLEAU
//------------------------------------------------------------------------------------------------------------------------------
        public static void present_detailler(Liste liste)
        {
            if (liste.nb_element_liste() == 0)
            {
                Console.WriteLine("vous n'avez pas d'élément dans votre liste ");
            }
            else
            {
                Console.WriteLine("rentrer l' identifiant de l'élement a détailler");
                int identifiant = int.Parse(Console.ReadLine());
                liste.presentation_detailler(identifiant);
            }
        }

//------------------------------------------------------------------------------------------------------------------------------
//                  PERMETANT LA SPRESSION D UN ELEMENT DU TABLEAU
//------------------------------------------------------------------------------------------------------------------------------
        public static void list_supression(ref Liste liste)
        {
            if (liste.nb_element_liste() == 0){
                Console.WriteLine("vous n'avez pas d'élément à suprimer");
            }
            else{
                Console.WriteLine("rentrer l' identifiant de l'élement a suprimer");
                int identifiant = int.Parse(Console.ReadLine());
                string format=liste.supression(identifiant);
                Console.WriteLine(format);
                systheme_pause ();
            }
        }


//------------------------------------------------------------------------------------------------------------------------------
//              ENSEMBLE DE FONCTION PERMETANT DE CHANER UN ATRIBUT D UNE TACHES
//------------------------------------------------------------------------------------------------------------------------------
        // On demande à l'utilisateur ce qu'il veut changer comme atribut de la tache. on renvoi un entier pour indiquer ce qu'il veut.
        public static int types_modification()
        {
            int types;
            do{
                Console.WriteLine("Taper 1 pour modifier le nom, 2 le descriptif, 3 le types,4 changement date limite");
                types = int.Parse(Console.ReadLine());
            } while (types > 5);
            return types;

        }

        // Concernant les chaine de caractère on aura une saisi spécifique. On viens donc en fonction de l'element changer, faire appel à la bonne fonction de modification et 
        // informaer lutilisateur si la modification c'est bien passer ou non.
        public static void affichage_modification(ref Liste liste, int identifiant,string nom_modif,int types){

            string chainenom,chainedescriptif,chainetypes;
                if (types == 1){
                    chainenom= liste.modification_nom(identifiant, nom_modif);
                    Console.WriteLine(chainenom);
                    systheme_pause ();
                }
                if (types == 2){
                    chainedescriptif = liste.modification_descriptif(identifiant, nom_modif);
                    Console.WriteLine(chainedescriptif);
                    systheme_pause ();
                } 
                if (types == 3){
                    chainetypes = liste.modification_types(identifiant, nom_modif);
                    Console.WriteLine(chainetypes);
                    systheme_pause ();
                }  

        }
        // pour le changement de la date fais saisi une date à l'utilisateur en verifiant sa sais grace a la fonction date.
        // on fais ensuite appel a la fonction de modification correspondante. On signal à l'utilisateur si la modification c'est bien passer ou non.
        public static void changement_date(ref Liste liste,int identifiant)
        {
            int[] tab=new int[3];
            date(ref tab);
            DateTime gg = new DateTime(tab[0], tab[1], tab[2]);
            liste.modification_deadline(identifiant,ref gg);
        }

        // fonction regroupant tous les elements de modifications.
        public static void modification_liste(ref Liste liste)
        {
            if (liste.nb_element_liste() == 0){
                Console.WriteLine("Aucun élément a modifier dans votre base");
            }
            else{
                int types = types_modification();
                Console.WriteLine("rentrer l' identifiant de l'élement a modifier");
                int identifiant = int.Parse(Console.ReadLine());
                if (types==4)
                {
                   changement_date(ref liste,identifiant);
                    
                }else{
                 
                    Console.WriteLine("rentrer la modification à effectuer");
                    string nom_modif = Console.ReadLine();
                    affichage_modification(ref liste,  identifiant,nom_modif,types);
                }
               
              
            }
        }

//------------------------------------------------------------------------------------------------------------------------------
//                          MAIN
//------------------------------------------------------------------------------------------------------------------------------


        static void Main(string[] args)
        {
            
            
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Liste liste = new Liste();
            Console.SetCursorPosition(25, 1);
            Console.WriteLine("Bienvenue dans votre gestionaire de Taches !!");
            int verif = 1;

            // ouverture du fichier ou sont stocker les taches !!
            // on viens lire ce fichier pour ensuite ajouter nos taches à la liste
            String path = @"fichier.txt"; 
            liste.lecture_taches(ref path);

            // on viens vérifier si des taches on dépaser leur date limite !!
            // si 'est le cas on previens l'utilisateur 
            string tache_finie=liste.date_limite();
            Console.WriteLine(tache_finie);
            
            // menu d'éxécutions de notre programme
            do
            {
                Console.SetCursorPosition(25, 3);

                Console.WriteLine("Votres liste constient {0} Taches ", liste.nb_element_liste());
                Console.WriteLine("taper 0 pour sortir de l'aplication");
                Console.WriteLine("taper 1 pour voir toutes les taches");
                Console.WriteLine("taper 2 pour ajouter une taches");
                Console.WriteLine("taper 3 pour supprimer une taches");
                Console.WriteLine("taper 4 pour détailler une tache");
                Console.WriteLine("taper 5 pour modifier une tache");
                verif = int.Parse(Console.ReadLine());

                switch (verif)
                {
                    case 1: Console.Clear(); liste.presentation_tache(); Console.Clear(); break;
                    case 2: Console.Clear(); creation(ref liste); Console.Clear(); break;
                    case 3: Console.Clear(); list_supression(ref liste); Console.Clear(); break;
                    case 4: Console.Clear(); present_detailler(liste); Console.Clear(); break;
                    case 5: Console.Clear(); modification_liste(ref liste); Console.Clear(); break;
                }

            } while (verif != 0);

            // une fois notre prgramme terminer on enregistre toutes nos tache dans un fichier texte
            liste.enregistrer_taches(ref path);
            

       

        }
    }
}
