namespace UnityEngine.InputSystem.HID;

internal static class HIDParser
{
	private struct HIDItemStateGlobal
	{
		public Nullable<Int32> usagePage; //Field offset: 0x0
		public Nullable<Int32> logicalMinimum; //Field offset: 0x8
		public Nullable<Int32> logicalMaximum; //Field offset: 0x10
		public Nullable<Int32> physicalMinimum; //Field offset: 0x18
		public Nullable<Int32> physicalMaximum; //Field offset: 0x20
		public Nullable<Int32> unitExponent; //Field offset: 0x28
		public Nullable<Int32> unit; //Field offset: 0x30
		public Nullable<Int32> reportSize; //Field offset: 0x38
		public Nullable<Int32> reportCount; //Field offset: 0x40
		public Nullable<Int32> reportId; //Field offset: 0x48

		public int GetPhysicalMax() { }

		public int GetPhysicalMin() { }

		public UsagePage GetUsagePage(int index, ref HIDItemStateLocal localItemState) { }

	}

	private struct HIDItemStateLocal
	{
		public Nullable<Int32> usage; //Field offset: 0x0
		public Nullable<Int32> usageMinimum; //Field offset: 0x8
		public Nullable<Int32> usageMaximum; //Field offset: 0x10
		public Nullable<Int32> designatorIndex; //Field offset: 0x18
		public Nullable<Int32> designatorMinimum; //Field offset: 0x20
		public Nullable<Int32> designatorMaximum; //Field offset: 0x28
		public Nullable<Int32> stringIndex; //Field offset: 0x30
		public Nullable<Int32> stringMinimum; //Field offset: 0x38
		public Nullable<Int32> stringMaximum; //Field offset: 0x40
		public List<Int32> usageList; //Field offset: 0x48

		public int GetUsage(int index) { }

		public static void Reset(ref HIDItemStateLocal state) { }

		public void SetUsage(int value) { }

	}

	private enum HIDItemTypeAndTag
	{
		Input = 128,
		Output = 144,
		Feature = 176,
		Collection = 160,
		EndCollection = 192,
		UsagePage = 4,
		LogicalMinimum = 20,
		LogicalMaximum = 36,
		PhysicalMinimum = 52,
		PhysicalMaximum = 68,
		UnitExponent = 84,
		Unit = 100,
		ReportSize = 116,
		ReportID = 132,
		ReportCount = 148,
		Push = 164,
		Pop = 180,
		Usage = 8,
		UsageMinimum = 24,
		UsageMaximum = 40,
		DesignatorIndex = 56,
		DesignatorMinimum = 72,
		DesignatorMaximum = 88,
		StringIndex = 120,
		StringMinimum = 136,
		StringMaximum = 152,
		Delimiter = 168,
	}

	private struct HIDReportData
	{
		public int reportId; //Field offset: 0x0
		public HIDReportType reportType; //Field offset: 0x4
		public int currentBitOffset; //Field offset: 0x8

		public static int FindOrAddReport(Nullable<Int32> reportId, HIDReportType reportType, List<HIDReportData> reports) { }

	}


	public static bool ParseReportDescriptor(Byte[] buffer, ref HIDDeviceDescriptor deviceDescriptor) { }

	public static bool ParseReportDescriptor(Byte* bufferPtr, int bufferLength, ref HIDDeviceDescriptor deviceDescriptor) { }

	private static int ReadData(int itemSize, Byte* currentPtr, Byte* endPtr) { }

}

