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
    public class PAWHS_NEW_BulkTransactionController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_NEW_BulkTransactionController)); //Declaring Log4Net.
        public PAWHS_NEW_BulkTransactionController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("new_pawhs_Bulk_save")]
        public string[] newSaveActualProc(PAWHS_NEW_BulkTrans_SApplication SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHS_NEW_BulkTransaction_service obj = new PAWHS_NEW_BulkTransaction_service();
            PAWHS_NEW_BulkTrans_SDocument Objresult = new PAWHS_NEW_BulkTrans_SDocument();
            try
            {
                //SetLog4NetConfiguration();
                response = obj.PAWHS_Offline_Save_Srv(SobjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return response;

        }
    }
}
