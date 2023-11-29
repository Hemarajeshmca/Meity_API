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
    public class PAWHSStockAdjController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSStockAdjController)); //Declaring Log4Net.       
        public PAWHSStockAdjController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allstock_adjustment")]
        public PAWHSStockAdjApplication allstock_adjustment(PAWHSStockAdjContext objICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSStockAdjApplication ObjList = new PAWHSStockAdjApplication();
            try
            {
                ObjList = PAWHSStockAdj_srv.Getallstock_adjustment_Srv(objICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("stock_adjustment")]
        public PAWHSStockAdjFApplication Getstock_adjustment(PAWHSStockAdjFContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSStockAdjFApplication ObjList = new PAWHSStockAdjFApplication();
            try
            {
                ObjList = PAWHSStockAdj_srv.Getstock_adjustment_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }


        [HttpPost("new_pawhs_stock_adjustment")]
        public PAWHSStockAdjSDocument newSaveStockAdjustment(PAWHSStockAdjSApplication SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSStockAdjSDocument Objresult = new PAWHSStockAdjSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSStockAdj_srv.SavenewSaveStockAdjustment_srv(SobjICDStockAdjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }

    }
}