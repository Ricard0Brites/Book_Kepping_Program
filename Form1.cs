using System;
using System.Windows.Forms;
using System.IO;

namespace Book_Kepping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string databaseTextContents, tableTextContents;
        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(C_Relative_Path.GetRelativePath(true) + "\\src"); //if the directory exists this line is ignored
            try
            {
                //prefill the database information if there is any
                TextReader databaseTextFile = new StreamReader(C_Relative_Path.GetRelativePath(true) + "src\\CM_DB.txt");
                databaseTextContents = databaseTextFile.ReadToEnd();
                DB_Control_Logic.Database_Info.SetDatabaseName(databaseTextContents);
                DatabaseSettings.SetDbName(databaseTextContents);
                databaseTextFile.Close();

                TextReader tableTextFile = new StreamReader(C_Relative_Path.GetRelativePath(true) + "src\\CM_TB.txt");
                tableTextContents = tableTextFile.ReadToEnd();
                DB_Control_Logic.Database_Info.SetDatabaseName(tableTextContents);
                DatabaseSettings.SetTbName(tableTextContents);
                tableTextFile.Close();
            }
            catch (FileNotFoundException)
            {
                //creates the files in the event of their inexistence
                TextWriter text1 = new StreamWriter(C_Relative_Path.GetRelativePath(true) + "src\\CM_DB.txt");
                text1.Close();
                TextWriter text2 = new StreamWriter(C_Relative_Path.GetRelativePath(true) + "src\\CM_TB.txt");
                text2.Close();
            }
        }

        private void BT_cash_method_Click(object sender, EventArgs e)
        {
            Form cashMethodForm = new CashMethod();
            cashMethodForm.Show();
        }

        private void B_DatabaseInfo_Click(object sender, EventArgs e)
        {
            Form databaseSettings = new DatabaseSettings();
            databaseSettings.Show();
        }
    }
}
