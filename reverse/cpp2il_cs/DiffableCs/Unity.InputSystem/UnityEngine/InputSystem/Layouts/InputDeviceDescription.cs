namespace UnityEngine.InputSystem.Layouts;

public struct InputDeviceDescription : IEquatable<InputDeviceDescription>
{
	private struct DeviceDescriptionJson
	{
		public string interface; //Field offset: 0x0
		public string type; //Field offset: 0x8
		public string product; //Field offset: 0x10
		public string serial; //Field offset: 0x18
		public string version; //Field offset: 0x20
		public string manufacturer; //Field offset: 0x28
		public string capabilities; //Field offset: 0x30

	}

	[SerializeField]
	private string m_InterfaceName; //Field offset: 0x0
	[SerializeField]
	private string m_DeviceClass; //Field offset: 0x8
	[SerializeField]
	private string m_Manufacturer; //Field offset: 0x10
	[SerializeField]
	private string m_Product; //Field offset: 0x18
	[SerializeField]
	private string m_Serial; //Field offset: 0x20
	[SerializeField]
	private string m_Version; //Field offset: 0x28
	[SerializeField]
	private string m_Capabilities; //Field offset: 0x30

	public string capabilities
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public string deviceClass
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public bool empty
	{
		 get { } //Length: 122
	}

	public string interfaceName
	{
		 get { } //Length: 4
		 set { } //Length: 8
	}

	public string manufacturer
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public string product
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public string serial
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public string version
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	internal static bool ComparePropertyToDeviceDescriptor(string propertyName, JsonString propertyValue, string deviceDescriptor) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(InputDeviceDescription other) { }

	public static InputDeviceDescription FromJson(string json) { }

	public string get_capabilities() { }

	public string get_deviceClass() { }

	public bool get_empty() { }

	public string get_interfaceName() { }

	public string get_manufacturer() { }

	public string get_product() { }

	public string get_serial() { }

	public string get_version() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(InputDeviceDescription left, InputDeviceDescription right) { }

	public static bool op_Inequality(InputDeviceDescription left, InputDeviceDescription right) { }

	public void set_capabilities(string value) { }

	public void set_deviceClass(string value) { }

	public void set_interfaceName(string value) { }

	public void set_manufacturer(string value) { }

	public void set_product(string value) { }

	public void set_serial(string value) { }

	public void set_version(string value) { }

	public string ToJson() { }

	public virtual string ToString() { }

}

