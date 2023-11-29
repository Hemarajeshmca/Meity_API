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
    public class PAWHSProduceCalController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSProduceCalController)); //Declaring Log4Net.       

        public PAWHSProduceCalController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allproduce_calendar")]
        public PAWHSProduceCalApplication allproduce_calendar(PAWHSProduceCalContext objinvoice)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);

            PAWHSProduceCalApplication ObjList = new PAWHSProduceCalApplication();
            try
            {
                ObjList = PAWHSProduceCal_srv.Getallproduce_calendar_Srv(objinvoice, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("produce_calendar")]
        public PAWHSProduceCalFApplication produce_calendar(PAWHSProduceCalFContext ObjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            PAWHSProduceCalFApplication ObjRootList = new PAWHSProduceCalFApplication();
            try
            {
                ObjRootList = PAWHSProduceCal_srv.Getproduce_calendar_Srv(ObjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("new_produce_calendar")]
        public PAWHSProduceCalSDocument new_produce_calendar(PAWHSProduceCalSApplication ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSProduceCalSDocument Objresult = new PAWHSProduceCalSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSProduceCal_srv.Savenew_produce_calendar_srv(ObjModel, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
    }
}