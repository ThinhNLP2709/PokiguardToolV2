namespace UnityEngine;

[NativeHeader("Modules/IMGUI/GUIStyle.h")]
[UsedByNativeCode]
public class RectOffset : IFormattable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(RectOffset rectOffset) { }

	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.IMGUIModule"})]
	internal IntPtr m_Ptr; //Field offset: 0x10
	private readonly object m_SourceStyle; //Field offset: 0x18

	[NativeProperty("bottom", False, TargetType::Field (1))]
	public int bottom
	{
		 get { } //Length: 81
		 set { } //Length: 88
	}

	public int horizontal
	{
		 get { } //Length: 81
	}

	[NativeProperty("left", False, TargetType::Field (1))]
	public int left
	{
		 get { } //Length: 81
		 set { } //Length: 88
	}

	[NativeProperty("right", False, TargetType::Field (1))]
	public int right
	{
		 get { } //Length: 81
		 set { } //Length: 88
	}

	[NativeProperty("top", False, TargetType::Field (1))]
	public int top
	{
		 get { } //Length: 81
		 set { } //Length: 88
	}

	public int vertical
	{
		 get { } //Length: 81
	}

	public RectOffset() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.IMGUIModule"})]
	internal RectOffset(object sourceStyle, IntPtr source) { }

	public RectOffset(int left, int right, int top, int bottom) { }

	private void Destroy() { }

	protected virtual void Finalize() { }

	public int get_bottom() { }

	private static int get_bottom_Injected(IntPtr _unity_self) { }

	public int get_horizontal() { }

	private static int get_horizontal_Injected(IntPtr _unity_self) { }

	public int get_left() { }

	private static int get_left_Injected(IntPtr _unity_self) { }

	public int get_right() { }

	private static int get_right_Injected(IntPtr _unity_self) { }

	public int get_top() { }

	private static int get_top_Injected(IntPtr _unity_self) { }

	public int get_vertical() { }

	private static int get_vertical_Injected(IntPtr _unity_self) { }

	[ThreadAndSerializationSafe]
	private static IntPtr InternalCreate() { }

	[ThreadAndSerializationSafe]
	private static void InternalDestroy(IntPtr ptr) { }

	public Rect Remove(Rect rect) { }

	private static void Remove_Injected(IntPtr _unity_self, in Rect rect, out Rect ret) { }

	public void set_bottom(int value) { }

	private static void set_bottom_Injected(IntPtr _unity_self, int value) { }

	public void set_left(int value) { }

	private static void set_left_Injected(IntPtr _unity_self, int value) { }

	public void set_right(int value) { }

	private static void set_right_Injected(IntPtr _unity_self, int value) { }

	public void set_top(int value) { }

	private static void set_top_Injected(IntPtr _unity_self, int value) { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

	public virtual string ToString() { }

}

