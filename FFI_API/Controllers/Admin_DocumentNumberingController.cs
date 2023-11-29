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
    public class Admin_DocumentNumberingController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_DocumentNumberingController)); //Declaring Log4Net.
        Admin_DocumentNumberingService objRoleService = new Admin_DocumentNumberingService();
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public Admin_DocumentNumberingController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpGet("alldoc_num")]
        public DCNumberList DocNumberList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue)
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
           
            DCNumberList ObjList = new DCNumberList();
            try
            {
                ObjList = objRoleService.DocNumberList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [HttpGet("doc_num")]
        public FetchDocNumber FetchDocNum(string org, string locn, string user, string lang,string activity_code,string finyear_code, int docnum_rowid)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(activity_code);
            objArr.Add(finyear_code);
            objArr.Add(docnum_rowid);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            FetchDocNumber ObjFetch = new FetchDocNumber();
            try
            {
                ObjFetch = objRoleService.FetchDocNum(org, locn, user, lang, activity_code, finyear_code, docnum_rowid,ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        [HttpPost("newdocnum")]
        public OutputDoc SaveDC(SaveDocNum objFin)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objFin, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objFin.document.context.locnId, this.appSettings.Value);
            OutputDoc ObjFetch = new OutputDoc();
            try
            {
                ObjFetch = objRoleService.SaveDC(objFin, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objFin.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }
    }
}
