namespace UnityEngine;

[NativeHeader("Runtime/Shaders/Material.h")]
[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
public class Material : object
{
	private static readonly int k_ColorId; //Field offset: 0x0
	private static readonly int k_MainTexId; //Field offset: 0x4

	public Color color
	{
		 get { } //Length: 403
		 set { } //Length: 385
	}

	public LocalKeyword[] enabledKeywords
	{
		 set { } //Length: 166
	}

	[NativeProperty("EnableInstancingVariants")]
	public bool enableInstancing
	{
		 get { } //Length: 151
		 set { } //Length: 167
	}

	public Texture mainTexture
	{
		 get { } //Length: 245
	}

	public Vector2 mainTextureOffset
	{
		 get { } //Length: 245
		 set { } //Length: 293
	}

	public Vector2 mainTextureScale
	{
		 get { } //Length: 245
		 set { } //Length: 293
	}

	public int passCount
	{
		[NativeName("GetShader()->GetPassCount")]
		 get { } //Length: 151
	}

	public int renderQueue
	{
		[NativeName("SetCustomRenderQueue")]
		 set { } //Length: 164
	}

	public Shader shader
	{
		 get { } //Length: 177
		 set { } //Length: 223
	}

	public String[] shaderKeywords
	{
		 get { } //Length: 151
		 set { } //Length: 166
	}

	private static Material() { }

	public Material(Shader shader) { }

	[RequiredByNativeCode]
	public Material(Material source) { }

	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[Obsolete("Creating materials from shader source string is no longer supported. Use Shader assets instead.", False)]
	public Material(string contents) { }

	public int ComputeCRC() { }

	private static int ComputeCRC_Injected(IntPtr _unity_self) { }

	[FreeFunction("MaterialScripting::CopyPropertiesFrom", HasExplicitThis = True)]
	public void CopyPropertiesFromMaterial(Material mat) { }

	private static void CopyPropertiesFromMaterial_Injected(IntPtr _unity_self, IntPtr mat) { }

	[FreeFunction("MaterialScripting::CreateWithMaterial")]
	private static void CreateWithMaterial(Material self, Material source) { }

	private static void CreateWithMaterial_Injected(Material self, IntPtr source) { }

	[FreeFunction("MaterialScripting::CreateWithShader")]
	private static void CreateWithShader(Material self, Shader shader) { }

	private static void CreateWithShader_Injected(Material self, IntPtr shader) { }

	[FreeFunction("MaterialScripting::CreateWithString")]
	private static void CreateWithString(Material self) { }

	public void DisableKeyword(in LocalKeyword keyword) { }

	public void DisableKeyword(string keyword) { }

	private static void DisableKeyword_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword) { }

	[FreeFunction("MaterialScripting::DisableKeyword", HasExplicitThis = True)]
	private void DisableLocalKeyword(LocalKeyword keyword) { }

	private static void DisableLocalKeyword_Injected(IntPtr _unity_self, in LocalKeyword keyword) { }

	public void EnableKeyword(string keyword) { }

	public void EnableKeyword(in LocalKeyword keyword) { }

	private static void EnableKeyword_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword) { }

	[FreeFunction("MaterialScripting::EnableKeyword", HasExplicitThis = True)]
	private void EnableLocalKeyword(LocalKeyword keyword) { }

	private static void EnableLocalKeyword_Injected(IntPtr _unity_self, in LocalKeyword keyword) { }

	public int FindPass(string passName) { }

	private static int FindPass_Injected(IntPtr _unity_self, ref ManagedSpanWrapper passName) { }

	public Color get_color() { }

	public bool get_enableInstancing() { }

	private static bool get_enableInstancing_Injected(IntPtr _unity_self) { }

	public Texture get_mainTexture() { }

	public Vector2 get_mainTextureOffset() { }

	public Vector2 get_mainTextureScale() { }

	[NativeName("GetShader()->GetPassCount")]
	public int get_passCount() { }

	private static int get_passCount_Injected(IntPtr _unity_self) { }

	public Shader get_shader() { }

	private static IntPtr get_shader_Injected(IntPtr _unity_self) { }

	public String[] get_shaderKeywords() { }

	public Color GetColor(int nameID) { }

	public Color GetColor(string name) { }

	[NativeName("GetColorFromScript")]
	private Color GetColorImpl(int name) { }

	private static void GetColorImpl_Injected(IntPtr _unity_self, int name, out Color ret) { }

	[NativeName("GetFirstPropertyNameIdByAttributeFromScript")]
	private int GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags attributeFlag) { }

	private static int GetFirstPropertyNameIdByAttribute_Injected(IntPtr _unity_self, ShaderPropertyFlags attributeFlag) { }

	public float GetFloat(string name) { }

	public float GetFloat(int nameID) { }

	[NativeName("GetFloatFromScript")]
	private float GetFloatImpl(int name) { }

	private static float GetFloatImpl_Injected(IntPtr _unity_self, int name) { }

	public int GetInt(string name) { }

	[FreeFunction("MaterialScripting::GetShaderKeywords", HasExplicitThis = True)]
	private String[] GetShaderKeywords() { }

	private static String[] GetShaderKeywords_Injected(IntPtr _unity_self) { }

	public Texture GetTexture(int nameID) { }

	[NativeName("GetTextureFromScript")]
	private Texture GetTextureImpl(int name) { }

	private static IntPtr GetTextureImpl_Injected(IntPtr _unity_self, int name) { }

	public Vector2 GetTextureOffset(int nameID) { }

	public Vector2 GetTextureOffset(string name) { }

	public Vector2 GetTextureScale(string name) { }

	public Vector2 GetTextureScale(int nameID) { }

	[NativeName("GetTextureScaleAndOffsetFromScript")]
	private Vector4 GetTextureScaleAndOffsetImpl(int name) { }

	private static void GetTextureScaleAndOffsetImpl_Injected(IntPtr _unity_self, int name, out Vector4 ret) { }

	public Vector4 GetVector(int nameID) { }

	public Vector4 GetVector(string name) { }

	public bool HasFloat(int nameID) { }

	[NativeName("HasFloatFromScript")]
	private bool HasFloatImpl(int name) { }

	private static bool HasFloatImpl_Injected(IntPtr _unity_self, int name) { }

	public bool HasProperty(string name) { }

	[NativeName("HasPropertyFromScript")]
	public bool HasProperty(int nameID) { }

	private static bool HasProperty_Injected(IntPtr _unity_self, int nameID) { }

	public bool IsKeywordEnabled(string keyword) { }

	private static bool IsKeywordEnabled_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword) { }

	public void set_color(Color value) { }

	public void set_enabledKeywords(LocalKeyword[] value) { }

	public void set_enableInstancing(bool value) { }

	private static void set_enableInstancing_Injected(IntPtr _unity_self, bool value) { }

	public void set_mainTextureOffset(Vector2 value) { }

	public void set_mainTextureScale(Vector2 value) { }

	[NativeName("SetCustomRenderQueue")]
	public void set_renderQueue(int value) { }

	private static void set_renderQueue_Injected(IntPtr _unity_self, int value) { }

	public void set_shader(Shader value) { }

	private static void set_shader_Injected(IntPtr _unity_self, IntPtr value) { }

	public void set_shaderKeywords(String[] value) { }

	public void SetBuffer(string name, GraphicsBuffer value) { }

	public void SetColor(string name, Color value) { }

	public void SetColor(int nameID, Color value) { }

	[NativeName("SetColorFromScript")]
	private void SetColorImpl(int name, Color value) { }

	private static void SetColorImpl_Injected(IntPtr _unity_self, int name, in Color value) { }

	public void SetConstantBuffer(int nameID, ComputeBuffer value, int offset, int size) { }

	[NativeName("SetConstantBufferFromScript")]
	private void SetConstantBufferImpl(int name, ComputeBuffer value, int offset, int size) { }

	private static void SetConstantBufferImpl_Injected(IntPtr _unity_self, int name, IntPtr value, int offset, int size) { }

	[FreeFunction("MaterialScripting::SetEnabledKeywords", HasExplicitThis = True)]
	private void SetEnabledKeywords(LocalKeyword[] keywords) { }

	private static void SetEnabledKeywords_Injected(IntPtr _unity_self, LocalKeyword[] keywords) { }

	public void SetFloat(int nameID, float value) { }

	public void SetFloat(string name, float value) { }

	private void SetFloatArray(int name, Single[] values, int count) { }

	public void SetFloatArray(int nameID, Single[] values) { }

	[FreeFunction(Name = "MaterialScripting::SetFloatArray", HasExplicitThis = True)]
	private void SetFloatArrayImpl(int name, Single[] values, int count) { }

	private static void SetFloatArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count) { }

	[NativeName("SetFloatFromScript")]
	private void SetFloatImpl(int name, float value) { }

	private static void SetFloatImpl_Injected(IntPtr _unity_self, int name, float value) { }

	[NativeName("SetBufferFromScript")]
	private void SetGraphicsBufferImpl(int name, GraphicsBuffer value) { }

	private static void SetGraphicsBufferImpl_Injected(IntPtr _unity_self, int name, IntPtr value) { }

	public void SetInt(string name, int value) { }

	public void SetInteger(int nameID, int value) { }

	[NativeName("SetIntFromScript")]
	private void SetIntImpl(int name, int value) { }

	private static void SetIntImpl_Injected(IntPtr _unity_self, int name, int value) { }

	public void SetMatrix(int nameID, Matrix4x4 value) { }

	public void SetMatrix(string name, Matrix4x4 value) { }

	public void SetMatrixArray(int nameID, Matrix4x4[] values) { }

	private void SetMatrixArray(int name, Matrix4x4[] values, int count) { }

	[FreeFunction(Name = "MaterialScripting::SetMatrixArray", HasExplicitThis = True)]
	private void SetMatrixArrayImpl(int name, Matrix4x4[] values, int count) { }

	private static void SetMatrixArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count) { }

	[NativeName("SetMatrixFromScript")]
	private void SetMatrixImpl(int name, Matrix4x4 value) { }

	private static void SetMatrixImpl_Injected(IntPtr _unity_self, int name, in Matrix4x4 value) { }

	[FreeFunction("MaterialScripting::SetPass", HasExplicitThis = True)]
	public bool SetPass(int pass) { }

	private static bool SetPass_Injected(IntPtr _unity_self, int pass) { }

	[FreeFunction("MaterialScripting::SetShaderKeywords", HasExplicitThis = True)]
	private void SetShaderKeywords(String[] names) { }

	private static void SetShaderKeywords_Injected(IntPtr _unity_self, String[] names) { }

	public void SetTexture(string name, Texture value) { }

	public void SetTexture(int nameID, Texture value) { }

	[NativeName("SetTextureFromScript")]
	private void SetTextureImpl(int name, Texture value) { }

	private static void SetTextureImpl_Injected(IntPtr _unity_self, int name, IntPtr value) { }

	public void SetTextureOffset(int nameID, Vector2 value) { }

	public void SetTextureOffset(string name, Vector2 value) { }

	[NativeName("SetTextureOffsetFromScript")]
	private void SetTextureOffsetImpl(int name, Vector2 offset) { }

	private static void SetTextureOffsetImpl_Injected(IntPtr _unity_self, int name, in Vector2 offset) { }

	public void SetTextureScale(int nameID, Vector2 value) { }

	public void SetTextureScale(string name, Vector2 value) { }

	[NativeName("SetTextureScaleFromScript")]
	private void SetTextureScaleImpl(int name, Vector2 scale) { }

	private static void SetTextureScaleImpl_Injected(IntPtr _unity_self, int name, in Vector2 scale) { }

	public void SetVector(int nameID, Vector4 value) { }

	public void SetVector(string name, Vector4 value) { }

	public void SetVectorArray(string name, Vector4[] values) { }

	private void SetVectorArray(int name, Vector4[] values, int count) { }

	public void SetVectorArray(int nameID, Vector4[] values) { }

	[FreeFunction(Name = "MaterialScripting::SetVectorArray", HasExplicitThis = True)]
	private void SetVectorArrayImpl(int name, Vector4[] values, int count) { }

	private static void SetVectorArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count) { }

}

