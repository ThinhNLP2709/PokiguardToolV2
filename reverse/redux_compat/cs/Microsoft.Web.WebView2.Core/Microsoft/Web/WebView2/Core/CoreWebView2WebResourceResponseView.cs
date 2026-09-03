/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2WebResourceResponseView // TypeDefIndex: 10625
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2WebResourceResponseView _nativeICoreWebView2WebResourceResponseViewValue; // 0x18
	
		// Properties
		internal ICoreWebView2WebResourceResponseView _nativeICoreWebView2WebResourceResponseView { get; set; } // 0x00000001813D8A90-0x00000001813D8BA0 0x00000001802FAF70-0x00000001802FAF80
		public CoreWebView2HttpResponseHeaders Headers { get; } // 0x00000001813D8610-0x00000001813D87D0 
		public string ReasonPhrase { get; } // 0x00000001813D87D0-0x00000001813D8930 
		public int StatusCode { get; } // 0x00000001813D8930-0x00000001813D8A90 
	
		// Nested types
		[CompilerGenerated]
		private struct _GetContentAsync_d__13 : IAsyncStateMachine // TypeDefIndex: 10626
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<Stream> __t__builder; // 0x08
			public CoreWebView2WebResourceResponseView __4__this; // 0x20
			private CoreWebView2WebResourceResponseViewGetContentCompletedHandler _handler_5__2; // 0x28
			private object __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001813DBF40-0x00000001813DC390
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813DC390-0x00000001813DC3F0
		}
	
		// Constructors
		internal CoreWebView2WebResourceResponseView(object rawCoreWebView2WebResourceResponseView); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public async Task<Stream> GetContentAsync(); // 0x00000001813D8540-0x00000001813D8610
	}
}
