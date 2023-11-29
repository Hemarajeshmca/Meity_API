using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class Mobile_FDR_Offlinesave_srv
    {
        string[] response = new string[4];
        public FarmerProfileOutput FarmerProfileSave_Srv(Mobile_FDR_FarmerProfile_model objPropfileDetails,string Mysql)
        {
            FarmerProfileOutput objOut = new FarmerProfileOutput();
            try
            {
                Mobile_FDR_Offlinesave_DB objConnection = new Mobile_FDR_Offlinesave_DB();
                objOut = objConnection.SaveFarmerHeaderData(objPropfileDetails.MFarmerHeaderDetails, Mysql);               
                if ( objOut.in_farmer_rowid>0)
                {
                    if (objPropfileDetails.MFarmerHeaderDetails.MfarmerBankDetails != null)
                    {
                        for (int i = 0; i < objPropfileDetails.MFarmerHeaderDetails.MfarmerBankDetails.Count; i++)
                        {
                            objConnection.FarmerBankDetailsSave(objPropfileDetails.MFarmerHeaderDetails.MfarmerBankDetails[i], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.MfarmerKycDetails != null)
                    {
                        for (int j = 0; j < objPropfileDetails.MFarmerHeaderDetails.MfarmerKycDetails.Count; j++)
                        {

                            objConnection.FarmerKYCDetailsSave(objPropfileDetails.MFarmerHeaderDetails.MfarmerKycDetails[j], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.MfarmerAddressDetails != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.MfarmerAddressDetails.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.MfarmerAddressDetails[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.MfarmerAddressDetails[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmercrop != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmercrop.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmercrop[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmercrop[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmercropsowing != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmercropsowing.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmercropsowing[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmercropsowing[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmerpersonal != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmerpersonal.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmerpersonal[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmerpersonal[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmerfamily != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmerfamily.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmerfamily[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmerfamily[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmerloans != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmerloans.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmerloans[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmerloans[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.MfarmerloansrePay != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.MfarmerloansrePay.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.MfarmerloansrePay[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.MfarmerloansrePay[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmerland != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmerland.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmerland[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmerland[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmerlivestock != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmerlivestock.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmerlivestock[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmerlivestock[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.MfarmerAssets != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.MfarmerAssets.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.MfarmerAssets[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.MfarmerAssets[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmerinsurance != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmerinsurance.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmerinsurance[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmerinsurance[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.MfarmerInputs != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.MfarmerInputs.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.MfarmerInputs[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.MfarmerInputs[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmerproduction != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmerproduction.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmerproduction[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmerproduction[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmersale != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmersale.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmersale[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmersale[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmerstock != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmerstock.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmerstock[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmerstock[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmertraning != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmertraning.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmertraning[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmertraning[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmershareholding != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmershareholding.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmershareholding[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmershareholding[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmerbusiness != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmerbusiness.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmerbusiness[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmerbusiness[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                    if (objPropfileDetails.MFarmerHeaderDetails.Mfarmerloanreq != null)
                    {
                        for (int k = 0; k < objPropfileDetails.MFarmerHeaderDetails.Mfarmerloanreq.Count; k++)
                        {
                            for (int M = 0; M < objPropfileDetails.MFarmerHeaderDetails.Mfarmerloanreq[0].Count; M++)
                            {
                                objConnection.FarmerAddressDetailsSave(objPropfileDetails.MFarmerHeaderDetails.Mfarmerloanreq[k][M], objPropfileDetails.MFarmerHeaderDetails.orgnId, objPropfileDetails.MFarmerHeaderDetails.locnId, objPropfileDetails.MFarmerHeaderDetails.userId, objPropfileDetails.MFarmerHeaderDetails.localeId, objOut.in_farmer_code, Mysql);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objOut;
        }
    }
}

