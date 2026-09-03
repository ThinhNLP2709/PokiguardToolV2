/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets.Initialization
{
	[Serializable]
	public class CacheInitializationData // TypeDefIndex: 14118
	{
		// Fields
		[FormerlySerializedAs("m_compressionEnabled")]
		[SerializeField]
		private bool m_CompressionEnabled; // 0x10
		[FormerlySerializedAs("m_cacheDirectoryOverride")]
		[SerializeField]
		private string m_CacheDirectoryOverride; // 0x18
		[FormerlySerializedAs("m_limitCacheSize")]
		[SerializeField]
		private bool m_LimitCacheSize; // 0x20
		[FormerlySerializedAs("m_maximumCacheSize")]
		[SerializeField]
		private long m_MaximumCacheSize; // 0x28
	
		// Properties
		public bool CompressionEnabled { get; set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		public string CacheDirectoryOverride { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public bool LimitCacheSize { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
		public long MaximumCacheSize { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181C854D0-0x0000000181C854E0
	
		// Constructors
		public CacheInitializationData(); // 0x0000000181C85460-0x0000000181C854D0
	}
}
