/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Contexts
{
	internal class DynamicPropertyCollection // TypeDefIndex: 2916
	{
		// Fields
		private ArrayList _properties; // 0x10
	
		// Properties
		public bool HasProperties { get; } // 0x00000001814DA6D0-0x00000001814DA700 
	
		// Nested types
		private class DynamicPropertyReg // TypeDefIndex: 2917
		{
			// Fields
			public IDynamicProperty Property; // 0x10
			public IDynamicMessageSink Sink; // 0x18
	
			// Constructors
			public DynamicPropertyReg(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public DynamicPropertyCollection(); // 0x00000001814DA660-0x00000001814DA6D0
	
		// Methods
		public bool RegisterDynamicProperty(IDynamicProperty prop); // 0x00000001814DA2B0-0x00000001814DA500
		public bool UnregisterDynamicProperty(string name); // 0x00000001814DA500-0x00000001814DA660
		public void NotifyMessage(bool start, IMessage msg, bool client_site, bool async); // 0x00000001814D9E20-0x00000001814DA2B0
		private int FindProperty(string name); // 0x00000001814D9CF0-0x00000001814D9E20
	}
}
