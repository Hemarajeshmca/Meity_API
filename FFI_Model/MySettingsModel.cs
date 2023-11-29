using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FFI_Model
{
    public class MySettingsModel
    {
        public string ODmysqlcon { get; set; }
        public string UPmysqlcon { get; set; }
        public string BHmysqlcon { get; set; }
        public string TNmysqlcon { get; set; }
        public string JUmysqlcon { get; set; }

        public string mysqlcon { get; set; }


    }


   
}
