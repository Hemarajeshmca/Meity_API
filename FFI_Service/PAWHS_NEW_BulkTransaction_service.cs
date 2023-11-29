using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class PAWHS_NEW_BulkTransaction_service
    {
        public string[]  PAWHS_Offline_Save_Srv(PAWHS_NEW_BulkTrans_SApplication objPropfileDetails, string Mysql)
        {
            PAWHS_NEW_BulkTrans_SDocument objOut = new PAWHS_NEW_BulkTrans_SDocument();
            string[] objlot = new string[objPropfileDetails.document.context.Esitmated_Prod.Count];
            string[] objWHS = new string[objPropfileDetails.document.context.NewWareHouseReceipt.Count];
            try
            {
                PAWHS_NEW_BulkTrans_DB objConnection = new PAWHS_NEW_BulkTrans_DB();               
                    if (objPropfileDetails.document.context.Esitmated_Prod != null)
                    {
                        for (int i = 0; i < objPropfileDetails.document.context.Esitmated_Prod.Count; i++)
                        {
                        objlot[i] = objConnection.Pawhs_bulk_Estimateprod_Save(objPropfileDetails.document.context.Esitmated_Prod[i], objPropfileDetails.document.context.orgnId, objPropfileDetails.document.context.locnId, objPropfileDetails.document.context.userId, objPropfileDetails.document.context.localeId,Mysql);
                        }
                    }
                if (objPropfileDetails.document.context.Actual_Procurment != null)
                {
                    for (int j = 0; j < objPropfileDetails.document.context.Actual_Procurment.Count; j++)
                    {
                        objConnection.Pawhs_bulk_newSaveActualProcurment(objPropfileDetails.document.context.Actual_Procurment[j], objPropfileDetails.document.context.orgnId, objPropfileDetails.document.context.locnId, objPropfileDetails.document.context.userId, objPropfileDetails.document.context.localeId, Mysql);
                    }
                }
                if (objPropfileDetails.document.context.NewWareHouseReceipt != null)
                {
                    for (int k = 0; k < objPropfileDetails.document.context.NewWareHouseReceipt.Count; k++)
                    {
                        objWHS[k] = objConnection.Pawhs_bulk_newSaveNewWareHouseReceipt(objPropfileDetails.document.context.NewWareHouseReceipt[k], objPropfileDetails.document.context.orgnId, objPropfileDetails.document.context.locnId, objPropfileDetails.document.context.userId, objPropfileDetails.document.context.localeId, Mysql);
                    }
                }             
                return objlot;

            }
            catch (Exception ex)
            {

            }
            return objlot;
        }
    }
}
