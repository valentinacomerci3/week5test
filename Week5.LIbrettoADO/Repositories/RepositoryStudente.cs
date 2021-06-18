using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.LibrettoADO.Entities;

namespace Week5.LibrettoADO.Repositories
{
    public class RepositoryStudente : IRepositoryStudente
    {
        const string connectionString = @"Server = .\SQLEXPRESS; Persist Security Info = False; 
                Integrated Security = true; Initial Catalog = Libretto;";

        public bool Add(Studente item)
        {
            bool esito = true;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                //creo adapter
                SqlDataAdapter adapter = new SqlDataAdapter();
                //creo comandi: selezione e aggiunta
                SqlCommand selectCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "SELECT * FROM Studente"
                };
                SqlCommand insertCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "INSERT INTO Studente VALUES (@ID, @Nome, @Cognome, @AnnoNascita)"
                };
                insertCommand.Parameters.Add("@ID", SqlDbType.VarChar, 20, "ID");
                insertCommand.Parameters.Add("@Nome", SqlDbType.VarChar, 50, "Nome");
                insertCommand.Parameters.Add("@Cognome", SqlDbType.VarChar, 50, "Cognome");
                insertCommand.Parameters.Add("@AnnoNascita", SqlDbType.Int, 999, "AnnoNascita");

                //associo i comandi che ho creato all'adapter
                adapter.SelectCommand = selectCommand;
                adapter.InsertCommand = insertCommand;

                //creo il dataset
                DataSet dataset = new DataSet();
                try
                {
                    //apro connessione
                    connection.Open();
                    adapter.Fill(dataset, "Studente");

                    //creo e poi aggiungo la riga al dataset
                    DataRow studente = dataset.Tables["AudioLibro"].NewRow();
                    studente["ID"] = item.ID;
                    studente["Nome"] = item.Nome;
                    studente["Cognome"] = item.Cognome;
                    studente["AnnoNascita"] = item.AnnoNascita;

                    dataset.Tables["Studente"].Rows.Add(studente);
                    adapter.Update(dataset, "Studente");

                }catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return esito = false;
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return esito = false;
                }

            }

            return true;
        }


        public IList<Studente> GetAll()
        {
            IList<Studente> studenti = new List<Studente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    //apertura connessione
                    connection.Open();

                    //creare il comando
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = System.Data.CommandType.Text,
                        CommandText = "SELECT * FROM Studente"
                    };
                    //esecuzione comando
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Studente studenteDaAggiungere = new Studente()
                        {
                            ID = Int32.Parse(reader["CFU"].ToString()),
                            Nome = reader["Nome"].ToString(),
                            Cognome = reader["Nome"].ToString(),
                            AnnoNascita = Int32.Parse(reader["Voto"].ToString()),
                           
                        };
                        studenti.Add(studenteDaAggiungere);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


                return studenti;
        }

    
    }
}
