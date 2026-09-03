/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class XmlDownloadManager // TypeDefIndex: 6871
	{
		// Fields
		private Hashtable connections; // 0x10
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass4_0 // TypeDefIndex: 6872
		{
			// Fields
			public Uri uri; // 0x10
	
			// Constructors
			public __c__DisplayClass4_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Stream _GetStreamAsync_b__0(); // 0x0000000181A93950-0x0000000181A939F0
		}
	
		[CompilerGenerated]
		private struct _GetNonFileStreamAsync_d__5 : IAsyncStateMachine // TypeDefIndex: 6873
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<Stream> __t__builder; // 0x08
			public Uri uri; // 0x20
			public ICredentials credentials; // 0x28
			public IWebProxy proxy; // 0x30
			public RequestCachePolicy cachePolicy; // 0x38
			public XmlDownloadManager __4__this; // 0x40
			private WebRequest _req_5__2; // 0x48
			private ConfiguredTaskAwaitable<WebResponse> __u__1; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181A93160-0x0000000181A938F0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181A938F0-0x0000000181A93950
		}
	
		// Constructors
		public XmlDownloadManager(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal Stream GetStream(Uri uri, ICredentials credentials, IWebProxy proxy, RequestCachePolicy cachePolicy); // 0x0000000181AA2AC0-0x0000000181AA2BD0
		private Stream GetNonFileStream(Uri uri, ICredentials credentials, IWebProxy proxy, RequestCachePolicy cachePolicy); // 0x0000000181AA23E0-0x0000000181AA2870
		internal void Remove(string host); // 0x0000000181AA2BD0-0x0000000181AA2D20
		internal Task<Stream> GetStreamAsync(Uri uri, ICredentials credentials, IWebProxy proxy, RequestCachePolicy cachePolicy); // 0x0000000181AA2870-0x0000000181AA2AC0
		private async Task<Stream> GetNonFileStreamAsync(Uri uri, ICredentials credentials, IWebProxy proxy, RequestCachePolicy cachePolicy); // 0x0000000181AA2290-0x0000000181AA23E0
	}
}
