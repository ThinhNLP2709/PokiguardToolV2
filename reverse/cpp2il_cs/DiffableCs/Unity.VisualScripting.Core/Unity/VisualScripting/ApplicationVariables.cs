namespace Unity.VisualScripting;

public static class ApplicationVariables
{
	public const string assetPath = "ApplicationVariables"; //Field offset: 0x0
	private static VariablesAsset _asset; //Field offset: 0x0
	[CompilerGenerated]
	private static VariableDeclarations <runtime>k__BackingField; //Field offset: 0x8

	public static VariablesAsset asset
	{
		 get { } //Length: 267
	}

	public static VariableDeclarations current
	{
		 get { } //Length: 141
	}

	public static VariableDeclarations initial
	{
		 get { } //Length: 30
	}

	public private static VariableDeclarations runtime
	{
		[CompilerGenerated]
		 get { } //Length: 55
		[CompilerGenerated]
		private set { } //Length: 86
	}

	private static void CreateRuntimeDeclarations() { }

	private static void DestroyRuntimeDeclarations() { }

	public static VariablesAsset get_asset() { }

	public static VariableDeclarations get_current() { }

	public static VariableDeclarations get_initial() { }

	[CompilerGenerated]
	public static VariableDeclarations get_runtime() { }

	public static void Load() { }

	public static void OnEnterEditMode() { }

	internal static void OnEnterPlayMode() { }

	public static void OnExitEditMode() { }

	internal static void OnExitPlayMode() { }

	[CompilerGenerated]
	private static void set_runtime(VariableDeclarations value) { }

}

