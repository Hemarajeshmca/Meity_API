using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FFI_DataModel;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FDRFpoRegController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        string methodName = "";
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FDRFpoRegController)); //Declaring Log4Net.    
        FDRFpoReg_Service objRoleService = new FDRFpoReg_Service();
        public FDRFpoRegController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpGet("allfpo_reg")]
        public RootObjectlist GetFPOList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue)
        {
            ParameterInfo[] parameters = MethodBase.GetCurrentMethod().GetParameters();
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(filterby_option);
            objArr.Add(filterby_code);
            objArr.Add(filterby_fromvalue);
            objArr.Add(filterby_tovalue);
            LogHelper.ConvertPropertiesIntoString(parameters, objArr);

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            methodName = MethodBase.GetCurrentMethod().Name;
            RootObjectlist objList = new RootObjectlist();
            try
            {
                objList = objRoleService.AllFPOList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
                LogHelper.ConvertObjIntoString(objList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objList;
        }

        [HttpGet("Fpo_reg_orgn")]
        public RootObjectFetch FetchFPO(string org, string locn, string user, string lang, int orgn_rowid, string orgn_code, int version_no)
        {
            ParameterInfo[] parameters = MethodBase.GetCurrentMethod().GetParameters();
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(orgn_rowid);
            objArr.Add(orgn_code);
            objArr.Add(version_no);
            LogHelper.ConvertPropertiesIntoString(parameters, objArr);
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            methodName = MethodBase.GetCurrentMethod().Name;
            RootObjectFetch ObjRootList = new RootObjectFetch();
            try
            {
                ObjRootList = objRoleService.FetchFPO(org, locn, user, lang, orgn_rowid, orgn_code, version_no, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjRootList;
        }

        [HttpPost("newfporeg")]
        public FPODocument SaveFPOList(FPORootObject objFP)
        {
            LogHelper.ConvertObjIntoString(objFP, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objFP.document.context.locnId, this.appSettings.Value);

            methodName = MethodBase.GetCurrentMethod().Name;
            FPODocument objOutFp = new FPODocument();
            try
            {
                objOutFp = objRoleService.SaveFPOReg(objFP, ConString);
                LogHelper.ConvertObjIntoString(objOutFp, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objFP.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objOutFp;
        }

    }
}