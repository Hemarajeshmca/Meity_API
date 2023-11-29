using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FFI_Model;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace FFI_API.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class SendSMSController : ControllerBase
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSWarehouseReceiptController)); //Declaring Log4Net. 
       
        string senderid = "";
        string msg_desc = "";
        string mobile_no = "";

        private IConfiguration _configuration;
        public SendSMSController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string SMSURL = "";
        string APIKEY = "";

        [HttpPost("SendSMS")]
        public RootObject SendSMSASync(send_sms obj)
        {
            RootObject rp = new RootObject();
            try
            {

                SMSURL = _configuration.GetSection("SMS_URL")["sms_url"].ToString();
                APIKEY = _configuration.GetSection("API_KEY")["api_key"].ToString();
                send_sms objData = new send_sms();
                objData = (send_sms)obj;
                var wb = new System.Net.WebClient();
                string baseURL = SMSURL + "?APIKey=" + APIKEY + "&senderid=" + objData.senderid + "&channel=2&DCS=0&flashsms=0&number=" + objData.mobile_no + "&text=" + objData.msg_desc + "&route=1";
                Stream SS = wb.OpenRead(baseURL);
                StreamReader Reader = new StreamReader(SS);
                string Result1 = Reader.ReadToEnd();
                Reader.Close();
              
                rp = (RootObject)JsonConvert.DeserializeObject(Result1, rp.GetType());
                if (rp.ErrorCode == "000")
                {
                    string EM = rp.ErrorMessage;
                    string EC = rp.ErrorCode;
                  
                }
                else if (rp.ErrorCode != "000")
                {
                    string EM = rp.ErrorMessage;
                    string EC = rp.ErrorCode;
                }
              
            }
              
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return rp;
        }

    }
   
}