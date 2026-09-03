/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class LinkedPool<T> // TypeDefIndex: 5084
		where T : LinkedPoolItem<T>
	{
		// Fields
		private readonly Func<T> m_CreateFunc;
		private readonly Action<T> m_ResetAction;
		private readonly int m_Limit;
		private T m_PoolFirst;
		[CompilerGenerated]
		private int _Count_k__BackingField;
	
		// Properties
		public int Count { [CompilerGenerated] get; [CompilerGenerated] private set; }
	
		// Constructors
		public LinkedPool(Func<T> createFunc, Action<T> resetAction, int limit = 10000 /* Metadata: 0x00660A89 */);
	
		// Methods
		public void Clear();
		public T Get();
		public void Return(T item);
	}
}
