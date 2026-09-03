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

namespace System
{
	internal sealed class LocalDataStoreMgr // TypeDefIndex: 2409
	{
		// Fields
		private bool[] m_SlotInfoTable; // 0x10
		private int m_FirstAvailableSlot; // 0x18
		private List<LocalDataStore> m_ManagedLocalDataStores; // 0x20
		private Dictionary<string, LocalDataStoreSlot> m_KeyToSlotMap; // 0x28
		private long m_CookieGenerator; // 0x30
	
		// Constructors
		public LocalDataStoreMgr(); // 0x000000018163C360-0x000000018163C450
	
		// Methods
		public LocalDataStoreHolder CreateLocalDataStore(); // 0x000000018163BC30-0x000000018163BE50
		public void DeleteLocalDataStore(LocalDataStore store); // 0x000000018163BE50-0x000000018163BF30
		public LocalDataStoreSlot AllocateDataSlot(); // 0x000000018163B890-0x000000018163BB20
		public LocalDataStoreSlot AllocateNamedDataSlot(string name); // 0x000000018163BB20-0x000000018163BC30
		public LocalDataStoreSlot GetNamedDataSlot(string name); // 0x000000018163C1C0-0x000000018163C2E0
		public void FreeNamedDataSlot(string name); // 0x000000018163C0E0-0x000000018163C1C0
		internal void FreeDataSlot(int slot, long cookie); // 0x000000018163BF30-0x000000018163C0E0
		public void ValidateSlot(LocalDataStoreSlot slot); // 0x000000018163C2E0-0x000000018163C360
		internal int GetSlotTableLength(); // 0x0000000180B5F570-0x0000000180B5F590
	}
}
