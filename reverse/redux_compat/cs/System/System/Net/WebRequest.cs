/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Net.Cache;
using System.Net.Security;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Threading.Tasks;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	public abstract class WebRequest : MarshalByRefObject, ISerializable // TypeDefIndex: 9059
	{
		// Fields
		private static ArrayList s_PrefixList; // 0x00
		private static object s_InternalSyncObject; // 0x08
		private static TimerThread.Queue s_DefaultTimerQueue; // 0x10
		private AuthenticationLevel m_AuthenticationLevel; // 0x18
		private TokenImpersonationLevel m_ImpersonationLevel; // 0x1C
		private RequestCachePolicy m_CachePolicy; // 0x20
		private RequestCacheProtocol m_CacheProtocol; // 0x28
		private RequestCacheBinding m_CacheBinding; // 0x30
		private static DesignerWebRequestCreate webRequestCreate; // 0x18
		private static IWebProxy s_DefaultWebProxy; // 0x20
		private static bool s_DefaultWebProxyInitialized; // 0x28
	
		// Properties
		private static object InternalSyncObject { get; } // 0x0000000181BFA1C0-0x0000000181BFA270 
		internal static ArrayList PrefixList { get; } // 0x0000000181BFA2A0-0x0000000181BFA400 
		public virtual RequestCachePolicy CachePolicy { set; } // 0x0000000181BF99A0-0x0000000181BF9A80
		public virtual string Method { get; set; } // 0x0000000181BFA270-0x0000000181BFA2A0 0x0000000181BFA4F0-0x0000000181BFA520
		public virtual Uri RequestUri { get; } // 0x0000000181BFA430-0x0000000181BFA460 
		public virtual WebHeaderCollection Headers { get; } // 0x0000000181BFA000-0x0000000181BFA030 
		public virtual long ContentLength { get; } // 0x0000000181BF9FA0-0x0000000181BF9FD0 
		public virtual ICredentials Credentials { get; set; } // 0x0000000181BF9FD0-0x0000000181BFA000 0x0000000181BFA4C0-0x0000000181BFA4F0
		public virtual bool UseDefaultCredentials { get; } // 0x0000000181BFA490-0x0000000181BFA4C0 
		public virtual IWebProxy Proxy { get; set; } // 0x0000000181BFA400-0x0000000181BFA430 0x0000000181BFA520-0x0000000181BFA550
		public virtual int Timeout { get; } // 0x0000000181BFA460-0x0000000181BFA490 
		internal RequestCacheProtocol CacheProtocol { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		internal static IWebProxy InternalDefaultWebProxy { get; } // 0x0000000181BFA030-0x0000000181BFA1C0 
	
		// Nested types
		internal class DesignerWebRequestCreate : IWebRequestCreate // TypeDefIndex: 9060
		{
			// Constructors
			public DesignerWebRequestCreate(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public WebRequest Create(Uri uri); // 0x0000000181BE0EB0-0x0000000181BE0FB0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass79_0 // TypeDefIndex: 9061
		{
			// Fields
			public WindowsIdentity currentUser; // 0x10
			public WebRequest __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass79_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Task<WebResponse> _GetResponseAsync_b__1(); // 0x0000000181BF57E0-0x0000000181BF5A40
		}
	
		// Constructors
		protected WebRequest(); // 0x0000000181BF9F70-0x0000000181BF9FA0
		protected WebRequest(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x00000001802E5CB0-0x00000001802E5CC0
		static WebRequest(); // 0x0000000181BF9E90-0x0000000181BF9F70
	
		// Methods
		private static WebRequest Create(Uri requestUri, bool useUriBase); // 0x0000000181BF9280-0x0000000181BF9540
		public static WebRequest Create(string requestUriString); // 0x0000000181BF9610-0x0000000181BF96E0
		public static WebRequest Create(Uri requestUri); // 0x0000000181BF9540-0x0000000181BF9610
		private static ArrayList PopulatePrefixList(); // 0x0000000181BF9A80-0x0000000181BF9D10
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181BF9D50-0x0000000181BF9D80
		protected virtual void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x00000001802E76C0-0x00000001802E76D0
		private void InternalSetCachePolicy(RequestCachePolicy policy); // 0x0000000181BF99A0-0x0000000181BF9A80
		public virtual WebResponse GetResponse(); // 0x0000000181BF9970-0x0000000181BF99A0
		public virtual IAsyncResult BeginGetResponse(AsyncCallback callback, object state); // 0x0000000181BF9250-0x0000000181BF9280
		public virtual WebResponse EndGetResponse(IAsyncResult asyncResult); // 0x0000000181BF96E0-0x0000000181BF9710
		public virtual Task<WebResponse> GetResponseAsync(); // 0x0000000181BF9710-0x0000000181BF9970
		private WindowsIdentity SafeCaptureIdenity(); // 0x0000000181BF9D10-0x0000000181BF9D50
		public virtual void Abort(); // 0x0000000181BF9220-0x0000000181BF9250
		[CompilerGenerated]
		private Task<WebResponse> _GetResponseAsync_b__79_0(); // 0x0000000181BF9D80-0x0000000181BF9E90
	}
}
