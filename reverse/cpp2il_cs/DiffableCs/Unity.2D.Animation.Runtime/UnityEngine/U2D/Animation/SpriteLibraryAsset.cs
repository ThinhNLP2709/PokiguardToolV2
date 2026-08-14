namespace UnityEngine.U2D.Animation;

[HelpURL("https://docs.unity3d.com/Packages/com.unity.2d.animation@latest/index.html?subfolder=/manual/AssetUpgrader.html%23upgrading-sprite-libraries")]
[MovedFrom("UnityEngine.Experimental.U2D.Animation")]
public class SpriteLibraryAsset : ScriptableObject
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<SpriteLibCategory, String> <>9__17_0; //Field offset: 0x8
		public static Func<SpriteCategoryEntry, String> <>9__19_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal string <GetCategoryLabelNames>b__19_1(SpriteCategoryEntry x) { }

		internal string <GetCategoryNames>b__17_0(SpriteLibCategory x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public int categoryHash; //Field offset: 0x10
		public int labelHash; //Field offset: 0x14

		public <>c__DisplayClass14_0() { }

		internal bool <GetSprite>b__0(SpriteLibCategory x) { }

		internal bool <GetSprite>b__1(SpriteCategoryEntry x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public string category; //Field offset: 0x10

		public <>c__DisplayClass19_0() { }

		internal bool <GetCategoryLabelNames>b__0(SpriteLibCategory x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_0
	{
		public int catHash; //Field offset: 0x10

		public <>c__DisplayClass20_0() { }

		internal bool <AddCategoryLabel>b__0(SpriteLibCategory x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_1
	{
		public int labelHash; //Field offset: 0x10

		public <>c__DisplayClass20_1() { }

		internal bool <AddCategoryLabel>b__1(SpriteCategoryEntry y) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public int catHash; //Field offset: 0x10
		public SpriteLibCategory libCategory; //Field offset: 0x18

		public <>c__DisplayClass21_0() { }

		internal bool <RemoveCategoryLabel>b__0(SpriteLibCategory x) { }

		internal bool <RemoveCategoryLabel>b__2(SpriteLibCategory x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_1
	{
		public int labelHash; //Field offset: 0x10

		public <>c__DisplayClass21_1() { }

		internal bool <RemoveCategoryLabel>b__1(SpriteCategoryEntry x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public bool log; //Field offset: 0x10

		public <>c__DisplayClass23_0() { }

		internal void <ValidateCategories>b__0(string originalName, string newName) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public INameHash category; //Field offset: 0x10

		public <>c__DisplayClass24_0() { }

		internal bool <RenameDuplicate>b__0(INameHash x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_1
	{
		public INameHash categoryClash; //Field offset: 0x10

		public <>c__DisplayClass24_1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_2
	{
		public int nameHash; //Field offset: 0x10
		public string name; //Field offset: 0x18
		public <>c__DisplayClass24_1 CS$<>8__locals1; //Field offset: 0x20

		public <>c__DisplayClass24_2() { }

		internal bool <RenameDuplicate>b__1(INameHash x) { }

	}

	[SerializeField]
	private List<SpriteLibCategory> m_Labels; //Field offset: 0x18
	[SerializeField]
	private long m_ModificationHash; //Field offset: 0x20
	[SerializeField]
	private int m_Version; //Field offset: 0x28

	internal List<SpriteLibCategory> categories
	{
		internal get { } //Length: 5
		internal set { } //Length: 40
	}

	internal long modificationHash
	{
		internal get { } //Length: 5
		internal set { } //Length: 5
	}

	internal int version
	{
		internal set { } //Length: 4
	}

	public SpriteLibraryAsset() { }

	public void AddCategoryLabel(Sprite sprite, string category, string label) { }

	internal static SpriteLibraryAsset CreateAsset(List<SpriteLibCategory> categories, string assetName, long modificationHash) { }

	internal List<SpriteLibCategory> get_categories() { }

	internal long get_modificationHash() { }

	[Obsolete("GetCategorylabelNames has been deprecated. Please use GetCategoryLabelNames (UnityUpgradable) -> GetCategoryLabelNames(*)")]
	public IEnumerable<String> GetCategorylabelNames(string category) { }

	public IEnumerable<String> GetCategoryLabelNames(string category) { }

	public IEnumerable<String> GetCategoryNames() { }

	internal Sprite GetSprite(int categoryHash, int labelHash) { }

	public Sprite GetSprite(string category, string label) { }

	internal Sprite GetSprite(int categoryHash, int labelHash, out bool validEntry) { }

	private void OnEnable() { }

	public void RemoveCategoryLabel(string category, string label, bool deleteCategory) { }

	internal static void RenameDuplicate(IEnumerable<INameHash> nameHashList, Action<String, String> onRename) { }

	internal void set_categories(List<SpriteLibCategory> value) { }

	internal void set_modificationHash(long value) { }

	internal void set_version(int value) { }

	internal void UpdateHashes() { }

	private void UpdateToVersionOne() { }

	internal void ValidateCategories(bool log = true) { }

}

