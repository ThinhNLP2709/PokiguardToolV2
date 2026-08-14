namespace Unity.Properties;

public class KeyValueCollectionPropertyBag : PropertyBag<TDictionary>, IDictionaryPropertyBag<TDictionary, TKey, TValue>, ICollectionPropertyBag<TDictionary, KeyValuePair`2<TKey, TValue>>, IPropertyBag<TDictionary>, IPropertyBag, ICollectionPropertyBagAccept<TDictionary>, IDictionaryPropertyBagAccept<TDictionary>, IKeyedProperties<TDictionary, Object>
{
	[IsReadOnly]
	private struct Enumerable : IEnumerable<IProperty`1<TDictionary>>, IEnumerable
	{
		private class Enumerator : IEnumerator<IProperty`1<TDictionary>>, IEnumerator, IDisposable
		{
			private readonly TDictionary m_Dictionary; //Field offset: 0x0
			private readonly KeyValuePairProperty<TDictionary, TKey, TValue> m_Property; //Field offset: 0x0
			private readonly TKey m_Previous; //Field offset: 0x0
			private readonly List<TKey> m_Keys; //Field offset: 0x0
			private int m_Position; //Field offset: 0x0

			public override IProperty<TDictionary> Current
			{
				 get { } //Length: 43
			}

			private override object System.Collections.IEnumerator.Current
			{
				private get { } //Length: 24
			}

			public Enumerator(TDictionary dictionary, KeyValuePairProperty<TDictionary, TKey, TValue> property) { }

			public override void Dispose() { }

			public override IProperty<TDictionary> get_Current() { }

			public override bool MoveNext() { }

			public override void Reset() { }

			private override object System.Collections.IEnumerator.get_Current() { }

		}

		private readonly TDictionary m_Dictionary; //Field offset: 0x0
		private readonly KeyValuePairProperty<TDictionary, TKey, TValue> m_Property; //Field offset: 0x0

		public Enumerable(TDictionary dictionary, KeyValuePairProperty<TDictionary, TKey, TValue> property) { }

		private override IEnumerator<IProperty`1<TDictionary>> System.Collections.Generic.IEnumerable<Unity.Properties.IProperty<TDictionary>>.GetEnumerator() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	}

	private class KeyValuePairProperty : Property<TDictionary, KeyValuePair`2<TKey, TValue>>, IDictionaryElementProperty
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private TKey <Key>k__BackingField; //Field offset: 0x0

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public internal override TKey Key
		{
			[CompilerGenerated]
			 get { } //Length: 169
			[CompilerGenerated]
			internal set { } //Length: 182
		}

		public virtual string Name
		{
			 get { } //Length: 354
		}

		public override object ObjectKey
		{
			 get { } //Length: 166
		}

		public KeyValuePairProperty() { }

		public virtual bool get_IsReadOnly() { }

		[CompilerGenerated]
		public override TKey get_Key() { }

		public virtual string get_Name() { }

		public override object get_ObjectKey() { }

		public virtual KeyValuePair<TKey, TValue> GetValue(ref TDictionary container) { }

		[CompilerGenerated]
		internal void set_Key(TKey value) { }

		public virtual void SetValue(ref TDictionary container, KeyValuePair<TKey, TValue> value) { }

	}

	private readonly KeyValuePairProperty<TDictionary, TKey, TValue> m_KeyValuePairProperty; //Field offset: 0x0

	public KeyValueCollectionPropertyBag`3() { }

	public virtual PropertyCollection<TDictionary> GetProperties() { }

	public virtual PropertyCollection<TDictionary> GetProperties(ref TDictionary container) { }

	private override void Unity.Properties.ICollectionPropertyBagAccept<TDictionary>.Accept(ICollectionPropertyBagVisitor visitor, ref TDictionary container) { }

	private override void Unity.Properties.IDictionaryPropertyBagAccept<TDictionary>.Accept(IDictionaryPropertyBagVisitor visitor, ref TDictionary container) { }

	private override bool Unity.Properties.IKeyedProperties<TDictionary,System.Object>.TryGetProperty(ref TDictionary container, object key, out IProperty<TDictionary>& property) { }

}

