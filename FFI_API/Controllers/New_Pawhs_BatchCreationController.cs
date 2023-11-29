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
using static FFI_Model.New_Pawhs_BatchCreation_Model;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class New_Pawhs_BatchCreationController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(New_Pawhs_BatchCreationController)); //Declaring Log4Net.       
                                                                                                     // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public New_Pawhs_BatchCreationController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("BatchCreation_List")]
        public PawhsBatchCreationApplication PawhsBatchCreation_List(PawhsBatchCreationContext objfarmer)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objfarmer, "Input");


            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            PawhsBatchCreationApplication ObjList = new PawhsBatchCreationApplication();
            try
            {
                ObjList = New_Pawhs_BatchCreation_Service.PawhsBatchCreation_List(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("BatchCreationLotNo_List")]
        public PawhsBatchCreationLotApplication PawhsBatchCreationLotNo_List(PawhsBatchCreationLotContext objfarmer)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objfarmer, "Input");


            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            PawhsBatchCreationLotApplication ObjList = new PawhsBatchCreationLotApplication();
            try
            {
                ObjList = New_Pawhs_BatchCreation_Service.PawhsBatchCreationLotNo_List(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("New_pawhs_BatchCreation_save")]
        public PAWHSBatchCreation_Save_Document NewSaveBatchCreation(PAWHSBatchCreation_Save_Application SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.document.context.locnId, this.appSettings.Value);
          
            PAWHSBatchCreation_Save_Document Objresult = new PAWHSBatchCreation_Save_Document();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = New_Pawhs_BatchCreation_Service.NewSaveBatchCreation(SobjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
        [HttpPost("BatchCreationLotNo_Single")]
        public PAWHSBatchCreationFetchApplication PawhsBatchCreationLotNo_Single(PAWHSBatchCreation_FetchContext objfarmer)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objfarmer, "Input");


            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            PAWHSBatchCreationFetchApplication ObjList = new PAWHSBatchCreationFetchApplication();
            try
            {
                ObjList = New_Pawhs_BatchCreation_Service.Single_PawhsBatchCreationLotNo_List(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return ObjList;
        }
    }
}
