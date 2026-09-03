/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerGame : MonoBehaviour // TypeDefIndex: 1341
{
	// Fields
	public static ManagerGame Instance; // 0x00
	public GameObject LoadingPanel; // 0x20
	public static Stack<string> sceneHistory; // 0x08
	private const float LOADING_STUCK_SEC = 25f; // Metadata: 0x0064D624
	private float _loadingShownAt; // 0x28
	private GameObject _originalLoadingPanel; // 0x30

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadSceneAfterDelay_d__5 : IEnumerator<object> // TypeDefIndex: 1342
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerGame __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadSceneAfterDelay_d__5(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180511680-0x0000000180511870
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180511870-0x00000001805118B0
	}

	// Constructors
	public ManagerGame(); // 0x00000001804FC920-0x00000001804FC930
	static ManagerGame(); // 0x00000001804FC890-0x00000001804FC920

	// Methods
	private void Awake(); // 0x00000001804FB800-0x00000001804FB8E0
	private void Start(); // 0x00000001804FC500-0x00000001804FC580
	[IteratorStateMachine(typeof(_LoadSceneAfterDelay_d__5))]
	private IEnumerator LoadSceneAfterDelay(); // 0x00000001804FBE10-0x00000001804FBE80
	private void OnError(string error); // 0x00000001804FC0E0-0x00000001804FC360
	public void LoadScene(string nameScene); // 0x00000001804FBE80-0x00000001804FC0E0
	public void BackScene(); // 0x00000001804FB8E0-0x00000001804FBA60
	public void RefreshCurrentUserInfo(); // 0x00000001804FC360-0x00000001804FC400
	public void ShowLoading(); // 0x00000001804FC400-0x00000001804FC500
	public void HideLoading(); // 0x00000001804FBA60-0x00000001804FBB20
	public void HideOrphanLoadingOverlays(string reason); // 0x00000001804FBB20-0x00000001804FBE10
	private bool AnyWatchedLoadingActive(); // 0x00000001804FB730-0x00000001804FB800
	private void Update(); // 0x00000001804FC580-0x00000001804FC890
}

