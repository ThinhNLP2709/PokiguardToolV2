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
using System.Runtime.Versioning;
using System.Text;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Bson
{
	internal class BsonBinaryWriter // TypeDefIndex: 10413
	{
		// Fields
		private static readonly Encoding Encoding; // 0x00
		private readonly BinaryWriter _writer; // 0x10
		private byte[] _largeByteBuffer; // 0x18
		[CompilerGenerated]
		private DateTimeKind _DateTimeKindHandling_k__BackingField; // 0x20
	
		// Properties
		public DateTimeKind DateTimeKindHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
	
		// Constructors
		public BsonBinaryWriter(BinaryWriter writer); // 0x0000000181771370-0x00000001817713B0
		static BsonBinaryWriter(); // 0x00000001817712F0-0x0000000181771370
	
		// Methods
		public void Flush(); // 0x0000000181770170-0x00000001817701A0
		public void Close(); // 0x0000000181738F00-0x0000000181738F30
		public void WriteToken(BsonToken t); // 0x0000000181771120-0x0000000181771150
		private void WriteTokenInternal(BsonToken t); // 0x0000000181770380-0x0000000181771120
		private void WriteString(string s, int byteCount, int? calculatedlengthPrefix); // 0x00000001817701A0-0x0000000181770380
		public void WriteUtf8Bytes(string s, int byteCount); // 0x0000000181771150-0x00000001817712F0
		private int CalculateSize(int stringByteCount); // 0x000000018176FA70-0x000000018176FA80
		private int CalculateSizeWithLength(int stringByteCount, bool includeSize); // 0x000000018176FA60-0x000000018176FA70
		private int CalculateSize(BsonToken t); // 0x000000018176FA80-0x0000000181770170
	}
}
