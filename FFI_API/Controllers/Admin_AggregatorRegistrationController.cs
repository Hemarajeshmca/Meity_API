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
    public class Admin_AggregatorRegistrationController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_AggregatorRegistrationController)); //Declaring Log4Net.    
        Admin_AggregatorRegistrationService objService = new Admin_AggregatorRegistrationService();
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End

        public Admin_AggregatorRegistrationController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        //new_pa_whs_mst_product
        [HttpGet("allaggregator_registration")]
        public PAWHSAggregatorRegistrationList AggregatorRegistrationList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue)
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

            PAWHSAggregatorRegistrationList ObjList = new PAWHSAggregatorRegistrationList();
            try
            {
                ObjList = objService.AggregatorRegistrationList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [HttpGet("aggregator_registration")]
        public FectAggregatorRegistration FectAggregatorRegistration(string org, string locn, string user, string lang, int orgn_rowid, string aggregator_code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(orgn_rowid);
            objArr.Add(aggregator_code);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            FectAggregatorRegistration ObjList = new FectAggregatorRegistration();
            try
            {
                ObjList = objService.FectAggregatorRegistration(org, locn, user, lang, orgn_rowid, aggregator_code, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [HttpGet("Aggr_mem_reg")]
        public MApplication AggrMemberFetch(string userId, string orgnId, string locnId, string localeId, int orgn_rowid, string orgn_code, string aggregator_code, string fpo_code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(userId);
            objArr.Add(orgnId);
            objArr.Add(locnId);
            objArr.Add(localeId);
            objArr.Add(orgn_rowid);
            objArr.Add(orgn_code);
            objArr.Add(aggregator_code);
            objArr.Add(fpo_code);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locnId, this.appSettings.Value);

            MApplication ObjFetch = new MApplication();
            try
            {
                ObjFetch = objService.AggrMemberFetch(orgnId, locnId, userId, localeId, orgn_rowid, orgn_code, aggregator_code, fpo_code, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        [HttpPost("new_aggregator_registration")]
        public SaveAGGDocument SavePAWHSAggregatorRegistration(SaveAggregatorRegistration objAggReg)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objAggReg, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objAggReg.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            SaveAGGDocument Objresult = new SaveAGGDocument();
            try
            {
                Objresult = objService.SavePAWHSAggregatorRegistration(objAggReg, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objAggReg.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return Objresult;

        }
        [HttpPost("Fetch_Addregator")]
        public AggregatorFetch_application Fetch_Aggreator_Mob (AggrFetchContext objContext)
        {
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objContext.locnId, this.appSettings.Value);
            AggregatorFetch_application ObjList = new AggregatorFetch_application();
            try
            {
                ObjList = Admin_AggregatorRegistrationService.GetAggrMobileList(objContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
    }
}
