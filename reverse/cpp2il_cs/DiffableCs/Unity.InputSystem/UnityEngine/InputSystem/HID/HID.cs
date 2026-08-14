namespace UnityEngine.InputSystem.HID;

public class HID : InputDevice
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public HIDLayoutBuilder layout; //Field offset: 0x10

		public <>c__DisplayClass13_0() { }

		internal InputControlLayout <OnFindLayoutForDevice>b__0() { }

	}

	internal enum Button
	{
		Undefined = 0,
		Primary = 1,
		Secondary = 2,
		Tertiary = 3,
	}

	internal enum GenericDesktop
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
		SystemDisplayLCDAutoScale = 183,
	}

	internal struct HIDCollectionDescriptor
	{
		public HIDCollectionType type; //Field offset: 0x0
		public int usage; //Field offset: 0x4
		public UsagePage usagePage; //Field offset: 0x8
		public int parent; //Field offset: 0xC
		public int childCount; //Field offset: 0x10
		public int firstChild; //Field offset: 0x14

	}

	internal enum HIDCollectionType
	{
		Physical = 0,
		Application = 1,
		Logical = 2,
		Report = 3,
		NamedArray = 4,
		UsageSwitch = 5,
		UsageModifier = 6,
	}

	internal struct HIDDeviceDescriptor
	{
		public int vendorId; //Field offset: 0x0
		public int productId; //Field offset: 0x4
		public int usage; //Field offset: 0x8
		public UsagePage usagePage; //Field offset: 0xC
		public int inputReportSize; //Field offset: 0x10
		public int outputReportSize; //Field offset: 0x14
		public int featureReportSize; //Field offset: 0x18
		public HIDElementDescriptor[] elements; //Field offset: 0x20
		public HIDCollectionDescriptor[] collections; //Field offset: 0x28

		public static HIDDeviceDescriptor FromJson(string json) { }

		public string ToJson() { }

	}

	internal struct HIDDeviceDescriptorBuilder
	{
		public UsagePage usagePage; //Field offset: 0x0
		public int usage; //Field offset: 0x4
		private int m_CurrentReportId; //Field offset: 0x8
		private HIDReportType m_CurrentReportType; //Field offset: 0xC
		private int m_CurrentReportOffsetInBits; //Field offset: 0x10
		private List<HIDElementDescriptor> m_Elements; //Field offset: 0x18
		private List<HIDCollectionDescriptor> m_Collections; //Field offset: 0x20
		private int m_InputReportSize; //Field offset: 0x28
		private int m_OutputReportSize; //Field offset: 0x2C
		private int m_FeatureReportSize; //Field offset: 0x30

		public HIDDeviceDescriptorBuilder(UsagePage usagePage, int usage) { }

		public HIDDeviceDescriptorBuilder(GenericDesktop usage) { }

		public HIDDeviceDescriptorBuilder AddElement(UsagePage usagePage, int usage, int sizeInBits) { }

		public HIDDeviceDescriptorBuilder AddElement(GenericDesktop usage, int sizeInBits) { }

		public HIDDeviceDescriptor Finish() { }

		public HIDDeviceDescriptorBuilder StartReport(HIDReportType reportType, int reportId = 1) { }

		public HIDDeviceDescriptorBuilder WithLogicalMinMax(int min, int max) { }

		public HIDDeviceDescriptorBuilder WithPhysicalMinMax(int min, int max) { }

	}

	internal struct HIDElementDescriptor
	{
		public int usage; //Field offset: 0x0
		public UsagePage usagePage; //Field offset: 0x4
		public int unit; //Field offset: 0x8
		public int unitExponent; //Field offset: 0xC
		public int logicalMin; //Field offset: 0x10
		public int logicalMax; //Field offset: 0x14
		public int physicalMin; //Field offset: 0x18
		public int physicalMax; //Field offset: 0x1C
		public HIDReportType reportType; //Field offset: 0x20
		public int collectionIndex; //Field offset: 0x24
		public int reportId; //Field offset: 0x28
		public int reportSizeInBits; //Field offset: 0x2C
		public int reportOffsetInBits; //Field offset: 0x30
		public HIDElementFlags flags; //Field offset: 0x34
		public Nullable<Int32> usageMin; //Field offset: 0x38
		public Nullable<Int32> usageMax; //Field offset: 0x40

		public bool hasNullState
		{
			 get { } //Length: 9
		}

		public bool hasPreferredState
		{
			 get { } //Length: 11
		}

		public bool isArray
		{
			 get { } //Length: 10
		}

		public bool isConstant
		{
			 get { } //Length: 7
		}

		public bool isNonLinear
		{
			 get { } //Length: 9
		}

		public bool isRelative
		{
			 get { } //Length: 9
		}

		internal bool isSigned
		{
			internal get { } //Length: 7
		}

		public bool isWrapping
		{
			 get { } //Length: 9
		}

		internal float maxFloatValue
		{
			internal get { } //Length: 211
		}

		internal float minFloatValue
		{
			internal get { } //Length: 211
		}

		internal void AddChildControls(ref HIDElementDescriptor element, string controlName, ref Builder builder) { }

		private string DetermineAxisNormalizationParameters() { }

		internal PrimitiveValue DetermineDefaultState() { }

		internal string DetermineDisplayName() { }

		internal FourCC DetermineFormat() { }

		internal string DetermineLayout() { }

		internal string DetermineName() { }

		internal string DetermineParameters() { }

		internal string DetermineProcessors() { }

		internal InternedString[] DetermineUsages() { }

		public bool get_hasNullState() { }

		public bool get_hasPreferredState() { }

		public bool get_isArray() { }

		public bool get_isConstant() { }

		public bool get_isNonLinear() { }

		public bool get_isRelative() { }

		internal bool get_isSigned() { }

		public bool get_isWrapping() { }

		internal float get_maxFloatValue() { }

		internal float get_minFloatValue() { }

		public bool Is(UsagePage usagePage, int usage) { }

		internal bool IsUsableElement() { }

	}

	[Flags]
	internal enum HIDElementFlags
	{
		Constant = 1,
		Variable = 2,
		Relative = 4,
		Wrap = 8,
		NonLinear = 16,
		NoPreferred = 32,
		NullState = 64,
		Volatile = 128,
		BufferedBytes = 256,
	}

	private class HIDLayoutBuilder
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Predicate<HIDElementDescriptor> <>9__4_0; //Field offset: 0x8
			public static Predicate<HIDElementDescriptor> <>9__4_1; //Field offset: 0x10
			public static Func<ControlItem, String> <>9__4_2; //Field offset: 0x18

			private static <>c() { }

			public <>c() { }

			internal bool <Build>b__4_0(HIDElementDescriptor element) { }

			internal bool <Build>b__4_1(HIDElementDescriptor element) { }

			internal string <Build>b__4_2(ControlItem x) { }

		}

		public string displayName; //Field offset: 0x10
		public HIDDeviceDescriptor hidDescriptor; //Field offset: 0x18
		public string parentLayout; //Field offset: 0x48
		public Type deviceType; //Field offset: 0x50

		public HIDLayoutBuilder() { }

		public InputControlLayout Build() { }

	}

	internal enum HIDReportType
	{
		Unknown = 0,
		Input = 1,
		Output = 2,
		Feature = 3,
	}

	internal enum Simulation
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
		RearBrake = 208,
	}

	internal enum UsagePage
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
		VendorDefined = 65280,
	}

	internal const string kHIDInterface = "HID"; //Field offset: 0x0
	internal const string kHIDNamespace = "HID"; //Field offset: 0x0
	private static readonly ProfilerMarker k_HIDParseDescriptorFallback; //Field offset: 0x0
	private bool m_HaveParsedHIDDescriptor; //Field offset: 0x190
	private HIDDeviceDescriptor m_HIDDescriptor; //Field offset: 0x198

	public HIDDeviceDescriptor hidDescriptor
	{
		 get { } //Length: 298
	}

	public static FourCC QueryHIDParsedReportDescriptorDeviceCommandType
	{
		 get { } //Length: 58
	}

	public static FourCC QueryHIDReportDescriptorDeviceCommandType
	{
		 get { } //Length: 58
	}

	public static FourCC QueryHIDReportDescriptorSizeDeviceCommandType
	{
		 get { } //Length: 58
	}

	private static HID() { }

	public HID() { }

	public HIDDeviceDescriptor get_hidDescriptor() { }

	public static FourCC get_QueryHIDParsedReportDescriptorDeviceCommandType() { }

	public static FourCC get_QueryHIDReportDescriptorDeviceCommandType() { }

	public static FourCC get_QueryHIDReportDescriptorSizeDeviceCommandType() { }

	internal static string OnFindLayoutForDevice(ref InputDeviceDescription description, string matchedLayout, InputDeviceExecuteCommandDelegate executeDeviceCommand) { }

	internal static HIDDeviceDescriptor ReadHIDDeviceDescriptor(ref InputDeviceDescription deviceDescription, InputDeviceExecuteCommandDelegate executeCommandDelegate) { }

	public static string UsagePageToString(UsagePage usagePage) { }

	public static string UsageToString(UsagePage usagePage, int usage) { }

}

