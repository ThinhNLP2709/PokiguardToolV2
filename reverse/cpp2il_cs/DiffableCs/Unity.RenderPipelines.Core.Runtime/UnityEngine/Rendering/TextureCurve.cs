namespace UnityEngine.Rendering;

[DefaultMember("Item")]
public class TextureCurve : IDisposable
{
	private const int k_Precision = 128; //Field offset: 0x0
	private const float k_Step = 0.0078125; //Field offset: 0x0
	[CompilerGenerated]
	[SerializeField]
	private int <length>k__BackingField; //Field offset: 0x10
	[SerializeField]
	private bool m_Loop; //Field offset: 0x14
	[SerializeField]
	private float m_ZeroValue; //Field offset: 0x18
	[SerializeField]
	private float m_Range; //Field offset: 0x1C
	[SerializeField]
	private AnimationCurve m_Curve; //Field offset: 0x20
	private AnimationCurve m_LoopingCurve; //Field offset: 0x28
	private Texture2D m_Texture; //Field offset: 0x30
	private bool m_IsCurveDirty; //Field offset: 0x38
	private bool m_IsTextureDirty; //Field offset: 0x39

	public Keyframe Item
	{
		 get { } //Length: 67
	}

	public private int length
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public TextureCurve(AnimationCurve baseCurve, float zeroValue, bool loop, in Vector2 bounds) { }

	public TextureCurve(Keyframe[] keys, float zeroValue, bool loop, in Vector2 bounds) { }

	public int AddKey(float time, float value) { }

	public override void Dispose() { }

	public float Evaluate(float time) { }

	public Keyframe get_Item(int index) { }

	[CompilerGenerated]
	public int get_length() { }

	public Texture2D GetTexture() { }

	private static GraphicsFormat GetTextureFormat() { }

	public int MoveKey(int index, in Keyframe key) { }

	public void Release() { }

	public void RemoveKey(int index) { }

	[CompilerGenerated]
	private void set_length(int value) { }

	public void SetDirty() { }

	public void SmoothTangents(int index, float weight) { }

}

