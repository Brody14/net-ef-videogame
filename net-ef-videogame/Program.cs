using net_ef_videogame.Database;
using net_ef_videogame.Models;
using System.Linq;
using System;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Creiamo quindi una console app che all'avvio mostra un menu con la 
             * possibilità di :
                1 inserire un nuovo videogioco
                2 ricercare un videogioco per id
                3 ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input
                4 cancellare un videogioco
                5 chiudere il programma*/

            Console.WriteLine("Benvenuto nel nostro gestionale di videogame! Ecco cosa puoi fare:");


            while (true)
            {
                Console.WriteLine(@"
            - 1: Inserisci un nuovo videogame
            - 2: Ricerca un videogame per id
            - 3: Ricerca tutti i videogiochi che contengono nel nome un tuo input
            - 4: Cancella un videogioco
            - 5: Aggiungi una software house
            - 6: Chiudi il programma 
            ");

                Console.Write("Seleziona l'opzione --> ");
 

                int selectedOption = int.Parse(Console.ReadLine());

                switch (selectedOption)
                {
                    case 1:
                        {

                            Console.WriteLine("Inserisci i dati del videogame!");
                            Console.Write("Inserisci il nome: ");
                            string name = Console.ReadLine();

                            Console.Write("Inserisci la trama: ");
                            string overview = Console.ReadLine();

                            Console.Write("Inserisci la data di rilascio (gg/mm/aaaa): ");
                            DateTime releaseDate = DateTime.Parse(Console.ReadLine());


                            using (VideogameContext db = new VideogameContext())
                            {
                                List<SoftwareHouse> softwareHouses = db.SoftwareHouses.ToList();

                                Console.WriteLine("Ecco le software house presenti:");
                                foreach(SoftwareHouse s in softwareHouses)
                                {
                                    Console.WriteLine(s);

                                }
                            }

                            Console.WriteLine();
                            Console.Write("Inserisci l'id della Software House: ");
                            int softwareHouse = int.Parse(Console.ReadLine());

                            Videogame newVideogame = new Videogame()
                            {
                                Name = name,
                                Overview = overview,
                                Release_date = releaseDate,
                                SoftwareHouseId = softwareHouse
                            };


                            using (VideogameContext db = new VideogameContext())
                            {
                                try
                                {
                                    db.Add(newVideogame);
                                    db.SaveChanges();

                                    Console.WriteLine("Il tuo videogioco è stato aggiunto!");
                                }catch(Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                        }

                        break;

                    case 2:
                        {
                            
                            Console.Write("Inserisci l'ID del videogioco che vuoi cercare: ");
                            int idSearched = int.Parse(Console.ReadLine());

                            using (VideogameContext db = new VideogameContext())
                            {
                                try
                                {
                                    Videogame videogame = db.Videogames.Where(videogame => videogame.VideogameId == idSearched).First();

                                    Console.WriteLine(videogame);
                                }catch(Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }  
                            }
                        }

                        break;

                    case 3:
                        {

                            Console.Write("Inserisci la parola che vuoi cercare all'interno del nome del videogioco: ");
                            string input = Console.ReadLine();

                            using (VideogameContext db = new VideogameContext())
                            {
                                try
                                {
                                    List<Videogame> videogames = db.Videogames.Where(videogame => videogame.Name.Contains(input)).ToList<Videogame>();

                                    if (videogames.Count > 0)
                                    {
                                        foreach (Videogame vid in videogames)
                                        {
                                            Console.WriteLine(vid);
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                        }
                        break;

                    case 4:
                        {
                            Console.Write("Inserisci l'ID del videogioco che vuoi cancellare: ");
                            int idToDelete = int.Parse(Console.ReadLine());

                            using (VideogameContext db = new VideogameContext())
                            {
                                try
                                {
                                    Videogame videogame = db.Videogames.Where(videogame => videogame.VideogameId == idToDelete).First();

                                    db.Remove(videogame);
                                    db.SaveChanges();

                                    Console.WriteLine($"Il videogioco con ID {idToDelete} è stato cancellato");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }

                        break;

                    case 5:
                        {
                            Console.WriteLine("Inserisci i dati della software house!");
                            Console.Write("Inserisci il nome: ");
                            string name = Console.ReadLine();

                            Console.Write("Inserisci la partita iva: ");
                            string vatNumber = Console.ReadLine();

                            Console.Write("Inserisci la città: ");
                            string city = Console.ReadLine();

                            Console.Write("Inserisci la nazione: ");
                            string country = Console.ReadLine();

                            SoftwareHouse newSoftwareHouse = new SoftwareHouse()
                            {
                                Name = name,
                                VatNumber = vatNumber,
                                City = city,
                                Country = country
                            };


                            using (VideogameContext db = new VideogameContext())
                            {
                                try
                                {
                                    db.Add(newSoftwareHouse);
                                    db.SaveChanges();

                                    Console.WriteLine("La Software House è stata aggiunta!");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                        break;

                    case 6:
                        {
                            Environment.Exit(0);
                        }
                        break;
                           
                    default:
                        {
                            Console.WriteLine("Non hai selezionato un opzione valida!");
                        }

                        break;
                }
            }
        }
    }
}