using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICDStockIssueController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDStockIssueController)); //Declaring Log4Net.
        ICDStockIssue_Service objRoleService = new ICDStockIssue_Service();
        public ICDStockIssueController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpGet("IssueList")]
        public ICDStockIssue_Model IssueTransferList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue,string issue_status)
        {
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ICDStockIssue_Model ObjFetch = new ICDStockIssue_Model();
            try
            {
                ObjFetch = objRoleService.IssueTransferList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, issue_status,ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjFetch;
        }
    }
}
