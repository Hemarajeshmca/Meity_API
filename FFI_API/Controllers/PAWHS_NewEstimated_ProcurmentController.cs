using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PAWHS_NewEstimated_ProcurmentController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_NewEstimated_ProcurmentController)); //Declaring Log4Net.    

        public PAWHS_NewEstimated_ProcurmentController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        //new_pa_whs_mst_product
        [HttpPost("pawhs_NewEstimated_Procurment_List")]
        public pawhs_NewEstimate_Proc_ALL_Application pawhs_NewEstimated_Procurment_List(pawhs_NewEstimate_Proc_ALL_Context objfarmer)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            pawhs_NewEstimate_Proc_ALL_Application ObjList = new pawhs_NewEstimate_Proc_ALL_Application();
            try
            {
                ObjList = PAWHS_NewEstimated_Procurment_service.pawhs_NewEstimated_Procurment_List(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("pawhs_NewEstimate_Proc_single")]
        public pawhs_NewEstimate_Proc_single_Application Single_pawhs_NewEstimate_Proc(pawhs_NewEstimate_Proc_single_Context SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);

            pawhs_NewEstimate_Proc_single_Application ObjList = new pawhs_NewEstimate_Proc_single_Application();
            try
            {
                ObjList = PAWHS_NewEstimated_Procurment_service.Single_pawhs_NewEstimate_Proc(SobjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("pawhs_NewEstimate_Proc_save")]
        public pawhs_NewEstimate_Proc_SDocument save_pawhs_NewEstimate_Procurement(pawhs_NewEstimate_Proc_SApplication SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            pawhs_NewEstimate_Proc_SDocument Objresult = new pawhs_NewEstimate_Proc_SDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHS_NewEstimated_Procurment_service.save_pawhs_NewEstimate_Procurement(SobjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
    }
}
