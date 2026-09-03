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
	internal class LocationWrapper : IResourceLocation // TypeDefIndex: 13777
	{
		// Fields
		private IResourceLocation m_InternalLocation; // 0x10
	
		// Properties
		public string InternalId { get; } // 0x00000001820500F0-0x0000000182050140 
		public string ProviderId { get; } // 0x0000000182050190-0x00000001820501E0 
		public IList<IResourceLocation> Dependencies { get; } // 0x0000000182050000-0x0000000182050050 
		public int DependencyHashCode { get; } // 0x0000000182050050-0x00000001820500A0 
		public bool HasDependencies { get; } // 0x00000001820500A0-0x00000001820500F0 
		public object Data { get; } // 0x000000018204FFB0-0x0000000182050000 
		public string PrimaryKey { get; } // 0x0000000182050140-0x0000000182050190 
		public Type ResourceType { get; } // 0x00000001820501E0-0x0000000182050230 
	
		// Constructors
		public LocationWrapper(IResourceLocation location); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public int Hash(Type resultType); // 0x000000018204FF50-0x000000018204FFB0
	}
}
