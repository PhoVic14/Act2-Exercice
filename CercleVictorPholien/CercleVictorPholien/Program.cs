using CercleVictorPholien;
using System;

namespace CercleVictorPholien
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quel programme voulez-vous utiliser ? (Cercle, Complexe, Personne, Sandwich)");

            string choixUtilisateur = Console.ReadLine().ToLower();

            if (choixUtilisateur == "cercle")
            {
                Cercle cercle = new Cercle();

                Console.WriteLine("Bienvenue dans ce programme sur le cercle");
                do
                {
                    Console.WriteLine("Tapez un rayon pour votre cercle");
                    cercle.Rayon = double.Parse(Console.ReadLine());
                    cercle.Caracteristique();
                    Console.WriteLine("Avec un rayon diminué de moitier");
                    cercle.Rayon /= 2;
                    cercle.Caracteristique();
                    Console.WriteLine("Un autre cercle ? (Tapez sur enter)");
                    Console.ReadLine();
                } while (0 == 0);

            }
            else if (choixUtilisateur == "complexe")
            {
                Complexe nbrComplexe = new Complexe();
                Complexe newNbrComplexe = new Complexe();

                Console.WriteLine("Bienvenue dans ce programme sur les complexes !");

                do
                {
                    Console.WriteLine("Que vaut la partie réelle du complexe de départ ?");
                    nbrComplexe.Reelle = int.Parse(Console.ReadLine());

                    Console.WriteLine("Que vaut la partie imaginaire du complexe de départ ?");
                    nbrComplexe.Imaginaire = int.Parse(Console.ReadLine());

                    Console.WriteLine("Le premier complexe : ");
                    nbrComplexe.AfficheComplexe();

                    Console.WriteLine(" et a pour module : " + nbrComplexe.CalculeModule());



                    Console.WriteLine("Encodez un second nombre imaginaire : ");

                    Console.WriteLine("Que vaut la partie réelle du second complexe ?");
                    newNbrComplexe.Reelle = int.Parse(Console.ReadLine());

                    Console.WriteLine("Que vaut la partie imaginaire du second complexe ?");
                    newNbrComplexe.Imaginaire = int.Parse(Console.ReadLine());


                    Console.WriteLine("Le second module est :");
                    newNbrComplexe.AfficheComplexe();


                    nbrComplexe.Ajoute(newNbrComplexe.Reelle, newNbrComplexe.Imaginaire);
                    Console.WriteLine("Le premier complexe devient :");
                    nbrComplexe.AfficheComplexe();

                    Console.WriteLine("Un autr test ? (Tapez sur espace)");


                } while (0 == 0);
            }

            else if (choixUtilisateur == "sandwich")
            {
                Console.WriteLine("Bienvenue dans notre concepteur de sandiwch ! ");
                string value = "";
                do
                {
                    Sandwich sandwich = new Sandwich();
                    sandwich.composeSandwich();
                    Console.WriteLine("Tapez sur espace pour générer un sandwich, n'importe quelle touhce pour quitter ! :::");
                    value = Console.ReadLine();
                } while (value == " ");
            }

            else if (choixUtilisateur == "personne")
            {
                Personne Personne1;
                Personne Personne2;

                Console.WriteLine("Bienvenue dans notre gestionnaire de porte monnaie !");

                do
                {
                    string nom = null;
                    int cash = 0;

                    GeneratedPersonne(out cash, out nom);
                    Personne1 = new Personne(nom, cash);

                    GeneratedPersonne(out cash, out nom);
                    Personne2 = new Personne(nom, cash);

                    DonnerArgent(Personne1, Personne2);
                    DonnerArgent(Personne2, Personne1);

                    Personne1.Cash += AjouterArgent(Personne1);
                    Personne1.Afficher();

                    Personne2.Cash += AjouterArgent(Personne2);
                    Personne2.Afficher();

                    Console.WriteLine("Tapez sur espace pour recommencer avec deux autres personnes");
                    Console.ReadLine();


                } while (0 == 0);
            }

            static int AjouterArgent(Personne personne)
            {
                Console.WriteLine("voulez vous ajouter de l'argent à " + personne.Nom + "Taper sur espace pour oui");
                string value = Console.ReadLine();

                if (value == " ")
                {
                    Console.WriteLine("combien voulez vous ajouter ?");
                    string Cash;
                    int CashValue;
                    do
                    {
                        Console.WriteLine("Tapez une somme d'argent en euros");
                        Cash = Console.ReadLine();
                    } while (!int.TryParse(Cash, out CashValue));

                    return CashValue;
                }

                return 0;
            }

            static void GeneratedPersonne(out int cash, out string nom)
            {
                Console.WriteLine("Premiere personne, quel est votre nom ?");
                nom = Console.ReadLine();


                cash = 0;
                string Cash;
                do
                {
                    Console.WriteLine("Tapez une somme d'argent en euros");
                    Cash = Console.ReadLine();
                } while (!int.TryParse(Cash, out cash));
            }

            static void DonnerArgent(Personne Personne1, Personne Personne2)
            {
                int euros;
                string value;

                Console.WriteLine(Personne2.Nom + " combien voulez vous donner à " + Personne1.Nom);
                do
                {
                    Console.WriteLine("Tapez une somme d'argent en euros");
                    value = Console.ReadLine();
                } while (!int.TryParse(value, out euros));

                if (Personne2.ALaThune(euros))
                {
                    Personne2.Cash -= euros;
                    Personne1.Cash += euros;
                    Console.WriteLine("Ajout effectué !");
                }
                else
                {
                    Console.WriteLine(Personne2.Nom + " vous n'avez pas asser d'argent pour cettre transaction !");
                }

                Personne1.Afficher();
                Personne2.Afficher();
            }
        }
    }
}