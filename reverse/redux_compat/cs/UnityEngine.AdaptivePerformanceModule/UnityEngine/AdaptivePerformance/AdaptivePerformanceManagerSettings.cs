/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 26: UnityEngine.AdaptivePerformanceModule.dll - Assembly: UnityEngine.AdaptivePerformanceModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14126-14224

namespace UnityEngine.AdaptivePerformance
{
	public sealed class AdaptivePerformanceManagerSettings : ScriptableObject // TypeDefIndex: 14183
	{
		// Fields
		[HideInInspector]
		private bool m_InitializationComplete; // 0x18
		[SerializeField]
		[Tooltip("Determines if the Adaptive Performance Manager instance is responsible for creating and destroying the appropriate loader instance.")]
		private bool m_AutomaticLoading; // 0x19
		[SerializeField]
		[Tooltip("Determines if the Adaptive Performance Manager instance is responsible for starting and stopping subsystems for the active loader instance.")]
		private bool m_AutomaticRunning; // 0x1A
		[SerializeField]
		[Tooltip("List of Adaptive Performance Loader instances arranged in desired load order.")]
		private List<AdaptivePerformanceLoader> m_Loaders; // 0x20
		[AutoStaticsCleanupOnCodeReload]
		[HideInInspector]
		private static AdaptivePerformanceLoader s_ActiveLoader; // 0x00
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
		// Properties
		public bool automaticLoading { get; set; } // 0x0000000181780E10-0x0000000181780E20 0x0000000181780E30-0x0000000181780E40
		public bool automaticRunning { get; set; } // 0x0000000181780E00-0x0000000181780E10 0x0000000181780E20-0x0000000181780E30
		public List<AdaptivePerformanceLoader> loaders { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public bool isInitializationComplete { get; } // 0x0000000180F9E350-0x0000000180F9E360 
		[HideInInspector]
		public AdaptivePerformanceLoader activeLoader { get; private set; } // 0x0000000182134A80-0x0000000182134AD0 0x0000000182134AD0-0x0000000182134B40
	
		// Nested types
		[CompilerGenerated]
		private sealed class _InitializeLoader_d__21 : IEnumerator<object> // TypeDefIndex: 14184
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public AdaptivePerformanceManagerSettings __4__this; // 0x20
			private List<AdaptivePerformanceLoader> __7__wrap1; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _InitializeLoader_d__21(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000182145710-0x00000001821457A0
			private bool MoveNext(); // 0x00000001821453B0-0x00000001821456D0
			private void __m__Finally1(); // 0x000000018206C150-0x000000018206C170
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001821456D0-0x0000000182145710
		}
	
		// Constructors
		public AdaptivePerformanceManagerSettings(); // 0x0000000182134A00-0x0000000182134A80
		static AdaptivePerformanceManagerSettings(); // 0x00000001821348B0-0x0000000182134A00
	
		// Methods
		public T ActiveLoaderAs<T>()
			where T : AdaptivePerformanceLoader;
		internal void InitializeLoaderSync(); // 0x0000000182134270-0x0000000182134500
		[IteratorStateMachine(typeof(_InitializeLoader_d__21))]
		internal IEnumerator InitializeLoader(); // 0x0000000182134500-0x0000000182134570
		internal void StartSubsystems(); // 0x00000001821345A0-0x00000001821346F0
		internal void StopSubsystems(); // 0x00000001821346F0-0x0000000182134840
		internal void DeinitializeLoader(); // 0x0000000182134100-0x0000000182134270
		private void OnDisable(); // 0x0000000182134580-0x00000001821345A0
		private void OnDestroy(); // 0x0000000182134570-0x0000000182134580
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182134840-0x00000001821348B0
	}
}
