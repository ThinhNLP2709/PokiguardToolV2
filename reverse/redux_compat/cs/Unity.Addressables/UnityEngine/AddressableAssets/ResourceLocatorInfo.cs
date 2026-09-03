/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets
{
	public class ResourceLocatorInfo // TypeDefIndex: 14029
	{
		// Fields
		[CompilerGenerated]
		private IResourceLocator _Locator_k__BackingField; // 0x10
		[CompilerGenerated]
		private string _LocalHash_k__BackingField; // 0x18
		[CompilerGenerated]
		private IResourceLocation _CatalogLocation_k__BackingField; // 0x20
		[CompilerGenerated]
		private bool _ContentUpdateAvailable_k__BackingField; // 0x28
	
		// Properties
		public IResourceLocator Locator { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string LocalHash { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public IResourceLocation CatalogLocation { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		internal bool ContentUpdateAvailable { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		public IResourceLocation HashLocation { get; } // 0x0000000181C80470-0x0000000181C804E0 
		public bool CanUpdateContent { get; } // 0x0000000181C803C0-0x0000000181C80470 
	
		// Constructors
		public ResourceLocatorInfo(IResourceLocator loc, string localHash, IResourceLocation remoteCatalogLocation); // 0x00000001803A7D10-0x00000001803A7D80
	
		// Methods
		internal void UpdateContent(IResourceLocator locator, string hash, IResourceLocation loc); // 0x0000000181C80360-0x0000000181C803C0
	}
}
