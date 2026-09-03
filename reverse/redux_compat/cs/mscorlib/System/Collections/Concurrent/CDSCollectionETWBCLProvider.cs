/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Concurrent
{
	[EventSource(Name = "System.Collections.Concurrent.ConcurrentCollectionsEventSource", Guid = "35167F8E-49B2-4b96-AB86-435B59336B5E")]
	internal sealed class CDSCollectionETWBCLProvider : EventSource // TypeDefIndex: 3542
	{
		// Fields
		public static CDSCollectionETWBCLProvider Log; // 0x00
	
		// Constructors
		private CDSCollectionETWBCLProvider(); // 0x00000001815A75F0-0x00000001815A7600
		static CDSCollectionETWBCLProvider(); // 0x00000001815A7580-0x00000001815A75F0
	
		// Methods
		[Event(3, Level = EventLevel.Warning)]
		public void ConcurrentDictionary_AcquiringAllLocks(int numOfBuckets); // 0x00000001815A7530-0x00000001815A7580
	}
}
