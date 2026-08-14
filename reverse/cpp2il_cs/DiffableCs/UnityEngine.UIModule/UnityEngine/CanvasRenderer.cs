namespace UnityEngine;

[NativeClass("UI::CanvasRenderer")]
[NativeHeader("Modules/UI/CanvasRenderer.h")]
public sealed class CanvasRenderer : Component
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <isMask>k__BackingField; //Field offset: 0x18

	public int absoluteDepth
	{
		 get { } //Length: 118
	}

	public Vector2 clippingSoftness
	{
		 set { } //Length: 128
	}

	[NativeProperty("ShouldCull", False, TargetType::Function (0))]
	public bool cull
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public bool cullTransparentMesh
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public bool hasMoved
	{
		 get { } //Length: 118
	}

	public bool hasPopInstruction
	{
		 set { } //Length: 134
	}

	public int materialCount
	{
		 get { } //Length: 118
		 set { } //Length: 131
	}

	public int popMaterialCount
	{
		 set { } //Length: 131
	}

	public static void AddUIVertexStream(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector4> uv2S, List<Vector4> uv3S, List<Vector3> normals, List<Vector4> tangents) { }

	public void Clear() { }

	private static void Clear_Injected(IntPtr _unity_self) { }

	public static void CreateUIVertexStream(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector4> uv2S, List<Vector4> uv3S, List<Vector3> normals, List<Vector4> tangents, List<Int32> indices) { }

	[StaticAccessor("UI", StaticAccessorType::DoubleColon (2))]
	private static void CreateUIVertexStreamInternal(object verts, object positions, object colors, object uv0S, object uv1S, object uv2S, object uv3S, object normals, object tangents, object indices) { }

	public void DisableRectClipping() { }

	private static void DisableRectClipping_Injected(IntPtr _unity_self) { }

	public void EnableRectClipping(Rect rect) { }

	private static void EnableRectClipping_Injected(IntPtr _unity_self, in Rect rect) { }

	public int get_absoluteDepth() { }

	private static int get_absoluteDepth_Injected(IntPtr _unity_self) { }

	public bool get_cull() { }

	private static bool get_cull_Injected(IntPtr _unity_self) { }

	public bool get_cullTransparentMesh() { }

	private static bool get_cullTransparentMesh_Injected(IntPtr _unity_self) { }

	public bool get_hasMoved() { }

	private static bool get_hasMoved_Injected(IntPtr _unity_self) { }

	public int get_materialCount() { }

	private static int get_materialCount_Injected(IntPtr _unity_self) { }

	public Color GetColor() { }

	private static void GetColor_Injected(IntPtr _unity_self, out Color ret) { }

	public Material GetMaterial() { }

	public Material GetMaterial(int index) { }

	private static IntPtr GetMaterial_Injected(IntPtr _unity_self, int index) { }

	public void set_clippingSoftness(Vector2 value) { }

	private static void set_clippingSoftness_Injected(IntPtr _unity_self, in Vector2 value) { }

	public void set_cull(bool value) { }

	private static void set_cull_Injected(IntPtr _unity_self, bool value) { }

	public void set_cullTransparentMesh(bool value) { }

	private static void set_cullTransparentMesh_Injected(IntPtr _unity_self, bool value) { }

	public void set_hasPopInstruction(bool value) { }

	private static void set_hasPopInstruction_Injected(IntPtr _unity_self, bool value) { }

	public void set_materialCount(int value) { }

	private static void set_materialCount_Injected(IntPtr _unity_self, int value) { }

	public void set_popMaterialCount(int value) { }

	private static void set_popMaterialCount_Injected(IntPtr _unity_self, int value) { }

	public void SetAlphaTexture(Texture texture) { }

	private static void SetAlphaTexture_Injected(IntPtr _unity_self, IntPtr texture) { }

	public void SetColor(Color color) { }

	private static void SetColor_Injected(IntPtr _unity_self, in Color color) { }

	public void SetMaterial(Material material, Texture texture) { }

	public void SetMaterial(Material material, int index) { }

	private static void SetMaterial_Injected(IntPtr _unity_self, IntPtr material, int index) { }

	public void SetMesh(Mesh mesh) { }

	private static void SetMesh_Injected(IntPtr _unity_self, IntPtr mesh) { }

	public void SetPopMaterial(Material material, int index) { }

	private static void SetPopMaterial_Injected(IntPtr _unity_self, IntPtr material, int index) { }

	public void SetTexture(Texture texture) { }

	private static void SetTexture_Injected(IntPtr _unity_self, IntPtr texture) { }

	[StaticAccessor("UI", StaticAccessorType::DoubleColon (2))]
	private static void SplitIndicesStreamsInternal(object verts, object indices) { }

	public static void SplitUIVertexStreams(List<UIVertex> verts, List<Vector3> positions, List<Color32> colors, List<Vector4> uv0S, List<Vector4> uv1S, List<Vector4> uv2S, List<Vector4> uv3S, List<Vector3> normals, List<Vector4> tangents, List<Int32> indices) { }

	[StaticAccessor("UI", StaticAccessorType::DoubleColon (2))]
	private static void SplitUIVertexStreamsInternal(object verts, object positions, object colors, object uv0S, object uv1S, object uv2S, object uv3S, object normals, object tangents) { }

}

