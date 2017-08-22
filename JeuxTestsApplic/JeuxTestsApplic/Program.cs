///////////////////////////////////////////////
// UN SEUL DEFINE NON COMMENTE A LA FOIS !!! //
///////////////////////////////////////////////

//#define TEST1
//#define TEST2
//#define TEST3
//#define TEST4
//#define TEST5
//#define TEST6
#define TEST7


using System;
using System.Collections.Generic;
using System.Text;

namespace JeuxTestsApplic
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TEST1 : Test des constructeurs et propriétés
#if TEST1
            Appareil app1 = new Appareil();
            Appareil app2 = new Appareil("KNooo","K999");
            Appareil app3 = new Appareil("AiKlère", "Loupiote de luxe", "L0001", 2.5,TypeAppareil.Eclairage);


            app1.Marque = "SenSong";
            app1.Modele = "S57";
            app1.NumeroSerie = "GSM0001";
            app1.Type = TypeAppareil.Media;


            Console.WriteLine("app1:" + app1);
            Console.WriteLine("\napp2:" + app2);
            Console.WriteLine("\napp3:" + app3);

            Console.WriteLine("Appuyez sur une touche pour afficher le resumé des appareils");
            Console.ReadKey();

            Console.WriteLine("app1:" + app1.ToString("Resume",null));
            Console.WriteLine("\napp2:" + app2.ToString("Resume", null));
            Console.WriteLine("\napp3:" + app3.ToString("Resume", null));

            Console.WriteLine("Appuyez sur une touche pour afficher le detail des appareils");
            Console.ReadKey();

            Console.WriteLine("app1:" + app1.ToString("Detail", null));
            Console.WriteLine("app2:" + app2.ToString("Detail", null));
            Console.WriteLine("app3:" + app3.ToString("Detail", null));
            

            Console.WriteLine("Appuyez sur une touche pour terminer");
            Console.ReadKey();
#endif
            #endregion

            #region TEST2 : Test de l'égalité d'appareils à l'aide de la méthode "Equals"
#if TEST2
            Appareil app1 = new Appareil();
            Appareil app2 = new Appareil("KNooo", "K999");
            Appareil app3 = new Appareil("AiKlère", "Loupiote de luxe", "L0001", 2.5, TypeAppareil.Eclairage);

            app1.Marque = "SenSong";
            app1.Modele = "S57";
            app1.NumeroSerie = "GSM0001";
            app1.Type = TypeAppareil.Media;


            Console.WriteLine("Test de l'égalité entre : ");
            Console.WriteLine("APPP1 : " + app1);
            Console.WriteLine("et");
            Console.WriteLine("APPP2 : " + app2);

            if (app1.Equals(app2))
            {
                Console.WriteLine("Oooops ! Something is wrong :( ... Try again !!!");            
            }
            else
            {
                Console.WriteLine("OK : " + app1.NumeroSerie + " est différent de " + app2.NumeroSerie);
            }

            Console.WriteLine();

            Console.WriteLine("Test de l'égalité entre : ");
            Console.WriteLine("APP1 : " + app1);
            Console.WriteLine("et");
            Console.WriteLine("APP3 : " + app3);

            if (app1.Equals(app3))
            {
                Console.WriteLine("Oooops ! Something is wrong :( ... Try again !!!");
            }
            else
            {
                Console.WriteLine("OK : " + app1.NumeroSerie + " est différent de " + app3.NumeroSerie);
            }

            Console.WriteLine();

            Console.WriteLine("On modifie P1 : ");
            
            app1.NumeroSerie = app3.NumeroSerie;

            Console.WriteLine("Test de l'égalité entre : ");
            Console.WriteLine("APP1 : " + app1);
            Console.WriteLine("et");
            Console.WriteLine("APP3 : " + app3);

            if (app1.Equals(app3))
            {
                Console.WriteLine("Parfait : " + app1.NumeroSerie + " == " + app3.NumeroSerie);
            }
            else
            {
                Console.WriteLine("Oooops ! Something is wrong :( ... Try again !!!");
            }

            Console.ReadKey();
#endif
            #endregion

            #region TEST3 : Test de l'égalité d'appareils à l'aide de l'opérateur ==
#if TEST3
            Appareil app1 = new Appareil();
            Appareil app2 = new Appareil("KNooo", "K999");
            Appareil app3 = new Appareil("AiKlère", "Loupiote de luxe", "L0001", 2.5, TypeAppareil.Eclairage);

            app1.Marque = "SenSong";
            app1.Modele = "S57";
            app1.NumeroSerie = "GSM0001";
            app1.Type = TypeAppareil.Media;


            Console.WriteLine("Test de l'égalité entre : ");
            Console.WriteLine("P1 : " + app1);
            Console.WriteLine("et");
            Console.WriteLine("P2 : " + app2);

            if (app1 == app2)
            {
                Console.WriteLine("Oooops ! Something is wrong :( ... Try again !!!");
            }
            else
            {
                Console.WriteLine("OK : " + app1.NumeroSerie + " est différent de " + app2.NumeroSerie);
            }

            Console.WriteLine();

            Console.WriteLine("Test de l'égalité entre : ");
            Console.WriteLine("APP1 : " + app1);
            Console.WriteLine("et");
            Console.WriteLine("APP3 : " + app3);

            if (app1 == app3)
            {
                Console.WriteLine("Oooops ! Something is wrong :( ... Try again !!!");
            }
            else
            {
                Console.WriteLine("OK : " + app1.NumeroSerie + " est différent de " + app3.NumeroSerie);
            }

            Console.WriteLine();

            Console.WriteLine("On modifie APP1 : ");

            app1.NumeroSerie = app3.NumeroSerie;

            Console.WriteLine("Test de l'égalité entre : ");
            Console.WriteLine("P1 : " + app1);
            Console.WriteLine("et");
            Console.WriteLine("P3 : " + app3);

            if (app1 == app3)
            {
                Console.WriteLine("Parfait : " + app1.NumeroSerie + " == " + app3.NumeroSerie);
            }
            else
            {
                Console.WriteLine("Oooops ! Something is wrong :( ... Try again !!!");
            }

            Console.ReadKey();
#endif
            #endregion

            #region TEST4 : Test présence d'un objet dans une liste
#if TEST4
            List<Appareil> ListeAppareils = new List<Appareil>();

            Appareil app1 = new Appareil();
            Appareil app2 = new Appareil("KNooo", "K999");
            Appareil app3 = new Appareil("AiKlère", "Loupiote de luxe", "L0001", 2.5, TypeAppareil.Eclairage);
            Appareil app4 = new Appareil("AiKlère", "Loupiote de luxe", "L0001", 2.5, TypeAppareil.Eclairage);

            app1.Marque = "SenSong";
            app1.Modele = "S57";
            app1.NumeroSerie = "GSM0001";
            app1.Type = TypeAppareil.Media;


            ListeAppareils.Add(app1);

            if (!ListeAppareils.Contains(app2))
            {
                ListeAppareils.Add(app2);
            }

            if (!ListeAppareils.Contains(app3))
            {
                ListeAppareils.Add(app3);
            }

            if (!ListeAppareils.Contains(app4))
            {
                ListeAppareils.Add(app4);
                Console.WriteLine("Ooops ! On ne devrait pas pouvoir ajouter un appareil ayant le même numéro de série qu'un autre appareil dejà présent dans la liste");
            }

            foreach (Appareil p in ListeAppareils)
            {
                Console.WriteLine(p.ToString("Resume",null));
            }

            if (ListeAppareils.Count == 3)
            {
                Console.WriteLine("Ok la liste contient bien 3 appareils");
            }
            else
            {
                Console.WriteLine("Ooops !!! La liste devrait contenir 3 appareils");
            }
            
      
            Console.ReadKey();
#endif
            #endregion

            #region TEST5: Comparaison d'activités via le tri dans une liste
#if TEST5

            List<Appareil> ListeAppareils = new List<Appareil>();

            Appareil app1 = new Appareil();
            Appareil app2 = new Appareil("KNooo", "K999");
            Appareil app3 = new Appareil("AiKlère", "Loupiote de luxe", "L0001", 2.5, TypeAppareil.Eclairage);

            app1.Marque = "SenSong";
            app1.Modele = "S57";
            app1.NumeroSerie = "GSM0001";
            app1.Type = TypeAppareil.Media;

            ListeAppareils.Add(app1);
            ListeAppareils.Add(app2);
            ListeAppareils.Add(app3);

            app2.NumeroSerie = "KN00999";


            Console.WriteLine("Affichage de la liste non triée");

            foreach (Appareil p in ListeAppareils)
            {
                Console.WriteLine(p.ToString("Detail", null));
            }


            try
            {
                Console.WriteLine("Tentative de tri");
                ListeAppareils.Sort();

                Console.WriteLine("Affichage de la liste triée");

                foreach (Appareil p in ListeAppareils)
                {
                    Console.WriteLine(p.ToString("Detail", null));
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Ooops ! Le tri n'a pu s'effectuer !!!");
                
            }

            app1.DateMiseEnService = DateTime.Today.AddDays(-2.0);
            app2.DateMiseEnService = DateTime.Today.AddYears(-1);
            app3.DateMiseEnService = DateTime.Now;

            try
            {
                Console.WriteLine("Tentative de tri sur la date de mise en service via un délégué");
                Comparison<Appareil> compAppareils = new Comparison<Appareil>(Appareil.ComparisonMiseEnService);
                ListeAppareils.Sort(compAppareils);

                Console.WriteLine("Affichage de la liste triée sur la date de mise en service ");

                foreach (Appareil p in ListeAppareils)
                {
                    Console.WriteLine(p.ToString("Detail", null));
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Ooops ! Le tri n'a pu s'effectuer !!!");
            }

            // Ajouter la fonctionnalité de tri de joueurs par date de naissance décroissante
      
            Console.ReadKey();
#endif
            #endregion

            #region TEST6 : Une classe dédicacée à la comparaison
#if TEST6
            List<Appareil> ListeAppareils = new List<Appareil>();

            Appareil app1 = new Appareil();
            Appareil app2 = new Appareil("KNooo", "K999");
            Appareil app3 = new Appareil("AiKlère", "Loupiote de luxe", "L0001", 2.5, TypeAppareil.Eclairage);

            app1.Marque = "SenSong";
            app1.Modele = "S57";
            app1.NumeroSerie = "GSM0001";
            app1.Type = TypeAppareil.Media;

            ListeAppareils.Add(app1);
            ListeAppareils.Add(app2);
            ListeAppareils.Add(app3);

            app1.Consommation = 3.0;
            app2.Consommation = 1.0;


            Console.WriteLine("Affichage de la liste non triée");

            foreach (Appareil p in ListeAppareils)
            {
                Console.WriteLine(p.ToString("Detail", null));
            }


            try
            {
                Console.WriteLine("Tentative de tri");
                ListeAppareils.Sort();

                Console.WriteLine("Affichage de la liste triée");

                foreach (Appareil p in ListeAppareils)
                {
                    Console.WriteLine(p.ToString("Detail", null));
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Ooops ! Le tri n'a pu s'effectuer !!!");
            }

            try
            {
                Console.WriteLine("Tentative de tri sur le lieu via un objet 'comparer'");
                MyAppareilComparer myComparer = new MyAppareilComparer();
                ListeAppareils.Sort(myComparer);

                Console.WriteLine("Affichage de la liste triée sur le pseudo");

                foreach (Appareil p in ListeAppareils)
                {
                    Console.WriteLine(p.ToString("Detail", null));
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Ooops ! Le tri n'a pu s'effectuer !!!");
            }

        
            Console.ReadKey();

#endif
            #endregion

            #region TEST7 : Test des indexeurs
#if TEST7
            Appareil app1 = new Appareil("AiKlère", "Loupiote de luxe", "L0001", 2.5, TypeAppareil.Eclairage);

            app1.Autorisation["9h-11h"] = true;

            app1.Autorisation["13h-17h"] = true;

            app1.Autorisation["19h30"] = true;

            if (app1.Autorisation["14h-16h"] == true)
            {
                Console.WriteLine(app1.Key + " peut jouer de 14h-16h");
            }
            else
            {
                Console.WriteLine(app1.Key + " ne peut pas jouer de 14h-16h");
            }

            Console.WriteLine("Pressez une touche pour changer l'autorisation entre 14h et 15h");
            Console.ReadKey();
            app1.Autorisation["14h-15h"] = false;

            if (app1.Autorisation["14h-16h"] == true)
            {
                Console.WriteLine(app1.Key + " peut jouer de 14h-16h");
            }
            else
            {
                Console.WriteLine(app1.Key + " ne peut pas jouer de 14h-16h");
            }
#endif
            #endregion
        }
    }
}

