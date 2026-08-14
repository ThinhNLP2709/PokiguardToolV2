namespace UnityEngine.InputSystem;

public struct InputControlScheme : IEquatable<InputControlScheme>
{
	internal struct DeviceRequirement : IEquatable<DeviceRequirement>
	{
		[Flags]
		public enum Flags
		{
			None = 0,
			Optional = 1,
			Or = 2,
		}

		[SerializeField]
		internal string m_ControlPath; //Field offset: 0x0
		[SerializeField]
		internal Flags m_Flags; //Field offset: 0x8

		public string controlPath
		{
			 get { } //Length: 4
			 set { } //Length: 8
		}

		public bool isAND
		{
			 get { } //Length: 8
			 set { } //Length: 25
		}

		public bool isOptional
		{
			 get { } //Length: 7
			 set { } //Length: 25
		}

		public bool isOR
		{
			 get { } //Length: 8
			 set { } //Length: 25
		}

		public override bool Equals(DeviceRequirement other) { }

		public virtual bool Equals(object obj) { }

		public string get_controlPath() { }

		public bool get_isAND() { }

		public bool get_isOptional() { }

		public bool get_isOR() { }

		public virtual int GetHashCode() { }

		public static bool op_Equality(DeviceRequirement left, DeviceRequirement right) { }

		public static bool op_Inequality(DeviceRequirement left, DeviceRequirement right) { }

		public void set_controlPath(string value) { }

		public void set_isAND(bool value) { }

		public void set_isOptional(bool value) { }

		public void set_isOR(bool value) { }

		public virtual string ToString() { }

	}

	[DefaultMember("Item")]
	internal struct MatchResult : IEnumerable<Match>, IEnumerable, IDisposable
	{
		private struct Enumerator : IEnumerator<Match>, IEnumerator, IDisposable
		{
			internal int m_Index; //Field offset: 0x0
			internal DeviceRequirement[] m_Requirements; //Field offset: 0x8
			internal InputControlList<InputControl> m_Controls; //Field offset: 0x10

			public override Match Current
			{
				 get { } //Length: 176
			}

			private override object System.Collections.IEnumerator.Current
			{
				private get { } //Length: 108
			}

			public override void Dispose() { }

			public override Match get_Current() { }

			public override bool MoveNext() { }

			public override void Reset() { }

			private override object System.Collections.IEnumerator.get_Current() { }

		}

		internal struct Match
		{
			internal int m_RequirementIndex; //Field offset: 0x0
			internal DeviceRequirement[] m_Requirements; //Field offset: 0x8
			internal InputControlList<InputControl> m_Controls; //Field offset: 0x10

			public InputControl control
			{
				 get { } //Length: 60
			}

			public InputDevice device
			{
				 get { } //Length: 76
			}

			public bool isOptional
			{
				 get { } //Length: 53
			}

			public DeviceRequirement requirement
			{
				 get { } //Length: 56
			}

			public int requirementIndex
			{
				 get { } //Length: 3
			}

			public InputControl get_control() { }

			public InputDevice get_device() { }

			public bool get_isOptional() { }

			public DeviceRequirement get_requirement() { }

			public int get_requirementIndex() { }

		}

		public enum Result
		{
			AllSatisfied = 0,
			MissingRequired = 1,
			MissingOptional = 2,
		}

		internal Result m_Result; //Field offset: 0x0
		internal float m_Score; //Field offset: 0x4
		internal InputControlList<InputDevice> m_Devices; //Field offset: 0x8
		internal InputControlList<InputControl> m_Controls; //Field offset: 0x28
		internal DeviceRequirement[] m_Requirements; //Field offset: 0x48

		public InputControlList<InputDevice> devices
		{
			 get { } //Length: 320
		}

		public bool hasMissingOptionalDevices
		{
			 get { } //Length: 7
		}

		public bool hasMissingRequiredDevices
		{
			 get { } //Length: 7
		}

		public bool isSuccessfulMatch
		{
			 get { } //Length: 7
		}

		public Match Item
		{
			 get { } //Length: 174
		}

		public float score
		{
			 get { } //Length: 6
		}

		public override void Dispose() { }

		public InputControlList<InputDevice> get_devices() { }

		public bool get_hasMissingOptionalDevices() { }

		public bool get_hasMissingRequiredDevices() { }

		public bool get_isSuccessfulMatch() { }

		public Match get_Item(int index) { }

		public float get_score() { }

		public override IEnumerator<Match> GetEnumerator() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	}

	public struct SchemeJson
	{
		internal struct DeviceJson
		{
			public string devicePath; //Field offset: 0x0
			public bool isOptional; //Field offset: 0x8
			public bool isOR; //Field offset: 0x9

			public static DeviceJson From(DeviceRequirement requirement) { }

			public DeviceRequirement ToDeviceEntry() { }

		}

		public string name; //Field offset: 0x0
		public string bindingGroup; //Field offset: 0x8
		public DeviceJson[] devices; //Field offset: 0x10

		public static SchemeJson ToJson(InputControlScheme scheme) { }

		public static SchemeJson[] ToJson(InputControlScheme[] schemes) { }

		public InputControlScheme ToScheme() { }

		public static InputControlScheme[] ToSchemes(SchemeJson[] schemes) { }

	}

	[SerializeField]
	internal string m_Name; //Field offset: 0x0
	[SerializeField]
	internal string m_BindingGroup; //Field offset: 0x8
	[SerializeField]
	internal DeviceRequirement[] m_DeviceRequirements; //Field offset: 0x10

	public string bindingGroup
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public ReadOnlyArray<DeviceRequirement> deviceRequirements
	{
		 get { } //Length: 83
	}

	public string name
	{
		 get { } //Length: 4
	}

	public InputControlScheme(string name, IEnumerable<DeviceRequirement> devices = null, string bindingGroup = null) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(InputControlScheme other) { }

	public static Nullable<InputControlScheme> FindControlSchemeForDevice(InputDevice device, TSchemes schemes) { }

	public static Nullable<InputControlScheme> FindControlSchemeForDevices(TDevices devices, TSchemes schemes, InputDevice mustIncludeDevice = null, bool allowUnsuccesfulMatch = false) { }

	public static bool FindControlSchemeForDevices(TDevices devices, TSchemes schemes, out InputControlScheme controlScheme, out MatchResult matchResult, InputDevice mustIncludeDevice = null, bool allowUnsuccessfulMatch = false) { }

	public string get_bindingGroup() { }

	public ReadOnlyArray<DeviceRequirement> get_deviceRequirements() { }

	public string get_name() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(InputControlScheme left, InputControlScheme right) { }

	public static bool op_Inequality(InputControlScheme left, InputControlScheme right) { }

	public MatchResult PickDevicesFrom(TDevices devices, InputDevice favorDevice = null) { }

	public void set_bindingGroup(string value) { }

	internal void SetNameAndBindingGroup(string name, string bindingGroup = null) { }

	public bool SupportsDevice(InputDevice device) { }

	public virtual string ToString() { }

}

