using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Staging_Data_Access.Utility
{
	#pragma warning disable CA2211 // Non-constant fields should not be visible
	#pragma warning disable IDE0031 // Use null propagation
	#pragma warning disable IDE0059 // Unnecessary assignment of a value
	#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
	#pragma warning disable IDE0090 // Use 'new(...)'
	#pragma warning disable IDE0057 // Use range operator
    public enum EFileType
	{
		/// <summary>
		/// Định dạng file kiểu text
		/// </summary>
		Text,
		/// <summary>
		/// Định dạng file kiểu XML
		/// </summary>
		XML
	}

	/// <summary>
	/// Logger Information
	/// </summary>

	public class U_Logger
	{
		public static string User = "";
		public static string File_Name = "";
		public static bool Enable_Trace = true;
		public static bool Enable_Error = true;
		public static bool Enable_Warning = true;
		public static bool Enable_Debug = true;
		public static EFileType File_Type = EFileType.Text;
		
		/// <summary>
		/// Update extend format FileName is log format
		/// </summary>
		/// <returns>String</returns>
		private static string Update_File_Name(string p_strFileName)
		{
			return p_strFileName.Replace(".log", "") + DateTime.Now.ToString("yyyyMMdd") + ".log";
		}

		public static void Write_To_File(string p_strMode, string p_strObjectName, string p_strFunctionName,
			string p_strContent)
		{
			string strFileExtend = "";
			
			TextWriter tw = null;
			
			U_Log data = new U_Log();
			
			// Get File Name
			strFileExtend = Update_File_Name(File_Name);

			if (!File.Exists(strFileExtend))
			{
				Directory.CreateDirectory(strFileExtend.Substring(0, strFileExtend.LastIndexOf("\\")));
			} // End if

			try
			{
				tw = new StreamWriter(strFileExtend, File.Exists(strFileExtend));

				// Asign value to log object
				data.Content = p_strContent;
				data.Date = DateTime.Now.ToString("dd/MM/yyyy");
				data.FunctionName = p_strFunctionName;
				data.Mode = p_strMode;
				data.ObjectName = p_strObjectName;
				data.Time = DateTime.Now.ToString("hh:mm:ss");
				data.User = User;

				// write data to log
				if (File_Type == EFileType.Text)
					data.WriteTextFile(tw);

				if (File_Type == EFileType.XML)
					data.WriteXmlFile(tw);
			}
			catch (Exception)
			{
			}
			finally
			{
				if (tw != null)
					tw.Close();
			}
		}

		/// <summary>
		/// Trace log
		/// </summary>
		/// <param name="p_strObjectName">Object Name</param>
		/// <param name="p_strFunctionName">FunctionName</param>
		/// <param name="p_strContent">Content</param>
		public static void Trace(string p_strObjectName, string p_strFunctionName, string p_strContent)
		{
			if (Enable_Trace == true)
				Write_To_File("Trace", p_strObjectName, p_strFunctionName, p_strContent);
		}

		/// <summary>
		/// Debug log
		/// </summary>
		/// <param name="p_strObjectName">Object Name</param>
		/// <param name="p_strFunctionName">FunctionName</param>
		/// <param name="p_strContent">Content</param>
		public static void Debug(string p_strObjectName, string p_strFunctionName, string p_strContent)
		{
			if (Enable_Debug == true)
				Write_To_File("Debug", p_strObjectName, p_strFunctionName, p_strContent);
		}

		/// <summary>
		/// Debug log
		/// </summary>
		/// <param name="p_strObjectName">Object Name</param>
		/// <param name="p_strFunctionName">FunctionName</param>
		/// <param name="p_strContent">Content</param>
		public static void Error(string p_strObjectName, string p_strFunctionName, string p_strContent)
		{
			if (Enable_Error == true)
				Write_To_File("Error", p_strObjectName, p_strFunctionName, p_strContent);
		}

		/// <summary>
		/// Warning log
		/// </summary>
		/// <param name="p_strObjectName">Object Name</param>
		/// <param name="p_strFunctionName">FunctionName</param>
		/// <param name="p_strContent">Content</param>
		public static void Warning(string p_strObjectName, string p_strFunctionName, string p_strContent)
		{
			if (Enable_Warning == true)
				Write_To_File("Warning", p_strObjectName, p_strFunctionName, p_strContent);
		}
	}
	#pragma warning restore IDE0057 // Use range operator
	#pragma warning restore IDE0090 // Use 'new(...)'
	#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
	#pragma warning restore IDE0059 // Unnecessary assignment of a value
	#pragma warning restore IDE0031 // Use null propagation
	#pragma warning restore CA2211 // Non-constant fields should not be visible
}
