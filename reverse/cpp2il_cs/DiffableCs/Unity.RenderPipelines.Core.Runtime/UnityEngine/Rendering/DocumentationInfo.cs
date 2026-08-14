namespace UnityEngine.Rendering;

public class DocumentationInfo
{
	private const string fallbackVersion = "13.1"; //Field offset: 0x0
	private const string url = "https://docs.unity3d.com/Packages/{0}@{1}/manual/{2}.html#{3}"; //Field offset: 0x0

	public static string version
	{
		 get { } //Length: 44
	}

	public DocumentationInfo() { }

	public static string get_version() { }

	public static string GetPackageLink(string packageName, string packageVersion, string pageName) { }

	public static string GetPageLink(string packageName, string pageName) { }

	public static string GetPageLink(string packageName, string pageName, string pageHash) { }

}

