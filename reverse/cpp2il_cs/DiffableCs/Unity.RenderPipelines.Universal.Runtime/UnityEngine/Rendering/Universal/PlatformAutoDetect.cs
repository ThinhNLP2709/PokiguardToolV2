namespace UnityEngine.Rendering.Universal;

internal static class PlatformAutoDetect
{
	[CompilerGenerated]
	private static bool <isXRMobile>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static bool <isShaderAPIMobileDefined>k__BackingField; //Field offset: 0x1
	[CompilerGenerated]
	private static bool <isSwitch>k__BackingField; //Field offset: 0x2
	internal static bool isRunningOnPowerVRGPU; //Field offset: 0x3

	internal static bool isShaderAPIMobileDefined
	{
		[CompilerGenerated]
		internal get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 84
	}

	internal static bool isSwitch
	{
		[CompilerGenerated]
		internal get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 84
	}

	internal static bool isXRMobile
	{
		[CompilerGenerated]
		internal get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 83
	}

	private static PlatformAutoDetect() { }

	[CompilerGenerated]
	internal static bool get_isShaderAPIMobileDefined() { }

	[CompilerGenerated]
	internal static bool get_isSwitch() { }

	[CompilerGenerated]
	internal static bool get_isXRMobile() { }

	internal static void Initialize() { }

	[CompilerGenerated]
	private static void set_isShaderAPIMobileDefined(bool value) { }

	[CompilerGenerated]
	private static void set_isSwitch(bool value) { }

	[CompilerGenerated]
	private static void set_isXRMobile(bool value) { }

	internal static ShEvalMode ShAutoDetect(ShEvalMode mode) { }

}

