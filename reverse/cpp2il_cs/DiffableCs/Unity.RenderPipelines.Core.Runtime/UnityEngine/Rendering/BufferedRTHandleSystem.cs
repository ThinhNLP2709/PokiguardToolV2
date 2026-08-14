namespace UnityEngine.Rendering;

public class BufferedRTHandleSystem : IDisposable
{
	[CompilerGenerated]
	private struct <>c__DisplayClass12_0
	{
		public BufferedRTHandleSystem <>4__this; //Field offset: 0x0
		public GraphicsFormat format; //Field offset: 0x8

	}

	private Dictionary<Int32, RTHandle[]> m_RTHandles; //Field offset: 0x10
	private RTHandleSystem m_RTHandleSystem; //Field offset: 0x18
	private bool m_DisposedValue; //Field offset: 0x20

	public int maxHeight
	{
		 get { } //Length: 26
	}

	public int maxWidth
	{
		 get { } //Length: 26
	}

	public RTHandleProperties rtHandleProperties
	{
		 get { } //Length: 49
	}

	public BufferedRTHandleSystem() { }

	[CompilerGenerated]
	private RTHandle <AllocBuffer>g__Alloc|12_0(ref RenderTextureDescriptor d, FilterMode fMode, TextureWrapMode wMode, bool isShadow, int aniso, float mipBias, string n, ref <>c__DisplayClass12_0 unnamed_param_7) { }

	public void AllocBuffer(int bufferId, Func<RTHandleSystem, Int32, RTHandle> allocator, int bufferCount) { }

	public void AllocBuffer(int bufferId, int bufferCount, ref RenderTextureDescriptor descriptor, FilterMode filterMode = 0, TextureWrapMode wrapMode = 0, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0, string name = "") { }

	public Vector2 CalculateRatioAgainstMaxSize(int width, int height) { }

	public void ClearBuffers(CommandBuffer cmd) { }

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

	public int get_maxHeight() { }

	public int get_maxWidth() { }

	public RTHandleProperties get_rtHandleProperties() { }

	public RTHandle GetFrameRT(int bufferId, int frameIndex) { }

	public int GetNumFramesAllocated(int bufferId) { }

	public void ReleaseAll() { }

	public void ReleaseBuffer(int bufferId) { }

	public void ResetReferenceSize(int width, int height) { }

	private void Swap() { }

	public void SwapAndSetReferenceSize(int width, int height) { }

}

