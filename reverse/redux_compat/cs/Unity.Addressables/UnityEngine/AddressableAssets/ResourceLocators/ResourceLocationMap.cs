/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement.ResourceLocations;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets.ResourceLocators
{
	public class ResourceLocationMap : IResourceLocator // TypeDefIndex: 14112
	{
		// Fields
		[CompilerGenerated]
		private string _LocatorId_k__BackingField; // 0x10
		private Dictionary<object, IList<IResourceLocation>> locations; // 0x18
	
		// Properties
		public string LocatorId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public IEnumerable<IResourceLocation> AllLocations { get; } // 0x0000000181C7FCD0-0x0000000181C7FDD0 
		public Dictionary<object, IList<IResourceLocation>> Locations { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public IEnumerable<object> Keys { get; } // 0x0000000181C7FDD0-0x0000000181C7FE20 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14113
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<KeyValuePair<object, IList<IResourceLocation>>, IEnumerable<IResourceLocation>> __9__8_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181C84030-0x0000000181C840A0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal IEnumerable<IResourceLocation> _get_AllLocations_b__8_0(KeyValuePair<object, IList<IResourceLocation>> k); // 0x0000000181B55CB0-0x0000000181B55CC0
		}
	
		// Constructors
		public ResourceLocationMap(string id, int capacity = 0 /* Metadata: 0x006A9557 */); // 0x0000000181C7F330-0x0000000181C7F3E0
		public ResourceLocationMap(string id, IList<ResourceLocationData> locations); // 0x0000000181C7F3E0-0x0000000181C7FCD0
	
		// Methods
		public bool Locate(object key, Type type, out IList<IResourceLocation> locations); // 0x0000000181C7ECF0-0x0000000181C7F330
		public void Add(object key, IResourceLocation location); // 0x0000000181C7EB60-0x0000000181C7EC80
		public void Add(object key, IList<IResourceLocation> locations); // 0x0000000181C7EC80-0x0000000181C7ECF0
	}
}
