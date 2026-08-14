namespace DG.Tweening.Core;

internal struct SafeModeReport
{
	public enum SafeModeReportType
	{
		Unset = 0,
		TargetOrFieldMissing = 1,
		Callback = 2,
		StartupFailure = 3,
	}

	[CompilerGenerated]
	private int <totMissingTargetOrFieldErrors>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private int <totCallbackErrors>k__BackingField; //Field offset: 0x4
	[CompilerGenerated]
	private int <totStartupErrors>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private int <totUnsetErrors>k__BackingField; //Field offset: 0xC

	public private int totCallbackErrors
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private int totMissingTargetOrFieldErrors
	{
		[CompilerGenerated]
		 get { } //Length: 3
		[CompilerGenerated]
		private set { } //Length: 3
	}

	public private int totStartupErrors
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private int totUnsetErrors
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public void Add(SafeModeReportType type) { }

	[CompilerGenerated]
	public int get_totCallbackErrors() { }

	[CompilerGenerated]
	public int get_totMissingTargetOrFieldErrors() { }

	[CompilerGenerated]
	public int get_totStartupErrors() { }

	[CompilerGenerated]
	public int get_totUnsetErrors() { }

	public int GetTotErrors() { }

	[CompilerGenerated]
	private void set_totCallbackErrors(int value) { }

	[CompilerGenerated]
	private void set_totMissingTargetOrFieldErrors(int value) { }

	[CompilerGenerated]
	private void set_totStartupErrors(int value) { }

	[CompilerGenerated]
	private void set_totUnsetErrors(int value) { }

}

