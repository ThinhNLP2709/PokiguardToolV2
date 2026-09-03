/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Events;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Obsolete("UnityEngine.Rendering.ObjectPool has been deprecated. Use UnityEngine.Pool.ObjectPool instead.", false)]
	public class ObjectPool<T> // TypeDefIndex: 5381
		where T : new()
	{
		// Fields
		private readonly Stack<T> m_Stack;
		private readonly UnityAction<T> m_ActionOnGet;
		private readonly UnityAction<T> m_ActionOnRelease;
		private readonly bool m_CollectionCheck;
		[CompilerGenerated]
		private int _countAll_k__BackingField;
	
		// Properties
		public int countAll { [CompilerGenerated] get; [CompilerGenerated] private set; }
		public int countActive { get; }
		public int countInactive { get; }
	
		// Nested types
		public struct PooledObject : IDisposable // TypeDefIndex: 5382
		{
			// Fields
			private readonly T m_ToReturn;
			private readonly ObjectPool<T> m_Pool;
	
			// Constructors
			internal PooledObject(T value, ObjectPool<T> pool);
	
			// Methods
			void IDisposable.Dispose();
		}
	
		// Constructors
		public ObjectPool(UnityAction<T> actionOnGet, UnityAction<T> actionOnRelease, bool collectionCheck = true /* Metadata: 0x006614BA */);
	
		// Methods
		public T Get();
		public PooledObject Get(out ref T v);
		public void Release(T element);
	}
}
