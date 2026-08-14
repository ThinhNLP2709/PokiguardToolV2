namespace UnityEngine.AddressableAssets.ResourceLocators;

public class ResourceLocationMap : IResourceLocator
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<KeyValuePair`2<Object, IList`1<IResourceLocation>>, IEnumerable`1<IResourceLocation>> <>9__8_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal IEnumerable<IResourceLocation> <get_AllLocations>b__8_0(KeyValuePair<Object, IList`1<IResourceLocation>> k) { }

	}

	[CompilerGenerated]
	private string <LocatorId>k__BackingField; //Field offset: 0x10
	private Dictionary<Object, IList`1<IResourceLocation>> locations; //Field offset: 0x18

	public override IEnumerable<IResourceLocation> AllLocations
	{
		 get { } //Length: 273
	}

	public override IEnumerable<Object> Keys
	{
		 get { } //Length: 68
	}

	public Dictionary<Object, IList`1<IResourceLocation>> Locations
	{
		 get { } //Length: 5
	}

	public private override string LocatorId
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public ResourceLocationMap(string id, int capacity = 0) { }

	public ResourceLocationMap(string id, IList<ResourceLocationData> locations) { }

	public void Add(object key, IResourceLocation location) { }

	public void Add(object key, IList<IResourceLocation> locations) { }

	public override IEnumerable<IResourceLocation> get_AllLocations() { }

	public override IEnumerable<Object> get_Keys() { }

	public Dictionary<Object, IList`1<IResourceLocation>> get_Locations() { }

	[CompilerGenerated]
	public override string get_LocatorId() { }

	public override bool Locate(object key, Type type, out IList<IResourceLocation>& locations) { }

	[CompilerGenerated]
	private void set_LocatorId(string value) { }

}

