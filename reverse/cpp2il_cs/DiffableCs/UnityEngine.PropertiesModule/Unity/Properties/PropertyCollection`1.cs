namespace Unity.Properties;

[IsReadOnly]
public struct PropertyCollection : IEnumerable<IProperty`1<TContainer>>, IEnumerable
{
	internal struct Enumerator : IEnumerator<IProperty`1<TContainer>>, IEnumerator, IDisposable
	{
		private readonly EnumeratorType<TContainer> m_Type; //Field offset: 0x0
		private IEnumerator<IProperty`1<TContainer>> m_Enumerator; //Field offset: 0x0
		private Enumerator<IProperty<TContainer>> m_Properties; //Field offset: 0x0
		private IndexedCollectionPropertyBagEnumerator<TContainer> m_IndexedCollectionPropertyBag; //Field offset: 0x0
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private IProperty<TContainer> <Current>k__BackingField; //Field offset: 0x0

		public private override IProperty<TContainer> Current
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
			[CompilerGenerated]
			private set { } //Length: 13
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 37
		}

		internal Enumerator(IEnumerator<IProperty`1<TContainer>> enumerator) { }

		internal Enumerator(Enumerator<IProperty<TContainer>> properties) { }

		internal Enumerator(IndexedCollectionPropertyBagEnumerator<TContainer> enumerator) { }

		public override void Dispose() { }

		[CompilerGenerated]
		[IsReadOnly]
		public override IProperty<TContainer> get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		[CompilerGenerated]
		private void set_Current(IProperty<TContainer> value) { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	private enum EnumeratorType
	{
		Empty = 0,
		Enumerable = 1,
		List = 2,
		IndexedCollectionPropertyBag = 3,
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static readonly PropertyCollection<TContainer> <Empty>k__BackingField; //Field offset: 0x0
	private readonly EnumeratorType<TContainer> m_Type; //Field offset: 0x0
	private readonly IEnumerable<IProperty`1<TContainer>> m_Enumerable; //Field offset: 0x0
	private readonly List<IProperty`1<TContainer>> m_Properties; //Field offset: 0x0
	private readonly IndexedCollectionPropertyBagEnumerable<TContainer> m_IndexedCollectionPropertyBag; //Field offset: 0x0

	public static PropertyCollection<TContainer> Empty
	{
		[CompilerGenerated]
		 get { } //Length: 176
	}

	private static PropertyCollection`1() { }

	public PropertyCollection`1(IEnumerable<IProperty`1<TContainer>> enumerable) { }

	public PropertyCollection`1(List<IProperty`1<TContainer>> properties) { }

	internal PropertyCollection`1(IndexedCollectionPropertyBagEnumerable<TContainer> enumerable) { }

	[CompilerGenerated]
	public static PropertyCollection<TContainer> get_Empty() { }

	public Enumerator<TContainer> GetEnumerator() { }

	private override IEnumerator<IProperty`1<TContainer>> System.Collections.Generic.IEnumerable<Unity.Properties.IProperty<TContainer>>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

