namespace UnityEngine.InputSystem.XR;

internal class XRLayoutBuilder
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public XRLayoutBuilder layout; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal InputControlLayout <OnFindLayoutForDevice>b__0() { }

	}

	private static readonly String[] poseSubControlNames; //Field offset: 0x0
	private static readonly FeatureType[] poseSubControlTypes; //Field offset: 0x8
	private string parentLayout; //Field offset: 0x10
	private string interfaceName; //Field offset: 0x18
	private XRDeviceDescriptor descriptor; //Field offset: 0x20

	private static XRLayoutBuilder() { }

	public XRLayoutBuilder() { }

	private InputControlLayout Build() { }

	private static string ConvertPotentialAliasToName(InputControlLayout layout, string nameOrAlias) { }

	private string GetParentControlName(string name) { }

	private static uint GetSizeOfFeature(XRFeatureDescriptor featureDescriptor) { }

	private bool IsPoseControl(List<XRFeatureDescriptor> features, int startIndex) { }

	private bool IsSubControl(string name) { }

	internal static string OnFindLayoutForDevice(ref InputDeviceDescription description, string matchedLayout, InputDeviceExecuteCommandDelegate executeCommandDelegate) { }

	private static string SanitizeString(string original, bool allowPaths = false) { }

}

