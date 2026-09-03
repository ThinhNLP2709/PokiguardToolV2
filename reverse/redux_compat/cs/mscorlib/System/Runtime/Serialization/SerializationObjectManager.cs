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
	public sealed class SerializationObjectManager // TypeDefIndex: 3028
	{
		// Fields
		private readonly Dictionary<object, object> _objectSeenTable; // 0x10
		private readonly StreamingContext _context; // 0x18
		private SerializationEventHandler _onSerializedHandler; // 0x28
	
		// Constructors
		public SerializationObjectManager(StreamingContext context); // 0x00000001814EB850-0x00000001814EB8E0
	
		// Methods
		public void RegisterObject(object obj); // 0x00000001814EB6B0-0x00000001814EB850
		public void RaiseOnSerializedEvent(); // 0x00000001814EB670-0x00000001814EB6B0
		private void AddOnSerialized(object obj); // 0x00000001814EB5D0-0x00000001814EB670
	}
}
