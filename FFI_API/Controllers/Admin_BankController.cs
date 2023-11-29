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

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin_BankController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_FinancialYearController)); //Declaring Log4Net.
        Admin_BankService objRoleService = new Admin_BankService();
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public Admin_BankController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpGet("allbank")]
        public BankList BankList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue)
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
            BankList ObjList = new BankList();
            try
            {
                ObjList = objRoleService.BankList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [HttpGet("bank")]
        public FetchBank FetchBank(string org, string locn, string user, string lang, int bank_rowid)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(bank_rowid);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            FetchBank ObjFetch = new FetchBank();
            try
            {
                ObjFetch = objRoleService.FetchBank(org, locn, user, lang, bank_rowid, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        [HttpPost("newbank")]
        public OutputBank SaveBank(SaveBank objBank)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objBank, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objBank.document.context.locnId, this.appSettings.Value);
            OutputBank ObjFetch = new OutputBank();
            try
            {
                ObjFetch = objRoleService.SaveBank(objBank, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objBank.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }
    }
}
