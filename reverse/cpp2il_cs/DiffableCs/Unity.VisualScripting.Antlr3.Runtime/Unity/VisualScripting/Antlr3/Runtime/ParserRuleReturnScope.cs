namespace Unity.VisualScripting.Antlr3.Runtime;

public class ParserRuleReturnScope : RuleReturnScope
{
	private IToken start; //Field offset: 0x10
	private IToken stop; //Field offset: 0x18

	public virtual object Start
	{
		 get { } //Length: 5
		 set { } //Length: 159
	}

	public virtual object Stop
	{
		 get { } //Length: 5
		 set { } //Length: 159
	}

	public ParserRuleReturnScope() { }

	public virtual object get_Start() { }

	public virtual object get_Stop() { }

	public virtual void set_Start(object value) { }

	public virtual void set_Stop(object value) { }

}

