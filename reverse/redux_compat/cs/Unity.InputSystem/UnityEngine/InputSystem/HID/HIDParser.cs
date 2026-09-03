/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.HID
{
	internal static class HIDParser // TypeDefIndex: 6351
	{
		// Nested types
		private struct HIDReportData // TypeDefIndex: 6352
		{
			// Fields
			public int reportId; // 0x00
			public HID.HIDReportType reportType; // 0x04
			public int currentBitOffset; // 0x08
	
			// Methods
			public static int FindOrAddReport(int? reportId, HID.HIDReportType reportType, List<HIDReportData> reports); // 0x0000000181DC9D50-0x0000000181DC9EB0
		}
	
		private enum HIDItemTypeAndTag // TypeDefIndex: 6353
		{
			UsagePage = 4,
			Usage = 8,
			LogicalMinimum = 20,
			UsageMinimum = 24,
			LogicalMaximum = 36,
			UsageMaximum = 40,
			PhysicalMinimum = 52,
			DesignatorIndex = 56,
			PhysicalMaximum = 68,
			DesignatorMinimum = 72,
			UnitExponent = 84,
			DesignatorMaximum = 88,
			Unit = 100,
			ReportSize = 116,
			StringIndex = 120,
			Input = 128,
			ReportID = 132,
			StringMinimum = 136,
			Output = 144,
			ReportCount = 148,
			StringMaximum = 152,
			Collection = 160,
			Push = 164,
			Delimiter = 168,
			Feature = 176,
			Pop = 180,
			EndCollection = 192
		}
	
		private struct HIDItemStateLocal // TypeDefIndex: 6354
		{
			// Fields
			public int? usage; // 0x00
			public int? usageMinimum; // 0x08
			public int? usageMaximum; // 0x10
			public int? designatorIndex; // 0x18
			public int? designatorMinimum; // 0x20
			public int? designatorMaximum; // 0x28
			public int? stringIndex; // 0x30
			public int? stringMinimum; // 0x38
			public int? stringMaximum; // 0x40
			public List<int> usageList; // 0x48
	
			// Methods
			public static void Reset(ref HIDItemStateLocal state); // 0x0000000181DC8CE0-0x0000000181DC8D20
			public void SetUsage(int value); // 0x0000000181DC8D20-0x0000000181DC8E40
			public int GetUsage(int index); // 0x0000000181DC8C10-0x0000000181DC8CE0
		}
	
		private struct HIDItemStateGlobal // TypeDefIndex: 6355
		{
			// Fields
			public int? usagePage; // 0x00
			public int? logicalMinimum; // 0x08
			public int? logicalMaximum; // 0x10
			public int? physicalMinimum; // 0x18
			public int? physicalMaximum; // 0x20
			public int? unitExponent; // 0x28
			public int? unit; // 0x30
			public int? reportSize; // 0x38
			public int? reportCount; // 0x40
			public int? reportId; // 0x48
	
			// Methods
			public HID.UsagePage GetUsagePage(int index, ref HIDItemStateLocal localItemState); // 0x0000000181DC8BE0-0x0000000181DC8C10
			public int GetPhysicalMin(); // 0x0000000181DC8B80-0x0000000181DC8BE0
			public int GetPhysicalMax(); // 0x0000000181DC8B20-0x0000000181DC8B80
		}
	
		// Methods
		public static bool ParseReportDescriptor(byte[] buffer, ref HID.HIDDeviceDescriptor deviceDescriptor); // 0x0000000181DC8E50-0x0000000181DC8EE0
		public static unsafe bool ParseReportDescriptor(byte* bufferPtr, int bufferLength, ref HID.HIDDeviceDescriptor deviceDescriptor); // 0x0000000181DC8EE0-0x0000000181DC9CF0
		private static unsafe int ReadData(int itemSize, byte* currentPtr, byte* endPtr); // 0x0000000181DC9CF0-0x0000000181DC9D50
	}
}
