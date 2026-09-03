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
	public class CoreWebView2ContextMenuTarget // TypeDefIndex: 10526
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2ContextMenuTarget _nativeICoreWebView2ContextMenuTargetValue; // 0x18
	
		// Properties
		internal ICoreWebView2ContextMenuTarget _nativeICoreWebView2ContextMenuTarget { get; set; } // 0x000000018138A5F0-0x000000018138A700 0x00000001802FAF70-0x00000001802FAF80
		public string FrameUri { get; } // 0x0000000181389410-0x0000000181389570 
		public bool HasLinkText { get; } // 0x0000000181389570-0x00000001813896D0 
		public bool HasLinkUri { get; } // 0x00000001813896D0-0x0000000181389830 
		public bool HasSelection { get; } // 0x0000000181389830-0x0000000181389990 
		public bool HasSourceUri { get; } // 0x0000000181389990-0x0000000181389AF0 
		public bool IsEditable { get; } // 0x0000000181389AF0-0x0000000181389C50 
		public bool IsRequestedForMainFrame { get; } // 0x0000000181389C50-0x0000000181389DB0 
		public CoreWebView2ContextMenuTargetKind Kind { get; } // 0x0000000181389DB0-0x0000000181389F10 
		public string LinkText { get; } // 0x0000000181389F10-0x000000018138A070 
		public string LinkUri { get; } // 0x000000018138A070-0x000000018138A1D0 
		public string PageUri { get; } // 0x000000018138A1D0-0x000000018138A330 
		public string SelectionText { get; } // 0x000000018138A330-0x000000018138A490 
		public string SourceUri { get; } // 0x000000018138A490-0x000000018138A5F0 
	
		// Constructors
		internal CoreWebView2ContextMenuTarget(object rawCoreWebView2ContextMenuTarget); // 0x00000001803855F0-0x0000000180385630
	}
}
