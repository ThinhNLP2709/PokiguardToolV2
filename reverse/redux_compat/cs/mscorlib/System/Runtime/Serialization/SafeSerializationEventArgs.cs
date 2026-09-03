/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization
{
	public sealed class SafeSerializationEventArgs : EventArgs // TypeDefIndex: 3042
	{
		// Fields
		private StreamingContext m_streamingContext; // 0x10
		private List<object> m_serializedStates; // 0x20
	
		// Properties
		internal IList<object> SerializedStates { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		internal SafeSerializationEventArgs(StreamingContext streamingContext); // 0x0000000181500750-0x0000000181500810
	}
}
