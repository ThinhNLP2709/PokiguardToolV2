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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	internal class IllogicalCallContext // TypeDefIndex: 2961
	{
		// Fields
		private Hashtable m_Datastore; // 0x10
		private object m_HostContext; // 0x18
	
		// Properties
		private Hashtable Datastore { get; } // 0x00000001814DD7D0-0x00000001814DD840 
		internal object HostContext { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		internal bool HasUserData { get; } // 0x00000001814DD840-0x00000001814DD880 
	
		// Constructors
		public IllogicalCallContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void FreeNamedDataSlot(string name); // 0x00000001814DD730-0x00000001814DD7D0
		public IllogicalCallContext CreateCopy(); // 0x00000001814DD410-0x00000001814DD730
	}
}
