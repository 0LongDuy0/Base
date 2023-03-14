using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Staging_Data_Access.Utility
{
    #pragma warning disable CS8629 // Nullable value type may be null.  
    #pragma warning disable IDE0057 // Use range operator
    #pragma warning disable IDE0059 // Unnecessary assignment of a value
    #pragma warning disable CA1845 // Use span-based 'string.Concat'
    public class U_Utility_Date
    {
        /// <summary>
        /// Convert ngày về đầu ngày.
        /// VD: 03/01/2017 14:22:11 thì sẽ chuyển thành 03/01/2017 00:00:00
        /// </summary>
        /// <param name="p_dtmDate"></param>
        /// <returns></returns>
        public static DateTime? Convert_To_Dau_Ngay(DateTime? p_dtmDate)
        {
            DateTime? v_dtmRes = p_dtmDate;

            if (p_dtmDate == null)
                return null;

            v_dtmRes = U_Utility.Convert_String_To_Datetime(p_dtmDate.Value.ToString("dd/MM/yyyy") + " 00:00:00", "dd/MM/yyyy HH:mm:ss");
            return v_dtmRes;
        }

        public static DateTime Convert_To_Dau_Ngay(DateTime p_dtmDate)
        {
            DateTime v_dtmRes = p_dtmDate;

            v_dtmRes = U_Utility.Convert_String_To_Datetime(p_dtmDate.ToString("dd/MM/yyyy") + " 00:00:00", "dd/MM/yyyy HH:mm:ss").Value;

            return v_dtmRes;
        }

        /// <summary>
        /// Convert ngày về cuối ngày.
        /// VD: 03/01/2017 14:22:11 thì sẽ chuyển thành 03/01/2017 23:59:59
        /// </summary>
        /// <param name="p_dtmDate"></param>
        /// <returns></returns>
        public static DateTime? Convert_To_Cuoi_Ngay(DateTime? p_dtmDate)
        {
            DateTime? v_dtmRes = p_dtmDate;

            if (p_dtmDate == null)
                return null;

            v_dtmRes = U_Utility.Convert_String_To_Datetime(p_dtmDate.Value.ToString("dd/MM/yyyy") + " 23:59:59", "dd/MM/yyyy HH:mm:ss");
            return v_dtmRes;
        }

        /// <summary>
        /// Convert ngày về đầu tháng
        /// VD: 13/05/2017 14:22:11 thì sẽ chuyển thành 01/05/2017 00:00:00
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime? Convert_To_Dau_Thang(DateTime? p_dtmData)
        {
            if (p_dtmData == null)
                return null;

            return U_Utility.Convert_String_To_Datetime("01/" + p_dtmData.Value.Month.ToString() + "/"
                + p_dtmData.Value.Year.ToString() + " 00:00:00", "dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Convert ngày về cuối tháng
        /// VD: 13/05/2017 14:22:11 thì sẽ chuyển thành 31/05/2017 23:59:59
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime? Convert_To_Cuoi_Thang(DateTime? p_dtmData)
        {
            if (p_dtmData == null)
                return null;

            return Convert_To_Cuoi_Ngay(Convert_To_Dau_Thang(p_dtmData.Value.AddMonths(1)).Value.AddDays(-1));
        }

        /// <summary>
        /// Convert ngày về đầu tuần
        /// VD: 13/05/2017 14:22:11 thì sẽ chuyển thành 08/05/2017 00:00:00 do 08/05 là thứ 2
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime? Convert_To_Dau_Tuan(DateTime? p_dtmData)
        {
            DateTime? v_dtmRes = p_dtmData;

            if (p_dtmData == null)
                return null;

            while (v_dtmRes.Value.DayOfWeek != DayOfWeek.Monday)
                v_dtmRes = v_dtmRes.Value.AddDays(-1);

            return Convert_To_Dau_Ngay(v_dtmRes);
        }

        /// <summary>
        /// Convert ngày về cuối tuần
        /// VD: 13/05/2017 14:22:11 thì sẽ chuyển thành 14/05/2017 23:59:59 do 14/05 là chủ nhật
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime? Convert_To_Cuoi_Tuan(DateTime? p_dtmData)
        {
            DateTime? v_dtmRes = p_dtmData;

            if (p_dtmData == null)
                return null;

            while (v_dtmRes.Value.DayOfWeek != DayOfWeek.Sunday)
                v_dtmRes = v_dtmRes.Value.AddDays(1);

            return Convert_To_Cuoi_Ngay(v_dtmRes);
        }

        /// <summary>
        /// Convert ngày về đầu năm
        /// VD: 13/05/2017 14:22:11 thì sẽ chuyển thành 01/01/2017 00:00:00
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime? Convert_To_Dau_Nam(DateTime? p_dtmData)
        {
            if (p_dtmData == null)
                return null;

            return U_Utility.Convert_String_To_Datetime("01/01/" + p_dtmData.Value.Year.ToString() + " 00:00:00", "dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Convert ngày về cuối năm
        /// VD: 13/05/2017 14:22:11 thì sẽ chuyển thành 31/12/2017 23:59:59
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime? Convert_To_Cuoi_Nam(DateTime? p_dtmData)
        {
            if (p_dtmData == null)
                return null;

            return U_Utility.Convert_String_To_Datetime("31/12/" + p_dtmData.Value.Year.ToString() + " 23:59:59", "dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Lấy ngày tương lai của 1 ngày chỉ định loại trừ chủ nhật ra.
        /// </summary>
        /// <param name="p_dtmNow"></param>
        /// <param name="p_iDay"></param>
        /// <returns></returns>
        public static DateTime? Add_Day_Ngoai_Tru_Chu_Nhat(DateTime? p_dtmNow, int p_iDay)
        {
            if (p_dtmNow == null)
                return null;

            int v_iCount = 0;
            int v_iSub = 1;
            if (p_iDay < 0)
                v_iSub = -1;
            DateTime? v_dtRes = p_dtmNow;

            while (v_iCount < Math.Abs(p_iDay))
            {
                v_iCount++;
                v_dtRes = v_dtRes.Value.AddDays(v_iSub);

                while (v_dtRes.Value.DayOfWeek == DayOfWeek.Sunday)
                    v_dtRes = v_dtRes.Value.AddDays(v_iSub);
            }

            return v_dtRes;
        }

        /// <summary>
        /// Dùng lấy dòng mô tả về thời điểm trước đó
        /// VD: 2 phút trước, 5 phút trước, 2h trước...
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <param name="p_dtmSource"></param>
        /// <returns></returns>
        public static string Get_Mo_Ta_Thoi_Gian(DateTime? p_dtmData)
        {
            if (p_dtmData == null)
                return "";

            TimeSpan v_ts = DateTime.Now - p_dtmData.Value;
            if (v_ts.TotalSeconds < 60)
                return Math.Round(v_ts.TotalSeconds, 0).ToString("######") + " giây trước";

            if (v_ts.TotalMinutes < 60)
                return Math.Round(v_ts.TotalMinutes, 0).ToString("######") + " phút trước";

            if (v_ts.TotalHours < 24)
                return Math.Round(v_ts.TotalHours, 0).ToString("######") + " giờ trước";

            return Math.Round(v_ts.TotalDays, 0).ToString("######") + " ngày trước";
        }

        public static DateTime? Add_Day_Include_Saturday(DateTime? p_dtmNow, int p_iDay)
        {
            if (p_dtmNow == null)
                return null;

            int v_iCount = 0;
            int v_iSub = 1;
            if (p_iDay < 0)
                v_iSub = -1;
            DateTime? v_dtRes = p_dtmNow;

            while (v_iCount < Math.Abs(p_iDay))
            {
                v_iCount++;
                v_dtRes = v_dtRes.Value.AddDays(v_iSub);

                while (v_dtRes.Value.DayOfWeek == DayOfWeek.Sunday)
                    v_dtRes = v_dtRes.Value.AddDays(v_iSub);
            }

            return v_dtRes;
        }

        /// <summary>
        /// Lấy ngày đầu tuần
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime? Lay_Ngay_Dau_Tuan(DateTime? p_dtmData)
        {
            if (p_dtmData == null)
                return null;

            DateTime? v_dtmRes = p_dtmData;

            while (v_dtmRes.Value.DayOfWeek != DayOfWeek.Monday)
                v_dtmRes = v_dtmRes.Value.AddDays(-1);

            return v_dtmRes;
        }

        /// <summary>
        /// Lấy ngày đầu tháng
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime? Lay_Ngay_Dau_Thang(DateTime? p_dtmData)
        {
            if (p_dtmData == null)
                return null;

            return U_Utility.Convert_String_To_Datetime("01/" + p_dtmData.Value.Month.ToString("00")
                + "/" + p_dtmData.Value.Year.ToString() + " 00:00:00", "dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Convert ngày về cuối tháng
        /// VD: 13/05/2017 14:22:11 thì sẽ chuyển thành 31/05/2017 23:59:59
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime? Lay_Ngay_Cuoi_Thang(DateTime? p_dtmData)
        {
            if (p_dtmData == null)
                return null;

            return Convert_To_Cuoi_Ngay(Lay_Ngay_Dau_Thang(p_dtmData.Value.AddMonths(1)).Value.AddDays(-1));
        }

        /// <summary>
        /// Lấy ngày đầu nam
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime? Lay_Ngay_Dau_Nam(DateTime? p_dtmData)
        {
            if (p_dtmData == null)
                return null;

            DateTime? v_dtmRes = p_dtmData;

            while (v_dtmRes.Value.DayOfYear != 1)
                v_dtmRes = v_dtmRes.Value.AddDays(-1);

            return v_dtmRes;
        }
        public static DateTime? Get_Vietnam_Datetime_From_String(string p_strDate)
        {
            try
            {
                int v_iLength = p_strDate.Length;

                if (v_iLength != 0)
                {

                    if (v_iLength != 10 && v_iLength != 16 && v_iLength != 19 && v_iLength != 6)
                        throw new Exception("Ngày không đúng định dạng.");

                    if (v_iLength == 10)
                        return U_Utility.Convert_String_To_Datetime(p_strDate, "dd/MM/yyyy");

                    if (v_iLength == 16)
                        return U_Utility.Convert_String_To_Datetime(p_strDate, "dd/MM/yyyy HH:mm");

                    if (v_iLength == 19)
                        return U_Utility.Convert_String_To_Datetime(p_strDate, "dd/MM/yyyy HH:mm:ss");

                    if (v_iLength == 6) // Format ddMMyy
                    {

                        string v_strDay = p_strDate.Substring(0, 2);
                        string v_strMonth = p_strDate.Substring(2, 2);

                        string v_strYear_Prefix = "20";
                        if (p_strDate == "010150")
                            v_strYear_Prefix = "19";

                        string v_strYear = v_strYear_Prefix + p_strDate.Substring(4, 2);

                        return U_Utility.Convert_String_To_Datetime(v_strDay + "/" + v_strMonth + "/" + v_strYear, "dd/MM/yyyy");
                    }
                }
            }

            catch (Exception)
            {
                throw new Exception("Ngày không đúng định dạng.");
            }

            return U_Const.DTM_VALUE_NULL;
        }

        public static double Tinh_Life(DateTime? p_dtmNgay_San_Xuat, DateTime? p_dtmNgay_Het_Han, DateTime? p_dtmNgay_Xuat_Kho)
        {
            if (p_dtmNgay_San_Xuat == null || p_dtmNgay_Het_Han == null)
                return 0;

            TimeSpan v_ts1 = U_Utility_Date.Convert_To_Dau_Ngay(DateTime.Now) - U_Utility_Date.Convert_To_Dau_Ngay(p_dtmNgay_San_Xuat).Value;

            if (p_dtmNgay_Xuat_Kho != null)
                v_ts1 = U_Utility_Date.Convert_To_Dau_Ngay(p_dtmNgay_Xuat_Kho).Value - U_Utility_Date.Convert_To_Dau_Ngay(p_dtmNgay_San_Xuat).Value;

            TimeSpan v_ts2 = U_Utility_Date.Convert_To_Dau_Ngay(p_dtmNgay_Het_Han).Value - U_Utility_Date.Convert_To_Dau_Ngay(p_dtmNgay_San_Xuat).Value;

            return ((v_ts2.TotalDays - v_ts1.TotalDays) / v_ts2.TotalDays) * 100;
        }
    }
    #pragma warning restore CA1845 // Use span-based 'string.Concat'
    #pragma warning restore IDE0059 // Unnecessary assignment of a value
    #pragma warning restore IDE0057 // Use range operator
    #pragma warning restore CS8629 // Nullable value type may be null.
}
