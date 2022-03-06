using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book_Kepping
{
    public partial class DatabaseSettings : Form
    {
        public DatabaseSettings()
        {
            InitializeComponent();
        }

        //fill in information
        private static string dbName, tbName;
        public static void SetDbName(string payload)
        {
            dbName = payload;
        }
        public static void SetTbName(string payload)
        {
            tbName = payload;
        }

        private void B_Verify_Click(object sender, EventArgs e)
        {
            //Saves the Information
            TextWriter txt = new StreamWriter(C_Relative_Path.GetRelativePath(true) + "src\\CM_DB.txt");
            txt.Write(TB_DatabaseName.Text);
            txt.Close();
            TextWriter txt2 = new StreamWriter(C_Relative_Path.GetRelativePath(true) + "src\\CM_TB.txt");
            txt2.Write(TB_TableName.Text);
            txt2.Close();

            DB_Control_Logic.Database_Info.SetDatabaseName(TB_DatabaseName.Text);
            DB_Control_Logic.Database_Info.SetTableName(TB_TableName.Text);


            //Verifies the connection
            if (DB_Control_Logic.DataRequest.TestDatabaseConnection())
            {
                MessageBox.Show("The Database Connection Was Successful!");
            }
            else
            {
                MessageBox.Show("The Database Connection Was Not Successful!");
            }
        }
        private void DatabaseSettings_Load(object sender, EventArgs e)
        {
            TB_DatabaseName.Text = dbName;
            TB_TableName.Text = tbName;
        }
    }
}