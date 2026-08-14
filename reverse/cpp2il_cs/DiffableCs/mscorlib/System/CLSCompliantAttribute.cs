namespace System;

[AttributeUsage(AttributeTargets::All (32767), Inherited = True, AllowMultiple = False)]
public sealed class CLSCompliantAttribute : Attribute
{
	private bool _compliant; //Field offset: 0x10

	public bool IsCompliant
	{
		 get { } //Length: 5
	}

	public CLSCompliantAttribute(bool isCompliant) { }

	public bool get_IsCompliant() { }

}

