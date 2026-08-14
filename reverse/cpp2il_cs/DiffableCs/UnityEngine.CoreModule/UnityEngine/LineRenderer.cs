namespace UnityEngine;

[NativeHeader("Runtime/Graphics/LineRenderer.h")]
[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
public sealed class LineRenderer : Renderer
{

	public Color endColor
	{
		 set { } //Length: 133
	}

	public float endWidth
	{
		 set { } //Length: 134
	}

	public bool loop
	{
		 set { } //Length: 134
	}

	public int numCapVertices
	{
		 set { } //Length: 131
	}

	public int numCornerVertices
	{
		 set { } //Length: 131
	}

	[NativeProperty("PositionsCount")]
	public int positionCount
	{
		 set { } //Length: 131
	}

	public Color startColor
	{
		 set { } //Length: 133
	}

	public float startWidth
	{
		 set { } //Length: 134
	}

	public bool useWorldSpace
	{
		 set { } //Length: 134
	}

	public void set_endColor(Color value) { }

	private static void set_endColor_Injected(IntPtr _unity_self, in Color value) { }

	public void set_endWidth(float value) { }

	private static void set_endWidth_Injected(IntPtr _unity_self, float value) { }

	public void set_loop(bool value) { }

	private static void set_loop_Injected(IntPtr _unity_self, bool value) { }

	public void set_numCapVertices(int value) { }

	private static void set_numCapVertices_Injected(IntPtr _unity_self, int value) { }

	public void set_numCornerVertices(int value) { }

	private static void set_numCornerVertices_Injected(IntPtr _unity_self, int value) { }

	public void set_positionCount(int value) { }

	private static void set_positionCount_Injected(IntPtr _unity_self, int value) { }

	public void set_startColor(Color value) { }

	private static void set_startColor_Injected(IntPtr _unity_self, in Color value) { }

	public void set_startWidth(float value) { }

	private static void set_startWidth_Injected(IntPtr _unity_self, float value) { }

	public void set_useWorldSpace(bool value) { }

	private static void set_useWorldSpace_Injected(IntPtr _unity_self, bool value) { }

	public void SetPosition(int index, Vector3 position) { }

	private static void SetPosition_Injected(IntPtr _unity_self, int index, in Vector3 position) { }

}

