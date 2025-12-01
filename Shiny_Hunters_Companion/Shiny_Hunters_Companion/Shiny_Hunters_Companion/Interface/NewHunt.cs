using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public partial class NewHunt : Form
    {
        private GameDB gameDB=new GameDB();
        private PokemonDB pokemonDB=new PokemonDB();
        private MethodDB methodDB = new MethodDB();
        private ModifierDB modifierDB = new ModifierDB();
        private HuntDB huntDB = new HuntDB();

        public NewHunt()
        {
            InitializeComponent();
            RunColumnDiagnostics();

        }
        private void NewHunt_Load(object sender, EventArgs e)
        {


            List<Game> games = gameDB.GetAllGames();
            if (games.Count == 0)
            {
                MessageBox.Show("Debug Warning: GameDB returned 0 games. Database might be empty or reset.");
            }
          
            cbGames.DisplayMember = "GameName";
            cbGames.ValueMember = "GameID";
            cbGames.DataSource = games;
            cbGames.SelectedIndex = -1;

        }

        private void cbGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGames.SelectedIndex == -1) return;

            int gameID = (int)cbGames.SelectedValue;

            List<Method> methods = methodDB.GetMethodsFromGame(gameID);

            cbMethods.DisplayMember = "MethodName";
            cbMethods.ValueMember = "MethodID";
            cbMethods.DataSource = methods;

            cbMethods.SelectedIndex = -1;

            LoadModifiersByGame(gameID);

            lstPokemon.DataSource = null;
            pbPreview.Image = null;
            lblPreviewName.Text = "";
            lblPreviewOdds.Text = "Est. Odds: --";
        }
        private void LoadModifiersByGame(int gameID)
        {
            List<PlayerModifier> modifiers = modifierDB.GetModifiersByGame(gameID);

            chkModifiers.DataSource = null;
            chkModifiers.DataSource = modifiers;
            chkModifiers.DisplayMember = "ModifierName";
            chkModifiers.ValueMember = "ModifierID";


            //Clear all values that were check by the user prior
            for (int i = 0; i < chkModifiers.Items.Count; i++)
            {
                chkModifiers.SetItemChecked(i, false);
            }
        }
        private void cbMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbGames.SelectedIndex == -1) || (cbMethods.SelectedIndex == -1))
            {
                return;
            }
            int gameID = Convert.ToInt32(cbGames.SelectedValue);
            int methodID = Convert.ToInt32(cbMethods.SelectedValue);

            List<PokemonForm> pokemon = pokemonDB.GetFormsByGameAndMethod(gameID, methodID);

            lstPokemon.DisplayMember = "DisplayName";
            lstPokemon.ValueMember = "FormID";
            lstPokemon.DataSource = pokemon;
            lstPokemon.SelectedIndex = -1;
        }
      

        private  List<PlayerModifier> GetSelectModifiers(){
            List<PlayerModifier> selectedModifiers=new List<PlayerModifier>();

            //Basic foreach loop that looks at all checked modifiers and adds them to 
            //a list containing all modifiers for that player
            foreach(var item in chkModifiers.CheckedItems)
            {
                selectedModifiers.Add((PlayerModifier)item);
            }
            return selectedModifiers;

        }

       
        
       

        

        private void lstPokemon_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (lstPokemon.SelectedIndex == -1)
            {
                return;
            }

            PokemonForm selectedPokemon= (PokemonForm)lstPokemon.SelectedItem;

            lblPreviewName.Text=selectedPokemon.DisplayName;
            if (string.IsNullOrEmpty(selectedPokemon.SpriteURL))
            {
                pbPreview.Image = null;
            }
            else
            {
                pbPreview.LoadAsync(selectedPokemon.SpriteURL);
            }

            if (cbMethods.SelectedItem != null)
            {
                Method meth=(Method)cbMethods.SelectedItem;
                lblPreviewOdds.Text= $"Est. Odds: 1/{meth.BaseOdds}";
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if ((cbGames.SelectedIndex == -1) || (cbMethods.SelectedIndex == -1))
            {
                MessageBox.Show("Error! Please Complete All Selections");
                return;
                
            }

            Hunt newHunt=new Hunt();
            newHunt.GameID = Convert.ToInt32(cbGames.SelectedValue);
            newHunt.MethodID=Convert.ToInt32(cbMethods.SelectedValue);
            newHunt.FormID=Convert.ToInt32(lstPokemon.SelectedValue);
            newHunt.UserID=Program.CurrentUser.UserID;
            newHunt.EncounterCount = 0;
            newHunt.isActive = true;
            newHunt.TotalTimeSeconds = 0;
            newHunt.ActiveModifiers = GetSelectModifiers();

            int newHuntResult=huntDB.CreateHunt(newHunt);

            if (newHuntResult != -1)
            {
                this.DialogResult=DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Creating a New Shiny Hunt");
            }

        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pbPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void RunColumnDiagnostics()
        {
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";

            using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connString))
            {
                try { conn.Open(); }
                catch (Exception ex) { MessageBox.Show("DB Connection Failed: " + ex.Message); return; }

                System.Text.StringBuilder report = new System.Text.StringBuilder();
                report.AppendLine("--- DIAGNOSTIC REPORT ---");

                // 1. Check tblPokemonForms Columns (Used in your SELECT f....)
                CheckColumn(conn, "tblPokemonForms", "FormID", report);
                CheckColumn(conn, "tblPokemonForms", "FormName", report);
                CheckColumn(conn, "tblPokemonForms", "DisplayName", report);
                CheckColumn(conn, "tblPokemonForms", "SpriteURL", report);
                CheckColumn(conn, "tblPokemonForms", "PokemonID_FK", report); // Used in JOIN

                // 2. Check tblPokemon Columns (Used in your SELECT p....)
                CheckColumn(conn, "tblPokemon", "PokemonID", report);
                CheckColumn(conn, "tblPokemon", "PokedexNumber", report);
                CheckColumn(conn, "tblPokemon", "BaseName", report);

                // 3. Check tblEncounters Columns (Used in your WHERE e....)
                CheckColumn(conn, "tblEncounters", "GameID_FK", report);
                CheckColumn(conn, "tblEncounters", "MethodID_FK", report);

                // CRITICAL CHECK: This is likely where the mismatch is
                // Does your table use 'FormID' or 'FormID_FK'?
                CheckColumn(conn, "tblEncounters", "FormID", report);
                CheckColumn(conn, "tblEncounters", "FormID_FK", report);

                MessageBox.Show(report.ToString(), "Database Column Check");
            }
        }

        // Helper to test a single column
        private void CheckColumn(System.Data.OleDb.OleDbConnection conn, string table, string col, System.Text.StringBuilder sb)
        {
            try
            {
                // Try to select just this one column
                var cmd = new System.Data.OleDb.OleDbCommand($"SELECT TOP 1 [{col}] FROM [{table}]", conn);
                cmd.ExecuteScalar();
                sb.AppendLine($"[✔ OK] {table}.{col}");
            }
            catch
            {
                sb.AppendLine($"[❌ MISSING] {table}.{col}");
            }
        }


    }
}
