/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	internal class DelegateMap // TypeDefIndex: 10811
	{
		// Fields
		private Dictionary<string, HashSet<int>> _RegisteredHandlerIdsMap; // 0x10
		private Dictionary<int, tuple> _HandlerMap; // 0x18
	
		// Nested types
		private class tuple // TypeDefIndex: 10812
		{
			// Fields
			public int count; // 0x10
			public Delegate handler; // 0x18
	
			// Constructors
			public tuple(int count, Delegate handler); // 0x00000001806F4520-0x00000001806F4560
		}
	
		// Constructors
		public DelegateMap(); // 0x00000001813E0220-0x00000001813E02E0
	
		// Methods
		public Delegate GetDelegate(int handlerId); // 0x00000001813DFB60-0x00000001813DFBD0
		public bool InsertDelegate(string eventName, int handlerId, Delegate handler); // 0x00000001813DFD80-0x00000001813E0030
		public Delegate RemoveDelegate(string eventName, int handlerId); // 0x00000001813E0030-0x00000001813E0220
		public List<string> GetRegisteredEventNameById(int handlerId); // 0x00000001813DFBD0-0x00000001813DFD80
	}
}
