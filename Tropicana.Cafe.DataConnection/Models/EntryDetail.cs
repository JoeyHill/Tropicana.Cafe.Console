using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropicana.Cafe.Main.Models
{
    public class EntryDetail
    {
        public int EntryDetailID { get; set; }

        public int EntryID { get; set; }

        public int StaffID { get; set; }

        public int ClassificationID { get; set; }

        public int AttendeeStatusEnum { get; set; }

        public int EventRegistrationFeeID { get; set; }

        public int CountryOfBirth_CountryID { get; set; }

        public int CountryOfResidence_CountryID { get; set; }

        public int RegionOfBirthID { get; set; }

        public int NationalityID { get; set; }

        public int Citizenship_CountryID { get; set; }

        public bool International { get; set; }

        public string InternationalDetails { get; set; }

        public bool Visa { get; set; }

        public string VisaDetails { get; set; }

        public string Religion { get; set; }

        public string Ethnicity { get; set; }

        public string Medical { get; set; }

        public string Disability { get; set; }

        public string Dietary { get; set; }

        public bool LivingWithDependents { get; set; }

        public DateTime DateEntry { get; set; }

        public DateTime DateExit { get; set; }

        public short ResidentYear { get; set; }

        public string ResidentStatus { get; set; }

        public string Occupation { get; set; }

        public string HearAboutUs { get; set; }

        public string VehicleRegistration { get; set; }

        public string VehicleDetails { get; set; }

        public string VehiclePermit { get; set; }

    }
}
