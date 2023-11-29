using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;
using System.Data;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {


        SMSGetFarmerInfo_Service Obj_SMSGetFarmerInfo_Service = new SMSGetFarmerInfo_Service();

        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private IConfiguration _configuration;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(SMSController)); //Declaring Log4Net.       

        public SMSController(IOptions<MySettingsModel> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }
        [Authorize]
        [HttpPost("Getfarmerinfo")]
        public string GetFarmerInfo([FromBody] SMSGetFarmerInfoModel Query)
        {
            Farmerinfo Obj_farmerInfo = new Farmerinfo();

            try
            {
                string[] condition =
                {
                    "UPDATE",
                    "DELETE",
                    "INSERT",
                    "EXEC "
                };
                string condition_set = "TRUE";
                string Queryset = Query.InstanceName;

                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);

                
                foreach (string c in condition)
                {

                    if (Queryset.Contains(c))
                    {

                        condition_set = "FALSE";


                    }

                }

                if (condition_set == "TRUE")
                {
                    Obj_farmerInfo = Obj_SMSGetFarmerInfo_Service.GetFarmerInfoData(Query, ConString);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        //    var json = new JavaScriptSerializer().Serialize(Obj_farmerInfo);
            var serializedProduct = JsonConvert.SerializeObject(Obj_farmerInfo, Formatting.Indented);
            //Farmerinfo abc = new Farmerinfo();
            //abc = (Farmerinfo)JsonConvert.DeserializeObject(serializedProduct, typeof(Application));
            return serializedProduct;
        }


        //start 
        [Authorize]
        [HttpPost("ODISHAFARMERINFO")]
        public string GetOdishaFarmerInfo([FromBody] SMSOdishaFarmerInfoModel Query)
        {
            FARMER objfar = new FARMER();
            FARMERDETAILS Obj_farmerdetails = new FARMERDETAILS();
            DataSet ds3 = new DataSet();
            try
            {
                string[] condition =
                {
                    "UPDATE",
                    "DELETE",
                    "INSERT",
                    "EXEC "
                };
                string condition_set = "TRUE";
                string Queryset = Query.InstanceName;
                string Queryset1 = Query.FROMDATE;
                string Queryset2 = Query.TODATE;

                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);

                foreach (string c in condition)
                {
                    if (Queryset.Contains(c))
                    {
                        condition_set = "FALSE";
                        
                        
                    }
                }
                if (condition_set == "TRUE")
                {
                   objfar = Obj_SMSGetFarmerInfo_Service.GetOdishaFarmerInfo(Query, ConString);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(objfar, Formatting.Indented);
            return serializedProduct;
            // return objfar;
        }

        //End


        //start 
        [Authorize]
        [HttpPost("GETICDINVOICE_Old")]
        public ICD_Invoice_Details GetQueryDetailsICDIN([FromBody] SMSIcdDetailsModel Query)
        {
            ICD_Invoice_Details Obj_GetIcdInvoice = new ICD_Invoice_Details();
            DataSet ds3 = new DataSet();
            try
            {

                string[] condition =
                {
                    "UPDATE",
                    "DELETE",
                    "INSERT",
                    "EXEC "
                };
                string Queryset2 = Query.InstanceName;
                string condition_set = "TRUE";
                string Queryset = Query.FROMDATE;
                string Queryset1 = Query.TODATE;

                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);


                foreach (string c in condition)
                {

                    if (Queryset.Contains(c))
                    {

                        condition_set = "FALSE";

                        //ds.Columns.Add("ERROR", typeof(string));
                        //ds.Rows.Add("QUERY ERROR");
                    }

                }

                if (condition_set == "TRUE")
                {
                    Obj_GetIcdInvoice = Obj_SMSGetFarmerInfo_Service.GetimapTableDtICDIN(Query, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Obj_GetIcdInvoice;
        }
        //End


        //start 
        [Authorize]
        [HttpPost("GETICDPAYMENT_Old")]
        public ICD_Payment_Details GetQueryDetailsICDPAY([FromBody] SMSIcdDetailsModel Query)
        {
            ICD_Payment_Details Obj_ICD_Payment_Details = new ICD_Payment_Details();
            DataSet ds3 = new DataSet();
            try
            {

                string[] condition =
                {
                    "UPDATE",
                    "DELETE",
                    "INSERT",
                    "EXEC "
                };

                string condition_set = "TRUE";
                string Queryset = Query.FROMDATE;
                string Queryset1 = Query.TODATE;
                string Queryset2 = Query.InstanceName;

                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);


                foreach (string c in condition)
                {

                    if (Queryset.Contains(c))
                    {

                        condition_set = "FALSE";

                        //ds.Columns.Add("ERROR", typeof(string));
                        //ds.Rows.Add("QUERY ERROR");
                    }

                }

                if (condition_set == "TRUE")
                {
                    Obj_ICD_Payment_Details = Obj_SMSGetFarmerInfo_Service.GetimapTableDtICDPAY(Query, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Obj_ICD_Payment_Details;
        }
        //End

        //start
        [Authorize]
        [HttpPost("GETICDSTOCK_Old")]
        public ICD_Stock_Details GetQueryDetailsICDSTOCK([FromBody] SMSIcdDetailsModel Query)
        {
            ICD_Stock_Details Obj_ICD_Stock_Details = new ICD_Stock_Details();
            DataSet ds3 = new DataSet();
            try
            {

                string[] condition =
                {
                    "UPDATE",
                    "DELETE",
                    "INSERT",
                    "EXEC "
                };

                string condition_set = "TRUE";
                string Queryset = Query.FROMDATE;
                string Queryset1 = Query.TODATE;
                string Queryset2 = Query.InstanceName;

                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);


                foreach (string c in condition)
                {

                    if (Queryset.Contains(c))
                    {

                        condition_set = "FALSE";

                        //ds.Columns.Add("ERROR", typeof(string));
                        //ds.Rows.Add("QUERY ERROR");
                    }

                }

                if (condition_set == "TRUE")
                {
                    Obj_ICD_Stock_Details = Obj_SMSGetFarmerInfo_Service.GetimapTableDtICDSTOCK(Query, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Obj_ICD_Stock_Details;
        }
        //End


        //Start 
        [Authorize]
        [HttpPost("GETICDINVOICE")]
        public string GetIcdInvoiceDetails([FromBody] SMSIcdDetailsModel Query)
        {
            SMSICDInvoice_model Obj_GetIcdInvoice = new SMSICDInvoice_model();
            DataSet ds3 = new DataSet();
            try
            {

                string[] condition =
                {
                    "UPDATE",
                    "DELETE",
                    "INSERT",
                    "EXEC "
                };
                string Queryset = Query.InstanceName;
                string condition_set = "TRUE";
                string Queryset2 = Query.FROMDATE;
                string Queryset1 = Query.TODATE;

                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);



                foreach (string c in condition)
                {

                    if (Queryset.Contains(c))
                    {

                        condition_set = "FALSE";

                        //ds.Columns.Add("ERROR", typeof(string));
                        //ds.Rows.Add("QUERY ERROR");
                    }

                }

                if (condition_set == "TRUE")
                {
                    Obj_GetIcdInvoice = Obj_SMSGetFarmerInfo_Service.GetICDInvoice(Query, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(Obj_GetIcdInvoice, Formatting.Indented);
            return serializedProduct;
            // return Obj_GetIcdInvoice;
        }
        //End 


        //start
        [Authorize]
        [HttpPost("GETICDPAYMENT")]
        public string GetICDPaymentDetails([FromBody] SMSIcdDetailsModel Query)
        {
            SMSICDPayment_model Obj_ICD_Payment_Details = new SMSICDPayment_model();
            DataSet ds3 = new DataSet();
            try
            {

                string[] condition =
                {
                    "UPDATE",
                    "DELETE",
                    "INSERT",
                    "EXEC "
                };

                string condition_set = "TRUE";
                string Queryset2 = Query.FROMDATE;
                string Queryset1 = Query.TODATE;
                string Queryset = Query.InstanceName;

                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);

                foreach (string c in condition)
                {

                    if (Queryset.Contains(c))
                    {

                        condition_set = "FALSE";

                        //ds.Columns.Add("ERROR", typeof(string));
                        //ds.Rows.Add("QUERY ERROR");
                    }

                }

                if (condition_set == "TRUE")
                {
                    Obj_ICD_Payment_Details = Obj_SMSGetFarmerInfo_Service.GetICDPaymentDetails(Query, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(Obj_ICD_Payment_Details, Formatting.Indented);
            return serializedProduct;
            // return Obj_ICD_Payment_Details;
        }
        //End

        //start
        [Authorize]
        [HttpPost("GETICDSTOCK")]
        public string GetICDStockDetails([FromBody] SMSIcdDetailsModel Query)
        {
            SMSICDSTOCK_model Obj_ICD_Stock_Details = new SMSICDSTOCK_model();
            DataSet ds3 = new DataSet();
            try
            {

                string[] condition =
                {
                    "UPDATE",
                    "DELETE",
                    "INSERT",
                    "EXEC "
                };

                string condition_set = "TRUE";
                string Queryset2 = Query.FROMDATE;
                string Queryset1 = Query.TODATE;
                string Queryset = Query.InstanceName;

                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);


                foreach (string c in condition)
                {

                    if (Queryset.Contains(c))
                    {

                        condition_set = "FALSE";

                        //ds.Columns.Add("ERROR", typeof(string));
                        //ds.Rows.Add("QUERY ERROR");
                    }

                }

                if (condition_set == "TRUE")
                {
                    Obj_ICD_Stock_Details = Obj_SMSGetFarmerInfo_Service.GetICDStockDetails(Query, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(Obj_ICD_Stock_Details, Formatting.Indented);
            return serializedProduct;
            // return Obj_ICD_Stock_Details;
        }

        //End
        //start 
        [Authorize]
        [HttpPost("GETICDPRODUCTHISTORY")]
        public string GetIcdPRODUCTHISTORY([FromBody] SMSIcdDetailsModel Query)
        {
            SMSICDProducthistory_BO Obj_ICD_producthistory_Details = new SMSICDProducthistory_BO();
            DataSet ds3 = new DataSet();
            try
            {

                string[] condition =
                {
                    "UPDATE",
                    "DELETE",
                    "INSERT",
                    "EXEC "
                };

                string condition_set = "TRUE";
                string Queryset2 = Query.FROMDATE;
                string Queryset1 = Query.TODATE;
                string Queryset = Query.InstanceName;

                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);

                foreach (string c in condition)
                {

                    if (Queryset.Contains(c))
                    {

                        condition_set = "FALSE";

                        //ds.Columns.Add("ERROR", typeof(string));
                        //ds.Rows.Add("QUERY ERROR");
                    }

                }

                if (condition_set == "TRUE")
                {
                    Obj_ICD_producthistory_Details = Obj_SMSGetFarmerInfo_Service.GetPRODUCTHISTORY(Query, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(Obj_ICD_producthistory_Details, Formatting.Indented);
            return serializedProduct;
            //  return Obj_ICD_producthistory_Details;
        }
        //End


    }
}
