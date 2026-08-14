namespace UnityEngine.U2D.Animation;

[AddComponentMenu("2D Animation/Sprite Skin")]
[DefaultExecutionOrder(10)]
[DisallowMultipleComponent]
[ExecuteInEditMode]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.2d.animation@latest/index.html?subfolder=/manual/SpriteSkin.html")]
[MovedFrom("UnityEngine.U2D.Experimental.Animation")]
[Preserve]
[RequireComponent(typeof(SpriteRenderer))]
public sealed class SpriteSkin : MonoBehaviour, IPreviewable, IAnimationPreviewable, ISerializationCallbackReceiver
{
	public static class Profiling
	{
		public static readonly ProfilerMarker cacheCurrentSprite; //Field offset: 0x0
		public static readonly ProfilerMarker cacheHierarchy; //Field offset: 0x8
		public static readonly ProfilerMarker getSpriteBonesTransformFromGuid; //Field offset: 0x10
		public static readonly ProfilerMarker getSpriteBonesTransformFromPath; //Field offset: 0x18

		private static Profiling() { }

	}

	public struct TransformData
	{
		public string fullName; //Field offset: 0x0
		public Transform transform; //Field offset: 0x8

	}

	[SerializeField]
	private Transform m_RootBone; //Field offset: 0x20
	[SerializeField]
	private Transform[] m_BoneTransforms; //Field offset: 0x28
	[SerializeField]
	private Bounds m_Bounds; //Field offset: 0x30
	[SerializeField]
	private bool m_AlwaysUpdate; //Field offset: 0x48
	[SerializeField]
	private bool m_AutoRebind; //Field offset: 0x49
	private NativeByteArray m_DeformedVertices; //Field offset: 0x50
	private int m_CurrentDeformVerticesLength; //Field offset: 0x58
	private SpriteRenderer m_SpriteRenderer; //Field offset: 0x60
	private int m_CurrentDeformSprite; //Field offset: 0x68
	private int m_SpriteId; //Field offset: 0x6C
	private bool m_IsValid; //Field offset: 0x70
	private SpriteSkinState m_State; //Field offset: 0x74
	private int m_TransformsHash; //Field offset: 0x78
	private bool m_ForceCpuDeformation; //Field offset: 0x7C
	private int m_TransformId; //Field offset: 0x80
	private NativeArray<Int32> m_BoneTransformId; //Field offset: 0x88
	private int m_RootBoneTransformId; //Field offset: 0x98
	private NativeCustomSlice<Vector2> m_SpriteUVs; //Field offset: 0xA0
	private NativeCustomSlice<Vector3> m_SpriteVertices; //Field offset: 0xB0
	private NativeCustomSlice<Vector4> m_SpriteTangents; //Field offset: 0xC0
	private NativeCustomSlice<BoneWeight> m_SpriteBoneWeights; //Field offset: 0xD0
	private NativeCustomSlice<Matrix4x4> m_SpriteBindPoses; //Field offset: 0xE0
	private NativeCustomSlice<Int32> m_BoneTransformIdNativeSlice; //Field offset: 0xF0
	private bool m_SpriteHasTangents; //Field offset: 0x100
	private int m_SpriteVertexStreamSize; //Field offset: 0x104
	private int m_SpriteVertexCount; //Field offset: 0x108
	private int m_SpriteTangentVertexOffset; //Field offset: 0x10C
	private int m_DataIndex; //Field offset: 0x110
	private bool m_BoneCacheUpdateToDate; //Field offset: 0x114
	internal Dictionary<Int32, List`1<TransformData>> hierarchyCache; //Field offset: 0x118
	private NativeArray<Int32> m_OutlineIndexCache; //Field offset: 0x120
	private NativeArray<Vector3> m_StaticOutlineVertexCache; //Field offset: 0x130
	private NativeArray<Vector3> m_DeformedOutlineVertexCache; //Field offset: 0x140
	private int m_VertexDeformationHash; //Field offset: 0x150
	private Sprite m_Sprite; //Field offset: 0x158
	[CompilerGenerated]
	private DeformationMethods <currentDeformationMethod>k__BackingField; //Field offset: 0x160
	[CompilerGenerated]
	private BaseDeformationSystem <deformationSystem>k__BackingField; //Field offset: 0x168

	public bool alwaysUpdate
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool autoRebind
	{
		 get { } //Length: 5
		 set { } //Length: 184
	}

	internal NativeArray<Int32> boneTransformId
	{
		internal get { } //Length: 14
	}

	public Transform[] boneTransforms
	{
		 get { } //Length: 5
	}

	internal Bounds bounds
	{
		internal get { } //Length: 21
		internal set { } //Length: 18
	}

	internal DeformationMethods currentDeformationMethod
	{
		[CompilerGenerated]
		internal get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	internal int dataIndex
	{
		internal get { } //Length: 7
	}

	internal BaseDeformationSystem deformationSystem
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public bool forceCpuDeformation
	{
		 get { } //Length: 5
		 set { } //Length: 72
	}

	internal bool isValid
	{
		internal get { } //Length: 22
	}

	internal NativeArray<Int32> outlineIndices
	{
		internal get { } //Length: 14
	}

	internal NativeArray<Vector3> outlineVertices
	{
		internal get { } //Length: 14
	}

	public Transform rootBone
	{
		 get { } //Length: 5
	}

	internal int rootBoneTransformId
	{
		internal get { } //Length: 7
	}

	internal Sprite sprite
	{
		internal get { } //Length: 8
	}

	internal NativeCustomSlice<BoneWeight> spriteBoneWeights
	{
		internal get { } //Length: 14
	}

	internal SpriteRenderer spriteRenderer
	{
		internal get { } //Length: 694
	}

	internal int vertexDeformationHash
	{
		internal get { } //Length: 7
	}

	public SpriteSkin() { }

	internal void Awake() { }

	internal bool BatchValidate() { }

	private void CacheBoneTransformIds() { }

	private void CacheCurrentSprite(bool rebind) { }

	internal void CacheHierarchy() { }

	private void CacheOutlineIndices(out int maxIndex) { }

	private void CacheOutlineVertices(int cacheSize) { }

	private void CacheSpriteOutline() { }

	private SpriteSkinState CacheValidFlag() { }

	internal void CopyToSpriteSkinData(ref SpriteSkinData data) { }

	private static int CountChildren(Transform transform) { }

	internal void DeactivateSkinning() { }

	private void Deform() { }

	private void DisposeOutlineCaches() { }

	public bool get_alwaysUpdate() { }

	public bool get_autoRebind() { }

	internal NativeArray<Int32> get_boneTransformId() { }

	public Transform[] get_boneTransforms() { }

	internal Bounds get_bounds() { }

	[CompilerGenerated]
	internal DeformationMethods get_currentDeformationMethod() { }

	internal int get_dataIndex() { }

	[CompilerGenerated]
	internal BaseDeformationSystem get_deformationSystem() { }

	public bool get_forceCpuDeformation() { }

	internal bool get_isValid() { }

	internal NativeArray<Int32> get_outlineIndices() { }

	internal NativeArray<Vector3> get_outlineVertices() { }

	public Transform get_rootBone() { }

	internal int get_rootBoneTransformId() { }

	internal Sprite get_sprite() { }

	internal NativeCustomSlice<BoneWeight> get_spriteBoneWeights() { }

	internal SpriteRenderer get_spriteRenderer() { }

	internal int get_vertexDeformationHash() { }

	internal NativeSlice<PositionVertex> GetCurrentDeformedVertexPositions() { }

	internal NativeSlice<PositionTangentVertex> GetCurrentDeformedVertexPositionsAndTangents() { }

	internal NativeArray<Byte> GetCurrentDeformedVertices() { }

	public IEnumerable<Vector3> GetDeformedVertexPositionData() { }

	public IEnumerable<Vector4> GetDeformedVertexTangentData() { }

	internal NativeByteArray GetDeformedVertices(int spriteVertexCount) { }

	private static int GetNewVertexDeformationHash() { }

	public bool HasCurrentDeformedVertices() { }

	private static bool IsInGUIUpdateLoop() { }

	internal bool NeedToUpdateDeformationCache() { }

	public override void OnAfterDeserialize() { }

	private void OnAfterSerializeBatch() { }

	public override void OnBeforeSerialize() { }

	private void OnBeforeSerializeBatch() { }

	private void OnBoneTransformChanged() { }

	private void OnDisable() { }

	internal void OnEditorEnable() { }

	private void OnEnable() { }

	public override void OnPreviewUpdate() { }

	private void OnSpriteChanged(SpriteRenderer updatedSpriteRenderer) { }

	internal void PostDeform(bool didDeform) { }

	private void RefreshBoneTransforms() { }

	private void Reset() { }

	public bool ResetBindPose() { }

	private void ResetBoneTransformIdCache() { }

	internal void ResetSprite() { }

	public void set_alwaysUpdate(bool value) { }

	public void set_autoRebind(bool value) { }

	internal void set_bounds(Bounds value) { }

	[CompilerGenerated]
	private void set_currentDeformationMethod(DeformationMethods value) { }

	[CompilerGenerated]
	private void set_deformationSystem(BaseDeformationSystem value) { }

	public void set_forceCpuDeformation(bool value) { }

	public SpriteSkinState SetBoneTransforms(Transform[] boneTransformsArray) { }

	internal void SetDataIndex(int index) { }

	internal void SetDeformationSystem(BaseDeformationSystem newDeformationSystem) { }

	public SpriteSkinState SetRootBone(Transform rootBoneTransform) { }

	private void UpdateDeformedOutlineCache() { }

	private void UpdateSpriteDeformationData() { }

}

