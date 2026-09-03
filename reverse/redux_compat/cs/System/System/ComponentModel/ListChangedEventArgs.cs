/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	public class ListChangedEventArgs : EventArgs // TypeDefIndex: 8864
	{
		// Fields
		[CompilerGenerated]
		private readonly ListChangedType _ListChangedType_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly int _NewIndex_k__BackingField; // 0x14
		[CompilerGenerated]
		private readonly int _OldIndex_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly PropertyDescriptor _PropertyDescriptor_k__BackingField; // 0x20
	
		// Properties
		public ListChangedType ListChangedType { [CompilerGenerated] get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public int NewIndex { [CompilerGenerated] get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public int OldIndex { [CompilerGenerated] get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Constructors
		public ListChangedEventArgs(ListChangedType listChangedType, int newIndex); // 0x0000000181BABA80-0x0000000181BABAF0
		public ListChangedEventArgs(ListChangedType listChangedType, int newIndex, PropertyDescriptor propDesc); // 0x0000000181BABAF0-0x0000000181BABB80
		public ListChangedEventArgs(ListChangedType listChangedType, PropertyDescriptor propDesc); // 0x0000000181BAB980-0x0000000181BABA00
		public ListChangedEventArgs(ListChangedType listChangedType, int newIndex, int oldIndex); // 0x0000000181BABA00-0x0000000181BABA80
	}
}
