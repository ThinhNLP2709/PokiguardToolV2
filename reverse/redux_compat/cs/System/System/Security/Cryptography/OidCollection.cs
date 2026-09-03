/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography
{
	public sealed class OidCollection : ICollection // TypeDefIndex: 8756
	{
		// Fields
		private readonly List<Oid> _list; // 0x10
	
		// Properties
		public Oid this[int index] { get => default; } // 0x0000000180CAFA00-0x0000000180CAFA20 
		public int Count { get; } // 0x0000000180B5F570-0x0000000180B5F590 
		public bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public object SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
	
		// Constructors
		public OidCollection(); // 0x0000000181B77330-0x0000000181B773B0
	
		// Methods
		public int Add(Oid oid); // 0x0000000181B77010-0x0000000181B770D0
		public OidEnumerator GetEnumerator(); // 0x0000000181B770D0-0x0000000181B77140
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181B770D0-0x0000000181B77140
		void ICollection.CopyTo(Array array, int index); // 0x0000000181B77140-0x0000000181B77330
	}
}
