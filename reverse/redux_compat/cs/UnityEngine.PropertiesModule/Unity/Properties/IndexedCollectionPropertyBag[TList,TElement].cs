/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	public class IndexedCollectionPropertyBag<TList, TElement> : PropertyBag<TList>, IListPropertyBag<TList, TElement>, IConstructorWithCount<TList>, IIndexedCollectionPropertyBagEnumerator<TList> // TypeDefIndex: 14475
		where TList : IList<TElement>
	{
		// Fields
		private readonly ListElementProperty m_Property;
	
		// Nested types
		private class ListElementProperty : Property<TList, TElement>, IListElementProperty // TypeDefIndex: 14476
		{
			// Fields
			internal int m_Index;
			internal bool m_IsReadOnly;
	
			// Properties
			public int Index { get; }
			public override string Name { get; }
			public override bool IsReadOnly { get; }
	
			// Constructors
			public ListElementProperty();
	
			// Methods
			public override TElement GetValue(ref ref TList container);
			public override void SetValue(ref ref TList container, TElement value);
		}
	
		// Constructors
		public IndexedCollectionPropertyBag();
	
		// Methods
		public override PropertyCollection<TList> GetProperties();
		public override PropertyCollection<TList> GetProperties(ref ref TList container);
		public bool TryGetProperty(ref ref TList container, int index, out IProperty<TList> property);
		void ICollectionPropertyBagAccept<TList>.Accept(ICollectionPropertyBagVisitor visitor, ref ref TList container);
		void IListPropertyBagAccept<TList>.Accept(IListPropertyBagVisitor visitor, ref ref TList list);
		void IListPropertyAccept<TList>.Accept<TContainer>(IListPropertyVisitor visitor, Property<TContainer, TList> property, ref ref TContainer container, ref ref TList list);
		TList IConstructorWithCount<TList>.InstantiateWithCount(int count);
		protected virtual TList InstantiateWithCount(int count);
		int IIndexedCollectionPropertyBagEnumerator<TList>.GetCount(ref ref TList container);
		IProperty<TList> IIndexedCollectionPropertyBagEnumerator<TList>.GetSharedProperty();
		IndexedCollectionSharedPropertyState IIndexedCollectionPropertyBagEnumerator<TList>.GetSharedPropertyState();
		void IIndexedCollectionPropertyBagEnumerator<TList>.SetSharedPropertyState(IndexedCollectionSharedPropertyState state);
	}
}
