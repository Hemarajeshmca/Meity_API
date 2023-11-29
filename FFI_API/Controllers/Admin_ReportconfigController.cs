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
    public class Admin_ReportconfigController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_FinancialYearController)); //Declaring Log4Net.
        Admin_ReportconfigService objRoleService = new Admin_ReportconfigService();
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public Admin_ReportconfigController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpGet("allreport")]
        public ReportconfigList ReportconfigList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue)
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
            
            ReportconfigList ObjList = new ReportconfigList();
            try
            {
                ObjList = objRoleService.ReportconfigList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [HttpGet("report_config")]
        public FetchRC FetchReportConfig(string org, string locn, string user, string lang, int report_rowid)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(report_rowid);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            FetchRC ObjFetch = new FetchRC();
            try
            {
                ObjFetch = objRoleService.FetchReportConfig(org, locn, user, lang, report_rowid, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        [HttpPost("newreportsconfig")]
        public OutReportConfig SaveReport(SaveReportConfig objRC)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objRC, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objRC.document.context.locnId, this.appSettings.Value);
            OutReportConfig ObjFetch = new OutReportConfig();
            try
            {
                ObjFetch = objRoleService.SaveReport(objRC, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objRC.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }
    }
}
