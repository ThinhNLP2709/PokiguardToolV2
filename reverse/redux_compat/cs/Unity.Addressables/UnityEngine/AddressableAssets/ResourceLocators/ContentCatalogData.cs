/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.ResourceManagement.Util;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets.ResourceLocators
{
	[Serializable]
	public class ContentCatalogData // TypeDefIndex: 14094
	{
		// Fields
		private const int kMagic = 233015618; // Metadata: 0x006A9552
		private const int kVersion = 2; // Metadata: 0x006A9556
		[NonSerialized]
		public string LocalHash; // 0x10
		[NonSerialized]
		internal IResourceLocation location; // 0x18
		[SerializeField]
		internal string m_LocatorId; // 0x20
		[SerializeField]
		internal string m_BuildResultHash; // 0x28
		[SerializeField]
		private ObjectInitializationData m_InstanceProviderData; // 0x30
		[SerializeField]
		private ObjectInitializationData m_SceneProviderData; // 0x60
		[SerializeField]
		internal List<ObjectInitializationData> m_ResourceProviderData; // 0x90
		private IList<ContentCatalogDataEntry> m_Entries; // 0x98
		private BinaryStorageBuffer.Reader m_Reader; // 0xA0
	
		// Properties
		public string BuildResultHash { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public string ProviderId { get; internal set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public ObjectInitializationData InstanceProviderData { get; set; } // 0x0000000181C77EB0-0x0000000181C77ED0 0x0000000181C77EF0-0x0000000181C77F20
		public ObjectInitializationData SceneProviderData { get; set; } // 0x0000000181C77ED0-0x0000000181C77EF0 0x0000000181C77F20-0x0000000181C77F50
		public List<ObjectInitializationData> ResourceProviderData { get; set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000180664160-0x0000000180664180
	
		// Nested types
		internal class Serializer : BinaryStorageBuffer.ISerializationAdapter<ContentCatalogData> // TypeDefIndex: 14095
		{
			// Fields
			private bool resolveInternalIds; // 0x10
	
			// Properties
			public IEnumerable<BinaryStorageBuffer.ISerializationAdapter> Dependencies { get; } // 0x0000000181C82E00-0x0000000181C82FB0 
	
			// Nested types
			[CompilerGenerated]
			private sealed class __c__DisplayClass5_0 // TypeDefIndex: 14096
			{
				// Fields
				public uint[] locationIds; // 0x10
				public Func<int, uint> __9__0; // 0x18
	
				// Constructors
				public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal uint _Serialize_b__0(int i); // 0x0000000181C83CA0-0x0000000181C83CD0
			}
	
			// Constructors
			public Serializer(); // 0x0000000181C82DF0-0x0000000181C82E00
	
			// Methods
			public Serializer WithInternalIdResolvingDisabled(); // 0x0000000181C82DE0-0x0000000181C82DF0
			public object Deserialize(BinaryStorageBuffer.Reader reader, Type t, uint offset, out uint size); // 0x0000000181C81BB0-0x0000000181C81EF0
			public uint Serialize(BinaryStorageBuffer.Writer writer, object val); // 0x0000000181C824E0-0x0000000181C82DE0
		}
	
		internal class ResourceLocator : IResourceLocator // TypeDefIndex: 14097
		{
			// Fields
			private Dictionary<object, uint> keyData; // 0x10
			private BinaryStorageBuffer.Reader reader; // 0x18
			[CompilerGenerated]
			private string _LocatorId_k__BackingField; // 0x20
			private string providerSuffix; // 0x28
			private LocateProcContext sharedContext; // 0x30
	
			// Properties
			public string LocatorId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
			public IEnumerable<object> Keys { get; } // 0x0000000181C80F20-0x0000000181C80F70 
			public IEnumerable<IResourceLocation> AllLocations { get; } // 0x0000000181C80C10-0x0000000181C80F20 
	
			// Nested types
			public struct Header // TypeDefIndex: 14098
			{
				// Fields
				public int magic; // 0x00
				public int version; // 0x04
				public uint keysOffset; // 0x08
				public uint idOffset; // 0x0C
				public uint instanceProvider; // 0x10
				public uint sceneProvider; // 0x14
				public uint initObjectsArray; // 0x18
				public uint buildResultHash; // 0x1C
			}
	
			public struct KeyData // TypeDefIndex: 14099
			{
				// Fields
				public uint keyNameOffset; // 0x00
				public uint locationSetOffset; // 0x04
			}
	
			internal class ContentCatalogDataEntrySerializationContext // TypeDefIndex: 14100
			{
				// Fields
				public ContentCatalogDataEntry entry; // 0x10
				public Dictionary<object, List<int>> keyToEntryIndices; // 0x18
				public IList<ContentCatalogDataEntry> allEntries; // 0x20
	
				// Constructors
				public ContentCatalogDataEntrySerializationContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
			}
	
			internal class ResourceLocation : IResourceLocation // TypeDefIndex: 14101
			{
				// Fields
				private BinaryStorageBuffer.Reader reader; // 0x10
				[CompilerGenerated]
				private string _InternalId_k__BackingField; // 0x18
				[CompilerGenerated]
				private string _ProviderId_k__BackingField; // 0x20
				private List<IResourceLocation> _deps; // 0x28
				private uint dependencyDataOffset; // 0x30
				[CompilerGenerated]
				private object _Data_k__BackingField; // 0x38
				[CompilerGenerated]
				private string _PrimaryKey_k__BackingField; // 0x40
				[CompilerGenerated]
				private Type _ResourceType_k__BackingField; // 0x48
	
				// Properties
				public string InternalId { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
				public string ProviderId { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
				public IList<IResourceLocation> Dependencies { get; } // 0x0000000181C80220-0x0000000181C80340 
				public int DependencyHashCode { get; } // 0x0000000181C80340-0x0000000181C80350 
				public bool HasDependencies { get; } // 0x0000000181C80350-0x0000000181C80360 
				public object Data { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
				public string PrimaryKey { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
				public Type ResourceType { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
	
				// Nested types
				private class ResolvedInternalId // TypeDefIndex: 14102
				{
					// Fields
					public string InternalId; // 0x10
	
					// Constructors
					public ResolvedInternalId(); // 0x00000001802E5CB0-0x00000001802E5CC0
				}
	
				public class ResolvedInternalIdSerializer : BinaryStorageBuffer.ISerializationAdapter<ResolvedInternalId> // TypeDefIndex: 14103
				{
					// Properties
					IEnumerable<BinaryStorageBuffer.ISerializationAdapter> ISerializationAdapter.Dependencies { get; } // 0x00000001802E7860-0x00000001802E7870 
	
					// Constructors
					public ResolvedInternalIdSerializer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
					// Methods
					object UnityEngine.ResourceManagement.Util.BinaryStorageBuffer.ISerializationAdapter.Deserialize(BinaryStorageBuffer.Reader reader, Type t, uint offset, out uint size); // 0x0000000181C7E7D0-0x0000000181C7E8A0
					uint UnityEngine.ResourceManagement.Util.BinaryStorageBuffer.ISerializationAdapter.Serialize(BinaryStorageBuffer.Writer writer, object val); // 0x0000000181C7E8A0-0x0000000181C7E8E0
				}
	
				public class Serializer : BinaryStorageBuffer.ISerializationAdapter<ResourceLocation>, BinaryStorageBuffer.ISerializationAdapter<ContentCatalogDataEntrySerializationContext> // TypeDefIndex: 14104
				{
					// Fields
					private bool resolveInternalIds; // 0x10
	
					// Properties
					public IEnumerable<BinaryStorageBuffer.ISerializationAdapter> Dependencies { get; } // 0x0000000181C82FB0-0x0000000181C830E0 
	
					// Nested types
					public struct Data // TypeDefIndex: 14105
					{
						// Fields
						public uint primaryKeyOffset; // 0x00
						public uint internalIdOffset; // 0x04
						public uint providerOffset; // 0x08
						public uint dependencySetOffset; // 0x0C
						public int dependencyHashValue; // 0x10
						public uint extraDataOffset; // 0x14
						public uint typeId; // 0x18
					}
	
					// Constructors
					public Serializer(bool resolveInternalIds); // 0x0000000180385630-0x0000000180385660
	
					// Methods
					public object Deserialize(BinaryStorageBuffer.Reader reader, Type t, uint offset, out uint size); // 0x0000000181C81EF0-0x0000000181C81F80
					public uint Serialize(BinaryStorageBuffer.Writer writer, object val); // 0x0000000181C81F80-0x0000000181C824E0
				}
	
				// Constructors
				public ResourceLocation(BinaryStorageBuffer.Reader r, uint id, out uint size, bool resolveInternalId); // 0x0000000181C7FFA0-0x0000000181C80220
	
				// Methods
				private static void ProcDependencies(ResourceLocation l, ResourceLocation d, int i, int count); // 0x0000000181C7FE80-0x0000000181C7FFA0
				public override string ToString(); // 0x00000001802F8EC0-0x00000001802F8ED0
				public int Hash(Type resultType); // 0x0000000181C7FE20-0x0000000181C7FE80
			}
	
			private class LocateProcContext // TypeDefIndex: 14106
			{
				// Fields
				public IList<IResourceLocation> locations; // 0x10
				public Type type; // 0x18
	
				// Constructors
				public LocateProcContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
			}
	
			// Constructors
			internal ResourceLocator(string id, BinaryStorageBuffer.Reader reader, string providerSuffix); // 0x0000000181C809F0-0x0000000181C80C10
	
			// Methods
			private static void ProcFunc(ResourceLocation loc, LocateProcContext context, int i, int count); // 0x0000000181C808A0-0x0000000181C809F0
			public bool Locate(object key, Type type, out IList<IResourceLocation> locations); // 0x0000000181C804E0-0x0000000181C808A0
		}
	
		internal class AssetBundleRequestOptionsSerializationAdapter : BinaryStorageBuffer.ISerializationAdapter<AssetBundleRequestOptions> // TypeDefIndex: 14107
		{
			// Properties
			public IEnumerable<BinaryStorageBuffer.ISerializationAdapter> Dependencies { get; } // 0x00000001802E7860-0x00000001802E7870 
	
			// Nested types
			private struct SerializedData // TypeDefIndex: 14108
			{
				// Fields
				public uint hashId; // 0x00
				public uint bundleNameId; // 0x04
				public uint crc; // 0x08
				public uint bundleSize; // 0x0C
				public uint commonId; // 0x10
	
				// Nested types
				public struct Common // TypeDefIndex: 14109
				{
					// Fields
					public short timeout; // 0x00
					public byte redirectLimit; // 0x02
					public byte retryCount; // 0x03
					public int flags; // 0x04
	
					// Properties
					public AssetLoadMode assetLoadMode { get; set; } // 0x0000000181C77840-0x0000000181C77850 0x0000000181C77890-0x0000000181C778A0
					public bool chunkedTransfer { get; set; } // 0x0000000181C77850-0x0000000181C77860 0x0000000181C778A0-0x0000000181C778C0
					public bool useCrcForCachedBundle { get; set; } // 0x0000000181C77870-0x0000000181C77880 0x0000000181C778E0-0x0000000181C77900
					public bool useUnityWebRequestForLocalBundles { get; set; } // 0x0000000181C77880-0x0000000181C77890 0x0000000181C77900-0x0000000181C77920
					public bool clearOtherCachedVersionsWhenLoaded { get; set; } // 0x0000000181C77860-0x0000000181C77870 0x0000000181C778C0-0x0000000181C778E0
				}
			}
	
			// Constructors
			public AssetBundleRequestOptionsSerializationAdapter(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public object Deserialize(BinaryStorageBuffer.Reader reader, Type type, uint offset, out uint size); // 0x0000000181C736F0-0x0000000181C73970
			public uint Serialize(BinaryStorageBuffer.Writer writer, object obj); // 0x0000000181C73970-0x0000000181C73BC0
		}
	
		// Constructors
		public ContentCatalogData(string id); // 0x0000000181C77CF0-0x0000000181C77D90
		public ContentCatalogData(); // 0x0000000181C77D90-0x0000000181C77E10
		internal ContentCatalogData(BinaryStorageBuffer.Reader reader); // 0x0000000181C77E10-0x0000000181C77EB0
	
		// Methods
		internal void CleanData(); // 0x0000000181C77A50-0x0000000181C77A90
		internal void CopyToFile(string path); // 0x0000000181C77A90-0x0000000181C77AC0
		internal byte[] GetBytes(); // 0x0000000181C77B60-0x0000000181C77B80
		internal IResourceLocator CreateCustomLocator(string overrideId = "" /* Metadata: 0x006A9551 */, string providerSuffix = null); // 0x0000000181C77AC0-0x0000000181C77B60
		internal static ContentCatalogData LoadFromFile(string path, bool resolveInternalIds); // 0x0000000181C77B80-0x0000000181C77CF0
	}
}
