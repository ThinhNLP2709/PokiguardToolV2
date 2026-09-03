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
	public sealed class X509ExtensionEnumerator : IEnumerator // TypeDefIndex: 8796
	{
		// Fields
		private IEnumerator enumerator; // 0x10
	
		// Properties
		public X509Extension Current { get; } // 0x0000000181BA0BE0-0x0000000181BA0C80 
		object IEnumerator.Current { get; } // 0x0000000181BA0B30-0x0000000181BA0B80 
	
		// Constructors
		internal X509ExtensionEnumerator(ArrayList list); // 0x0000000181BA0B80-0x0000000181BA0BE0
	
		// Methods
		public bool MoveNext(); // 0x0000000181BA0A90-0x0000000181BA0AE0
		public void Reset(); // 0x0000000181BA0AE0-0x0000000181BA0B30
	}
}
