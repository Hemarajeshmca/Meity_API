using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFI_DataModel;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICDMOBListController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDProductController)); //Declaring Log4Net. 
        public ICDMOBListController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpGet("get_adjustment_count")]
        public string ICDProduct_List(string org, string locn, string user, string lang,string customer_code,string product_code,string adjustment_type,string adjustment_date)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            ADJCOUNTRoot ObjList = new ADJCOUNTRoot();
            try
            {
                ObjList = ICDMOBList_service.ICDProduct_List(org, locn, user, lang, customer_code, product_code, adjustment_type, adjustment_date, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }

        [HttpGet("ICD_Supplier_list")]
        public string ICD_SupplieRlist(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(filterby_option);
            objArr.Add(filterby_code);
            objArr.Add(filterby_fromvalue);
            objArr.Add(filterby_tovalue);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            ICDMOBSRoot ObjList = new ICDMOBSRoot();
            try
            {
                ObjList = ICDMOBList_service.ICD_Supplier_list_SRV(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }
        [HttpGet("Customers")]
        public string Customerslist(string org, string locn, string user, string lang)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);           
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            ICDMOBCRoot ObjList = new ICDMOBCRoot();
            try
            {
                ObjList = ICDMOBList_service.Customerslist_SRV(org, locn, user, lang, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }
        [HttpGet("allmasterlist")]
        public string allmasterlist(string org, string locn, string user, string lang,string parent_code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(parent_code);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            MasterRootObject ObjList = new MasterRootObject();
            try
            {
                ObjList = ICDMOBList_service.allmasterlist_SRV(org, locn, user, lang, parent_code, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }
        [HttpGet("geticdtransaction")]
        public string geticdtransactionlist(string org, string locn, string user, string lang)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            ICDMOBTRoot ObjList = new ICDMOBTRoot();
            try
            {
                ObjList = ICDMOBList_service.geticdtransactionlist_SRV(org, locn, user, lang, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }
    }
}
