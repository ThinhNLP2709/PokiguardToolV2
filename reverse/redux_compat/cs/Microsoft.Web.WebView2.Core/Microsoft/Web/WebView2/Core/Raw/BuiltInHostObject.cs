/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Web.WebView2.Core;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core.Raw
{
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[ComVisible(true)]
	public class BuiltInHostObject // TypeDefIndex: 10820
	{
		// Fields
		private object _originalHostObject; // 0x10
		private EventConnector _eventConnector; // 0x18
	
		// Properties
		private EventConnector EventConnector { get; } // 0x00000001813DDE80-0x00000001813DE000 
	
		// Constructors
		public BuiltInHostObject(object originalHostObject); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public void addEventListener(string eventName, object JSHandler); // 0x00000001813DDE40-0x00000001813DDE80
		public void removeEventListener(string eventName, object JSHandler); // 0x00000001813DE000-0x00000001813DE040
	}
}
