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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Security
{
	[DefaultMember("Item")]
	internal class ASN1 // TypeDefIndex: 2119
	{
		// Fields
		private byte m_nTag; // 0x10
		private byte[] m_aValue; // 0x18
		private ArrayList elist; // 0x20
	
		// Properties
		public int Count { get; } // 0x0000000181400020-0x0000000181400050 
		public byte[] Value { get; } // 0x000000018142CA90-0x000000018142CB30 
	
		// Constructors
		public ASN1(byte tag); // 0x00000001813FFF90-0x00000001813FFFD0
		public ASN1(byte tag, byte[] data); // 0x00000001813FFFD0-0x0000000181400020
		public ASN1(byte[] data); // 0x000000018142C900-0x000000018142CA90
	
		// Methods
		public ASN1 Add(ASN1 asn1); // 0x000000018142BBD0-0x000000018142BC70
		public virtual byte[] GetBytes(); // 0x000000018142BF70-0x000000018142C600
		protected void Decode(byte[] asn1, ref int anPos, int anLength); // 0x000000018142BD90-0x000000018142BF70
		protected void DecodeTLV(byte[] asn1, ref int pos, out byte tag, out int length, out byte[] content); // 0x000000018142BC70-0x000000018142BD90
		public override string ToString(); // 0x000000018142C600-0x000000018142C900
	}
}
