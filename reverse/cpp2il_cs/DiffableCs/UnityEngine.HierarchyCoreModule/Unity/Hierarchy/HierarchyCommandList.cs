namespace Unity.Hierarchy;

[NativeHeader("Modules/HierarchyCore/HierarchyCommandListBindings.h")]
[NativeHeader("Modules/HierarchyCore/Public/HierarchyCommandList.h")]
[RequiredByNativeCode(GenerateProxy = True)]
public sealed class HierarchyCommandList : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(HierarchyCommandList cmdList) { }

	}

	private IntPtr m_Ptr; //Field offset: 0x10
	private readonly bool m_IsOwner; //Field offset: 0x18

	private HierarchyCommandList(IntPtr nativePtr) { }

	[RequiredByNativeCode]
	private static IntPtr CreateCommandList(IntPtr nativePtr) { }

	[FreeFunction("HierarchyCommandListBindings::Destroy", IsThreadSafe = True)]
	private static void Destroy(IntPtr nativePtr) { }

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

	protected virtual void Finalize() { }

	internal static HierarchyCommandList FromIntPtr(IntPtr handlePtr) { }

}

