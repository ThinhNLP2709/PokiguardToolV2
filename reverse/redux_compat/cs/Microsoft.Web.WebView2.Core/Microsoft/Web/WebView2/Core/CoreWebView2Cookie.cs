/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2Cookie // TypeDefIndex: 10529
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2Cookie _nativeICoreWebView2CookieValue; // 0x18
		private static DateTime _unixEpoch; // 0x00
	
		// Properties
		internal ICoreWebView2Cookie _nativeICoreWebView2Cookie { get; set; } // 0x00000001813928B0-0x00000001813929C0 0x00000001802FAF70-0x00000001802FAF80
		public string Domain { get; } // 0x0000000181391C00-0x0000000181391D60 
		public bool IsHttpOnly { get; set; } // 0x0000000181391F10-0x0000000181392070 0x0000000181392B40-0x0000000181392CB0
		public bool IsSecure { get; set; } // 0x0000000181392070-0x00000001813921D0 0x0000000181392CB0-0x0000000181392E20
		public bool IsSession { get; } // 0x00000001813921D0-0x0000000181392330 
		public string Name { get; } // 0x0000000181392330-0x0000000181392490 
		public string Path { get; } // 0x0000000181392490-0x00000001813925F0 
		public CoreWebView2CookieSameSiteKind SameSite { get; set; } // 0x00000001813925F0-0x0000000181392750 0x0000000181392E20-0x0000000181392F90
		public string Value { get; set; } // 0x0000000181392750-0x00000001813928B0 0x0000000181392F90-0x0000000181393100
		public DateTime Expires { get; set; } // 0x0000000181391D60-0x0000000181391F10 0x00000001813929C0-0x0000000181392B40
	
		// Constructors
		internal CoreWebView2Cookie(object rawCoreWebView2Cookie); // 0x00000001803855F0-0x0000000180385630
		static CoreWebView2Cookie(); // 0x0000000181391B70-0x0000000181391C00
	
		// Methods
		public Cookie ToSystemNetCookie(); // 0x00000001813918F0-0x0000000181391B70
		private DateTime SecondsSinceUnixEpochToDateTime(double seconds); // 0x0000000181391790-0x00000001813918F0
	}
}
