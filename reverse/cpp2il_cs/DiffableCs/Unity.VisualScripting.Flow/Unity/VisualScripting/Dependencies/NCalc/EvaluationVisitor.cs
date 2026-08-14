namespace Unity.VisualScripting.Dependencies.NCalc;

public class EvaluationVisitor : LogicalExpressionVisitor
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public object leftValue; //Field offset: 0x10
		public BinaryExpression binary; //Field offset: 0x18
		public EvaluationVisitor <>4__this; //Field offset: 0x20
		public object rightValue; //Field offset: 0x28

		public <>c__DisplayClass21_0() { }

		internal object <Visit>b__0() { }

		internal object <Visit>b__1() { }

	}

	private sealed class Func : MulticastDelegate
	{

		public Func`1(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(AsyncCallback callback, object object) { }

		public override T EndInvoke(IAsyncResult result) { }

		public override T Invoke() { }

	}

	[CompilerGenerated]
	private EvaluateFunctionHandler EvaluateFunction; //Field offset: 0x10
	[CompilerGenerated]
	private EvaluateParameterHandler EvaluateParameter; //Field offset: 0x18
	private readonly Flow flow; //Field offset: 0x20
	private readonly EvaluateOptions options; //Field offset: 0x28
	[CompilerGenerated]
	private object <Result>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private Dictionary<String, Object> <Parameters>k__BackingField; //Field offset: 0x38

	public event EvaluateFunctionHandler EvaluateFunction
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public event EvaluateParameterHandler EvaluateParameter
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	private bool IgnoreCase
	{
		private get { } //Length: 8
	}

	public Dictionary<String, Object> Parameters
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public private object Result
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public EvaluationVisitor(Flow flow, EvaluateOptions options) { }

	[CompilerGenerated]
	public void add_EvaluateFunction(EvaluateFunctionHandler value) { }

	[CompilerGenerated]
	public void add_EvaluateParameter(EvaluateParameterHandler value) { }

	private void CheckCase(FunctionExpression function, string reference) { }

	public static void CheckExactArgumentCount(FunctionExpression function, int count) { }

	public static void CheckMinArgumentCount(FunctionExpression function, int count) { }

	private object Evaluate(LogicalExpression expression) { }

	private bool get_IgnoreCase() { }

	[CompilerGenerated]
	public Dictionary<String, Object> get_Parameters() { }

	[CompilerGenerated]
	public object get_Result() { }

	private void OnEvaluateFunction(string name, FunctionArgs args) { }

	private void OnEvaluateParameter(string name, ParameterArgs args) { }

	[CompilerGenerated]
	public void remove_EvaluateFunction(EvaluateFunctionHandler value) { }

	[CompilerGenerated]
	public void remove_EvaluateParameter(EvaluateParameterHandler value) { }

	[CompilerGenerated]
	public void set_Parameters(Dictionary<String, Object> value) { }

	[CompilerGenerated]
	private void set_Result(object value) { }

	public virtual void Visit(TernaryExpression ternary) { }

	public virtual void Visit(BinaryExpression binary) { }

	public virtual void Visit(UnaryExpression unary) { }

	public virtual void Visit(ValueExpression value) { }

	public virtual void Visit(FunctionExpression function) { }

	public virtual void Visit(IdentifierExpression identifier) { }

}

