namespace System.Diagnostics;

[TypeConverter(typeof(ExpandableObjectConverter))]
public sealed class ProcessStartInfo
{
	private static readonly String[] empty; //Field offset: 0x0
	private string fileName; //Field offset: 0x10
	private string arguments; //Field offset: 0x18
	private string directory; //Field offset: 0x20
	private string verb; //Field offset: 0x28
	private ProcessWindowStyle windowStyle; //Field offset: 0x30
	private bool errorDialog; //Field offset: 0x34
	private IntPtr errorDialogParentHandle; //Field offset: 0x38
	private bool useShellExecute; //Field offset: 0x40
	private string userName; //Field offset: 0x48
	private string domain; //Field offset: 0x50
	private SecureString password; //Field offset: 0x58
	private string passwordInClearText; //Field offset: 0x60
	private bool loadUserProfile; //Field offset: 0x68
	private bool redirectStandardInput; //Field offset: 0x69
	private bool redirectStandardOutput; //Field offset: 0x6A
	private bool redirectStandardError; //Field offset: 0x6B
	private Encoding standardOutputEncoding; //Field offset: 0x70
	private Encoding standardErrorEncoding; //Field offset: 0x78
	private bool createNoWindow; //Field offset: 0x80
	private WeakReference weakParentProcess; //Field offset: 0x88
	internal StringDictionary environmentVariables; //Field offset: 0x90
	private Collection<String> _argumentList; //Field offset: 0x98
	private IDictionary<String, String> environment; //Field offset: 0xA0
	[CompilerGenerated]
	private Encoding <StandardInputEncoding>k__BackingField; //Field offset: 0xA8

	public Collection<String> ArgumentList
	{
		 get { } //Length: 134
	}

	[DefaultValue(null)]
	[MonitoringDescription("Command line arguments that will be passed to the application specified by the FileName property.")]
	[NotifyParentProperty(True)]
	[SettingsBindable(True)]
	[TypeConverter("System.Diagnostics.Design.StringValueConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public string Arguments
	{
		 get { } //Length: 30
		 set { } //Length: 13
	}

	[NotifyParentProperty(True)]
	public string Domain
	{
		 get { } //Length: 30
	}

	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility::Content (2))]
	[Editor("System.Diagnostics.Design.StringDictionaryEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[MonitoringDescription("Set of environment variables that apply to this process and child processes.")]
	[NotifyParentProperty(True)]
	public StringDictionary EnvironmentVariables
	{
		 get { } //Length: 1100
	}

	[DefaultValue(null)]
	[Editor("System.Diagnostics.Design.StartFileNameEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[MonitoringDescription("The name of the application, document or URL to start.")]
	[NotifyParentProperty(True)]
	[SettingsBindable(True)]
	[TypeConverter("System.Diagnostics.Design.StringValueConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public string FileName
	{
		 get { } //Length: 30
	}

	internal bool HaveEnvVars
	{
		internal get { } //Length: 12
	}

	[NotifyParentProperty(True)]
	public bool LoadUserProfile
	{
		 get { } //Length: 5
	}

	public SecureString Password
	{
		 get { } //Length: 5
	}

	[DefaultValue(False)]
	[MonitoringDescription("Whether the process's error output is written to the Process instance's StandardError member.")]
	[NotifyParentProperty(True)]
	public bool RedirectStandardError
	{
		 get { } //Length: 5
	}

	[DefaultValue(False)]
	[MonitoringDescription("Whether the process command input is read from the Process instance's StandardInput member.")]
	[NotifyParentProperty(True)]
	public bool RedirectStandardInput
	{
		 get { } //Length: 5
	}

	[DefaultValue(False)]
	[MonitoringDescription("Whether the process output is written to the Process instance's StandardOutput member.")]
	[NotifyParentProperty(True)]
	public bool RedirectStandardOutput
	{
		 get { } //Length: 5
	}

	public Encoding StandardErrorEncoding
	{
		 get { } //Length: 5
	}

	public Encoding StandardInputEncoding
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public Encoding StandardOutputEncoding
	{
		 get { } //Length: 5
	}

	[NotifyParentProperty(True)]
	public string UserName
	{
		 get { } //Length: 30
	}

	[DefaultValue(True)]
	[MonitoringDescription("Whether to use the operating system shell to start the process.")]
	[NotifyParentProperty(True)]
	public bool UseShellExecute
	{
		 get { } //Length: 5
	}

	[DefaultValue(null)]
	[Editor("System.Diagnostics.Design.WorkingDirectoryEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[MonitoringDescription("The initial working directory for the process.")]
	[NotifyParentProperty(True)]
	[SettingsBindable(True)]
	[TypeConverter("System.Diagnostics.Design.StringValueConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public string WorkingDirectory
	{
		 get { } //Length: 30
	}

	private static ProcessStartInfo() { }

	internal ProcessStartInfo(Process parent) { }

	public ProcessStartInfo(string fileName) { }

	public Collection<String> get_ArgumentList() { }

	public string get_Arguments() { }

	public string get_Domain() { }

	public StringDictionary get_EnvironmentVariables() { }

	public string get_FileName() { }

	internal bool get_HaveEnvVars() { }

	public bool get_LoadUserProfile() { }

	public SecureString get_Password() { }

	public bool get_RedirectStandardError() { }

	public bool get_RedirectStandardInput() { }

	public bool get_RedirectStandardOutput() { }

	public Encoding get_StandardErrorEncoding() { }

	[CompilerGenerated]
	public Encoding get_StandardInputEncoding() { }

	public Encoding get_StandardOutputEncoding() { }

	public string get_UserName() { }

	public bool get_UseShellExecute() { }

	public string get_WorkingDirectory() { }

	public void set_Arguments(string value) { }

}

