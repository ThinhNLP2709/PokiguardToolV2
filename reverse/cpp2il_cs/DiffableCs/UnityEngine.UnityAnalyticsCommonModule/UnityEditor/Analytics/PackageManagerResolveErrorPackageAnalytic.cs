namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
public class PackageManagerResolveErrorPackageAnalytic : PackageManagerBaseAnalytic
{
	public string reason; //Field offset: 0x60
	public string action; //Field offset: 0x68

	public PackageManagerResolveErrorPackageAnalytic() { }

	[RequiredByNativeCode]
	internal static PackageManagerResolveErrorPackageAnalytic CreatePackageManagerResolveErrorPackageAnalytic() { }

}

