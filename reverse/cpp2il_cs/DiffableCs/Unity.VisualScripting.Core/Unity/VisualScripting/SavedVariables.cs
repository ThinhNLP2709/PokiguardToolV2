namespace Unity.VisualScripting;

public static class SavedVariables
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__8_0; //Field offset: 0x8
		public static Func<VariableDeclaration, String> <>9__24_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal string <MergeInitialAndSavedDeclarations>b__24_0(VariableDeclaration vd) { }

		internal void <OnEnterPlayMode>b__8_0() { }

	}

	public const string assetPath = "SavedVariables"; //Field offset: 0x0
	public const string playerPrefsKey = "LudiqSavedVariables"; //Field offset: 0x0
	private static VariablesAsset _asset; //Field offset: 0x0
	[CompilerGenerated]
	private static VariableDeclarations <saved>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private static VariableDeclarations <merged>k__BackingField; //Field offset: 0x10

	public static VariablesAsset asset
	{
		 get { } //Length: 267
	}

	public static VariableDeclarations current
	{
		 get { } //Length: 126
	}

	public static VariableDeclarations initial
	{
		 get { } //Length: 281
	}

	public private static VariableDeclarations merged
	{
		[CompilerGenerated]
		 get { } //Length: 55
		[CompilerGenerated]
		private set { } //Length: 86
	}

	public private static VariableDeclarations saved
	{
		[CompilerGenerated]
		 get { } //Length: 55
		[CompilerGenerated]
		private set { } //Length: 86
	}

	private static void DestroyMergedDeclarations() { }

	public static void FetchSavedDeclarations() { }

	public static VariablesAsset get_asset() { }

	public static VariableDeclarations get_current() { }

	public static VariableDeclarations get_initial() { }

	[CompilerGenerated]
	public static VariableDeclarations get_merged() { }

	[CompilerGenerated]
	public static VariableDeclarations get_saved() { }

	public static void Load() { }

	private static void MergeInitialAndSavedDeclarations() { }

	public static void OnEnterEditMode() { }

	internal static void OnEnterPlayMode() { }

	public static void OnExitEditMode() { }

	internal static void OnExitPlayMode() { }

	public static void SaveDeclarations(VariableDeclarations declarations) { }

	[CompilerGenerated]
	private static void set_merged(VariableDeclarations value) { }

	[CompilerGenerated]
	private static void set_saved(VariableDeclarations value) { }

	private static void WarnAndNullifyUnityObjectReferences(VariableDeclarations declarations) { }

}

