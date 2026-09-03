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
	internal sealed class LocalDataStore // TypeDefIndex: 2407
	{
		// Fields
		private LocalDataStoreElement[] m_DataTable; // 0x10
		private LocalDataStoreMgr m_Manager; // 0x18
	
		// Constructors
		public LocalDataStore(LocalDataStoreMgr mgr, int InitialCapacity); // 0x000000018163CB00-0x000000018163CB80
	
		// Methods
		internal void Dispose(); // 0x000000018163C550-0x000000018163C580
		public object GetData(LocalDataStoreSlot slot); // 0x000000018163C5E0-0x000000018163C710
		public void SetData(LocalDataStoreSlot slot, object data); // 0x000000018163C9C0-0x000000018163CB00
		internal void FreeData(int slot, long cookie); // 0x000000018163C580-0x000000018163C5E0
		private LocalDataStoreElement PopulateElement(LocalDataStoreSlot slot); // 0x000000018163C710-0x000000018163C9C0
	}
}
