using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;
using static FFI_Model.New_Pawhs_SaleEntryModel;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class New_PAWHS_SaleEntryController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(New_PAWHS_SaleEntryController)); //Declaring Log4Net. 
        public New_PAWHS_SaleEntryController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("New_Pawhs_SaleEntry_List")]
        public PAWHSSaleEntryApplication SaleEntryList(PAWHSSaleEntryContext objfarmer)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            PAWHSSaleEntryApplication ObjList = new PAWHSSaleEntryApplication();
            try
            {
                ObjList = NewPawhsSaleEntry_Service.GetSaleEntryList(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("New_Pawhs_Single_SaleEntry")]
        public PAWHS_SaleEntryFetchApplication Single_SaleEntry(PAWHS_SaleEntry_FetchContext SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);

            PAWHS_SaleEntryFetchApplication ObjList = new PAWHS_SaleEntryFetchApplication();
            try
            {
                ObjList = NewPawhsSaleEntry_Service.Single_SaleEntry(SobjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("New_Pawhs_SaleEntry_Save")]
        public PAWHSSalesEntry_Save_Document NewSaveSaleEntry(PAWHSSalesEntry_Save_Application SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSSalesEntry_Save_Document Objresult = new PAWHSSalesEntry_Save_Document();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = NewPawhsSaleEntry_Service.NewSaveSaleEntry(SobjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }

        [HttpPost("Pawhs_SaleEntry_checkdub")]
        public PAWHSSaleEntrydubContext Pawhs_SaleEntry_checkdub(PAWHSSaleEntrydubContext objfarmer)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.Instance, this.appSettings.Value);

            PAWHSSaleEntrydubContext ObjList = new PAWHSSaleEntrydubContext();
            try
            {
                ObjList = NewPawhsSaleEntry_Service.GetSaleEntrydubsrv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }


        [HttpPost("Pawhs_PurchaseEntry_checkdub")]
        public PAWHSpurEntrydubContext Pawhs_PurchaseEntry_checkdub(PAWHSpurEntrydubContext objfarmer)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.Instance, this.appSettings.Value);
            PAWHSpurEntrydubContext ObjList = new PAWHSpurEntrydubContext();
            try
            {
                ObjList = NewPawhsSaleEntry_Service.GetPurchaseEntrydubsrv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("Pawhs_sale_qty")]
        public PAWHSsaleqtyContext Pawhs_sale_qty(PAWHSsaleqtyContext objfarmer)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.Instance, this.appSettings.Value);
            PAWHSsaleqtyContext ObjList = new PAWHSsaleqtyContext();
            try
            {
                ObjList = NewPawhsSaleEntry_Service.Pawhs_sale_qty_srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
    }
}