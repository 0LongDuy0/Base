using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Staging_Data_Access.Utility
{
    #pragma warning disable CA2211 // Non-constant fields should not be visible
    #pragma warning disable IDE0090 // Use 'new(...)'
    #pragma warning disable CS8603 // Possible null reference return.
    public class U_Utility
    {
        public static Random rand = new Random();

        public static DateTime? Get_Null_Date()
        {
            return Convert_String_To_Datetime("01/01/1900", "dd/MM/yyyy");
        }

        public static int Convert_To_Int32(object p_objData)
        {
            if ((p_objData != System.DBNull.Value) && (U_Utility.Convert_To_String(p_objData) != ""))
                return Convert.ToInt32(p_objData);
            else
                return U_Const.INT_VALUE_NULL;
        }

        public static long Convert_To_Int64(object p_objData)
        {
            if ((p_objData != System.DBNull.Value) && (U_Utility.Convert_To_String(p_objData) != ""))
                return Convert.ToInt64(p_objData);
            else
                return U_Const.INT_VALUE_NULL;
        }

        public static double Convert_To_Double(object p_objData)
        {
            if ((p_objData != System.DBNull.Value) && (U_Utility.Convert_To_String(p_objData) != ""))
                return Convert.ToDouble(p_objData);
            else
                return U_Const.FLT_VALUE_NULL;
        }

        public static bool Convert_To_Bool(object p_objData)
        {
            if (p_objData != System.DBNull.Value)
                return Convert.ToBoolean(p_objData);
            else
                return U_Const.BL_VALUE_NULL;
        }

        public static DateTime? Convert_To_DateTime(object p_objData)
        {
            if (p_objData != System.DBNull.Value && p_objData != null)
                return Convert.ToDateTime(p_objData);
            else
                return U_Const.DTM_VALUE_NULL;
        }

        public static DateTime? Convert_String_To_Datetime(string p_strDate)
        {
            if (p_strDate == "")
                return U_Const.DTM_VALUE_NULL;

            CultureInfo provider = CultureInfo.InvariantCulture;
            return DateTime.ParseExact(p_strDate, U_Config.Date_Format_String, provider);
        }

        public static DateTime? Convert_String_To_Datetime(string p_strDate, string p_strFormat)
        {
            if (p_strDate == "")
                return U_Const.DTM_VALUE_NULL;

            CultureInfo provider = CultureInfo.InvariantCulture;
            return DateTime.ParseExact(p_strDate, p_strFormat, provider);
        }

        public static string Convert_To_String(object p_objData)
        {
            return Convert.ToString(p_objData);
        }
    }
    #pragma warning restore CS8603 // Possible null reference return.
    #pragma warning restore IDE0090 // Use 'new(...)'
    #pragma warning restore CA2211 // Non-constant fields should not be visible
}
