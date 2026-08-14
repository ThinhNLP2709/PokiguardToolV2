namespace Unity.VisualScripting;

[AddComponentMenu("Visual Scripting/Variables")]
[DisableAnnotation]
[IncludeInSettings(False)]
public class Variables : LudiqBehaviour, IAotStubbable
{
	[CompilerGenerated]
	private sealed class <GetAotStubs>d__25 : IEnumerable<Object>, IEnumerable, IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public Variables <>4__this; //Field offset: 0x28
		private IEnumerator<VariableDeclaration> <>7__wrap1; //Field offset: 0x30

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
		public <GetAotStubs>d__25(int <>1__state) { }

		private void <>m__Finally1() { }

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
	private VariableDeclarations <declarations>k__BackingField; //Field offset: 0x30

	public static VariableDeclarations ActiveScene
	{
		 get { } //Length: 117
	}

	public static VariableDeclarations Application
	{
		 get { } //Length: 141
	}

	[Inspectable]
	[Serialize]
	public internal VariableDeclarations declarations
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	public static bool ExistInActiveScene
	{
		 get { } //Length: 273
	}

	public static VariableDeclarations Saved
	{
		 get { } //Length: 126
	}

	public Variables() { }

	public static bool ExistInScene(Nullable<Scene> scene) { }

	public static bool ExistOnObject(Component component) { }

	public static bool ExistOnObject(GameObject go) { }

	public static VariableDeclarations get_ActiveScene() { }

	public static VariableDeclarations get_Application() { }

	[CompilerGenerated]
	public VariableDeclarations get_declarations() { }

	public static bool get_ExistInActiveScene() { }

	public static VariableDeclarations get_Saved() { }

	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[IteratorStateMachine(typeof(<GetAotStubs>d__25))]
	public override IEnumerable<Object> GetAotStubs(HashSet<Object> visited) { }

	public static VariableDeclarations Graph(GraphPointer pointer) { }

	public static VariableDeclarations GraphDefinition(IGraphWithVariables graph) { }

	public static VariableDeclarations GraphDefinition(GraphPointer pointer) { }

	public static VariableDeclarations GraphInstance(GraphPointer pointer) { }

	public static VariableDeclarations Object(Component component) { }

	public static VariableDeclarations Object(GameObject go) { }

	public static VariableDeclarations Scene(Nullable<Scene> scene) { }

	public static VariableDeclarations Scene(GameObject go) { }

	public static VariableDeclarations Scene(Component component) { }

	[CompilerGenerated]
	internal void set_declarations(VariableDeclarations value) { }

	[ContextMenu("Show Data...")]
	protected virtual void ShowData() { }

}

