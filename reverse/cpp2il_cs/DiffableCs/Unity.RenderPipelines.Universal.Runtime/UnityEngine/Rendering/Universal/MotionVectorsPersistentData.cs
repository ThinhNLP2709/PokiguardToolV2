namespace UnityEngine.Rendering.Universal;

internal sealed class MotionVectorsPersistentData
{
	private const int k_EyeCount = 2; //Field offset: 0x0
	private readonly Matrix4x4[] m_Projection; //Field offset: 0x10
	private readonly Matrix4x4[] m_View; //Field offset: 0x18
	private readonly Matrix4x4[] m_ViewProjection; //Field offset: 0x20
	private readonly Matrix4x4[] m_PreviousProjection; //Field offset: 0x28
	private readonly Matrix4x4[] m_PreviousView; //Field offset: 0x30
	private readonly Matrix4x4[] m_PreviousViewProjection; //Field offset: 0x38
	private readonly Matrix4x4[] m_PreviousPreviousProjection; //Field offset: 0x40
	private readonly Matrix4x4[] m_PreviousPreviousView; //Field offset: 0x48
	private readonly Int32[] m_LastFrameIndex; //Field offset: 0x50
	private readonly Single[] m_PrevAspectRatio; //Field offset: 0x58
	private float m_deltaTime; //Field offset: 0x60
	private float m_lastDeltaTime; //Field offset: 0x64
	private Vector3 m_worldSpaceCameraPos; //Field offset: 0x68
	private Vector3 m_previousWorldSpaceCameraPos; //Field offset: 0x74
	private Vector3 m_previousPreviousWorldSpaceCameraPos; //Field offset: 0x80

	internal float deltaTime
	{
		internal get { } //Length: 6
	}

	internal float lastDeltaTime
	{
		internal get { } //Length: 6
	}

	internal int lastFrameIndex
	{
		internal get { } //Length: 38
	}

	internal Matrix4x4[] previousPreviousProjectionStereo
	{
		internal get { } //Length: 5
	}

	internal Matrix4x4[] previousPreviousViewStereo
	{
		internal get { } //Length: 5
	}

	internal Vector3 previousPreviousWorldSpaceCameraPos
	{
		internal get { } //Length: 25
	}

	internal Matrix4x4[] previousProjectionStereo
	{
		internal get { } //Length: 5
	}

	internal Matrix4x4 previousViewProjection
	{
		internal get { } //Length: 69
	}

	internal Matrix4x4[] previousViewProjectionStereo
	{
		internal get { } //Length: 5
	}

	internal Matrix4x4[] previousViewStereo
	{
		internal get { } //Length: 5
	}

	internal Vector3 previousWorldSpaceCameraPos
	{
		internal get { } //Length: 19
	}

	internal Matrix4x4[] projectionStereo
	{
		internal get { } //Length: 5
	}

	internal Matrix4x4 viewProjection
	{
		internal get { } //Length: 69
	}

	internal Matrix4x4[] viewProjectionStereo
	{
		internal get { } //Length: 5
	}

	internal Matrix4x4[] viewStereo
	{
		internal get { } //Length: 5
	}

	internal Vector3 worldSpaceCameraPos
	{
		internal get { } //Length: 19
	}

	internal MotionVectorsPersistentData() { }

	internal float get_deltaTime() { }

	internal float get_lastDeltaTime() { }

	internal int get_lastFrameIndex() { }

	internal Matrix4x4[] get_previousPreviousProjectionStereo() { }

	internal Matrix4x4[] get_previousPreviousViewStereo() { }

	internal Vector3 get_previousPreviousWorldSpaceCameraPos() { }

	internal Matrix4x4[] get_previousProjectionStereo() { }

	internal Matrix4x4 get_previousViewProjection() { }

	internal Matrix4x4[] get_previousViewProjectionStereo() { }

	internal Matrix4x4[] get_previousViewStereo() { }

	internal Vector3 get_previousWorldSpaceCameraPos() { }

	internal Matrix4x4[] get_projectionStereo() { }

	internal Matrix4x4 get_viewProjection() { }

	internal Matrix4x4[] get_viewProjectionStereo() { }

	internal Matrix4x4[] get_viewStereo() { }

	internal Vector3 get_worldSpaceCameraPos() { }

	private static int GetXRMultiPassId(XRPass xr) { }

	public void Reset() { }

	public void SetGlobalMotionMatrices(RasterCommandBuffer cmd, XRPass xr) { }

	public void Update(UniversalCameraData cameraData) { }

}

