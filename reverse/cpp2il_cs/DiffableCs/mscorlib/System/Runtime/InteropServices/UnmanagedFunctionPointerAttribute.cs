namespace System.Runtime.InteropServices;

[AttributeUsage(AttributeTargets::Delegate (4096), AllowMultiple = False, Inherited = False)]
[ComVisible(True)]
public sealed class UnmanagedFunctionPointerAttribute : Attribute
{
	private CallingConvention m_callingConvention; //Field offset: 0x10

	public CallingConvention CallingConvention
	{
		 get { } //Length: 4
	}

	public UnmanagedFunctionPointerAttribute(CallingConvention callingConvention) { }

	public CallingConvention get_CallingConvention() { }

}

