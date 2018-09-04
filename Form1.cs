using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NfcTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tag = Nfc.ReaderWriter.GetInformation();

            using (MySqlConnection connection = new MySqlConnection("Server=192.168.101.111;Database=TEST_DB;Uid=k_minamide;SSL Mode=none"))
            {
                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("insert into IN_OUT (CARD_ID, DT) values (@id, sysdate());", connection);
                    command.Parameters.Add(new MySqlParameter("@id", tag.identifier));

                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
            }


        }
    }
}
