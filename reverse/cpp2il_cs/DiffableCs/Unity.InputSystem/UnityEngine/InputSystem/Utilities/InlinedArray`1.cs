namespace UnityEngine.InputSystem.Utilities;

[DefaultMember("Item")]
internal struct InlinedArray : IEnumerable<TValue>, IEnumerable
{
	private struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
	{
		public InlinedArray<TValue> array; //Field offset: 0x0
		public int index; //Field offset: 0x0

		public override TValue Current
		{
			 get { } //Length: 68
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 161
		}

		public override void Dispose() { }

		public override TValue get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	public int length; //Field offset: 0x0
	public TValue firstValue; //Field offset: 0x0
	public TValue[] additionalValues; //Field offset: 0x0

	public int Capacity
	{
		 get { } //Length: 21
	}

	public TValue Item
	{
		 get { } //Length: 143
		 set { } //Length: 143
	}

	public InlinedArray`1(TValue value) { }

	public InlinedArray`1(TValue firstValue, TValue[] additionalValues) { }

	public InlinedArray`1(IEnumerable<TValue> values) { }

	public void Append(IEnumerable<TValue> values) { }

	public int Append(TValue value) { }

	public int AppendWithCapacity(TValue value, int capacityIncrement = 10) { }

	public void AssignWithCapacity(InlinedArray<TValue> values) { }

	public void Clear() { }

	public void ClearWithCapacity() { }

	public InlinedArray<TValue> Clone() { }

	public bool Contains(TValue value, IEqualityComparer<TValue> comparer) { }

	public int get_Capacity() { }

	public TValue get_Item(int index) { }

	public override IEnumerator<TValue> GetEnumerator() { }

	public int IndexOf(TValue value) { }

	public void Merge(InlinedArray<TValue> other) { }

	public void Remove(TValue value) { }

	public void RemoveAt(int index) { }

	public void RemoveAtByMovingTailWithCapacity(int index) { }

	public void RemoveAtWithCapacity(int index) { }

	public bool RemoveByMovingTailWithCapacity(TValue value) { }

	public void set_Item(int index, TValue value) { }

	public void SetLength(int size) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public TValue[] ToArray() { }

	public TOther[] ToArray(Func<TValue, TOther> mapFunction) { }

}

