using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";
        private OleDbConnection myConnection;
        public Form1()
        {
            myConnection = new OleDbConnection(connectionString);
            InitializeComponent();
            DatabaseSeeder.SeedGames();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Add these namespaces at the top

       

    }
}
