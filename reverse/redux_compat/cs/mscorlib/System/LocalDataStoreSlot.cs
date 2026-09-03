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

namespace System
{
	[ComVisible(true)]
	public sealed class LocalDataStoreSlot // TypeDefIndex: 2408
	{
		// Fields
		private LocalDataStoreMgr m_mgr; // 0x10
		private int m_slot; // 0x18
		private long m_cookie; // 0x20
	
		// Properties
		internal LocalDataStoreMgr Manager { get; } // 0x0000000180377550-0x0000000180377560 
		internal int Slot { get; } // 0x0000000180B23260-0x0000000180B23270 
		internal long Cookie { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Constructors
		internal LocalDataStoreSlot(LocalDataStoreMgr mgr, int slot, long cookie); // 0x000000018163C4F0-0x000000018163C550
	
		// Methods
		~LocalDataStoreSlot(); // 0x000000018163C450-0x000000018163C4F0
	}
}
