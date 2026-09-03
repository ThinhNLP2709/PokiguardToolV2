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

public class MatchStartGateOverlay : MonoBehaviour // TypeDefIndex: 429
{
	// Fields
	private const float FailsafeSec = 35f; // Metadata: 0x0064C2E5
	private const float MinShowSec = 2f; // Metadata: 0x0064C2E9
	private const float NoClockFallbackSec = 6f; // Metadata: 0x0064C2ED
	private static MatchStartGateOverlay _instance; // 0x00
	private UnityEngine.UI.Text _titleText; // 0x20
	private UnityEngine.UI.Text _readyText; // 0x28
	private float _shownAtUnscaled; // 0x30
	private bool _closing; // 0x34

	// Properties
	public static bool IsShowing { get; } // 0x000000018033FFF0-0x0000000180340060 

	// Nested types
	[CompilerGenerated]
	private sealed class _WatchRoutine_d__20 : IEnumerator<object> // TypeDefIndex: 430
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchStartGateOverlay __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28
		private int _dotPhase_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WatchRoutine_d__20(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018035BF40-0x000000018035C1A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018035C1A0-0x000000018035C1E0
	}

	// Constructors
	public MatchStartGateOverlay(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public static void Show(string subtitle = null); // 0x000000018033FA40-0x000000018033FBC0
	public static void HideNow(); // 0x000000018033F510-0x000000018033F5F0
	private void Awake(); // 0x000000018033ED70-0x000000018033ED90
	private void Start(); // 0x000000018033FBC0-0x000000018033FF80
	private void OnDestroy(); // 0x000000018033F5F0-0x000000018033F9B0
	private void HandleGateClosed(); // 0x000000018033F190-0x000000018033F200
	private void HandleGameOver(string winner); // 0x000000018033F190-0x000000018033F200
	private void HandleReadyState(int ready, int total); // 0x000000018033F470-0x000000018033F510
	private void SetReadyLabel(string text); // 0x000000018033F9B0-0x000000018033FA40
	private void Close(); // 0x000000018033F190-0x000000018033F200
	[IteratorStateMachine(typeof(_WatchRoutine_d__20))]
	private IEnumerator WatchRoutine(); // 0x000000018033FF80-0x000000018033FFF0
	private void BuildUI(); // 0x000000018033ED90-0x000000018033F190
	private static UnityEngine.UI.Text CreateText(Transform parent, string name, string content, Font font, int size, Color color, Vector2 anchoredPos); // 0x000000018033F200-0x000000018033F470
}

