using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Kepping
{
    public class BookKeepingEntryModel
    {
        public int id { get; set; }
        public bool movementType { get; set; }
        public string transactionDescription { get; set; }
        public float amount { get; set; }
        public DateTime date { get; set; }
        public string supportingFilesPath { get; set; }
    }
}
