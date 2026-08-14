namespace Unity.Collections;

[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
[NativeContainer]
public struct NativeReference : INativeDisposable, IDisposable, IEquatable<NativeReference`1<T>>
{
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct ReadOnly
	{
		[NativeDisableUnsafePtrRestriction]
		private readonly Void* m_Data; //Field offset: 0x0

		public T Value
		{
			 get { } //Length: 156
		}

		internal ReadOnly(Void* data) { }

		public T get_Value() { }

	}

	[NativeDisableUnsafePtrRestriction]
	internal Void* m_Data; //Field offset: 0x0
	internal AllocatorHandle m_AllocatorLabel; //Field offset: 0x0

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 8
	}

	public T Value
	{
		 get { } //Length: 156
		 set { } //Length: 225
	}

	public NativeReference`1(AllocatorHandle allocator, NativeArrayOptions options = 1) { }

	public NativeReference`1(T value, AllocatorHandle allocator) { }

	private static void Allocate(AllocatorHandle allocator, out NativeReference<T>& reference) { }

	public ReadOnly<T> AsReadOnly() { }

	public static void Copy(NativeReference<T> dst, NativeReference<T> src) { }

	public void CopyFrom(NativeReference<T> reference) { }

	public void CopyTo(NativeReference<T> reference) { }

	public override void Dispose() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	[ExcludeFromBurstCompatTesting("Equals boxes because Value does not implement IEquatable<T>")]
	public override bool Equals(NativeReference<T> other) { }

	[ExcludeFromBurstCompatTesting("Takes managed object")]
	public virtual bool Equals(object obj) { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	public T get_Value() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(NativeReference<T> left, NativeReference<T> right) { }

	public static ReadOnly<T> op_Implicit(NativeReference<T> nativeReference) { }

	public static bool op_Inequality(NativeReference<T> left, NativeReference<T> right) { }

	public void set_Value(T value) { }

}

