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
	public class LinkedListNodeCache<T> // TypeDefIndex: 13719
	{
		// Fields
		private int m_maxNodesAllowed;
		private int m_NodesCreated;
		private Stack<LinkedListNode<T>> m_NodeCache;
	
		// Properties
		internal int CreatedNodeCount { get; }
		internal int CachedNodeCount { get; set; }
	
		// Constructors
		public LinkedListNodeCache();
		public LinkedListNodeCache(int maxNodesAllowed, int initialCapacity, int initialPreallocateCount);
	
		// Methods
		private void InitCache(int maxNodesAllowed = 2147483647 /* Metadata: 0x006A7E50 */, int initialCapacity = 10 /* Metadata: 0x006A7E51 */, int initialPreallocateCount = 0 /* Metadata: 0x006A7E52 */);
		public LinkedListNode<T> Acquire(T val);
		public void Release(LinkedListNode<T> node);
	}
}
