using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropicana.Cafe.Main.Models
{
    public class Entry
    {
        public int EntryID { get; set; }

        public int CategoryID { get; set; }

        public int EventID { get; set; }

        public int GroupID { get; set; }

        public int ContactID { get; set; }

        public int EntryStatusEnum { get; set; }

        public int AddressTypeID { get; set; }

        public int BookingID { get; set; }

        public int EntryApplicationID { get; set; }

        public int PinNumber { get; set; }

        public string NameLast { get; set; }

        public string NameFirst { get; set; }

        public string NameTitle { get; set; }

        public string NamePreferred { get; set; }

        public string NameWeb { get; set; }

        public string NameOther { get; set; }

        public string NameInitials { get; set; }

        public string NameSharer { get; set; }

        public int GenderEnum { get; set; }

        public int Birth_GenderEnum { get; set; }

        public bool DirectoryFlagPrivacy { get; set; }

        public DateTime? DOB { get; set; }

        public string Position { get; set; }

        public string ID1 { get; set; }

        public string ID2 { get; set; }

        public string ID3 { get; set; }

        public int ID4 { get; set; }

        public int ID5 { get; set; }

        public bool PhoneProcessToAccount { get; set; }

        public int PhoneChargeTypeID { get; set; }

        public decimal PhoneDisableValue { get; set; }

        public decimal PhoneRestrictValue { get; set; }

        public int PhoneControlEnum { get; set; }

        public int TaxExemptionEnum { get; set; }

        public DateTime? LastCheckInOutDate { get; set; }

        public int Previous_EntryStatusEnum { get; set; }

        public bool Testing { get; set; }

        public int User_SecurityUserID { get; set; }

        public int SecurityUserID { get; set; }

        public int CreatedBy_SecurityUserID { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid EntryGUID { get; set; }

        public string PortalEmail { get; set; }

        public Guid PortalResetGUID { get; set; }

        public string PortalAuthProviderUserID { get; set; }

    }
}
