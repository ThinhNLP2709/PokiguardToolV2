namespace Unity.VisualScripting.Dependencies.NCalc;

public class ParameterArgs : EventArgs
{
	private object _result; //Field offset: 0x10
	[CompilerGenerated]
	private bool <HasResult>k__BackingField; //Field offset: 0x18

	public bool HasResult
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public object Result
	{
		 get { } //Length: 5
		 set { } //Length: 32
	}

	public ParameterArgs() { }

	[CompilerGenerated]
	public bool get_HasResult() { }

	public object get_Result() { }

	[CompilerGenerated]
	public void set_HasResult(bool value) { }

	public void set_Result(object value) { }

}

