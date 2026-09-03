/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq
{
	[Nullable(0)]
	[NullableContext(2)]
	public class JTokenWriter : JsonWriter // TypeDefIndex: 10339
	{
		// Fields
		private JContainer _token; // 0x60
		private JContainer _parent; // 0x68
		private JValue _value; // 0x70
		private JToken _current; // 0x78
	
		// Properties
		public JToken CurrentToken { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		public JToken Token { get; } // 0x0000000181763C80-0x0000000181763CA0 
	
		// Constructors
		[NullableContext(1)]
		public JTokenWriter(JContainer container); // 0x0000000181763BE0-0x0000000181763C80
		public JTokenWriter(); // 0x0000000181763B90-0x0000000181763BE0
	
		// Methods
		[NullableContext(1)]
		internal override Task WriteTokenAsync(JsonReader reader, bool writeChildren, bool writeDateConstructorAsDate, bool writeComments, CancellationToken cancellationToken); // 0x0000000181762520-0x0000000181762630
		public override void Flush(); // 0x00000001802E76C0-0x00000001802E76D0
		public override void Close(); // 0x0000000181762020-0x0000000181762030
		public override void WriteStartObject(); // 0x0000000181762480-0x0000000181762520
		[NullableContext(1)]
		private void AddParent(JContainer container); // 0x0000000181761EF0-0x0000000181761F50
		private void RemoveParent(); // 0x0000000181762030-0x00000001817620C0
		public override void WriteStartArray(); // 0x0000000181762330-0x00000001817623D0
		[NullableContext(1)]
		public override void WriteStartConstructor(string name); // 0x00000001817623D0-0x0000000181762480
		protected override void WriteEnd(JsonToken token); // 0x0000000181762030-0x00000001817620C0
		[NullableContext(1)]
		public override void WritePropertyName(string name); // 0x00000001817621B0-0x00000001817622B0
		private void AddRawValue(object value, JTokenType type, JsonToken token); // 0x0000000181761F50-0x0000000181762020
		internal void AddJValue(JValue value, JsonToken token); // 0x0000000181761E10-0x0000000181761EF0
		public override void WriteValue(object value); // 0x0000000181763090-0x0000000181763130
		public override void WriteNull(); // 0x0000000181762180-0x00000001817621B0
		public override void WriteUndefined(); // 0x00000001817629D0-0x0000000181762A90
		public override void WriteRaw(string json); // 0x00000001817622B0-0x0000000181762330
		public override void WriteComment(string text); // 0x00000001817620C0-0x0000000181762180
		public override void WriteValue(string value); // 0x0000000181762B50-0x0000000181762C20
		public override void WriteValue(int value); // 0x0000000181763130-0x0000000181763190
		[CLSCompliant(false)]
		public override void WriteValue(uint value); // 0x0000000181762C20-0x0000000181762C80
		public override void WriteValue(long value); // 0x0000000181763190-0x00000001817632A0
		[CLSCompliant(false)]
		public override void WriteValue(ulong value); // 0x0000000181762E90-0x0000000181762F70
		public override void WriteValue(float value); // 0x0000000181762DA0-0x0000000181762E90
		public override void WriteValue(double value); // 0x0000000181763950-0x0000000181763A60
		public override void WriteValue(bool value); // 0x00000001817636D0-0x00000001817637E0
		public override void WriteValue(short value); // 0x00000001817637E0-0x0000000181763840
		[CLSCompliant(false)]
		public override void WriteValue(ushort value); // 0x0000000181763570-0x00000001817635D0
		public override void WriteValue(char value); // 0x0000000181763840-0x0000000181763950
		public override void WriteValue(byte value); // 0x0000000181762AF0-0x0000000181762B50
		[CLSCompliant(false)]
		public override void WriteValue(sbyte value); // 0x0000000181762A90-0x0000000181762AF0
		public override void WriteValue(decimal value); // 0x0000000181762C80-0x0000000181762DA0
		public override void WriteValue(DateTime value); // 0x0000000181763A60-0x0000000181763B90
		public override void WriteValue(DateTimeOffset value); // 0x0000000181763460-0x0000000181763570
		public override void WriteValue(byte[] value); // 0x00000001817632A0-0x0000000181763370
		public override void WriteValue(TimeSpan value); // 0x00000001817635D0-0x00000001817636D0
		public override void WriteValue(Guid value); // 0x0000000181763370-0x0000000181763460
		public override void WriteValue(Uri value); // 0x0000000181762F70-0x0000000181763090
		[NullableContext(1)]
		internal override void WriteToken(JsonReader reader, bool writeChildren, bool writeDateConstructorAsDate, bool writeComments); // 0x0000000181762630-0x00000001817629D0
	}
}
