using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PAWHSPaymentdetailsupdateController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSPaymentdetailsupdateController)); //Declaring Log4Net.    
        public PAWHSPaymentdetailsupdateController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("pawhs_payment_update")]
        public PAWHSPaydtlupdateApplication all_pawhs_payment_update(PAWHSPaydtlupdateContext objICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSPaydtlupdateApplication ObjList = new PAWHSPaydtlupdateApplication();
            try
            {
                ObjList = PAWHSPaydtlupdate_service.all_pawhs_payment_update(objICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("new_pawhs_payment_update")]
        public PAWHSPaydtlupdateSDocument new_pawhs_payment_update(PAWHSPaydtlupdateSApplication SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSPaydtlupdateSDocument Objresult = new PAWHSPaydtlupdateSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSPaydtlupdate_service.new_pawhs_payment_update(SobjICDStockAdjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
    }
}
