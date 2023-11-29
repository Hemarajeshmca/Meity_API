using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFI_DataModel;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static FFI_Model.New_Pawhs_SaleEntryModel;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class New_Pawhs_Sale_EntryController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(New_Pawhs_Sale_EntryController)); //Declaring Log4Net.       
                                                                                                       // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public New_Pawhs_Sale_EntryController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("SaleEntry_List")]
        public PawhsBatSaleEntryApplication PawhsSaleEntry_List(PawhsSaleEntryContext objfarmer)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objfarmer, "Input");


            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            PawhsBatSaleEntryApplication ObjList = new PawhsBatSaleEntryApplication();
            try
            {
                ObjList = New_Pawhs_SaleEntry_Service.PawhsSaleEntry_List(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("SaleEntry_SingleFetch")]
        public PAWHSSaleEntryFetchApplication PawhsBatchCreationLotNo_Single(PAWHSSaleEntry_FetchContext objfarmer)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objfarmer, "Input");


            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            PAWHSSaleEntryFetchApplication ObjList = new PAWHSSaleEntryFetchApplication();
            try
            {
                ObjList = New_Pawhs_SaleEntry_Service.PawhsSaleEntry_SingleFetch(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("new_pawhs_SaleEntry_save")]
        public PAWHSSaleEntry_Save_Document newSaveActualProc(PAWHSSaleEntry_Save_Application SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSSaleEntry_Save_Document Objresult = new PAWHSSaleEntry_Save_Document();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = New_Pawhs_SaleEntry_Service.newSaveSaleEntry(SobjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
    }
}
