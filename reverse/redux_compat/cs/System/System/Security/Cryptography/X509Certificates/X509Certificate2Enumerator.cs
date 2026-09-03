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
	public sealed class X509Certificate2Enumerator : IEnumerator // TypeDefIndex: 8778
	{
		// Fields
		private IEnumerator enumerator; // 0x10
	
		// Properties
		public X509Certificate2 Current { get; } // 0x0000000181B94830-0x0000000181B948D0 
		object IEnumerator.Current { get; } // 0x0000000181B94770-0x0000000181B947C0 
	
		// Constructors
		internal X509Certificate2Enumerator(X509Certificate2Collection collection); // 0x0000000181B947C0-0x0000000181B94830
	
		// Methods
		public bool MoveNext(); // 0x0000000181B94680-0x0000000181B946D0
		bool IEnumerator.MoveNext(); // 0x0000000181B946D0-0x0000000181B94720
		void IEnumerator.Reset(); // 0x0000000181B94720-0x0000000181B94770
	}
}
