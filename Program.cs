// See https://aka.ms/new-console-template for more information
using System;

namespace Jeux_devinette
    // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
           bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Bienvenue dans le jeu Moins ou Plus");
                Console.WriteLine("Veuillez entrer un nombre entre 1 et 100");

                // Lance le jeu
                Random rnd = new Random();
                int secretNumber = rnd.Next(1, 101); // Génère un nombre entre 1 et 100
                int numberLif = 8;
                bool win = false;

                // Tant que le jeu n'est pas terminé
                while (numberLif > 0 && !win)
                {
                    Console.Write("Entrez un nombre : ");
                    string inputString = Console.ReadLine();
                    int inputNumber;

                    if (int.TryParse(inputString, out inputNumber))
                    {
                        if (inputNumber < 1 || inputNumber > 100)
                        {
                            Console.WriteLine("Veuillez entrer un nombre compris entre 1 et 100 (inclus).");
                        }
                        else if (inputNumber == secretNumber)
                        {
                            Console.WriteLine($"Bravo ! Vous avez gagné ! Le nombre secret était {secretNumber}.");
                            win = true;
                        }
                        else if (inputNumber < secretNumber)
                        {
                            Console.WriteLine("C'est plus.");
                            numberLif--;
                        }
                        else // inputNumber > secretNumber
                        {
                            Console.WriteLine("C'est moins.");
                            numberLif--;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrée invalide. Veuillez entrer un nombre compris entre 1 et 100.");
                    }

                    // Afficher les vies restantes si le joueur n'a pas gagné
                    if (!win && numberLif > 0)
                    {
                        Console.WriteLine($"Il vous reste {numberLif} essais.");
                    }
                }

                if (!win)
                {
                    Console.WriteLine($"Dommage, vous avez perdu ! Le nombre secret était {secretNumber}.");
                }

                // Rejouer ou quitter
                bool ok = false;
                while (!ok)
                {
                    Console.Write("Recommencer ? (1: Oui, 0: Non) : ");
                    string inputString2 = Console.ReadLine();
                    int inputNumber2;

                    if (int.TryParse(inputString2, out inputNumber2))
                    {
                        ok = true;
                        exit = inputNumber2 == 0; // Si 0, quitter
                    }
                    else
                    {
                        Console.WriteLine("Commande inconnue. Veuillez entrer 1 pour Oui ou 0 pour Non.");
                    }
                }
            }
        }
    }
}

