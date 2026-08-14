namespace UnityEngine;

[NativeHeader("Runtime/Camera/Camera.h")]
[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
[NativeHeader("Runtime/GfxDevice/GfxDevice.h")]
[NativeHeader("Runtime/Camera/CameraUtil.h")]
[StaticAccessor("GetGfxDevice()", StaticAccessorType::Dot (0))]
public sealed class GL
{

	public static Matrix4x4 modelview
	{
		 set { } //Length: 82
	}

	public static bool wireframe
	{
		 get { } //Length: 42
	}

	[FreeFunction("GLBegin", ThrowsException = True)]
	public static void Begin(int mode) { }

	public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor) { }

	public static void Clear(bool clearDepth, bool clearColor, Color backgroundColor, float depth) { }

	public static void Color(Color c) { }

	[FreeFunction("GLEnd")]
	public static void End() { }

	public static bool get_wireframe() { }

	[FreeFunction("GLGetGPUProjectionMatrix")]
	public static Matrix4x4 GetGPUProjectionMatrix(Matrix4x4 proj, bool renderIntoTexture) { }

	private static void GetGPUProjectionMatrix_Injected(in Matrix4x4 proj, bool renderIntoTexture, out Matrix4x4 ret) { }

	[FreeFunction]
	private static void GLClear(bool clearDepth, bool clearColor, Color backgroundColor, float depth) { }

	private static void GLClear_Injected(bool clearDepth, bool clearColor, in Color backgroundColor, float depth) { }

	[FreeFunction]
	private static void GLLoadPixelMatrixScript(float left, float right, float bottom, float top) { }

	[NativeName("ImmediateColor")]
	private static void ImmediateColor(float r, float g, float b, float a) { }

	[FreeFunction("GLLoadOrthoScript")]
	public static void LoadOrtho() { }

	[FreeFunction("GLLoadPixelMatrixScript")]
	public static void LoadPixelMatrix() { }

	public static void LoadPixelMatrix(float left, float right, float bottom, float top) { }

	[FreeFunction("GLLoadProjectionMatrixScript")]
	public static void LoadProjectionMatrix(Matrix4x4 mat) { }

	private static void LoadProjectionMatrix_Injected(in Matrix4x4 mat) { }

	[FreeFunction("GLPopMatrixScript")]
	public static void PopMatrix() { }

	[FreeFunction("GLPushMatrixScript")]
	public static void PushMatrix() { }

	public static void set_modelview(Matrix4x4 value) { }

	private static void SetViewMatrix(Matrix4x4 m) { }

	private static void SetViewMatrix_Injected(in Matrix4x4 m) { }

	public static void TexCoord2(float x, float y) { }

	[NativeName("ImmediateTexCoordAll")]
	public static void TexCoord3(float x, float y, float z) { }

	public static void Vertex(Vector3 v) { }

	[NativeName("ImmediateVertex")]
	public static void Vertex3(float x, float y, float z) { }

	[FreeFunction("SetGLViewport")]
	public static void Viewport(Rect pixelRect) { }

	private static void Viewport_Injected(in Rect pixelRect) { }

}

