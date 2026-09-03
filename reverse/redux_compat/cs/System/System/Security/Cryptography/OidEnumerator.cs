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

namespace System.Security.Cryptography
{
	public sealed class OidEnumerator : IEnumerator // TypeDefIndex: 8757
	{
		// Fields
		private readonly OidCollection _oids; // 0x10
		private int _current; // 0x18
	
		// Properties
		public Oid Current { get; } // 0x0000000181B773F0-0x0000000181B77420 
		object IEnumerator.Current { get; } // 0x0000000181B773F0-0x0000000181B77420 
	
		// Constructors
		internal OidEnumerator(OidCollection oids); // 0x0000000181560590-0x00000001815605D0
	
		// Methods
		public bool MoveNext(); // 0x0000000181B773B0-0x0000000181B773F0
		public void Reset(); // 0x00000001810FCE00-0x00000001810FCE10
	}
}
