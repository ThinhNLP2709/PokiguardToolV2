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
	[DisplayName("Text Data Provider")]
	public class TextDataProvider : ResourceProviderBase // TypeDefIndex: 13771
	{
		// Fields
		[CompilerGenerated]
		private bool _IgnoreFailures_k__BackingField; // 0x20
	
		// Properties
		public bool IgnoreFailures { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
	
		// Nested types
		internal class InternalOp // TypeDefIndex: 13772
		{
			// Fields
			private TextDataProvider m_Provider; // 0x10
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
			public void Start(ProvideHandle provideHandle, TextDataProvider rawProvider); // 0x000000018204EB00-0x000000018204EF10
			private bool WaitForCompletionHandler(); // 0x000000018204F2D0-0x000000018204F340
			private void RequestOperation_completed(AsyncOperation op); // 0x000000018204CF60-0x000000018204D1E0
			protected void CompleteOperation(string text, Exception exception); // 0x000000018204C490-0x000000018204C530
			private object ConvertText(string text); // 0x000000018204C5D0-0x000000018204C6B0
			protected virtual void SendWebRequest(string path); // 0x000000018204D980-0x000000018204DCF0
			[CompilerGenerated]
			private void _SendWebRequest_b__13_0(UnityWebRequestAsyncOperation asyncOperation); // 0x000000018204F050-0x000000018204F0F0
		}
	
		// Constructors
		public TextDataProvider(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual object Convert(Type type, string text); // 0x0000000180700320-0x0000000180700330
		public override void Provide(ProvideHandle provideHandle); // 0x000000018205A600-0x000000018205A690
	}
}
