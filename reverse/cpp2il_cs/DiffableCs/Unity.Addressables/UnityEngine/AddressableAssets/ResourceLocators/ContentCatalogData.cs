namespace UnityEngine.AddressableAssets.ResourceLocators;

public class ContentCatalogData
{
	public class AssetBundleRequestOptionsSerializationAdapter : ISerializationAdapter<AssetBundleRequestOptions>, ISerializationAdapter
	{
		private struct SerializedData
		{
			internal struct Common
			{
				public short timeout; //Field offset: 0x0
				public byte redirectLimit; //Field offset: 0x2
				public byte retryCount; //Field offset: 0x3
				public int flags; //Field offset: 0x4

				public AssetLoadMode assetLoadMode
				{
					 get { } //Length: 7
					 set { } //Length: 12
				}

				public bool chunkedTransfer
				{
					 get { } //Length: 8
					 set { } //Length: 23
				}

				public bool clearOtherCachedVersionsWhenLoaded
				{
					 get { } //Length: 9
					 set { } //Length: 24
				}

				public bool useCrcForCachedBundle
				{
					 get { } //Length: 9
					 set { } //Length: 24
				}

				public bool useUnityWebRequestForLocalBundles
				{
					 get { } //Length: 9
					 set { } //Length: 24
				}

				public AssetLoadMode get_assetLoadMode() { }

				public bool get_chunkedTransfer() { }

				public bool get_clearOtherCachedVersionsWhenLoaded() { }

				public bool get_useCrcForCachedBundle() { }

				public bool get_useUnityWebRequestForLocalBundles() { }

				public void set_assetLoadMode(AssetLoadMode value) { }

				public void set_chunkedTransfer(bool value) { }

				public void set_clearOtherCachedVersionsWhenLoaded(bool value) { }

				public void set_useCrcForCachedBundle(bool value) { }

				public void set_useUnityWebRequestForLocalBundles(bool value) { }

			}

			public uint hashId; //Field offset: 0x0
			public uint bundleNameId; //Field offset: 0x4
			public uint crc; //Field offset: 0x8
			public uint bundleSize; //Field offset: 0xC
			public uint commonId; //Field offset: 0x10

		}


		public override IEnumerable<ISerializationAdapter> Dependencies
		{
			 get { } //Length: 3
		}

		public AssetBundleRequestOptionsSerializationAdapter() { }

		public override object Deserialize(Reader reader, Type type, uint offset, out uint size) { }

		public override IEnumerable<ISerializationAdapter> get_Dependencies() { }

		public override uint Serialize(Writer writer, object obj) { }

	}

	public class ResourceLocator : IResourceLocator
	{
		public class ContentCatalogDataEntrySerializationContext
		{
			public ContentCatalogDataEntry entry; //Field offset: 0x10
			public Dictionary<Object, List`1<Int32>> keyToEntryIndices; //Field offset: 0x18
			public IList<ContentCatalogDataEntry> allEntries; //Field offset: 0x20

			public ContentCatalogDataEntrySerializationContext() { }

		}

		internal struct Header
		{
			public int magic; //Field offset: 0x0
			public int version; //Field offset: 0x4
			public uint keysOffset; //Field offset: 0x8
			public uint idOffset; //Field offset: 0xC
			public uint instanceProvider; //Field offset: 0x10
			public uint sceneProvider; //Field offset: 0x14
			public uint initObjectsArray; //Field offset: 0x18
			public uint buildResultHash; //Field offset: 0x1C

		}

		internal struct KeyData
		{
			public uint keyNameOffset; //Field offset: 0x0
			public uint locationSetOffset; //Field offset: 0x4

		}

		private class LocateProcContext
		{
			public IList<IResourceLocation> locations; //Field offset: 0x10
			public Type type; //Field offset: 0x18

			public LocateProcContext() { }

		}

		public class ResourceLocation : IResourceLocation
		{
			private class ResolvedInternalId
			{
				public string InternalId; //Field offset: 0x10

				public ResolvedInternalId() { }

			}

			internal class ResolvedInternalIdSerializer : ISerializationAdapter<ResolvedInternalId>, ISerializationAdapter
			{

				private override IEnumerable<ISerializationAdapter> UnityEngine.ResourceManagement.Util.BinaryStorageBuffer.ISerializationAdapter.Dependencies
				{
					private get { } //Length: 3
				}

				public ResolvedInternalIdSerializer() { }

				private override object UnityEngine.ResourceManagement.Util.BinaryStorageBuffer.ISerializationAdapter.Deserialize(Reader reader, Type t, uint offset, out uint size) { }

				private override IEnumerable<ISerializationAdapter> UnityEngine.ResourceManagement.Util.BinaryStorageBuffer.ISerializationAdapter.get_Dependencies() { }

				private override uint UnityEngine.ResourceManagement.Util.BinaryStorageBuffer.ISerializationAdapter.Serialize(Writer writer, object val) { }

			}

			internal class Serializer : ISerializationAdapter<ResourceLocation>, ISerializationAdapter, ISerializationAdapter<ContentCatalogDataEntrySerializationContext>
			{
				internal struct Data
				{
					public uint primaryKeyOffset; //Field offset: 0x0
					public uint internalIdOffset; //Field offset: 0x4
					public uint providerOffset; //Field offset: 0x8
					public uint dependencySetOffset; //Field offset: 0xC
					public int dependencyHashValue; //Field offset: 0x10
					public uint extraDataOffset; //Field offset: 0x14
					public uint typeId; //Field offset: 0x18

				}

				private bool resolveInternalIds; //Field offset: 0x10

				public override IEnumerable<ISerializationAdapter> Dependencies
				{
					 get { } //Length: 188
				}

				public Serializer(bool resolveInternalIds) { }

				public override object Deserialize(Reader reader, Type t, uint offset, out uint size) { }

				public override IEnumerable<ISerializationAdapter> get_Dependencies() { }

				public override uint Serialize(Writer writer, object val) { }

			}

			private Reader reader; //Field offset: 0x10
			[CompilerGenerated]
			private string <InternalId>k__BackingField; //Field offset: 0x18
			[CompilerGenerated]
			private string <ProviderId>k__BackingField; //Field offset: 0x20
			private List<IResourceLocation> _deps; //Field offset: 0x28
			private uint dependencyDataOffset; //Field offset: 0x30
			[CompilerGenerated]
			private object <Data>k__BackingField; //Field offset: 0x38
			[CompilerGenerated]
			private string <PrimaryKey>k__BackingField; //Field offset: 0x40
			[CompilerGenerated]
			private Type <ResourceType>k__BackingField; //Field offset: 0x48

			public internal override object Data
			{
				[CompilerGenerated]
				 get { } //Length: 5
				[CompilerGenerated]
				internal set { } //Length: 13
			}

			public override IList<IResourceLocation> Dependencies
			{
				 get { } //Length: 282
			}

			public override int DependencyHashCode
			{
				 get { } //Length: 11
			}

			public override bool HasDependencies
			{
				 get { } //Length: 8
			}

			public internal override string InternalId
			{
				[CompilerGenerated]
				 get { } //Length: 5
				[CompilerGenerated]
				internal set { } //Length: 13
			}

			public internal override string PrimaryKey
			{
				[CompilerGenerated]
				 get { } //Length: 5
				[CompilerGenerated]
				internal set { } //Length: 13
			}

			public internal override string ProviderId
			{
				[CompilerGenerated]
				 get { } //Length: 5
				[CompilerGenerated]
				internal set { } //Length: 13
			}

			public internal override Type ResourceType
			{
				[CompilerGenerated]
				 get { } //Length: 5
				[CompilerGenerated]
				internal set { } //Length: 13
			}

			public ResourceLocation(Reader r, uint id, out uint size, bool resolveInternalId) { }

			[CompilerGenerated]
			public override object get_Data() { }

			public override IList<IResourceLocation> get_Dependencies() { }

			public override int get_DependencyHashCode() { }

			public override bool get_HasDependencies() { }

			[CompilerGenerated]
			public override string get_InternalId() { }

			[CompilerGenerated]
			public override string get_PrimaryKey() { }

			[CompilerGenerated]
			public override string get_ProviderId() { }

			[CompilerGenerated]
			public override Type get_ResourceType() { }

			public override int Hash(Type resultType) { }

			private static void ProcDependencies(ResourceLocation l, ResourceLocation d, int i, int count) { }

			[CompilerGenerated]
			internal void set_Data(object value) { }

			[CompilerGenerated]
			internal void set_InternalId(string value) { }

			[CompilerGenerated]
			internal void set_PrimaryKey(string value) { }

			[CompilerGenerated]
			internal void set_ProviderId(string value) { }

			[CompilerGenerated]
			internal void set_ResourceType(Type value) { }

			public virtual string ToString() { }

		}

		private Dictionary<Object, UInt32> keyData; //Field offset: 0x10
		private Reader reader; //Field offset: 0x18
		[CompilerGenerated]
		private string <LocatorId>k__BackingField; //Field offset: 0x20
		private string providerSuffix; //Field offset: 0x28
		private LocateProcContext sharedContext; //Field offset: 0x30

		public override IEnumerable<IResourceLocation> AllLocations
		{
			 get { } //Length: 783
		}

		public override IEnumerable<Object> Keys
		{
			 get { } //Length: 68
		}

		public private override string LocatorId
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			private set { } //Length: 13
		}

		internal ResourceLocator(string id, Reader reader, string providerSuffix) { }

		public override IEnumerable<IResourceLocation> get_AllLocations() { }

		public override IEnumerable<Object> get_Keys() { }

		[CompilerGenerated]
		public override string get_LocatorId() { }

		public override bool Locate(object key, Type type, out IList<IResourceLocation>& locations) { }

		private static void ProcFunc(ResourceLocation loc, LocateProcContext context, int i, int count) { }

		[CompilerGenerated]
		private void set_LocatorId(string value) { }

	}

	public class Serializer : ISerializationAdapter<ContentCatalogData>, ISerializationAdapter
	{
		[CompilerGenerated]
		private sealed class <>c__DisplayClass5_0
		{
			public UInt32[] locationIds; //Field offset: 0x10
			public Func<Int32, UInt32> <>9__0; //Field offset: 0x18

			public <>c__DisplayClass5_0() { }

			internal uint <Serialize>b__0(int i) { }

		}

		private bool resolveInternalIds; //Field offset: 0x10

		public override IEnumerable<ISerializationAdapter> Dependencies
		{
			 get { } //Length: 423
		}

		public Serializer() { }

		public override object Deserialize(Reader reader, Type t, uint offset, out uint size) { }

		public override IEnumerable<ISerializationAdapter> get_Dependencies() { }

		public override uint Serialize(Writer writer, object val) { }

		public Serializer WithInternalIdResolvingDisabled() { }

	}

	private static int kMagic; //Field offset: 0x0
	private const int kVersion = 2; //Field offset: 0x0
	public string LocalHash; //Field offset: 0x10
	internal IResourceLocation location; //Field offset: 0x18
	[SerializeField]
	internal string m_LocatorId; //Field offset: 0x20
	[SerializeField]
	internal string m_BuildResultHash; //Field offset: 0x28
	[SerializeField]
	private ObjectInitializationData m_InstanceProviderData; //Field offset: 0x30
	[SerializeField]
	private ObjectInitializationData m_SceneProviderData; //Field offset: 0x60
	[SerializeField]
	internal List<ObjectInitializationData> m_ResourceProviderData; //Field offset: 0x90
	private IList<ContentCatalogDataEntry> m_Entries; //Field offset: 0x98
	private Reader m_Reader; //Field offset: 0xA0

	public string BuildResultHash
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public ObjectInitializationData InstanceProviderData
	{
		 get { } //Length: 27
		 set { } //Length: 34
	}

	public internal string ProviderId
	{
		 get { } //Length: 5
		internal set { } //Length: 13
	}

	public List<ObjectInitializationData> ResourceProviderData
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	public ObjectInitializationData SceneProviderData
	{
		 get { } //Length: 30
		 set { } //Length: 37
	}

	private static ContentCatalogData() { }

	internal ContentCatalogData(Reader reader) { }

	public ContentCatalogData() { }

	public ContentCatalogData(string id) { }

	internal void CleanData() { }

	internal void CopyToFile(string path) { }

	internal IResourceLocator CreateCustomLocator(string overrideId = "", string providerSuffix = null) { }

	public string get_BuildResultHash() { }

	public ObjectInitializationData get_InstanceProviderData() { }

	public string get_ProviderId() { }

	public List<ObjectInitializationData> get_ResourceProviderData() { }

	public ObjectInitializationData get_SceneProviderData() { }

	internal Byte[] GetBytes() { }

	internal static ContentCatalogData LoadFromFile(string path, bool resolveInternalIds) { }

	public void set_BuildResultHash(string value) { }

	public void set_InstanceProviderData(ObjectInitializationData value) { }

	internal void set_ProviderId(string value) { }

	public void set_ResourceProviderData(List<ObjectInitializationData> value) { }

	public void set_SceneProviderData(ObjectInitializationData value) { }

}

