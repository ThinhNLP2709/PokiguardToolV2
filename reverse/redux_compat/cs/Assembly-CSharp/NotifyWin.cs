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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class NotifyWin : MonoBehaviour // TypeDefIndex: 1698
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
	private sealed class _LoadImageFromUrl_d__14 : IEnumerator<object> // TypeDefIndex: 1699
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string url; // 0x20
		public RawImage rawImage; // 0x28
		private UnityWebRequest _request_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadImageFromUrl_d__14(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805E5A80-0x00000001805E5B60
		private bool MoveNext(); // 0x00000001805E57E0-0x00000001805E5A40
		private void __m__Finally1(); // 0x00000001805E5B60-0x00000001805E5BB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E5A40-0x00000001805E5A80
	}

	[CompilerGenerated]
	private sealed class _winGame_d__13 : IEnumerator<object> // TypeDefIndex: 1700
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NotifyWin __4__this; // 0x20
		public int useId; // 0x28
		public GameObject listAward; // 0x30
		private List<ResponseDataAward> __7__wrap1; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _winGame_d__13(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805E9AB0-0x00000001805E9B40
		private bool MoveNext(); // 0x00000001805E92F0-0x00000001805E9A70
		private void __m__Finally1(); // 0x00000001805E9B40-0x00000001805E9B60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E9A70-0x00000001805E9AB0
	}

	// Constructors
	public NotifyWin(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Start(); // 0x00000001805E0F30-0x00000001805E0FA0
	public void endBoard(int userId); // 0x00000001805E0FA0-0x00000001805E1130
	[IteratorStateMachine(typeof(_winGame_d__13))]
	public IEnumerator winGame(int useId, GameObject listAward); // 0x00000001805E1130-0x00000001805E11D0
	[IteratorStateMachine(typeof(_LoadImageFromUrl_d__14))]
	private IEnumerator LoadImageFromUrl(string url, RawImage rawImage); // 0x00000001805E0EA0-0x00000001805E0F30
}

