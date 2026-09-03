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
	public class EventSource : IDisposable // TypeDefIndex: 3476
	{
		// Fields
		[CompilerGenerated]
		private string _Name_k__BackingField; // 0x10
	
		// Properties
		private string Name { [CompilerGenerated] set; } // 0x00000001803780D0-0x00000001803780E0
	
		// Nested types
		protected internal struct EventData // TypeDefIndex: 3477
		{
			// Fields
			[CompilerGenerated]
			private IntPtr _DataPointer_k__BackingField; // 0x00
			[CompilerGenerated]
			private int _Size_k__BackingField; // 0x08
			[CompilerGenerated]
			private int _Reserved_k__BackingField; // 0x0C
	
			// Properties
			public IntPtr DataPointer { [CompilerGenerated] set; } // 0x0000000180CBE820-0x0000000180CBE830
			public int Size { [CompilerGenerated] set; } // 0x0000000180732D60-0x0000000180732D70
			internal int Reserved { [CompilerGenerated] set; } // 0x0000000180732D70-0x0000000180732D80
		}
	
		// Constructors
		protected EventSource(); // 0x0000000181599820-0x0000000181599870
		public EventSource(string eventSourceName); // 0x00000001803855F0-0x0000000180385630
		internal EventSource(Guid eventSourceGuid, string eventSourceName); // 0x00000001815997E0-0x0000000181599820
	
		// Methods
		~EventSource(); // 0x0000000181428550-0x00000001814285D0
		public bool IsEnabled(); // 0x00000001802E7840-0x00000001802E7850
		public bool IsEnabled(EventLevel level, EventKeywords keywords); // 0x00000001802E7840-0x00000001802E7850
		public void Dispose(); // 0x0000000181599060-0x00000001815990D0
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		protected void WriteEvent(int eventId, int arg1); // 0x0000000181599400-0x00000001815994C0
		protected void WriteEvent(int eventId, string arg1); // 0x00000001815990D0-0x0000000181599170
		protected void WriteEvent(int eventId, int arg1, int arg2); // 0x00000001815996C0-0x00000001815997E0
		protected void WriteEvent(int eventId, int arg1, int arg2, int arg3); // 0x0000000181599170-0x0000000181599300
		protected void WriteEvent(int eventId, long arg1); // 0x0000000181599600-0x00000001815996C0
		protected void WriteEvent(int eventId, long arg1, string arg2); // 0x0000000181599300-0x0000000181599400
		protected void WriteEvent(int eventId, params object[] args); // 0x00000001802E76C0-0x00000001802E76D0
		protected void WriteEvent(int eventId, string arg1, string arg2, string arg3); // 0x00000001815994C0-0x0000000181599600
		[CLSCompliant(false)]
		protected unsafe void WriteEventCore(int eventId, int eventDataCount, EventData* data); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
