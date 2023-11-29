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
    public class PAWHS_NewWareHouseReceiptController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_NewWareHouseReceiptController)); //Declaring Log4Net.    

        public PAWHS_NewWareHouseReceiptController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        //new_pa_whs_mst_product
        [HttpPost("pawhs_NewWareHouseReceipt_List")]
        public PAWHS_NewWareHouseReceipt_ALL_Application pawhs_NewWareHouseReceipt_List(PAWHS_NewWareHouseReceipt_ALL_Context objfarmer)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            PAWHS_NewWareHouseReceipt_ALL_Application ObjList = new PAWHS_NewWareHouseReceipt_ALL_Application();
            try
            {
                ObjList = PAWHS_NewWareHouseReceipt_service.pawhs_NewWareHouseReceipt_Lists(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }


        [HttpPost("pawhs_NewWareHouseReceipt_single")]
        public PAWHS_NewWareHouseReceipt_single_Application Single_pawhs_NewWareHouseReceipt(PAWHS_NewWareHouseReceipt_single_Context SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);

            PAWHS_NewWareHouseReceipt_single_Application ObjList = new PAWHS_NewWareHouseReceipt_single_Application();
            try
            {
                ObjList = PAWHS_NewWareHouseReceipt_service.Single_pawhs_NewWareHouseReceipt(SobjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("pawhs_NewWareHouseReceipt_save")]
        public PAWHS_NewWareHouseReceipt_SDocument save_pawhs_NewWareHouseReceipt(PAWHS_NewWareHouseReceipt_SApplication SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHS_NewWareHouseReceipt_SDocument Objresult = new PAWHS_NewWareHouseReceipt_SDocument();
            PAWHS_NewWareHouseReceipt_ApplicationException errordis = new PAWHS_NewWareHouseReceipt_ApplicationException();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHS_NewWareHouseReceipt_service.save_pawhs_NewWareHouseReceipt(SobjContext, ConString);

            }
            catch (Exception ex)
            {
                errordis.errorDescription = ex.Message.ToString();
                Objresult.ApplicationException = errordis;
                logger.Error(ex);
            }
            return Objresult;

        }
    }
}
