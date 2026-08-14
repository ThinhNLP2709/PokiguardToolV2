namespace UnityEngine.InputSystem.Layouts;

internal struct InputDeviceBuilder : IDisposable
{
	public struct RefInstance : IDisposable
	{

		public override void Dispose() { }

	}

	private const uint kSizeForControlUsingStateFromOtherControl = 4294967295; //Field offset: 0x0
	private static InputDeviceBuilder s_Instance; //Field offset: 0x0
	private static int s_InstanceRef; //Field offset: 0x28
	private InputDevice m_Device; //Field offset: 0x0
	private CacheRefInstance m_LayoutCacheRef; //Field offset: 0x8
	private Dictionary<String, ControlItem> m_ChildControlOverrides; //Field offset: 0x10
	private List<UInt32> m_StateOffsetToControlMap; //Field offset: 0x18
	private StringBuilder m_StringBuilder; //Field offset: 0x20

	internal static InputDeviceBuilder instance
	{
		internal get { } //Length: 51
	}

	private InputControl AddChildControl(InputControlLayout layout, InternedString variants, InputControl parent, ref bool haveChildrenUsingStateFromOtherControls, ControlItem controlItem, int childIndex, string nameOverride = null) { }

	private void AddChildControlIfMissing(InputControlLayout layout, InternedString variants, InputControl parent, ref bool haveChildrenUsingStateFromOtherControls, ref ControlItem controlItem) { }

	private void AddChildControls(InputControlLayout layout, InternedString variants, InputControl parent, ref bool haveChildrenUsingStateFromOtherControls) { }

	private void AddChildren(ref ControlBitRangeNode parent, ControlBitRangeNode left, ControlBitRangeNode right) { }

	private void AddControlToNode(InputControl control, ref int controlIndiciesNextFreeIndex, int nodeIndex) { }

	private static void AddParentDisplayNameRecursive(InputControl control, StringBuilder stringBuilder, bool shortName) { }

	private static void AddProcessors(InputControl control, ref ControlItem controlItem, string layoutName) { }

	private static void ApplyUseStateFrom(InputControl parent, ref ControlItem controlItem, InputControlLayout layout) { }

	private string ChildControlOverridePath(InputControl parent, InternedString controlName) { }

	private static void ComputeStateLayout(InputControl control) { }

	public override void Dispose() { }

	private void FinalizeControlHierarchy() { }

	private void FinalizeControlHierarchyRecursive(InputControl control, int controlIndex, InputControl[] allControls, bool noisy, bool dontReset, ref int controlIndiciesNextFreeIndex) { }

	private static InputControlLayout FindOrLoadLayout(string name) { }

	public InputDevice Finish() { }

	internal static InputDeviceBuilder get_instance() { }

	private ushort GetBestMidPoint(ControlBitRangeNode parent, ushort startOffset) { }

	private ushort GetControlIndex(InputControl control) { }

	private InputControl InsertChildControl(InputControlLayout layout, InternedString variant, InputControl parent, ref bool haveChildrenUsingStateFromOtherControls, ref ControlItem controlItem) { }

	private void InsertChildControlOverride(InputControl parent, ref ControlItem controlItem) { }

	private void InsertControlBitRangeNode(ref ControlBitRangeNode parent, InputControl control, ref int controlIndiciesNextFreeIndex, ushort startOffset) { }

	private InputControl InstantiateLayout(InternedString layout, InternedString variants, InternedString name, InputControl parent) { }

	private InputControl InstantiateLayout(InputControlLayout layout, InternedString variants, InternedString name, InputControl parent) { }

	internal static RefInstance Ref() { }

	private void Reset() { }

	private void SetDisplayName(InputControl control, string longDisplayNameFromLayout, string shortDisplayNameFromLayout, bool shortName) { }

	private static void SetFormat(InputControl control, ControlItem controlItem) { }

	public void Setup(InternedString layout, InternedString variants, InputDeviceDescription deviceDescription = null) { }

	private static void ShiftChildIndicesInHierarchyOneUp(InputDevice device, int startIndex, InputControl exceptControl) { }

}

