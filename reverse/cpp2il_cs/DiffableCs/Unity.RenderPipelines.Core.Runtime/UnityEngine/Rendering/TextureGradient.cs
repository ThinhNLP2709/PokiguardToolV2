namespace UnityEngine.Rendering;

public class TextureGradient : IDisposable
{
	[CompilerGenerated]
	[HideInInspector]
	[SerializeField]
	private int <textureSize>k__BackingField; //Field offset: 0x10
	[SerializeField]
	private Gradient m_Gradient; //Field offset: 0x18
	private Texture2D m_Texture; //Field offset: 0x20
	private int m_RequestedTextureSize; //Field offset: 0x28
	private bool m_IsTextureDirty; //Field offset: 0x2C
	private bool m_Precise; //Field offset: 0x2D
	[HideInInspector]
	[SerializeField]
	public GradientMode mode; //Field offset: 0x30
	[HideInInspector]
	[SerializeField]
	public ColorSpace colorSpace; //Field offset: 0x34

	[HideInInspector]
	public GradientAlphaKey[] alphaKeys
	{
		 get { } //Length: 19
	}

	[HideInInspector]
	public GradientColorKey[] colorKeys
	{
		 get { } //Length: 19
	}

	public private int textureSize
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public TextureGradient(Gradient baseCurve) { }

	public TextureGradient(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys, GradientMode mode = 2, ColorSpace colorSpace = -1, int requestedTextureSize = -1, bool precise = false) { }

	public override void Dispose() { }

	public Color Evaluate(float time) { }

	public GradientAlphaKey[] get_alphaKeys() { }

	public GradientColorKey[] get_colorKeys() { }

	[CompilerGenerated]
	public int get_textureSize() { }

	public Texture2D GetTexture() { }

	private static GraphicsFormat GetTextureFormat() { }

	private void Rebuild(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys, GradientMode mode, ColorSpace colorSpace, int requestedTextureSize, bool precise) { }

	public void Release() { }

	[CompilerGenerated]
	private void set_textureSize(int value) { }

	public void SetDirty() { }

	public void SetKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys, GradientMode mode, ColorSpace colorSpace) { }

}

