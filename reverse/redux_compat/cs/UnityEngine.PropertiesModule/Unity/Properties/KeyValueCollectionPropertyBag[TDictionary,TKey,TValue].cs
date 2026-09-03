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
	public class KeyValueCollectionPropertyBag<TDictionary, TKey, TValue> : PropertyBag<TDictionary>, IDictionaryPropertyBag<TDictionary, TKey, TValue> // TypeDefIndex: 14486
		where TDictionary : IDictionary<TKey, TValue>
	{
		// Fields
		private readonly KeyValuePairProperty m_KeyValuePairProperty;
	
		// Nested types
		private class KeyValuePairProperty : Property<TDictionary, KeyValuePair<TKey, TValue>>, IDictionaryElementProperty // TypeDefIndex: 14487
		{
			// Fields
			[CompilerGenerated]
			private TKey _Key_k__BackingField;
	
			// Properties
			public override string Name { get; }
			public override bool IsReadOnly { get; }
			public TKey Key { [CompilerGenerated] get; [CompilerGenerated] internal set; }
			public object ObjectKey { get; }
	
			// Constructors
			public KeyValuePairProperty();
	
			// Methods
			public override KeyValuePair<TKey, TValue> GetValue(ref ref TDictionary container);
			public override void SetValue(ref ref TDictionary container, KeyValuePair<TKey, TValue> value);
		}
	
		[IsReadOnly]
		private struct Enumerable : IEnumerable<IProperty<TDictionary>> // TypeDefIndex: 14488
		{
			// Fields
			private readonly TDictionary m_Dictionary;
			private readonly KeyValuePairProperty<TDictionary, TKey, TValue> m_Property;
	
			// Nested types
			private class Enumerator : IEnumerator<IProperty<TDictionary>> // TypeDefIndex: 14489
			{
				// Fields
				private readonly TDictionary m_Dictionary;
				private readonly KeyValuePairProperty<TDictionary, TKey, TValue> m_Property;
				private readonly TKey m_Previous;
				private readonly List<TKey> m_Keys;
				private int m_Position;
	
				// Properties
				public IProperty<TDictionary> Current { get; }
				object IEnumerator.Current { get; }
	
				// Constructors
				public Enumerator(TDictionary dictionary, KeyValuePairProperty<TDictionary, TKey, TValue> property);
	
				// Methods
				public bool MoveNext();
				public void Reset();
				public void Dispose();
			}
	
			// Constructors
			public Enumerable(TDictionary dictionary, KeyValuePairProperty<TDictionary, TKey, TValue> property);
	
			// Methods
			IEnumerator IEnumerable.GetEnumerator();
			IEnumerator<IProperty<TDictionary>> IEnumerable<IProperty<TDictionary>>.GetEnumerator();
		}
	
		// Constructors
		public KeyValueCollectionPropertyBag();
	
		// Methods
		public override PropertyCollection<TDictionary> GetProperties();
		public override PropertyCollection<TDictionary> GetProperties(ref ref TDictionary container);
		void ICollectionPropertyBagAccept<TDictionary>.Accept(ICollectionPropertyBagVisitor visitor, ref ref TDictionary container);
		void IDictionaryPropertyBagAccept<TDictionary>.Accept(IDictionaryPropertyBagVisitor visitor, ref ref TDictionary container);
		bool IKeyedProperties<TDictionary, object>.TryGetProperty(ref ref TDictionary container, object key, out IProperty<TDictionary> property);
	}
}
