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

namespace System.Runtime.Serialization
{
	[Serializable]
	[ComVisible(true)]
	[IsReadOnly]
	public struct StreamingContext // TypeDefIndex: 3052
	{
		// Fields
		internal readonly object m_additionalContext; // 0x00
		internal readonly StreamingContextStates m_state; // 0x08
	
		// Properties
		public object Context { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public StreamingContextStates State { get; } // 0x0000000180732D20-0x0000000180732D30 
	
		// Constructors
		public StreamingContext(StreamingContextStates state); // 0x00000001815046B0-0x00000001815046D0
		public StreamingContext(StreamingContextStates state, object additional); // 0x00000001815046D0-0x00000001815046E0
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181504620-0x00000001815046B0
		public override int GetHashCode(); // 0x0000000180732D20-0x0000000180732D30
	}
}
