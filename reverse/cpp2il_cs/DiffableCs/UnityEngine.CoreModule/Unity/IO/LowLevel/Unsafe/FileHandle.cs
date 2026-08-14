namespace Unity.IO.LowLevel.Unsafe;

[IsReadOnly]
public struct FileHandle
{
	[NativeDisableUnsafePtrRestriction]
	internal readonly IntPtr fileCommandPtr; //Field offset: 0x0
	internal readonly int version; //Field offset: 0x8

	public JobHandle JobHandle
	{
		 get { } //Length: 205
	}

	public JobHandle Close(JobHandle dependency = null) { }

	public JobHandle get_JobHandle() { }

	[FreeFunction("AsyncReadManagerManaged::GetJobFenceFromManagedHandle")]
	private static JobHandle GetJobHandle_Internal(in FileHandle handle) { }

	private static void GetJobHandle_Internal_Injected(in FileHandle handle, out JobHandle ret) { }

	[FreeFunction("AsyncReadManagerManaged::IsFileHandleValid")]
	private static bool IsFileHandleValid(in FileHandle handle) { }

	public bool IsValid() { }

}

