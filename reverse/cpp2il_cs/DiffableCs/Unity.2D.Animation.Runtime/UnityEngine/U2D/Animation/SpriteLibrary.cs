namespace UnityEngine.U2D.Animation;

[AddComponentMenu("2D Animation/Sprite Library")]
[DisallowMultipleComponent]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.2d.animation@latest/index.html?subfolder=/manual/SL-component.html")]
[MovedFrom("UnityEngine.Experimental.U2D.Animation")]
public class SpriteLibrary : MonoBehaviour, IPreviewable, IAnimationPreviewable
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public string category; //Field offset: 0x10

		public <>c__DisplayClass18_0() { }

		internal bool <GetEntries>b__0(SpriteLibCategory x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public string entry; //Field offset: 0x10

		public <>c__DisplayClass19_0() { }

		internal bool <GetEntry>b__0(SpriteCategoryEntry x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public int categoryHash; //Field offset: 0x10

		public <>c__DisplayClass21_0() { }

		internal bool <AddOverride>b__0(SpriteLibCategory x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public string category; //Field offset: 0x10

		public <>c__DisplayClass23_0() { }

		internal bool <RemoveOverride>b__0(SpriteLibCategory x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public string label; //Field offset: 0x10

		public <>c__DisplayClass24_0() { }

		internal bool <RemoveOverride>b__0(SpriteCategoryEntry x) { }

	}

	private struct CategoryEntrySprite
	{
		public string category; //Field offset: 0x0
		public string entry; //Field offset: 0x8
		public Sprite sprite; //Field offset: 0x10

	}

	[SerializeField]
	private List<SpriteLibCategory> m_Library; //Field offset: 0x20
	[SerializeField]
	private SpriteLibraryAsset m_SpriteLibraryAsset; //Field offset: 0x28
	private Dictionary<Int32, CategoryEntrySprite> m_CategoryEntryHashCache; //Field offset: 0x30
	private Dictionary<String, HashSet`1<String>> m_CategoryEntryCache; //Field offset: 0x38
	private int m_PreviousSpriteLibraryAsset; //Field offset: 0x40
	private long m_PreviousModificationHash; //Field offset: 0x48

	internal IEnumerable<String> categoryNames
	{
		internal get { } //Length: 78
	}

	public SpriteLibraryAsset spriteLibraryAsset
	{
		 get { } //Length: 5
		 set { } //Length: 144
	}

	public SpriteLibrary() { }

	public void AddOverride(Sprite sprite, string category, string label) { }

	public void AddOverride(SpriteLibraryAsset spriteLib, string category) { }

	public void AddOverride(SpriteLibraryAsset spriteLib, string category, string label) { }

	internal void CacheOverrides() { }

	internal IEnumerable<String> get_categoryNames() { }

	public SpriteLibraryAsset get_spriteLibraryAsset() { }

	internal bool GetCategoryAndEntryNameFromHash(int hash, out string category, out string entry) { }

	private List<SpriteCategoryEntry> GetEntries(string category, bool addIfNotExist) { }

	private static SpriteCategoryEntry GetEntry(List<SpriteCategoryEntry> entries, string entry, bool addIfNotExist) { }

	internal IEnumerable<String> GetEntryNames(string category) { }

	internal static int GetHashForCategoryAndEntry(string category, string entry) { }

	private Sprite GetSprite(int hash) { }

	public Sprite GetSprite(string category, string label) { }

	internal Sprite GetSpriteFromCategoryAndEntryHash(int hash, out bool validEntry) { }

	public bool HasOverride(string category, string label) { }

	private void OnEnable() { }

	public override void OnPreviewUpdate() { }

	public void RefreshSpriteResolvers() { }

	public void RemoveOverride(string category) { }

	public void RemoveOverride(string category, string label) { }

	public void set_spriteLibraryAsset(SpriteLibraryAsset value) { }

	private void UpdateCacheOverridesIfNeeded() { }

}

