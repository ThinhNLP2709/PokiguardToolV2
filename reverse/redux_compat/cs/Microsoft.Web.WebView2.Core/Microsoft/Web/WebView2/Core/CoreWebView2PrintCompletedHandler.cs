/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	internal class CoreWebView2PrintCompletedHandler : ICoreWebView2PrintCompletedHandler, INotifyCompletion // TypeDefIndex: 10771
	{
		// Fields
		[CompilerGenerated]
		private CoreWebView2PrintStatus _AsyncReturnValue_k__BackingField; // 0x10
		[CompilerGenerated]
		private int _errCode_k__BackingField; // 0x14
		private Action continuation; // 0x18
		[CompilerGenerated]
		private bool _IsCompleted_k__BackingField; // 0x20
	
		// Properties
		public CoreWebView2PrintStatus AsyncReturnValue { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public int errCode { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public bool IsCompleted { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
	
		// Constructors
		public CoreWebView2PrintCompletedHandler(); // 0x00000001813C7360-0x00000001813C7380
	
		// Methods
		public void Invoke(int errCode, COREWEBVIEW2_PRINT_STATUS value); // 0x00000001813DF190-0x00000001813DF1C0
		public CoreWebView2PrintCompletedHandler GetAwaiter(); // 0x0000000180370C60-0x0000000180370C70
		public void OnCompleted(Action continuation); // 0x00000001813C7310-0x00000001813C7360
		public CoreWebView2PrintStatus GetResult(); // 0x00000001802E64B0-0x00000001802E64C0
	}
}
