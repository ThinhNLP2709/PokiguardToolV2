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

public class PvpRoomLoadingOverlay : MonoBehaviour // TypeDefIndex: 230
{
	// Fields
	private static PvpRoomLoadingOverlay _instance; // 0x00
	private readonly Dictionary<string, Entry> _entries; // 0x20
	private readonly List<string> _order; // 0x28
	private Canvas _canvas; // 0x30
	private Image _dim; // 0x38
	private Image _panel; // 0x40
	private UnityEngine.UI.Text _label; // 0x48
	private int _dotPhase; // 0x50
	private string _baseMessage; // 0x58

	// Properties
	public static bool IsShowing { get; } // 0x00000001808387C0-0x0000000180838870 

	// Nested types
	private class Entry // TypeDefIndex: 231
	{
		// Fields
		public string message; // 0x10
		public bool block; // 0x18
		public float deadline; // 0x1C

		// Constructors
		public Entry(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class _WatchRoutine_d__19 : IEnumerator<object> // TypeDefIndex: 232
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PvpRoomLoadingOverlay __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WatchRoutine_d__19(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180841F20-0x0000000180842220
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180842220-0x00000001808422D0
	}

	// Constructors
	public PvpRoomLoadingOverlay(); // 0x00000001808386D0-0x00000001808387C0

	// Methods
	public static void Show(string key, string message, bool blockInput = true /* Metadata: 0x0068AD6E */, float failsafeSec = 25f /* Metadata: 0x0068AD6F */); // 0x00000001808382C0-0x00000001808385E0
	public static void Hide(string key); // 0x0000000180837D50-0x0000000180837E80
	public static void HideAll(); // 0x0000000180837C10-0x0000000180837D50
	private static PvpRoomLoadingOverlay EnsureInstance(); // 0x0000000180837AE0-0x0000000180837C10
	private void Awake(); // 0x0000000180837250-0x0000000180837330
	private void OnDestroy(); // 0x0000000180837E80-0x0000000180837F30
	private void Start(); // 0x00000001808385E0-0x0000000180838660
	[IteratorStateMachine(typeof(_WatchRoutine_d__19))]
	private IEnumerator WatchRoutine(); // 0x0000000180838660-0x00000001808386D0
	private void Refresh(); // 0x0000000180837F30-0x00000001808382C0
	private void BuildUI(); // 0x0000000180837330-0x0000000180837AE0
}

