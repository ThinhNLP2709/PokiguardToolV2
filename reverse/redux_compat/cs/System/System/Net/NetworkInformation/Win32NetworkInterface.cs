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

namespace System.Net.NetworkInformation
{
	internal class Win32NetworkInterface // TypeDefIndex: 9194
	{
		// Fields
		private static Win32_FIXED_INFO fixedInfo; // 0x00
		private static bool initialized; // 0x58
	
		// Properties
		public static Win32_FIXED_INFO FixedInfo { get; } // 0x0000000181B40E20-0x0000000181B414A0 
	
		// Methods
		private static extern int GetNetworkParams(IntPtr ptr, ref int size); // 0x0000000181B40BD0-0x0000000181B40C60
		private static unsafe extern int MultiByteToWideChar(uint CodePage, uint dwFlags, byte* lpMultiByteStr, int cbMultiByte, char* lpWideCharStr, int cchWideChar); // 0x0000000181B40C60-0x0000000181B40D30
		[CompilerGenerated]
		internal static unsafe string _get_FixedInfo_g__GetStringFromMultiByte_5_0(byte* bytes); // 0x0000000181B40D30-0x0000000181B40E20
	}
}
