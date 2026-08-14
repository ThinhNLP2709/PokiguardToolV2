namespace UnityEngine.ResourceManagement.Util;

public class UnityWebRequestUtilities
{
	private const string k_AddressablesLogConditional = "ADDRESSABLES_LOG_ALL"; //Field offset: 0x0

	public UnityWebRequestUtilities() { }

	public static bool IsAssetBundleDownloaded(UnityWebRequestAsyncOperation op) { }

	[Conditional("ADDRESSABLES_LOG_ALL")]
	internal static void Log(string msg) { }

	internal static void LogError(string msg) { }

	internal static void LogOperationResult(AsyncOperation op) { }

	public static bool RequestHasErrors(UnityWebRequest webReq, out UnityWebRequestResult result) { }

}

