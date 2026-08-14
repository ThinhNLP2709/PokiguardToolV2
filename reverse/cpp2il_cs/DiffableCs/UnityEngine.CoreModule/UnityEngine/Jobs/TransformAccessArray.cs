namespace UnityEngine.Jobs;

[DefaultMember("Item")]
[NativeType(Header = "Runtime/Transform/ScriptBindings/TransformAccess.bindings.h", CodegenOptions = CodegenOptions::Custom (1))]
public struct TransformAccessArray : IDisposable
{
	private IntPtr m_TransformArray; //Field offset: 0x0

	public int capacity
	{
		 get { } //Length: 51
		 set { } //Length: 64
	}

	public bool isCreated
	{
		 get { } //Length: 10
	}

	public Transform Item
	{
		 get { } //Length: 106
	}

	public int length
	{
		 get { } //Length: 51
	}

	public TransformAccessArray(int capacity, int desiredJobCount = -1) { }

	[NativeMethod(Name = "TransformAccessArrayBindings::AddTransform", IsFreeFunction = True)]
	private static void Add(IntPtr transformArrayIntPtr, Transform transform) { }

	public void Add(Transform transform) { }

	private static void Add_Injected(IntPtr transformArrayIntPtr, IntPtr transform) { }

	public static void Allocate(int capacity, int desiredJobCount, out TransformAccessArray array) { }

	[NativeMethod(Name = "TransformAccessArrayBindings::Create", IsFreeFunction = True)]
	private static IntPtr Create(int capacity, int desiredJobCount) { }

	[NativeMethod(Name = "DestroyTransformAccessArray", IsFreeFunction = True)]
	private static void DestroyTransformAccessArray(IntPtr transformArray) { }

	public override void Dispose() { }

	public int get_capacity() { }

	public bool get_isCreated() { }

	public Transform get_Item(int index) { }

	public int get_length() { }

	[NativeMethod(Name = "TransformAccessArrayBindings::GetCapacity", IsFreeFunction = True)]
	internal static int GetCapacity(IntPtr transformArrayIntPtr) { }

	[NativeMethod(Name = "TransformAccessArrayBindings::GetLength", IsFreeFunction = True)]
	internal static int GetLength(IntPtr transformArrayIntPtr) { }

	[NativeMethod(Name = "TransformAccessArrayBindings::GetSortedToUserIndex", IsThreadSafe = True, IsFreeFunction = True, ThrowsException = True)]
	internal static IntPtr GetSortedToUserIndex(IntPtr transformArrayIntPtr) { }

	[NativeMethod(Name = "TransformAccessArrayBindings::GetSortedTransformAccess", IsThreadSafe = True, IsFreeFunction = True, ThrowsException = True)]
	internal static IntPtr GetSortedTransformAccess(IntPtr transformArrayIntPtr) { }

	[NativeMethod(Name = "TransformAccessArrayBindings::GetTransform", IsFreeFunction = True, ThrowsException = True)]
	internal static Transform GetTransform(IntPtr transformArrayIntPtr, int index) { }

	private static IntPtr GetTransform_Injected(IntPtr transformArrayIntPtr, int index) { }

	internal IntPtr GetTransformAccessArrayForSchedule() { }

	public void RemoveAtSwapBack(int index) { }

	[NativeMethod(Name = "TransformAccessArrayBindings::RemoveAtSwapBack", IsFreeFunction = True, ThrowsException = True)]
	private static void RemoveAtSwapBack(IntPtr transformArrayIntPtr, int index) { }

	public void set_capacity(int value) { }

	[NativeMethod(Name = "TransformAccessArrayBindings::SetCapacity", IsFreeFunction = True)]
	internal static void SetCapacity(IntPtr transformArrayIntPtr, int capacity) { }

	public void SetTransforms(Transform[] transforms) { }

	[NativeMethod(Name = "TransformAccessArrayBindings::SetTransforms", IsFreeFunction = True)]
	private static void SetTransforms(IntPtr transformArrayIntPtr, Transform[] transforms) { }

}

