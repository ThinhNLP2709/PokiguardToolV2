namespace Unity.Collections;

[DebuggerDisplay("Length = {m_Length}")]
[DebuggerTypeProxy(typeof(NativeArrayDebugView`1))]
[DefaultMember("Item")]
[NativeContainer]
[NativeContainerSupportsDeallocateOnJobCompletion]
[NativeContainerSupportsDeferredConvertListToArray]
[NativeContainerSupportsMinMaxWriteRestriction]
public struct NativeArray : IDisposable, IEnumerable<T>, IEnumerable, IEquatable<NativeArray`1<T>>
{
	[ExcludeFromDocs]
	internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private NativeArray<T> m_Array; //Field offset: 0x0
		private int m_Index; //Field offset: 0x0
		private T value; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 6
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 94
		}

		public Enumerator(ref NativeArray<T>& array) { }

		public override void Dispose() { }

		public override T get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[DebuggerDisplay("Length = {Length}")]
	[DebuggerTypeProxy(typeof(NativeArrayReadOnlyDebugView`1))]
	[DefaultMember("Item")]
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct ReadOnly : IEnumerable<T>, IEnumerable
	{
		[ExcludeFromDocs]
		internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private ReadOnly<T> m_Array; //Field offset: 0x0
			private int m_Index; //Field offset: 0x0
			private T value; //Field offset: 0x0

			public override T Current
			{
				 get { } //Length: 4
			}

			private override object System.Collections.IEnumerator.Current
			{
				private get { } //Length: 94
			}

			public Enumerator(in ReadOnly<T> array) { }

			public override void Dispose() { }

			public override T get_Current() { }

			public override bool MoveNext() { }

			public override void Reset() { }

			private override object System.Collections.IEnumerator.get_Current() { }

		}

		[NativeDisableUnsafePtrRestriction]
		internal Void* m_Buffer; //Field offset: 0x0
		internal int m_Length; //Field offset: 0x0

		public T Item
		{
			 get { } //Length: 48
		}

		public int Length
		{
			 get { } //Length: 6
		}

		internal ReadOnly(Void* buffer, int length) { }

		[IsReadOnly]
		public ReadOnlySpan<T> AsReadOnlySpan() { }

		public T get_Item(int index) { }

		public int get_Length() { }

		public Enumerator<T> GetEnumerator() { }

		public static ReadOnlySpan<T> op_Implicit(in ReadOnly<T> source) { }

		private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		public T UnsafeElementAt(int index) { }

	}

	[NativeDisableUnsafePtrRestriction]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.ContentLoadModule", "UnityEngine.TilemapModule"})]
	internal Void* m_Buffer; //Field offset: 0x0
	internal int m_Length; //Field offset: 0x0
	internal Allocator m_AllocatorLabel; //Field offset: 0x0

	public bool IsCreated
	{
		 get { } //Length: 8
	}

	public T Item
	{
		 get { } //Length: 48
		[WriteAccessRequired]
		 set { } //Length: 61
	}

	public int Length
	{
		 get { } //Length: 6
	}

	public NativeArray`1(int length, Allocator allocator, NativeArrayOptions options = 1) { }

	public NativeArray`1(T[] array, Allocator allocator) { }

	public NativeArray`1(NativeArray<T> array, Allocator allocator) { }

	private static void Allocate(int length, Allocator allocator, out NativeArray<T>& array) { }

	public ReadOnly<T> AsReadOnly() { }

	[IsReadOnly]
	public ReadOnlySpan<T> AsReadOnlySpan() { }

	[IsReadOnly]
	[WriteAccessRequired]
	public Span<T> AsSpan() { }

	public static void Copy(NativeArray<T> src, int srcIndex, T[] dst, int dstIndex, int length) { }

	public static void Copy(T[] src, NativeArray<T> dst) { }

	public static void Copy(NativeArray<T> src, T[] dst) { }

	public static void Copy(NativeArray<T> src, NativeArray<T> dst, int length) { }

	public static void Copy(NativeArray<T> src, NativeArray<T> dst) { }

	public static void Copy(NativeArray<T> src, int srcIndex, NativeArray<T> dst, int dstIndex, int length) { }

	public static void Copy(NativeArray<T> src, T[] dst, int length) { }

	[WriteAccessRequired]
	public void CopyFrom(T[] array) { }

	[WriteAccessRequired]
	public void CopyFrom(NativeArray<T> array) { }

	private static void CopySafe(T[] src, int srcIndex, NativeArray<T> dst, int dstIndex, int length) { }

	private static void CopySafe(NativeArray<T> src, int srcIndex, NativeArray<T> dst, int dstIndex, int length) { }

	private static void CopySafe(NativeArray<T> src, int srcIndex, T[] dst, int dstIndex, int length) { }

	public void CopyTo(T[] array) { }

	public JobHandle Dispose(JobHandle inputDeps) { }

	[WriteAccessRequired]
	public override void Dispose() { }

	public override bool Equals(NativeArray<T> other) { }

	public virtual bool Equals(object obj) { }

	public bool get_IsCreated() { }

	public T get_Item(int index) { }

	public int get_Length() { }

	public Enumerator<T> GetEnumerator() { }

	public virtual int GetHashCode() { }

	public NativeArray<T> GetSubArray(int start, int length) { }

	private NativeArray<U> InternalReinterpret(int length) { }

	public static bool op_Equality(NativeArray<T> left, NativeArray<T> right) { }

	public static Span<T> op_Implicit(in NativeArray<T>& source) { }

	public static ReadOnlySpan<T> op_Implicit(in NativeArray<T>& source) { }

	public static bool op_Inequality(NativeArray<T> left, NativeArray<T> right) { }

	public NativeArray<U> Reinterpret() { }

	public NativeArray<U> Reinterpret(int expectedTypeSize) { }

	[WriteAccessRequired]
	public void set_Item(int index, T value) { }

	private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public T[] ToArray() { }

}

