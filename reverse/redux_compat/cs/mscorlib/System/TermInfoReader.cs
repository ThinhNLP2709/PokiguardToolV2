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

namespace System
{
	internal class TermInfoReader // TypeDefIndex: 2490
	{
		// Fields
		private int boolSize; // 0x10
		private int numSize; // 0x14
		private int strOffsets; // 0x18
		private byte[] buffer; // 0x20
		private int booleansOffset; // 0x28
		private int intOffset; // 0x2C
	
		// Constructors
		public TermInfoReader(string term, string filename); // 0x0000000181660A00-0x0000000181660C30
		public TermInfoReader(string term, byte[] buffer); // 0x0000000181660960-0x0000000181660A00
	
		// Methods
		private void DetermineVersion(short magic); // 0x0000000181660060-0x0000000181660110
		private void ReadHeader(byte[] buffer, ref int position); // 0x0000000181660640-0x00000001816608B0
		private void ReadNames(byte[] buffer, ref int position); // 0x00000001816608B0-0x0000000181660960
		public int Get(TermInfoNumbers number); // 0x0000000181660580-0x0000000181660640
		public string Get(TermInfoStrings tstr); // 0x0000000181660420-0x0000000181660580
		public byte[] GetStringBytes(TermInfoStrings tstr); // 0x0000000181660220-0x0000000181660390
		private short GetInt16(byte[] buffer, int offset); // 0x0000000181660110-0x0000000181660170
		private string GetString(byte[] buffer, int offset); // 0x0000000181660390-0x0000000181660420
		private byte[] GetStringBytes(byte[] buffer, int offset); // 0x0000000181660170-0x0000000181660220
	}
}
