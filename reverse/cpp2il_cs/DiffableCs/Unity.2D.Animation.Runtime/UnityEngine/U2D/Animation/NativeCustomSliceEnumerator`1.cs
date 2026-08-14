namespace UnityEngine.U2D.Animation;

internal struct NativeCustomSliceEnumerator : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
{
	private NativeCustomSlice<T> nativeCustomSlice; //Field offset: 0x0
	private int index; //Field offset: 0x0

	public override T Current
	{
		 get { } //Length: 134
	}

	private override object System.Collections.IEnumerator.Current
	{
		private get { } //Length: 208
	}

	internal NativeCustomSliceEnumerator`1(NativeSlice<Byte> slice, int length, int stride) { }

	public override T get_Current() { }

	public override IEnumerator<T> GetEnumerator() { }

	public override bool MoveNext() { }

	public override void Reset() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	private override object System.Collections.IEnumerator.get_Current() { }

	private override void System.IDisposable.Dispose() { }

}

