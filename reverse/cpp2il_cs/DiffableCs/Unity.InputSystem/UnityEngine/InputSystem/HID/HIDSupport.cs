namespace UnityEngine.InputSystem.HID;

public static class HIDSupport
{
	internal struct HIDPageUsage
	{
		public UsagePage page; //Field offset: 0x0
		public int usage; //Field offset: 0x4

		public HIDPageUsage(UsagePage page, int usage) { }

		public HIDPageUsage(GenericDesktop usage) { }

	}

	private static HIDPageUsage[] s_SupportedHIDUsages; //Field offset: 0x0

	public static ReadOnlyArray<HIDPageUsage> supportedHIDUsages
	{
		 get { } //Length: 100
		 set { } //Length: 651
	}

	public static ReadOnlyArray<HIDPageUsage> get_supportedHIDUsages() { }

	internal static void Initialize() { }

	public static void set_supportedHIDUsages(ReadOnlyArray<HIDPageUsage> value) { }

}

