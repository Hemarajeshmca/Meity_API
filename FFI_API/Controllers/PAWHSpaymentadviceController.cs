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
    public class PAWHSpaymentadviceController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSpaymentadviceController)); //Declaring Log4Net.    
        public PAWHSpaymentadviceController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allpawhs_payment_advice")]
        public PAWHSpayadviceApplication all_pawhs_payment_update(PAWHSpayadviceContext objICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSpayadviceApplication ObjList = new PAWHSpayadviceApplication();
            try
            {
                ObjList = PAWHSpaymentadvice_service.allpawhs_payment_advice(objICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("pawhs_ser_aggregator_registration")]
        public PAWHSpaymentadvice_FApplication Gepayment_advice(PAWHSpaymentadvice_FContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSpaymentadvice_FApplication ObjList = new PAWHSpaymentadvice_FApplication();
            try
            {
                ObjList = PAWHSpaymentadvice_service.Gepayment_advice(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;

        }

        [HttpPost("new_pawhs_payment_advice")]
        public PAWHSpaymentadvice_SDocument new_pawhs_payment_advice(PAWHSpaymentadvice_SApplication SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSpaymentadvice_SDocument Objresult = new PAWHSpaymentadvice_SDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSpaymentadvice_service.new_pawhs_payment_advice(SobjICDStockAdjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
    }
}
