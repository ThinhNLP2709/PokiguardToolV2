/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement.ResourceLocations;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	public interface IResourceProvider // TypeDefIndex: 13754
	{
		// Properties
		string ProviderId { get; }
		ProviderBehaviourFlags BehaviourFlags { get; }
	
		// Methods
		Type GetDefaultType(IResourceLocation location);
		bool CanProvide(Type type, IResourceLocation location);
		void Provide(ProvideHandle provideHandle);
		void Release(IResourceLocation location, object asset);
	}
}
