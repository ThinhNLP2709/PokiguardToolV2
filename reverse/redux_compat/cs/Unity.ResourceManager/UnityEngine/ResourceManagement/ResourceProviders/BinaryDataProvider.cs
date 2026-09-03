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
	[DisplayName("Binary Data Provider")]
	public class BinaryDataProvider : ResourceProviderBase // TypeDefIndex: 13744
	{
		// Fields
		[CompilerGenerated]
		private bool _IgnoreFailures_k__BackingField; // 0x20
	
		// Properties
		public bool IgnoreFailures { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
	
		// Nested types
		internal class InternalOp // TypeDefIndex: 13745
		{
			// Fields
			private BinaryDataProvider m_Provider; // 0x10
			private UnityWebRequestAsyncOperation m_RequestOperation; // 0x18
			private WebRequestQueueOperation m_RequestQueueOperation; // 0x20
			private ProvideHandle m_PI; // 0x28
			private bool m_IgnoreFailures; // 0x40
			private bool m_Complete; // 0x41
			private int m_Timeout; // 0x44
	
			// Constructors
			public InternalOp(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			private float GetPercentComplete(); // 0x0000000182044EC0-0x0000000182044EE0
			public void Start(ProvideHandle provideHandle, BinaryDataProvider rawProvider); // 0x000000018204E170-0x000000018204E600
			private bool WaitForCompletionHandler(); // 0x000000018204F260-0x000000018204F2D0
			private void RequestOperation_completed(AsyncOperation op); // 0x000000018204CCE0-0x000000018204CF60
			protected void CompleteOperation(byte[] data, Exception exception); // 0x000000018204C530-0x000000018204C5D0
			private object ConvertBytes(byte[] data); // 0x000000018204C5D0-0x000000018204C6B0
			protected virtual void SendWebRequest(string path); // 0x000000018204D410-0x000000018204D6C0
			[CompilerGenerated]
			private void _SendWebRequest_b__13_0(UnityWebRequestAsyncOperation asyncOperation); // 0x000000018204EFB0-0x000000018204F050
		}
	
		// Constructors
		public BinaryDataProvider(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual object Convert(Type type, byte[] data); // 0x0000000180700320-0x0000000180700330
		public override void Provide(ProvideHandle provideHandle); // 0x0000000182048360-0x00000001820483F0
	}
}
