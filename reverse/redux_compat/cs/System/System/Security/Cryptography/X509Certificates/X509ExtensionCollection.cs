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
	public sealed class X509ExtensionCollection : ICollection // TypeDefIndex: 8795
	{
		// Fields
		private static byte[] Empty; // 0x00
		private ArrayList _list; // 0x10
	
		// Properties
		public int Count { get; } // 0x0000000181592F20-0x0000000181592F50 
		public bool IsSynchronized { get; } // 0x0000000181501A10-0x0000000181501A40 
		public object SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
		public X509Extension this[string oid] { get => default; } // 0x0000000181BA0800-0x0000000181BA0A90 
	
		// Constructors
		public X509ExtensionCollection(); // 0x0000000181BA0790-0x0000000181BA0800
		static X509ExtensionCollection(); // 0x0000000181BA0720-0x0000000181BA0790
	
		// Methods
		public int Add(X509Extension extension); // 0x0000000181BA0450-0x0000000181BA04E0
		void ICollection.CopyTo(Array array, int index); // 0x0000000181BA0570-0x0000000181BA0690
		public X509ExtensionEnumerator GetEnumerator(); // 0x0000000181BA04E0-0x0000000181BA0570
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181BA0690-0x0000000181BA0720
	}
}
