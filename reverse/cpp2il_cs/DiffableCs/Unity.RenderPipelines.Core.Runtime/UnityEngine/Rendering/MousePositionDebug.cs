namespace UnityEngine.Rendering;

public class MousePositionDebug
{
	private static MousePositionDebug s_Instance; //Field offset: 0x0

	public static MousePositionDebug instance
	{
		 get { } //Length: 141
	}

	public MousePositionDebug() { }

	public void Build() { }

	public void Cleanup() { }

	public static MousePositionDebug get_instance() { }

	private Vector2 GetInputMousePosition() { }

	public Vector2 GetMouseClickPosition(float ScreenHeight) { }

	public Vector2 GetMousePosition(float ScreenHeight, bool sceneView) { }

}

