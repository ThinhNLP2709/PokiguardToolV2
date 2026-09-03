/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 59: UnityEngine.ContentLoadModule.dll - Assembly: UnityEngine.ContentLoadModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15722-15736

namespace Unity.Loading.LowLevel
{
	[NativeHeader("Modules/ContentLoad/Public/L0LoadingSystem.bindings.h")]
	internal struct LoadingResponseQueue : IDisposable // TypeDefIndex: 15732
	{
		// Fields
		internal IntPtr m_Ptr; // 0x00
	
		// Constructors
		public LoadingResponseQueue(); // 0x0000000182175A00-0x0000000182175A50
	
		// Methods
		public unsafe int ConsumeResults(AsyncResult* outResults, int maxResults); // 0x00000001821757B0-0x0000000182175800
		public void Dispose(); // 0x0000000182175800-0x0000000182175850
		[FreeFunction("ContentLoad::L0Bindings::ResponseQueue_Create", true)]
		private static LoadingResponseQueue ResponseQueue_Create(); // 0x0000000182175940-0x0000000182175980
		[FreeFunction("ContentLoad::L0Bindings::ResponseQueue_Release", true)]
		private static void ResponseQueue_Release(LoadingResponseQueue queue); // 0x00000001821759C0-0x0000000182175A00
		[FreeFunction("ContentLoad::L0Bindings::ResponseQueue_ConsumeResults", true)]
		private static unsafe int ResponseQueue_ConsumeResults(LoadingResponseQueue queue, AsyncResult* outResults, int maxResults); // 0x00000001821758B0-0x0000000182175900
		private static void ResponseQueue_Create_Injected(); // 0x0000000182175900-0x0000000182175940
		private static void ResponseQueue_Release_Injected(in LoadingResponseQueue queue); // 0x0000000182175980-0x00000001821759C0
		private static unsafe int ResponseQueue_ConsumeResults_Injected(in LoadingResponseQueue queue, AsyncResult* outResults, int maxResults); // 0x0000000182175850-0x00000001821758B0
	}
}
