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
using static FFI_Model.Admin_BulkUpload_Model;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin_BulkUploadController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_BulkUploadController)); //Declaring Log4Net.
        Admin_BulkUpload_Service objRoleService = new Admin_BulkUpload_Service();
        public Admin_BulkUploadController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpGet("excelTemp")]
        public BulkExceltempApplication exceltempfetch(string org, string locn, string user, string lang,  string excel_upload_code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(excel_upload_code);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End

            BulkExceltempApplication ObjFetch = new BulkExceltempApplication();
            try
            {
                ObjFetch = objRoleService.exceltempfetch(org, locn, user, lang, excel_upload_code, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }

            return ObjFetch;
        }
        [HttpPost("excelVector")]
        public savevectorApplicationouput SaveBulkvector(vectorApplication objRole)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objRole, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objRole.document.context.locnId, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            savevectorApplicationouput ObjFetch = new savevectorApplicationouput();
            try
            {
                ObjFetch = objRoleService.SaveBulkvector(objRole, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objRole.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }
        [HttpPost("excelScalar")]
        public ScalerApplicationRes SaveBulkScalar(ScalerApplication objRole)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objRole, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objRole.document.context.locnId, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            ScalerApplicationRes ObjFetch = new ScalerApplicationRes();
            try
            {
                ObjFetch = objRoleService.SaveBulkScalar(objRole, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objRole.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjFetch;
        }
        [HttpPost("excelHistory")]
        public SaveHistoryContextRes SaveexcelHistory(SaveHistoryApplication objRole)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objRole, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objRole.document.context.locnId, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            SaveHistoryContextRes ObjFetch = new SaveHistoryContextRes();
            try
            {
                ObjFetch = objRoleService.SaveexcelHistory(objRole, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objRole.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjFetch;
        }

        [HttpPost("excelduplicate")]
        public ScalerApplicationRes SaveBulkDuplicateCheck(duplicatefarmerdata objRole)
        {
            //log Input information
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objRole.locnId, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            ScalerApplicationRes ObjFetch = new ScalerApplicationRes();
            try
            {
                ObjFetch = objRoleService.SaveBulkDuplicateCheck(objRole, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objRole.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }
    }
}