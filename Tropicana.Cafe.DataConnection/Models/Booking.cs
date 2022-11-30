using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tropicana.Cafe.Main.Rules;

namespace Tropicana.Cafe.Main.Models
{
    public class Booking
    {
        public int BookingID { get; set; }

        public int RoomSpaceID { get; set; }

        public string RoomSpaceDescription
        {
            get
            {
                return Data.DatabaseAccess.GetRoomSpaceDescription(this.RoomSpaceID);
            }
        }

        public int EntryID { get; set; }

        public int EntryStatusEnum { get; set; }

        public int RoomTypeID { get; set; }

        public int RoomLocationID { get; set; }

        public int Start_BookingReasonID { get; set; }

        public int End_BookingReasonID { get; set; }

        public int BookingTypeID { get; set; }

        public int RoomRateID { get; set; }

        public int BookingLinkTypeEnum { get; set; }

        public int TermSessionID { get; set; }

        public int HousekeepingID { get; set; }

        public bool RoomLocationFixed { get; set; }

        public decimal RoomRateAmount { get; set; }

        public DateTime CheckInDate { get; set; }

        public bool IsCheckInDay
        {
            get
            {
                return MealRules.isCheckInDay(this);
            }
        }

        public DateTime CheckOutDate { get; set; }

        public bool IsCheckOutDay
        {
            get
            {
                return MealRules.isCheckOutDay(this);
            }
        }

        public int ETA { get; set; }

        public int ETD { get; set; }

        public DateTime? CheckInDateActual { get; set; }

        public DateTime? CheckOutDateActual { get; set; }

        public DateTime DateChargedTo { get; set; }

        public DateTime ContractDateStart { get; set; }

        public DateTime ContractDateEnd { get; set; }

        public bool ResvChargeToEntry { get; set; }

        public int NumberOfGuests { get; set; }

        public int NumberOfGuestsFree { get; set; }

        public int NumberOfChildren { get; set; }

        public int NumberOfChildrenFree { get; set; }

        public string SpecialRequirement { get; set; }

        public string Comments { get; set; }

        public DateTime? DateBilled { get; set; }

        public bool CustomBit1 { get; set; }

        public bool CustomBit2 { get; set; }

        public bool CustomBit3 { get; set; }

        public bool CustomBit4 { get; set; }

        public string CustomString1 { get; set; }

        public string CustomString2 { get; set; }

        public string CustomString3 { get; set; }

        public string CustomString4 { get; set; }

        public string CustomString5 { get; set; }

        public string CustomString6 { get; set; }

        public string CustomString7 { get; set; }

        public string CustomString8 { get; set; }

        public string CustomString9 { get; set; }

        public string CustomString10 { get; set; }

        public DateTime? CustomDate1 { get; set; }

        public DateTime? CustomDate2 { get; set; }

        public DateTime? CustomDate3 { get; set; }

        public DateTime? CustomDate4 { get; set; }

        public int SecurityUserID { get; set; }

        public DateTime DateModifiedBilling { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
