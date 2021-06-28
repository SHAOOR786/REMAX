using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMAX
{
    public class House
    {

        private string vHouseNumber;
        private string vAddress;
        private string vCity;
        private string vProvince;
        private string vPostalCode;
        private EnumHuoseType vHouseType;
        private string vRefClient;



        public House()
        {
            vRefClient= vHouseNumber = vAddress = vCity = vProvince = vPostalCode = "Undefined";
            VHouseType = new EnumHuoseType();

        }
        public House(string HouseNumber, string Address, string City, string Province, string PostalCode, EnumHuoseType HouseType,string RefClient)
        {
            vHouseNumber = HouseNumber;
            vAddress = Address;
            vCity = City;
            vProvince = Province;
            vPostalCode = PostalCode;
            VHouseType = HouseType;
            VRefClient = RefClient;


        }
        [System.ComponentModel.DataAnnotations.Key]

        public string HouseNumber
        {
            get => vHouseNumber;
            set
            {
                vHouseNumber = value;
            }
        }
       
        public string Address
        {
            get => vAddress;
            set
            {
                vAddress = value;
            }
        }
        public string City
        {
            get => vCity;
            set
            {
                vCity = value;
            }
        }
        public string Province
        {
            get => vProvince;
            set
            {
                vProvince = value;
            }
        }
        public string PostalCode
        {
            get => vPostalCode;
            set
            {
                vPostalCode = value;
            }
        }
     

        public string VRefClient { get => vRefClient; set => vRefClient = value; }
        public EnumHuoseType VHouseType { get => vHouseType; set => vHouseType = value; }

        public string Display()
        {
            string info = "House Number : " + HouseNumber + "\nAddress : " + Address + "\nCity : " + City + "\nProvince : " + Province + "\nPostal Code : " + PostalCode  ;
            return info;
        }
    }
}
