/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.Util;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets.Initialization
{
	[Serializable]
	public class CacheInitialization : IInitializableObject // TypeDefIndex: 14115
	{
		// Properties
		public static string RootPath { get; } // 0x0000000181C857E0-0x0000000181C85850 
	
		// Nested types
		private class CacheInitOp : AsyncOperationBase<bool>, IUpdateReceiver // TypeDefIndex: 14116
		{
			// Fields
			private Func<bool> m_Callback; // 0x98
			private bool m_UpdateRequired; // 0xA0
	
			// Constructors
			public CacheInitOp(); // 0x0000000181C85420-0x0000000181C85460
	
			// Methods
			public void Init(Func<bool> callback); // 0x00000001806CCE20-0x00000001806CCE40
			protected override bool InvokeWaitForCompletion(); // 0x0000000181C852F0-0x0000000181C85350
			public void Update(float unscaledDeltaTime); // 0x0000000181C85350-0x0000000181C85420
			protected override void Execute(); // 0x0000000181C85250-0x0000000181C852F0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass1_0 // TypeDefIndex: 14117
		{
			// Fields
			public CacheInitialization __4__this; // 0x10
			public string id; // 0x18
			public string data; // 0x20
	
			// Constructors
			public __c__DisplayClass1_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _InitializeAsync_b__0(); // 0x0000000181C88600-0x0000000181C88750
		}
	
		// Constructors
		public CacheInitialization(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public bool Initialize(string id, string dataStr); // 0x0000000181C856A0-0x0000000181C857E0
		public virtual AsyncOperationHandle<bool> InitializeAsync(ResourceManager rm, string id, string data); // 0x0000000181C854E0-0x0000000181C856A0
	}
}
