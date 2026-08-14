namespace UnityEngine;

[NativeHeader("Runtime/Export/Camera/CullingGroup.bindings.h")]
public class CullingGroup : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(CullingGroup cullingGroup) { }

	}

	internal sealed class StateChanged : MulticastDelegate
	{

		public StateChanged(object object, IntPtr method) { }

		public override void Invoke(CullingGroupEvent sphere) { }

	}

	internal IntPtr m_Ptr; //Field offset: 0x10
	private StateChanged m_OnStateChanged; //Field offset: 0x18

	public Camera targetCamera
	{
		 set { } //Length: 174
	}

	public CullingGroup() { }

	public override void Dispose() { }

	[FreeFunction("CullingGroup_Bindings::Dispose", HasExplicitThis = True)]
	private void DisposeInternal() { }

	private static void DisposeInternal_Injected(IntPtr _unity_self) { }

	protected virtual void Finalize() { }

	[FreeFunction("CullingGroup_Bindings::FinalizerFailure", HasExplicitThis = True, IsThreadSafe = True)]
	private void FinalizerFailure() { }

	private static void FinalizerFailure_Injected(IntPtr _unity_self) { }

	[FreeFunction("CullingGroup_Bindings::Init")]
	private static IntPtr Init(object scripting) { }

	public int QueryIndices(bool visible, Int32[] result, int firstIndex) { }

	[FreeFunction("CullingGroup_Bindings::QueryIndices", HasExplicitThis = True)]
	[NativeThrows]
	private int QueryIndices(bool visible, int distanceIndex, CullingQueryOptions options, Int32[] result, int firstIndex) { }

	private static int QueryIndices_Injected(IntPtr _unity_self, bool visible, int distanceIndex, CullingQueryOptions options, ref ManagedSpanWrapper result, int firstIndex) { }

	[RequiredByNativeCode]
	private static void SendEvents(CullingGroup cullingGroup, IntPtr eventsPtr, int count) { }

	public void set_targetCamera(Camera value) { }

	private static void set_targetCamera_Injected(IntPtr _unity_self, IntPtr value) { }

	[FreeFunction("CullingGroup_Bindings::SetBoundingDistances", HasExplicitThis = True)]
	public void SetBoundingDistances(Single[] distances) { }

	private static void SetBoundingDistances_Injected(IntPtr _unity_self, ref ManagedSpanWrapper distances) { }

	public void SetBoundingSphereCount(int count) { }

	private static void SetBoundingSphereCount_Injected(IntPtr _unity_self, int count) { }

	public void SetBoundingSpheres(BoundingSphere[] array) { }

	private static void SetBoundingSpheres_Injected(IntPtr _unity_self, BoundingSphere[] array) { }

	public void SetDistanceReferencePoint(Vector3 point) { }

	[FreeFunction("CullingGroup_Bindings::SetDistanceReferencePoint", HasExplicitThis = True)]
	private void SetDistanceReferencePoint_InternalVector3(Vector3 point) { }

	private static void SetDistanceReferencePoint_InternalVector3_Injected(IntPtr _unity_self, in Vector3 point) { }

}

