/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	[IsReadOnly]
	internal struct IndexedCollectionPropertyBagEnumerable<TContainer> // TypeDefIndex: 14471
	{
		// Fields
		private readonly IIndexedCollectionPropertyBagEnumerator<TContainer> m_Impl;
		private readonly TContainer m_Container;
	
		// Constructors
		public IndexedCollectionPropertyBagEnumerable(IIndexedCollectionPropertyBagEnumerator<TContainer> impl, TContainer container);
	
		// Methods
		public IndexedCollectionPropertyBagEnumerator<TContainer> GetEnumerator();
	}
}
