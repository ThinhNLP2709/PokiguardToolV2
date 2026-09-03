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
	internal class CoreWebView2WebMessageReceivedEventHandler : ICoreWebView2WebMessageReceivedEventHandler // TypeDefIndex: 10650
	{
		// Fields
		private CallbackType _callback; // 0x10
	
		// Nested types
		public delegate void CallbackType(CoreWebView2WebMessageReceivedEventArgs args); // TypeDefIndex: 10651; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		public CoreWebView2WebMessageReceivedEventHandler(CallbackType callback); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public void Invoke(ICoreWebView2 source, ICoreWebView2WebMessageReceivedEventArgs args); // 0x00000001813D6740-0x00000001813D67C0
	}
}
