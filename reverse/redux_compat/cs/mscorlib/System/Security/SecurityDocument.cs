/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security
{
	[Serializable]
	internal sealed class SecurityDocument // TypeDefIndex: 2746
	{
		// Fields
		internal byte[] m_data; // 0x10
	
		// Constructors
		public SecurityDocument(int numData); // 0x0000000181482170-0x00000001814821D0
	
		// Methods
		public void GuaranteeSize(int size); // 0x0000000181481E40-0x0000000181481EF0
		public void AddString(string str, ref int position); // 0x00000001814816A0-0x0000000181481870
		public void AppendString(string str, ref int position); // 0x0000000181481960-0x0000000181481A00
		public static int EncodedStringSize(string str); // 0x0000000181481A00-0x0000000181481A20
		public string GetString(ref int position, bool bCreate); // 0x0000000181481A70-0x0000000181481E40
		public void AddToken(byte b, ref int position); // 0x0000000181481870-0x0000000181481960
		public SecurityElement GetRootElement(); // 0x0000000181481A40-0x0000000181481A70
		public SecurityElement GetElement(int position, bool bCreate); // 0x0000000181481A20-0x0000000181481A40
		internal SecurityElement InternalGetElement(ref int position, bool bCreate); // 0x0000000181481EF0-0x0000000181482170
	}
}
