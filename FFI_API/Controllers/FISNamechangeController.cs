using System;
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

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FISNamechangeController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISNamechangeController)); //Declaring Log4Net.       
        string methodName = "";
        public FISNamechangeController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("allservice_request")]
        public FISNameChangeApplication allservice_request(FISNameChangeContext objfarmer)
        {
            LogHelper.ConvertObjIntoString(objfarmer, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            FISNameChangeApplication ObjList = new FISNameChangeApplication();
            try
            {
                ObjList = FISNamechange_srv.allservice_requestList_srv(objfarmer, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("service_req_name")]
        public FISNameChangeFApplication service_req_name(FISNameChangeFContext ObjContext)
        {
            LogHelper.ConvertObjIntoString(ObjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            FISNameChangeFApplication ObjRootList = new FISNameChangeFApplication();
            try
            {
                ObjRootList = FISNamechange_srv.Getservice_req_name_Srv(ObjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("service_req")]
        public FISNameChangeFNApplication service_req(FISNameChangeFNContext ObjContext)
        {
            LogHelper.ConvertObjIntoString(ObjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            FISNameChangeFNApplication ObjRootList = new FISNameChangeFNApplication();
            try
            {
                ObjRootList = FISNamechange_srv.Getservice_req_Srv(ObjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("newservicerequestname")]
        public FISNameChangeSDocument newservicerequestname(FISNameChangeSApplication ObjModel)
        {
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            string[] response = { };
            FISNameChangeSDocument Objresult = new FISNameChangeSDocument();
            try
            {
                Objresult = FISNamechange_srv.Savenewservicerequestname_Srv(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  logger.Error(ex);
            }
            return Objresult;
        }
        
        
    }
}