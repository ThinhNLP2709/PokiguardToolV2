/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement.ResourceLocations;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	internal sealed class LocationCacheKey : IOperationCacheKey // TypeDefIndex: 13708
	{
		// Fields
		private readonly IResourceLocation m_Location; // 0x10
		private readonly Type m_DesiredType; // 0x18
	
		// Constructors
		public LocationCacheKey(IResourceLocation location, Type desiredType); // 0x000000018204FBC0-0x000000018204FCD0
	
		// Methods
		public override int GetHashCode(); // 0x000000018204FB70-0x000000018204FBC0
		public override bool Equals(object obj); // 0x000000018204F9D0-0x000000018204FA30
		public bool Equals(IOperationCacheKey other); // 0x000000018204FB10-0x000000018204FB70
		private bool Equals(LocationCacheKey other); // 0x000000018204FA30-0x000000018204FB10
	}
}
