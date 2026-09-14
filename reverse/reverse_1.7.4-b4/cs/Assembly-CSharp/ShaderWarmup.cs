/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class ShaderWarmup // TypeDefIndex: 1809
{
	// Fields
	private static bool _started; // 0x00

	// Nested types
	[CompilerGenerated]
	private sealed class _WarmCo_d__6 : IEnumerator<object> // TypeDefIndex: 1810
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private ShaderVariantCollection _svc_5__2; // 0x20
		private int _steps_5__3; // 0x28
		private bool _progressiveOk_5__4; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WarmCo_d__6(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805EFDE0-0x00000001805EFE50
		private bool MoveNext(); // 0x00000001808EDDD0-0x00000001808EE320
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808EE320-0x00000001808EE360
	}

	// Methods
	[IteratorStateMachine(typeof(_WarmCo_d__6))]
	public static IEnumerator WarmCo(); // 0x00000001808EDD90-0x00000001808EDDD0
}

