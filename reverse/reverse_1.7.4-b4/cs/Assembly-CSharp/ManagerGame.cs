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

public class ManagerGame : MonoBehaviour // TypeDefIndex: 1971
{
	// Fields
	public static ManagerGame Instance; // 0x00
	public GameObject LoadingPanel; // 0x20
	public static Stack<string> sceneHistory; // 0x08
	private const float LOADING_STUCK_SEC = 25f; // Metadata: 0x005F178B
	private float _loadingShownAt; // 0x28
	private GameObject _originalLoadingPanel; // 0x30

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__5 : IEnumerator<object> // TypeDefIndex: 1972
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001809827D0-0x0000000180982A20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180982A20-0x0000000180982A60
	}

	// Constructors
	public ManagerGame(); // 0x00000001809826A0-0x00000001809826F0
	static ManagerGame(); // 0x00000001809826F0-0x00000001809827D0

	// Methods
	private void Awake(); // 0x0000000180980560-0x0000000180980790
	private void Start(); // 0x0000000180980790-0x0000000180980840
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__5))]
	private IEnumerator LoadSceneAfterDelay(); // 0x0000000180980840-0x00000001809808E0
	private void OnError(string error); // 0x00000001809808E0-0x0000000180980C40
	public void LoadScene(string nameScene); // 0x0000000180980C40-0x0000000180981070
	public void BackScene(); // 0x0000000180981070-0x0000000180981280
	public void RefreshCurrentUserInfo(); // 0x0000000180981280-0x00000001809813A0
	public void ShowLoading(); // 0x00000001809813A0-0x00000001809815F0
	public void HideLoading(); // 0x00000001809815F0-0x0000000180981790
	public void HideOrphanLoadingOverlays(string reason); // 0x0000000180981790-0x0000000180981E50
	private bool AnyWatchedLoadingActive(); // 0x0000000180981E50-0x00000001809821C0
	private void Update(); // 0x00000001809821C0-0x00000001809826A0
}

