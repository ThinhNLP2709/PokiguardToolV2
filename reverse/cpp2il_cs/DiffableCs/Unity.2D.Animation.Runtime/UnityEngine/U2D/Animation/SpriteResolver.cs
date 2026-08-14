namespace UnityEngine.U2D.Animation;

[AddComponentMenu("2D Animation/Sprite Resolver")]
[DefaultExecutionOrder(-20)]
[DisallowMultipleComponent]
[ExecuteInEditMode]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.2d.animation@latest/index.html?subfolder=/manual/SL-Resolver.html")]
[MovedFrom("UnityEngine.Experimental.U2D.Animation")]
public class SpriteResolver : MonoBehaviour, IPreviewable, IAnimationPreviewable
{
	[SerializeField]
	private float m_CategoryHash; //Field offset: 0x20
	[SerializeField]
	private float m_labelHash; //Field offset: 0x24
	[SerializeField]
	private float m_SpriteKey; //Field offset: 0x28
	[DiscreteEvaluation]
	[SerializeField]
	private int m_SpriteHash; //Field offset: 0x2C
	private int m_CategoryHashInt; //Field offset: 0x30
	private int m_LabelHashInt; //Field offset: 0x34
	private int m_PreviousCategoryHash; //Field offset: 0x38
	private int m_PreviousLabelHash; //Field offset: 0x3C
	private int m_PreviousSpriteKeyInt; //Field offset: 0x40
	private int m_PreviousSpriteHash; //Field offset: 0x44

	public SpriteLibrary spriteLibrary
	{
		 get { } //Length: 79
	}

	private SpriteRenderer spriteRenderer
	{
		private get { } //Length: 57
	}

	public SpriteResolver() { }

	internal static int ConvertCategoryLabelHashToSpriteKey(SpriteLibrary library, int categoryHash, int labelHash) { }

	public SpriteLibrary get_spriteLibrary() { }

	private SpriteRenderer get_spriteRenderer() { }

	public string GetCategory() { }

	public string GetLabel() { }

	internal Sprite GetSprite(out bool validEntry) { }

	private void InitializeSerializedData() { }

	private static bool IsInGUIUpdateLoop() { }

	internal void LateUpdate() { }

	private void OnEnable() { }

	public override void OnPreviewUpdate() { }

	private void OnTransformParentChanged() { }

	private void Reset() { }

	public bool ResolveSpriteToSpriteRenderer() { }

	private void ResolveUpdatedValue() { }

	public bool SetCategoryAndLabel(string category, string label) { }

	private void SetSprite(Sprite sprite) { }

}

