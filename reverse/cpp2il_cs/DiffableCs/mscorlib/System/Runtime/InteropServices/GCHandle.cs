namespace System.Runtime.InteropServices;

[ComVisible(True)]
public struct GCHandle
{
	private IntPtr handle; //Field offset: 0x0

	public bool IsAllocated
	{
		 get { } //Length: 8
	}

	public object Target
	{
		 get { } //Length: 127
		 set { } //Length: 89
	}

	private GCHandle(IntPtr h) { }

	private GCHandle(object obj) { }

	internal GCHandle(object value, GCHandleType type) { }

	public IntPtr AddrOfPinnedObject() { }

	public static GCHandle Alloc(object value, GCHandleType type) { }

	public static GCHandle Alloc(object value) { }

	internal static bool CanDereferenceHandle(IntPtr handle) { }

	private static bool CheckCurrentDomain(IntPtr handle) { }

	public virtual bool Equals(object o) { }

	public void Free() { }

	private static void FreeHandle(IntPtr handle) { }

	public static GCHandle FromIntPtr(IntPtr value) { }

	public bool get_IsAllocated() { }

	public object get_Target() { }

	private static IntPtr GetAddrOfPinnedObject(IntPtr handle) { }

	public virtual int GetHashCode() { }

	internal static object GetRef(IntPtr handle) { }

	private static object GetTarget(IntPtr handle) { }

	private static IntPtr GetTargetHandle(object obj, IntPtr handle, GCHandleType type) { }

	public static bool op_Equality(GCHandle a, GCHandle b) { }

	public static IntPtr op_Explicit(GCHandle value) { }

	public static GCHandle op_Explicit(IntPtr value) { }

	public void set_Target(object value) { }

	internal static void SetRef(IntPtr handle, object value) { }

	public static IntPtr ToIntPtr(GCHandle value) { }

}

