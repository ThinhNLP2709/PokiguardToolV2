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

namespace Mono.Security
{
	public class ASN1 // TypeDefIndex: 13808
	{
		// Fields
		private byte m_nTag; // 0x10
		private byte[] m_aValue; // 0x18
		private ArrayList elist; // 0x20
	
		// Properties
		public int Count { get; } // 0x0000000181400020-0x0000000181400050 
		public byte Tag { get; } // 0x00000001805625D0-0x00000001805625E0 
		public int Length { get; } // 0x0000000181332730-0x0000000181332750 
		public byte[] Value { get; set; } // 0x0000000181400120-0x00000001814001C0 0x00000001814001C0-0x0000000181400280
		public ASN1 this[int index] { get => default; } // 0x0000000181400050-0x0000000181400120 
	
		// Constructors
		public ASN1(byte tag); // 0x00000001813FFF90-0x00000001813FFFD0
		public ASN1(byte tag, byte[] data); // 0x00000001813FFFD0-0x0000000181400020
		public ASN1(byte[] data); // 0x00000001813FFE00-0x00000001813FFF90
	
		// Methods
		private bool CompareArray(byte[] array1, byte[] array2); // 0x00000001813FEFC0-0x00000001813FF050
		public bool CompareValue(byte[] value); // 0x00000001813FF050-0x00000001813FF0D0
		public ASN1 Add(ASN1 asn1); // 0x00000001813FEF20-0x00000001813FEFC0
		public virtual byte[] GetBytes(); // 0x00000001813FF4C0-0x00000001813FFB00
		protected void Decode(byte[] asn1, ref int anPos, int anLength); // 0x00000001813FF1F0-0x00000001813FF3D0
		protected void DecodeTLV(byte[] asn1, ref int pos, out byte tag, out int length, out byte[] content); // 0x00000001813FF0D0-0x00000001813FF1F0
		public ASN1 Element(int index, byte anTag); // 0x00000001813FF3D0-0x00000001813FF4C0
		public override string ToString(); // 0x00000001813FFB00-0x00000001813FFE00
	}
}
