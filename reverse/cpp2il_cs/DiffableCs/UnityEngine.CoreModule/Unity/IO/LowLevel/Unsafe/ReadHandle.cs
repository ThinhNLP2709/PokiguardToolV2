namespace Unity.IO.LowLevel.Unsafe;

public struct ReadHandle : IDisposable
{
	[NativeDisableUnsafePtrRestriction]
	internal IntPtr ptr; //Field offset: 0x0
	internal int version; //Field offset: 0x8

	public JobHandle JobHandle
	{
		 get { } //Length: 225
	}

	public ReadStatus Status
	{
		 get { } //Length: 183
	}

	public void Cancel() { }

	[FreeFunction("AsyncReadManagerManaged::CancelReadRequest")]
	private static void CancelInternal(ReadHandle handle) { }

	private static void CancelInternal_Injected(in ReadHandle handle) { }

	public override void Dispose() { }

	public JobHandle get_JobHandle() { }

	public ReadStatus get_Status() { }

	[FreeFunction("AsyncReadManagerManaged::GetJobHandle", IsThreadSafe = True)]
	[ThreadAndSerializationSafe]
	private static JobHandle GetJobHandle(ReadHandle handle) { }

	private static void GetJobHandle_Injected(in ReadHandle handle, out JobHandle ret) { }

	[FreeFunction("AsyncReadManagerManaged::GetReadStatus", IsThreadSafe = True)]
	[ThreadAndSerializationSafe]
	private static ReadStatus GetReadStatus(ReadHandle handle) { }

	private static ReadStatus GetReadStatus_Injected(in ReadHandle handle) { }

	[FreeFunction("AsyncReadManagerManaged::IsReadHandleValid", IsThreadSafe = True)]
	[ThreadAndSerializationSafe]
	private static bool IsReadHandleValid(ReadHandle handle) { }

	private static bool IsReadHandleValid_Injected(in ReadHandle handle) { }

	public bool IsValid() { }

	[FreeFunction("AsyncReadManagerManaged::ReleaseReadHandle", IsThreadSafe = True)]
	[ThreadAndSerializationSafe]
	private static void ReleaseReadHandle(ReadHandle handle) { }

	private static void ReleaseReadHandle_Injected(in ReadHandle handle) { }

}

