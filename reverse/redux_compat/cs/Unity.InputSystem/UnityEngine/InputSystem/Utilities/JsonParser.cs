/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal struct JsonParser // TypeDefIndex: 6604
	{
		// Fields
		private readonly string m_Text; // 0x00
		private readonly int m_Length; // 0x08
		private int m_Position; // 0x0C
		private bool m_MatchAnyElementInArray; // 0x10
		private bool m_DryRun; // 0x11
	
		// Properties
		public bool isAtEnd { get; } // 0x0000000181CF27C0-0x0000000181CF27D0 
	
		// Nested types
		public enum JsonValueType // TypeDefIndex: 6605
		{
			None = 0,
			Bool = 1,
			Real = 2,
			Integer = 3,
			String = 4,
			Array = 5,
			Object = 6,
			Any = 7
		}
	
		public struct JsonString : IEquatable<JsonString> // TypeDefIndex: 6606
		{
			// Fields
			public Substring text; // 0x00
			public bool hasEscapes; // 0x10
	
			// Methods
			public override string ToString(); // 0x0000000181CF2A60-0x0000000181CF2B40
			public bool Equals(JsonString other); // 0x0000000181CF27D0-0x0000000181CF2970
			public override bool Equals(object obj); // 0x0000000181CF2970-0x0000000181CF2A10
			public override int GetHashCode(); // 0x0000000181CF2A10-0x0000000181CF2A60
			public static bool operator ==(JsonString left, JsonString right); // 0x0000000181CF2B40-0x0000000181CF2B70
			public static bool operator !=(JsonString left, JsonString right); // 0x0000000181CF2BB0-0x0000000181CF2BE0
			public static implicit operator JsonString(string str); // 0x0000000181CF2B70-0x0000000181CF2BB0
		}
	
		public struct JsonValue : IEquatable<JsonValue> // TypeDefIndex: 6607
		{
			// Fields
			public JsonValueType type; // 0x00
			public bool boolValue; // 0x04
			public double realValue; // 0x08
			public long integerValue; // 0x10
			public JsonString stringValue; // 0x18
			public List<JsonValue> arrayValue; // 0x30
			public Dictionary<string, JsonValue> objectValue; // 0x38
			public object anyValue; // 0x40
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 6608
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<JsonValue, string> __9__11_0; // 0x08
				public static Func<KeyValuePair<string, JsonValue>, string> __9__11_1; // 0x10
	
				// Constructors
				static __c(); // 0x0000000181D01B70-0x0000000181D01BE0
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal string _ToString_b__11_0(JsonValue x); // 0x0000000181D019A0-0x0000000181D019C0
				internal string _ToString_b__11_1(KeyValuePair<string, JsonValue> pair); // 0x0000000181D019C0-0x0000000181D01A50
			}
	
			// Methods
			public bool ToBoolean(); // 0x0000000181CF3A30-0x0000000181CF3AE0
			public long ToInteger(); // 0x0000000181CF3B90-0x0000000181CF3C30
			public double ToDouble(); // 0x0000000181CF3AE0-0x0000000181CF3B90
			public override string ToString(); // 0x0000000181CF3C30-0x0000000181CF4060
			public static implicit operator JsonValue(bool val); // 0x0000000181CF40B0-0x0000000181CF40E0
			public static implicit operator JsonValue(long val); // 0x0000000181CF4250-0x0000000181CF4280
			public static implicit operator JsonValue(double val); // 0x0000000181CF42D0-0x0000000181CF4300
			public static implicit operator JsonValue(string str); // 0x0000000181CF4130-0x0000000181CF41B0
			public static implicit operator JsonValue(JsonString str); // 0x0000000181CF4200-0x0000000181CF4250
			public static implicit operator JsonValue(List<JsonValue> array); // 0x0000000181CF40E0-0x0000000181CF4130
			public static implicit operator JsonValue(Dictionary<string, JsonValue> obj); // 0x0000000181CF4280-0x0000000181CF42D0
			public static implicit operator JsonValue(Enum val); // 0x0000000181CF41B0-0x0000000181CF4200
			public bool Equals(JsonValue other); // 0x0000000181CF2BE0-0x0000000181CF2EC0
			private static bool Equals(object obj, JsonValue value); // 0x0000000181CF2F80-0x0000000181CF38A0
			public override bool Equals(object obj); // 0x0000000181CF2EC0-0x0000000181CF2F80
			public override int GetHashCode(); // 0x0000000181CF38A0-0x0000000181CF3A30
			public static bool operator ==(JsonValue left, JsonValue right); // 0x0000000181CF4060-0x0000000181CF40B0
			public static bool operator !=(JsonValue left, JsonValue right); // 0x0000000181CF4300-0x0000000181CF4350
		}
	
		// Constructors
		public JsonParser(string json); // 0x0000000181CF2730-0x0000000181CF27C0
	
		// Methods
		public void Reset(); // 0x0000000181CF2460-0x0000000181CF2470
		public override string ToString(); // 0x0000000181CF2660-0x0000000181CF2730
		public bool NavigateToProperty(string path); // 0x0000000181CF1070-0x0000000181CF14A0
		public bool CurrentPropertyHasValueEqualTo(JsonValue expectedValue); // 0x0000000181CF0EC0-0x0000000181CF1070
		public bool ParseToken(char token); // 0x0000000181CF2120-0x0000000181CF21F0
		public bool ParseValue(); // 0x0000000181CF2420-0x0000000181CF2460
		public bool ParseValue(out JsonValue result); // 0x0000000181CF21F0-0x0000000181CF2420
		public bool ParseStringValue(out JsonValue result); // 0x0000000181CF1F30-0x0000000181CF2120
		public bool ParseArrayValue(out JsonValue result); // 0x0000000181CF14A0-0x0000000181CF1760
		public bool ParseObjectValue(out JsonValue result); // 0x0000000181CF1D10-0x0000000181CF1F30
		public bool ParseNumber(out JsonValue result); // 0x0000000181CF18C0-0x0000000181CF1D10
		public bool ParseBooleanValue(out JsonValue result); // 0x0000000181CF1760-0x0000000181CF1860
		public bool ParseNullValue(out JsonValue result); // 0x0000000181CF1860-0x0000000181CF18C0
		public bool SkipToValue(); // 0x0000000181CF2510-0x0000000181CF25E0
		private bool SkipString(string text); // 0x0000000181CF2470-0x0000000181CF2510
		private void SkipWhitespace(); // 0x0000000181CF25E0-0x0000000181CF2660
	}
}
