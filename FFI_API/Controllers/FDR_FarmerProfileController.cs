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
    public class FDR_FarmerProfileController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FDR_FarmerProfileController));
        //Declaring Log4Net.
        FDR_FarmerProfileService objRoleService = new FDR_FarmerProfileService();
        string methodName = "";
        public FDR_FarmerProfileController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpGet("allfarmerpro")]
        public FarmerProfileList FarmerProfileList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, int from_index, int to_index, int record_count)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
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
            objArr.Add(from_index);
            objArr.Add(to_index);
            objArr.Add(record_count);
            LogHelper.ConvertPropertiesIntoString(parameters, objArr);
            FarmerProfileList objList = new FarmerProfileList();
            try
            {
                objList = objRoleService.FarmerProfileList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, from_index, to_index, record_count, ConString);
                LogHelper.ConvertObjIntoString(objList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objList;
        }

        [HttpGet("farmer_profile")]
        public FarmerProfileFetch FetchFarmerProfile(string org, string locn, string user, string lang, int farmer_rowid, string farmer_code, int version_no)
        {
            ParameterInfo[] parameters = MethodBase.GetCurrentMethod().GetParameters();
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(farmer_rowid);
            objArr.Add(farmer_code);
            objArr.Add(version_no);
            LogHelper.ConvertPropertiesIntoString(parameters, objArr);
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            methodName = MethodBase.GetCurrentMethod().Name;
            FarmerProfileFetch ObjRootList = new FarmerProfileFetch();
            try
            {
                ObjRootList = objRoleService.FetchFarmerProfile(org, locn, user, lang, farmer_rowid, farmer_code, version_no, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjRootList;
        }
        [HttpPost("newfarmerprofile")]
        public OutputFarmerProfile SaveFarmerProfile(SaveFarmerProfile objFP)
        {
            LogHelper.ConvertObjIntoString(objFP, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objFP.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            string jsonstring = "";
            OutputFarmerProfile objOutFp = new OutputFarmerProfile();
            try
            {
                if (objFP.document.context.Detail.Count > 1)
                {
                    jsonstring = JsonConvert.SerializeObject(objFP.document.context.Detail);
                }
                objOutFp = objRoleService.SaveFarmerProfile(objFP, jsonstring, ConString);
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
