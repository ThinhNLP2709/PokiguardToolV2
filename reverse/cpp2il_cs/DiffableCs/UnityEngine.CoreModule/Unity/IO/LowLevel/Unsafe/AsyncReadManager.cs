namespace Unity.IO.LowLevel.Unsafe;

[NativeHeader("Runtime/File/AsyncReadManagerManagedApi.h")]
public static class AsyncReadManager
{

	[FreeFunction("AsyncReadManagerManaged::ScheduleCloseRequest", IsThreadSafe = True)]
	[ThreadAndSerializationSafe]
	internal static JobHandle CloseFileAsync(in FileHandle fileHandle, JobHandle dependency) { }

	private static void CloseFileAsync_Injected(in FileHandle fileHandle, in JobHandle dependency, out JobHandle ret) { }

	public static ReadHandle GetFileInfo(string filename, FileInfoResult* result) { }

	[FreeFunction("AsyncReadManagerManaged::GetFileInfo", IsThreadSafe = True)]
	[ThreadAndSerializationSafe]
	private static ReadHandle GetFileInfoInternal(string filename, Void* cmd) { }

	private static void GetFileInfoInternal_Injected(ref ManagedSpanWrapper filename, Void* cmd, out ReadHandle ret) { }

	public static FileHandle OpenFileAsync(string fileName) { }

	[FreeFunction("AsyncReadManagerManaged::ScheduleOpenRequest", IsThreadSafe = True)]
	[ThreadAndSerializationSafe]
	private static FileHandle OpenFileAsync_Internal(string fileName) { }

	private static void OpenFileAsync_Internal_Injected(ref ManagedSpanWrapper fileName, out FileHandle ret) { }

	public static ReadHandle Read(in FileHandle fileHandle, ReadCommandArray readCmdArray) { }

	[FreeFunction("AsyncReadManagerManaged::ReadWithHandles_NativeCopy", IsThreadSafe = True)]
	[ThreadAndSerializationSafe]
	private static ReadHandle ReadWithHandlesInternal_NativeCopy(in FileHandle fileHandle, Void* readCmdArray) { }

	private static void ReadWithHandlesInternal_NativeCopy_Injected(in FileHandle fileHandle, Void* readCmdArray, out ReadHandle ret) { }

}

