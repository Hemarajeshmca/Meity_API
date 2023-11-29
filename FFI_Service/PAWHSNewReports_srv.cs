using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class PAWHSNewReports_srv
    {
        PAWHSNewReports_DB ObjpawhsDataModel = new PAWHSNewReports_DB();

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDData_Service));
        public DataTable GetPAPurchaseList_srv(pareportsInputParams objparam,string orgn_code, string constring)
        {
            DataTable dtpapurchaseList = new DataTable();
            try
            {
                DataSet ds = ObjpawhsDataModel.GetPAPurchaseList_db(objparam, orgn_code, constring);
                dtpapurchaseList = ds.Tables[0];
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return dtpapurchaseList;
        }
        public DataTable GetPASaleList_srv(pareportsInputParams objparam, string orgn_code, string constring)
        {
            DataTable dtpapurchaseList = new DataTable();
            try
            {
                DataSet ds = ObjpawhsDataModel.GetPASaleList_db(objparam, orgn_code, constring);
                dtpapurchaseList = ds.Tables[0];
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return dtpapurchaseList;
        }
    }
}
