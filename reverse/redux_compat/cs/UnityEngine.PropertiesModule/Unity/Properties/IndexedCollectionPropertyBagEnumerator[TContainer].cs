/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	internal struct IndexedCollectionPropertyBagEnumerator<TContainer> : IEnumerator<Unity.Properties.IProperty<TContainer>> // TypeDefIndex: 14472
	{
		// Fields
		private readonly IIndexedCollectionPropertyBagEnumerator<TContainer> m_Impl;
		private readonly IndexedCollectionSharedPropertyState m_Previous;
		private TContainer m_Container;
		private int m_Position;
	
		// Properties
		public IProperty<TContainer> Current { get; }
		object IEnumerator.Current { get; }
	
		// Constructors
		internal IndexedCollectionPropertyBagEnumerator(IIndexedCollectionPropertyBagEnumerator<TContainer> impl, TContainer container);
	
		// Methods
		public bool MoveNext();
		public void Reset();
		public void Dispose();
	}
}
