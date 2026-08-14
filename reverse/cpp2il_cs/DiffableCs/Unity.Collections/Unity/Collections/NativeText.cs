namespace Unity.Collections;

[DebuggerDisplay("Length = {Length}")]
[DefaultMember("Item")]
[GenerateTestsForBurstCompatibility]
[NativeContainer]
public struct NativeText : INativeList<Byte>, IIndexable<Byte>, INativeDisposable, IDisposable, IUTF8Bytes, IComparable<String>, IEquatable<String>, IComparable<NativeText>, IEquatable<NativeText>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
{
	internal struct Enumerator : IEnumerator<Rune>, IEnumerator, IDisposable
	{
		private ReadOnly target; //Field offset: 0x0
		private int offset; //Field offset: 0x8
		private Rune current; //Field offset: 0xC

		public override Rune Current
		{
			 get { } //Length: 4
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 67
		}

		public Enumerator(NativeText source) { }

		public Enumerator(ReadOnly source) { }

		public override void Dispose() { }

		public override Rune get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[DefaultMember("Item")]
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct ReadOnly : INativeList<Byte>, IIndexable<Byte>, IUTF8Bytes, IComparable<String>, IEquatable<String>, IComparable<NativeText>, IEquatable<NativeText>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes>
	{
		[NativeDisableUnsafePtrRestriction]
		internal UnsafeText* m_Data; //Field offset: 0x0

		public override int Capacity
		{
			[IsReadOnly]
			 get { } //Length: 100
			 set { } //Length: 3
		}

		public override bool IsEmpty
		{
			[IsReadOnly]
			 get { } //Length: 19
			 set { } //Length: 3
		}

		public override byte Item
		{
			[IsReadOnly]
			 get { } //Length: 62
			 set { } //Length: 3
		}

		public override int Length
		{
			[IsReadOnly]
			 get { } //Length: 128
			 set { } //Length: 3
		}

		[CreateProperty]
		[EditorBrowsable(EditorBrowsableState::Never (1))]
		[ExcludeFromBurstCompatTesting("Returns managed string")]
		public string Value
		{
			 get { } //Length: 88
		}

		internal ReadOnly(UnsafeText* text) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckNull(Void* dataPtr) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead() { }

		public override void Clear() { }

		public override int CompareTo(FixedString128Bytes other) { }

		public override int CompareTo(FixedString32Bytes other) { }

		public override int CompareTo(FixedString4096Bytes other) { }

		public override int CompareTo(NativeText other) { }

		public override int CompareTo(FixedString512Bytes other) { }

		public override int CompareTo(FixedString64Bytes other) { }

		public int CompareTo(ReadOnly other) { }

		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public override int CompareTo(string other) { }

		public override byte ElementAt(int index) { }

		public override bool Equals(FixedString32Bytes other) { }

		public override bool Equals(NativeText other) { }

		public bool Equals(ReadOnly other) { }

		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public override bool Equals(string other) { }

		[ExcludeFromBurstCompatTesting("Takes managed object")]
		public virtual bool Equals(object other) { }

		public override bool Equals(FixedString128Bytes other) { }

		public override bool Equals(FixedString512Bytes other) { }

		public override bool Equals(FixedString4096Bytes other) { }

		public override bool Equals(FixedString64Bytes other) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void ErrorWrite() { }

		[IsReadOnly]
		public override int get_Capacity() { }

		[IsReadOnly]
		public override bool get_IsEmpty() { }

		[IsReadOnly]
		public override byte get_Item(int index) { }

		[IsReadOnly]
		public override int get_Length() { }

		public string get_Value() { }

		public Enumerator GetEnumerator() { }

		public virtual int GetHashCode() { }

		public override Byte* GetUnsafePtr() { }

		public static bool op_Equality(in ReadOnly a, in FixedString64Bytes b) { }

		public static bool op_Equality(in ReadOnly a, in FixedString4096Bytes b) { }

		public static bool op_Equality(in ReadOnly a, in FixedString512Bytes b) { }

		public static bool op_Equality(in ReadOnly a, in FixedString32Bytes b) { }

		public static bool op_Equality(in ReadOnly a, in FixedString128Bytes b) { }

		public static bool op_Inequality(in ReadOnly a, in FixedString128Bytes b) { }

		public static bool op_Inequality(in ReadOnly a, in FixedString512Bytes b) { }

		public static bool op_Inequality(in ReadOnly a, in FixedString64Bytes b) { }

		public static bool op_Inequality(in ReadOnly a, in FixedString4096Bytes b) { }

		public static bool op_Inequality(in ReadOnly a, in FixedString32Bytes b) { }

		public override void set_Capacity(int value) { }

		public void set_IsEmpty(bool value) { }

		public override void set_Item(int index, byte value) { }

		public override void set_Length(int value) { }

		[ExcludeFromBurstCompatTesting("Returns managed string")]
		public virtual string ToString() { }

		public override bool TryResize(int newLength, NativeArrayOptions clearOptions = 1) { }

	}

	[NativeDisableUnsafePtrRestriction]
	internal UnsafeText* m_Data; //Field offset: 0x0

	public override int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 100
		 set { } //Length: 99
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 8
	}

	public override bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 19
	}

	public override byte Item
	{
		 get { } //Length: 62
		 set { } //Length: 75
	}

	public override int Length
	{
		[IsReadOnly]
		 get { } //Length: 128
		 set { } //Length: 11
	}

	[CreateProperty]
	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[ExcludeFromBurstCompatTesting("Returns managed string")]
	public string Value
	{
		 get { } //Length: 88
	}

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	public NativeText(string source, Allocator allocator) { }

	public NativeText(in FixedString4096Bytes source, AllocatorHandle allocator) { }

	public NativeText(in FixedString512Bytes source, Allocator allocator) { }

	public NativeText(in FixedString512Bytes source, AllocatorHandle allocator) { }

	public NativeText(in FixedString128Bytes source, Allocator allocator) { }

	public NativeText(in FixedString128Bytes source, AllocatorHandle allocator) { }

	public NativeText(in FixedString64Bytes source, Allocator allocator) { }

	public NativeText(in FixedString4096Bytes source, Allocator allocator) { }

	public NativeText(in FixedString64Bytes source, AllocatorHandle allocator) { }

	public NativeText(in FixedString32Bytes source, AllocatorHandle allocator) { }

	public NativeText(AllocatorHandle allocator) { }

	public NativeText(Allocator allocator) { }

	public NativeText(int capacity, AllocatorHandle allocator) { }

	public NativeText(int capacity, Allocator allocator) { }

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	public NativeText(string source, AllocatorHandle allocator) { }

	public NativeText(in FixedString32Bytes source, Allocator allocator) { }

	public void Add(in byte value) { }

	public ReadOnly AsReadOnly() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckIndexInRange(int index) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	internal static void CheckNull(Void* dataPtr) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[IsReadOnly]
	private void CheckRead() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckWrite() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[IsReadOnly]
	private void CheckWriteAndBumpSecondaryVersion() { }

	public override void Clear() { }

	public override int CompareTo(FixedString64Bytes other) { }

	public override int CompareTo(FixedString4096Bytes other) { }

	public override int CompareTo(FixedString512Bytes other) { }

	public override int CompareTo(FixedString128Bytes other) { }

	public override int CompareTo(FixedString32Bytes other) { }

	public override int CompareTo(NativeText other) { }

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	public override int CompareTo(string other) { }

	public int CompareTo(ReadOnly other) { }

	public override void Dispose() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override byte ElementAt(int index) { }

	[ExcludeFromBurstCompatTesting("Takes managed object")]
	public virtual bool Equals(object other) { }

	public override bool Equals(FixedString4096Bytes other) { }

	public override bool Equals(NativeText other) { }

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	public override bool Equals(string other) { }

	public override bool Equals(FixedString512Bytes other) { }

	public bool Equals(ReadOnly other) { }

	public override bool Equals(FixedString128Bytes other) { }

	public override bool Equals(FixedString32Bytes other) { }

	public override bool Equals(FixedString64Bytes other) { }

	[IsReadOnly]
	public override int get_Capacity() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public override bool get_IsEmpty() { }

	public override byte get_Item(int index) { }

	[IsReadOnly]
	public override int get_Length() { }

	public string get_Value() { }

	public Enumerator GetEnumerator() { }

	public virtual int GetHashCode() { }

	public override Byte* GetUnsafePtr() { }

	public static bool op_Equality(in NativeText a, in FixedString4096Bytes b) { }

	public static bool op_Equality(in NativeText a, in FixedString64Bytes b) { }

	public static bool op_Equality(in NativeText a, in FixedString512Bytes b) { }

	public static bool op_Equality(in NativeText a, in FixedString32Bytes b) { }

	public static bool op_Equality(in NativeText a, in FixedString128Bytes b) { }

	public static bool op_Inequality(in NativeText a, in FixedString512Bytes b) { }

	public static bool op_Inequality(in NativeText a, in FixedString4096Bytes b) { }

	public static bool op_Inequality(in NativeText a, in FixedString32Bytes b) { }

	public static bool op_Inequality(in NativeText a, in FixedString128Bytes b) { }

	public static bool op_Inequality(in NativeText a, in FixedString64Bytes b) { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, byte value) { }

	public override void set_Length(int value) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void ThrowCopyError(CopyError error, string source) { }

	[ExcludeFromBurstCompatTesting("Returns managed string")]
	public virtual string ToString() { }

	public override bool TryResize(int newLength, NativeArrayOptions clearOptions = 1) { }

}

