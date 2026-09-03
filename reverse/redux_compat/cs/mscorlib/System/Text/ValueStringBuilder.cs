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

namespace System.Text
{
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	internal struct ValueStringBuilder // TypeDefIndex: 2733
	{
		// Fields
		private char[] _arrayToReturnToPool; // 0x00
		private Span<char> _chars; // 0x08
		private int _pos; // 0x18
	
		// Properties
		public int Length { get; } // 0x0000000180B23260-0x0000000180B23270 
		public ref char this[int index] { get => default; } // 0x000000018148BD50-0x000000018148BD70 
	
		// Constructors
		public ValueStringBuilder(Span<char> initialBuffer); // 0x000000018148BD40-0x000000018148BD50
	
		// Methods
		public override string ToString(); // 0x000000018148BC00-0x000000018148BC90
		public bool TryCopyTo(Span<char> destination, out int charsWritten); // 0x000000018148BC90-0x000000018148BD40
		public void Append(char c); // 0x0000000181474A10-0x0000000181474B20
		public void Append(string s); // 0x000000018148B750-0x000000018148B870
		private void AppendSlow(string s); // 0x000000018148B550-0x000000018148B620
		public void Append(char c, int count); // 0x000000018148B870-0x000000018148B900
		public unsafe void Append(char* value, int length); // 0x000000018148B6B0-0x000000018148B750
		public Span<char> AppendSpan(int length); // 0x000000018148B620-0x000000018148B6B0
		private void GrowAndAppend(char c); // 0x000000018148B9D0-0x000000018148BA40
		private void Grow(int requiredAdditionalCapacity); // 0x000000018148BA40-0x000000018148BC00
		public void Dispose(); // 0x000000018148B900-0x000000018148B9D0
	}
}
