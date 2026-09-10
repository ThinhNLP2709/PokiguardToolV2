/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class NotifyWin : MonoBehaviour // TypeDefIndex: 1976
{
	// Fields
	public GameObject openThongBao; // 0x20
	public GameObject tbPrefab; // 0x28
	public GameObject listA; // 0x30
	public GameObject itemA; // 0x38
	public GameObject nameA; // 0x40
	public GameObject imgA; // 0x48
	public GameObject imgB; // 0x50
	public Api api; // 0x58
	public GameObject offBoardParent; // 0x60
	public GameObject resultBaner; // 0x68
	public GameObject enemyPet; // 0x70

	// Nested types
	[CompilerGenerated]
	private sealed class _LoadImageFromUrl_d__14 : IEnumerator<object> // TypeDefIndex: 1977
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string url; // 0x20
		public RawImage rawImage; // 0x28
		private UnityWebRequest _request_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadImageFromUrl_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018070D320-0x000000018070D400
		private bool MoveNext(); // 0x000000018070D080-0x000000018070D2E0
		private void __m__Finally1(); // 0x000000018070D400-0x000000018070D450
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018070D2E0-0x000000018070D320
	}

	[CompilerGenerated]
	private sealed class _winGame_d__13 : IEnumerator<object> // TypeDefIndex: 1978
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NotifyWin __4__this; // 0x20
		public int useId; // 0x28
		public GameObject listAward; // 0x30
		private List<ResponseDataAward> __7__wrap1; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _winGame_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180711010-0x00000001807110A0
		private bool MoveNext(); // 0x0000000180710850-0x0000000180710FD0
		private void __m__Finally1(); // 0x00000001807110A0-0x00000001807110C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180710FD0-0x0000000180711010
	}

	// Constructors
	public NotifyWin(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Start(); // 0x000000018070B9A0-0x000000018070BA10
	public void endBoard(int userId); // 0x000000018070BA10-0x000000018070BBA0
	[IteratorStateMachine(typeof(_winGame_d__13))]
	public IEnumerator winGame(int useId, GameObject listAward); // 0x000000018070BBA0-0x000000018070BC40
	[IteratorStateMachine(typeof(_LoadImageFromUrl_d__14))]
	private IEnumerator LoadImageFromUrl(string url, RawImage rawImage); // 0x000000018070B910-0x000000018070B9A0
}

