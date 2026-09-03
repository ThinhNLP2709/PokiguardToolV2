/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json
{
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	public class JsonValidatingReader : JsonReader, IJsonLineInfo // TypeDefIndex: 10059
	{
		// Fields
		private readonly JsonReader _reader; // 0x78
		private readonly Stack<SchemaScope> _stack; // 0x80
		private JsonSchema _schema; // 0x88
		private JsonSchemaModel _model; // 0x90
		private SchemaScope _currentScope; // 0x98
		[CompilerGenerated]
		private ValidationEventHandler ValidationEventHandler; // 0xA0
		private static readonly IList<JsonSchemaModel> EmptySchemaList; // 0x00
	
		// Properties
		public override object Value { get; } // 0x00000001816CFEE0-0x00000001816CFF10 
		public override int Depth { get; } // 0x00000001816CFDF0-0x00000001816CFE20 
		public override string Path { get; } // 0x00000001816CFE20-0x00000001816CFE50 
		public override char QuoteChar { get; protected internal set; } // 0x00000001816CFE50-0x00000001816CFE80 0x00000001802E76C0-0x00000001802E76D0
		public override JsonToken TokenType { get; } // 0x00000001816CFE80-0x00000001816CFEB0 
		public override Type ValueType { get; } // 0x00000001816CFEB0-0x00000001816CFEE0 
		private IList<JsonSchemaModel> CurrentSchemas { get; } // 0x00000001816CFDD0-0x00000001816CFDF0 
		private IList<JsonSchemaModel> CurrentMemberSchemas { get; } // 0x00000001816CF3B0-0x00000001816CFDD0 
		public JsonSchema Schema { get; set; } // 0x000000018038B8A0-0x000000018038B8B0 0x00000001816CFFC0-0x00000001816D0070
		public JsonReader Reader { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		int IJsonLineInfo.LineNumber { get; } // 0x00000001816CB590-0x00000001816CB5F0 
		int IJsonLineInfo.LinePosition { get; } // 0x00000001816CB5F0-0x00000001816CB650 
	
		// Events
		public event ValidationEventHandler ValidationEventHandler {
			add; // 0x00000001816CF300-0x00000001816CF3B0
			remove; // 0x00000001816CFF10-0x00000001816CFFC0
		}
	
		// Nested types
		private class SchemaScope // TypeDefIndex: 10060
		{
			// Fields
			private readonly JTokenType _tokenType; // 0x10
			private readonly IList<JsonSchemaModel> _schemas; // 0x18
			private readonly Dictionary<string, bool> _requiredProperties; // 0x20
			[CompilerGenerated]
			private string _CurrentPropertyName_k__BackingField; // 0x28
			[CompilerGenerated]
			private int _ArrayItemCount_k__BackingField; // 0x30
			[CompilerGenerated]
			private readonly bool _IsUniqueArray_k__BackingField; // 0x34
			[CompilerGenerated]
			private readonly IList<JToken> _UniqueArrayItems_k__BackingField; // 0x38
			[CompilerGenerated]
			private JTokenWriter _CurrentItemWriter_k__BackingField; // 0x40
	
			// Properties
			public string CurrentPropertyName { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
			public int ArrayItemCount { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
			public bool IsUniqueArray { [CompilerGenerated] get; } // 0x00000001816DAFD0-0x00000001816DAFE0 
			public IList<JToken> UniqueArrayItems { [CompilerGenerated] get; } // 0x00000001803272A0-0x00000001803272B0 
			public JTokenWriter CurrentItemWriter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
			public IList<JsonSchemaModel> Schemas { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public Dictionary<string, bool> RequiredProperties { get; } // 0x00000001802F8630-0x00000001802F8640 
			public JTokenType TokenType { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 10061
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<string, string> __9__27_0; // 0x08
				public static Func<string, bool> __9__27_1; // 0x10
				public static Func<JsonSchemaModel, bool> __9__27_2; // 0x18
				public static Func<KeyValuePair<string, JsonSchemaModel>, bool> __9__28_0; // 0x20
				public static Func<KeyValuePair<string, JsonSchemaModel>, string> __9__28_1; // 0x28
	
				// Constructors
				static __c(); // 0x00000001816E0430-0x00000001816E04A0
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal string _.ctor_b__27_0(string p); // 0x0000000180A68C50-0x0000000180A68C60
				internal bool _.ctor_b__27_1(string p); // 0x00000001802E7840-0x00000001802E7850
				internal bool _.ctor_b__27_2(JsonSchemaModel s); // 0x00000001816E03A0-0x00000001816E03C0
				internal bool _GetRequiredProperties_b__28_0(KeyValuePair<string, JsonSchemaModel> p); // 0x00000001816E0340-0x00000001816E0360
				internal string _GetRequiredProperties_b__28_1(KeyValuePair<string, JsonSchemaModel> p); // 0x0000000180691EA0-0x0000000180691EB0
			}
	
			// Constructors
			public SchemaScope(JTokenType tokenType, IList<JsonSchemaModel> schemas); // 0x00000001816DAC80-0x00000001816DAFD0
	
			// Methods
			private IEnumerable<string> GetRequiredProperties(JsonSchemaModel schema); // 0x00000001816DAA70-0x00000001816DAC80
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10062
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<JsonSchemaModel, bool> __9__50_0; // 0x08
			public static Func<JsonSchemaModel, bool> __9__50_1; // 0x10
			public static Func<JsonSchemaModel, bool> __9__50_2; // 0x18
			public static Func<bool, bool> __9__51_0; // 0x20
			public static Func<KeyValuePair<string, bool>, bool> __9__51_1; // 0x28
			public static Func<KeyValuePair<string, bool>, string> __9__51_2; // 0x30
	
			// Constructors
			static __c(); // 0x00000001816E03C0-0x00000001816E0430
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _WriteToken_b__50_0(JsonSchemaModel s); // 0x00000001816E0380-0x00000001816E03A0
			internal bool _WriteToken_b__50_1(JsonSchemaModel s); // 0x00000001816E03A0-0x00000001816E03C0
			internal bool _WriteToken_b__50_2(JsonSchemaModel s); // 0x00000001816E0380-0x00000001816E03A0
			internal bool _ValidateEndObject_b__51_0(bool v); // 0x00000001816E0360-0x00000001816E0370
			internal bool _ValidateEndObject_b__51_1(KeyValuePair<string, bool> kv); // 0x00000001816E0370-0x00000001816E0380
			internal string _ValidateEndObject_b__51_2(KeyValuePair<string, bool> kv); // 0x0000000180691EA0-0x0000000180691EB0
		}
	
		// Constructors
		public JsonValidatingReader(JsonReader reader); // 0x00000001816CF250-0x00000001816CF300
		static JsonValidatingReader(); // 0x00000001816CF1C0-0x00000001816CF250
	
		// Methods
		private void Push(SchemaScope scope); // 0x00000001816CBA80-0x00000001816CBAF0
		private new SchemaScope Pop(); // 0x00000001816CB6F0-0x00000001816CB790
		private void RaiseError(string message, JsonSchemaModel schema); // 0x00000001816CBAF0-0x00000001816CBD30
		private void OnValidationEvent(JsonSchemaException exception); // 0x00000001816CB650-0x00000001816CB6F0
		public override void Close(); // 0x00000001816CB010-0x00000001816CB050
		private void ValidateNotDisallowed(JsonSchemaModel schema); // 0x00000001816CE030-0x00000001816CE280
		private JsonSchemaType? GetCurrentNodeSchemaType(); // 0x00000001816CB0C0-0x00000001816CB240
		public override int? ReadAsInt32(); // 0x00000001816CBF50-0x00000001816CBFA0
		public override byte[] ReadAsBytes(); // 0x00000001816CBD80-0x00000001816CBDD0
		public override decimal? ReadAsDecimal(); // 0x00000001816CBE90-0x00000001816CBEF0
		public override double? ReadAsDouble(); // 0x00000001816CBEF0-0x00000001816CBF50
		public override bool? ReadAsBoolean(); // 0x00000001816CBD30-0x00000001816CBD80
		public override string ReadAsString(); // 0x00000001816CBFA0-0x00000001816CBFF0
		public override DateTime? ReadAsDateTime(); // 0x00000001816CBE30-0x00000001816CBE90
		public override DateTimeOffset? ReadAsDateTimeOffset(); // 0x00000001816CBDD0-0x00000001816CBE30
		public override bool Read(); // 0x00000001816CBFF0-0x00000001816CC060
		private void ValidateCurrentToken(); // 0x00000001816CC1E0-0x00000001816CCF70
		private void WriteToken(IList<JsonSchemaModel> schemas); // 0x00000001816CE870-0x00000001816CF1C0
		private void ValidateEndObject(JsonSchemaModel schema); // 0x00000001816CD150-0x00000001816CD470
		private void ValidateEndArray(JsonSchemaModel schema); // 0x00000001816CCF70-0x00000001816CD150
		private void ValidateNull(JsonSchemaModel schema); // 0x00000001816CE280-0x00000001816CE2C0
		private void ValidateBoolean(JsonSchemaModel schema); // 0x00000001816CC1A0-0x00000001816CC1E0
		private void ValidateString(JsonSchemaModel schema); // 0x00000001816CE490-0x00000001816CE870
		private void ValidateInteger(JsonSchemaModel schema); // 0x00000001816CD980-0x00000001816CE030
		private void ProcessValue(); // 0x00000001816CB790-0x00000001816CBA80
		private void ValidateFloat(JsonSchemaModel schema); // 0x00000001816CD470-0x00000001816CD980
		private static double FloatingPointRemainder(double dividend, double divisor); // 0x00000001816CB050-0x00000001816CB0C0
		private static bool IsZero(double value); // 0x00000001816CB4D0-0x00000001816CB530
		private void ValidatePropertyName(JsonSchemaModel schema); // 0x00000001816CE2E0-0x00000001816CE490
		private bool IsPropertyDefinied(JsonSchemaModel schema, string propertyName); // 0x00000001816CB240-0x00000001816CB4D0
		private bool ValidateArray(JsonSchemaModel schema); // 0x00000001816CC180-0x00000001816CC1A0
		private bool ValidateObject(JsonSchemaModel schema); // 0x00000001816CE2C0-0x00000001816CE2E0
		private bool TestType(JsonSchemaModel currentSchema, JsonSchemaType currentType); // 0x00000001816CC060-0x00000001816CC180
		bool IJsonLineInfo.HasLineInfo(); // 0x00000001816CB530-0x00000001816CB590
	}
}
