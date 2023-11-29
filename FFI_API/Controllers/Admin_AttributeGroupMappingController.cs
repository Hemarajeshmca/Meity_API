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
    public class Admin_AttributeGroupMappingController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_AttributeGroupMappingController)); //Declaring Log4Net.
        Admin_AttributeGroupMappingService objRoleService = new Admin_AttributeGroupMappingService();
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public Admin_AttributeGroupMappingController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpGet("all_attribute_activity")]
        public AttributeGroupMappingList AttributeGroupMappingList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue)
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
           
            AttributeGroupMappingList ObjList = new AttributeGroupMappingList();
            try
            {
                ObjList = objRoleService.AttributeGroupMappingList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [HttpGet("attr_grp_activity")]
        public FtchAttributeGroupMapping FetchAttributeGroupMapping(string org, string locn, string user, string lang,string activity_code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(activity_code);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            FtchAttributeGroupMapping ObjFetch =new FtchAttributeGroupMapping();
            try
            {
                ObjFetch = objRoleService.FetchAttributeGroupMapping(org, locn, user, lang, activity_code, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        [HttpPost("newattrgroupactivity")]
        public OutputAGM SaveAttributeGroupMapping(SaveAttributeGroupMapping objAG)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objAG, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objAG.document.context.locnId, this.appSettings.Value);
            OutputAGM ObjFetch = new OutputAGM();
            try
            {
                ObjFetch = objRoleService.SaveAttributeGroupMapping(objAG, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objAG.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }
    }
}
