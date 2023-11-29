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
    public class PAWHS_NEW_Farmerlistcontroller : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_NEW_Farmerlistcontroller)); //Declaring Log4Net.    

        public PAWHS_NEW_Farmerlistcontroller(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        //new_pa_whs_mst_product
        [HttpPost("new_pawhs_Farmer_List")]
        public PAWHSFarmerRootObject new_pawhs_Farmer_List(PAWHSFarmerContext objfarmer)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            PAWHSFarmerRootObject ObjList = new PAWHSFarmerRootObject();
            try
            {
                ObjList = PAWHS_NEW_Farmerlist_SRV.GetAllFarmerList_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

    }
}
