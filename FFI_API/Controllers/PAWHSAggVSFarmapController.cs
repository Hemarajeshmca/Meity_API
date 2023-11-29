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
    public class PAWHSAggVSFarmapController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSAggVSFarmapController)); //Declaring Log4Net.       

        public PAWHSAggVSFarmapController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allmapped_farmers")]
        public PAWHSAggVSFarmapApplication allmapped_farmers(PAWHSAggVSFarmapContext objinvoice)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);

            PAWHSAggVSFarmapApplication ObjList = new PAWHSAggVSFarmapApplication();
            try
            {
                ObjList = PAWHSAggVSFarmap_srv.Getallmapped_farmers_Srv(objinvoice, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("aggr_farmer_map")]
        public PAWHSAggVSFarmapFApplication FPOFarmer_map(PAWHSAggVSFarmapFContext ObjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            PAWHSAggVSFarmapFApplication ObjRootList = new PAWHSAggVSFarmapFApplication();
            try
            {
                ObjRootList = PAWHSAggVSFarmap_srv.Getaggr_farmer_map_Srv(ObjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("new_aggr_vs_farmer_mapping")]
        public PAWHSAggVSFarmapSDocument newFPOFarmerMap(PAWHSAggVSFarmapSApplication ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSAggVSFarmapSDocument Objresult = new PAWHSAggVSFarmapSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSAggVSFarmap_srv.Savenew_aggr_vs_farmer_mapping_srv(ObjModel, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
    }
}