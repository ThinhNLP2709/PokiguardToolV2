namespace UnityEngine.UIElements;

public interface IStyleValue
{

	public StyleKeyword keyword
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public T value
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public StyleKeyword get_keyword() { }

	public T get_value() { }

	public void set_keyword(StyleKeyword value) { }

	public void set_value(T value) { }

}

