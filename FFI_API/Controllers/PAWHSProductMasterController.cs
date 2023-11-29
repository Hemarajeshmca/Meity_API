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
    public class PAWHSProductMasterController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSProductMasterController)); //Declaring Log4Net.    

        public PAWHSProductMasterController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        //new_pa_whs_mst_product
        [HttpPost("new_pawhs_ProductMaster_allproduct")]
        public PAWHSProductmasterApplication allproduct(PAWHSProductmasterContext objfarmer)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            PAWHSProductmasterApplication ObjList = new PAWHSProductmasterApplication();
            try
            {
                ObjList = PAWHSProductmaster_service.GetAllProductMasterList(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("new_pawhs_Single_ProductMaster")]
        public PAWHSProductmasterFApplication Single_ProductMaster(PAWHSProductmasterFContext SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);

            PAWHSProductmasterFApplication ObjList = new PAWHSProductmasterFApplication();
            try
            {
                ObjList = PAWHSProductmaster_service.Single_ProductMaster(SobjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }


        [HttpPost("new_pawhs_Product_Master_save")]
        public PAWHSProductmasterSDocument newSaveProductMaster(PAWHSProductmasterSApplication SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSProductmasterSDocument Objresult = new PAWHSProductmasterSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSProductmaster_service.newSaveProductMaster(SobjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
    }
}
