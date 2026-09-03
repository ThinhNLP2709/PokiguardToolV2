/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	[DisplayName("Cached File Provider")]
	public class CachedFileProvider : ResourceProviderBase // TypeDefIndex: 13748
	{
		// Nested types
		internal class InternalOp // TypeDefIndex: 13749
		{
			// Fields
			private CachedFileProvider m_Provider; // 0x10
			private UnityWebRequestAsyncOperation m_RequestOperation; // 0x18
			private WebRequestQueueOperation m_RequestQueueOperation; // 0x20
			private ProvideHandle m_PI; // 0x28
			private bool m_IgnoreFailures; // 0x40
			private bool m_Complete; // 0x41
			private int m_Timeout; // 0x44
			private string m_CachePath; // 0x48
	
			// Constructors
			public InternalOp(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			private float GetPercentComplete(); // 0x0000000182044EC0-0x0000000182044EE0
			public void Start(ProvideHandle provideHandle, CachedFileProvider rawProvider); // 0x000000018204DCF0-0x000000018204E170
			private bool WaitForCompletionHandler(); // 0x000000018204F100-0x000000018204F170
			private void RequestOperation_completed(AsyncOperation op); // 0x000000018204D1E0-0x000000018204D410
			protected virtual void SendWebRequest(string remotePath, string cachePath); // 0x000000018204D6C0-0x000000018204D980
			[CompilerGenerated]
			private void _SendWebRequest_b__12_0(UnityWebRequestAsyncOperation asyncOperation); // 0x000000018204EF10-0x000000018204EFB0
		}
	
		// Constructors
		public CachedFileProvider(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override void Provide(ProvideHandle provideHandle); // 0x0000000182049380-0x0000000182049410
	}
}
