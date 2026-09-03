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
	public class CoreWebView2BrowserProcessExitedEventArgs : EventArgs // TypeDefIndex: 10518
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2BrowserProcessExitedEventArgs _nativeICoreWebView2BrowserProcessExitedEventArgsValue; // 0x18
	
		// Properties
		internal ICoreWebView2BrowserProcessExitedEventArgs _nativeICoreWebView2BrowserProcessExitedEventArgs { get; set; } // 0x0000000181369E60-0x0000000181369F70 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2BrowserProcessExitKind BrowserProcessExitKind { get; } // 0x0000000181369BA0-0x0000000181369D00 
		public uint BrowserProcessId { get; } // 0x0000000181369D00-0x0000000181369E60 
	
		// Constructors
		internal CoreWebView2BrowserProcessExitedEventArgs(object rawCoreWebView2BrowserProcessExitedEventArgs); // 0x0000000181369B30-0x0000000181369BA0
	}
}
