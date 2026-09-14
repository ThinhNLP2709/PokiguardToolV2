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
	public static bool IsShowing { get; } // 0x0000000180C96E70-0x0000000180C96FA0 

	// Nested types
	private class Entry // TypeDefIndex: 231
	{
		// Fields
		public string message; // 0x10
		public bool block; // 0x18
		public float deadline; // 0x1C

		// Constructors
		public Entry(); // 0x000000018028A320-0x000000018028A330
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WatchRoutine_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180C99360-0x0000000180C998A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180C998A0-0x0000000180C998E0
	}

	// Constructors
	public PvpRoomLoadingOverlay(); // 0x0000000180C99140-0x0000000180C99360

	// Methods
	public static void Show(string key, string message, bool blockInput = true /* Metadata: 0x005ED999 */, float failsafeSec = 25f /* Metadata: 0x005ED99A */); // 0x0000000180C96FA0-0x0000000180C97270
	public static void Hide(string key); // 0x0000000180C97270-0x0000000180C97430
	public static void HideAll(); // 0x0000000180C97430-0x0000000180C975E0
	private static PvpRoomLoadingOverlay EnsureInstance(); // 0x0000000180C975E0-0x0000000180C977F0
	private void Awake(); // 0x0000000180C977F0-0x0000000180C97A80
	private void OnDestroy(); // 0x0000000180C97A80-0x0000000180C97C40
	private void Start(); // 0x0000000180C97C40-0x0000000180C97CF0
	[IteratorStateMachine(typeof(_WatchRoutine_d__19))]
	private IEnumerator WatchRoutine(); // 0x0000000180C97CF0-0x0000000180C97D90
	private void Refresh(); // 0x0000000180C97D90-0x0000000180C98480
	private void BuildUI(); // 0x0000000180C98480-0x0000000180C99140
}

