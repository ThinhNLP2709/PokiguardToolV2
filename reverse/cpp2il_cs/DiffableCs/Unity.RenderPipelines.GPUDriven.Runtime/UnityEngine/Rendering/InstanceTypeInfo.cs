namespace UnityEngine.Rendering;

internal static class InstanceTypeInfo
{
	public const int kInstanceTypeBitCount = 1; //Field offset: 0x0
	public const int kMaxInstanceTypesCount = 2; //Field offset: 0x0
	public const uint kInstanceTypeMask = 1; //Field offset: 0x0
	private static InstanceType[] s_ParentTypes; //Field offset: 0x0
	private static List<InstanceType>[] s_ChildTypes; //Field offset: 0x8

	private static InstanceTypeInfo() { }

	private static void FlattenChildInstanceTypes(InstanceType instanceType, NativeList<InstanceType> instanceTypes) { }

	public static List<InstanceType> GetChildTypes(InstanceType type) { }

	private static InstanceType GetMaxChildTypeRecursively(InstanceType type) { }

	public static InstanceType GetParentType(InstanceType type) { }

	private static void InitChildTypes() { }

	private static void InitParentTypes() { }

	private static void ValidateTypeRelationsAreCorrectlySorted() { }

}

