/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Util
{
	internal sealed class Tokenizer // TypeDefIndex: 2757
	{
		// Fields
		public int LineNo; // 0x10
		private int _inProcessingTag; // 0x14
		private byte[] _inBytes; // 0x18
		private char[] _inChars; // 0x20
		private string _inString; // 0x28
		private int _inIndex; // 0x30
		private int _inSize; // 0x34
		private int _inSavedCharacter; // 0x38
		private TokenSource _inTokenSource; // 0x3C
		private ITokenReader _inTokenReader; // 0x40
		private StringMaker _maker; // 0x48
		private string[] _searchStrings; // 0x50
		private string[] _replaceStrings; // 0x58
		private int _inNestedIndex; // 0x60
		private int _inNestedSize; // 0x64
		private string _inNestedString; // 0x68
	
		// Nested types
		private enum TokenSource // TypeDefIndex: 2758
		{
			UnicodeByteArray = 0,
			UTF8ByteArray = 1,
			ASCIIByteArray = 2,
			CharArray = 3,
			String = 4,
			NestedStrings = 5,
			Other = 6
		}
	
		[Serializable]
		internal sealed class StringMaker // TypeDefIndex: 2759
		{
			// Fields
			private string[] aStrings; // 0x10
			private uint cStringsMax; // 0x18
			private uint cStringsUsed; // 0x1C
			public StringBuilder _outStringBuilder; // 0x20
			public char[] _outChars; // 0x28
			public int _outIndex; // 0x30
	
			// Constructors
			public StringMaker(); // 0x0000000181484410-0x00000001814844A0
	
			// Methods
			private static uint HashString(string str); // 0x0000000181484040-0x00000001814840C0
			private static uint HashCharArray(char[] a, int l); // 0x0000000181483FD0-0x0000000181484040
			private bool CompareStringAndChars(string str, char[] a, int l); // 0x0000000181483F40-0x0000000181483FD0
			public string MakeString(); // 0x00000001814840C0-0x0000000181484410
		}
	
		internal interface ITokenReader // TypeDefIndex: 2760
		{
			// Methods
			int Read();
		}
	
		internal class StreamTokenReader : ITokenReader // TypeDefIndex: 2761
		{
			// Fields
			internal StreamReader _in; // 0x10
			internal int _numCharRead; // 0x18
	
			// Properties
			internal int NumCharEncountered { get; } // 0x0000000180B23260-0x0000000180B23270 
	
			// Constructors
			internal StreamTokenReader(StreamReader input); // 0x0000000181483F00-0x0000000181483F40
	
			// Methods
			public virtual int Read(); // 0x0000000181483EC0-0x0000000181483F00
		}
	
		// Constructors
		internal Tokenizer(string input); // 0x0000000181485990-0x0000000181485A50
	
		// Methods
		internal void BasicInitialization(); // 0x0000000181484BF0-0x0000000181484C70
		public void Recycle(); // 0x0000000181485940-0x0000000181485990
		internal void ChangeFormat(Encoding encoding); // 0x0000000181484C70-0x0000000181484F10
		internal void GetTokens(TokenizerStream stream, int maxNum, bool endAfterKet); // 0x0000000181484F30-0x0000000181485940
		private string GetStringToken(); // 0x0000000181484F10-0x0000000181484F30
	}
}
