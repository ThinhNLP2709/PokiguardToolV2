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
	internal class EncoderNLS : Encoder // TypeDefIndex: 2711
	{
		// Fields
		internal char _charLeftOver; // 0x20
		private Encoding _encoding; // 0x28
		private bool _mustFlush; // 0x30
		internal bool _throwOnOverflow; // 0x31
		internal int _charsUsed; // 0x34
	
		// Properties
		public Encoding Encoding { get; } // 0x000000018033D240-0x000000018033D250 
		public bool MustFlush { get; } // 0x00000001802E8950-0x00000001802E8960 
		internal virtual bool HasState { get; } // 0x0000000181462840-0x0000000181462850 
	
		// Constructors
		internal EncoderNLS(Encoding encoding); // 0x00000001814627D0-0x0000000181462840
	
		// Methods
		public override void Reset(); // 0x00000001814627A0-0x00000001814627D0
		public override int GetByteCount(char[] chars, int index, int count, bool flush); // 0x00000001814620C0-0x0000000181462270
		public override unsafe int GetByteCount(char* chars, int count, bool flush); // 0x0000000181462270-0x0000000181462390
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush); // 0x0000000181462390-0x0000000181462640
		public override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, bool flush); // 0x0000000181462640-0x00000001814627A0
		public override void Convert(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, int byteCount, bool flush, out int charsUsed, out int bytesUsed, out bool completed); // 0x0000000181461D80-0x00000001814620C0
		public override unsafe void Convert(char* chars, int charCount, byte* bytes, int byteCount, bool flush, out int charsUsed, out int bytesUsed, out bool completed); // 0x0000000181461B80-0x0000000181461D80
		internal void ClearMustFlush(); // 0x00000001803ED880-0x00000001803ED890
	}
}
