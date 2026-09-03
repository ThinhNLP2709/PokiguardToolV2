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

namespace System.Collections
{
	[Serializable]
	public abstract class ReadOnlyCollectionBase : ICollection // TypeDefIndex: 3512
	{
		// Fields
		private ArrayList _list; // 0x10
	
		// Properties
		protected ArrayList InnerList { get; } // 0x000000018159DE90-0x000000018159DF00 
		public virtual int Count { get; } // 0x000000018159DE00-0x000000018159DE90 
		bool ICollection.IsSynchronized { get; } // 0x000000018159DCE0-0x000000018159DD70 
		object ICollection.SyncRoot { get; } // 0x000000018159DD70-0x000000018159DE00 
	
		// Constructors
		protected ReadOnlyCollectionBase(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		void ICollection.CopyTo(Array array, int index); // 0x000000018159DC30-0x000000018159DCE0
		public virtual IEnumerator GetEnumerator(); // 0x000000018159DBA0-0x000000018159DC30
	}
}
