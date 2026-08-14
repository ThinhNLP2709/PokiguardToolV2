namespace UnityEngine.InputSystem.Utilities;

[Extension]
internal static class TypeHelpers
{

	[Extension]
	public static TObject As(object obj) { }

	public static Type GetGenericTypeArgumentFromHierarchy(Type type, Type genericTypeDefinition, int argumentIndex) { }

	[Extension]
	public static string GetNiceTypeName(Type type) { }

	public static Type GetValueType(MemberInfo member) { }

	[Extension]
	public static bool IsInt(TypeCode type) { }

}

