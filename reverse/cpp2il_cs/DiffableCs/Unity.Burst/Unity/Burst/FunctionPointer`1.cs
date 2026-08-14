namespace Unity.Burst;

[IsReadOnly]
public struct FunctionPointer : IFunctionPointer
{
	[NativeDisableUnsafePtrRestriction]
	private readonly IntPtr _ptr; //Field offset: 0x0

	public T Invoke
	{
		 get { } //Length: 118
	}

	public bool IsCreated
	{
		 get { } //Length: 8
	}

	public IntPtr Value
	{
		 get { } //Length: 4
	}

	public FunctionPointer`1(IntPtr ptr) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckIsCreated() { }

	public T get_Invoke() { }

	public bool get_IsCreated() { }

	public IntPtr get_Value() { }

	private override IFunctionPointer Unity.Burst.IFunctionPointer.FromIntPtr(IntPtr ptr) { }

}

