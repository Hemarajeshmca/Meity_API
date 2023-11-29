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
    public class Admin_AttributeGroupController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_AttributeGroupController)); //Declaring Log4Net.
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        Admin_AttributeGroupService objRoleService = new Admin_AttributeGroupService();
        public Admin_AttributeGroupController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpGet("all_attribute")]
        public AttributeGroupList AttributeGroupList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue)
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
            
            AttributeGroupList ObjList = new AttributeGroupList();
            try
            {
                ObjList = objRoleService.AttributeGroupList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [HttpGet("attr_group")]
        public FetchAttributeGroup FetchAttributeGroup(string org, string locn, string user, string lang, int entitygrp_rowid, string entitygrp_code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(entitygrp_rowid);
            objArr.Add(entitygrp_code);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            FetchAttributeGroup ObjFetch = new FetchAttributeGroup();
            try
            {
                ObjFetch = objRoleService.FetchAttributeGroup(org, locn, user, lang, entitygrp_rowid, entitygrp_code, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        [HttpPost("newattributegroup")]
        public OutputAG SaveAttributeGroup(SaveAG objAG)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objAG, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objAG.document.context.locnId, this.appSettings.Value);
            OutputAG ObjFetch = new OutputAG();
            try
            {
                ObjFetch = objRoleService.SaveAttributeGroup(objAG, ConString);
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
