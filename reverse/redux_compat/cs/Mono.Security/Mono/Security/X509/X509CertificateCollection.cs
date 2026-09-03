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

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.X509
{
	[Serializable]
	public class X509CertificateCollection : CollectionBase, IEnumerable // TypeDefIndex: 13823
	{
		// Properties
		public X509Certificate this[int index] { get => default; } // 0x0000000181412030-0x00000001814120D0 
	
		// Nested types
		public class X509CertificateEnumerator : IEnumerator // TypeDefIndex: 13824
		{
			// Fields
			private IEnumerator enumerator; // 0x10
	
			// Properties
			public X509Certificate Current { get; } // 0x0000000181412280-0x0000000181412320 
			object IEnumerator.Current { get; } // 0x00000001814121C0-0x0000000181412210 
	
			// Constructors
			public X509CertificateEnumerator(X509CertificateCollection mappings); // 0x0000000181412210-0x0000000181412280
	
			// Methods
			bool IEnumerator.MoveNext(); // 0x0000000181412120-0x0000000181412170
			void IEnumerator.Reset(); // 0x0000000181412170-0x00000001814121C0
			public bool MoveNext(); // 0x00000001814120D0-0x0000000181412120
		}
	
		// Constructors
		public X509CertificateCollection(); // 0x0000000181412020-0x0000000181412030
	
		// Methods
		public int Add(X509Certificate value); // 0x0000000181411C30-0x0000000181411CC0
		public void AddRange(X509CertificateCollection value); // 0x0000000181411AD0-0x0000000181411C30
		public bool Contains(X509Certificate value); // 0x0000000181411D30-0x0000000181411D50
		public new X509CertificateEnumerator GetEnumerator(); // 0x0000000181411D50-0x0000000181411DF0
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181411FF0-0x0000000181412020
		public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
		public int IndexOf(X509Certificate value); // 0x0000000181411E20-0x0000000181411FF0
		private bool Compare(byte[] array1, byte[] array2); // 0x0000000181411CC0-0x0000000181411D30
	}
}
