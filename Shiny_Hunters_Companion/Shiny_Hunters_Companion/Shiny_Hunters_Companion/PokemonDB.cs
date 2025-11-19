using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public class PokemonDB
    {

        //Connection string to Access Database file incase it needs to be changed
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";

        private OleDbConnection myConnection;
        private OleDbDataAdapter myDataAdapter;
        private DataSet myDataSet;
        private BindingSource myBindingSource;
        private string strSql;

        public PokemonDB()
        {

            myConnection = new OleDbConnection(connectionString);

        }

        public List<PokemonForm> GetAllPokemonForms()
        {

        }
    }

}
