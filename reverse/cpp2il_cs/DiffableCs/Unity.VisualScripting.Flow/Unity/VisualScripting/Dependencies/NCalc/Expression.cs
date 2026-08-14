namespace Unity.VisualScripting.Dependencies.NCalc;

public class Expression
{
	private static bool _cacheEnabled; //Field offset: 0x0
	private static Dictionary<String, WeakReference> _compiledExpressions; //Field offset: 0x8
	private static readonly ReaderWriterLock Rwl; //Field offset: 0x10
	[CompilerGenerated]
	private EvaluateFunctionHandler EvaluateFunction; //Field offset: 0x10
	[CompilerGenerated]
	private EvaluateParameterHandler EvaluateParameter; //Field offset: 0x18
	protected readonly string OriginalExpression; //Field offset: 0x20
	protected Dictionary<String, IEnumerator> ParameterEnumerators; //Field offset: 0x28
	private Dictionary<String, Object> _parameters; //Field offset: 0x30
	[CompilerGenerated]
	private EvaluateOptions <Options>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private string <Error>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private LogicalExpression <ParsedExpression>k__BackingField; //Field offset: 0x48

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

	public static bool CacheEnabled
	{
		 get { } //Length: 78
		 set { } //Length: 278
	}

	public private string Error
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public EvaluateOptions Options
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public Dictionary<String, Object> Parameters
	{
		 get { } //Length: 123
		 set { } //Length: 13
	}

	public private LogicalExpression ParsedExpression
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	private static Expression() { }

	public Expression(LogicalExpression expression, EvaluateOptions options = 1) { }

	private Expression() { }

	public Expression(string expression, EvaluateOptions options = 1) { }

	[CompilerGenerated]
	public void add_EvaluateFunction(EvaluateFunctionHandler value) { }

	[CompilerGenerated]
	public void add_EvaluateParameter(EvaluateParameterHandler value) { }

	private static void CleanCache() { }

	public static LogicalExpression Compile(string expression, bool noCache) { }

	public object Evaluate(Flow flow) { }

	public static bool get_CacheEnabled() { }

	[CompilerGenerated]
	public string get_Error() { }

	[CompilerGenerated]
	public EvaluateOptions get_Options() { }

	public Dictionary<String, Object> get_Parameters() { }

	[CompilerGenerated]
	public LogicalExpression get_ParsedExpression() { }

	public bool HasErrors() { }

	[CompilerGenerated]
	public void remove_EvaluateFunction(EvaluateFunctionHandler value) { }

	[CompilerGenerated]
	public void remove_EvaluateParameter(EvaluateParameterHandler value) { }

	public static void set_CacheEnabled(bool value) { }

	[CompilerGenerated]
	private void set_Error(string value) { }

	[CompilerGenerated]
	public void set_Options(EvaluateOptions value) { }

	public void set_Parameters(Dictionary<String, Object> value) { }

	[CompilerGenerated]
	private void set_ParsedExpression(LogicalExpression value) { }

	public void UpdateUnityTimeParameters() { }

}

