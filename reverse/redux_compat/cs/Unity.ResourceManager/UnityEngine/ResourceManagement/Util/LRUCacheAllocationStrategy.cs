/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	public class LRUCacheAllocationStrategy : IAllocationStrategy // TypeDefIndex: 13717
	{
		// Fields
		private int m_poolMaxSize; // 0x10
		private int m_poolInitialCapacity; // 0x14
		private int m_poolCacheMaxSize; // 0x18
		private List<List<object>> m_poolCache; // 0x20
		private Dictionary<int, List<object>> m_cache; // 0x28
	
		// Constructors
		public LRUCacheAllocationStrategy(int poolMaxSize, int poolCapacity, int poolCacheMaxSize, int initialPoolCacheCapacity); // 0x000000018204F810-0x000000018204F9D0
	
		// Methods
		private List<object> GetPool(); // 0x000000018204F350-0x000000018204F410
		private void ReleasePool(List<object> pool); // 0x000000018204F5A0-0x000000018204F650
		public object New(Type type, int typeHash); // 0x000000018204F410-0x000000018204F5A0
		public void Release(int typeHash, object obj); // 0x000000018204F650-0x000000018204F810
	}
}
