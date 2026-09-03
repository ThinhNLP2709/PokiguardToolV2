/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.Serialization;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	[Serializable]
	[DataContract]
	public class AssetBundleRequestOptions : ILocationSizeData // TypeDefIndex: 13732
	{
		// Fields
		[DataMember(Name = "Hash")]
		[FormerlySerializedAs("m_hash")]
		[SerializeField]
		private string m_Hash; // 0x10
		[DataMember(Name = "Crc")]
		[FormerlySerializedAs("m_crc")]
		[SerializeField]
		private uint m_Crc; // 0x18
		[DataMember(Name = "Timeout")]
		[FormerlySerializedAs("m_timeout")]
		[SerializeField]
		private int m_Timeout; // 0x1C
		[DataMember(Name = "ChunkedTransfer")]
		[FormerlySerializedAs("m_chunkedTransfer")]
		[SerializeField]
		private bool m_ChunkedTransfer; // 0x20
		[DataMember(Name = "RedirectLimit")]
		[FormerlySerializedAs("m_redirectLimit")]
		[SerializeField]
		private int m_RedirectLimit; // 0x24
		[DataMember(Name = "RetryCount")]
		[FormerlySerializedAs("m_retryCount")]
		[SerializeField]
		private int m_RetryCount; // 0x28
		[DataMember(Name = "BundleName")]
		[SerializeField]
		private string m_BundleName; // 0x30
		[DataMember(Name = "AssetLoadMode")]
		[SerializeField]
		private AssetLoadMode m_AssetLoadMode; // 0x38
		[DataMember(Name = "BundleSize")]
		[SerializeField]
		private long m_BundleSize; // 0x40
		[DataMember(Name = "UseCrcForCachedBundle")]
		[SerializeField]
		private bool m_UseCrcForCachedBundles; // 0x48
		[DataMember(Name = "UseUnityWebRequestForLocalBundles")]
		[SerializeField]
		private bool m_UseUWRForLocalBundles; // 0x49
		[DataMember(Name = "ClearOtherCachedVersionsWhenLoaded")]
		[SerializeField]
		private bool m_ClearOtherCachedVersionsWhenLoaded; // 0x4A
	
		// Properties
		public string Hash { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public uint Crc { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public int Timeout { get; set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public bool ChunkedTransfer { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
		public int RedirectLimit { get; set; } // 0x0000000182042F40-0x0000000182042F60 0x0000000180E02560-0x0000000180E02570
		public int RetryCount { get; set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public string BundleName { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public AssetLoadMode AssetLoadMode { get; set; } // 0x000000018047EDE0-0x000000018047EDF0 0x00000001805D5570-0x00000001805D5580
		public long BundleSize { get; set; } // 0x0000000180377940-0x0000000180377950 0x000000018172A470-0x000000018172A480
		public bool UseCrcForCachedBundle { get; set; } // 0x00000001804EFDA0-0x00000001804EFDB0 0x0000000180C47C30-0x0000000180C47C40
		public bool UseUnityWebRequestForLocalBundles { get; set; } // 0x0000000181A42150-0x0000000181A42160 0x0000000182042F70-0x0000000182042F80
		public bool ClearOtherCachedVersionsWhenLoaded { get; set; } // 0x0000000181A42140-0x0000000181A42150 0x0000000182042F60-0x0000000182042F70
	
		// Constructors
		public AssetBundleRequestOptions(); // 0x0000000182042E10-0x0000000182042E70
		public AssetBundleRequestOptions(AssetBundleRequestOptions abro); // 0x0000000182042E70-0x0000000182042F40
	
		// Methods
		public virtual long ComputeSize(IResourceLocation location, ResourceManager resourceManager); // 0x0000000182042C70-0x0000000182042E10
	}
}
