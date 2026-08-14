namespace UnityEngine.InputSystem.Utilities;

public struct PrimitiveValue : IEquatable<PrimitiveValue>, IConvertible
{
	private TypeCode m_Type; //Field offset: 0x0
	private bool m_BoolValue; //Field offset: 0x4
	private char m_CharValue; //Field offset: 0x4
	private byte m_ByteValue; //Field offset: 0x4
	private sbyte m_SByteValue; //Field offset: 0x4
	private short m_ShortValue; //Field offset: 0x4
	private ushort m_UShortValue; //Field offset: 0x4
	private int m_IntValue; //Field offset: 0x4
	private uint m_UIntValue; //Field offset: 0x4
	private long m_LongValue; //Field offset: 0x4
	private ulong m_ULongValue; //Field offset: 0x4
	private float m_FloatValue; //Field offset: 0x4
	private double m_DoubleValue; //Field offset: 0x4

	public bool isEmpty
	{
		 get { } //Length: 7
	}

	public TypeCode type
	{
		 get { } //Length: 3
	}

	internal Byte* valuePtr
	{
		internal get { } //Length: 5
	}

	public PrimitiveValue(int value) { }

	public PrimitiveValue(double value) { }

	public PrimitiveValue(float value) { }

	public PrimitiveValue(bool value) { }

	public PrimitiveValue(char value) { }

	public PrimitiveValue(byte value) { }

	public PrimitiveValue(sbyte value) { }

	public PrimitiveValue(short value) { }

	public PrimitiveValue(ushort value) { }

	public PrimitiveValue(ulong value) { }

	public PrimitiveValue(uint value) { }

	public PrimitiveValue(long value) { }

	public PrimitiveValue ConvertTo(TypeCode type) { }

	public override bool Equals(PrimitiveValue other) { }

	public virtual bool Equals(object obj) { }

	public static PrimitiveValue From(TValue value) { }

	public static PrimitiveValue FromBoolean(bool value) { }

	public static PrimitiveValue FromByte(byte value) { }

	public static PrimitiveValue FromChar(char value) { }

	public static PrimitiveValue FromDouble(double value) { }

	public static PrimitiveValue FromInt16(short value) { }

	public static PrimitiveValue FromInt32(int value) { }

	public static PrimitiveValue FromInt64(long value) { }

	public static PrimitiveValue FromObject(object value) { }

	public static PrimitiveValue FromSByte(sbyte value) { }

	public static PrimitiveValue FromSingle(float value) { }

	public static PrimitiveValue FromString(string value) { }

	public static PrimitiveValue FromUInt16(ushort value) { }

	public static PrimitiveValue FromUInt32(uint value) { }

	public static PrimitiveValue FromUInt64(ulong value) { }

	public bool get_isEmpty() { }

	public TypeCode get_type() { }

	internal Byte* get_valuePtr() { }

	public virtual int GetHashCode() { }

	public override TypeCode GetTypeCode() { }

	public static bool op_Equality(PrimitiveValue left, PrimitiveValue right) { }

	public static PrimitiveValue op_Implicit(int value) { }

	public static PrimitiveValue op_Implicit(float value) { }

	public static PrimitiveValue op_Implicit(ulong value) { }

	public static PrimitiveValue op_Implicit(long value) { }

	public static PrimitiveValue op_Implicit(uint value) { }

	public static PrimitiveValue op_Implicit(ushort value) { }

	public static PrimitiveValue op_Implicit(short value) { }

	public static PrimitiveValue op_Implicit(sbyte value) { }

	public static PrimitiveValue op_Implicit(byte value) { }

	public static PrimitiveValue op_Implicit(char value) { }

	public static PrimitiveValue op_Implicit(bool value) { }

	public static PrimitiveValue op_Implicit(double value) { }

	public static bool op_Inequality(PrimitiveValue left, PrimitiveValue right) { }

	public override bool ToBoolean(IFormatProvider provider = null) { }

	public override byte ToByte(IFormatProvider provider = null) { }

	public override char ToChar(IFormatProvider provider = null) { }

	public override DateTime ToDateTime(IFormatProvider provider = null) { }

	public override decimal ToDecimal(IFormatProvider provider = null) { }

	public override double ToDouble(IFormatProvider provider = null) { }

	public override short ToInt16(IFormatProvider provider = null) { }

	public override int ToInt32(IFormatProvider provider = null) { }

	public override long ToInt64(IFormatProvider provider = null) { }

	public object ToObject() { }

	public override sbyte ToSByte(IFormatProvider provider = null) { }

	public override float ToSingle(IFormatProvider provider = null) { }

	public virtual string ToString() { }

	public override string ToString(IFormatProvider provider) { }

	public override object ToType(Type conversionType, IFormatProvider provider) { }

	public override ushort ToUInt16(IFormatProvider provider = null) { }

	public override uint ToUInt32(IFormatProvider provider = null) { }

	public override ulong ToUInt64(IFormatProvider provider = null) { }

}

