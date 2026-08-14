namespace Unity.VisualScripting;

public sealed class Flow : IPoolable, IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Flow> <>9__35_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal Flow <New>b__35_0() { }

	}

	[CompilerGenerated]
	private sealed class <Coroutine>d__53 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Flow <>4__this; //Field offset: 0x20
		public ControlOutput startPort; //Field offset: 0x28
		private IEnumerator <>7__wrap1; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <Coroutine>d__53(int <>1__state) { }

		private void <>m__Finally1() { }

		private void <>m__Finally2() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <InvokeCoroutine>d__55 : IEnumerable<Object>, IEnumerable, IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private ControlOutput output; //Field offset: 0x28
		public ControlOutput <>3__output; //Field offset: 0x30
		public Flow <>4__this; //Field offset: 0x38
		private RecursionNode <recursionNode>5__2; //Field offset: 0x40
		private IEnumerator <>7__wrap2; //Field offset: 0x50
		private IEnumerator <>7__wrap3; //Field offset: 0x58

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <InvokeCoroutine>d__55(int <>1__state) { }

		private void <>m__Finally1() { }

		private void <>m__Finally2() { }

		private void <>m__Finally3() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<Object> System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <InvokeCoroutineDelegate>d__59 : IEnumerable<Object>, IEnumerable, IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private ControlInput input; //Field offset: 0x28
		public ControlInput <>3__input; //Field offset: 0x30
		public Flow <>4__this; //Field offset: 0x38
		private IEnumerator <instructions>5__2; //Field offset: 0x40

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <InvokeCoroutineDelegate>d__59(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<Object> System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private struct RecursionNode : IEquatable<RecursionNode>
	{
		[CompilerGenerated]
		private readonly IUnitPort <port>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		private readonly IGraphParent <context>k__BackingField; //Field offset: 0x8

		public IGraphParent context
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 5
		}

		public IUnitPort port
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 4
		}

		public RecursionNode(IUnitPort port, GraphPointer pointer) { }

		public override bool Equals(RecursionNode other) { }

		public virtual bool Equals(object obj) { }

		[CompilerGenerated]
		[IsReadOnly]
		public IGraphParent get_context() { }

		[CompilerGenerated]
		[IsReadOnly]
		public IUnitPort get_port() { }

		public virtual int GetHashCode() { }

	}

	[CompilerGenerated]
	private static Func<GraphPointer, Boolean> <isInspectedBinding>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private GraphStack <stack>k__BackingField; //Field offset: 0x10
	private Recursion<RecursionNode> recursion; //Field offset: 0x18
	private readonly Dictionary<IUnitValuePort, Object> locals; //Field offset: 0x20
	public readonly VariableDeclarations variables; //Field offset: 0x28
	private readonly Stack<Int32> loops; //Field offset: 0x30
	private readonly HashSet<GraphStack> preservedStacks; //Field offset: 0x38
	[CompilerGenerated]
	private MonoBehaviour <coroutineRunner>k__BackingField; //Field offset: 0x40
	private ICollection<Flow> activeCoroutinesRegistry; //Field offset: 0x48
	private bool coroutineStopRequested; //Field offset: 0x50
	[CompilerGenerated]
	private bool <isCoroutine>k__BackingField; //Field offset: 0x51
	private IEnumerator coroutineEnumerator; //Field offset: 0x58
	[CompilerGenerated]
	private bool <isPrediction>k__BackingField; //Field offset: 0x60
	private bool disposed; //Field offset: 0x61
	public int loopIdentifier; //Field offset: 0x64

	public private MonoBehaviour coroutineRunner
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public int currentLoop
	{
		 get { } //Length: 100
	}

	public bool enableDebug
	{
		 get { } //Length: 49
	}

	public private bool isCoroutine
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public bool isInspected
	{
		 get { } //Length: 91
	}

	public static Func<GraphPointer, Boolean> isInspectedBinding
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		 set { } //Length: 81
	}

	public private bool isPrediction
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private GraphStack stack
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	private Flow() { }

	private void AfterInvoke(ControlOutput output, RecursionNode recursionNode) { }

	private RecursionNode BeforeInvoke(ControlOutput output, RecursionNode recursionNode) { }

	public void BreakLoop() { }

	private bool CanPredict(ValueOutput output) { }

	private bool CanPredict(ValueInput input) { }

	public static bool CanPredict(IUnitValuePort port, GraphReference reference) { }

	private bool CanPredictDelegate(ValueOutput output) { }

	[IteratorStateMachine(typeof(<Coroutine>d__53))]
	private IEnumerator Coroutine(ControlOutput startPort) { }

	public override void Dispose() { }

	public void DisposePreservedStack(GraphStack stack) { }

	public int EnterLoop() { }

	public void ExitLoop(int loop) { }

	public static T FetchValue(ValueInput input, GraphReference reference) { }

	public static object FetchValue(ValueInput input, Type type, GraphReference reference) { }

	public static object FetchValue(ValueInput input, GraphReference reference) { }

	[CompilerGenerated]
	public MonoBehaviour get_coroutineRunner() { }

	public int get_currentLoop() { }

	public bool get_enableDebug() { }

	[CompilerGenerated]
	public bool get_isCoroutine() { }

	public bool get_isInspected() { }

	[CompilerGenerated]
	public static Func<GraphPointer, Boolean> get_isInspectedBinding() { }

	[CompilerGenerated]
	public bool get_isPrediction() { }

	[CompilerGenerated]
	public GraphStack get_stack() { }

	public object GetConvertedValue(ValueInput input) { }

	private object GetDefaultValue(ValueInput input) { }

	private object GetValue(ValueOutput output) { }

	public T GetValue(ValueInput input) { }

	public object GetValue(ValueInput input, Type type) { }

	public object GetValue(ValueInput input) { }

	private object GetValueDelegate(ValueOutput output) { }

	public void Invoke(ControlOutput output) { }

	[IteratorStateMachine(typeof(<InvokeCoroutine>d__55))]
	private IEnumerable InvokeCoroutine(ControlOutput output) { }

	[IteratorStateMachine(typeof(<InvokeCoroutineDelegate>d__59))]
	private IEnumerable InvokeCoroutineDelegate(ControlInput input) { }

	private ControlOutput InvokeDelegate(ControlInput input) { }

	public bool IsLocal(IUnitValuePort port) { }

	public bool LoopIsNotBroken(int loop) { }

	public static Flow New(GraphReference reference) { }

	public static object Predict(IUnitValuePort port, GraphReference reference) { }

	public static T Predict(IUnitValuePort port, GraphReference pointer) { }

	public static object Predict(IUnitValuePort port, GraphReference reference, Type type) { }

	public GraphStack PreserveStack() { }

	public void RestoreStack(GraphStack stack) { }

	public void Run(ControlOutput port) { }

	[CompilerGenerated]
	private void set_coroutineRunner(MonoBehaviour value) { }

	[CompilerGenerated]
	private void set_isCoroutine(bool value) { }

	[CompilerGenerated]
	public static void set_isInspectedBinding(Func<GraphPointer, Boolean> value) { }

	[CompilerGenerated]
	private void set_isPrediction(bool value) { }

	[CompilerGenerated]
	private void set_stack(GraphStack value) { }

	public void SetValue(IUnitValuePort port, object value) { }

	public void StartCoroutine(ControlOutput port, ICollection<Flow> registry = null) { }

	public void StopCoroutine(bool disposeInstantly) { }

	internal void StopCoroutineImmediate() { }

	public bool TryGetDefaultValue(ValueInput input, out object defaultValue) { }

	private override void Unity.VisualScripting.IPoolable.Free() { }

	private override void Unity.VisualScripting.IPoolable.New() { }

}

