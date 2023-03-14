using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staging_Data_Access.Utility
{
	#pragma warning disable CA2211 // Non-constant fields should not be visible
    public class U_Const
	{
		public const int INT_VALUE_NULL = 0;
		public const int FLT_VALUE_NULL = 0;
		public const double DB_VALUE_NULL = 0;
		public const string STR_VALUE_NULL = "";		
		public static DateTime? DTM_VALUE_NULL = null;
		public const int INT_VALUE_ALL = -5;
		public const bool BL_VALUE_NULL = false;
	}
	#pragma warning restore CA2211 // Non-constant fields should not be visible
}
