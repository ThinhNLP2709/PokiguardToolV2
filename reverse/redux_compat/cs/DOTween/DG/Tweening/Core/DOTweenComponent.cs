/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Core
{
	[AddComponentMenu("")]
	public class DOTweenComponent : MonoBehaviour, IDOTweenInit // TypeDefIndex: 13502
	{
		// Fields
		public int inspectorUpdater; // 0x20
		private float _unscaledTime; // 0x24
		private float _unscaledDeltaTime; // 0x28
		private bool _paused; // 0x2C
		private float _pausedTime; // 0x30
		private bool _isQuitting; // 0x34
		private bool _duplicateToDestroy; // 0x35
	
		// Nested types
		[CompilerGenerated]
		private sealed class _WaitForCompletion_d__17 : IEnumerator<object> // TypeDefIndex: 13503
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Tween t; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _WaitForCompletion_d__17(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x000000018072BE10-0x000000018072BE80
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018072BE80-0x000000018072BEC0
		}
	
		[CompilerGenerated]
		private sealed class _WaitForElapsedLoops_d__20 : IEnumerator<object> // TypeDefIndex: 13504
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Tween t; // 0x20
			public int elapsedLoops; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _WaitForElapsedLoops_d__20(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x000000018072BEC0-0x000000018072BF30
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018072BF30-0x000000018072BF70
		}
	
		[CompilerGenerated]
		private sealed class _WaitForKill_d__19 : IEnumerator<object> // TypeDefIndex: 13505
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Tween t; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _WaitForKill_d__19(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x000000018072BF70-0x000000018072BFD0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018072BFD0-0x000000018072C010
		}
	
		[CompilerGenerated]
		private sealed class _WaitForPosition_d__21 : IEnumerator<object> // TypeDefIndex: 13506
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Tween t; // 0x20
			public float position; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _WaitForPosition_d__21(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x000000018072C010-0x000000018072C090
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018072C090-0x000000018072C0D0
		}
	
		[CompilerGenerated]
		private sealed class _WaitForRewind_d__18 : IEnumerator<object> // TypeDefIndex: 13507
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Tween t; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _WaitForRewind_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x0000000180739720-0x00000001807397B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807397B0-0x00000001807397F0
		}
	
		[CompilerGenerated]
		private sealed class _WaitForStart_d__22 : IEnumerator<object> // TypeDefIndex: 13508
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Tween t; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _WaitForStart_d__22(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x00000001807397F0-0x0000000180739860
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180739860-0x00000001807398A0
		}
	
		// Constructors
		public DOTweenComponent(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void Awake(); // 0x000000018071E4B0-0x000000018071E830
		private void Start(); // 0x000000018071F330-0x000000018071F3E0
		private void Update(); // 0x000000018071F3E0-0x000000018071F590
		private void LateUpdate(); // 0x000000018071EB70-0x000000018071EC50
		private void FixedUpdate(); // 0x000000018071EA30-0x000000018071EB70
		private void OnDrawGizmos(); // 0x000000018071F1A0-0x000000018071F2C0
		private void OnDestroy(); // 0x000000018071ED00-0x000000018071F1A0
		public void OnApplicationPause(bool pauseStatus); // 0x000000018071EC50-0x000000018071ECB0
		private void OnApplicationQuit(); // 0x000000018071ECB0-0x000000018071ED00
		public IDOTweenInit SetCapacity(int tweenersCapacity, int sequencesCapacity); // 0x000000018071F2C0-0x000000018071F330
		internal IEnumerator WaitForCompletion(Tween t); // 0x000000018071F590-0x000000018071F600
		internal IEnumerator WaitForRewind(Tween t); // 0x000000018071F770-0x000000018071F7E0
		internal IEnumerator WaitForKill(Tween t); // 0x000000018071F680-0x000000018071F6F0
		internal IEnumerator WaitForElapsedLoops(Tween t, int elapsedLoops); // 0x000000018071F600-0x000000018071F680
		internal IEnumerator WaitForPosition(Tween t, float position); // 0x000000018071F6F0-0x000000018071F770
		internal IEnumerator WaitForStart(Tween t); // 0x000000018071F7E0-0x000000018071F850
		internal static void Create(); // 0x000000018071E830-0x000000018071E950
		internal static void DestroyInstance(); // 0x000000018071E950-0x000000018071EA30
	}
}
