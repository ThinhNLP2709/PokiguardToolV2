/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Dynamic;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Utilities;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq
{
	[Nullable(0)]
	[NullableContext(2)]
	public class JValue : JToken, IEquatable<JValue>, IFormattable, IComparable, IComparable<JValue>, IConvertible // TypeDefIndex: 10340
	{
		// Fields
		private JTokenType _valueType; // 0x30
		private object _value; // 0x38
	
		// Properties
		public override bool HasValues { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override JTokenType Type { get; } // 0x000000018033D100-0x000000018033D110 
		public object Value { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x0000000181768BF0-0x0000000181768CB0
	
		// Nested types
		[Nullable(new byte[2] {0, 1 })]
		[NullableContext(1)]
		private class JValueDynamicProxy : DynamicProxy<JValue> // TypeDefIndex: 10341
		{
			// Constructors
			public JValueDynamicProxy(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override bool TryConvert(JValue instance, ConvertBinder binder, [Nullable(2)] [NotNullWhen(true)] out object result); // 0x0000000181763FE0-0x0000000181764170
			public override bool TryBinaryOperation(JValue instance, BinaryOperationBinder binder, object arg, [Nullable(2)] [NotNullWhen(true)] out object result); // 0x0000000181763CA0-0x0000000181763FE0
		}
	
		// Constructors
		internal JValue(object value, JTokenType type); // 0x0000000181768410-0x0000000181768490
		[NullableContext(1)]
		internal JValue(JValue other, [Nullable(2)] JsonCloneSettings settings); // 0x0000000181768690-0x00000001817687A0
		[NullableContext(1)]
		public JValue(JValue other); // 0x0000000181768490-0x0000000181768560
		public JValue(long value); // 0x0000000181768140-0x00000001817681F0
		public JValue(decimal value); // 0x0000000181768A80-0x0000000181768B40
		public JValue(char value); // 0x0000000181768830-0x00000001817688C0
		[CLSCompliant(false)]
		public JValue(ulong value); // 0x00000001817680B0-0x0000000181768140
		public JValue(double value); // 0x00000001817681F0-0x00000001817682B0
		public JValue(float value); // 0x00000001817687A0-0x0000000181768830
		public JValue(DateTime value); // 0x0000000181768360-0x0000000181768410
		public JValue(DateTimeOffset value); // 0x0000000181768B40-0x0000000181768BF0
		public JValue(bool value); // 0x00000001817682B0-0x0000000181768360
		public JValue(string value); // 0x00000001817688C0-0x0000000181768930
		public JValue(Guid value); // 0x00000001817689F0-0x0000000181768A80
		public JValue(Uri value); // 0x0000000181768930-0x00000001817689F0
		public JValue(TimeSpan value); // 0x0000000181768560-0x0000000181768610
		public JValue(object value); // 0x0000000181768610-0x0000000181768690
	
		// Methods
		[NullableContext(1)]
		public override Task WriteToAsync(JsonWriter writer, CancellationToken cancellationToken, params JsonConverter[] converters); // 0x0000000181766D70-0x0000000181767740
		[NullableContext(1)]
		internal override bool DeepEquals(JToken node); // 0x00000001817654D0-0x0000000181765590
		[NullableContext(1)]
		private static int CompareBigInteger(BigInteger i1, object i2); // 0x00000001817642A0-0x00000001817645C0
		internal static int Compare(JTokenType valueType, object objA, object objB); // 0x00000001817646D0-0x0000000181765270
		[NullableContext(1)]
		private static int CompareFloat(object objA, object objB); // 0x00000001817645C0-0x00000001817646A0
		private static bool Operation(ExpressionType operation, object objA, object objB, out object result); // 0x0000000181765C70-0x0000000181766590
		[NullableContext(1)]
		internal override JToken CloneToken([Nullable(2)] JsonCloneSettings settings); // 0x0000000181764170-0x00000001817642A0
		[NullableContext(1)]
		public static JValue CreateComment([Nullable(2)] string value); // 0x0000000181765270-0x0000000181765310
		[NullableContext(1)]
		public static JValue CreateString([Nullable(2)] string value); // 0x00000001817653A0-0x0000000181765440
		[NullableContext(1)]
		public static JValue CreateNull(); // 0x0000000181765310-0x00000001817653A0
		[NullableContext(1)]
		public static JValue CreateUndefined(); // 0x0000000181765440-0x00000001817654D0
		private static JTokenType GetValueType(JTokenType? current, object value); // 0x0000000181765800-0x0000000181765C70
		private static JTokenType GetStringValueType(JTokenType? current); // 0x00000001817657D0-0x0000000181765800
		[NullableContext(1)]
		public override void WriteTo(JsonWriter writer, params JsonConverter[] converters); // 0x0000000181767740-0x00000001817680B0
		internal override int GetDeepHashCode(); // 0x00000001817656A0-0x0000000181765700
		[NullableContext(1)]
		private static bool ValuesEquals(JValue v1, JValue v2); // 0x0000000181766D20-0x0000000181766D70
		public bool Equals(JValue other); // 0x0000000181765650-0x00000001817656A0
		public override bool Equals(object obj); // 0x0000000181765590-0x0000000181765650
		public override int GetHashCode(); // 0x0000000181765700-0x0000000181765730
		[NullableContext(1)]
		public override string ToString(); // 0x0000000181766B50-0x0000000181766B90
		[NullableContext(1)]
		public string ToString(string format); // 0x0000000181766B90-0x0000000181766BE0
		[NullableContext(1)]
		public string ToString([Nullable(2)] IFormatProvider formatProvider); // 0x0000000181766D10-0x0000000181766D20
		public string ToString(string format, IFormatProvider formatProvider); // 0x0000000181766BE0-0x0000000181766D10
		[NullableContext(1)]
		protected override DynamicMetaObject GetMetaObject(Expression parameter); // 0x0000000181765730-0x00000001817657D0
		int IComparable.CompareTo(object obj); // 0x0000000181766590-0x0000000181766650
		public int CompareTo(JValue obj); // 0x00000001817646A0-0x00000001817646D0
		TypeCode IConvertible.GetTypeCode(); // 0x0000000181766650-0x00000001817666C0
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x00000001817666C0-0x0000000181766710
		char IConvertible.ToChar(IFormatProvider provider); // 0x0000000181766760-0x00000001817667B0
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x00000001817669B0-0x0000000181766A00
		byte IConvertible.ToByte(IFormatProvider provider); // 0x0000000181766710-0x0000000181766760
		short IConvertible.ToInt16(IFormatProvider provider); // 0x00000001817668C0-0x0000000181766910
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x0000000181766A60-0x0000000181766AB0
		int IConvertible.ToInt32(IFormatProvider provider); // 0x0000000181766910-0x0000000181766960
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x0000000181766AB0-0x0000000181766B00
		long IConvertible.ToInt64(IFormatProvider provider); // 0x0000000181766960-0x00000001817669B0
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x0000000181766B00-0x0000000181766B50
		float IConvertible.ToSingle(IFormatProvider provider); // 0x0000000181766A00-0x0000000181766A50
		double IConvertible.ToDouble(IFormatProvider provider); // 0x0000000181766870-0x00000001817668C0
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x0000000181766800-0x0000000181766870
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x00000001817667B0-0x0000000181766800
		[NullableContext(1)]
		object IConvertible.ToType(Type conversionType, [Nullable(2)] IFormatProvider provider); // 0x0000000181766A50-0x0000000181766A60
	}
}
