using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_FDR_FListController : ControllerBase
    {

        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_FListController)); //Declaring Log4Net.       

        public Mobile_FDR_FListController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("FarmerList")]
        public FDRFarmerRootObject GetFarmerList(FDRFarmerContext objfarmer)
        {
            string db = objfarmer.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            FDRFarmerRootObject ObjList = new FDRFarmerRootObject();
            try
            {
                ObjList = Mobile_FDR_FList_srv.GetAllFarmerList_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("mobFarmerSinglefetch")]
        public FDRRootObject GetmobFarmerSinglefetch(FDRContext objfarmer)
        {
            string db = objfarmer.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            FDRRootObject ObjList = new FDRRootObject();
            try
            {
                ObjList = Mobile_FDR_FList_srv.GetmobFarmerSinglefetch_srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
    }
}