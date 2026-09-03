/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	[IsReadOnly]
	public struct PropertyCollection<TContainer> : IEnumerable<Unity.Properties.IProperty<TContainer>> // TypeDefIndex: 14496
	{
		// Fields
		private readonly EnumeratorType m_Type;
		private readonly IEnumerable<IProperty<TContainer>> m_Enumerable;
		private readonly List<IProperty<TContainer>> m_Properties;
		private readonly IndexedCollectionPropertyBagEnumerable<TContainer> m_IndexedCollectionPropertyBag;
		[CompilerGenerated]
		private static readonly PropertyCollection<TContainer> _Empty_k__BackingField;
	
		// Properties
		[NoAutoStaticsCleanup]
		public static PropertyCollection<TContainer> Empty { [CompilerGenerated] get; }
	
		// Nested types
		private enum EnumeratorType // TypeDefIndex: 14497
		{
			Empty = 0,
			Enumerable = 1,
			List = 2,
			IndexedCollectionPropertyBag = 3
		}
	
		public struct Enumerator : IEnumerator<IProperty<TContainer>> // TypeDefIndex: 14498
		{
			// Fields
			private readonly EnumeratorType<TContainer> m_Type;
			private IEnumerator<IProperty<TContainer>> m_Enumerator;
			private List<IProperty<TContainer>> m_Properties;
			private IndexedCollectionPropertyBagEnumerator<TContainer> m_IndexedCollectionPropertyBag;
			[CompilerGenerated]
			private IProperty<TContainer> _Current_k__BackingField;
	
			// Properties
			public IProperty<TContainer> Current { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; }
			object IEnumerator.Current { get; }
	
			// Constructors
			internal Enumerator(IEnumerator<IProperty<TContainer>> enumerator);
			internal Enumerator(List<IProperty<TContainer>> properties);
			internal Enumerator(IndexedCollectionPropertyBagEnumerator<TContainer> enumerator);
	
			// Methods
			public bool MoveNext();
			public void Reset();
			public void Dispose();
		}
	
		// Constructors
		public PropertyCollection(IEnumerable<IProperty<TContainer>> enumerable);
		public PropertyCollection(List<IProperty<TContainer>> properties);
		internal PropertyCollection(IndexedCollectionPropertyBagEnumerable<TContainer> enumerable);
	
		// Methods
		public Enumerator GetEnumerator();
		IEnumerator<IProperty<TContainer>> IEnumerable<IProperty<TContainer>>.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
	}
}
