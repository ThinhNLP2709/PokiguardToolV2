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
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Bson
{
	[Obsolete("BSON reading and writing has been moved to its own package. See https://www.nuget.org/packages/Newtonsoft.Json.Bson for more details.")]
	public class BsonWriter : JsonWriter // TypeDefIndex: 10429
	{
		// Fields
		private readonly BsonBinaryWriter _writer; // 0x60
		private BsonToken _root; // 0x68
		private BsonToken _parent; // 0x70
		private string _propertyName; // 0x78
	
		// Properties
		public DateTimeKind DateTimeKindHandling { get; set; } // 0x00000001817758F0-0x0000000181775910 0x0000000181775910-0x0000000181775930
	
		// Constructors
		public BsonWriter(Stream stream); // 0x00000001817757F0-0x00000001817758F0
		public BsonWriter(BinaryWriter writer); // 0x0000000181775720-0x00000001817757F0
	
		// Methods
		public override void Flush(); // 0x00000001817743C0-0x0000000181774400
		protected override void WriteEnd(JsonToken token); // 0x0000000181774480-0x0000000181774500
		public override void WriteComment(string text); // 0x0000000181774430-0x0000000181774480
		public override void WriteStartConstructor(string name); // 0x0000000181774940-0x0000000181774990
		public override void WriteRaw(string json); // 0x00000001817746C0-0x0000000181774710
		public override void WriteRawValue(string json); // 0x0000000181774670-0x00000001817746C0
		public override void WriteStartArray(); // 0x0000000181774860-0x0000000181774940
		public override void WriteStartObject(); // 0x0000000181774990-0x0000000181774A70
		public override void WritePropertyName(string name); // 0x0000000181774630-0x0000000181774670
		public override void Close(); // 0x0000000181774370-0x00000001817743C0
		private void AddParent(BsonToken container); // 0x0000000181773ED0-0x0000000181773F10
		private void RemoveParent(); // 0x0000000181774400-0x0000000181774430
		private void AddValue(object value, BsonType type); // 0x00000001817742E0-0x0000000181774370
		internal void AddToken(BsonToken token); // 0x0000000181773F10-0x00000001817742E0
		public override void WriteValue(object value); // 0x0000000181774B30-0x0000000181774C60
		public override void WriteNull(); // 0x0000000181774500-0x0000000181774570
		public override void WriteUndefined(); // 0x0000000181774A70-0x0000000181774AE0
		public override void WriteValue(string value); // 0x0000000181775530-0x0000000181775610
		public override void WriteValue(int value); // 0x0000000181774D90-0x0000000181774DE0
		[CLSCompliant(false)]
		public override void WriteValue(uint value); // 0x0000000181774C60-0x0000000181774CF0
		public override void WriteValue(long value); // 0x0000000181774DE0-0x0000000181774E30
		[CLSCompliant(false)]
		public override void WriteValue(ulong value); // 0x0000000181774CF0-0x0000000181774D90
		public override void WriteValue(float value); // 0x0000000181775490-0x00000001817754E0
		public override void WriteValue(double value); // 0x0000000181775230-0x0000000181775280
		public override void WriteValue(bool value); // 0x00000001817753E0-0x0000000181775490
		public override void WriteValue(short value); // 0x0000000181774F90-0x0000000181774FE0
		[CLSCompliant(false)]
		public override void WriteValue(ushort value); // 0x0000000181774AE0-0x0000000181774B30
		public override void WriteValue(char value); // 0x0000000181774E30-0x0000000181774F10
		public override void WriteValue(byte value); // 0x0000000181775110-0x0000000181775160
		[CLSCompliant(false)]
		public override void WriteValue(sbyte value); // 0x00000001817754E0-0x0000000181775530
		public override void WriteValue(decimal value); // 0x0000000181774FE0-0x0000000181775060
		public override void WriteValue(DateTime value); // 0x0000000181775280-0x0000000181775330
		public override void WriteValue(DateTimeOffset value); // 0x0000000181774F10-0x0000000181774F90
		public override void WriteValue(byte[] value); // 0x0000000181775060-0x0000000181775110
		public override void WriteValue(Guid value); // 0x0000000181775330-0x00000001817753E0
		public override void WriteValue(TimeSpan value); // 0x0000000181775160-0x0000000181775230
		public override void WriteValue(Uri value); // 0x0000000181775610-0x0000000181775720
		public void WriteObjectId(byte[] value); // 0x0000000181774570-0x0000000181774630
		public void WriteRegex(string pattern, string options); // 0x0000000181774710-0x0000000181774860
	}
}
