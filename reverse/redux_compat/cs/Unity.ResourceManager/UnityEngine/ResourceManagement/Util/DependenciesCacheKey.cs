/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement.ResourceLocations;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	internal sealed class DependenciesCacheKey : IOperationCacheKey // TypeDefIndex: 13709
	{
		// Fields
		private readonly IList<IResourceLocation> m_Dependencies; // 0x10
		private readonly int m_DependenciesHash; // 0x18
	
		// Constructors
		public DependenciesCacheKey(IList<IResourceLocation> dependencies, int dependenciesHash); // 0x0000000180E02950-0x0000000180E029A0
	
		// Methods
		public override int GetHashCode(); // 0x0000000180B23260-0x0000000180B23270
		public override bool Equals(object obj); // 0x000000018204A6E0-0x000000018204A760
		public bool Equals(IOperationCacheKey other); // 0x000000018204A780-0x000000018204A800
		private bool Equals(DependenciesCacheKey other); // 0x000000018204A760-0x000000018204A780
	}
}
