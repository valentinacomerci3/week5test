using System;
using System.Collections.Generic;
using Week5.LibrettoADO.Entities;
using Week5.LibrettoADO.Repositories;

namespace Week5.BibliotecaADO
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepositoryEsame repoEsami = new RepositoryEsame(); 
            foreach (var es in repoEsami.GetAll())
            {
                Console.WriteLine("ISBN: {0} Titolo: {1} Autore: {2} Numero Pagine: {3}" +
                    "Quantita' Magazzino: {4}",
                    es.Nome, es.CFU, es.Voto, es.DataEsame, es.Esito,es.Studente);
            }
            
            Esame esame = new Esame()
            {
                Nome = "Storia Generale",
                CFU = 9,
                DataEsame = new DateTime(12/12/12),
                Voto = 27,
                Esito = "positivo",
                Studente = 25,
            };

           
            //tasks
            
            

            Console.WriteLine("\nEsami ordinati secondo votazione e data");
            foreach (var es in repoEsami.EsamiOrdinatiPerVotoData())
            {
                Console.WriteLine("ID: {0} - Nome: {1} - CFU: {2} - Data: {3}- Voto: {4}- Esito: {5}",
                    es.ID, es.Nome, es.CFU, es.DataEsame, es.Voto, es.Esito);
            }


            IRepositoryStudente repoStudenti = new RepositoryStudente();
            foreach (var stud in repoStudenti.GetAll())
            {
                Console.WriteLine("ID: {0} - Nome: {1} - Cognome: {2} - AnnoNascita: {3}",
                    stud.ID, stud.Nome, stud.Cognome, stud.AnnoNascita);
            }


            Console.WriteLine("---inserimento studente modalità disconnessa---");
            Console.WriteLine("Inserisci ID");
            int ID = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci Nome");
            string Nome = Console.ReadLine();
            Console.WriteLine("Inserisci Cognome");
            string Cognome = Console.ReadLine();
            Console.WriteLine("Inserisci Anno di Nascita");
            int AnnoNascita = Int32.Parse(Console.ReadLine());
            Studente Studente = new Studente()
            {
                ID = ID,
                Nome = Nome,
                Cognome = Cognome,
                AnnoNascita = AnnoNascita
            };
            
            Console.ReadKey();

        }
    }
}
