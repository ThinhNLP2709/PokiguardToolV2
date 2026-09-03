/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 44: System.Numerics.dll - Assembly: System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 15302-15314

namespace System.Text
{
	[DefaultMember("Item")]
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	internal struct ValueStringBuilder // TypeDefIndex: 15314
	{
		// Fields
		private char[] _arrayToReturnToPool; // 0x00
		private Span<char> _chars; // 0x08
		private int _pos; // 0x18
	
		// Properties
		public int Length { get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Constructors
		public ValueStringBuilder(Span<char> initialBuffer); // 0x000000018148BD40-0x000000018148BD50
	
		// Methods
		public override string ToString(); // 0x000000018193D050-0x000000018193D0E0
		public bool TryCopyTo(Span<char> destination, out int charsWritten); // 0x000000018193D0E0-0x000000018193D190
		public void Insert(int index, char value, int count); // 0x000000018193CF10-0x000000018193D050
		public void Append(char c); // 0x000000018192EA40-0x000000018192EB50
		public void Append(string s); // 0x000000018192E920-0x000000018192EA40
		private void AppendSlow(string s); // 0x000000018193C9B0-0x000000018193CA80
		public void Append(char c, int count); // 0x000000018193CB10-0x000000018193CBA0
		public unsafe void Append(char* value, int length); // 0x000000018193CBA0-0x000000018193CC40
		public Span<char> AppendSpan(int length); // 0x000000018193CA80-0x000000018193CB10
		private void GrowAndAppend(char c); // 0x000000018193CD10-0x000000018193CD50
		private void Grow(int requiredAdditionalCapacity); // 0x000000018193CD50-0x000000018193CF10
		public void Dispose(); // 0x000000018193CC40-0x000000018193CD10
	}
}
