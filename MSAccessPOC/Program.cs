using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MSAccessPOC
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Farrukh");
            // InsertData();

            const string accountSid = "Accid";
            const string authToken = "Token";
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"), body: "Good morning Farrukh", to: new Twilio.Types.PhoneNumber("whatsapp:+92345"));
            Console.WriteLine(message.Sid);

            Console.ReadLine();
        }


        public static bool InsertData()
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                     @"Data source= C:\Users\FarrukhRehman\Documents\Database1.accdb";

            try
            {
                conn.Open();
                String name = "Muddasr";
                String cell = "0301";
              
                String my_querry = "INSERT INTO Customer(Name,CellNo)VALUES('" + name + "','" + cell + "')";

                OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data saved successfuly...!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed due to" + ex.Message);
                return false;
               
            }
            finally
            {
                conn.Close();
            }


        
        }
    }
}
