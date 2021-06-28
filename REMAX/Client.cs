using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMAX
{
    public class Client
    {
        private string VclientId;
        private string VfName;
        private string VlName;
        private string Vemail;
        private string Vphone;
        private string vPassword;
        private string vRefEmp;



        public Client()
        {
           vRefEmp= VclientId = VfName = VlName = Vemail = Vphone=vPassword = "Undefined";
        }

        public Client(string ClientId, string FirstName, string LastName, string Email, string PhoneNumber,string Password,string RefEmp)
        {
            VclientId = ClientId;
            VfName = FirstName;
            VlName = LastName;
            Vemail = Email;
            Vphone = PhoneNumber;
            vPassword = Password;
            vRefEmp = RefEmp;


        }

        [System.ComponentModel.DataAnnotations.Key]
        public string ClientId
        {
            get => VclientId;
            set
            {
                VclientId = value;
            }
        }

        public string FirstName
        {
            get => VfName;
            set
            {
                VfName = value;
            }
        }

        public string LastName
        {
            get => VlName;
            set
            {
                VlName = value;
            }
        }

        public string Email
        {
            get => Vemail;
            set
            {
                Vemail = value;
            }
        }

        public string PhoneNumber
        {
            get => Vphone;
            set
            {
                Vphone = value;
            }
        }

        public string VPassword { get => vPassword; set => vPassword = value; }
        public string VRefEmp { get => vRefEmp; set => vRefEmp = value; }

        public string Display()
        {
            string info = "Client Id : " + ClientId + "\n FirstName : " + FirstName + "\nLast Name : " + LastName + "\nEmail : " + Email + "\nPhone Number : " + PhoneNumber;

            return info;
        }

    }
}
