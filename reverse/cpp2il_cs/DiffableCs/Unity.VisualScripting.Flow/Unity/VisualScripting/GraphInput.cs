namespace Unity.VisualScripting;

[UnitCategory("Nesting")]
[UnitOrder(1)]
[UnitTitle("Input")]
public sealed class GraphInput : Unit
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public string key; //Field offset: 0x10
		public Type type; //Field offset: 0x18

		public <>c__DisplayClass2_0() { }

		internal object <Definition>b__0(Flow flow) { }

	}


	public virtual bool canDefine
	{
		 get { } //Length: 51
	}

	public GraphInput() { }

	protected virtual void AfterDefine() { }

	protected virtual void BeforeUndefine() { }

	protected virtual void Definition() { }

	public virtual bool get_canDefine() { }

}

