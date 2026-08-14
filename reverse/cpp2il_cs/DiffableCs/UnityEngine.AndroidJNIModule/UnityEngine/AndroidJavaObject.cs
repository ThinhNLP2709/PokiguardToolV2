namespace UnityEngine;

public class AndroidJavaObject : IDisposable
{
	private static bool enableDebugPrints; //Field offset: 0x0
	internal GlobalJavaObjectRef m_jobject; //Field offset: 0x10
	internal GlobalJavaObjectRef m_jclass; //Field offset: 0x18

	private void _AndroidJavaObject(IntPtr constructorID, Object[] args) { }

	private void _AndroidJavaObject(string className, Object[] args) { }

	protected ReturnType _Call(IntPtr methodID, Object[] args) { }

	protected ReturnType _Call(string methodName, Object[] args) { }

	protected ReturnType _CallStatic(IntPtr methodID, Object[] args) { }

	protected ReturnType _CallStatic(string methodName, Object[] args) { }

	protected IntPtr _GetRawClass() { }

	protected IntPtr _GetRawObject() { }

	internal AndroidJavaObject() { }

	public AndroidJavaObject(IntPtr jobject) { }

	public AndroidJavaObject(string className, Object[] args) { }

	internal static AndroidJavaObject AndroidJavaObjectDeleteLocalRef(IntPtr jobject) { }

	public ReturnType Call(string methodName, Object[] args) { }

	public ReturnType CallStatic(string methodName, Object[] args) { }

	protected void DebugPrint(string msg) { }

	protected override void Dispose(bool disposing) { }

	public override void Dispose() { }

	protected virtual void Finalize() { }

	internal static ReturnType FromJavaArray(IntPtr jobject) { }

	public IntPtr GetRawClass() { }

	public IntPtr GetRawObject() { }

}

