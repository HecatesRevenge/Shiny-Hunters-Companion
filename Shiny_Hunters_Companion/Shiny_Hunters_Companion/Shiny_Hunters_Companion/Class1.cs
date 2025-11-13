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
        OleDbConnection myConnection;
        OleDbDataAdapter myDataAdapter;
        DataSet myDataSet;
        BindingSource myBindingSource;
        string strSql;

        public PokemonDB()
        {

            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyHuntersCompanion.accdb;");
            //Might need to query different table
            strSql = "SELECT * FROM tblPokemon";
            myDataAdapter = new OleDbDataAdapter(strSql, myConnection);
            myDataSet = new DataSet("AllPokemon");
            myDataAdapter.Fill(myDataSet, "AllPokemon");
            
            myBindingSource=new BindingSource();
            myBindingSource.DataSource = myDataSet;
            myBindingSource.DataMember = "AllPokemon";

           

        }
    }

}
