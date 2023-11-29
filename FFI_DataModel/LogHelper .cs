using FFI_Model;
using log4net.Repository.Hierarchy;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace FFI_DataModel
{
    public class LogHelper
    {
        static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(LogHelper));
        public static void WriteLog(string type, string spName, string inputorOuptut, object inoutObject, ParameterInfo[] parameters)
        {
            if (type == "GET")
            {
                logger.Debug("SP Name : " + spName);
                if (inputorOuptut == "Input")
                {
                    logger.Debug("Input Parametrs : ");
                    string res = ConvertObjectIntoString(inoutObject);
                }
                if (inputorOuptut == "Output")
                {

                }
            }
            if (type == "POST")
            {
                logger.Debug("SP Name : " + spName);
                logger.Debug("Input Parametrs : ");
                if (inputorOuptut == "Input")
                {

                }
                if (inputorOuptut == "Output")
                {

                }
            }
        }
        public static string ConvertObjectIntoString(object obj)
        {
            string output = string.Empty;
            //StringBuilder response = new StringBuilder();
            try
            {
                output = JsonConvert.SerializeObject(obj);
                logger.Debug(output);
                //    //dynamic d = obj;
                //    //object o = d;
                //    //string[] propertyNames = o.GetType().GetProperties().Select(p => p.Name).ToArray();
                //    //foreach (var prop in propertyNames)
                //    //{
                //    //    object propValue = o.GetType().GetProperty(prop).GetValue(o, null);

                //    //}                
                //    //object objlist = obj.GetType().GetProperties().Where(p => p.PropertyType == typeof(List<>));

                //    var stringProps = obj.GetType().GetProperties().Where(p => p.PropertyType == typeof(string));
                //    foreach (var prop in stringProps)
                //    {
                //        response.Append(prop.Name + " - " + (string)prop.GetValue(obj) + " ");
                //    }
                //    var intProps = obj.GetType().GetProperties().Where(p => p.PropertyType == typeof(int));
                //    foreach (var prop in stringProps)
                //    {
                //        response.Append(prop.Name + " - " + (int)prop.GetValue(obj) + " ");
                //    }
                //    var decimalProps = obj.GetType().GetProperties().Where(p => p.PropertyType == typeof(decimal));
                //    foreach (var prop in stringProps)
                //    {
                //        response.Append(prop.Name + " - " + (decimal)prop.GetValue(obj) + " ");
                //    }
                //    var doubleProps = obj.GetType().GetProperties().Where(p => p.PropertyType == typeof(double));
                //    foreach (var prop in stringProps)
                //    {
                //        response.Append(prop.Name + " - " + (double)prop.GetValue(obj) + " ");
                //    }
            }
            catch (Exception ex)
            {
            }
            return output;
        }

        public static void ConvertObjIntoString(object obj, string inout)
        {
            try
            {
                if (inout == "Input")
                {
                    logger.Debug("Input Request : ");
                }
                else
                {
                    logger.Debug("Output Response : ");
                }
                string output = JsonConvert.SerializeObject(obj);
                logger.Debug(output);
            }
            catch (Exception ex)
            {
            }
        }
        public static void ConvertCmdIntoString(MySqlCommand cmd)
        {
            string response = string.Empty;
            System.Data.DataSet ds = new System.Data.DataSet();
            try
            {
                logger.Debug("SP Name :" + cmd.CommandText);
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    if (cmd.Parameters[i].Direction == System.Data.ParameterDirection.Input)
                    {
                        logger.Debug("Input Paramerter No : " + i + " ; Name :" + cmd.Parameters[i].ParameterName + " ; Value : " + cmd.Parameters[i].Value);
                    }
                    if (cmd.Parameters[i].Direction == System.Data.ParameterDirection.Output)
                    {
                        logger.Debug("Output Paramerter No : " + i + " ; Name :" + cmd.Parameters[i].ParameterName + " ; Value : " + cmd.Parameters[i].Value);
                    }
                }
                //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                //da.Fill(ds);
                //logger.Debug("MYSQL Output");
                //if (ds.Tables.Count == 0)
                //{
                //    logger.Debug("No DataSet Retuens");
                //}
                //for (int j = 0; j < ds.Tables.Count; j++)
                //{
                //    logger.Debug(ConvertDataTableToString(ds.Tables[j]));
                //}
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
        }
        public static string ConvertDataTableToString(DataTable dt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            dt.Rows.Cast<DataRow>().ToList().ForEach(dataRow =>
            {
                dt.Columns.Cast<DataColumn>().ToList().ForEach(column =>
                {
                    stringBuilder.AppendFormat("{0}:{1} ", column.ColumnName, dataRow[column]);
                });
                stringBuilder.Append(Environment.NewLine);
            });
            return stringBuilder.ToString();
        }
        public static void ConvertPropertiesIntoString(ParameterInfo[] param, ArrayList objArr)
        {
            string response = string.Empty;
            try
            {
                logger.Debug("Input Request : ");
                for (int i = 0; i < objArr.Count; i++)
                {
                    logger.Debug("Paramerter : " + i + " ; Name :" + param[i].Name + " ; Value : " + objArr[i]);
                }
            }
            catch (Exception)
            {

            }
        }
        public static ArrayList Arr()
        {
            ArrayList objarr = new ArrayList();
            try
            {
            }
            catch (Exception)
            {
            }
            return objarr;
        }
    }
}
