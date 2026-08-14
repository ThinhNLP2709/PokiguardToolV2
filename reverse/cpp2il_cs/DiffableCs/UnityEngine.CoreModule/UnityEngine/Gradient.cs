namespace UnityEngine;

[NativeHeader("Runtime/Export/Math/Gradient.bindings.h")]
[RequiredByNativeCode]
public class Gradient : IEquatable<Gradient>
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(Gradient graident) { }

	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.ParticleSystemModule"})]
	internal IntPtr m_Ptr; //Field offset: 0x10
	private bool m_RequiresNativeCleanup; //Field offset: 0x18

	public GradientAlphaKey[] alphaKeys
	{
		[FreeFunction("Gradient_Bindings::GetAlphaKeys", IsThreadSafe = True, HasExplicitThis = True)]
		 get { } //Length: 237
		[FreeFunction("Gradient_Bindings::SetAlphaKeys", IsThreadSafe = True, HasExplicitThis = True)]
		 set { } //Length: 249
	}

	public GradientColorKey[] colorKeys
	{
		[FreeFunction("Gradient_Bindings::GetColorKeys", IsThreadSafe = True, HasExplicitThis = True)]
		 get { } //Length: 237
		[FreeFunction("Gradient_Bindings::SetColorKeys", IsThreadSafe = True, HasExplicitThis = True)]
		 set { } //Length: 249
	}

	[NativeProperty(IsThreadSafe = True)]
	public ColorSpace colorSpace
	{
		 get { } //Length: 81
		 set { } //Length: 88
	}

	[NativeProperty(IsThreadSafe = True)]
	public GradientMode mode
	{
		 get { } //Length: 81
		 set { } //Length: 88
	}

	[RequiredByNativeCode]
	public Gradient() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.ParticleSystemModule"})]
	internal Gradient(IntPtr ptr) { }

	[FreeFunction(Name = "Gradient_Bindings::Cleanup", IsThreadSafe = True, HasExplicitThis = True)]
	private void Cleanup() { }

	private static void Cleanup_Injected(IntPtr _unity_self) { }

	public override bool Equals(Gradient other) { }

	public virtual bool Equals(object o) { }

	[FreeFunction(Name = "Gradient_Bindings::Evaluate", IsThreadSafe = True, HasExplicitThis = True)]
	public Color Evaluate(float time) { }

	private static void Evaluate_Injected(IntPtr _unity_self, float time, out Color ret) { }

	protected virtual void Finalize() { }

	[FreeFunction("Gradient_Bindings::GetAlphaKeys", IsThreadSafe = True, HasExplicitThis = True)]
	public GradientAlphaKey[] get_alphaKeys() { }

	private static void get_alphaKeys_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret) { }

	[FreeFunction("Gradient_Bindings::GetColorKeys", IsThreadSafe = True, HasExplicitThis = True)]
	public GradientColorKey[] get_colorKeys() { }

	private static void get_colorKeys_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret) { }

	public ColorSpace get_colorSpace() { }

	private static ColorSpace get_colorSpace_Injected(IntPtr _unity_self) { }

	public GradientMode get_mode() { }

	private static GradientMode get_mode_Injected(IntPtr _unity_self) { }

	public virtual int GetHashCode() { }

	[FreeFunction(Name = "Gradient_Bindings::Init", IsThreadSafe = True)]
	private static IntPtr Init() { }

	[FreeFunction("Gradient_Bindings::Internal_Equals", IsThreadSafe = True, HasExplicitThis = True)]
	private bool Internal_Equals(IntPtr other) { }

	private static bool Internal_Equals_Injected(IntPtr _unity_self, IntPtr other) { }

	[FreeFunction("Gradient_Bindings::SetAlphaKeys", IsThreadSafe = True, HasExplicitThis = True)]
	public void set_alphaKeys(GradientAlphaKey[] value) { }

	private static void set_alphaKeys_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value) { }

	[FreeFunction("Gradient_Bindings::SetColorKeys", IsThreadSafe = True, HasExplicitThis = True)]
	public void set_colorKeys(GradientColorKey[] value) { }

	private static void set_colorKeys_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value) { }

	public void set_colorSpace(ColorSpace value) { }

	private static void set_colorSpace_Injected(IntPtr _unity_self, ColorSpace value) { }

	public void set_mode(GradientMode value) { }

	private static void set_mode_Injected(IntPtr _unity_self, GradientMode value) { }

	[FreeFunction(Name = "Gradient_Bindings::SetKeys", IsThreadSafe = True, HasExplicitThis = True)]
	public void SetKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys) { }

	private static void SetKeys_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colorKeys, ref ManagedSpanWrapper alphaKeys) { }

}

