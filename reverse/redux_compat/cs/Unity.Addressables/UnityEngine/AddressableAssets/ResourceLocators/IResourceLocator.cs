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
	public interface IResourceLocator // TypeDefIndex: 14110
	{
		// Properties
		string LocatorId { get; }
		IEnumerable<object> Keys { get; }
		IEnumerable<IResourceLocation> AllLocations { get; }
	
		// Methods
		bool Locate(object key, Type type, out IList<IResourceLocation> locations);
	}
}
