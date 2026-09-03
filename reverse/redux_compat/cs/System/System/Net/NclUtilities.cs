/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal static class NclUtilities // TypeDefIndex: 9042
	{
		// Fields
		private static IPAddress[] _LocalAddresses; // 0x00
		private static object _LocalAddressesLock; // 0x08
		internal static string _LocalDomainName; // 0x10
	
		// Properties
		internal static IPAddress[] LocalAddresses { get; } // 0x0000000181BF30D0-0x0000000181BF3590 
		private static object LocalAddressesLock { get; } // 0x0000000181BF3040-0x0000000181BF30D0 
	
		// Methods
		internal static bool IsFatal(Exception exception); // 0x0000000181BF2FA0-0x0000000181BF3040
		internal static bool IsAddressLocal(IPAddress ipAddress); // 0x0000000181BF2F10-0x0000000181BF2FA0
		private static IPHostEntry GetLocalHost(); // 0x0000000181BF2EF0-0x0000000181BF2F10
	}
}
