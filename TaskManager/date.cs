using System;


namespace taskmanager
{
    public class VerificationSaisie
    {

        private DateTime deadline;

        public DateTime Date_limite(int anne, int moi, int jour)
        {
            this.deadline = new DateTime(anne, moi, jour);
            return this.deadline;
        }

        // Cette objet sert uniquement a vérifier les saisi utilisateur concernant la date
        // On aura 3 saisi a vérifier (année,moinjour)
        public static int verife_annee()
        {
            int annee = 0;
            do
            {
                Console.WriteLine("donner une année ! ");
                annee = int.Parse(Console.ReadLine());
            } while (annee <= 2018);
            return annee;
        }


        public static int verife_moi()
        {
            int moi = 0;
            do
            {
                Console.WriteLine("donner un mois ! ");
                moi = int.Parse(Console.ReadLine());
            } while (moi >12);
            return moi;
        }

        public static int nombre_jour_max(int moi)
        {   int nb_jour_max=0;
            switch (moi)
                {
                    case 1:  nb_jour_max=31; break;
                    case 2:  nb_jour_max=28; break;
                    case 3:  nb_jour_max=31; break;
                    case 4:  nb_jour_max=30; break;
                    case 5:  nb_jour_max=31; break;
                    case 6:  nb_jour_max=30; break;
                    case 7:  nb_jour_max=31; break;
                    case 8:  nb_jour_max=31; break;
                    case 9:  nb_jour_max=30; break;
                    case 10: nb_jour_max=31; break;
                    case 11: nb_jour_max=30; break;
                    case 12: nb_jour_max=31; break;
                }
                return nb_jour_max;
        }


        public static int verife_jour(int moi)
        {
            int nb_jour_max=nombre_jour_max(moi);
            int jour=0;
            do
            {
                Console.WriteLine("donner un jour! ");
                 jour = int.Parse(Console.ReadLine());
            } while (jour > nb_jour_max);
            return jour;
        }



    }
}
