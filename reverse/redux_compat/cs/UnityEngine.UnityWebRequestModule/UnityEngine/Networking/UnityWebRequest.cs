/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using UnityEngine;
using UnityEngine.Bindings;

// Image 45: UnityEngine.UnityWebRequestModule.dll - Assembly: UnityEngine.UnityWebRequestModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15315-15336

namespace UnityEngine.Networking
{
	[NativeHeader("Modules/UnityWebRequest/Public/UnityWebRequest.h")]
	public class UnityWebRequest : IDisposable // TypeDefIndex: 15329
	{
		// Fields
		[NonSerialized]
		internal IntPtr m_Ptr; // 0x10
		[NonSerialized]
		internal DownloadHandler m_DownloadHandler; // 0x18
		[NonSerialized]
		internal UploadHandler m_UploadHandler; // 0x20
		[NonSerialized]
		internal CertificateHandler m_CertificateHandler; // 0x28
		[NonSerialized]
		internal Uri m_Uri; // 0x30
		[CompilerGenerated]
		private bool _disposeCertificateHandlerOnDispose_k__BackingField; // 0x38
		[CompilerGenerated]
		private bool _disposeDownloadHandlerOnDispose_k__BackingField; // 0x39
		[CompilerGenerated]
		private bool _disposeUploadHandlerOnDispose_k__BackingField; // 0x3A
	
		// Properties
		public bool disposeCertificateHandlerOnDispose { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0
		public bool disposeDownloadHandlerOnDispose { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001814CFF30-0x00000001814CFF40 0x00000001816DA820-0x00000001816DA830
		public bool disposeUploadHandlerOnDispose { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001814CFF20-0x00000001814CFF30 0x00000001814CFF40-0x00000001814CFF50
		public string method { get; set; } // 0x00000001825CEA40-0x00000001825CEB30 0x00000001825CEF60-0x00000001825CF1C0
		public string error { get; } // 0x00000001825CE7B0-0x00000001825CE940 
		public string url { get; set; } // 0x00000001825CEC70-0x00000001825CEC80 0x00000001825CF5C0-0x00000001825CF650
		public Uri uri { set; } // 0x00000001825CF4C0-0x00000001825CF5C0
		public long responseCode { get; } // 0x00000001825CEB70-0x00000001825CEBD0 
		public bool isModifiable { [NativeMethod("IsModifiable")] get; } // 0x00000001825CE9E0-0x00000001825CEA40 
		public bool isDone { get; } // 0x00000001825CE940-0x00000001825CE9A0 
		public Result result { [NativeMethod("GetResult")] get; } // 0x00000001825CEC10-0x00000001825CEC70 
		public ulong downloadedBytes { get; } // 0x00000001825CE750-0x00000001825CE7B0 
		public int redirectLimit { set; } // 0x00000001825CDD20-0x00000001825CDD80
		public UploadHandler uploadHandler { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x00000001825CF350-0x00000001825CF4C0
		public DownloadHandler downloadHandler { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001825CEDF0-0x00000001825CEF60
		public CertificateHandler certificateHandler { get; set; } // 0x000000018033D240-0x000000018033D250 0x00000001825CEC80-0x00000001825CEDF0
		public int timeout { set; } // 0x00000001825CF1C0-0x00000001825CF350
	
		// Nested types
		internal enum UnityWebRequestMethod // TypeDefIndex: 15330
		{
			Get = 0,
			Post = 1,
			Put = 2,
			Head = 3,
			Custom = 4
		}
	
		internal enum UnityWebRequestError // TypeDefIndex: 15331
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
			InsecureConnectionNotAllowed = 40
		}
	
		public enum Result // TypeDefIndex: 15332
		{
			InProgress = 0,
			Success = 1,
			ConnectionError = 2,
			ProtocolError = 3,
			DataProcessingError = 4
		}
	
		internal static class BindingsMarshaller // TypeDefIndex: 15333
		{
			// Methods
			public static IntPtr ConvertToNative(UnityWebRequest unityWebRequest); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public UnityWebRequest(string url, string method); // 0x00000001825CE690-0x00000001825CE710
		public UnityWebRequest(string url, string method, DownloadHandler downloadHandler, UploadHandler uploadHandler); // 0x00000001825CE460-0x00000001825CE510
		public UnityWebRequest(Uri uri, string method, DownloadHandler downloadHandler, UploadHandler uploadHandler); // 0x00000001825CE510-0x00000001825CE690
	
		// Methods
		[NativeConditional("ENABLE_UNITYWEBREQUEST")]
		[NativeMethod(IsThreadSafe = true)]
		private static string GetWebErrorString(UnityWebRequestError err); // 0x00000001825CCEA0-0x00000001825CCF60
		[VisibleToOtherModules]
		internal static string GetHTTPStatusString(long responseCode); // 0x00000001825CC9A0-0x00000001825CCA60
		[NativeMethod(ThrowsException = true)]
		internal static IntPtr Create(); // 0x00000001825CC310-0x00000001825CC340
		[NativeMethod(IsThreadSafe = true)]
		private void Release(); // 0x00000001825CD7A0-0x00000001825CD800
		internal void InternalDestroy(); // 0x00000001825CD090-0x00000001825CD120
		private void InternalSetDefaults(); // 0x00000001825CD230-0x00000001825CD240
		~UnityWebRequest(); // 0x00000001825CC6F0-0x00000001825CC770
		public void Dispose(); // 0x00000001825CC3F0-0x00000001825CC450
		private void DisposeHandlers(); // 0x00000001825CC340-0x00000001825CC3F0
		[NativeMethod(ThrowsException = true)]
		internal UnityWebRequestAsyncOperation BeginWebRequest(); // 0x00000001825CC260-0x00000001825CC310
		public UnityWebRequestAsyncOperation SendWebRequest(); // 0x00000001825CD800-0x00000001825CD8D0
		[NativeMethod(IsThreadSafe = true)]
		public void Abort(); // 0x00000001825CC1C0-0x00000001825CC220
		private UnityWebRequestError SetMethod(UnityWebRequestMethod methodType); // 0x00000001825CDC80-0x00000001825CDCE0
		internal void InternalSetMethod(UnityWebRequestMethod methodType); // 0x00000001825CD240-0x00000001825CD380
		private UnityWebRequestError SetCustomMethod(string customMethodName); // 0x00000001825CD9F0-0x00000001825CDB70
		internal void InternalSetCustomMethod(string customMethodName); // 0x00000001825CD120-0x00000001825CD230
		internal UnityWebRequestMethod GetMethod(); // 0x00000001825CCAA0-0x00000001825CCB00
		internal string GetCustomMethod(); // 0x00000001825CC7C0-0x00000001825CC8B0
		private UnityWebRequestError GetError(); // 0x00000001825CC8F0-0x00000001825CC950
		private string GetUrl(); // 0x00000001825CCD70-0x00000001825CCE60
		private UnityWebRequestError SetUrl(string url); // 0x00000001825CE110-0x00000001825CE290
		private void InternalSetUrl(string url); // 0x00000001825CD650-0x00000001825CD760
		[NativeMethod(ThrowsException = true)]
		private void SetRedirectLimitFromScripting(int limit); // 0x00000001825CDD20-0x00000001825CDD80
		[NativeMethod("SetRequestHeader")]
		internal UnityWebRequestError InternalSetRequestHeader(string name, string value); // 0x00000001825CD3E0-0x00000001825CD650
		public void SetRequestHeader(string name, string value); // 0x00000001825CDD80-0x00000001825CDF50
		public string GetResponseHeader(string name); // 0x00000001825CCB60-0x00000001825CCD20
		private UnityWebRequestError SetUploadHandler(UploadHandler uh); // 0x00000001825CE040-0x00000001825CE0C0
		private UnityWebRequestError SetDownloadHandler(DownloadHandler dh); // 0x00000001825CDBC0-0x00000001825CDC40
		private UnityWebRequestError SetCertificateHandler(CertificateHandler ch); // 0x00000001825CD920-0x00000001825CD9A0
		private UnityWebRequestError SetTimeoutMsec(int timeout); // 0x00000001825CDF90-0x00000001825CDFF0
		public static UnityWebRequest Get(string uri); // 0x00000001825CCF60-0x00000001825CD090
		public static string EscapeURL(string s); // 0x00000001825CC450-0x00000001825CC5A0
		public static string EscapeURL(string s, Encoding e); // 0x00000001825CC5A0-0x00000001825CC6F0
		public static string UnEscapeURL(string s); // 0x00000001825CE380-0x00000001825CE460
		public static string UnEscapeURL(string s, Encoding e); // 0x00000001825CE290-0x00000001825CE380
		private static void GetWebErrorString_Injected(UnityWebRequestError err, ); // 0x00000001825CCE60-0x00000001825CCEA0
		private static void GetHTTPStatusString_Injected(long responseCode, ); // 0x00000001825CC950-0x00000001825CC9A0
		private static void Release_Injected(IntPtr _unity_self); // 0x00000001825CD760-0x00000001825CD7A0
		private static IntPtr BeginWebRequest_Injected(IntPtr _unity_self); // 0x00000001825CC220-0x00000001825CC260
		private static void Abort_Injected(IntPtr _unity_self); // 0x00000001825CC180-0x00000001825CC1C0
		private static UnityWebRequestError SetMethod_Injected(IntPtr _unity_self, UnityWebRequestMethod methodType); // 0x00000001825CDC40-0x00000001825CDC80
		private static UnityWebRequestError SetCustomMethod_Injected(IntPtr _unity_self, ref ManagedSpanWrapper customMethodName); // 0x00000001825CD9A0-0x00000001825CD9F0
		private static UnityWebRequestMethod GetMethod_Injected(IntPtr _unity_self); // 0x00000001825CCA60-0x00000001825CCAA0
		private static void GetCustomMethod_Injected(IntPtr _unity_self, ); // 0x00000001825CC770-0x00000001825CC7C0
		private static UnityWebRequestError GetError_Injected(IntPtr _unity_self); // 0x00000001825CC8B0-0x00000001825CC8F0
		private static void GetUrl_Injected(IntPtr _unity_self, ); // 0x00000001825CCD20-0x00000001825CCD70
		private static UnityWebRequestError SetUrl_Injected(IntPtr _unity_self, ref ManagedSpanWrapper url); // 0x00000001825CE0C0-0x00000001825CE110
		private static long get_responseCode_Injected(IntPtr _unity_self); // 0x00000001825CEB30-0x00000001825CEB70
		private static bool get_isModifiable_Injected(IntPtr _unity_self); // 0x00000001825CE9A0-0x00000001825CE9E0
		private static Result get_result_Injected(IntPtr _unity_self); // 0x00000001825CEBD0-0x00000001825CEC10
		private static ulong get_downloadedBytes_Injected(IntPtr _unity_self); // 0x00000001825CE710-0x00000001825CE750
		private static void SetRedirectLimitFromScripting_Injected(IntPtr _unity_self, int limit); // 0x00000001825CDCE0-0x00000001825CDD20
		private static UnityWebRequestError InternalSetRequestHeader_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, ref ManagedSpanWrapper value); // 0x00000001825CD380-0x00000001825CD3E0
		private static void GetResponseHeader_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, ); // 0x00000001825CCB00-0x00000001825CCB60
		private static UnityWebRequestError SetUploadHandler_Injected(IntPtr _unity_self, IntPtr uh); // 0x00000001825CDFF0-0x00000001825CE040
		private static UnityWebRequestError SetDownloadHandler_Injected(IntPtr _unity_self, IntPtr dh); // 0x00000001825CDB70-0x00000001825CDBC0
		private static UnityWebRequestError SetCertificateHandler_Injected(IntPtr _unity_self, IntPtr ch); // 0x00000001825CD8D0-0x00000001825CD920
		private static UnityWebRequestError SetTimeoutMsec_Injected(IntPtr _unity_self, int timeout); // 0x00000001825CDF50-0x00000001825CDF90
	}
}
