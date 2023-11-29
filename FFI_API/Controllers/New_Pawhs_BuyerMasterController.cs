using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFI_DataModel;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static FFI_Model.New_Pawhs_BuyerMaster_Model;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class New_Pawhs_BuyerMasterController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(New_Pawhs_BuyerMasterController)); //Declaring Log4Net.       
                                                                                              // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public New_Pawhs_BuyerMasterController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("BuyerMaster_List")]
        public PawhsBuyerMasterApplication PawhsBuyerMaster_List(PawhsBuyerMasterContext objfarmer)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objfarmer, "Input");


            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            PawhsBuyerMasterApplication ObjList = new PawhsBuyerMasterApplication();
            try
            {
                ObjList = New_Pawhs_BuyerMaster_Service.PawhsBuyerMaster_List(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("BuyerMaster_SingleFetch")]
        public PawhsBuyerMasterFetchApplication PawhsBuyerMaster_SingleFetch(PawhsBuyerMasterFetchContext SobjContext)
        {

            //log Input information
            LogHelper.ConvertObjIntoString(SobjContext, "Input");


            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);

            PawhsBuyerMasterFetchApplication ObjList = new PawhsBuyerMasterFetchApplication();
            try
            {
                ObjList = New_Pawhs_BuyerMaster_Service.PawhsBuyerMaster_SingleFetch(SobjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + SobjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("newSaveBuyerMaster")]
        public SavebuyerDocument newSaveBuyerMaster(SavebuyerApplication ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            SavebuyerDocument Objresult = new SavebuyerDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = New_Pawhs_BuyerMaster_Service.SaveBuyerMaster_service(ObjModel, ConString);

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return Objresult;

        }

    }
}