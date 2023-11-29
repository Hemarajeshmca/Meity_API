using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;
using FFI_DataModel;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PAWHS_New_AggregatorController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_New_AggregatorController)); //Declaring Log4Net.    
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //Endz
        public PAWHS_New_AggregatorController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        //new_pa_whs_mst_product
        [HttpPost("new_pawhs_aggregator_List")]
        public New_PAWHSAggregator_all_Application new_pawhs_aggregator_List(New_PAWHSAggregator_all_Context objfarmer)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objfarmer, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            New_PAWHSAggregator_all_Application ObjList = new New_PAWHSAggregator_all_Application();
            try
            {
                ObjList = PAWHS_New_Aggregator_service.GetAllpawhs_aggregator_List(objfarmer, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [HttpPost("new_pawhs_aggregator_single")]
        public New_PAWHSAggregator_single_Application Single_new_pawhs_aggregator(New_PAWHSAggregator_single_Context SobjContext)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(SobjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);

            New_PAWHSAggregator_single_Application ObjList = new New_PAWHSAggregator_single_Application();
            try
            {
                ObjList = PAWHS_New_Aggregator_service.Single_new_pawhs_aggregator(SobjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + SobjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [HttpPost("new_pawhs_aggregator_save")]
        public New_PAWHSAggregator_SDocument save_new_pawhs_aggregator(New_PAWHSAggregator_SApplication SobjContext)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(SobjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.document.context.userId, this.appSettings.Value);

            string[] response = { };
            New_PAWHSAggregator_SDocument Objresult = new New_PAWHSAggregator_SDocument();
            try
            {
                Objresult = PAWHS_New_Aggregator_service.save_new_pawhs_aggregator(SobjContext, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + SobjContext.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return Objresult;

        }
    }
}
