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

public class MatchStartGateOverlay : MonoBehaviour // TypeDefIndex: 551
{
	// Fields
	private const float FailsafeSec = 35f; // Metadata: 0x005EE247
	private const float MinShowSec = 2f; // Metadata: 0x005EE24B
	private const float NoClockFallbackSec = 6f; // Metadata: 0x005EE24F
	private static MatchStartGateOverlay _instance; // 0x00
	private UnityEngine.UI.Text _titleText; // 0x20
	private UnityEngine.UI.Text _readyText; // 0x28
	private float _shownAtUnscaled; // 0x30
	private bool _closing; // 0x34

	// Properties
	public static bool IsShowing { get; } // 0x00000001803D9DB0-0x00000001803D9EB0 

	// Nested types
	[CompilerGenerated]
	private sealed class _WatchRoutine_d__20 : IEnumerator<object> // TypeDefIndex: 552
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchStartGateOverlay __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28
		private int _dotPhase_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WatchRoutine_d__20(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001803DB710-0x00000001803DBC30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803DBC30-0x00000001803DBC70
	}

	// Constructors
	public MatchStartGateOverlay(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void Show(string subtitle = null); // 0x00000001803D99F0-0x00000001803D9C90
	public static void HideNow(); // 0x00000001803D9C90-0x00000001803D9DB0
	private void Awake(); // 0x00000001803D9EB0-0x00000001803D9F10
	private void Start(); // 0x00000001803D9F10-0x00000001803DA3F0
	private void OnDestroy(); // 0x00000001803DA3F0-0x00000001803DA9B0
	private void HandleGateClosed(); // 0x00000001803DA9B0-0x00000001803DA9C0
	private void HandleGameOver(string winner); // 0x00000001803DA9B0-0x00000001803DA9C0
	private void HandleReadyState(int ready, int total); // 0x00000001803DA9C0-0x00000001803DAAA0
	private void SetReadyLabel(string text); // 0x00000001803DAAA0-0x00000001803DABB0
	private void Close(); // 0x00000001803DABB0-0x00000001803DAC60
	[IteratorStateMachine(typeof(_WatchRoutine_d__20))]
	private IEnumerator WatchRoutine(); // 0x00000001803DAC60-0x00000001803DAD00
	private void BuildUI(); // 0x00000001803DAD00-0x00000001803DB310
	private static UnityEngine.UI.Text CreateText(Transform parent, string name, string content, Font font, int size, Color color, Vector2 anchoredPos); // 0x00000001803DB310-0x00000001803DB710
}

