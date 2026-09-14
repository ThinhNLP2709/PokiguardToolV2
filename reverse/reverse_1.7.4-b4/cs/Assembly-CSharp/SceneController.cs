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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class SceneController : MonoBehaviour // TypeDefIndex: 2385
{
	// Fields
	public LoadRoom loadRoom; // 0x20
	public Api api; // 0x28
	public ApiLoadRoom apiLoadRoom; // 0x30

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 2386
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<long, bool> __9__3_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180B60CD0-0x0000000180B60D70
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal bool _LoadSceneByNameStart_b__3_1(long number); // 0x0000000180B60D70-0x0000000180B60D80
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterApi_d__5 : IEnumerator<object> // TypeDefIndex: 2387
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B60D80-0x0000000180B610A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B610A0-0x0000000180B610E0
	}

	// Constructors
	public SceneController(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void LoadSceneByNameStart(string sceneName); // 0x0000000180B5FC00-0x0000000180B60110
	private long ExtractNumberFromName(string name); // 0x0000000180B60110-0x0000000180B60370
	[IteratorStateMachine(typeof(_LoadSceneAfterApi_d__5))]
	private IEnumerator LoadSceneAfterApi(string sceneName, string listCardUserIdJson); // 0x0000000180B60370-0x0000000180B604D0
	public void UnloadNewScene(); // 0x0000000180B604D0-0x0000000180B60760
	public void HideNewScene(string newSceneName); // 0x0000000180B60760-0x0000000180B608D0
	public void ShowNewScene(string newSceneName); // 0x0000000180B608D0-0x0000000180B60A40
	public void LoadSceneByName(string sceneName); // 0x0000000180B60A40-0x0000000180B60AE0
	public void LoadSceneByIndex(int sceneIndex); // 0x0000000180B60AE0-0x0000000180B60B30
	public void QuitGame(); // 0x0000000180B60B30-0x0000000180B60BF0
	public void ChangeSceneDauTruong(string sceneName); // 0x0000000180B60BF0-0x0000000180B60C90
	[CompilerGenerated]
	private long _LoadSceneByNameStart_b__3_0(Button card); // 0x0000000180B60C90-0x0000000180B60CD0
}

