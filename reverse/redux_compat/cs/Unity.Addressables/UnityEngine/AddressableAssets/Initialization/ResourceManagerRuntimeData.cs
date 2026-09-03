/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.Util;
using UnityEngine.Serialization;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets.Initialization
{
	[Serializable]
	public class ResourceManagerRuntimeData // TypeDefIndex: 14125
	{
		// Fields
		public const string kCatalogAddress = "AddressablesMainContentCatalog"; // Metadata: 0x006A9558
		public const string kTypeTreeDataAddress = "AddressablesTypeTreeData"; // Metadata: 0x006A9577
		[SerializeField]
		private string m_buildTarget; // 0x10
		[FormerlySerializedAs("m_settingsHash")]
		[SerializeField]
		private string m_SettingsHash; // 0x18
		[FormerlySerializedAs("m_catalogLocations")]
		[SerializeField]
		private List<ResourceLocationData> m_CatalogLocations; // 0x20
		[FormerlySerializedAs("m_logResourceManagerExceptions")]
		[SerializeField]
		private bool m_LogResourceManagerExceptions; // 0x28
		[FormerlySerializedAs("m_extraInitializationData")]
		[SerializeField]
		private List<ObjectInitializationData> m_ExtraInitializationData; // 0x30
		[SerializeField]
		private bool m_DisableCatalogUpdateOnStart; // 0x38
		[SerializeField]
		private bool m_IsLocalCatalogInBundle; // 0x39
		[SerializeField]
		private SerializedType m_CertificateHandlerType; // 0x40
		[SerializeField]
		private string m_AddressablesVersion; // 0x60
		[SerializeField]
		private int m_maxConcurrentWebRequests; // 0x68
		[SerializeField]
		private int m_CatalogRequestsTimeout; // 0x6C
	
		// Properties
		public string BuildTarget { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string SettingsHash { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public List<ResourceLocationData> CatalogLocations { get; } // 0x00000001802F8630-0x00000001802F8640 
		public bool LogResourceManagerExceptions { get; set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		public List<ObjectInitializationData> InitializationObjects { get; } // 0x000000018031E110-0x000000018031E120 
		public bool DisableCatalogUpdateOnStartup { get; set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0
		public bool IsLocalCatalogInBundle { get; set; } // 0x00000001814CFF30-0x00000001814CFF40 0x00000001816DA820-0x00000001816DA830
		public Type CertificateHandlerType { get; set; } // 0x0000000181C88110-0x0000000181C88120 0x0000000181C88140-0x0000000181C88150
		public string AddressablesVersion { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		public int MaxConcurrentWebRequests { get; set; } // 0x00000001803002C0-0x00000001803002D0 0x0000000181C88150-0x0000000181C88170
		public int CatalogRequestsTimeout { get; set; } // 0x0000000180C55C40-0x0000000180C55C50 0x0000000181C88120-0x0000000181C88140
	
		// Constructors
		public ResourceManagerRuntimeData(); // 0x0000000181C88040-0x0000000181C88110
	}
}
