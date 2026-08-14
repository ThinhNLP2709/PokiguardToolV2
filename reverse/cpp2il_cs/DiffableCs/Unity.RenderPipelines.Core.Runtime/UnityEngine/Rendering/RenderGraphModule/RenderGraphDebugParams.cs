namespace UnityEngine.Rendering.RenderGraphModule;

internal class RenderGraphDebugParams : IDebugDisplaySettingsQuery
{
	private static class Strings
	{
		public static readonly NameAndTooltip ClearRenderTargetsAtCreation; //Field offset: 0x0
		public static readonly NameAndTooltip ClearRenderTargetsAtFree; //Field offset: 0x10
		public static readonly NameAndTooltip DisablePassCulling; //Field offset: 0x20
		public static readonly NameAndTooltip ImmediateMode; //Field offset: 0x30
		public static readonly NameAndTooltip EnableLogging; //Field offset: 0x40
		public static readonly NameAndTooltip LogFrameInformation; //Field offset: 0x50
		public static readonly NameAndTooltip LogResources; //Field offset: 0x60
		public static readonly NameAndTooltip EnableNativeCompiler; //Field offset: 0x70

		private static Strings() { }

	}

	private Widget[] m_DebugItems; //Field offset: 0x10
	private Panel m_DebugPanel; //Field offset: 0x18
	public bool clearRenderTargetsAtCreation; //Field offset: 0x20
	public bool clearRenderTargetsAtRelease; //Field offset: 0x21
	public bool disablePassCulling; //Field offset: 0x22
	public bool immediateMode; //Field offset: 0x23
	public bool enableLogging; //Field offset: 0x24
	public bool logFrameInformation; //Field offset: 0x25
	public bool logResources; //Field offset: 0x26

	public override bool AreAnySettingsActive
	{
		 get { } //Length: 32
	}

	public RenderGraphDebugParams() { }

	[CompilerGenerated]
	private bool <GetWidgetList>b__11_0() { }

	[CompilerGenerated]
	private void <GetWidgetList>b__11_1(bool value) { }

	[CompilerGenerated]
	private void <GetWidgetList>b__11_10(bool value) { }

	[CompilerGenerated]
	private void <GetWidgetList>b__11_11() { }

	[CompilerGenerated]
	private void <GetWidgetList>b__11_12() { }

	[CompilerGenerated]
	private bool <GetWidgetList>b__11_2() { }

	[CompilerGenerated]
	private void <GetWidgetList>b__11_3(bool value) { }

	[CompilerGenerated]
	private bool <GetWidgetList>b__11_4() { }

	[CompilerGenerated]
	private void <GetWidgetList>b__11_5(bool value) { }

	[CompilerGenerated]
	private bool <GetWidgetList>b__11_6() { }

	[CompilerGenerated]
	private void <GetWidgetList>b__11_7(bool value) { }

	[CompilerGenerated]
	private bool <GetWidgetList>b__11_8() { }

	[CompilerGenerated]
	private bool <GetWidgetList>b__11_9() { }

	public override bool get_AreAnySettingsActive() { }

	internal List<Widget> GetWidgetList(string name) { }

	private bool IsImmediateModeSupported() { }

	public void RegisterDebug(string name, Panel debugPanel = null) { }

	internal void Reset() { }

	public void UnRegisterDebug(string name) { }

}

