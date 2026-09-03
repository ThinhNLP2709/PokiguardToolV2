/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2SharedBuffer : IDisposable // TypeDefIndex: 10613
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2SharedBuffer _nativeICoreWebView2SharedBufferValue; // 0x18
		private bool _disposed; // 0x20
		private WebView2SharedBufferSafeHandle _safeFileMappingHandle; // 0x28
	
		// Properties
		internal ICoreWebView2SharedBuffer _nativeICoreWebView2SharedBuffer { get; set; } // 0x00000001813D44A0-0x00000001813D45B0 0x00000001802FAF70-0x00000001802FAF80
		public IntPtr Buffer { get; } // 0x00000001813D4080-0x00000001813D41E0 
		public ulong Size { get; } // 0x00000001813D4280-0x00000001813D4440 
		internal IntPtr UnsafeFileMappingHandle { get; } // 0x00000001813D4440-0x00000001813D44A0 
		public SafeHandle FileMappingHandle { get; } // 0x00000001813D41E0-0x00000001813D4280 
	
		// Nested types
		internal class WebView2SharedBufferSafeHandle : SafeHandle // TypeDefIndex: 10614
		{
			// Fields
			protected CoreWebView2SharedBuffer _shared_buffer; // 0x20
	
			// Properties
			public override bool IsInvalid { get; } // 0x00000001813DDC00-0x00000001813DDDD0 
	
			// Constructors
			public WebView2SharedBufferSafeHandle(CoreWebView2SharedBuffer shared_buffer); // 0x00000001813DDBA0-0x00000001813DDC00
	
			// Methods
			protected override bool ReleaseHandle(); // 0x00000001813DDB80-0x00000001813DDBA0
		}
	
		// Constructors
		internal CoreWebView2SharedBuffer(object rawCoreWebView2SharedBuffer); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public Stream OpenStream(); // 0x00000001813D3F10-0x00000001813D4080
		public void Close(); // 0x00000001813D3CD0-0x00000001813D3E40
		public void Dispose(); // 0x00000001813D3E40-0x00000001813D3EB0
		protected virtual void Dispose(bool disposing); // 0x00000001813D3EB0-0x00000001813D3F10
	}
}
