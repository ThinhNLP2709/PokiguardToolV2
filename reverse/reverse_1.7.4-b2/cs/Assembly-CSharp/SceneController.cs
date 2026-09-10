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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class SceneController : MonoBehaviour // TypeDefIndex: 1981
{
	// Fields
	public LoadRoom loadRoom; // 0x20
	public Api api; // 0x28
	public ApiLoadRoom apiLoadRoom; // 0x30

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1982
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<long, bool> __9__3_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180727620-0x0000000180727690
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal bool _LoadSceneByNameStart_b__3_1(long number); // 0x0000000180726B90-0x0000000180726BA0
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterApi_d__5 : IEnumerator<object> // TypeDefIndex: 1983
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SceneController __4__this; // 0x20
		public string listCardUserIdJson; // 0x28
		public string sceneName; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterApi_d__5(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180724940-0x0000000180724B20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180724B20-0x0000000180724B60
	}

	// Constructors
	public SceneController(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public void LoadSceneByNameStart(string sceneName); // 0x000000018071E900-0x000000018071EBD0
	private long ExtractNumberFromName(string name); // 0x000000018071E650-0x000000018071E730
	[IteratorStateMachine(typeof(_LoadSceneAfterApi_d__5))]
	private IEnumerator LoadSceneAfterApi(string sceneName, string listCardUserIdJson); // 0x000000018071E800-0x000000018071E8B0
	public void UnloadNewScene(); // 0x000000018071EE30-0x000000018071EFC0
	public void HideNewScene(string newSceneName); // 0x000000018071E730-0x000000018071E800
	public void ShowNewScene(string newSceneName); // 0x000000018071EC60-0x000000018071ED30
	public void LoadSceneByName(string sceneName); // 0x000000018071EBD0-0x000000018071EC20
	public void LoadSceneByIndex(int sceneIndex); // 0x000000018071E8B0-0x000000018071E900
	public void QuitGame(); // 0x000000018071EC20-0x000000018071EC60
	public void ChangeSceneDauTruong(string sceneName); // 0x000000018071E600-0x000000018071E650
	[CompilerGenerated]
	private long _LoadSceneByNameStart_b__3_0(Button card); // 0x000000018071ED30-0x000000018071EE30
}

