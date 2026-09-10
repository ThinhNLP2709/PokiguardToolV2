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

public class ManagerGame : MonoBehaviour // TypeDefIndex: 1585
{
	// Fields
	public static ManagerGame Instance; // 0x00
	public GameObject LoadingPanel; // 0x20
	public static Stack<string> sceneHistory; // 0x08
	private const float LOADING_STUCK_SEC = 25f; // Metadata: 0x0068D50D
	private float _loadingShownAt; // 0x28
	private GameObject _originalLoadingPanel; // 0x30

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__5 : IEnumerator<object> // TypeDefIndex: 1586
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerGame __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__5(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180620140-0x0000000180620330
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180620330-0x0000000180620370
	}

	// Constructors
	public ManagerGame(); // 0x000000018060C360-0x000000018060C370
	static ManagerGame(); // 0x000000018060C2D0-0x000000018060C360

	// Methods
	private void Awake(); // 0x000000018060B240-0x000000018060B320
	private void Start(); // 0x000000018060BF40-0x000000018060BFC0
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__5))]
	private IEnumerator LoadSceneAfterDelay(); // 0x000000018060B850-0x000000018060B8C0
	private void OnError(string error); // 0x000000018060BB20-0x000000018060BDA0
	public void LoadScene(string nameScene); // 0x000000018060B8C0-0x000000018060BB20
	public void BackScene(); // 0x000000018060B320-0x000000018060B4A0
	public void RefreshCurrentUserInfo(); // 0x000000018060BDA0-0x000000018060BE40
	public void ShowLoading(); // 0x000000018060BE40-0x000000018060BF40
	public void HideLoading(); // 0x000000018060B4A0-0x000000018060B560
	public void HideOrphanLoadingOverlays(string reason); // 0x000000018060B560-0x000000018060B850
	private bool AnyWatchedLoadingActive(); // 0x000000018060B170-0x000000018060B240
	private void Update(); // 0x000000018060BFC0-0x000000018060C2D0
}

