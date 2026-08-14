namespace UnityEngine;

[DefaultMember("Item")]
[NativeHeader("Runtime/Math/AnimationCurve.bindings.h")]
[RequiredByNativeCode]
public class AnimationCurve : IEquatable<AnimationCurve>
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(AnimationCurve animationCurve) { }

	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.ParticleSystemModule"})]
	internal IntPtr m_Ptr; //Field offset: 0x10
	private bool m_RequiresNativeCleanup; //Field offset: 0x18

	public Keyframe Item
	{
		 get { } //Length: 170
	}

	public Keyframe[] keys
	{
		 get { } //Length: 9
		 set { } //Length: 249
	}

	public int length
	{
		[NativeMethod("GetKeyCount", IsThreadSafe = True)]
		 get { } //Length: 81
	}

	public WrapMode postWrapMode
	{
		[NativeMethod("GetPostInfinity", IsThreadSafe = True)]
		 get { } //Length: 81
		[NativeMethod("SetPostInfinity", IsThreadSafe = True)]
		 set { } //Length: 88
	}

	public WrapMode preWrapMode
	{
		[NativeMethod("GetPreInfinity", IsThreadSafe = True)]
		 get { } //Length: 81
		[NativeMethod("SetPreInfinity", IsThreadSafe = True)]
		 set { } //Length: 88
	}

	public AnimationCurve(Keyframe[] keys) { }

	[RequiredByNativeCode]
	public AnimationCurve() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.ParticleSystemModule"})]
	internal AnimationCurve(IntPtr ptr) { }

	[FreeFunction("AnimationCurveBindings::AddKeySmoothTangents", HasExplicitThis = True, IsThreadSafe = True)]
	public int AddKey(float time, float value) { }

	public int AddKey(Keyframe key) { }

	private static int AddKey_Injected(IntPtr _unity_self, float time, float value) { }

	[NativeMethod("AddKey", IsThreadSafe = True)]
	private int AddKey_Internal(Keyframe key) { }

	private static int AddKey_Internal_Injected(IntPtr _unity_self, in Keyframe key) { }

	[FreeFunction("AnimationCurveBindings::ClearKeys", HasExplicitThis = True, IsThreadSafe = True)]
	public void ClearKeys() { }

	private static void ClearKeys_Injected(IntPtr _unity_self) { }

	public void CopyFrom(AnimationCurve other) { }

	public override bool Equals(AnimationCurve other) { }

	public virtual bool Equals(object o) { }

	[ThreadSafe]
	public float Evaluate(float time) { }

	private static float Evaluate_Injected(IntPtr _unity_self, float time) { }

	protected virtual void Finalize() { }

	public Keyframe get_Item(int index) { }

	public Keyframe[] get_keys() { }

	[NativeMethod("GetKeyCount", IsThreadSafe = True)]
	public int get_length() { }

	private static int get_length_Injected(IntPtr _unity_self) { }

	[NativeMethod("GetPostInfinity", IsThreadSafe = True)]
	public WrapMode get_postWrapMode() { }

	private static WrapMode get_postWrapMode_Injected(IntPtr _unity_self) { }

	[NativeMethod("GetPreInfinity", IsThreadSafe = True)]
	public WrapMode get_preWrapMode() { }

	private static WrapMode get_preWrapMode_Injected(IntPtr _unity_self) { }

	[FreeFunction("AnimationCurveBindings::GetHashCode", HasExplicitThis = True, IsThreadSafe = True)]
	public virtual int GetHashCode() { }

	private static int GetHashCode_Injected(IntPtr _unity_self) { }

	[FreeFunction("AnimationCurveBindings::GetKey", HasExplicitThis = True, IsThreadSafe = True)]
	[NativeThrows]
	private Keyframe GetKey(int index) { }

	private static void GetKey_Injected(IntPtr _unity_self, int index, out Keyframe ret) { }

	[FreeFunction("AnimationCurveBindings::GetKeys", HasExplicitThis = True, IsThreadSafe = True)]
	private Keyframe[] GetKeys() { }

	private static void GetKeys_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret) { }

	[FreeFunction("AnimationCurveBindings::Internal_CopyFrom", HasExplicitThis = True, IsThreadSafe = True)]
	private void Internal_CopyFrom(IntPtr other) { }

	private static void Internal_CopyFrom_Injected(IntPtr _unity_self, IntPtr other) { }

	[FreeFunction("AnimationCurveBindings::Internal_Create", IsThreadSafe = True)]
	private static IntPtr Internal_Create(Keyframe[] keys) { }

	private static IntPtr Internal_Create_Injected(ref ManagedSpanWrapper keys) { }

	[FreeFunction("AnimationCurveBindings::Internal_Destroy", IsThreadSafe = True)]
	private static void Internal_Destroy(IntPtr ptr) { }

	[FreeFunction("AnimationCurveBindings::Internal_Equals", HasExplicitThis = True, IsThreadSafe = True)]
	private bool Internal_Equals(IntPtr other) { }

	private static bool Internal_Equals_Injected(IntPtr _unity_self, IntPtr other) { }

	public static AnimationCurve Linear(float timeStart, float valueStart, float timeEnd, float valueEnd) { }

	[FreeFunction("AnimationCurveBindings::MoveKey", HasExplicitThis = True, IsThreadSafe = True)]
	[NativeThrows]
	public int MoveKey(int index, Keyframe key) { }

	private static int MoveKey_Injected(IntPtr _unity_self, int index, in Keyframe key) { }

	[FreeFunction("AnimationCurveBindings::RemoveKey", HasExplicitThis = True, IsThreadSafe = True)]
	[NativeThrows]
	public void RemoveKey(int index) { }

	private static void RemoveKey_Injected(IntPtr _unity_self, int index) { }

	public void set_keys(Keyframe[] value) { }

	[NativeMethod("SetPostInfinity", IsThreadSafe = True)]
	public void set_postWrapMode(WrapMode value) { }

	private static void set_postWrapMode_Injected(IntPtr _unity_self, WrapMode value) { }

	[NativeMethod("SetPreInfinity", IsThreadSafe = True)]
	public void set_preWrapMode(WrapMode value) { }

	private static void set_preWrapMode_Injected(IntPtr _unity_self, WrapMode value) { }

	[FreeFunction("AnimationCurveBindings::SetKeys", HasExplicitThis = True, IsThreadSafe = True)]
	private void SetKeys(Keyframe[] keys) { }

	private static void SetKeys_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keys) { }

	[FreeFunction("AnimationCurveBindings::SmoothTangents", HasExplicitThis = True, IsThreadSafe = True)]
	[NativeThrows]
	public void SmoothTangents(int index, float weight) { }

	private static void SmoothTangents_Injected(IntPtr _unity_self, int index, float weight) { }

}

