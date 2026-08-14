namespace Unity.VisualScripting;

[IncludeInSettings(False)]
public sealed class VariablesAsset : LudiqScriptableObject
{
	[CompilerGenerated]
	private VariableDeclarations <declarations>k__BackingField; //Field offset: 0x30

	[Inspectable]
	[InspectorWide(True)]
	[Serialize]
	public internal VariableDeclarations declarations
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	public VariablesAsset() { }

	[CompilerGenerated]
	public VariableDeclarations get_declarations() { }

	[CompilerGenerated]
	internal void set_declarations(VariableDeclarations value) { }

	[ContextMenu("Show Data...")]
	protected virtual void ShowData() { }

}

