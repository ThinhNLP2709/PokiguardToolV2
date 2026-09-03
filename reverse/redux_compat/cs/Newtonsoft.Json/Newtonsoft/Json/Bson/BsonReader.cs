/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Bson
{
	[Obsolete("BSON reading and writing has been moved to its own package. See https://www.nuget.org/packages/Newtonsoft.Json.Bson for more details.")]
	public class BsonReader : JsonReader // TypeDefIndex: 10415
	{
		// Fields
		private const int MaxCharBytesSize = 128; // Metadata: 0x006A1079
		private static readonly byte[] SeqRange1; // 0x00
		private static readonly byte[] SeqRange2; // 0x08
		private static readonly byte[] SeqRange3; // 0x10
		private static readonly byte[] SeqRange4; // 0x18
		private readonly BinaryReader _reader; // 0x78
		private readonly List<ContainerContext> _stack; // 0x80
		private byte[] _byteBuffer; // 0x88
		private char[] _charBuffer; // 0x90
		private BsonType _currentElementType; // 0x98
		private BsonReaderState _bsonReaderState; // 0x9C
		private ContainerContext _currentContext; // 0xA0
		private bool _readRootValueAsArray; // 0xA8
		private bool _jsonNet35BinaryCompatibility; // 0xA9
		private DateTimeKind _dateTimeKindHandling; // 0xAC
	
		// Properties
		[Obsolete("JsonNet35BinaryCompatibility will be removed in a future version of Json.NET.")]
		public bool JsonNet35BinaryCompatibility { get; set; } // 0x0000000181773CF0-0x0000000181773D00 0x0000000181773D20-0x0000000181773D30
		public bool ReadRootValueAsArray { get; set; } // 0x0000000181773D00-0x0000000181773D10 0x0000000181773D30-0x0000000181773D40
		public DateTimeKind DateTimeKindHandling { get; set; } // 0x000000018158AF80-0x000000018158AF90 0x0000000181773D10-0x0000000181773D20
	
		// Nested types
		private enum BsonReaderState // TypeDefIndex: 10416
		{
			Normal = 0,
			ReferenceStart = 1,
			ReferenceRef = 2,
			ReferenceId = 3,
			CodeWScopeStart = 4,
			CodeWScopeCode = 5,
			CodeWScopeScope = 6,
			CodeWScopeScopeObject = 7,
			CodeWScopeScopeEnd = 8
		}
	
		private class ContainerContext // TypeDefIndex: 10417
		{
			// Fields
			public readonly BsonType Type; // 0x10
			public int Length; // 0x14
			public int Position; // 0x18
	
			// Constructors
			public ContainerContext(BsonType type); // 0x0000000180385630-0x0000000180385660
		}
	
		// Constructors
		public BsonReader(Stream stream); // 0x0000000181773AE0-0x0000000181773BE0
		public BsonReader(BinaryReader reader); // 0x0000000181773A20-0x0000000181773AE0
		public BsonReader(Stream stream, bool readRootValueAsArray, DateTimeKind dateTimeKindHandling); // 0x0000000181773BE0-0x0000000181773CF0
		public BsonReader(BinaryReader reader, bool readRootValueAsArray, DateTimeKind dateTimeKindHandling); // 0x0000000181773940-0x0000000181773A20
		static BsonReader(); // 0x0000000181773790-0x0000000181773940
	
		// Methods
		private string ReadElement(); // 0x0000000181772590-0x00000001817725E0
		public override bool Read(); // 0x0000000181773640-0x0000000181773790
		public override void Close(); // 0x0000000181771AA0-0x0000000181771AE0
		private bool ReadCodeWScope(); // 0x00000001817722E0-0x0000000181772550
		private bool ReadReference(); // 0x0000000181772A00-0x0000000181772CE0
		private bool ReadNormal(); // 0x00000001817726F0-0x0000000181772A00
		private void PopContext(); // 0x0000000181772010-0x00000001817720A0
		private void PushContext(ContainerContext newContext); // 0x00000001817720A0-0x0000000181772160
		private byte ReadByte(); // 0x0000000181772260-0x00000001817722A0
		private void ReadType(BsonType type); // 0x0000000181772F60-0x0000000181773600
		private byte[] ReadBinary(out BsonBinaryType binaryType); // 0x0000000181772160-0x0000000181772260
		private string ReadString(); // 0x0000000181772CE0-0x0000000181772F60
		private string ReadLengthString(); // 0x0000000181772660-0x00000001817726F0
		private string GetString(int length); // 0x0000000181771D40-0x0000000181771FF0
		private int GetLastFullCharStop(int start); // 0x0000000181771BB0-0x0000000181771D40
		private int BytesInSequence(byte b); // 0x0000000181771980-0x0000000181771AA0
		private void EnsureBuffers(); // 0x0000000181771AE0-0x0000000181771BB0
		private double ReadDouble(); // 0x0000000181772550-0x0000000181772590
		private int ReadInt32(); // 0x00000001817725E0-0x0000000181772620
		private long ReadInt64(); // 0x0000000181772620-0x0000000181772660
		private BsonType ReadType(); // 0x0000000181773600-0x0000000181773640
		private void MovePosition(int count); // 0x0000000181771FF0-0x0000000181772010
		private byte[] ReadBytes(int count); // 0x00000001817722A0-0x00000001817722E0
	}
}
