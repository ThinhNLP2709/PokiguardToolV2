namespace Unity.Properties;

public class KeyValuePairPropertyBag : PropertyBag<KeyValuePair`2<TKey, TValue>>, INamedProperties<KeyValuePair`2<TKey, TValue>>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<TKey, TValue> <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal TKey <.cctor>b__7_0(ref KeyValuePair<TKey, TValue>& container) { }

		internal TValue <.cctor>b__7_1(ref KeyValuePair<TKey, TValue>& container) { }

	}

	[CompilerGenerated]
	private sealed class <GetPropertiesEnumerable>d__4 : IEnumerable<IProperty`1<KeyValuePair`2<TKey, TValue>>>, IEnumerable, IEnumerator<IProperty`1<KeyValuePair`2<TKey, TValue>>>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x0
		private IProperty<KeyValuePair`2<TKey, TValue>> <>2__current; //Field offset: 0x0
		private int <>l__initialThreadId; //Field offset: 0x0

		private override IProperty<KeyValuePair`2<TKey, TValue>> System.Collections.Generic.IEnumerator<Unity.Properties.IProperty<System.Collections.Generic.KeyValuePair<TKey,TValue>>>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <GetPropertiesEnumerable>d__4(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<IProperty`1<KeyValuePair`2<TKey, TValue>>> System.Collections.Generic.IEnumerable<Unity.Properties.IProperty<System.Collections.Generic.KeyValuePair<TKey,TValue>>>.GetEnumerator() { }

		[DebuggerHidden]
		private override IProperty<KeyValuePair`2<TKey, TValue>> System.Collections.Generic.IEnumerator<Unity.Properties.IProperty<System.Collections.Generic.KeyValuePair<TKey,TValue>>>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private static readonly DelegateProperty<KeyValuePair`2<TKey, TValue>, TKey> s_KeyProperty; //Field offset: 0x0
	private static readonly DelegateProperty<KeyValuePair`2<TKey, TValue>, TValue> s_ValueProperty; //Field offset: 0x0

	private static KeyValuePairPropertyBag`2() { }

	public KeyValuePairPropertyBag`2() { }

	public virtual PropertyCollection<KeyValuePair`2<TKey, TValue>> GetProperties() { }

	public virtual PropertyCollection<KeyValuePair`2<TKey, TValue>> GetProperties(ref KeyValuePair<TKey, TValue>& container) { }

	[IteratorStateMachine(typeof(<GetPropertiesEnumerable>d__4))]
	private static IEnumerable<IProperty`1<KeyValuePair`2<TKey, TValue>>> GetPropertiesEnumerable() { }

	public override bool TryGetProperty(ref KeyValuePair<TKey, TValue>& container, string name, out IProperty<KeyValuePair`2<TKey, TValue>>& property) { }

}

