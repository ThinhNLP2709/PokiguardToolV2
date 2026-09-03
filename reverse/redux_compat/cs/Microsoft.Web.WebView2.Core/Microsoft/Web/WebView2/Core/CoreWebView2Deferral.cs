/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2Deferral : IDisposable // TypeDefIndex: 10537
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2Deferral _nativeICoreWebView2DeferralValue; // 0x18
		private bool disposed; // 0x20
		private SafeHandle handle; // 0x28
	
		// Properties
		internal ICoreWebView2Deferral _nativeICoreWebView2Deferral { get; set; } // 0x0000000181395240-0x0000000181395350 0x00000001802FAF70-0x00000001802FAF80
	
		// Constructors
		internal CoreWebView2Deferral(object rawCoreWebView2Deferral); // 0x00000001813951B0-0x0000000181395240
	
		// Methods
		public void Complete(); // 0x0000000181394F90-0x0000000181395100
		public void Dispose(); // 0x0000000181395140-0x00000001813951B0
		protected virtual void Dispose(bool disposing); // 0x0000000181395100-0x0000000181395140
	}
}
