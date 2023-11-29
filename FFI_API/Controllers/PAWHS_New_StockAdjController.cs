using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using log4net;
using log4net.Config;
using System.Reflection;
using log4net.Repository.Hierarchy;
using System.Xml;
using QRCoder;
using System.Drawing;
using FFI_DataModel;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PAWHS_New_StockAdjController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        string methodName = "";
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_New_StockAdjController)); //Declaring Log4Net.  
        public PAWHS_New_StockAdjController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allstock_list")]
        public StockRootObject Allstock_list(StockContext ObjModel)
        {
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            methodName = MethodBase.GetCurrentMethod().Name;
            StockRootObject ObjList = new StockRootObject();
            try
            {
                ObjList = PAWHS_New_StockAdj_Service.GetAllStockDtls_Srv(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [HttpPost("new_pawhs_Stock_save")]
        public PAWHSStock_Save_Document NewPawhsStockSave(PAWHSStock_Save_Application SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            PAWHSStock_Save_Document Objresult = new PAWHSStock_Save_Document();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHS_New_StockAdj_Service.NewPAWHSStockDetail(SobjContext, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("new_pawhs_Single_FetchStock")]
        public PAWHSStockFetchApplication Single_FetchStock(PAWHSStock_FetchContext SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);

            PAWHSStockFetchApplication ObjList = new PAWHSStockFetchApplication();
            try
            {
                ObjList = PAWHS_New_StockAdj_Service.Single_StockFetch(SobjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
    }
}