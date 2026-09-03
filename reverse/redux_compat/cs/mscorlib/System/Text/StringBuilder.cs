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
	public sealed class StringBuilder : ISerializable // TypeDefIndex: 2718
	{
		// Fields
		internal char[] m_ChunkChars; // 0x10
		internal StringBuilder m_ChunkPrevious; // 0x18
		internal int m_ChunkLength; // 0x20
		internal int m_ChunkOffset; // 0x24
		internal int m_MaxCapacity; // 0x28
	
		// Properties
		public int Capacity { get; } // 0x000000018146B700-0x000000018146B720 
		public int MaxCapacity { get; } // 0x0000000180377930-0x0000000180377940 
		public int Length { get; set; } // 0x000000018146B7F0-0x000000018146B800 0x000000018146B9A0-0x000000018146BC40
		public char this[int index] { get => default; set {} } // 0x000000018146B720-0x000000018146B7F0 0x000000018146B880-0x000000018146B9A0
		private Span<char> RemainingCurrentChunk { get; } // 0x000000018146B800-0x000000018146B880 
	
		// Constructors
		public StringBuilder(); // 0x000000018146ACE0-0x000000018146AD40
		public StringBuilder(int capacity); // 0x000000018146AD40-0x000000018146AD50
		public StringBuilder(string value); // 0x000000018146B680-0x000000018146B6C0
		public StringBuilder(string value, int capacity); // 0x000000018146B6C0-0x000000018146B700
		public StringBuilder(string value, int startIndex, int length, int capacity); // 0x000000018146AF40-0x000000018146B230
		public StringBuilder(int capacity, int maxCapacity); // 0x000000018146AD50-0x000000018146AF40
		private StringBuilder(SerializationInfo info, StreamingContext context); // 0x000000018146B230-0x000000018146B570
		private StringBuilder(StringBuilder from); // 0x000000018146B610-0x000000018146B680
		private StringBuilder(int size, int maxCapacity, StringBuilder previousBlock); // 0x000000018146B570-0x000000018146B610
	
		// Methods
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018146A620-0x000000018146A750
		public override string ToString(); // 0x000000018146ABB0-0x000000018146ACE0
		public string ToString(int startIndex, int length); // 0x000000018146A980-0x000000018146ABB0
		public StringBuilder Clear(); // 0x0000000181468690-0x00000001814686B0
		public StringBuilder Append(char value, int repeatCount); // 0x0000000181468320-0x00000001814684A0
		public StringBuilder Append(char[] value, int startIndex, int charCount); // 0x00000001814680F0-0x00000001814682D0
		public StringBuilder Append(string value); // 0x0000000181467CC0-0x0000000181467DC0
		private void AppendHelper(string value); // 0x0000000181467C10-0x0000000181467C60
		public StringBuilder Append(string value, int startIndex, int count); // 0x00000001814684A0-0x0000000181468690
		public StringBuilder Append(StringBuilder value); // 0x0000000181468070-0x00000001814680B0
		private StringBuilder AppendCore(StringBuilder value, int startIndex, int count); // 0x0000000181466C50-0x0000000181466EA0
		public StringBuilder AppendLine(); // 0x0000000181467C60-0x0000000181467C90
		public StringBuilder AppendLine(string value); // 0x0000000181467C90-0x0000000181467CC0
		public void CopyTo(int sourceIndex, Span<char> destination, int count); // 0x00000001814686B0-0x00000001814688E0
		public StringBuilder Remove(int startIndex, int length); // 0x0000000181469760-0x0000000181469A50
		public StringBuilder Append(char value); // 0x0000000181468000-0x0000000181468070
		public StringBuilder Append(byte value); // 0x0000000181467DD0-0x0000000181467DE0
		public StringBuilder Append(int value); // 0x0000000181467DC0-0x0000000181467DD0
		public StringBuilder Append(long value); // 0x0000000181467FF0-0x0000000181468000
		[CLSCompliant(false)]
		public StringBuilder Append(uint value); // 0x0000000181467FE0-0x0000000181467FF0
		private StringBuilder AppendSpanFormattable<T>(T value)
			where T : IFormattable;
		public StringBuilder Append(object value); // 0x0000000181467DE0-0x0000000181467E30
		public StringBuilder Append(char[] value); // 0x00000001814680B0-0x00000001814680F0
		public StringBuilder Append(ReadOnlySpan<char> value); // 0x00000001814682D0-0x0000000181468320
		public StringBuilder Insert(int index, string value); // 0x00000001814691D0-0x0000000181469290
		public StringBuilder Insert(int index, char value); // 0x0000000181468B50-0x0000000181468B80
		public StringBuilder AppendFormat(string format, object arg0); // 0x0000000181467BA0-0x0000000181467C10
		public StringBuilder AppendFormat(string format, object arg0, object arg1); // 0x0000000181467B20-0x0000000181467BA0
		public StringBuilder AppendFormat(string format, object arg0, object arg1, object arg2); // 0x0000000181467980-0x0000000181467A10
		public StringBuilder AppendFormat(string format, params object[] args); // 0x00000001814678B0-0x0000000181467980
		public StringBuilder AppendFormat(IFormatProvider provider, string format, object arg0); // 0x0000000181467AA0-0x0000000181467B20
		public StringBuilder AppendFormat(IFormatProvider provider, string format, object arg0, object arg1, object arg2); // 0x0000000181467A10-0x0000000181467AA0
		private static void FormatError(); // 0x0000000181468B00-0x0000000181468B50
		internal StringBuilder AppendFormatHelper(IFormatProvider provider, string format, ParamsArray args); // 0x0000000181466EA0-0x00000001814678B0
		public StringBuilder Replace(string oldValue, string newValue); // 0x000000018146A510-0x000000018146A540
		public StringBuilder Replace(string oldValue, string newValue, int startIndex, int count); // 0x000000018146A000-0x000000018146A510
		[CLSCompliant(false)]
		public unsafe StringBuilder Append(char* value, int valueCount); // 0x0000000181467E30-0x0000000181467FE0
		private unsafe void Insert(int index, char* value, int valueCount); // 0x0000000181468B80-0x00000001814691D0
		private void ReplaceAllInChunk(int[] replacements, int replacementsCount, StringBuilder sourceChunk, int removeCount, string value); // 0x0000000181469C20-0x0000000181469E30
		private bool StartsWith(StringBuilder chunk, int indexInChunk, int count, string value); // 0x000000018146A540-0x000000018146A620
		private unsafe void ReplaceInPlaceAtChunk(ref StringBuilder chunk, ref int indexInChunk, char* value, int count); // 0x0000000181469E30-0x000000018146A000
		private static unsafe void ThreadSafeCopy(char* sourcePtr, char[] destination, int destinationIndex, int count); // 0x000000018146A750-0x000000018146A820
		private static void ThreadSafeCopy(char[] source, int sourceIndex, Span<char> destination, int destinationIndex, int count); // 0x000000018146A820-0x000000018146A980
		private StringBuilder FindChunkForIndex(int index); // 0x0000000181468AC0-0x0000000181468B00
		private StringBuilder Next(StringBuilder chunk); // 0x0000000181469710-0x0000000181469760
		private void ExpandByABlock(int minBlockCharCount); // 0x00000001814688E0-0x0000000181468AC0
		private void MakeRoom(int index, int count, out StringBuilder chunk, out int indexInChunk, bool doNotMoveFollowingChars); // 0x0000000181469290-0x0000000181469710
		private void Remove(int startIndex, int count, out StringBuilder chunk, out int indexInChunk); // 0x0000000181469A50-0x0000000181469C20
	}
}
