using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;

namespace FFI_Service
{
    public class NewPawhsSaleEntry_Service
    {
        public static PAWHSSaleEntryApplication GetSaleEntryList(PAWHSSaleEntryContext ObjContext, string Mysql)
        {
            PAWHSSaleEntryApplication ObjFetchAll = new PAWHSSaleEntryApplication();
            NewPawhsSaleEntry_DB objDataModel = new NewPawhsSaleEntry_DB();
            try
            {
                ObjFetchAll = objDataModel.GetSaleEntryList(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static PAWHS_SaleEntryFetchApplication Single_SaleEntry(PAWHS_SaleEntry_FetchContext objfarmer, string Mysql)
        {
            PAWHS_SaleEntryFetchApplication ObjFarmerRoot = new PAWHS_SaleEntryFetchApplication();
            NewPawhsSaleEntry_DB objDataModel = new NewPawhsSaleEntry_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Single_SaleEntry(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSSalesEntry_Save_Document NewSaveSaleEntry(PAWHSSalesEntry_Save_Application objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSSalesEntry_Save_Document objfarmer = new PAWHSSalesEntry_Save_Document();
            try
            {
                NewPawhsSaleEntry_DB objDataModel = new NewPawhsSaleEntry_DB();
                objfarmer = objDataModel.NewSaveSaleEntry(objmodel, MysqlCon);
                return objfarmer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static PAWHSSaleEntrydubContext GetSaleEntrydubsrv(PAWHSSaleEntrydubContext ObjContext, string Mysql)
        {
            PAWHSSaleEntrydubContext ObjFetchAll = new PAWHSSaleEntrydubContext();
            ObjFetchAll.List = new List<PAWHSSaleEntrydub>();
            NewPawhsSaleEntry_DB objDataModel = new NewPawhsSaleEntry_DB();
            try
            {
                for (int i = 0; i < ObjContext.List.Count; i++)
                {
                    string dubserialno = objDataModel.GetSaleEntrydub(ObjContext.List[i].serial_no, ObjContext.sale_no, Mysql);
                    if (dubserialno != "")
                    {
                        PAWHSSaleEntrydub objdub = new PAWHSSaleEntrydub();
                        objdub.err_serial_no = dubserialno;
                        objdub.serial_no = "";
                        ObjFetchAll.Instance = "";
                        ObjFetchAll.List.Add(objdub);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static PAWHSpurEntrydubContext GetPurchaseEntrydubsrv(PAWHSpurEntrydubContext ObjContext, string Mysql)
        {
            string dubserialno = "";
            PAWHSpurEntrydubContext ObjFetchAll = new PAWHSpurEntrydubContext();
            ObjFetchAll.List = new List<PAWHSpurEntrydub>();
            NewPawhsSaleEntry_DB objDataModel = new NewPawhsSaleEntry_DB();
            try
            {
                for (int i = 0; i < ObjContext.List.Count; i++)
               {
                       dubserialno = objDataModel.GetPurchaseEntrydub(ObjContext.List[i].serial_no, ObjContext.purchase_no, Mysql);
                        if (dubserialno != "")
                        {
                            PAWHSpurEntrydub objdub = new PAWHSpurEntrydub();
                            objdub.err_serial_no = dubserialno;
                            objdub.serial_no = "";
                            ObjFetchAll.Instance = "";
                            ObjFetchAll.List.Add(objdub);
                        }
               }                  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }

        public static PAWHSsaleqtyContext Pawhs_sale_qty_srv(PAWHSsaleqtyContext ObjContext, string Mysql)
        {            
            PAWHSsaleqtyContext ObjFetchAll = new PAWHSsaleqtyContext();
            NewPawhsSaleEntry_DB objDataModel = new NewPawhsSaleEntry_DB();
            try
            {
                ObjFetchAll = objDataModel.Pawhs_sale_qty_db(ObjContext, Mysql);               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
    }
}
