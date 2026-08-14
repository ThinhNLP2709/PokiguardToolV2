namespace UnityEngine.UIElements;

[NativeHeader("Modules/UIElements/Core/Native/Renderer/UIPainter2D.bindings.h")]
internal static class UIPainter2D
{

	public static void ClearSnapshots(IntPtr handle) { }

	public static IntPtr Create(bool computeBBox = false) { }

	public static void Destroy(IntPtr handle) { }

	[ThreadSafe]
	public static MeshWriteDataInterface ExecuteSnapshotFromJob(IntPtr painterHandle, int i) { }

	private static void ExecuteSnapshotFromJob_Injected(IntPtr painterHandle, int i, out MeshWriteDataInterface ret) { }

	public static void Reset(IntPtr handle) { }

}

