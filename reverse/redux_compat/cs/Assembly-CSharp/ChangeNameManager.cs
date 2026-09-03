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

public class ChangeNameManager : MonoBehaviour // TypeDefIndex: 459
{
	// Fields
	[Header("Panel")]
	public GameObject panelChangeName; // 0x20
	public Button btnOpenChangeName; // 0x28
	[Header("UI Components (trong Rewards)")]
	public UnityEngine.UI.Text txtOldName; // 0x30
	public UnityEngine.UI.Text txtMessage; // 0x38
	public InputField inputNewName; // 0x40
	public Button btnClose; // 0x48
	public Button btnChange; // 0x50
	private const int CHANGE_NAME_COST = 300000; // Metadata: 0x0064C4B6
	private int userId; // 0x58

	// Nested types
	[CompilerGenerated]
	private sealed class _ChangeNameCoroutine_d__13 : IEnumerator<object> // TypeDefIndex: 460
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ChangeNameManager __4__this; // 0x20
		public string newName; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ChangeNameCoroutine_d__13(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018036CBB0-0x000000018036CDF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018036CDF0-0x000000018036CE30
	}

	// Constructors
	public ChangeNameManager(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Start(); // 0x000000018035D850-0x000000018035DA40
	public void OpenPanel(); // 0x000000018035D5B0-0x000000018035D730
	private void ClosePanel(); // 0x000000018035D1B0-0x000000018035D230
	private void OnClickChangeName(); // 0x000000018035D230-0x000000018035D400
	[IteratorStateMachine(typeof(_ChangeNameCoroutine_d__13))]
	private IEnumerator ChangeNameCoroutine(string newName); // 0x000000018035D120-0x000000018035D1B0
	private void ShowMessage(string message, bool isSuccess); // 0x000000018035D730-0x000000018035D850
	private void UpdateUIAfterChangeName(string newName, int remainingGold); // 0x000000018035DE30-0x000000018035DFA0
	private void OnDestroy(); // 0x000000018035D400-0x000000018035D5B0
	[CompilerGenerated]
	private void _ChangeNameCoroutine_b__13_0(ChangeNameResponse response); // 0x000000018035DA40-0x000000018035DD40
	[CompilerGenerated]
	private void _ChangeNameCoroutine_b__13_1(string error); // 0x000000018035DD40-0x000000018035DE30
}

