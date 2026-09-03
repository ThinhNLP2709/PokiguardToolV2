/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets
{
	internal class DynamicResourceLocator : IResourceLocator // TypeDefIndex: 14082
	{
		// Fields
		private AddressablesImpl m_Addressables; // 0x10
		private string m_AtlasSpriteProviderId; // 0x18
	
		// Properties
		public string LocatorId { get; } // 0x0000000181C78C50-0x0000000181C78C80 
		public virtual IEnumerable<object> Keys { get; } // 0x0000000181C78C10-0x0000000181C78C50 
		private string AtlasSpriteProviderId { get; } // 0x0000000181C789B0-0x0000000181C78C10 
		public IEnumerable<IResourceLocation> AllLocations { get; } // 0x0000000181C78970-0x0000000181C789B0 
	
		// Constructors
		public DynamicResourceLocator(AddressablesImpl addr); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public bool Locate(object key, Type type, out IList<IResourceLocation> locations); // 0x0000000181C78640-0x0000000181C78970
		internal void CreateDynamicLocations(Type type, IList<IResourceLocation> locations, string locName, string subKey, IResourceLocation mainLoc); // 0x0000000181C78240-0x0000000181C78640
	}
}
