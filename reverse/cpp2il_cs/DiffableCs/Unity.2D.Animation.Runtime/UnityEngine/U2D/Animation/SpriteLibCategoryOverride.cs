namespace UnityEngine.U2D.Animation;

internal class SpriteLibCategoryOverride : SpriteLibCategory
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String, String> <>9__13_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <RenameDuplicateOverrideEntries>b__13_0(string _, string _) { }

	}

	[SerializeField]
	private List<SpriteCategoryEntryOverride> m_OverrideEntries; //Field offset: 0x28
	[SerializeField]
	private bool m_FromMain; //Field offset: 0x30
	[SerializeField]
	private int m_EntryOverrideCount; //Field offset: 0x34

	public int entryOverrideCount
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public bool fromMain
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public List<SpriteCategoryEntryOverride> overrideEntries
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public SpriteLibCategoryOverride() { }

	public int get_entryOverrideCount() { }

	public bool get_fromMain() { }

	public List<SpriteCategoryEntryOverride> get_overrideEntries() { }

	public void RenameDuplicateOverrideEntries() { }

	public void set_entryOverrideCount(int value) { }

	public void set_fromMain(bool value) { }

	public void set_overrideEntries(List<SpriteCategoryEntryOverride> value) { }

	public void UpdateOverrideCount() { }

}

