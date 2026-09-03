/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2FrameInfo // TypeDefIndex: 10563
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2FrameInfo _nativeICoreWebView2FrameInfoValue; // 0x18
		internal ICoreWebView2FrameInfo2 _nativeICoreWebView2FrameInfo2Value; // 0x20
	
		// Properties
		internal ICoreWebView2FrameInfo _nativeICoreWebView2FrameInfo { get; set; } // 0x00000001813A7F10-0x00000001813A8020 0x00000001802FAF70-0x00000001802FAF80
		public string Name { get; } // 0x00000001813A7970-0x00000001813A7AD0 
		public string Source { get; } // 0x00000001813A7CA0-0x00000001813A7E00 
		internal ICoreWebView2FrameInfo2 _nativeICoreWebView2FrameInfo2 { get; set; } // 0x00000001813A7E00-0x00000001813A7F10 0x000000018033E830-0x000000018033E840
		public uint FrameId { get; } // 0x00000001813A76B0-0x00000001813A7810 
		public CoreWebView2FrameKind FrameKind { get; } // 0x00000001813A7810-0x00000001813A7970 
		public CoreWebView2FrameInfo ParentFrameInfo { get; } // 0x00000001813A7AD0-0x00000001813A7CA0 
	
		// Constructors
		internal CoreWebView2FrameInfo(object rawCoreWebView2FrameInfo); // 0x00000001803855F0-0x0000000180385630
	}
}
