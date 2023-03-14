using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staging_Data_Access.Utility
{
	#pragma warning disable CA2211 // Non-constant fields should not be visible
    public class U_Config
	{
		public static string Date_Format_String = "dd/MM/yyyy";
        public static string Number_Format_String = "###,###0.###;-###,###0.###;-";
    }
	#pragma warning restore CA2211 // Non-constant fields should not be visible
}
