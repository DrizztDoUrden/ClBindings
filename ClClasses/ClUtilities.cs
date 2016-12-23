using ClBindings.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClClasses
{
	internal static class ClUtilities
	{
		internal static void Check(ClResult result)
		{
			if (result != ClResult.CL_SUCCESS)
				throw new Exception($"Cl error occured: {result.ToString()}");
		}
	}
}
