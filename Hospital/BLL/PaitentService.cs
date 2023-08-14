using BOL;
using MySql.Data.MySqlClient;

namespace BLL
{
    public class PaitentService
    {

        public static string s = @"server=localhost;port=3306;user=root;password=root123;database=akku";


        public static int insertp(Patient p)
        {
            MySqlConnection m=new MySqlConnection(s);
            try
            {
                m.Open();
                String s = "insert into patient( pname, disease, room, admitdate) value('" + p.pname + "','" + p.disease + "','" + p.room + "','" + p.admitdate.ToString("yyyy")+ "')";
                MySqlCommand cmd=new MySqlCommand(s, m);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally { m.Close(); }  
        }


        public static List<Patient> Getlist()
        {
            List<Patient> list = new List<Patient>();
            MySqlConnection m = new MySqlConnection(s);
            try
            {
                m.Open();
                String s = "SELECT * FROM PATIENT";
                MySqlCommand cmd = new MySqlCommand(s, m);
                
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["pid"].ToString());
                    string pname = reader["pname"].ToString();
                    string disease = reader["disease"].ToString();
                    string room =reader["room"].ToString();
                    DateOnly d = DateOnly.FromDateTime( DateTime.Parse(reader["admitdate"].ToString()) );
                
                    Patient patient = new Patient(id,pname,disease,room,d);
                    list.Add(patient);
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally { m.Close(); }
        }

        public static void Delete(int id)
        {
   
            MySqlConnection m = new MySqlConnection(s);
            try
            {
                m.Open();
                String s = "delete from patient where pid="+id;
                MySqlCommand cmd = new MySqlCommand(s, m);
                Console.WriteLine(s);
                 cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { m.Close(); }
        }

        public static Patient Getbyid(int id)
        {
         
            MySqlConnection m = new MySqlConnection(s);
            try
            {
                m.Open();
                String s = "SELECT * FROM PATIENT where pid="+id;
                MySqlCommand cmd = new MySqlCommand(s, m);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int pid = int.Parse(reader["pid"].ToString());
                    string pname = reader["pname"].ToString();
                    string disease = reader["disease"].ToString();
                    string room = reader["room"].ToString();
                    DateOnly d = DateOnly.FromDateTime(DateTime.Parse(reader["admitdate"].ToString()));
                    Patient patient = new Patient(pid, pname, disease, room, d);
                    return patient;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally { m.Close(); }
            return null;
        }
        
        public static int Update(Patient p)
        {
            MySqlConnection m = new MySqlConnection(s);
            try
            {
                m.Open();
                String s = "update patient set pname='" + p.pname + "', disease='" + p.disease + "', room='" + p.room + "',admitdate='" + p.admitdate.ToString("yyyy-MM-dd") + "' where pid=" + p.pid;
                MySqlCommand cmd = new MySqlCommand(s, m);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally { m.Close(); }
        }

    }
}