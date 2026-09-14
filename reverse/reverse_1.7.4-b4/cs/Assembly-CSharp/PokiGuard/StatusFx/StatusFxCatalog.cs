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

namespace PokiGuard.StatusFx
{
	public static class StatusFxCatalog // TypeDefIndex: 2522
	{
		// Fields
		private static readonly Dictionary<string, Meta> _map; // 0x00
		private static readonly Dictionary<string, Sprite> _iconCache; // 0x08
		private static readonly Dictionary<string, Sprite[]> _frameCache; // 0x10
	
		// Nested types
		public struct Meta // TypeDefIndex: 2523
		{
			// Fields
			public string label; // 0x00
			public string iconName; // 0x08
			public Color color; // 0x10
			public bool isDebuff; // 0x20
			public bool showTurns; // 0x21
		}
	
		[CompilerGenerated]
		private sealed class _PrewarmFramesCo_d__13 : IEnumerator<object> // TypeDefIndex: 2524
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public string prefix; // 0x20
			public int maxPerStep; // 0x28
			public float budgetMs; // 0x2C
			private Stopwatch _sw_5__2; // 0x30
			private int _inStep_5__3; // 0x38
			private int _start_5__4; // 0x3C
			private Sprite _first_5__5; // 0x40
			private List<Sprite> _list_5__6; // 0x48
			private int _i_5__7; // 0x50
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _PrewarmFramesCo_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001808F4EA0-0x00000001808F4FB0
			private bool MoveNext(); // 0x0000000180BAAA40-0x0000000180BAB4E0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BAB4E0-0x0000000180BAB520
		}
	
		// Constructors
		static StatusFxCatalog(); // 0x0000000180BA9300-0x0000000180BAAA40
	
		// Methods
		private static Color C(float r, float g, float b); // 0x0000000180BA7DF0-0x0000000180BA7E10
		public static bool TryGet(string type, out Meta meta); // 0x0000000180BA7E10-0x0000000180BA80F0
		public static string PopupText(string type, string action, double value); // 0x0000000180BA80F0-0x0000000180BA84E0
		public static Sprite LoadIcon(string iconName); // 0x0000000180BA84E0-0x0000000180BA88E0
		public static Sprite[] LoadFrames(string prefix); // 0x0000000180BA88E0-0x0000000180BA8D70
		public static bool IsFramesWarm(string prefix); // 0x0000000180BA8D70-0x0000000180BA8E20
		public static void ClearCaches(); // 0x0000000180BA8E20-0x0000000180BA8EF0
		[IteratorStateMachine(typeof(_PrewarmFramesCo_d__13))]
		public static IEnumerator PrewarmFramesCo(string prefix, int maxPerStep, float budgetMs); // 0x0000000180BA8EF0-0x0000000180BA8FB0
		private static Sprite LoadFrame(string prefix, int index); // 0x0000000180BA8FB0-0x0000000180BA9300
	}
}
