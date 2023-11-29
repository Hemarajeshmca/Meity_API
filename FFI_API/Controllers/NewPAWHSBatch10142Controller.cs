using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FFI_DataModel;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static FFI_Model.New_Pawhs_BatchCreation_Model;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewPAWHSBatch10142Controller : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(NewPAWHSBatch10142Controller)); //Declaring Log4Net.       
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        NewPAWHSBatch10142Service objService = new NewPAWHSBatch10142Service();
        public NewPAWHSBatch10142Controller(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpGet("NewPAWHSBatchCreationList")]
        public FetchBatchListNew NewPAWHSBatchCreationList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue)
        {
            LogHelper.ConvertObjIntoString(locn, "Input");
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            FetchBatchListNew ObjList = new FetchBatchListNew();
            try
            {
                ObjList = objService.BatchCreation_List(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return ObjList;
        }

        [HttpGet("FectNewPAWHSBatchCreation")]
        public BatchCreationSingleFetch FectNewPAWHSBatchCreation(string org, string locn, string user, string lang, int batch_rowid, string batch_no)
        {
            LogHelper.ConvertObjIntoString(locn, "Input");
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            BatchCreationSingleFetch ObjList = new BatchCreationSingleFetch();
            try
            {
                ObjList = objService.FectNewPAWHSBatchCreation(org, locn, user, lang, batch_rowid, batch_no, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [HttpGet("BatchDetailsBasedonDestination")]
        public BatchDetailsBasedOnDest BatchDetailsBasedonDestination(string org, string locn, string user, string lang, string destination, string location_code)
        {
            BatchDetailsBasedOnDest objBatch = new BatchDetailsBasedOnDest();

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            try
            {
                objBatch = objService.BatchDetailsBasedonDestination(org, locn, user, lang, destination, location_code, ConString);
                LogHelper.ConvertObjIntoString(objBatch, "Output");
            }
            catch (Exception ex)
            {

            }
            return objBatch;
        }

        [HttpPost("SaveBatchDetailsBasedonDestination")]
        public PAWHSNewBatchCreation_Save_Context SaveBatchDetailsBasedonDestination(PAWHSNewBatchCreation_Save_Context objContext)
        {
            PAWHSNewBatchCreation_Save_Context objFetch = new PAWHSNewBatchCreation_Save_Context();
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objContext.locnId, this.appSettings.Value);
            try
            {
                objFetch = objService.SaveBatchDetailsBasedonDestination(objContext, ConString);
                LogHelper.ConvertObjIntoString(objFetch, "Output");
            }
            catch (Exception ex)
            {
            }
            return objFetch;
        }

        [HttpGet("FetchPODetails")]
        public FetchPODetails FetchPODetails(string org, string locn, string user, string lang, string po_no)
        {
            FetchPODetails objBatch = new FetchPODetails();
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            try
            {
                objBatch = objService.FetchPODetails(org, locn, user, lang, po_no, ConString);
                LogHelper.ConvertObjIntoString(objBatch, "Output");
            }
            catch (Exception ex)
            {

            }
            return objBatch;
        }

        public void SingleFetchBatchCreation()
        {

        }

        [HttpGet("GetPOBasedOnBuyer")]
        public DataTable GetPOBasedOnBuyer(string org, string locn, string user, string lang, string buyer_code)
        {
            DataTable dt = new DataTable();
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            try
            {
                dt = objService.GetPOBasedOnBuyer(org, locn, user, lang, buyer_code, ConString);
            }
            catch(Exception ex)
            {

            }
            return dt;
        }
    }

}
