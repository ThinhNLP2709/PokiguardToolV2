/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
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
	public class XmlUrlResolver : XmlResolver // TypeDefIndex: 6898
	{
		// Fields
		private static object s_DownloadManager; // 0x00
		private ICredentials _credentials; // 0x10
		private IWebProxy _proxy; // 0x18
		private RequestCachePolicy _cachePolicy; // 0x20
	
		// Properties
		private static XmlDownloadManager DownloadManager { get; } // 0x0000000181AA77E0-0x0000000181AA78C0 
	
		// Nested types
		[CompilerGenerated]
		private struct _GetEntityAsync_d__15 : IAsyncStateMachine // TypeDefIndex: 6899
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<object> __t__builder; // 0x08
			public Type ofObjectToReturn; // 0x20
			public Uri absoluteUri; // 0x28
			public XmlUrlResolver __4__this; // 0x30
			private ConfiguredTaskAwaitable<Stream> __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x0000000181A92E40-0x0000000181A93100
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181A93100-0x0000000181A93160
		}
	
		// Constructors
		public XmlUrlResolver(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn); // 0x0000000181AA75E0-0x0000000181AA77D0
		public override Uri ResolveUri(Uri baseUri, string relativeUri); // 0x0000000181AA77D0-0x0000000181AA77E0
		public override async Task<object> GetEntityAsync(Uri absoluteUri, string role, Type ofObjectToReturn); // 0x0000000181AA74B0-0x0000000181AA75E0
	}
}
