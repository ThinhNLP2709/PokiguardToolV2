namespace UnityEngine.Networking;

[NativeHeader("Modules/UnityWebRequest/Public/UnityWebRequest.h")]
public class UnityWebRequest : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(UnityWebRequest unityWebRequest) { }

	}

	internal enum Result
	{
		InProgress = 0,
		Success = 1,
		ConnectionError = 2,
		ProtocolError = 3,
		DataProcessingError = 4,
	}

	public enum UnityWebRequestError
	{
		OK = 0,
		OKCached = 1,
		Unknown = 2,
		SDKError = 3,
		UnsupportedProtocol = 4,
		MalformattedUrl = 5,
		CannotResolveProxy = 6,
		CannotResolveHost = 7,
		CannotConnectToHost = 8,
		AccessDenied = 9,
		GenericHttpError = 10,
		WriteError = 11,
		ReadError = 12,
		OutOfMemory = 13,
		Timeout = 14,
		HTTPPostError = 15,
		SSLCannotConnect = 16,
		Aborted = 17,
		TooManyRedirects = 18,
		ReceivedNoData = 19,
		SSLNotSupported = 20,
		FailedToSendData = 21,
		FailedToReceiveData = 22,
		SSLCertificateError = 23,
		SSLCipherNotAvailable = 24,
		SSLCACertError = 25,
		UnrecognizedContentEncoding = 26,
		LoginFailed = 27,
		SSLShutdownFailed = 28,
		RedirectLimitInvalid = 29,
		InvalidRedirect = 30,
		CannotModifyRequest = 31,
		HeaderNameContainsInvalidCharacters = 32,
		HeaderValueContainsInvalidCharacters = 33,
		CannotOverrideSystemHeaders = 34,
		AlreadySent = 35,
		InvalidMethod = 36,
		NotImplemented = 37,
		NoInternetConnection = 38,
		DataProcessingError = 39,
		InsecureConnectionNotAllowed = 40,
	}

	public enum UnityWebRequestMethod
	{
		Get = 0,
		Post = 1,
		Put = 2,
		Head = 3,
		Custom = 4,
	}

	internal IntPtr m_Ptr; //Field offset: 0x10
	internal DownloadHandler m_DownloadHandler; //Field offset: 0x18
	internal UploadHandler m_UploadHandler; //Field offset: 0x20
	internal CertificateHandler m_CertificateHandler; //Field offset: 0x28
	internal Uri m_Uri; //Field offset: 0x30
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposeCertificateHandlerOnDispose>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposeDownloadHandlerOnDispose>k__BackingField; //Field offset: 0x39
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposeUploadHandlerOnDispose>k__BackingField; //Field offset: 0x3A

	public CertificateHandler certificateHandler
	{
		 get { } //Length: 7
		 set { } //Length: 360
	}

	public bool disposeCertificateHandlerOnDispose
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool disposeDownloadHandlerOnDispose
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool disposeUploadHandlerOnDispose
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public ulong downloadedBytes
	{
		 get { } //Length: 81
	}

	public DownloadHandler downloadHandler
	{
		 get { } //Length: 7
		 set { } //Length: 360
	}

	public string error
	{
		 get { } //Length: 407
	}

	public bool isDone
	{
		 get { } //Length: 86
	}

	public bool isModifiable
	{
		[NativeMethod("IsModifiable")]
		 get { } //Length: 81
	}

	public string method
	{
		 get { } //Length: 238
		 set { } //Length: 595
	}

	public int redirectLimit
	{
		 set { } //Length: 88
	}

	public long responseCode
	{
		 get { } //Length: 81
	}

	public Result result
	{
		[NativeMethod("GetResult")]
		 get { } //Length: 81
	}

	public int timeout
	{
		 set { } //Length: 387
	}

	public UploadHandler uploadHandler
	{
		 get { } //Length: 7
		 set { } //Length: 360
	}

	public Uri uri
	{
		 set { } //Length: 242
	}

	public string url
	{
		 get { } //Length: 9
		 set { } //Length: 132
	}

	public UnityWebRequest(string url, string method, DownloadHandler downloadHandler, UploadHandler uploadHandler) { }

	public UnityWebRequest(Uri uri, string method, DownloadHandler downloadHandler, UploadHandler uploadHandler) { }

	public UnityWebRequest(string url, string method) { }

	[NativeMethod(IsThreadSafe = True)]
	public void Abort() { }

	private static void Abort_Injected(IntPtr _unity_self) { }

	[NativeThrows]
	internal UnityWebRequestAsyncOperation BeginWebRequest() { }

	private static IntPtr BeginWebRequest_Injected(IntPtr _unity_self) { }

	[NativeThrows]
	internal static IntPtr Create() { }

	public override void Dispose() { }

	private void DisposeHandlers() { }

	public static string EscapeURL(string s, Encoding e) { }

	public static string EscapeURL(string s) { }

	protected virtual void Finalize() { }

	public static UnityWebRequest Get(string uri) { }

	public CertificateHandler get_certificateHandler() { }

	[CompilerGenerated]
	public bool get_disposeCertificateHandlerOnDispose() { }

	[CompilerGenerated]
	public bool get_disposeDownloadHandlerOnDispose() { }

	[CompilerGenerated]
	public bool get_disposeUploadHandlerOnDispose() { }

	public ulong get_downloadedBytes() { }

	private static ulong get_downloadedBytes_Injected(IntPtr _unity_self) { }

	public DownloadHandler get_downloadHandler() { }

	public string get_error() { }

	public bool get_isDone() { }

	[NativeMethod("IsModifiable")]
	public bool get_isModifiable() { }

	private static bool get_isModifiable_Injected(IntPtr _unity_self) { }

	public string get_method() { }

	public long get_responseCode() { }

	private static long get_responseCode_Injected(IntPtr _unity_self) { }

	[NativeMethod("GetResult")]
	public Result get_result() { }

	private static Result get_result_Injected(IntPtr _unity_self) { }

	public UploadHandler get_uploadHandler() { }

	public string get_url() { }

	internal string GetCustomMethod() { }

	private static void GetCustomMethod_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret) { }

	private UnityWebRequestError GetError() { }

	private static UnityWebRequestError GetError_Injected(IntPtr _unity_self) { }

	[VisibleToOtherModules]
	internal static string GetHTTPStatusString(long responseCode) { }

	private static void GetHTTPStatusString_Injected(long responseCode, out ManagedSpanWrapper ret) { }

	internal UnityWebRequestMethod GetMethod() { }

	private static UnityWebRequestMethod GetMethod_Injected(IntPtr _unity_self) { }

	public string GetResponseHeader(string name) { }

	private static void GetResponseHeader_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, out ManagedSpanWrapper ret) { }

	private string GetUrl() { }

	private static void GetUrl_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret) { }

	[NativeConditional("ENABLE_UNITYWEBREQUEST")]
	[NativeMethod(IsThreadSafe = True)]
	private static string GetWebErrorString(UnityWebRequestError err) { }

	private static void GetWebErrorString_Injected(UnityWebRequestError err, out ManagedSpanWrapper ret) { }

	internal void InternalDestroy() { }

	internal void InternalSetCustomMethod(string customMethodName) { }

	private void InternalSetDefaults() { }

	internal void InternalSetMethod(UnityWebRequestMethod methodType) { }

	[NativeMethod("SetRequestHeader")]
	internal UnityWebRequestError InternalSetRequestHeader(string name, string value) { }

	private static UnityWebRequestError InternalSetRequestHeader_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, ref ManagedSpanWrapper value) { }

	private void InternalSetUrl(string url) { }

	[NativeMethod(IsThreadSafe = True)]
	private void Release() { }

	private static void Release_Injected(IntPtr _unity_self) { }

	public UnityWebRequestAsyncOperation SendWebRequest() { }

	public void set_certificateHandler(CertificateHandler value) { }

	[CompilerGenerated]
	public void set_disposeCertificateHandlerOnDispose(bool value) { }

	[CompilerGenerated]
	public void set_disposeDownloadHandlerOnDispose(bool value) { }

	[CompilerGenerated]
	public void set_disposeUploadHandlerOnDispose(bool value) { }

	public void set_downloadHandler(DownloadHandler value) { }

	public void set_method(string value) { }

	public void set_redirectLimit(int value) { }

	public void set_timeout(int value) { }

	public void set_uploadHandler(UploadHandler value) { }

	public void set_uri(Uri value) { }

	public void set_url(string value) { }

	private UnityWebRequestError SetCertificateHandler(CertificateHandler ch) { }

	private static UnityWebRequestError SetCertificateHandler_Injected(IntPtr _unity_self, IntPtr ch) { }

	private UnityWebRequestError SetCustomMethod(string customMethodName) { }

	private static UnityWebRequestError SetCustomMethod_Injected(IntPtr _unity_self, ref ManagedSpanWrapper customMethodName) { }

	private UnityWebRequestError SetDownloadHandler(DownloadHandler dh) { }

	private static UnityWebRequestError SetDownloadHandler_Injected(IntPtr _unity_self, IntPtr dh) { }

	private UnityWebRequestError SetMethod(UnityWebRequestMethod methodType) { }

	private static UnityWebRequestError SetMethod_Injected(IntPtr _unity_self, UnityWebRequestMethod methodType) { }

	[NativeThrows]
	private void SetRedirectLimitFromScripting(int limit) { }

	private static void SetRedirectLimitFromScripting_Injected(IntPtr _unity_self, int limit) { }

	public void SetRequestHeader(string name, string value) { }

	private UnityWebRequestError SetTimeoutMsec(int timeout) { }

	private static UnityWebRequestError SetTimeoutMsec_Injected(IntPtr _unity_self, int timeout) { }

	private UnityWebRequestError SetUploadHandler(UploadHandler uh) { }

	private static UnityWebRequestError SetUploadHandler_Injected(IntPtr _unity_self, IntPtr uh) { }

	private UnityWebRequestError SetUrl(string url) { }

	private static UnityWebRequestError SetUrl_Injected(IntPtr _unity_self, ref ManagedSpanWrapper url) { }

	public static string UnEscapeURL(string s, Encoding e) { }

	public static string UnEscapeURL(string s) { }

}

