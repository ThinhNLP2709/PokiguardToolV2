/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	public struct PrimitiveValue : IEquatable<UnityEngine.InputSystem.Utilities.PrimitiveValue>, IConvertible // TypeDefIndex: 6631
	{
		// Fields
		private TypeCode m_Type; // 0x00
		private bool m_BoolValue; // 0x04
		private char m_CharValue; // 0x04
		private byte m_ByteValue; // 0x04
		private sbyte m_SByteValue; // 0x04
		private short m_ShortValue; // 0x04
		private ushort m_UShortValue; // 0x04
		private int m_IntValue; // 0x04
		private uint m_UIntValue; // 0x04
		private long m_LongValue; // 0x04
		private ulong m_ULongValue; // 0x04
		private float m_FloatValue; // 0x04
		private double m_DoubleValue; // 0x04
	
		// Properties
		internal unsafe byte* valuePtr { get; } // 0x0000000181CFE200-0x0000000181CFE210 
		public TypeCode type { get; } // 0x0000000180732D10-0x0000000180732D20 
		public bool isEmpty { get; } // 0x00000001819337A0-0x00000001819337B0 
	
		// Constructors
		public PrimitiveValue(bool value); // 0x0000000181CFE160-0x0000000181CFE170
		public PrimitiveValue(char value); // 0x0000000181CFE0C0-0x0000000181CFE0E0
		public PrimitiveValue(byte value); // 0x0000000181CFE190-0x0000000181CFE1A0
		public PrimitiveValue(sbyte value); // 0x0000000181CFE0B0-0x0000000181CFE0C0
		public PrimitiveValue(short value); // 0x0000000181CFE140-0x0000000181CFE160
		public PrimitiveValue(ushort value); // 0x0000000181CFE1E0-0x0000000181CFE200
		public PrimitiveValue(int value); // 0x0000000181CFE1C0-0x0000000181CFE1E0
		public PrimitiveValue(uint value); // 0x0000000181CFE1A0-0x0000000181CFE1C0
		public PrimitiveValue(long value); // 0x0000000181CFE120-0x0000000181CFE140
		public PrimitiveValue(ulong value); // 0x0000000181CFE100-0x0000000181CFE120
		public PrimitiveValue(float value); // 0x0000000181CFE0E0-0x0000000181CFE100
		public PrimitiveValue(double value); // 0x0000000181CFE170-0x0000000181CFE190
	
		// Methods
		public PrimitiveValue ConvertTo(TypeCode type); // 0x0000000181CFC4A0-0x0000000181CFC740
		public bool Equals(PrimitiveValue other); // 0x0000000181CFC740-0x0000000181CFC780
		public override bool Equals(object obj); // 0x0000000181CFC780-0x0000000181CFC960
		public static bool operator ==(PrimitiveValue left, PrimitiveValue right); // 0x0000000181CFE210-0x0000000181CFE250
		public static bool operator !=(PrimitiveValue left, PrimitiveValue right); // 0x0000000181CFE250-0x0000000181CFE290
		public override int GetHashCode(); // 0x0000000181CFD490-0x0000000181CFD4F0
		public override string ToString(); // 0x0000000181CFDB40-0x0000000181CFDF60
		public static PrimitiveValue FromString(string value); // 0x0000000181CFD110-0x0000000181CFD430
		public TypeCode GetTypeCode(); // 0x0000000180732D10-0x0000000180732D20
		public bool ToBoolean(IFormatProvider provider = null); // 0x0000000181CFD4F0-0x0000000181CFD670
		public byte ToByte(IFormatProvider provider = null); // 0x0000000181CFD670-0x0000000181CFD680
		public char ToChar(IFormatProvider provider = null); // 0x0000000181CFD680-0x0000000181CFD730
		public DateTime ToDateTime(IFormatProvider provider = null); // 0x0000000181CFD730-0x0000000181CFD780
		public decimal ToDecimal(IFormatProvider provider = null); // 0x0000000181CFD780-0x0000000181CFD7C0
		public double ToDouble(IFormatProvider provider = null); // 0x0000000181CFD7C0-0x0000000181CFD8C0
		public short ToInt16(IFormatProvider provider = null); // 0x0000000181CFD670-0x0000000181CFD680
		public int ToInt32(IFormatProvider provider = null); // 0x0000000181CFD670-0x0000000181CFD680
		public long ToInt64(IFormatProvider provider = null); // 0x0000000181CFD8C0-0x0000000181CFD950
		public sbyte ToSByte(IFormatProvider provider = null); // 0x0000000181CFD670-0x0000000181CFD680
		public float ToSingle(IFormatProvider provider = null); // 0x0000000181CFDB20-0x0000000181CFDB40
		public string ToString(IFormatProvider provider); // 0x0000000181CFDF60-0x0000000181CFDF70
		public object ToType(Type conversionType, IFormatProvider provider); // 0x0000000181CFDF70-0x0000000181CFDFB0
		public ushort ToUInt16(IFormatProvider provider = null); // 0x0000000181CFDFB0-0x0000000181CFDFC0
		public uint ToUInt32(IFormatProvider provider = null); // 0x0000000181CFDFB0-0x0000000181CFDFC0
		public ulong ToUInt64(IFormatProvider provider = null); // 0x0000000181CFDFC0-0x0000000181CFE0B0
		public object ToObject(); // 0x0000000181CFD950-0x0000000181CFDB20
		public static PrimitiveValue From<TValue>(TValue value)
			where TValue : struct;
		public static PrimitiveValue FromObject(object value); // 0x0000000181CFCA40-0x0000000181CFD0D0
		public static implicit operator PrimitiveValue(bool value); // 0x0000000181CFC960-0x0000000181CFC980
		public static implicit operator PrimitiveValue(char value); // 0x0000000181CFC9A0-0x0000000181CFC9C0
		public static implicit operator PrimitiveValue(byte value); // 0x0000000181CFC980-0x0000000181CFC9A0
		public static implicit operator PrimitiveValue(sbyte value); // 0x0000000181CFD0D0-0x0000000181CFD0F0
		public static implicit operator PrimitiveValue(short value); // 0x0000000181CFC9E0-0x0000000181CFCA00
		public static implicit operator PrimitiveValue(ushort value); // 0x0000000181CFD430-0x0000000181CFD450
		public static implicit operator PrimitiveValue(int value); // 0x0000000181CFCA00-0x0000000181CFCA20
		public static implicit operator PrimitiveValue(uint value); // 0x0000000181CFD450-0x0000000181CFD470
		public static implicit operator PrimitiveValue(long value); // 0x0000000181CFCA20-0x0000000181CFCA40
		public static implicit operator PrimitiveValue(ulong value); // 0x0000000181CFD470-0x0000000181CFD490
		public static implicit operator PrimitiveValue(float value); // 0x0000000181CFD0F0-0x0000000181CFD110
		public static implicit operator PrimitiveValue(double value); // 0x0000000181CFC9C0-0x0000000181CFC9E0
		public static PrimitiveValue FromBoolean(bool value); // 0x0000000181CFC960-0x0000000181CFC980
		public static PrimitiveValue FromChar(char value); // 0x0000000181CFC9A0-0x0000000181CFC9C0
		public static PrimitiveValue FromByte(byte value); // 0x0000000181CFC980-0x0000000181CFC9A0
		public static PrimitiveValue FromSByte(sbyte value); // 0x0000000181CFD0D0-0x0000000181CFD0F0
		public static PrimitiveValue FromInt16(short value); // 0x0000000181CFC9E0-0x0000000181CFCA00
		public static PrimitiveValue FromUInt16(ushort value); // 0x0000000181CFD430-0x0000000181CFD450
		public static PrimitiveValue FromInt32(int value); // 0x0000000181CFCA00-0x0000000181CFCA20
		public static PrimitiveValue FromUInt32(uint value); // 0x0000000181CFD450-0x0000000181CFD470
		public static PrimitiveValue FromInt64(long value); // 0x0000000181CFCA20-0x0000000181CFCA40
		public static PrimitiveValue FromUInt64(ulong value); // 0x0000000181CFD470-0x0000000181CFD490
		public static PrimitiveValue FromSingle(float value); // 0x0000000181CFD0F0-0x0000000181CFD110
		public static PrimitiveValue FromDouble(double value); // 0x0000000181CFC9C0-0x0000000181CFC9E0
	}
}
