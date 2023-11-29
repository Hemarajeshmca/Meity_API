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
    public class FarmerRegController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        string methodName = "";
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FarmerRegController)); //Declaring Log4Net.       

        public FarmerRegController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        //public IEnumerable<string> GetEmployee()
        //{
        //    ConString = appSettings.Value.mysqlcon;
        //    return new string[] { "Murali", "Raja", "Shiva" };
        // SFarmerRootObject user = new SFarmerRootObject();
        //var re = Request;
        //var headers = re.Headers;
        //List<SFarmerKycSegment> listFarmerKycSegment = new List<SFarmerKycSegment>();
        //List<SFarmerBankSegment> listFarmerBankSegment = new List<SFarmerBankSegment>();
        //dynamic jsonData = ObjModel;
        //SFarmerRootObject orderJson = jsonData.order;
        //JArray SFarmerKycSegmentJson = jsonData.SFarmerKycSegment;
        //var Order = orderJson.ToObject<Order>();
        //Stream data = this.Request.Content.ReadAsStreamAsync().Result;
        //StreamReader reader = new StreamReader(data);
        //string post_data = reader.ReadToEnd();
        //user = (SFarmerContext)JsonConvert.DeserializeObject(post_data, ObjModel.GetType());
        //}

        [HttpPost("new_farmer_qrcode")]
        public string new_farmer_qr(FarmerQrContext ObjModel)
        {

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            string Qrcode = "";
            SFarmerDocument Objresult = new SFarmerDocument();


            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(ObjModel.FarmerCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);


            // Byte[] Qrcode = BitmapToBytesCode(qrCodeImage);
            //return Qrcode(BitmapToBytesCode(qrCodeImage));

            //SetLog4NetConfiguration();
            // Objresult = FarmerReg_Service.SaveFarmerReg(ObjModel, ConString);

            using (MemoryStream stream = new MemoryStream())
            {
                qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                return Convert.ToBase64String(stream.ToArray());
                //stream.ToArray();
            }
        }

        //[NonAction]
        //private static Byte[] BitmapToBytesCode(Bitmap image)
        //{
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

        //       return stream.ToArray();
        //    }
        //}

        [HttpPost("new_farmer_reg")]
        public SFarmerDocument new_farmer_reg(SFarmerRootObject ObjModel)
        {
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            methodName = MethodBase.GetCurrentMethod().Name;
            string[] response = { };
            SFarmerDocument Objresult = new SFarmerDocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = FarmerReg_Service.SaveFarmerReg(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return Objresult;
        }
        [HttpPost("allfarmer_reg")]
        public FarmerRootObject allfarmer_reg(FarmerContext objfarmer)
        {
            LogHelper.ConvertObjIntoString(objfarmer, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            methodName = MethodBase.GetCurrentMethod().Name;
            FarmerRootObject ObjList = new FarmerRootObject();
            try
            {
                ObjList = FarmerReg_Service.GetAllFarmerDtls_Srv(objfarmer, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }
        [HttpPost("farmer_reg")]
        public FRootObject farmer_reg(FContext ObjContext)
        {
            LogHelper.ConvertObjIntoString(ObjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            methodName = MethodBase.GetCurrentMethod().Name;
            FRootObject ObjRootList = new FRootObject();
            try
            {
                ObjRootList = FarmerReg_Service.GetSingleFarmerDtls_Srv(ObjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjRootList;
        }
    }
}