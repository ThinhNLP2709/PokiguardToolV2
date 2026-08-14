namespace Unity.IntegerTime;

public struct DiscreteTime : IEquatable<DiscreteTime>, IFormattable, IComparable<DiscreteTime>
{
	public static readonly DiscreteTime Zero; //Field offset: 0x0
	public static readonly DiscreteTime MinValue; //Field offset: 0x8
	public static readonly DiscreteTime MaxValue; //Field offset: 0x10
	private static readonly int TicksPerSecondBits; //Field offset: 0x18
	private static readonly int NonPow2TpsBits; //Field offset: 0x1C
	[SerializeField]
	public long Value; //Field offset: 0x0

	private static DiscreteTime() { }

	private DiscreteTime(long v, int _) { }

	public DiscreteTime(float v) { }

	public DiscreteTime(double v) { }

	[IsReadOnly]
	public override int CompareTo(DiscreteTime other) { }

	[IsReadOnly]
	public override bool Equals(DiscreteTime rhs) { }

	[IsReadOnly]
	public virtual bool Equals(object o) { }

	public static DiscreteTime FromTicks(long v) { }

	[IsReadOnly]
	public virtual int GetHashCode() { }

	public static DiscreteTime op_Addition(DiscreteTime lhs, DiscreteTime rhs) { }

	public static float op_Explicit(DiscreteTime d) { }

	public static double op_Explicit(DiscreteTime d) { }

	public static bool op_GreaterThan(DiscreteTime lhs, DiscreteTime rhs) { }

	public static bool op_GreaterThanOrEqual(DiscreteTime lhs, DiscreteTime rhs) { }

	public static bool op_Inequality(DiscreteTime lhs, DiscreteTime rhs) { }

	public static DiscreteTime op_Subtraction(DiscreteTime lhs, DiscreteTime rhs) { }

	[IsReadOnly]
	public virtual string ToString() { }

	[IsReadOnly]
	public override string ToString(string format, IFormatProvider formatProvider) { }

}

