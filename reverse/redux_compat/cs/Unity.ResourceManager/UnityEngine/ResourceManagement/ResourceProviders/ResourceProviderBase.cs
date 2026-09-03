/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.Util;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	public abstract class ResourceProviderBase : IResourceProvider, IInitializableObject // TypeDefIndex: 13762
	{
		// Fields
		protected string m_ProviderId; // 0x10
		protected ProviderBehaviourFlags m_BehaviourFlags; // 0x18
	
		// Properties
		public virtual string ProviderId { get; } // 0x0000000182057D10-0x0000000182057D70 
		ProviderBehaviourFlags IResourceProvider.BehaviourFlags { get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Nested types
		private class BaseInitAsyncOp : AsyncOperationBase<bool> // TypeDefIndex: 13763
		{
			// Fields
			private Func<bool> m_CallBack; // 0x98
	
			// Constructors
			public BaseInitAsyncOp(); // 0x0000000182047F40-0x0000000182047F80
	
			// Methods
			public void Init(Func<bool> callback); // 0x00000001806CCE20-0x00000001806CCE40
			protected override bool InvokeWaitForCompletion(); // 0x0000000180DB13C0-0x0000000180DB1410
			protected override void Execute(); // 0x0000000182047E90-0x0000000182047F40
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass10_0 // TypeDefIndex: 13764
		{
			// Fields
			public ResourceProviderBase __4__this; // 0x10
			public string id; // 0x18
			public string data; // 0x20
	
			// Constructors
			public __c__DisplayClass10_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _InitializeAsync_b__0(); // 0x000000018205A9E0-0x000000018205AA20
		}
	
		// Constructors
		protected ResourceProviderBase(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual bool Initialize(string id, string data); // 0x0000000182057CE0-0x0000000182057D10
		public virtual bool CanProvide(Type t, IResourceLocation location); // 0x0000000182057AD0-0x0000000182057B20
		public override string ToString(); // 0x00000001817AAE10-0x00000001817AAE30
		public virtual void Release(IResourceLocation location, object obj); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual Type GetDefaultType(IResourceLocation location); // 0x0000000181742460-0x00000001817424A0
		public abstract void Provide(ProvideHandle provideHandle);
		public virtual AsyncOperationHandle<bool> InitializeAsync(ResourceManager rm, string id, string data); // 0x0000000182057B20-0x0000000182057CE0
	}
}
