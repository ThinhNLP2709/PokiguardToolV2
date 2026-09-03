/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Text
{
	[Serializable]
	internal class Latin1Encoding : EncodingNLS, ISerializable // TypeDefIndex: 2716
	{
		// Fields
		internal static readonly Latin1Encoding s_default; // 0x00
		private static readonly char[] arrayCharBestFit; // 0x08
	
		// Constructors
		public Latin1Encoding(); // 0x0000000181466A40-0x0000000181466A50
		internal Latin1Encoding(SerializationInfo info, StreamingContext context); // 0x00000001814669F0-0x0000000181466A40
		static Latin1Encoding(); // 0x00000001814668A0-0x00000001814669F0
	
		// Methods
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001814667C0-0x00000001814668A0
		internal override unsafe int GetByteCount(char* chars, int charCount, EncoderNLS encoder); // 0x0000000181465DC0-0x0000000181466030
		internal override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, EncoderNLS encoder); // 0x0000000181466030-0x00000001814664C0
		internal override unsafe int GetCharCount(byte* bytes, int count, DecoderNLS decoder); // 0x0000000180720D20-0x0000000180720D30
		internal override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount, DecoderNLS decoder); // 0x00000001814664C0-0x0000000181466540
		public override int GetMaxByteCount(int charCount); // 0x0000000181466540-0x0000000181466680
		public override int GetMaxCharCount(int byteCount); // 0x0000000181466680-0x00000001814667C0
		internal override char[] GetBestFitUnicodeToBytesData(); // 0x0000000181465D70-0x0000000181465DC0
	}
}
