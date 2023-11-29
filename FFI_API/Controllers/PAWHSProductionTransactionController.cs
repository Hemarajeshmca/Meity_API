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
    public class PAWHSProductionTransactionController : ControllerBase
    {

        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSProductionTransactionController)); //Declaring Log4Net.       

        public PAWHSProductionTransactionController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allproduction_transaction")]
        public PAWHSProductionTransactionApplication allproduction_transaction(PAWHSProductionTransactionContext objinvoice)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);

            PAWHSProductionTransactionApplication ObjList = new PAWHSProductionTransactionApplication();
            try
            {
                ObjList = PAWHSProductionTransaction_srv.Getallproduction_transaction_Srv(objinvoice, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("production_transaction")]
        public PAWHSProductionTransactionFApplication production_transaction(PAWHSProductionTransactionFContext ObjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            PAWHSProductionTransactionFApplication ObjRootList = new PAWHSProductionTransactionFApplication();
            try
            {
                ObjRootList = PAWHSProductionTransaction_srv.Getproduction_transaction_Srv(ObjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("new_production_transaction")]
        public PAWHSProductionTransactionSDocument new_production_transaction(PAWHSProductionTransactionSApplication ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSProductionTransactionSDocument Objresult = new PAWHSProductionTransactionSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSProductionTransaction_srv.Savenew_production_transaction_srv(ObjModel, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
    }
}