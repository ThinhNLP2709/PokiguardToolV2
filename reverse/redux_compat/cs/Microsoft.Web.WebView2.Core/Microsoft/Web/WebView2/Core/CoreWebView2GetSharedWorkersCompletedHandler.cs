/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	internal class CoreWebView2GetSharedWorkersCompletedHandler : ICoreWebView2GetSharedWorkersCompletedHandler, INotifyCompletion // TypeDefIndex: 10757
	{
		// Fields
		[CompilerGenerated]
		private IReadOnlyList<CoreWebView2SharedWorker> _AsyncReturnValue_k__BackingField; // 0x10
		[CompilerGenerated]
		private int _errCode_k__BackingField; // 0x18
		private Action continuation; // 0x20
		[CompilerGenerated]
		private bool _IsCompleted_k__BackingField; // 0x28
	
		// Properties
		public IReadOnlyList<CoreWebView2SharedWorker> AsyncReturnValue { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public int errCode { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public bool IsCompleted { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
	
		// Constructors
		public CoreWebView2GetSharedWorkersCompletedHandler(); // 0x00000001813C72C0-0x00000001813C72E0
	
		// Methods
		public void Invoke(int errCode, ICoreWebView2SharedWorkerCollectionView value); // 0x00000001813DEDF0-0x00000001813DEE60
		public CoreWebView2GetSharedWorkersCompletedHandler GetAwaiter(); // 0x0000000180370C60-0x0000000180370C70
		public void OnCompleted(Action continuation); // 0x00000001813C7270-0x00000001813C72C0
		public IReadOnlyList<CoreWebView2SharedWorker> GetResult(); // 0x0000000180377550-0x0000000180377560
	}
}
