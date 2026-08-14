namespace UnityEngine.Rendering.Universal;

[AddComponentMenu("Rendering/URP Decal Projector")]
[ExecuteAlways]
public class DecalProjector : MonoBehaviour
{
	public sealed class DecalProjectorAction : MulticastDelegate
	{

		public DecalProjectorAction(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(DecalProjector decalProjector, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(DecalProjector decalProjector) { }

	}

	[CompilerGenerated]
	private static DecalProjectorAction onDecalAdd; //Field offset: 0x0
	[CompilerGenerated]
	private static DecalProjectorAction onDecalRemove; //Field offset: 0x8
	[CompilerGenerated]
	private static DecalProjectorAction onDecalPropertyChange; //Field offset: 0x10
	[CompilerGenerated]
	private static Action onAllDecalPropertyChange; //Field offset: 0x18
	[CompilerGenerated]
	private static DecalProjectorAction onDecalMaterialChange; //Field offset: 0x20
	[CompilerGenerated]
	private static Material <defaultMaterial>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private DecalEntity <decalEntity>k__BackingField; //Field offset: 0x20
	[SerializeField]
	private Material m_Material; //Field offset: 0x28
	[SerializeField]
	private float m_DrawDistance; //Field offset: 0x30
	[Range(0, 1)]
	[SerializeField]
	private float m_FadeScale; //Field offset: 0x34
	[Range(0, 180)]
	[SerializeField]
	private float m_StartAngleFade; //Field offset: 0x38
	[Range(0, 180)]
	[SerializeField]
	private float m_EndAngleFade; //Field offset: 0x3C
	[SerializeField]
	private Vector2 m_UVScale; //Field offset: 0x40
	[SerializeField]
	private Vector2 m_UVBias; //Field offset: 0x48
	[SerializeField]
	private uint m_DecalLayerMask; //Field offset: 0x50
	[SerializeField]
	private DecalScaleMode m_ScaleMode; //Field offset: 0x54
	[SerializeField]
	internal Vector3 m_Offset; //Field offset: 0x58
	[SerializeField]
	internal Vector3 m_Size; //Field offset: 0x64
	[Range(0, 1)]
	[SerializeField]
	private float m_FadeFactor; //Field offset: 0x70
	private Material m_OldMaterial; //Field offset: 0x78

	internal static event Action onAllDecalPropertyChange
	{
		[CompilerGenerated]
		internal add { } //Length: 184
		[CompilerGenerated]
		internal remove { } //Length: 184
	}

	internal static event DecalProjectorAction onDecalAdd
	{
		[CompilerGenerated]
		internal add { } //Length: 180
		[CompilerGenerated]
		internal remove { } //Length: 180
	}

	internal static event DecalProjectorAction onDecalMaterialChange
	{
		[CompilerGenerated]
		internal add { } //Length: 184
		[CompilerGenerated]
		internal remove { } //Length: 184
	}

	internal static event DecalProjectorAction onDecalPropertyChange
	{
		[CompilerGenerated]
		internal add { } //Length: 184
		[CompilerGenerated]
		internal remove { } //Length: 184
	}

	internal static event DecalProjectorAction onDecalRemove
	{
		[CompilerGenerated]
		internal add { } //Length: 184
		[CompilerGenerated]
		internal remove { } //Length: 184
	}

	internal DecalEntity decalEntity
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 5
	}

	internal Vector3 decalOffset
	{
		internal get { } //Length: 32
	}

	internal Vector3 decalSize
	{
		internal get { } //Length: 21
	}

	internal static Material defaultMaterial
	{
		[CompilerGenerated]
		internal get { } //Length: 55
		[CompilerGenerated]
		internal set { } //Length: 86
	}

	public float drawDistance
	{
		 get { } //Length: 6
		 set { } //Length: 21
	}

	internal Vector3 effectiveScale
	{
		internal get { } //Length: 143
	}

	public float endAngleFade
	{
		 get { } //Length: 6
		 set { } //Length: 38
	}

	public float fadeFactor
	{
		 get { } //Length: 6
		 set { } //Length: 51
	}

	public float fadeScale
	{
		 get { } //Length: 6
		 set { } //Length: 51
	}

	internal static bool isSupported
	{
		internal get { } //Length: 58
	}

	public Material material
	{
		 get { } //Length: 5
		 set { } //Length: 37
	}

	public Vector3 pivot
	{
		 get { } //Length: 19
		 set { } //Length: 22
	}

	public uint renderingLayerMask
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public DecalScaleMode scaleMode
	{
		 get { } //Length: 4
		 set { } //Length: 10
	}

	public Vector3 size
	{
		 get { } //Length: 19
		 set { } //Length: 22
	}

	public float startAngleFade
	{
		 get { } //Length: 6
		 set { } //Length: 51
	}

	public Vector2 uvBias
	{
		 get { } //Length: 19
		 set { } //Length: 11
	}

	public Vector2 uvScale
	{
		 get { } //Length: 19
		 set { } //Length: 11
	}

	internal Vector4 uvScaleBias
	{
		internal get { } //Length: 27
	}

	public DecalProjector() { }

	[CompilerGenerated]
	internal static void add_onAllDecalPropertyChange(Action value) { }

	[CompilerGenerated]
	internal static void add_onDecalAdd(DecalProjectorAction value) { }

	[CompilerGenerated]
	internal static void add_onDecalMaterialChange(DecalProjectorAction value) { }

	[CompilerGenerated]
	internal static void add_onDecalPropertyChange(DecalProjectorAction value) { }

	[CompilerGenerated]
	internal static void add_onDecalRemove(DecalProjectorAction value) { }

	[CompilerGenerated]
	internal DecalEntity get_decalEntity() { }

	internal Vector3 get_decalOffset() { }

	internal Vector3 get_decalSize() { }

	[CompilerGenerated]
	internal static Material get_defaultMaterial() { }

	public float get_drawDistance() { }

	internal Vector3 get_effectiveScale() { }

	public float get_endAngleFade() { }

	public float get_fadeFactor() { }

	public float get_fadeScale() { }

	internal static bool get_isSupported() { }

	public Material get_material() { }

	public Vector3 get_pivot() { }

	public uint get_renderingLayerMask() { }

	public DecalScaleMode get_scaleMode() { }

	public Vector3 get_size() { }

	public float get_startAngleFade() { }

	public Vector2 get_uvBias() { }

	public Vector2 get_uvScale() { }

	internal Vector4 get_uvScaleBias() { }

	private void InitMaterial() { }

	public bool IsValid() { }

	private void OnDisable() { }

	private void OnEnable() { }

	internal void OnValidate() { }

	[CompilerGenerated]
	internal static void remove_onAllDecalPropertyChange(Action value) { }

	[CompilerGenerated]
	internal static void remove_onDecalAdd(DecalProjectorAction value) { }

	[CompilerGenerated]
	internal static void remove_onDecalMaterialChange(DecalProjectorAction value) { }

	[CompilerGenerated]
	internal static void remove_onDecalPropertyChange(DecalProjectorAction value) { }

	[CompilerGenerated]
	internal static void remove_onDecalRemove(DecalProjectorAction value) { }

	[CompilerGenerated]
	internal void set_decalEntity(DecalEntity value) { }

	[CompilerGenerated]
	internal static void set_defaultMaterial(Material value) { }

	public void set_drawDistance(float value) { }

	public void set_endAngleFade(float value) { }

	public void set_fadeFactor(float value) { }

	public void set_fadeScale(float value) { }

	public void set_material(Material value) { }

	public void set_pivot(Vector3 value) { }

	public void set_renderingLayerMask(uint value) { }

	public void set_scaleMode(DecalScaleMode value) { }

	public void set_size(Vector3 value) { }

	public void set_startAngleFade(float value) { }

	public void set_uvBias(Vector2 value) { }

	public void set_uvScale(Vector2 value) { }

	internal static void UpdateAllDecalProperties() { }

}

