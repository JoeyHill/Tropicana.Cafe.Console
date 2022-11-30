using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropicana.Cafe.Main.Models
{
    public class EntryCustomField
    {
        public int EntryCustomFieldID { get; set; }

        public int EntryID { get; set; }

        public int CustomFieldDefinitionID { get; set; }

        public int FieldDataTypeEnum { get; set; }

        public string ValueString { get; set; }

        public DateTime? ValueDate { get; set; }

        public Boolean ValueBoolean { get; set; }

        public int ValueInteger { get; set; }

        public decimal ValueMoney { get; set; }

    }
}
