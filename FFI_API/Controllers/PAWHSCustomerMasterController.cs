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
    public class PAWHSCustomerMasterController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSCustomerMasterController)); //Declaring Log4Net.
        public PAWHSCustomerMasterController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allcustomer_master")]
        public PAWHSCustomerApplication allcustomer_master(Context ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            PAWHSCustomerApplication Objresult = new PAWHSCustomerApplication();
            try
            {
                Objresult = PAWHSCustomerMaster_Service.GetAllCustomerList(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }

        [HttpPost("customer_master")]
        public SingleApplication customer_master(SingleContext ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            SingleApplication Objresult = new SingleApplication();
            try
            {
                Objresult = PAWHSCustomerMaster_Service.GetSingleCustomerMasterList(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }

        [HttpPost("new_customer_master")]
        public DocumentCustomer new_customer_master(SaveApplication ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            DocumentCustomer Objresult = new DocumentCustomer();
            try
            {
                Objresult = PAWHSCustomerMaster_Service.SaveCustomerMasterList(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
    }
}