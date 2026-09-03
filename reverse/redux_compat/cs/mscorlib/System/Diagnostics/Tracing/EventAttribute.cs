/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Diagnostics.Tracing
{
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class EventAttribute : Attribute // TypeDefIndex: 3475
	{
		// Fields
		[CompilerGenerated]
		private int _EventId_k__BackingField; // 0x10
		[CompilerGenerated]
		private EventLevel _Level_k__BackingField; // 0x14
		[CompilerGenerated]
		private EventKeywords _Keywords_k__BackingField; // 0x18
		[CompilerGenerated]
		private string _Message_k__BackingField; // 0x20
	
		// Properties
		private int EventId { [CompilerGenerated] set; } // 0x00000001805D5560-0x00000001805D5570
		public EventLevel Level { [CompilerGenerated] set; } // 0x0000000180E02550-0x0000000180E02560
		public EventKeywords Keywords { [CompilerGenerated] set; } // 0x00000001804C2E30-0x00000001804C2E40
		public string Message { [CompilerGenerated] set; } // 0x000000018033E830-0x000000018033E840
	
		// Constructors
		public EventAttribute(int eventId); // 0x0000000181380310-0x0000000181380340
	}
}
