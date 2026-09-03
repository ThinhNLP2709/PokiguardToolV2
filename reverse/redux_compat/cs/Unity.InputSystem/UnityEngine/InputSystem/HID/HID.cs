/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.HID
{
	public class HID : InputDevice // TypeDefIndex: 6336
	{
		// Fields
		internal const string kHIDInterface = "HID"; // Metadata: 0x00698E46
		internal const string kHIDNamespace = "HID"; // Metadata: 0x00698E4A
		private bool m_HaveParsedHIDDescriptor; // 0x190
		private HIDDeviceDescriptor m_HIDDescriptor; // 0x198
		private static readonly ProfilerMarker k_HIDParseDescriptorFallback; // 0x00
	
		// Properties
		public static FourCC QueryHIDReportDescriptorDeviceCommandType { get; } // 0x0000000181DACCB0-0x0000000181DACCF0 
		public static FourCC QueryHIDReportDescriptorSizeDeviceCommandType { get; } // 0x0000000181DACCF0-0x0000000181DACD30 
		public static FourCC QueryHIDParsedReportDescriptorDeviceCommandType { get; } // 0x0000000181DACC70-0x0000000181DACCB0 
		public HIDDeviceDescriptor hidDescriptor { get; } // 0x0000000181DACD30-0x0000000181DACE60 
	
		// Nested types
		[Serializable]
		private class HIDLayoutBuilder // TypeDefIndex: 6337
		{
			// Fields
			public string displayName; // 0x10
			public HIDDeviceDescriptor hidDescriptor; // 0x18
			public string parentLayout; // 0x48
			public Type deviceType; // 0x50
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 6338
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Predicate<HIDElementDescriptor> __9__4_0; // 0x08
				public static Predicate<HIDElementDescriptor> __9__4_1; // 0x10
				public static Func<InputControlLayout.ControlItem, string> __9__4_2; // 0x18
	
				// Constructors
				static __c(); // 0x0000000181DD4CD0-0x0000000181DD4D40
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _Build_b__4_0(HIDElementDescriptor element); // 0x0000000181DD4A50-0x0000000181DD4A70
				internal bool _Build_b__4_1(HIDElementDescriptor element); // 0x0000000181DD4A70-0x0000000181DD4A90
				internal string _Build_b__4_2(InputControlLayout.ControlItem x); // 0x0000000181DD4A90-0x0000000181DD4AB0
			}
	
			// Constructors
			public HIDLayoutBuilder(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public InputControlLayout Build(); // 0x0000000181DAAAB0-0x0000000181DAB970
		}
	
		public enum HIDReportType // TypeDefIndex: 6339
		{
			Unknown = 0,
			Input = 1,
			Output = 2,
			Feature = 3
		}
	
		public enum HIDCollectionType // TypeDefIndex: 6340
		{
			Physical = 0,
			Application = 1,
			Logical = 2,
			Report = 3,
			NamedArray = 4,
			UsageSwitch = 5,
			UsageModifier = 6
		}
	
		[Flags]
		public enum HIDElementFlags // TypeDefIndex: 6341
		{
			Constant = 1,
			Variable = 2,
			Relative = 4,
			Wrap = 8,
			NonLinear = 16,
			NoPreferred = 32,
			NullState = 64,
			Volatile = 128,
			BufferedBytes = 256
		}
	
		[Serializable]
		public struct HIDElementDescriptor // TypeDefIndex: 6342
		{
			// Fields
			public int usage; // 0x00
			public UsagePage usagePage; // 0x04
			public int unit; // 0x08
			public int unitExponent; // 0x0C
			public int logicalMin; // 0x10
			public int logicalMax; // 0x14
			public int physicalMin; // 0x18
			public int physicalMax; // 0x1C
			public HIDReportType reportType; // 0x20
			public int collectionIndex; // 0x24
			public int reportId; // 0x28
			public int reportSizeInBits; // 0x2C
			public int reportOffsetInBits; // 0x30
			public HIDElementFlags flags; // 0x34
			public int? usageMin; // 0x38
			public int? usageMax; // 0x40
	
			// Properties
			public bool hasNullState { get; } // 0x0000000181DC88E0-0x0000000181DC88F0 
			public bool hasPreferredState { get; } // 0x0000000181DC88F0-0x0000000181DC8900 
			public bool isArray { get; } // 0x0000000181DC8900-0x0000000181DC8910 
			public bool isNonLinear { get; } // 0x0000000181DC8920-0x0000000181DC8930 
			public bool isRelative { get; } // 0x0000000181DC8930-0x0000000181DC8940 
			public bool isConstant { get; } // 0x0000000181DC8910-0x0000000181DC8920 
			public bool isWrapping { get; } // 0x0000000181DC8950-0x0000000181DC8960 
			internal bool isSigned { get; } // 0x0000000181DC8940-0x0000000181DC8950 
			internal float minFloatValue { get; } // 0x0000000181DC8A40-0x0000000181DC8B20 
			internal float maxFloatValue { get; } // 0x0000000181DC8960-0x0000000181DC8A40 
	
			// Methods
			public bool Is(UsagePage usagePage, int usage); // 0x0000000181DC88D0-0x0000000181DC88E0
			internal string DetermineName(); // 0x0000000181DC8230-0x0000000181DC8410
			internal string DetermineDisplayName(); // 0x0000000181DC7F00-0x0000000181DC7FC0
			internal bool IsUsableElement(); // 0x0000000181DC87A0-0x0000000181DC88D0
			internal string DetermineLayout(); // 0x0000000181DC8140-0x0000000181DC8230
			internal FourCC DetermineFormat(); // 0x0000000181DC7FC0-0x0000000181DC8140
			internal InternedString[] DetermineUsages(); // 0x0000000181DC85B0-0x0000000181DC87A0
			internal string DetermineParameters(); // 0x0000000181DC8410-0x0000000181DC8550
			private string DetermineAxisNormalizationParameters(); // 0x0000000181DC7AD0-0x0000000181DC7E10
			internal string DetermineProcessors(); // 0x0000000181DC8550-0x0000000181DC85B0
			internal PrimitiveValue DetermineDefaultState(); // 0x0000000181DC7E10-0x0000000181DC7F00
			internal void AddChildControls(ref HIDElementDescriptor element, string controlName, ref InputControlLayout.Builder builder); // 0x0000000181DC72E0-0x0000000181DC7AD0
		}
	
		[Serializable]
		public struct HIDCollectionDescriptor // TypeDefIndex: 6343
		{
			// Fields
			public HIDCollectionType type; // 0x00
			public int usage; // 0x04
			public UsagePage usagePage; // 0x08
			public int parent; // 0x0C
			public int childCount; // 0x10
			public int firstChild; // 0x14
		}
	
		[Serializable]
		public struct HIDDeviceDescriptor // TypeDefIndex: 6344
		{
			// Fields
			public int vendorId; // 0x00
			public int productId; // 0x04
			public int usage; // 0x08
			public UsagePage usagePage; // 0x0C
			public int inputReportSize; // 0x10
			public int outputReportSize; // 0x14
			public int featureReportSize; // 0x18
			public HIDElementDescriptor[] elements; // 0x20
			public HIDCollectionDescriptor[] collections; // 0x28
	
			// Methods
			public string ToJson(); // 0x0000000181DC7270-0x0000000181DC72E0
			public static HIDDeviceDescriptor FromJson(string json); // 0x0000000181DC61D0-0x0000000181DC7270
		}
	
		public struct HIDDeviceDescriptorBuilder // TypeDefIndex: 6345
		{
			// Fields
			public UsagePage usagePage; // 0x00
			public int usage; // 0x04
			private int m_CurrentReportId; // 0x08
			private HIDReportType m_CurrentReportType; // 0x0C
			private int m_CurrentReportOffsetInBits; // 0x10
			private List<HIDElementDescriptor> m_Elements; // 0x18
			private List<HIDCollectionDescriptor> m_Collections; // 0x20
			private int m_InputReportSize; // 0x28
			private int m_OutputReportSize; // 0x2C
			private int m_FeatureReportSize; // 0x30
	
			// Constructors
			public HIDDeviceDescriptorBuilder(UsagePage usagePage, int usage); // 0x0000000181DC61A0-0x0000000181DC61D0
			public HIDDeviceDescriptorBuilder(GenericDesktop usage); // 0x0000000181DC6170-0x0000000181DC61A0
	
			// Methods
			public HIDDeviceDescriptorBuilder StartReport(HIDReportType reportType, int reportId = 1 /* Metadata: 0x00698E65 */); // 0x0000000181DC5E90-0x0000000181DC5ED0
			public HIDDeviceDescriptorBuilder AddElement(UsagePage usagePage, int usage, int sizeInBits); // 0x0000000181DC59F0-0x0000000181DC5D70
			public HIDDeviceDescriptorBuilder AddElement(GenericDesktop usage, int sizeInBits); // 0x0000000181DC5D70-0x0000000181DC5DD0
			public HIDDeviceDescriptorBuilder WithPhysicalMinMax(int min, int max); // 0x0000000181DC6020-0x0000000181DC6170
			public HIDDeviceDescriptorBuilder WithLogicalMinMax(int min, int max); // 0x0000000181DC5ED0-0x0000000181DC6020
			public HIDDeviceDescriptor Finish(); // 0x0000000181DC5DD0-0x0000000181DC5E90
		}
	
		public enum UsagePage // TypeDefIndex: 6346
		{
			Undefined = 0,
			GenericDesktop = 1,
			Simulation = 2,
			VRControls = 3,
			SportControls = 4,
			GameControls = 5,
			GenericDeviceControls = 6,
			Keyboard = 7,
			LEDs = 8,
			Button = 9,
			Ordinal = 10,
			Telephony = 11,
			Consumer = 12,
			Digitizer = 13,
			PID = 15,
			Unicode = 16,
			AlphanumericDisplay = 20,
			MedicalInstruments = 64,
			Monitor = 128,
			Power = 132,
			BarCodeScanner = 140,
			MagneticStripeReader = 142,
			Camera = 144,
			Arcade = 145,
			VendorDefined = 65280
		}
	
		public enum GenericDesktop // TypeDefIndex: 6347
		{
			Undefined = 0,
			Pointer = 1,
			Mouse = 2,
			Joystick = 4,
			Gamepad = 5,
			Keyboard = 6,
			Keypad = 7,
			MultiAxisController = 8,
			TabletPCControls = 9,
			AssistiveControl = 10,
			X = 48,
			Y = 49,
			Z = 50,
			Rx = 51,
			Ry = 52,
			Rz = 53,
			Slider = 54,
			Dial = 55,
			Wheel = 56,
			HatSwitch = 57,
			CountedBuffer = 58,
			ByteCount = 59,
			MotionWakeup = 60,
			Start = 61,
			Select = 62,
			Vx = 64,
			Vy = 65,
			Vz = 66,
			Vbrx = 67,
			Vbry = 68,
			Vbrz = 69,
			Vno = 70,
			FeatureNotification = 71,
			ResolutionMultiplier = 72,
			SystemControl = 128,
			SystemPowerDown = 129,
			SystemSleep = 130,
			SystemWakeUp = 131,
			SystemContextMenu = 132,
			SystemMainMenu = 133,
			SystemAppMenu = 134,
			SystemMenuHelp = 135,
			SystemMenuExit = 136,
			SystemMenuSelect = 137,
			SystemMenuRight = 138,
			SystemMenuLeft = 139,
			SystemMenuUp = 140,
			SystemMenuDown = 141,
			SystemColdRestart = 142,
			SystemWarmRestart = 143,
			DpadUp = 144,
			DpadDown = 145,
			DpadRight = 146,
			DpadLeft = 147,
			SystemDock = 160,
			SystemUndock = 161,
			SystemSetup = 162,
			SystemBreak = 163,
			SystemDebuggerBreak = 164,
			ApplicationBreak = 165,
			ApplicationDebuggerBreak = 166,
			SystemSpeakerMute = 167,
			SystemHibernate = 168,
			SystemDisplayInvert = 176,
			SystemDisplayInternal = 177,
			SystemDisplayExternal = 178,
			SystemDisplayBoth = 179,
			SystemDisplayDual = 180,
			SystemDisplayToggleIntExt = 181,
			SystemDisplaySwapPrimarySecondary = 182,
			SystemDisplayLCDAutoScale = 183
		}
	
		public enum Simulation // TypeDefIndex: 6348
		{
			Undefined = 0,
			FlightSimulationDevice = 1,
			AutomobileSimulationDevice = 2,
			TankSimulationDevice = 3,
			SpaceshipSimulationDevice = 4,
			SubmarineSimulationDevice = 5,
			SailingSimulationDevice = 6,
			MotorcycleSimulationDevice = 7,
			SportsSimulationDevice = 8,
			AirplaneSimulationDevice = 9,
			HelicopterSimulationDevice = 10,
			MagicCarpetSimulationDevice = 11,
			BicylcleSimulationDevice = 12,
			FlightControlStick = 32,
			FlightStick = 33,
			CyclicControl = 34,
			CyclicTrim = 35,
			FlightYoke = 36,
			TrackControl = 37,
			Aileron = 176,
			AileronTrim = 177,
			AntiTorqueControl = 178,
			AutopilotEnable = 179,
			ChaffRelease = 180,
			CollectiveControl = 181,
			DiveBreak = 182,
			ElectronicCountermeasures = 183,
			Elevator = 184,
			ElevatorTrim = 185,
			Rudder = 186,
			Throttle = 187,
			FlightCommunications = 188,
			FlareRelease = 189,
			LandingGear = 190,
			ToeBreak = 191,
			Trigger = 192,
			WeaponsArm = 193,
			WeaponsSelect = 194,
			WingFlaps = 195,
			Accelerator = 196,
			Brake = 197,
			Clutch = 198,
			Shifter = 199,
			Steering = 200,
			TurretDirection = 201,
			BarrelElevation = 202,
			DivePlane = 203,
			Ballast = 204,
			BicycleCrank = 205,
			HandleBars = 206,
			FrontBrake = 207,
			RearBrake = 208
		}
	
		public enum Button // TypeDefIndex: 6349
		{
			Undefined = 0,
			Primary = 1,
			Secondary = 2,
			Tertiary = 3
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass13_0 // TypeDefIndex: 6350
		{
			// Fields
			public HIDLayoutBuilder layout; // 0x10
	
			// Constructors
			public __c__DisplayClass13_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal InputControlLayout _OnFindLayoutForDevice_b__0(); // 0x0000000181DD4C40-0x0000000181DD4C60
		}
	
		// Constructors
		public HID(); // 0x0000000181CC2A30-0x0000000181CC2A40
		static HID(); // 0x0000000181DACC10-0x0000000181DACC70
	
		// Methods
		internal static string OnFindLayoutForDevice(ref InputDeviceDescription description, string matchedLayout, InputDeviceExecuteCommandDelegate executeDeviceCommand); // 0x0000000181DAB970-0x0000000181DAC310
		internal static HIDDeviceDescriptor ReadHIDDeviceDescriptor(ref InputDeviceDescription deviceDescription, InputDeviceExecuteCommandDelegate executeCommandDelegate); // 0x0000000181DAC310-0x0000000181DACAF0
		public static string UsagePageToString(UsagePage usagePage); // 0x0000000181DACAF0-0x0000000181DACB60
		public static string UsageToString(UsagePage usagePage, int usage); // 0x0000000181DACB60-0x0000000181DACC10
	}
}
