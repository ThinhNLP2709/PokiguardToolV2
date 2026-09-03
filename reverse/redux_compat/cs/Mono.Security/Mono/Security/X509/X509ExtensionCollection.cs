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
using Mono.Security;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.X509
{
	public sealed class X509ExtensionCollection : CollectionBase, IEnumerable // TypeDefIndex: 13828
	{
		// Fields
		private bool readOnly; // 0x18
	
		// Properties
		public X509Extension this[string oid] { get => default; } // 0x0000000181416BD0-0x0000000181416DD0 
	
		// Constructors
		public X509ExtensionCollection(); // 0x0000000181412020-0x0000000181412030
		public X509ExtensionCollection(ASN1 asn1); // 0x0000000181416A90-0x0000000181416BD0
	
		// Methods
		public int IndexOf(string oid); // 0x0000000181416920-0x0000000181416A90
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181411FF0-0x0000000181412020
	}
}
