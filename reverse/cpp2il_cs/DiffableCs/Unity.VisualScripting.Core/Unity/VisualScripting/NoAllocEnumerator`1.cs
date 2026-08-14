namespace Unity.VisualScripting;

public struct NoAllocEnumerator : IEnumerator<T>, IEnumerator, IDisposable
{
	private readonly IList<T> list; //Field offset: 0x0
	private int index; //Field offset: 0x0
	private T current; //Field offset: 0x0
	private bool exceeded; //Field offset: 0x0

	public override T Current
	{
		 get { } //Length: 5
	}

	private override object System.Collections.IEnumerator.Current
	{
		private get { } //Length: 99
	}

	public NoAllocEnumerator`1(IList<T> list) { }

	public override void Dispose() { }

	public override T get_Current() { }

	public override bool MoveNext() { }

	private override object System.Collections.IEnumerator.get_Current() { }

	private override void System.Collections.IEnumerator.Reset() { }

}

