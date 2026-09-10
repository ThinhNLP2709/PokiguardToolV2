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

public class MatchStartGateOverlay : MonoBehaviour // TypeDefIndex: 498
{
	// Fields
	private const float FailsafeSec = 35f; // Metadata: 0x0068B35E
	private const float MinShowSec = 2f; // Metadata: 0x0068B362
	private const float NoClockFallbackSec = 6f; // Metadata: 0x0068B366
	private static MatchStartGateOverlay _instance; // 0x00
	private UnityEngine.UI.Text _titleText; // 0x20
	private UnityEngine.UI.Text _readyText; // 0x28
	private float _shownAtUnscaled; // 0x30
	private bool _closing; // 0x34

	// Properties
	public static bool IsShowing { get; } // 0x000000018039EF60-0x000000018039EFD0 

	// Nested types
	[CompilerGenerated]
	private sealed class _WatchRoutine_d__20 : IEnumerator<object> // TypeDefIndex: 499
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchStartGateOverlay __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28
		private int _dotPhase_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WatchRoutine_d__20(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001803A6C90-0x00000001803A6F40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A6F40-0x00000001803A6F80
	}

	// Constructors
	public MatchStartGateOverlay(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static void Show(string subtitle = null); // 0x000000018039E9B0-0x000000018039EB30
	public static void HideNow(); // 0x000000018039E480-0x000000018039E560
	private void Awake(); // 0x000000018039DCE0-0x000000018039DD00
	private void Start(); // 0x000000018039EB30-0x000000018039EEF0
	private void OnDestroy(); // 0x000000018039E560-0x000000018039E920
	private void HandleGateClosed(); // 0x000000018039E100-0x000000018039E170
	private void HandleGameOver(string winner); // 0x000000018039E100-0x000000018039E170
	private void HandleReadyState(int ready, int total); // 0x000000018039E3E0-0x000000018039E480
	private void SetReadyLabel(string text); // 0x000000018039E920-0x000000018039E9B0
	private void Close(); // 0x000000018039E100-0x000000018039E170
	[IteratorStateMachine(typeof(_WatchRoutine_d__20))]
	private IEnumerator WatchRoutine(); // 0x000000018039EEF0-0x000000018039EF60
	private void BuildUI(); // 0x000000018039DD00-0x000000018039E100
	private static UnityEngine.UI.Text CreateText(Transform parent, string name, string content, Font font, int size, Color color, Vector2 anchoredPos); // 0x000000018039E170-0x000000018039E3E0
}

