namespace Unity.VisualScripting.FullSerializer;

public class fsConverterRegistrar
{
	public static AnimationCurve_DirectConverter Register_AnimationCurve_DirectConverter; //Field offset: 0x0
	public static Bounds_DirectConverter Register_Bounds_DirectConverter; //Field offset: 0x8
	public static Gradient_DirectConverter Register_Gradient_DirectConverter; //Field offset: 0x10
	public static GUIStyleState_DirectConverter Register_GUIStyleState_DirectConverter; //Field offset: 0x18
	public static GUIStyle_DirectConverter Register_GUIStyle_DirectConverter; //Field offset: 0x20
	[UsedImplicitly]
	public static InputAction_DirectConverter Register_InputAction_DirectConverter; //Field offset: 0x28
	public static Keyframe_DirectConverter Register_Keyframe_DirectConverter; //Field offset: 0x30
	public static LayerMask_DirectConverter Register_LayerMask_DirectConverter; //Field offset: 0x38
	public static RectOffset_DirectConverter Register_RectOffset_DirectConverter; //Field offset: 0x40
	public static Rect_DirectConverter Register_Rect_DirectConverter; //Field offset: 0x48
	public static List<Type> Converters; //Field offset: 0x50

	private static fsConverterRegistrar() { }

	public fsConverterRegistrar() { }

}

