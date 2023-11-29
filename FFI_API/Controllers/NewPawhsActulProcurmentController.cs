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
    public class NewPawhsActulProcurmentController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(NewPawhsActulProcurmentController)); //Declaring Log4Net. 
        public NewPawhsActulProcurmentController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        //new_pa_whs_mst_product
        [HttpPost("new_pawhs_ActualProc_List")]
        public PAWHSActualProcurmentApplication ActualProcList(PAWHSActualProcurmentContext objfarmer)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            PAWHSActualProcurmentApplication ObjList = new PAWHSActualProcurmentApplication();
            try
            {
                ObjList = NewPawhsActualProc_Service.GetActualProcList(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("new_pawhs_Single_ActualProc")]
        public PAWHSActualProcurmentFetchApplication Single_ActualProc(PAWHSActualProcurment_FetchContext SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);

            PAWHSActualProcurmentFetchApplication ObjList = new PAWHSActualProcurmentFetchApplication();
            try
            {
                ObjList = NewPawhsActualProc_Service.Single_ActualPro(SobjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("new_pawhs_ActualProc_save")]
        public PAWHSActualProcurment_Save_Document newSaveActualProc(PAWHSActualProcurment_Save_Application SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSActualProcurment_Save_Document Objresult = new PAWHSActualProcurment_Save_Document();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = NewPawhsActualProc_Service.newSaveActualProcur(SobjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
        [HttpPost("Estimate_Actual_Approved_List")]
        public PAWHSEstimateActWRApplication Estimate_Actual_Approved(PAWHSEstimateActWRContext SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);

            PAWHSEstimateActWRApplication ObjList = new PAWHSEstimateActWRApplication();
            try
            {
                ObjList = NewPawhsActualProc_Service.Estimate_Actual_Approve_List(SobjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("ActualPro_Slno_List")]
        public PAWHSActualProcurmentSlnoFetchApplication ActualPro_Slno_details(PAWHSActualProcurment_SlnoFetchContext ObjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            PAWHSActualProcurmentSlnoFetchApplication ObjList = new PAWHSActualProcurmentSlnoFetchApplication();
            try
            {
                ObjList = NewPawhsActualProc_Service.Single_ActualPro_Slno(ObjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
    }
}