/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2InitializationCompletedEventArgs : EventArgs // TypeDefIndex: 10814
	{
		// Fields
		[CompilerGenerated]
		private Exception _InitializationException_k__BackingField; // 0x10
	
		// Properties
		public bool IsSuccess { get; } // 0x00000001813DEED0-0x00000001813DEEE0 
		public Exception InitializationException { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
	
		// Constructors
		public CoreWebView2InitializationCompletedEventArgs(Exception ex = null); // 0x00000001813DEE60-0x00000001813DEED0
	}
}
