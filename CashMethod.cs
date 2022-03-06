using System;
using System.IO;
using System.Windows.Forms;

namespace Book_Kepping
{
    public partial class CashMethod : Form
    {
        public CashMethod()
        {
            InitializeComponent();

            //Drag and Drop
            AllowDrop = true;
            DragEnter += new DragEventHandler(CashMethod_DragEnter);
            DragDrop += new DragEventHandler(CashMethod_DragDrop);
        }
        private void CashMethod_Load(object sender, EventArgs e)
        {
            UpdateSupportingFileName();
        }


        //relative Path
        private string relPath = C_Relative_Path.GetRelativePath(true); //true because this is the Cash method.


        //Drag and Drop
        private string droppedFile;
        void CashMethod_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        void CashMethod_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) Console.WriteLine(file);
            droppedFile = files[0];
            UpdateSupportingFileName();
        }
        private void UpdateSupportingFileName()
        {
            if (droppedFile != null)
            {
                TB_supporting_file_name.Text = droppedFile;
            }
            else
            {
                TB_supporting_file_name.PlaceholderText = "No File Has Been Provided";
            }
        }


        //information Submit
        private void BT_Submit_Click(object sender, EventArgs e)
        {
            if (CheckDataFields())
            {
                //if the directory doesn't exist it creates it
                if (!Directory.Exists(relPath + PathFriendlyDate() + "\\src"))
                {
                    CreateDirectory();
                }
                //if the connection to the Database is successfull we send the information
                if (DB_Control_Logic.DataRequest.TestDatabaseConnection())
                {
                    CopyFile(droppedFile);
                    DB_Control_Logic.DataRequest.InsertBookKeepingEntry
                        (GetMovementType(),
                        TB_purchase_description.Text,
                        float.Parse(TB_purchase_amount.Text),
                        dateTimePicker2.Value,
                        C_Relative_Path.GetRelativePath(true) + PathFriendlyDate() + "\\" + (DB_Control_Logic.DataRequest.GetLastCashID() + 1).ToString() + GetFileExtension(droppedFile));
                    TB_purchase_amount.Text = "";
                    TB_purchase_description.Text = "";
                    TB_supporting_file_name.Text = "";
                    MessageBox.Show("Information Successfully Stored In The Database!");
                }
                else
                {
                    MessageBox.Show("Information Not Stored Due To An Error! \nPlease Contact The Developer For Further Assistance!");
                }
            }
            else
            {
                MessageBox.Show("Missing Information!");
            }
            GC.Collect();
        }


        //creates the directory for X date files
        private void CreateDirectory()
        {
            string path = relPath + PathFriendlyDate();
            Directory.CreateDirectory(path);
        }


        //places the file in the directory
        private void CopyFile(string fileToCopy)
        {
            string path = C_Relative_Path.GetRelativePath(true) + PathFriendlyDate() + "\\";
            File.Copy(fileToCopy, path + (DB_Control_Logic.DataRequest.GetLastCashID() + 1).ToString() + GetFileExtension(fileToCopy));
            
        }


        //Gets the name of the file
        private string GetFileExtension(string filePath)
        {
            int fileExtensionIndexStart = 0;
            char[] charFilePath = filePath.ToCharArray();
            string fileExtension = "";
            //gets the index where the file extension starts
            for(int i = (charFilePath.Length - 1); i >= 0; i--)
            {
                if(charFilePath[i] == '.')
                {
                    fileExtensionIndexStart = i;
                    break;
                }
            }

            //Makes the array of chars into a string
            for(int i = fileExtensionIndexStart; i <= (charFilePath.Length - 1); i++)
            {
                fileExtension += charFilePath[i];
            }

            return fileExtension;
        }


        //returns the date (path friendly)  ex "2_22_2022" MM_DD_YYYY
        private string PathFriendlyDate()
        {
            return (dateTimePicker2.Value.Month.ToString() + "_" + dateTimePicker2.Value.Day.ToString() + "_" + dateTimePicker2.Value.Year.ToString());
        }


        //checks if the fields in the form are filled or empty
        private bool CheckDataFields()
        {
            if ((!RA_credit.Checked && !RA_debit.Checked) || (TB_purchase_description.Text.Length == 0 || TB_purchase_description.Text == " ") || (TB_supporting_file_name.Text.Length == 0 || TB_supporting_file_name.Text == " ") || (TB_purchase_amount.Text.Length == 0 || TB_purchase_amount.Text == " "))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //get the movement type
        private bool GetMovementType()
        {
            if (RA_credit.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}