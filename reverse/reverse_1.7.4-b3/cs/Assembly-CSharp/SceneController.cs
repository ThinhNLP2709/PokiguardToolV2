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

public class SceneController : MonoBehaviour // TypeDefIndex: 2378
{
	// Fields
	public LoadRoom loadRoom; // 0x20
	public Api api; // 0x28
	public ApiLoadRoom apiLoadRoom; // 0x30

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2379
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<long, bool> __9__3_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180B53990-0x0000000180B53A30
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _LoadSceneByNameStart_b__3_1(long number); // 0x0000000180B53A30-0x0000000180B53A40
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterApi_d__5 : IEnumerator<object> // TypeDefIndex: 2380
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SceneController __4__this; // 0x20
		public string listCardUserIdJson; // 0x28
		public string sceneName; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterApi_d__5(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180B53A40-0x0000000180B53D60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B53D60-0x0000000180B53DA0
	}

	// Constructors
	public SceneController(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void LoadSceneByNameStart(string sceneName); // 0x0000000180B528C0-0x0000000180B52DD0
	private long ExtractNumberFromName(string name); // 0x0000000180B52DD0-0x0000000180B53030
	[IteratorStateMachine(typeof(_LoadSceneAfterApi_d__5))]
	private IEnumerator LoadSceneAfterApi(string sceneName, string listCardUserIdJson); // 0x0000000180B53030-0x0000000180B53190
	public void UnloadNewScene(); // 0x0000000180B53190-0x0000000180B53420
	public void HideNewScene(string newSceneName); // 0x0000000180B53420-0x0000000180B53590
	public void ShowNewScene(string newSceneName); // 0x0000000180B53590-0x0000000180B53700
	public void LoadSceneByName(string sceneName); // 0x0000000180B53700-0x0000000180B537A0
	public void LoadSceneByIndex(int sceneIndex); // 0x0000000180B537A0-0x0000000180B537F0
	public void QuitGame(); // 0x0000000180B537F0-0x0000000180B538B0
	public void ChangeSceneDauTruong(string sceneName); // 0x0000000180B538B0-0x0000000180B53950
	[CompilerGenerated]
	private long _LoadSceneByNameStart_b__3_0(Button card); // 0x0000000180B53950-0x0000000180B53990
}

