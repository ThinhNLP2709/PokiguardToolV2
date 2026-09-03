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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	public sealed class X509ChainElementCollection : ICollection // TypeDefIndex: 8787
	{
		// Fields
		private ArrayList _list; // 0x10
	
		// Properties
		public int Count { get; } // 0x0000000181592F20-0x0000000181592F50 
		public bool IsSynchronized { get; } // 0x0000000181501A10-0x0000000181501A40 
		public X509ChainElement this[int index] { get => default; } // 0x0000000181B99B20-0x0000000181B99BC0 
		public object SyncRoot { get; } // 0x0000000181592730-0x0000000181592760 
	
		// Constructors
		internal X509ChainElementCollection(); // 0x0000000181B99AB0-0x0000000181B99B20
	
		// Methods
		void ICollection.CopyTo(Array array, int index); // 0x0000000181592700-0x0000000181592730
		public X509ChainElementEnumerator GetEnumerator(); // 0x0000000181B99970-0x0000000181B99A10
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181B99A10-0x0000000181B99AB0
		internal void Add(X509Certificate2 certificate); // 0x0000000181B99780-0x0000000181B99830
		internal void Clear(); // 0x00000001818C1620-0x00000001818C1650
		internal bool Contains(X509Certificate2 certificate); // 0x0000000181B99830-0x0000000181B99970
	}
}
