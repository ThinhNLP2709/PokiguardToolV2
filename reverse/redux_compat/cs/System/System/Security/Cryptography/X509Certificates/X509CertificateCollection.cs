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
	[Serializable]
	public class X509CertificateCollection : CollectionBase // TypeDefIndex: 8782
	{
		// Properties
		public X509Certificate this[int index] { get => default; } // 0x0000000181B98F70-0x0000000181B99010 
	
		// Nested types
		public class X509CertificateEnumerator : IEnumerator // TypeDefIndex: 8783
		{
			// Fields
			private IEnumerator enumerator; // 0x10
	
			// Properties
			public X509Certificate Current { get; } // 0x0000000181B991C0-0x0000000181B99260 
			object IEnumerator.Current { get; } // 0x0000000181B99100-0x0000000181B99150 
	
			// Constructors
			public X509CertificateEnumerator(X509CertificateCollection mappings); // 0x0000000181B99150-0x0000000181B991C0
	
			// Methods
			bool IEnumerator.MoveNext(); // 0x0000000181B99060-0x0000000181B990B0
			void IEnumerator.Reset(); // 0x0000000181B990B0-0x0000000181B99100
			public bool MoveNext(); // 0x0000000181B99010-0x0000000181B99060
		}
	
		// Constructors
		public X509CertificateCollection(); // 0x0000000181412020-0x0000000181412030
		public X509CertificateCollection(X509CertificateCollection value); // 0x0000000181B98E10-0x0000000181B98F70
	
		// Methods
		public int Add(X509Certificate value); // 0x0000000181B98CE0-0x0000000181B98D70
		public void AddRange(X509CertificateCollection value); // 0x0000000181B98B80-0x0000000181B98CE0
		public new X509CertificateEnumerator GetEnumerator(); // 0x0000000181B98D70-0x0000000181B98E10
		public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
	}
}
