namespace Unity.VisualScripting.Antlr3.Runtime;

public interface IIntStream
{

	public int Count
	{
		 get { } //Length: 0
	}

	public string SourceName
	{
		 get { } //Length: 0
	}

	public void Consume() { }

	public int get_Count() { }

	public string get_SourceName() { }

	public int Index() { }

	public int LA(int i) { }

	public int Mark() { }

	public void Release(int marker) { }

	public void Rewind(int marker) { }

	public void Rewind() { }

	public void Seek(int index) { }

	[Obsolete("Please use property Count instead.")]
	public int Size() { }

}

