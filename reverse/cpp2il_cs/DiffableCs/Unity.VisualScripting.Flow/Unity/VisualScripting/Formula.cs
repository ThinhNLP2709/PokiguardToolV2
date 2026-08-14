namespace Unity.VisualScripting;

public sealed class Formula : MultiInputUnit<Object>
{
	[SerializeAs("Formula")]
	private string _formula; //Field offset: 0xA0
	private Expression ncalc; //Field offset: 0xA8
	[CompilerGenerated]
	private bool <cacheArguments>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <result>k__BackingField; //Field offset: 0xB8

	[Inspectable(order = 2147483647)]
	[InspectorExpandTooltip]
	[Serialize]
	public bool cacheArguments
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	[DoNotSerialize]
	[Inspectable]
	[InspectorTextArea]
	[UnitHeaderInspectable]
	public string formula
	{
		 get { } //Length: 8
		 set { } //Length: 43
	}

	protected virtual int minInputCount
	{
		 get { } //Length: 3
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput result
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public Formula() { }

	protected virtual void Definition() { }

	private object Evaluate(Flow flow) { }

	private void EvaluateTreeFunction(Flow flow, string name, FunctionArgs args) { }

	private void EvaluateTreeParameter(Flow flow, string name, ParameterArgs args) { }

	[CompilerGenerated]
	public bool get_cacheArguments() { }

	public string get_formula() { }

	protected virtual int get_minInputCount() { }

	[CompilerGenerated]
	public ValueOutput get_result() { }

	public static int GetArgumentIndex(char name) { }

	public static string GetArgumentName(int index) { }

	public object GetParameterValue(Flow flow, string name) { }

	private void InitializeNCalc() { }

	[CompilerGenerated]
	public void set_cacheArguments(bool value) { }

	public void set_formula(string value) { }

	[CompilerGenerated]
	private void set_result(ValueOutput value) { }

}

