/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Pool
{
	public class ObjectPool<T> : IDisposable, IPool, IObjectPool<T> // TypeDefIndex: 8170
		where T : class
	{
		// Fields
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal readonly List<T> m_List;
		private readonly Func<T> m_CreateFunc;
		private readonly Action<T> m_ActionOnGet;
		private readonly Action<T> m_ActionOnRelease;
		private readonly Action<T> m_ActionOnDestroy;
		private readonly int m_MaxSize;
		internal bool m_CollectionCheck;
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal T m_FreshlyReleased;
		[CompilerGenerated]
		private int _CountAll_k__BackingField;
	
		// Properties
		public int CountAll { [CompilerGenerated] get; [CompilerGenerated] private set; }
		public int CountInactive { get; }
	
		// Constructors
		public ObjectPool(Func<T> createFunc, Action<T> actionOnGet = null, Action<T> actionOnRelease = null, Action<T> actionOnDestroy = null, bool collectionCheck = true /* Metadata: 0x0069D843 */, int defaultCapacity = 10 /* Metadata: 0x0069D844 */, int maxSize = 10000 /* Metadata: 0x0069D845 */);
	
		// Methods
		public T Get();
		public PooledObject<T> Get(out ref T v);
		public void Release(T element);
		public void Clear();
		public void Dispose();
	}
}
