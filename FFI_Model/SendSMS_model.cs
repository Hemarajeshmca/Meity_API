using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
  public  class SendSMS_model
    {
    }

    #region sendsms
    public class send_sms
    {
        public string senderid { get; set; }
        public string mobile_no { get; set; }
        public string msg_desc { get; set; }
      
    }
    #endregion

    public class RootObject
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        //public string JobId { get; set; }
        //public string MessageData { get; set; }
        public List<send_sms> send_sms { get; set; }
    }

}
