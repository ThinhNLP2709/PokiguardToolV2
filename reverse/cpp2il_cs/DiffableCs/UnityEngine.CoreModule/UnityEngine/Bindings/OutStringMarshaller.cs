namespace UnityEngine.Bindings;

[IsByRefLike]
[Obsolete("Types with embedded references are not supported in this version of your compiler.", True)]
[VisibleToOtherModules]
internal struct OutStringMarshaller
{

	public static string GetStringAndDispose(ManagedSpanWrapper managedSpan) { }

}

