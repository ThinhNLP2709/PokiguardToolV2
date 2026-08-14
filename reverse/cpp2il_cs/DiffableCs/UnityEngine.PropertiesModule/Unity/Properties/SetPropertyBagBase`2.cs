namespace Unity.Properties;

public class SetPropertyBagBase : PropertyBag<TSet>, ISetPropertyBag<TSet, TElement>, ICollectionPropertyBag<TSet, TElement>, IPropertyBag<TSet>, IPropertyBag, ICollectionPropertyBagAccept<TSet>, ISetPropertyBagAccept<TSet>, IKeyedProperties<TSet, Object>
{
	[CompilerGenerated]
	private sealed class <GetPropertiesEnumerable>d__4 : IEnumerable<IProperty`1<TSet>>, IEnumerable, IEnumerator<IProperty`1<TSet>>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private IProperty<TSet> <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0
		private TSet container; //Field offset: 0x0
		public TSet <>3__container; //Field offset: 0x0
		public SetPropertyBagBase<TSet, TElement> <>4__this; //Field offset: 0x0
		private IEnumerator<TElement> <>s__1; //Field offset: 0x0
		private TElement <element>5__2; //Field offset: 0x0

		private override IProperty<TSet> System.Collections.Generic.IEnumerator<Unity.Properties.IProperty<TSet>>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 42
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 42
		}

		[DebuggerHidden]
		public <GetPropertiesEnumerable>d__4(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<IProperty`1<TSet>> System.Collections.Generic.IEnumerable<Unity.Properties.IProperty<TSet>>.GetEnumerator() { }

		[DebuggerHidden]
		private override IProperty<TSet> System.Collections.Generic.IEnumerator<Unity.Properties.IProperty<TSet>>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private class SetElementProperty : Property<TSet, TElement>, ISetElementProperty
	{
		internal TElement m_Value; //Field offset: 0x0

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 230
		}

		public override object ObjectKey
		{
			 get { } //Length: 169
		}

		public SetElementProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public override object get_ObjectKey() { }

		public virtual TElement GetValue(ref TSet container) { }

		public virtual void SetValue(ref TSet container, TElement value) { }

	}

	private readonly SetElementProperty<TSet, TElement> m_Property; //Field offset: 0x0

	public SetPropertyBagBase`2() { }

	public virtual PropertyCollection<TSet> GetProperties() { }

	public virtual PropertyCollection<TSet> GetProperties(ref TSet container) { }

	[IteratorStateMachine(typeof(<GetPropertiesEnumerable>d__4))]
	private IEnumerable<IProperty`1<TSet>> GetPropertiesEnumerable(TSet container) { }

	public override bool TryGetProperty(ref TSet container, object key, out IProperty<TSet>& property) { }

	private override void Unity.Properties.ICollectionPropertyBagAccept<TSet>.Accept(ICollectionPropertyBagVisitor visitor, ref TSet container) { }

	private override void Unity.Properties.ISetPropertyBagAccept<TSet>.Accept(ISetPropertyBagVisitor visitor, ref TSet container) { }

}

