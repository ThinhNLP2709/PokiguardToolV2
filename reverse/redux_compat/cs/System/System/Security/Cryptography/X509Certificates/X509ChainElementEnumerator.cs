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
	public sealed class X509ChainElementEnumerator : IEnumerator // TypeDefIndex: 8788
	{
		// Fields
		private IEnumerator enumerator; // 0x10
	
		// Properties
		public X509ChainElement Current { get; } // 0x0000000181B99D20-0x0000000181B99DC0 
		object IEnumerator.Current { get; } // 0x0000000181B99C60-0x0000000181B99CB0 
	
		// Constructors
		internal X509ChainElementEnumerator(IEnumerable enumerable); // 0x0000000181B99CB0-0x0000000181B99D20
	
		// Methods
		public bool MoveNext(); // 0x0000000181B99BC0-0x0000000181B99C10
		public void Reset(); // 0x0000000181B99C10-0x0000000181B99C60
	}
}
