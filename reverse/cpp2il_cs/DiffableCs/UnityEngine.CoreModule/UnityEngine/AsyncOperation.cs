namespace UnityEngine;

[NativeHeader("Runtime/Misc/AsyncOperation.h")]
[NativeHeader("Runtime/Export/Scripting/AsyncOperation.bindings.h")]
[RequiredByNativeCode]
public class AsyncOperation : YieldInstruction
{
	public static class BindingsMarshaller
	{

		public static AsyncOperation ConvertToManaged(IntPtr ptr) { }

		public static IntPtr ConvertToNative(AsyncOperation asyncOperation) { }

	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.AssetBundleModule"})]
	internal IntPtr m_Ptr; //Field offset: 0x10
	private Action<AsyncOperation> m_completeCallback; //Field offset: 0x18

	public event Action<AsyncOperation> completed
	{
		 add { } //Length: 291
		 remove { } //Length: 175
	}

	public bool allowSceneActivation
	{
		[NativeMethod("GetAllowSceneActivation")]
		 get { } //Length: 81
		[NativeMethod("SetAllowSceneActivation")]
		 set { } //Length: 91
	}

	public bool isDone
	{
		[NativeMethod("IsDone")]
		 get { } //Length: 81
	}

	public int priority
	{
		[NativeMethod("SetPriority")]
		 set { } //Length: 88
	}

	public float progress
	{
		[NativeMethod("GetProgress")]
		 get { } //Length: 81
	}

	protected AsyncOperation(IntPtr ptr) { }

	public void add_completed(Action<AsyncOperation> value) { }

	protected virtual void Finalize() { }

	[NativeMethod("GetAllowSceneActivation")]
	public bool get_allowSceneActivation() { }

	private static bool get_allowSceneActivation_Injected(IntPtr _unity_self) { }

	[NativeMethod("IsDone")]
	public bool get_isDone() { }

	private static bool get_isDone_Injected(IntPtr _unity_self) { }

	[NativeMethod("GetProgress")]
	public float get_progress() { }

	private static float get_progress_Injected(IntPtr _unity_self) { }

	[NativeMethod(IsThreadSafe = True)]
	[StaticAccessor("AsyncOperationBindings", StaticAccessorType::DoubleColon (2))]
	private static void InternalDestroy(IntPtr ptr) { }

	[NativeMethod(IsThreadSafe = True)]
	[StaticAccessor("AsyncOperationBindings", StaticAccessorType::DoubleColon (2))]
	private static void InternalSetManagedObject(IntPtr ptr, AsyncOperation self) { }

	[RequiredByNativeCode]
	internal void InvokeCompletionEvent() { }

	public void remove_completed(Action<AsyncOperation> value) { }

	[NativeMethod("SetAllowSceneActivation")]
	public void set_allowSceneActivation(bool value) { }

	private static void set_allowSceneActivation_Injected(IntPtr _unity_self, bool value) { }

	[NativeMethod("SetPriority")]
	public void set_priority(int value) { }

	private static void set_priority_Injected(IntPtr _unity_self, int value) { }

}

