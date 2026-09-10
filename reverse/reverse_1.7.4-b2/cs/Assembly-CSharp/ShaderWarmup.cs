/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class ShaderWarmup // TypeDefIndex: 1424
{
	// Fields
	public const string RESOURCE_PATH = "Shaders/MatchShaderVariants"; // Metadata: 0x0068D07C
	private const int VARIANTS_PER_FRAME = 4; // Metadata: 0x0068D098
	private const int MAX_STEPS = 4000; // Metadata: 0x0068D099
	private static bool _started; // 0x00

	// Properties
	public static bool Started { get; } // 0x00000001805C4DA0-0x00000001805C4DE0 

	// Nested types
	[CompilerGenerated]
	private sealed class _WarmCo_d__6 : IEnumerator<object> // TypeDefIndex: 1425
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private ShaderVariantCollection _svc_5__2; // 0x20
		private int _steps_5__3; // 0x28
		private bool _progressiveOk_5__4; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WarmCo_d__6(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804AE160-0x00000001804AE190
		private bool MoveNext(); // 0x00000001805D6610-0x00000001805D6940
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D6940-0x00000001805D6980
	}

	// Methods
	[IteratorStateMachine(typeof(_WarmCo_d__6))]
	public static IEnumerator WarmCo(); // 0x00000001805C4D50-0x00000001805C4DA0
}

