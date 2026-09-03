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
	internal class EventConnector // TypeDefIndex: 10813
	{
		// Fields
		private DelegateMap _DelegatesMap; // 0x10
		private object _originalHostObject; // 0x18
	
		// Constructors
		public EventConnector(object originalHostObject); // 0x00000001813E05D0-0x00000001813E0700
	
		// Methods
		public void addEventListener(string eventName, object JSHandler); // 0x00000001813E0700-0x00000001813E08F0
		public void removeEventListener(string eventName, object JSHandler); // 0x00000001813E08F0-0x00000001813E0AB0
		private void RemoteObjectPassivated(object sender, object args); // 0x00000001813E03B0-0x00000001813E05D0
		private EventInfo CheckAndGetEventInfo(string eventName); // 0x00000001813E02E0-0x00000001813E03B0
	}
}
