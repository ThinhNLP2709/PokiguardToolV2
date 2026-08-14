namespace UnityEngine.Bindings;

[VisibleToOtherModules]
internal static class ExceptionMarshaller
{
	[ThreadStatic]
	private static Exception s_pendingException; //Field offset: 0x80000000

	[RequiredByNativeCode]
	private static void SetPendingException(Exception ex) { }

}

