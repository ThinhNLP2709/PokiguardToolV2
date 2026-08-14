namespace UnityEngine;

[NativeHeader("Runtime/Graphics/RenderTexture.h")]
[NativeHeader("Runtime/Camera/Camera.h")]
[NativeHeader("Runtime/Graphics/RenderBufferManager.h")]
[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
[UsedByNativeCode]
public class RenderTexture : Texture
{

	public static RenderTexture active
	{
		 get { } //Length: 84
		 set { } //Length: 107
	}

	public int antiAliasing
	{
		 get { } //Length: 118
	}

	public bool autoGenerateMips
	{
		 set { } //Length: 134
	}

	public bool bindTextureMS
	{
		 get { } //Length: 118
	}

	public RenderBuffer colorBuffer
	{
		 get { } //Length: 160
	}

	public RenderBuffer depthBuffer
	{
		 get { } //Length: 160
	}

	public GraphicsFormat depthStencilFormat
	{
		 get { } //Length: 118
		 set { } //Length: 131
	}

	public RenderTextureDescriptor descriptor
	{
		 get { } //Length: 213
	}

	public virtual TextureDimension dimension
	{
		 get { } //Length: 118
		 set { } //Length: 131
	}

	public bool enableRandomWrite
	{
		 set { } //Length: 134
	}

	public RenderTextureFormat format
	{
		 get { } //Length: 417
	}

	public GraphicsFormat graphicsFormat
	{
		 get { } //Length: 120
		 set { } //Length: 131
	}

	public virtual int height
	{
		 get { } //Length: 118
		 set { } //Length: 131
	}

	[NativeProperty("SRGBReadWrite")]
	public bool sRGB
	{
		 get { } //Length: 118
	}

	public bool useDynamicScale
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public bool useDynamicScaleExplicit
	{
		 get { } //Length: 118
	}

	[NativeProperty("MipMap")]
	public bool useMipMap
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public int volumeDepth
	{
		 get { } //Length: 118
		 set { } //Length: 131
	}

	public virtual int width
	{
		 get { } //Length: 118
		 set { } //Length: 131
	}

	[RequiredByNativeCode]
	protected private RenderTexture() { }

	public RenderTexture(RenderTexture textureToCopy) { }

	[ExcludeFromDocs]
	public RenderTexture(int width, int height, int depth, DefaultFormat format) { }

	[ExcludeFromDocs]
	public RenderTexture(int width, int height, int depth, GraphicsFormat format) { }

	[ExcludeFromDocs]
	public RenderTexture(int width, int height, int depth, GraphicsFormat format, int mipCount) { }

	[ExcludeFromDocs]
	public RenderTexture(int width, int height, int depth, RenderTextureFormat format, int mipCount) { }

	[ExcludeFromDocs]
	public RenderTexture(int width, int height, int depth) { }

	[ExcludeFromDocs]
	public RenderTexture(int width, int height, int depth, RenderTextureFormat format) { }

	[ExcludeFromDocs]
	public RenderTexture(int width, int height, GraphicsFormat colorFormat, GraphicsFormat depthStencilFormat, int mipCount) { }

	public RenderTexture(int width, int height, int depth, RenderTextureFormat format, RenderTextureReadWrite readWrite) { }

	[ExcludeFromDocs]
	public RenderTexture(int width, int height, GraphicsFormat colorFormat, GraphicsFormat depthStencilFormat) { }

	public RenderTexture(RenderTextureDescriptor desc) { }

	public void ApplyDynamicScale() { }

	private static void ApplyDynamicScale_Injected(IntPtr _unity_self) { }

	public bool Create() { }

	private static bool Create_Injected(IntPtr _unity_self) { }

	public static RenderTexture get_active() { }

	public int get_antiAliasing() { }

	private static int get_antiAliasing_Injected(IntPtr _unity_self) { }

	public bool get_bindTextureMS() { }

	private static bool get_bindTextureMS_Injected(IntPtr _unity_self) { }

	public RenderBuffer get_colorBuffer() { }

	public RenderBuffer get_depthBuffer() { }

	public GraphicsFormat get_depthStencilFormat() { }

	private static GraphicsFormat get_depthStencilFormat_Injected(IntPtr _unity_self) { }

	public RenderTextureDescriptor get_descriptor() { }

	public virtual TextureDimension get_dimension() { }

	private static TextureDimension get_dimension_Injected(IntPtr _unity_self) { }

	public RenderTextureFormat get_format() { }

	public GraphicsFormat get_graphicsFormat() { }

	public virtual int get_height() { }

	private static int get_height_Injected(IntPtr _unity_self) { }

	public bool get_sRGB() { }

	private static bool get_sRGB_Injected(IntPtr _unity_self) { }

	public bool get_useDynamicScale() { }

	private static bool get_useDynamicScale_Injected(IntPtr _unity_self) { }

	public bool get_useDynamicScaleExplicit() { }

	private static bool get_useDynamicScaleExplicit_Injected(IntPtr _unity_self) { }

	public bool get_useMipMap() { }

	private static bool get_useMipMap_Injected(IntPtr _unity_self) { }

	public int get_volumeDepth() { }

	private static int get_volumeDepth_Injected(IntPtr _unity_self) { }

	public virtual int get_width() { }

	private static int get_width_Injected(IntPtr _unity_self) { }

	[FreeFunction("RenderTexture::GetActiveAsRenderTexture")]
	private static RenderTexture GetActive() { }

	private static IntPtr GetActive_Injected() { }

	[FreeFunction(Name = "RenderTextureScripting::GetColorBuffer", HasExplicitThis = True)]
	private RenderBuffer GetColorBuffer() { }

	private static void GetColorBuffer_Injected(IntPtr _unity_self, out RenderBuffer ret) { }

	[NativeName("GetColorFormat")]
	private GraphicsFormat GetColorFormat(bool suppressWarnings) { }

	private static GraphicsFormat GetColorFormat_Injected(IntPtr _unity_self, bool suppressWarnings) { }

	internal static GraphicsFormat GetCompatibleFormat(RenderTextureFormat renderTextureFormat, RenderTextureReadWrite readWrite) { }

	internal static GraphicsFormat GetDefaultColorFormat(DefaultFormat format) { }

	internal static GraphicsFormat GetDefaultDepthStencilFormat(DefaultFormat format, int depth) { }

	[FreeFunction(Name = "RenderTextureScripting::GetDepthBuffer", HasExplicitThis = True)]
	private RenderBuffer GetDepthBuffer() { }

	private static void GetDepthBuffer_Injected(IntPtr _unity_self, out RenderBuffer ret) { }

	internal static GraphicsFormat GetDepthStencilFormatLegacy(int depthBits, GraphicsFormat colorFormat) { }

	internal static GraphicsFormat GetDepthStencilFormatLegacy(int depthBits, DefaultFormat format) { }

	internal static GraphicsFormat GetDepthStencilFormatLegacy(int depthBits, ShadowSamplingMode shadowSamplingMode) { }

	internal static GraphicsFormat GetDepthStencilFormatLegacy(int depthBits, bool requestedShadowMap) { }

	internal static GraphicsFormat GetDepthStencilFormatLegacy(int depthBits, RenderTextureFormat format, bool disableFallback = false) { }

	[NativeName("GetRenderTextureDesc")]
	private RenderTextureDescriptor GetDescriptor() { }

	private static void GetDescriptor_Injected(IntPtr _unity_self, out RenderTextureDescriptor ret) { }

	internal static ShadowSamplingMode GetShadowSamplingModeForFormat(DefaultFormat format) { }

	internal static ShadowSamplingMode GetShadowSamplingModeForFormat(RenderTextureFormat format) { }

	public static RenderTexture GetTemporary(RenderTextureDescriptor desc) { }

	[ExcludeFromDocs]
	public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, RenderTextureMemoryless memorylessMode) { }

	[ExcludeFromDocs]
	public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite) { }

	public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, RenderTextureMemoryless memorylessMode, VRTextureUsage vrUsage, bool useDynamicScale) { }

	[ExcludeFromDocs]
	public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format) { }

	[ExcludeFromDocs]
	public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing) { }

	[ExcludeFromDocs]
	public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing, RenderTextureMemoryless memorylessMode, VRTextureUsage vrUsage) { }

	[FreeFunction("GetRenderBufferManager().GetTextures().GetTempBuffer")]
	private static RenderTexture GetTemporary_Internal(RenderTextureDescriptor desc) { }

	private static IntPtr GetTemporary_Internal_Injected(in RenderTextureDescriptor desc) { }

	private static RenderTexture GetTemporaryImpl(int width, int height, GraphicsFormat depthStencilFormat, GraphicsFormat colorFormat, int antiAliasing = 1, RenderTextureMemoryless memorylessMode = 0, VRTextureUsage vrUsage = 0, bool useDynamicScale = false, ShadowSamplingMode shadowSamplingMode = 2) { }

	private void Initialize(int width, int height, int depth, RenderTextureFormat format, RenderTextureReadWrite readWrite, int mipCount) { }

	[FreeFunction("RenderTextureScripting::Create")]
	private static void Internal_Create(RenderTexture rt) { }

	public void Release() { }

	private static void Release_Injected(IntPtr _unity_self) { }

	[FreeFunction("GetRenderBufferManager().GetTextures().ReleaseTempBuffer")]
	public static void ReleaseTemporary(RenderTexture temp) { }

	private static void ReleaseTemporary_Injected(IntPtr temp) { }

	public static void set_active(RenderTexture value) { }

	public void set_autoGenerateMips(bool value) { }

	private static void set_autoGenerateMips_Injected(IntPtr _unity_self, bool value) { }

	public void set_depthStencilFormat(GraphicsFormat value) { }

	private static void set_depthStencilFormat_Injected(IntPtr _unity_self, GraphicsFormat value) { }

	public virtual void set_dimension(TextureDimension value) { }

	private static void set_dimension_Injected(IntPtr _unity_self, TextureDimension value) { }

	public void set_enableRandomWrite(bool value) { }

	private static void set_enableRandomWrite_Injected(IntPtr _unity_self, bool value) { }

	public void set_graphicsFormat(GraphicsFormat value) { }

	public virtual void set_height(int value) { }

	private static void set_height_Injected(IntPtr _unity_self, int value) { }

	public void set_useDynamicScale(bool value) { }

	private static void set_useDynamicScale_Injected(IntPtr _unity_self, bool value) { }

	public void set_useMipMap(bool value) { }

	private static void set_useMipMap_Injected(IntPtr _unity_self, bool value) { }

	public void set_volumeDepth(int value) { }

	private static void set_volumeDepth_Injected(IntPtr _unity_self, int value) { }

	public virtual void set_width(int value) { }

	private static void set_width_Injected(IntPtr _unity_self, int value) { }

	[FreeFunction("RenderTextureScripting::SetActive")]
	private static void SetActive(RenderTexture rt) { }

	private static void SetActive_Injected(IntPtr rt) { }

	[NativeName("SetColorFormat")]
	private void SetColorFormat(GraphicsFormat format) { }

	private static void SetColorFormat_Injected(IntPtr _unity_self, GraphicsFormat format) { }

	private void SetMipMapCount(int count) { }

	private static void SetMipMapCount_Injected(IntPtr _unity_self, int count) { }

	[NativeName("SetRenderTextureDescFromScript")]
	private void SetRenderTextureDescriptor(RenderTextureDescriptor desc) { }

	private static void SetRenderTextureDescriptor_Injected(IntPtr _unity_self, in RenderTextureDescriptor desc) { }

	internal void SetShadowSamplingMode(ShadowSamplingMode samplingMode) { }

	private static void SetShadowSamplingMode_Injected(IntPtr _unity_self, ShadowSamplingMode samplingMode) { }

	internal void SetSRGBReadWrite(bool srgb) { }

	private static void SetSRGBReadWrite_Injected(IntPtr _unity_self, bool srgb) { }

	private static void ValidateRenderTextureDesc(ref RenderTextureDescriptor desc) { }

	internal static void WarnAboutFallbackTo16BitsDepth(RenderTextureFormat format) { }

}

