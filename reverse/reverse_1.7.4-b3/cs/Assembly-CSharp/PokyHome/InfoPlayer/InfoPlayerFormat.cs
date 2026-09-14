/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	public static class InfoPlayerFormat // TypeDefIndex: 2833
	{
		// Fields
		private static readonly StringBuilder Builder; // 0x00
	
		// Nested types
		[CompilerGenerated]
		private sealed class _AwaitSprite_d__9 : IEnumerator<object> // TypeDefIndex: 2834
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public string resourcePath; // 0x20
			public Action<Sprite> done; // 0x28
			public float timeoutSeconds; // 0x30
			private float _deadline_5__2; // 0x34
			private WaitForSecondsRealtime _wait_5__3; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _AwaitSprite_d__9(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
			private bool MoveNext(); // 0x0000000180CF3590-0x0000000180CF37A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180CF37A0-0x0000000180CF37E0
		}
	
		// Constructors
		static InfoPlayerFormat(); // 0x0000000180CF3490-0x0000000180CF3590
	
		// Methods
		public static string Number(long value); // 0x0000000180CF2F60-0x0000000180CF3030
		public static string Rank(long value); // 0x0000000180CF3030-0x0000000180CF3130
		public static string Clean(string raw, int maxLength); // 0x0000000180CF3130-0x0000000180CF3340
		public static int ElementOrZero(int[] values, int index); // 0x0000000180CF3340-0x0000000180CF3370
		[IteratorStateMachine(typeof(_AwaitSprite_d__9))]
		public static IEnumerator AwaitSprite(string resourcePath, Action<Sprite> done, float timeoutSeconds = 15f /* Metadata: 0x005F1CAC */); // 0x0000000180CF3370-0x0000000180CF3490
	}
}
