/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Mono.Security;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.X509
{
	public class X509Extension // TypeDefIndex: 13827
	{
		// Fields
		protected string extnOid; // 0x10
		protected bool extnCritical; // 0x18
		protected ASN1 extnValue; // 0x20
	
		// Properties
		public string Oid { get; } // 0x0000000180377550-0x0000000180377560 
		public bool Critical { get; } // 0x0000000180F9E350-0x0000000180F9E360 
		public ASN1 Value { get; } // 0x0000000181417750-0x0000000181417790 
	
		// Constructors
		public X509Extension(ASN1 asn1); // 0x0000000181417290-0x00000001814175C0
		public X509Extension(X509Extension extension); // 0x00000001814175C0-0x0000000181417750
	
		// Methods
		protected virtual void Decode(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void Encode(); // 0x00000001802E76C0-0x00000001802E76D0
		public override bool Equals(object obj); // 0x0000000181416DD0-0x0000000181416F30
		public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
		private void WriteLine(StringBuilder sb, int n, int pos); // 0x0000000181417040-0x0000000181417290
		public override string ToString(); // 0x0000000181416F30-0x0000000181417040
	}
}
