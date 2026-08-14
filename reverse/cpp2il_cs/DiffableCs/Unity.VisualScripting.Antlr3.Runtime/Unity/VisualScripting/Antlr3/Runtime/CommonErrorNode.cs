namespace Unity.VisualScripting.Antlr3.Runtime;

public class CommonErrorNode : CommonTree
{
	public IIntStream input; //Field offset: 0x38
	public IToken start; //Field offset: 0x40
	public IToken stop; //Field offset: 0x48
	public RecognitionException trappedException; //Field offset: 0x50

	public virtual bool IsNil
	{
		 get { } //Length: 3
	}

	public virtual string Text
	{
		 get { } //Length: 762
	}

	public virtual int Type
	{
		 get { } //Length: 3
	}

	public CommonErrorNode(ITokenStream input, IToken start, IToken stop, RecognitionException e) { }

	public virtual bool get_IsNil() { }

	public virtual string get_Text() { }

	public virtual int get_Type() { }

	public virtual string ToString() { }

}

