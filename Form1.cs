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

        private string textContents, textContents2;
        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(C_Relative_Path.GetRelativePath(true) + "\\src");
            try
            {
                //prefill the database information if there is any
                TextReader txt = new StreamReader(C_Relative_Path.GetRelativePath(true) + "src\\CM_DB.txt");
                textContents = txt.ReadToEnd();
                DB_Control_Logic.Database_Info.SetDatabaseName(textContents);
                DatabaseSettings.SetDbName(textContents);
                txt.Close();

                TextReader txt2 = new StreamReader(C_Relative_Path.GetRelativePath(true) + "src\\CM_TB.txt");
                textContents2 = txt2.ReadToEnd();
                DB_Control_Logic.Database_Info.SetDatabaseName(textContents2);
                DatabaseSettings.SetTbName(textContents2);
                txt2.Close();
            }
            catch (FileNotFoundException)
            {
                //creates the files in the event of their inexistence
                TextWriter text1 = new StreamWriter(C_Relative_Path.GetRelativePath(true) + "src\\CM_DB.txt");
                text1.Close();
                TextWriter text2 = new StreamWriter(C_Relative_Path.GetRelativePath(true) + "src\\CM_TB.txt");
                text2.Close();
            }
            //Verifies the connection
            if (DB_Control_Logic.DataRequest.TestDatabaseConnection())
            {
                MessageBox.Show("The Database auto-Connection Was Successful!");
            }
            else
            {
                MessageBox.Show("The Database auto-Connection Was Not Successful... \nPlease Verify the Settings!");
            }
        }

        private void BT_accrual_method_Click(object sender, EventArgs e)
        {

        }

        private void BT_cash_method_Click(object sender, EventArgs e)
        {
            Form cashMethodForm = new CashMethod();

            cashMethodForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void B_DatabaseInfo_Click(object sender, EventArgs e)
        {
            Form databaseSettings = new DatabaseSettings();
            databaseSettings.Show();
        }
    }
}
