namespace UnityEngine.AddressableAssets;

public class ResourceLocatorInfo
{
	[CompilerGenerated]
	private IResourceLocator <Locator>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private string <LocalHash>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private IResourceLocation <CatalogLocation>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private bool <ContentUpdateAvailable>k__BackingField; //Field offset: 0x28

	public bool CanUpdateContent
	{
		 get { } //Length: 169
	}

	public private IResourceLocation CatalogLocation
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	internal bool ContentUpdateAvailable
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	public IResourceLocation HashLocation
	{
		 get { } //Length: 110
	}

	public private string LocalHash
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private IResourceLocator Locator
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public ResourceLocatorInfo(IResourceLocator loc, string localHash, IResourceLocation remoteCatalogLocation) { }

	public bool get_CanUpdateContent() { }

	[CompilerGenerated]
	public IResourceLocation get_CatalogLocation() { }

	[CompilerGenerated]
	internal bool get_ContentUpdateAvailable() { }

	public IResourceLocation get_HashLocation() { }

	[CompilerGenerated]
	public string get_LocalHash() { }

	[CompilerGenerated]
	public IResourceLocator get_Locator() { }

	[CompilerGenerated]
	private void set_CatalogLocation(IResourceLocation value) { }

	[CompilerGenerated]
	internal void set_ContentUpdateAvailable(bool value) { }

	[CompilerGenerated]
	private void set_LocalHash(string value) { }

	[CompilerGenerated]
	private void set_Locator(IResourceLocator value) { }

	internal void UpdateContent(IResourceLocator locator, string hash, IResourceLocation loc) { }

}

