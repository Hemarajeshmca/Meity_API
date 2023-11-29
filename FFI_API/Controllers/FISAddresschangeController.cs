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
    public class FISAddresschangeController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISAddresschangeController)); //Declaring Log4Net.       
        string methodName = "";
        public FISAddresschangeController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        
        [HttpPost("service_req_address")]
        public FISAddressChangeApplication service_req_name(FISAddressChangeContext ObjContext)
        {
            LogHelper.ConvertObjIntoString(ObjContext, "Input");

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            FISAddressChangeApplication ObjRootList = new FISAddressChangeApplication();
            try
            {
                ObjRootList = FISAddresschange_srv.Getservice_req_address_Srv(ObjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjRootList;
        }
        
        [HttpPost("newServiceRequestAddress")]
        public FISAddressChangeSDocument newServiceRequestAddress(FISAddressChangeSApplication ObjModel)
        {

            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            string[] response = { };
            FISAddressChangeSDocument Objresult = new FISAddressChangeSDocument();
            try
            {
                Objresult = FISAddresschange_srv.SavenewServiceRequestAddress_Srv(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return Objresult;
        }


    }
}