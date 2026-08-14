namespace Unity.VisualScripting;

[DefaultMember("Item")]
[SerializationVersion("A", new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
public sealed class VariableDeclarations : IEnumerable<VariableDeclaration>, IEnumerable, ISpecifiesCloner
{
	public VariableKind Kind; //Field offset: 0x10
	[InspectorWide(True)]
	[Serialize]
	private VariableDeclarationCollection collection; //Field offset: 0x18
	internal Action OnVariableChanged; //Field offset: 0x20

	public object Item
	{
		 get { } //Length: 8
		 set { } //Length: 291
	}

	private override ICloner Unity.VisualScripting.ISpecifiesCloner.cloner
	{
		private get { } //Length: 78
	}

	public VariableDeclarations() { }

	public void Clear() { }

	public object Get(string variable) { }

	public T Get(string variable) { }

	public object Get(string variable, Type expectedType) { }

	public object get_Item(string variable) { }

	public VariableDeclaration GetDeclaration(string variable) { }

	public override IEnumerator<VariableDeclaration> GetEnumerator() { }

	public bool IsDefined(string variable) { }

	public void Set(string variable, object value) { }

	public void set_Item(string variable, object value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	private override ICloner Unity.VisualScripting.ISpecifiesCloner.get_cloner() { }

}

