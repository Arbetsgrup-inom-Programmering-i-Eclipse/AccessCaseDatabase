using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQL
{
    public static class AriaInterface
    {
        private static SqlConnection connection = null;

        public static void Connect()
        {
            // Clinical database
            connection = new SqlConnection("data source = IPADDRESS; initial catalog = VARIAN; persist security info = True; user id = USERID; password = PASSWORD; MultipleActiveResultSets = True");
            
            // Research database
            //connection = new SqlConnection("data source = IPADDRESS; initial catalog = VARIAN; persist security info = True; user id = USERID; password = PASSWORD; MultipleActiveResultSets = True");
            
            connection.Open();
        }

        public static void Disconnect()
        {
            connection.Close();
        }

        public static DataTable Query(string queryString)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection) { MissingMappingAction = MissingMappingAction.Passthrough, MissingSchemaAction = MissingSchemaAction.Add };
                adapter.Fill(dataTable);
                adapter.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }
    }
}
