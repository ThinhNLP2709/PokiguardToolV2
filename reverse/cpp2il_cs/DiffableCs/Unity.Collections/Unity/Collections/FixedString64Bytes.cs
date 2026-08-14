namespace Unity.Collections;

[DefaultMember("Item")]
[GenerateTestsForBurstCompatibility]
public struct FixedString64Bytes : INativeList<Byte>, IIndexable<Byte>, IUTF8Bytes, IComparable<String>, IEquatable<String>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
{
	internal struct Enumerator : IEnumerator
	{
		private FixedString64Bytes target; //Field offset: 0x0
		private int offset; //Field offset: 0x40
		private Rune current; //Field offset: 0x44

		public Rune Current
		{
			 get { } //Length: 4
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 67
		}

		public Enumerator(FixedString64Bytes other) { }

		public void Dispose() { }

		public Rune get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	internal const ushort utf8MaxLengthInBytes = 61; //Field offset: 0x0
	[SerializeField]
	internal ushort utf8LengthInBytes; //Field offset: 0x0
	[SerializeField]
	internal FixedBytes62 bytes; //Field offset: 0x2

	public override int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 6
		 set { } //Length: 3
	}

	public override bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 8
	}

	public override byte Item
	{
		[IsReadOnly]
		 get { } //Length: 9
		 set { } //Length: 9
	}

	public override int Length
	{
		[IsReadOnly]
		 get { } //Length: 4
		 set { } //Length: 12
	}

	public static int UTF8MaxLengthInBytes
	{
		 get { } //Length: 6
	}

	[CreateProperty]
	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[ExcludeFromBurstCompatTesting("Returns managed string")]
	public string Value
	{
		 get { } //Length: 57
	}

	public FixedString64Bytes(in FixedString64Bytes other) { }

	public FixedString64Bytes(in FixedString128Bytes other) { }

	public FixedString64Bytes(in FixedString32Bytes other) { }

	public FixedString64Bytes(in UnsafeText other) { }

	public FixedString64Bytes(ReadOnly other) { }

	public FixedString64Bytes(in FixedString512Bytes other) { }

	public FixedString64Bytes(Rune rune, int count = 1) { }

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	public FixedString64Bytes(string source) { }

	public FixedString64Bytes(in FixedString4096Bytes other) { }

	public void Add(in byte value) { }

	public FixedList64Bytes<Byte>& AsFixedList() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckCapacityInRange(int capacity) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckCopyError(CopyError error, string source) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckFormatError(FormatError error) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	[IsReadOnly]
	private void CheckIndexInRange(int index) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckLengthInRange(int length) { }

	public override void Clear() { }

	public override int CompareTo(FixedString4096Bytes other) { }

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	public override int CompareTo(string other) { }

	public override int CompareTo(FixedString64Bytes other) { }

	public override int CompareTo(FixedString128Bytes other) { }

	public override int CompareTo(FixedString512Bytes other) { }

	public override int CompareTo(FixedString32Bytes other) { }

	public override byte ElementAt(int index) { }

	public override bool Equals(FixedString32Bytes other) { }

	public override bool Equals(FixedString128Bytes other) { }

	public override bool Equals(FixedString64Bytes other) { }

	public override bool Equals(FixedString4096Bytes other) { }

	public override bool Equals(FixedString512Bytes other) { }

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	public override bool Equals(string other) { }

	[ExcludeFromBurstCompatTesting("Takes managed object")]
	public virtual bool Equals(object obj) { }

	[IsReadOnly]
	public override int get_Capacity() { }

	[IsReadOnly]
	public override bool get_IsEmpty() { }

	[IsReadOnly]
	public override byte get_Item(int index) { }

	[IsReadOnly]
	public override int get_Length() { }

	public static int get_UTF8MaxLengthInBytes() { }

	public string get_Value() { }

	public Enumerator GetEnumerator() { }

	public virtual int GetHashCode() { }

	[IsReadOnly]
	public override Byte* GetUnsafePtr() { }

	internal FormatError Initialize(in FixedString4096Bytes other) { }

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	internal CopyError Initialize(string source) { }

	internal FormatError Initialize(in FixedString512Bytes other) { }

	internal FormatError Initialize(Rune rune, int count = 1) { }

	internal FormatError Initialize(in FixedString64Bytes other) { }

	internal FormatError Initialize(in FixedString32Bytes other) { }

	internal FormatError Initialize(in FixedString128Bytes other) { }

	internal FormatError Initialize(Byte* srcBytes, int srcLength) { }

	public static bool op_Equality(in FixedString64Bytes a, in FixedString64Bytes b) { }

	public static bool op_Equality(in FixedString64Bytes a, in FixedString512Bytes b) { }

	public static bool op_Equality(in FixedString64Bytes a, in FixedString32Bytes b) { }

	public static bool op_Equality(in FixedString64Bytes a, in FixedString128Bytes b) { }

	public static bool op_Equality(in FixedString64Bytes a, in FixedString4096Bytes b) { }

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	public static FixedString64Bytes op_Implicit(string b) { }

	public static FixedString4096Bytes op_Implicit(in FixedString64Bytes fs) { }

	public static FixedString128Bytes op_Implicit(in FixedString64Bytes fs) { }

	public static FixedString512Bytes op_Implicit(in FixedString64Bytes fs) { }

	public static bool op_Inequality(in FixedString64Bytes a, in FixedString64Bytes b) { }

	public static bool op_Inequality(in FixedString64Bytes a, in FixedString128Bytes b) { }

	public static bool op_Inequality(in FixedString64Bytes a, in FixedString512Bytes b) { }

	public static bool op_Inequality(in FixedString64Bytes a, in FixedString32Bytes b) { }

	public static bool op_Inequality(in FixedString64Bytes a, in FixedString4096Bytes b) { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, byte value) { }

	public override void set_Length(int value) { }

	[ExcludeFromBurstCompatTesting("Returns managed string")]
	public virtual string ToString() { }

	public override bool TryResize(int newLength, NativeArrayOptions clearOptions = 1) { }

}

