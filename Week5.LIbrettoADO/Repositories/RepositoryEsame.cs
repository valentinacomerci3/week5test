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
    public class RepositoryEsame : IRepositoryEsame
    {
        const string connectionString = @"Server = .\SQLEXPRESS; Persist Security Info = False; 
                Integrated Security = true; Initial Catalog = Libretto;";

        public bool Add(Esame item)
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
                    CommandText = "SELECT * FROM Esame"
                };
                SqlCommand insertCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "INSERT INTO Esame VALUES (@ID, @Nome, @CFU, @DataEsame,@Voto,@Esito,@Studente)"
                };
                insertCommand.Parameters.Add("@ID", SqlDbType.Int, 999, "ID");
                insertCommand.Parameters.Add("@Nome", SqlDbType.VarChar, 50, "Nome");
                insertCommand.Parameters.Add("@CFU", SqlDbType.Int, 999, "CFU");
                insertCommand.Parameters.Add("@DataEsame", SqlDbType.Date, 20, "DataEsame");
                insertCommand.Parameters.Add("@Voto", SqlDbType.Int, 999, "Voto");
                insertCommand.Parameters.Add("@Esito", SqlDbType.VarChar, 999, "Esito");
                insertCommand.Parameters.Add("@Studente", SqlDbType.Int, 999, "Studente");

                //associo i comandi che ho creato all'adapter
                adapter.SelectCommand = selectCommand;
                adapter.InsertCommand = insertCommand;

                //creo il dataset
                DataSet dataset = new DataSet();
                try
                {
                    //apro connessione
                    connection.Open();
                    adapter.Fill(dataset, "Esame");

                    //creo e poi aggiungo la riga al dataset
                    DataRow esame = dataset.Tables["Esame"].NewRow();
                    esame["ID"] = item.ID;
                    esame["Nome"] = item.Nome;
                    esame["CFU"] = item.CFU;
                    esame["DataEsame"] = item.DataEsame;
                    esame["Voto"] = item.Voto;
                    esame["Esito"] = item.Esito;
                    esame["Studente"] = item.Studente;

                    dataset.Tables["Esame"].Rows.Add(esame);
                    adapter.Update(dataset, "Esame");
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


        public IList<Esame> GetAll()
        {
            IList<Esame> esami = new List<Esame>();

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
                        CommandText = "SELECT * FROM Esame"
                    };
                    //esecuzione comando
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Esame esameDaAggiungere = new Esame()
                        {
                            ID = Int32.Parse(reader["ID"].ToString()),
                            Nome = reader["Nome"].ToString(),
                            CFU = Int32.Parse(reader["CFU"].ToString()),
                            DataEsame = DateTime.Parse(reader["DataEsame"].ToString()),
                            Voto = Int32.Parse(reader["Voto"].ToString()),
                            Esito= reader["Esito"].ToString(),
                            Studente = Int32.Parse(reader["Studente"].ToString()),
                        };
                        esami.Add(esameDaAggiungere);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


                return esami;
        }

        public IList<Esame> EsamiOrdinatiPerVotoData()
        {
            IEnumerable<Esame> esamiPerVotoData = GetAll().OrderBy(esame => esame.Studente);
            return esamiPerVotoData.ToList();
        }

        

    }
}
