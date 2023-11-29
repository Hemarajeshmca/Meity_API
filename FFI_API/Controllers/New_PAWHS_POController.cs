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
    public class New_PAWHS_POController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        string methodName = "";
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(New_PAWHS_POController)); //Declaring Log4Net.       

        public New_PAWHS_POController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("allpo_list")]
        public PORootObject AllPo_list(POContext objfarmer)
        {
            LogHelper.ConvertObjIntoString(objfarmer, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            methodName = MethodBase.GetCurrentMethod().Name;
            PORootObject ObjList = new PORootObject();
            try
            {
                ObjList = New_PAWHS_PO_Service.GetAllPODtls_Srv(objfarmer, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [HttpPost("new_pawhs_PO_save")]
        public PAWHSPO_Save_Document NewPawhsPOSave(PAWHSPO_Save_Application SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;           
            PAWHSPO_Save_Document Objresult = new PAWHSPO_Save_Document();
            try
            {
                Objresult = New_PAWHS_PO_Service.NewPAWHSPODetail(SobjContext, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
        [HttpPost("new_pawhs_Single_FetchPO")]
        public PAWHSPOFetchApplication Single_FetchPO(PAWHSPO_FetchContext SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);

            PAWHSPOFetchApplication ObjList = new PAWHSPOFetchApplication();
            try
            {
                ObjList = New_PAWHS_PO_Service.Single_POFetch(SobjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("shipmentfetch")]
        public PAWHSPurchaseOrderShipment Getshipmentfetch(PAWHSPurchaseOrderShipmentContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSPurchaseOrderShipment ObjList = new PAWHSPurchaseOrderShipment();
            try
            {
                ObjList = New_PAWHS_PO_Service.Getshipmentfetch_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

    }
}