/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class LoginArt // TypeDefIndex: 1018
{
	// Fields
	private static readonly HashSet<string> _warned; // 0x00
	private static readonly List<Pending> _pending; // 0x08

	// Nested types
	private struct Pending // TypeDefIndex: 1019
	{
		// Fields
		public Image img; // 0x00
		public string name; // 0x08
		public Image.Type type; // 0x10
		public Color waiting; // 0x14
		public Color ready; // 0x24
		public bool preserve; // 0x34
		public string fallback; // 0x38
		public Action onReady; // 0x40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 1020
	{
		// Fields
		public Sprite got; // 0x10

		// Constructors
		public __c__DisplayClass26_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _AwaitTexture_b__0(Sprite sp); // 0x00000001802D8A80-0x00000001802D8AE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass27_0 // TypeDefIndex: 1021
	{
		// Fields
		public Image img; // 0x10
		public Color ready; // 0x18
		public Action onReady; // 0x28

		// Constructors
		public __c__DisplayClass27_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(Sprite sp); // 0x0000000180635F50-0x0000000180636150
	}

	[CompilerGenerated]
	private sealed class _AwaitTexture_d__26 : IEnumerator<object> // TypeDefIndex: 1022
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string path; // 0x20
		private __c__DisplayClass26_0 __8__1; // 0x28
		public Action<Texture2D> onReady; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AwaitTexture_d__26(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180636150-0x0000000180636710
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180636710-0x0000000180636750
	}

	// Constructors
	static LoginArt(); // 0x0000000180635D40-0x0000000180635F50

	// Methods
	public static Sprite Load(string name, string fallbackInfoPlayerName = null); // 0x0000000180633F70-0x0000000180634120
	public static Texture2D Tex(string name, Action<Texture2D> onReady = null); // 0x0000000180634120-0x00000001806345E0
	[IteratorStateMachine(typeof(_AwaitTexture_d__26))]
	private static IEnumerator AwaitTexture(string path, Action<Texture2D> onReady); // 0x00000001806345E0-0x00000001806346F0
	public static void Bind(MonoBehaviour host, Image img, string name, Image.Type type, Color waiting, Color ready, bool preserveAspect = false /* Metadata: 0x005EF2C4 */, string fallbackInfoPlayerName = null, Action onReady = null); // 0x00000001806346F0-0x0000000180634F50
	private static void Fire(Action onReady); // 0x0000000180634F50-0x0000000180634FF0
	private static void Remember(Image img, string name, Image.Type type, Color waiting, Color ready, bool preserve, string fallback, Action onReady); // 0x0000000180634FF0-0x0000000180635610
	public static void Refresh(Transform root, MonoBehaviour host); // 0x0000000180635610-0x0000000180635B70
	private static void WarnOnce(string name, string why); // 0x0000000180635B70-0x0000000180635D40
}

