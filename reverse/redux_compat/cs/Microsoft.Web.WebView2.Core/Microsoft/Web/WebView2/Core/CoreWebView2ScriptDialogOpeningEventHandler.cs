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
	internal class CoreWebView2ScriptDialogOpeningEventHandler : ICoreWebView2ScriptDialogOpeningEventHandler // TypeDefIndex: 10646
	{
		// Fields
		private CallbackType _callback; // 0x10
	
		// Nested types
		public delegate void CallbackType(CoreWebView2ScriptDialogOpeningEventArgs args); // TypeDefIndex: 10647; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		public CoreWebView2ScriptDialogOpeningEventHandler(CallbackType callback); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public void Invoke(ICoreWebView2 source, ICoreWebView2ScriptDialogOpeningEventArgs args); // 0x00000001813CC0F0-0x00000001813CC1B0
	}
}
