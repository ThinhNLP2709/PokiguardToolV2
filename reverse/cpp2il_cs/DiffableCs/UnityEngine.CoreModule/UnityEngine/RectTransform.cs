namespace UnityEngine;

[NativeClass("UI::RectTransform")]
[NativeHeader("Runtime/Transform/RectTransform.h")]
public sealed class RectTransform : Transform
{
	internal enum Axis
	{
		Horizontal = 0,
		Vertical = 1,
	}

	internal sealed class ReapplyDrivenProperties : MulticastDelegate
	{

		public ReapplyDrivenProperties(object object, IntPtr method) { }

		public override void Invoke(RectTransform driven) { }

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static ReapplyDrivenProperties reapplyDrivenProperties; //Field offset: 0x0

	public static event ReapplyDrivenProperties reapplyDrivenProperties
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public Vector2 anchoredPosition
	{
		 get { } //Length: 136
		 set { } //Length: 129
	}

	public Vector3 anchoredPosition3D
	{
		 get { } //Length: 291
		 set { } //Length: 386
	}

	public Vector2 anchorMax
	{
		 get { } //Length: 136
		 set { } //Length: 129
	}

	public Vector2 anchorMin
	{
		 get { } //Length: 136
		 set { } //Length: 129
	}

	public Vector2 offsetMax
	{
		 get { } //Length: 451
		 set { } //Length: 1014
	}

	public Vector2 offsetMin
	{
		 get { } //Length: 387
		 set { } //Length: 1038
	}

	public Vector2 pivot
	{
		 get { } //Length: 136
		 set { } //Length: 129
	}

	public Rect rect
	{
		 get { } //Length: 143
	}

	public Vector2 sizeDelta
	{
		 get { } //Length: 136
		 set { } //Length: 129
	}

	[CompilerGenerated]
	public static void add_reapplyDrivenProperties(ReapplyDrivenProperties value) { }

	public Vector2 get_anchoredPosition() { }

	private static void get_anchoredPosition_Injected(IntPtr _unity_self, out Vector2 ret) { }

	public Vector3 get_anchoredPosition3D() { }

	public Vector2 get_anchorMax() { }

	private static void get_anchorMax_Injected(IntPtr _unity_self, out Vector2 ret) { }

	public Vector2 get_anchorMin() { }

	private static void get_anchorMin_Injected(IntPtr _unity_self, out Vector2 ret) { }

	public Vector2 get_offsetMax() { }

	public Vector2 get_offsetMin() { }

	public Vector2 get_pivot() { }

	private static void get_pivot_Injected(IntPtr _unity_self, out Vector2 ret) { }

	public Rect get_rect() { }

	private static void get_rect_Injected(IntPtr _unity_self, out Rect ret) { }

	public Vector2 get_sizeDelta() { }

	private static void get_sizeDelta_Injected(IntPtr _unity_self, out Vector2 ret) { }

	public void GetLocalCorners(Vector3[] fourCornersArray) { }

	private Vector2 GetParentSize() { }

	public void GetWorldCorners(Vector3[] fourCornersArray) { }

	[CompilerGenerated]
	public static void remove_reapplyDrivenProperties(ReapplyDrivenProperties value) { }

	[RequiredByNativeCode]
	internal static void SendReapplyDrivenProperties(RectTransform driven) { }

	public void set_anchoredPosition(Vector2 value) { }

	private static void set_anchoredPosition_Injected(IntPtr _unity_self, in Vector2 value) { }

	public void set_anchoredPosition3D(Vector3 value) { }

	public void set_anchorMax(Vector2 value) { }

	private static void set_anchorMax_Injected(IntPtr _unity_self, in Vector2 value) { }

	public void set_anchorMin(Vector2 value) { }

	private static void set_anchorMin_Injected(IntPtr _unity_self, in Vector2 value) { }

	public void set_offsetMax(Vector2 value) { }

	public void set_offsetMin(Vector2 value) { }

	public void set_pivot(Vector2 value) { }

	private static void set_pivot_Injected(IntPtr _unity_self, in Vector2 value) { }

	public void set_sizeDelta(Vector2 value) { }

	private static void set_sizeDelta_Injected(IntPtr _unity_self, in Vector2 value) { }

	public void SetSizeWithCurrentAnchors(Axis axis, float size) { }

}

