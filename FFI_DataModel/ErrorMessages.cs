using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_DataModel
{
    public class ErrorMessages
    {
        public string Errorno = "";
        public string ErrorMsg = "";

        public  string ErrorMessage(string errorno)
        {
            if (errorno == "06021")
            {
                ErrorMsg = "Proof Type cannot be blank";
            }
            else if (errorno == "1002")
            {
                ErrorMsg = "Phone No alreay register,So please give another number";
            }
            else if (errorno == "06022")
            {
                ErrorMsg = "Proof Doc cannot be blank";
            }
            else if (errorno == "06023")
            {
                ErrorMsg = "Proof Doc No cannot be blank";
            }
            else if (errorno == "06024")
            {
                ErrorMsg = "Status Cannot be blank ";
            }
            else if(errorno== "27001")
            {
                ErrorMsg = "Farmer ID should not be blank";
            }
            else if (errorno== "27002")
            {
                ErrorMsg = "Farmer member ID should not be blank";
            }
            else if (errorno == "27004")
            {
                ErrorMsg = "Shares applied on date cannot be blank";
            }
            else if (errorno == "27005")
            {
                ErrorMsg = "Shares applied on date cannot be a future date";
            }
            else if (errorno == "27006")
            {
                ErrorMsg = "Number of shares applied cannot be zero";
            }
            else if (errorno == "27007")
            {
                ErrorMsg = "Payment method cannot be blank";
            }
            else if (errorno == "27008")
            {
                ErrorMsg = "Payment status cannot be blank";
            }
            else if (errorno == "27010")
            {
                ErrorMsg = "Record modified since last fetch so Kindly refetch and continue ";
            }
            else if (errorno == "27014")
            {
                ErrorMsg = "Board Approval date cannot be left blank. ";
            }
            else if (errorno == "27016")
            {
                ErrorMsg = "Shares Approved' should be less than or equal to 'Shares Applied' count. ";
            }
            else if (errorno == "27017")
            {
                ErrorMsg = "Shares Rejected' should be less than or equal to 'Shares Applied' count. ";
            }
            else if (errorno == "27018")
            {
                ErrorMsg = "Report date cannot be left blank. ";
            }
            else if (errorno== "Please configure capital structure")
            {
                ErrorMsg = "Please configure capital structure";
            }
            else if(errorno== "Applied Share must be less than or equal to maximum share applicable")
            {
                ErrorMsg = "Applied Share must be less than or equal to maximum share applicable";
            }
            else if (errorno== "Authorized Capital is reached out")
            {
                ErrorMsg = "Authorized Capital is reached out";
            }
            else if (errorno== "27011")
            {
                ErrorMsg = "Inactive Record  cannot be modified";
            }
            else if(errorno == "Cannot approve share application without completing mandatory checklist item(s)")
            {
                ErrorMsg = "Cannot approve share application without completing mandatory checklist item(s)";
            }
            else if (errorno== "Record  can not be modified in current state")
            {
                ErrorMsg = "Record  can not be modified in current state";
            }
            else if (errorno == "06002")
            {
                ErrorMsg = "Status is Empty";
            }
            else if (errorno == "06004")
            {
                ErrorMsg = "Item Code not in product master.";
            }
            else if (errorno == "06003")
            {
                ErrorMsg = "Duplicate Entry.";
            }
            else if (errorno == "The Same Farmer Avaliable in Db")
            {
                ErrorMsg = "The Same Farmer Avaliable in Db";
            }
            else if (errorno == "Duplicate farmer not updated")
            {
                ErrorMsg = "Duplicate farmer not updated";
            }
            else if(errorno== "Duplicate Farmer - Combination of FarmerName/Surname/FHWName/DOB/Village/AadharNo")
            {
                ErrorMsg = "Duplicate Farmer - Combination of FarmerName/Surname/FHWName/DOB/Village/AadharNo";
            }
            else if (errorno == "Duplicate Farmer - Combination of FarmerName/FHWName/DOB/Village/AadharNo")
            {
                ErrorMsg = "Duplicate Farmer - Combination of FarmerName/FHWName/DOB/Village/AadharNo";
            }
            else if (errorno == "Duplicate Farmer -Combination of FarmerName/ DOB / Village / AadharNo")
            {
                ErrorMsg = "Duplicate Farmer -Combination of FarmerName/ DOB / Village / AadharNo";
            }
            else if (errorno == "Duplicate Farmer - Combination of FarmerName/Village/AadharNo")
            {
                ErrorMsg = "Duplicate Farmer - Combination of FarmerName/Village/AadharNo";
            }
            else if (errorno == "Duplicate Farmer - Combination of FarmerName/AadharNo")
            {
                ErrorMsg = "Duplicate Farmer - Combination of FarmerName/AadharNo";
            }
            else if (errorno == "Duplicate Farmer - Combination of FarmerName/FHWName/DOB/AadharNo")
            {
                ErrorMsg = "Duplicate Farmer - Combination of FarmerName/FHWName/DOB/AadharNo";
            }
            else if (errorno == "P00101")
            {
                ErrorMsg = "Please fill the mandatory fields correctly - invoice no,channel,invoice date and invoice amount.";
            }
            else if (errorno == "Hamlet cannot be blank")
            {
                ErrorMsg = "Hamlet cannot be blank";
            }
            else
            {
                ErrorMsg = errorno; //ramya added else part on 23 jun 21
            }
            return ErrorMsg;
        }

    }
}
