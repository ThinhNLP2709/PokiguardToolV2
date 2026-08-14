namespace UnityEngine;

[NativeHeader("Modules/IMGUI/GUIStyle.bindings.h")]
public sealed class GUIStyleState
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(GUIStyleState guiStyleState) { }

	}

	internal IntPtr m_Ptr; //Field offset: 0x10
	private readonly GUIStyle m_SourceStyle; //Field offset: 0x18

	[NativeProperty("Background", False, TargetType::Function (0))]
	public Texture2D background
	{
		 get { } //Length: 132
		 set { } //Length: 174
	}

	[NativeProperty("textColor", False, TargetType::Field (1))]
	public Color textColor
	{
		 get { } //Length: 105
		 set { } //Length: 90
	}

	public GUIStyleState() { }

	private GUIStyleState(GUIStyle sourceStyle, IntPtr source) { }

	[FreeFunction(Name = "GUIStyleState_Bindings::Cleanup", IsThreadSafe = True, HasExplicitThis = True)]
	private void Cleanup() { }

	private static void Cleanup_Injected(IntPtr _unity_self) { }

	protected virtual void Finalize() { }

	public Texture2D get_background() { }

	private static IntPtr get_background_Injected(IntPtr _unity_self) { }

	public Color get_textColor() { }

	private static void get_textColor_Injected(IntPtr _unity_self, out Color ret) { }

	internal static GUIStyleState GetGUIStyleState(GUIStyle sourceStyle, IntPtr source) { }

	[FreeFunction(Name = "GUIStyleState_Bindings::Init", IsThreadSafe = True)]
	private static IntPtr Init() { }

	public void set_background(Texture2D value) { }

	private static void set_background_Injected(IntPtr _unity_self, IntPtr value) { }

	public void set_textColor(Color value) { }

	private static void set_textColor_Injected(IntPtr _unity_self, in Color value) { }

}

