namespace UnityEngine.U2D.Animation;

internal class DeformationManager : ScriptableObject
{
	private static DeformationManager s_Instance; //Field offset: 0x0
	private BaseDeformationSystem[] m_DeformationSystems; //Field offset: 0x18
	[SerializeField]
	private GameObject m_Helper; //Field offset: 0x20
	[CompilerGenerated]
	private bool <canUseGpuDeformation>k__BackingField; //Field offset: 0x28
	private bool m_WasUsingGpuDeformationLastFrame; //Field offset: 0x29

	private bool canUseGpuDeformation
	{
		[CompilerGenerated]
		private get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	internal GameObject helperGameObject
	{
		internal get { } //Length: 5
	}

	public static DeformationManager instance
	{
		 get { } //Length: 335
	}

	public DeformationManager() { }

	internal void AddSpriteSkin(SpriteSkin spriteSkin) { }

	internal void AddSpriteSkinBoneTransform(SpriteSkin spriteSkin) { }

	private void CreateBatchSystems() { }

	private void CreateHelper() { }

	[CompilerGenerated]
	private bool get_canUseGpuDeformation() { }

	internal GameObject get_helperGameObject() { }

	public static DeformationManager get_instance() { }

	private bool HasToggledGpuDeformation() { }

	private void Init() { }

	private void MoveSpriteSkinsToActiveSystem() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnHelperDestroyed(GameObject helperGo) { }

	internal void RemoveBoneTransforms(SpriteSkin spriteSkin) { }

	[CompilerGenerated]
	private void set_canUseGpuDeformation(bool value) { }

	internal void Update() { }

}

