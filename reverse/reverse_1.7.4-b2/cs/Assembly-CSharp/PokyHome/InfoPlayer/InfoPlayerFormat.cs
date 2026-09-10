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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	public static class InfoPlayerFormat // TypeDefIndex: 2388
	{
		// Fields
		public const string Placeholder = "\u2014"; // Metadata: 0x0068EE29
		public const int NameLimit = 24; // Metadata: 0x0068EE2D
		private const char TagOpenReplacement = '\x2039'; // Metadata: 0x0068EE2E
		private const string Ellipsis = "\u2026"; // Metadata: 0x0068EE30
		private static readonly StringBuilder Builder; // 0x00
	
		// Nested types
		[CompilerGenerated]
		private sealed class _AwaitSprite_d__9 : IEnumerator<object> // TypeDefIndex: 2389
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _AwaitSprite_d__9(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
			private bool MoveNext(); // 0x00000001807F3C30-0x00000001807F3DC0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001807F3DC0-0x00000001807F3E00
		}
	
		// Constructors
		static InfoPlayerFormat(); // 0x00000001807DD910-0x00000001807DD980
	
		// Methods
		public static string Number(long value); // 0x00000001807DD850-0x00000001807DD8A0
		public static string Rank(long value); // 0x00000001807DD8A0-0x00000001807DD910
		public static string Clean(string raw, int maxLength); // 0x00000001807DD640-0x00000001807DD820
		public static int ElementOrZero(int[] values, int index); // 0x00000001807DD820-0x00000001807DD850
		[IteratorStateMachine(typeof(_AwaitSprite_d__9))]
		public static IEnumerator AwaitSprite(string resourcePath, Action<Sprite> done, float timeoutSeconds = 15f /* Metadata: 0x0068EE25 */); // 0x00000001807DD5A0-0x00000001807DD640
	}
}
