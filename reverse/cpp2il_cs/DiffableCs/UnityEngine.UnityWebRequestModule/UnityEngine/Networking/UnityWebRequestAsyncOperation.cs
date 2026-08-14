namespace UnityEngine.Networking;

[NativeHeader("UnityWebRequestScriptingClasses.h")]
[NativeHeader("Modules/UnityWebRequest/Public/UnityWebRequestAsyncOperation.h")]
[UsedByNativeCode]
public class UnityWebRequestAsyncOperation : AsyncOperation
{
	public static class BindingsMarshaller
	{

		public static UnityWebRequestAsyncOperation ConvertToManaged(IntPtr ptr) { }

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private UnityWebRequest <webRequest>k__BackingField; //Field offset: 0x20

	public internal UnityWebRequest webRequest
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	private UnityWebRequestAsyncOperation(IntPtr ptr) { }

	[CompilerGenerated]
	public UnityWebRequest get_webRequest() { }

	[CompilerGenerated]
	internal void set_webRequest(UnityWebRequest value) { }

}

