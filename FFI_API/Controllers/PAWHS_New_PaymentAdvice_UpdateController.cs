using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FFI_Model;
using FFI_Service;
using Microsoft.Extensions.Options;
namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PAWHS_New_PaymentAdvice_UpdateController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_New_PaymentAdvice_UpdateController)); //Declaring Log4Net.    
        public PAWHS_New_PaymentAdvice_UpdateController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("PAWHS_New_PaymentAdvice_Update_List")]
        public PAWHS_New_PaymentAdvice_UpdateApplication all_pawhs_payment_update(PAWHS_New_PaymentAdvice_UpdateContext objpawhsnewpaymentupdateContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objpawhsnewpaymentupdateContext.locnId, this.appSettings.Value);

            PAWHS_New_PaymentAdvice_UpdateApplication ObjList = new PAWHS_New_PaymentAdvice_UpdateApplication();
            try
            {
                ObjList = PAWHS_New_PaymentAdvice_Update_Service.all_pawhs_payment_update(objpawhsnewpaymentupdateContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        //End 

        //start 

        [HttpPost("PAWHS_New_PaymentAdvice_Update_Save")]
        public PAWHS_New_PaymentAdvice_UpdateSDocument new_pawhs_payment_update(PAWHS_New_PaymentAdvice_UpdateSApplication SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHS_New_PaymentAdvice_UpdateSDocument Objresult = new PAWHS_New_PaymentAdvice_UpdateSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHS_New_PaymentAdvice_Update_Service.new_pawhs_payment_update(SobjICDStockAdjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
        //End

    }
}
