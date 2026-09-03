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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class SceneController : MonoBehaviour // TypeDefIndex: 1703
{
	// Fields
	public LoadRoom loadRoom; // 0x20
	public Api api; // 0x28
	public ApiLoadRoom apiLoadRoom; // 0x30

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1704
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<long, bool> __9__3_1; // 0x08

		// Constructors
		static __c(); // 0x00000001805E9150-0x00000001805E91C0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal bool _LoadSceneByNameStart_b__3_1(long number); // 0x00000001805E87A0-0x00000001805E87B0
	}

	[CompilerGenerated]
	private sealed class _LoadSceneAfterApi_d__5 : IEnumerator<object> // TypeDefIndex: 1705
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public SceneController __4__this; // 0x20
		public string listCardUserIdJson; // 0x28
		public string sceneName; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterApi_d__5(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805E6150-0x00000001805E6330
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E6330-0x00000001805E6370
	}

	// Constructors
	public SceneController(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void LoadSceneByNameStart(string sceneName); // 0x00000001805E1650-0x00000001805E1920
	private long ExtractNumberFromName(string name); // 0x00000001805E13A0-0x00000001805E1480
	[IteratorStateMachine(typeof(_LoadSceneAfterApi_d__5))]
	private IEnumerator LoadSceneAfterApi(string sceneName, string listCardUserIdJson); // 0x00000001805E1550-0x00000001805E1600
	public void UnloadNewScene(); // 0x00000001805E1B80-0x00000001805E1D10
	public void HideNewScene(string newSceneName); // 0x00000001805E1480-0x00000001805E1550
	public void ShowNewScene(string newSceneName); // 0x00000001805E19B0-0x00000001805E1A80
	public void LoadSceneByName(string sceneName); // 0x00000001805E1920-0x00000001805E1970
	public void LoadSceneByIndex(int sceneIndex); // 0x00000001805E1600-0x00000001805E1650
	public void QuitGame(); // 0x00000001805E1970-0x00000001805E19B0
	public void ChangeSceneDauTruong(string sceneName); // 0x00000001805E1350-0x00000001805E13A0
	[CompilerGenerated]
	private long _LoadSceneByNameStart_b__3_0(Button card); // 0x00000001805E1A80-0x00000001805E1B80
}

