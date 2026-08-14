namespace UnityEngine.Rendering;

internal class ProbeSamplingDebugData
{
	public ProbeSamplingDebugUpdate update; //Field offset: 0x10
	public Vector2 coordinates; //Field offset: 0x14
	public bool forceScreenCenterCoordinates; //Field offset: 0x1C
	public Camera camera; //Field offset: 0x20
	public bool shortcutPressed; //Field offset: 0x28
	public GraphicsBuffer positionNormalBuffer; //Field offset: 0x30

	public ProbeSamplingDebugData() { }

}

