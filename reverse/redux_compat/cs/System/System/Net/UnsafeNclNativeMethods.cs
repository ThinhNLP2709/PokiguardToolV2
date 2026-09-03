/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal static class UnsafeNclNativeMethods // TypeDefIndex: 9103
	{
		// Nested types
		internal static class HttpApi // TypeDefIndex: 9104
		{
			// Fields
			private static string[] m_Strings; // 0x00
	
			// Nested types
			internal static class HTTP_REQUEST_HEADER_ID // TypeDefIndex: 9105
			{
				// Fields
				private static string[] m_Strings; // 0x00
	
				// Constructors
				static HTTP_REQUEST_HEADER_ID(); // 0x0000000181C0B4C0-0x0000000181C0BCB0
	
				// Methods
				internal static string ToString(int position); // 0x0000000181C0B450-0x0000000181C0B4C0
			}
	
			// Constructors
			static HttpApi(); // 0x0000000181C0BCB0-0x0000000181C0C290
		}
	
		internal static class SecureStringHelper // TypeDefIndex: 9106
		{
			// Methods
			internal static string CreateString(SecureString secureString); // 0x0000000181C11130-0x0000000181C11260
			internal static SecureString CreateSecureString(string plainString); // 0x0000000181C11090-0x0000000181C11130
		}
	}
}
