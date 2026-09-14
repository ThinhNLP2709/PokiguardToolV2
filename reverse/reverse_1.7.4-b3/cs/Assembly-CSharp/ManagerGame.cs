/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerGame : MonoBehaviour // TypeDefIndex: 1969
{
	// Fields
	public static ManagerGame Instance; // 0x00
	public GameObject LoadingPanel; // 0x20
	public static Stack<string> sceneHistory; // 0x08
	private const float LOADING_STUCK_SEC = 25f; // Metadata: 0x005F03BA
	private float _loadingShownAt; // 0x28
	private GameObject _originalLoadingPanel; // 0x30

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__5 : IEnumerator<object> // TypeDefIndex: 1970
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerGame __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__5(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018097F180-0x000000018097F3D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018097F3D0-0x000000018097F410
	}

	// Constructors
	public ManagerGame(); // 0x000000018097F050-0x000000018097F0A0
	static ManagerGame(); // 0x000000018097F0A0-0x000000018097F180

	// Methods
	private void Awake(); // 0x000000018097CF10-0x000000018097D140
	private void Start(); // 0x000000018097D140-0x000000018097D1F0
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__5))]
	private IEnumerator LoadSceneAfterDelay(); // 0x000000018097D1F0-0x000000018097D290
	private void OnError(string error); // 0x000000018097D290-0x000000018097D5F0
	public void LoadScene(string nameScene); // 0x000000018097D5F0-0x000000018097DA20
	public void BackScene(); // 0x000000018097DA20-0x000000018097DC30
	public void RefreshCurrentUserInfo(); // 0x000000018097DC30-0x000000018097DD50
	public void ShowLoading(); // 0x000000018097DD50-0x000000018097DFA0
	public void HideLoading(); // 0x000000018097DFA0-0x000000018097E140
	public void HideOrphanLoadingOverlays(string reason); // 0x000000018097E140-0x000000018097E800
	private bool AnyWatchedLoadingActive(); // 0x000000018097E800-0x000000018097EB70
	private void Update(); // 0x000000018097EB70-0x000000018097F050
}

