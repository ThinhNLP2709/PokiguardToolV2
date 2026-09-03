/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class ImplicitPool<T> // TypeDefIndex: 5076
		where T : class
	{
		// Fields
		private readonly int m_StartCapacity;
		private readonly int m_MaxCapacity;
		private Func<T> m_CreateAction;
		private Action<T> m_ResetAction;
		private List<T> m_List;
		private int m_UsedCount;
	
		// Constructors
		public ImplicitPool(Func<T> createAction, Action<T> resetAction, int startCapacity, int maxCapacity);
	
		// Methods
		public T Get();
		public void ReturnAll();
	}
}
