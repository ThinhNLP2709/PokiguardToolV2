namespace Unity.IntegerTime;

[NativeHeader("Runtime/Input/RationalTime.h")]
public struct RationalTime
{
	internal struct TicksPerSecond : IEquatable<TicksPerSecond>
	{
		public static readonly TicksPerSecond DefaultTicksPerSecond; //Field offset: 0x0
		public static readonly TicksPerSecond TicksPerSecond24; //Field offset: 0x8
		public static readonly TicksPerSecond TicksPerSecond25; //Field offset: 0x10
		public static readonly TicksPerSecond TicksPerSecond30; //Field offset: 0x18
		public static readonly TicksPerSecond TicksPerSecond50; //Field offset: 0x20
		public static readonly TicksPerSecond TicksPerSecond60; //Field offset: 0x28
		public static readonly TicksPerSecond TicksPerSecond120; //Field offset: 0x30
		public static readonly TicksPerSecond TicksPerSecond2397; //Field offset: 0x38
		public static readonly TicksPerSecond TicksPerSecond2425; //Field offset: 0x40
		public static readonly TicksPerSecond TicksPerSecond2997; //Field offset: 0x48
		public static readonly TicksPerSecond TicksPerSecond5994; //Field offset: 0x50
		public static readonly TicksPerSecond TicksPerSecond11988; //Field offset: 0x58
		internal static readonly TicksPerSecond DiscreteTimeRate; //Field offset: 0x60
		[SerializeField]
		private uint m_Numerator; //Field offset: 0x0
		[SerializeField]
		private uint m_Denominator; //Field offset: 0x4

		private static TicksPerSecond() { }

		public TicksPerSecond(uint num, uint den = 1) { }

		[IsReadOnly]
		public override bool Equals(TicksPerSecond rhs) { }

		[IsReadOnly]
		public virtual bool Equals(object rhs) { }

		private static uint Gcd(uint a, uint b) { }

		[IsReadOnly]
		public virtual int GetHashCode() { }

		private static void Simplify(ref uint num, ref uint den) { }

	}

	[SerializeField]
	private long m_Count; //Field offset: 0x0
	[SerializeField]
	private TicksPerSecond m_TicksPerSecond; //Field offset: 0x8

	public long Count
	{
		 get { } //Length: 4
	}

	public long get_Count() { }

	public static DiscreteTime op_Explicit(RationalTime t) { }

}

