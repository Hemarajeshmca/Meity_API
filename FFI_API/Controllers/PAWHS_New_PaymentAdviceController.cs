using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FFI_Model;
using FFI_Service;
using Microsoft.Extensions.Options;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PAWHS_New_PaymentAdviceController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_New_PaymentAdviceController)); //Declaring Log4Net.    
        public PAWHS_New_PaymentAdviceController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }


        //List Start

        [HttpPost("pawhs_new_paymentadvice_list")]
        public PAWHS_New_PaymentAdvice_List_Application PAWHS_New_PaymentAdvice_All(PAWHS_New_PaymentAdvice_ALL_Context objPAWHSNewPaymentAdvicecontext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objPAWHSNewPaymentAdvicecontext.locnId, this.appSettings.Value);

            PAWHS_New_PaymentAdvice_List_Application ObjList = new PAWHS_New_PaymentAdvice_List_Application();
            try
            {
                ObjList = PAWHS_New_PaymentAdvice_Service.PAWHS_New_PaymentAdvice_All(objPAWHSNewPaymentAdvicecontext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        //End

        //Single Fetch 

        [HttpPost("PAWHS_New_PaymentAdvice_Single")]
        public PAWHS_New_PaymentAdvice_Single_FApplication PAWHS_New_PaymentAdvice_Single(PAWHS_New_PaymentAdvice_Single_FContext objPAWHSNewPaymentAdviceSingleContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objPAWHSNewPaymentAdviceSingleContext.locnId, this.appSettings.Value);

            PAWHS_New_PaymentAdvice_Single_FApplication ObjList = new PAWHS_New_PaymentAdvice_Single_FApplication();
            try
            {
                ObjList = PAWHS_New_PaymentAdvice_Service.PAWHS_New_PaymentAdvice_Single(objPAWHSNewPaymentAdviceSingleContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;

        }

        //End

        //Save And Update Start

        [HttpPost("PAWHS_New_PaymentAdvice_Save")]
        public PAWHS_New_PaymentAdvice_SDocument PAWHS_New_PaymentAdvice_Save(PAWHS_New_PaymentAdvice_SApplication objPAWHSNewPaymentAdviceSaveContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objPAWHSNewPaymentAdviceSaveContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHS_New_PaymentAdvice_SDocument Objresult = new PAWHS_New_PaymentAdvice_SDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHS_New_PaymentAdvice_Service.PAWHS_New_PaymentAdvice_Save(objPAWHSNewPaymentAdviceSaveContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }

        //End

        //start 
        [HttpPost("PAWHS_New_PaymentAdvice_Fetch_Gridvalue")]
        public PAWHS_New_PaymentAdvice_fetchgrid_FApplication PAWHS_New_PaymentAdvice_Fetch_Gridvalue(PAWHS_New_PaymentAdvice_fetchgrid_FContext objPAWHSNewPaymentAdviceSingleContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objPAWHSNewPaymentAdviceSingleContext.locnId, this.appSettings.Value);

            PAWHS_New_PaymentAdvice_fetchgrid_FApplication ObjList = new PAWHS_New_PaymentAdvice_fetchgrid_FApplication();
            try
            {
                ObjList = PAWHS_New_PaymentAdvice_Service.PAWHS_New_PaymentAdvice_Fetch_Gridvalue(objPAWHSNewPaymentAdviceSingleContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;

        }


        //End


    }
}
