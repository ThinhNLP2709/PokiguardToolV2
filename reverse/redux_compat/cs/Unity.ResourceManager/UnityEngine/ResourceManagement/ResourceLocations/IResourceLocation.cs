/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceLocations
{
	public interface IResourceLocation // TypeDefIndex: 13774
	{
		// Properties
		string InternalId { get; }
		string ProviderId { get; }
		IList<IResourceLocation> Dependencies { get; }
		int DependencyHashCode { get; }
		bool HasDependencies { get; }
		object Data { get; }
		string PrimaryKey { get; }
		Type ResourceType { get; }
	
		// Methods
		int Hash(Type resultType);
	}
}
