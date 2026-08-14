namespace UnityEngine;

[NativeHeader("Runtime/Misc/ObjectDispatcher.h")]
[RequiredByNativeCode]
[StaticAccessor("GetObjectDispatcher()", StaticAccessorType::Dot (0))]
internal sealed class ObjectDispatcher : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.cctor>b__64_0(Object[] changed, IntPtr changedID, IntPtr destroyedID, int changedCount, int destroyedCount, Action<TypeDispatchData> callback) { }

		internal void <.cctor>b__64_1(IntPtr transformed, IntPtr parents, IntPtr localToWorldMatrices, IntPtr positions, IntPtr rotations, IntPtr scales, int count, Action<TransformDispatchData> callback) { }

	}

	internal enum TransformTrackingType
	{
		GlobalTRS = 0,
		LocalTRS = 1,
		Hierarchy = 2,
	}

	[Flags]
	internal enum TypeTrackingFlags
	{
		SceneObjects = 1,
		Assets = 2,
		EditorOnlyObjects = 4,
		Default = 3,
		All = 7,
	}

	private static Action<Object[], IntPtr, IntPtr, Int32, Int32, Action`1<TypeDispatchData>> s_TypeDispatch; //Field offset: 0x0
	private static Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, Int32, Action`1<TransformDispatchData>> s_TransformDispatch; //Field offset: 0x8
	private IntPtr m_Ptr; //Field offset: 0x10
	private Allocator m_DispatchAllocator; //Field offset: 0x18
	private TypeDispatchData m_TypeDispatchData; //Field offset: 0x20
	private TransformDispatchData m_TransformDispatchData; //Field offset: 0x48
	private Component[] m_TransformedComponents; //Field offset: 0xA8
	private Action<TypeDispatchData> m_TypeDataCallback; //Field offset: 0xB0
	private Action<TransformDispatchData> m_TransformDataCallback; //Field offset: 0xB8
	private Action<Component[]> m_TransformComponentCallback; //Field offset: 0xC0

	public bool valid
	{
		 get { } //Length: 11
	}

	private static ObjectDispatcher() { }

	public ObjectDispatcher() { }

	private static IntPtr CreateDispatchSystemHandle() { }

	[ThreadSafe]
	private static void DestroyDispatchSystemHandle(IntPtr ptr) { }

	private void DispatchCallback(Component[] components) { }

	private void DispatchCallback(TypeDispatchData data) { }

	private void DispatchCallback(TransformDispatchData data) { }

	public void DispatchTransformChangesAndClear(Type type, TransformTrackingType trackingType, Action<TransformDispatchData> callback) { }

	private static void DispatchTransformDataChangesAndClear(IntPtr ptr, Type type, TransformTrackingType trackingType, Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, Int32, Action`1<TransformDispatchData>> callback, Action<TransformDispatchData> param) { }

	private static void DispatchTypeChangesAndClear(IntPtr ptr, Type type, Action<Object[], IntPtr, IntPtr, Int32, Int32, Action`1<TypeDispatchData>> callback, bool sortByInstanceID, bool noScriptingArray, Action<TypeDispatchData> param) { }

	public void DispatchTypeChangesAndClear(Type type, Action<TypeDispatchData> callback, bool sortByInstanceID = false, bool noScriptingArray = false) { }

	private void Dispose(bool disposing) { }

	public override void Dispose() { }

	public void EnableTransformTracking(TransformTrackingType trackingType) { }

	public void EnableTransformTracking(TransformTrackingType trackingType, Type[] types) { }

	private static void EnableTransformTracking(IntPtr ptr, Type type, TransformTrackingType trackingType) { }

	private static void EnableTypeTracking(IntPtr ptr, Type type, TypeTrackingFlags typeTrackingMask) { }

	public void EnableTypeTracking(TypeTrackingFlags typeTrackingMask, Type[] types) { }

	public void EnableTypeTracking(TypeTrackingFlags typeTrackingMask = 3) { }

	protected virtual void Finalize() { }

	public bool get_valid() { }

	public TransformDispatchData GetTransformChangesAndClear(Type type, TransformTrackingType trackingType, Allocator allocator) { }

	public TransformDispatchData GetTransformChangesAndClear(TransformTrackingType trackingType, Allocator allocator) { }

	public TypeDispatchData GetTypeChangesAndClear(Allocator allocator, bool sortByInstanceID = false, bool noScriptingArray = false) { }

	public TypeDispatchData GetTypeChangesAndClear(Type type, Allocator allocator, bool sortByInstanceID = false, bool noScriptingArray = false) { }

	private void ValidateComponentTypeAndThrow(Type type) { }

	private void ValidateSystemHandleAndThrow() { }

	private void ValidateTypeAndThrow(Type type) { }

}

