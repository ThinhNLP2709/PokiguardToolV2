namespace UnityEngine.UIElements;

[UxmlObject]
public class DataBinding : Binding, IDataSourceProvider
{
	private static MethodInfo s_UpdateUIMethodInfo; //Field offset: 0x0
	private BindingMode m_BindingMode; //Field offset: 0x20
	private ConverterGroup m_SourceToUiConverters; //Field offset: 0x28
	private ConverterGroup m_UiToSourceConverters; //Field offset: 0x30
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private object <dataSource>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Type <dataSourceType>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private PropertyPath <dataSourcePath>k__BackingField; //Field offset: 0x48

	[CreateProperty]
	public BindingMode bindingMode
	{
		 get { } //Length: 4
		 set { } //Length: 13
	}

	[CreateProperty]
	public override object dataSource
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[CreateProperty]
	public override PropertyPath dataSourcePath
	{
		[CompilerGenerated]
		 get { } //Length: 93
		[CompilerGenerated]
		 set { } //Length: 100
	}

	public Type dataSourceType
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[CreateProperty(ReadOnly = True)]
	public ConverterGroup sourceToUiConverters
	{
		 get { } //Length: 149
	}

	[CreateProperty(ReadOnly = True)]
	public ConverterGroup uiToSourceConverters
	{
		 get { } //Length: 149
	}

	internal static MethodInfo updateUIMethod
	{
		internal get { } //Length: 527
	}

	public void ApplyConverterGroupToSource(ConverterGroup group) { }

	public void ApplyConverterGroupToUI(ConverterGroup group) { }

	private static MethodInfo CacheReflectionInfo() { }

	public BindingMode get_bindingMode() { }

	[CompilerGenerated]
	public override object get_dataSource() { }

	[CompilerGenerated]
	public override PropertyPath get_dataSourcePath() { }

	[CompilerGenerated]
	public Type get_dataSourceType() { }

	public ConverterGroup get_sourceToUiConverters() { }

	public ConverterGroup get_uiToSourceConverters() { }

	internal static MethodInfo get_updateUIMethod() { }

	internal static string GetSetValueErrorString(VisitReturnCode returnCode, object source, in PropertyPath sourcePath, object target, in BindingId targetPath, TValue extractedValueFromSource) { }

	public void set_bindingMode(BindingMode value) { }

	[CompilerGenerated]
	public void set_dataSource(object value) { }

	[CompilerGenerated]
	public void set_dataSourcePath(PropertyPath value) { }

	[CompilerGenerated]
	public void set_dataSourceType(Type value) { }

	protected private override BindingResult UpdateSource(in BindingContext context, ref TValue value) { }

	protected private override BindingResult UpdateUI(in BindingContext context, ref TValue value) { }

}

