namespace UnityEngine.U2D.Animation;

internal class SpriteLibrarySourceAsset : ScriptableObject
{
	public const string defaultName = "New Sprite Library Asset"; //Field offset: 0x0
	public const string extension = ".spriteLib"; //Field offset: 0x0
	[SerializeField]
	private List<SpriteLibCategoryOverride> m_Library; //Field offset: 0x18
	[SerializeField]
	private string m_PrimaryLibraryGUID; //Field offset: 0x20
	[SerializeField]
	private long m_ModificationHash; //Field offset: 0x28
	[SerializeField]
	private int m_Version; //Field offset: 0x30

	public IReadOnlyList<SpriteLibCategoryOverride> library
	{
		 get { } //Length: 5
	}

	public long modificationHash
	{
		 get { } //Length: 5
	}

	public string primaryLibraryGUID
	{
		 get { } //Length: 5
	}

	public int version
	{
		 get { } //Length: 4
	}

	public SpriteLibrarySourceAsset() { }

	public void AddCategory(SpriteLibCategoryOverride newCategory) { }

	public void ClearCategories() { }

	public IReadOnlyList<SpriteLibCategoryOverride> get_library() { }

	public long get_modificationHash() { }

	public string get_primaryLibraryGUID() { }

	public int get_version() { }

	public void InitializeWithAsset(SpriteLibrarySourceAsset source) { }

	public void RemoveCategory(SpriteLibCategoryOverride categoryToRemove) { }

	public void RemoveCategory(int indexToRemove) { }

	public void SetLibrary(IList<SpriteLibCategoryOverride> newLibrary) { }

	public void SetPrimaryLibraryGUID(string newPrimaryLibraryGUID) { }

	private void UpdateModificationHash() { }

}

