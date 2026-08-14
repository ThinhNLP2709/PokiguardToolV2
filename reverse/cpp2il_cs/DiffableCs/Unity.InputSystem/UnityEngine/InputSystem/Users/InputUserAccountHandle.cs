namespace UnityEngine.InputSystem.Users;

public struct InputUserAccountHandle : IEquatable<InputUserAccountHandle>
{
	private string m_ApiName; //Field offset: 0x0
	private ulong m_Handle; //Field offset: 0x8

	public string apiName
	{
		 get { } //Length: 4
	}

	public ulong handle
	{
		 get { } //Length: 5
	}

	public InputUserAccountHandle(string apiName, ulong handle) { }

	public override bool Equals(InputUserAccountHandle other) { }

	public virtual bool Equals(object obj) { }

	public string get_apiName() { }

	public ulong get_handle() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(InputUserAccountHandle left, InputUserAccountHandle right) { }

	public static bool op_Inequality(InputUserAccountHandle left, InputUserAccountHandle right) { }

	public virtual string ToString() { }

}

