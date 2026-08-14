namespace UnityEngine.UIElements;

public class Image : VisualElement
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<Image, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{

		public UxmlTraits() { }

	}

	internal static readonly BindingId imageProperty; //Field offset: 0x0
	internal static readonly BindingId spriteProperty; //Field offset: 0x98
	internal static readonly BindingId vectorImageProperty; //Field offset: 0x130
	internal static readonly BindingId sourceRectProperty; //Field offset: 0x1C8
	internal static readonly BindingId uvProperty; //Field offset: 0x260
	internal static readonly BindingId scaleModeProperty; //Field offset: 0x2F8
	internal static readonly BindingId tintColorProperty; //Field offset: 0x390
	public static readonly string ussClassName; //Field offset: 0x428
	private static CustomStyleProperty<Texture2D> s_ImageProperty; //Field offset: 0x430
	private static CustomStyleProperty<Sprite> s_SpriteProperty; //Field offset: 0x438
	private static CustomStyleProperty<VectorImage> s_VectorImageProperty; //Field offset: 0x440
	private static CustomStyleProperty<String> s_ScaleModeProperty; //Field offset: 0x448
	private static CustomStyleProperty<Color> s_TintColorProperty; //Field offset: 0x450
	private ScaleMode m_ScaleMode; //Field offset: 0x4A8
	private Texture m_Image; //Field offset: 0x4B0
	private Sprite m_Sprite; //Field offset: 0x4B8
	private VectorImage m_VectorImage; //Field offset: 0x4C0
	private Rect m_UV; //Field offset: 0x4C8
	private Color m_TintColor; //Field offset: 0x4D8
	internal bool m_ImageIsInline; //Field offset: 0x4E8
	private bool m_ScaleModeIsInline; //Field offset: 0x4E9
	private bool m_TintColorIsInline; //Field offset: 0x4EA

	[CreateProperty]
	public Texture image
	{
		 get { } //Length: 8
		 set { } //Length: 408
	}

	[CreateProperty]
	public ScaleMode scaleMode
	{
		 get { } //Length: 7
		 set { } //Length: 33
	}

	[CreateProperty]
	public Rect sourceRect
	{
		 get { } //Length: 37
		 set { } //Length: 376
	}

	[CreateProperty]
	public Sprite sprite
	{
		 get { } //Length: 8
		 set { } //Length: 433
	}

	[CreateProperty]
	public Color tintColor
	{
		 get { } //Length: 14
		 set { } //Length: 152
	}

	[CreateProperty]
	public Rect uv
	{
		 get { } //Length: 14
		 set { } //Length: 195
	}

	[CreateProperty]
	public VectorImage vectorImage
	{
		 get { } //Length: 8
		 set { } //Length: 433
	}

	private static Image() { }

	public Image() { }

	private void CalculateUV(Rect srcRect) { }

	private void ClearProperty() { }

	protected private virtual Vector2 DoMeasure(float desiredWidth, MeasureMode widthMode, float desiredHeight, MeasureMode heightMode) { }

	public Texture get_image() { }

	public ScaleMode get_scaleMode() { }

	public Rect get_sourceRect() { }

	public Sprite get_sprite() { }

	public Color get_tintColor() { }

	public Rect get_uv() { }

	public VectorImage get_vectorImage() { }

	private Rect GetSourceRect() { }

	private Vector2 GetTextureDisplaySize(Texture texture) { }

	private Vector2 GetTextureDisplaySize(Sprite sprite) { }

	private void OnCustomStyleResolved(CustomStyleResolvedEvent e) { }

	private void OnGenerateVisualContent(MeshGenerationContext mgc) { }

	private void ReadCustomProperties(ICustomStyle customStyleProvider) { }

	public void set_image(Texture value) { }

	public void set_scaleMode(ScaleMode value) { }

	public void set_sourceRect(Rect value) { }

	public void set_sprite(Sprite value) { }

	public void set_tintColor(Color value) { }

	public void set_uv(Rect value) { }

	public void set_vectorImage(VectorImage value) { }

	private void SetProperty(T0 src, ref T0 dst, ref T1 alt0, ref T2 alt1, BindingId binding) { }

	private void SetScaleMode(ScaleMode mode) { }

	private void SetTintColor(Color color) { }

}

