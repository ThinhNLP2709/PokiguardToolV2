namespace UnityEngine.U2D.Animation;

[MovedFrom("UnityEngine.Experimental.U2D.Animation")]
internal class SpriteLibCategory : INameHash, ISpriteLibraryCategory
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public bool log; //Field offset: 0x10

		public <>c__DisplayClass14_0() { }

		internal void <ValidateLabels>b__0(string originalName, string newName) { }

	}

	[SerializeField]
	private string m_Name; //Field offset: 0x10
	[SerializeField]
	private int m_Hash; //Field offset: 0x18
	[SerializeField]
	private List<SpriteCategoryEntry> m_CategoryList; //Field offset: 0x20

	public List<SpriteCategoryEntry> categoryList
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public override int hash
	{
		 get { } //Length: 4
	}

	public override IEnumerable<ISpriteLibraryLabel> labels
	{
		 get { } //Length: 5
	}

	public override string name
	{
		 get { } //Length: 5
		 set { } //Length: 143
	}

	public SpriteLibCategory() { }

	public List<SpriteCategoryEntry> get_categoryList() { }

	public override int get_hash() { }

	public override IEnumerable<ISpriteLibraryLabel> get_labels() { }

	public override string get_name() { }

	public void set_categoryList(List<SpriteCategoryEntry> value) { }

	public override void set_name(string value) { }

	public void UpdateHash() { }

	internal void ValidateLabels(bool log = true) { }

}

