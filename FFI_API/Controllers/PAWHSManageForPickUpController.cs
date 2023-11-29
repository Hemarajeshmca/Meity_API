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
    public class PAWHSManageForPickUpController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSManageForPickUpController)); //Declaring Log4Net.       

        public PAWHSManageForPickUpController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allreadyto_pickup")]
        public PAWHSManageForPickUpApplication allreadyto_pickup(PAWHSManageForPickUpContext objinvoice)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);

            PAWHSManageForPickUpApplication ObjList = new PAWHSManageForPickUpApplication();
            try
            {
                ObjList = PAWHSManageForPickUp_srv.Getallreadyto_pickup_Srv(objinvoice, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("readyto_pickup")]
        public PAWHSManageForPickUpFApplication readyto_pickup(PAWHSManageForPickUpFContext ObjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            PAWHSManageForPickUpFApplication ObjRootList = new PAWHSManageForPickUpFApplication();
            try
            {
                ObjRootList = PAWHSManageForPickUp_srv.Getreadyto_pickup_Srv(ObjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("new_readyto_pickup")]
        public PAWHSManageForPickUpSDocument new_readyto_pickup(PAWHSManageForPickUpSApplication ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSManageForPickUpSDocument Objresult = new PAWHSManageForPickUpSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSManageForPickUp_srv.Savenew_readyto_pickup_srv(ObjModel, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
    }
}