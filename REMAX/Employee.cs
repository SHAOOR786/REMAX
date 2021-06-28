using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMAX
{
    public class Employee
    {

        private string vEmployeeId;
        private string vFName;
        private EnumEmpType vType;
        private string vLName;
        private string vEmail;
        private string vPhone;
        private string vPassword;



        public Employee()
        {
            VEmployeeId = VFName = VLName = VEmail = VPhone = VPassword = "Undefined";
            VType = new EnumEmpType();
        }

        public Employee(string EmployeeId, string FirstName, string LastName, string Email, string PhoneNumber, string Password, EnumEmpType Type)
        {
            VEmployeeId = EmployeeId;
            vFName = FirstName;
            vLName = LastName;
            vEmail = Email;
            vPhone = PhoneNumber;
            VPassword = Password;
            VType = Type;
        }

        [System.ComponentModel.DataAnnotations.Key]

        public string VEmployeeId { get => vEmployeeId; set => vEmployeeId = value; }

        public string VFName { get => vFName; set => vFName = value; }
        public string VLName { get => vLName; set => vLName = value; }
        public string VEmail { get => vEmail; set => vEmail = value; }
        public string VPhone { get => vPhone; set => vPhone = value; }
        public string VPassword { get => vPassword; set => vPassword = value; }
        public EnumEmpType VType { get => vType; set => vType = value; }
    }
}

