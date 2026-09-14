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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class NotifyWin : MonoBehaviour // TypeDefIndex: 2368
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
	private sealed class _LoadImageFromUrl_d__14 : IEnumerator<object> // TypeDefIndex: 2369
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string url; // 0x20
		public RawImage rawImage; // 0x28
		private UnityWebRequest _request_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadImageFromUrl_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180B57470-0x0000000180B575A0
		private bool MoveNext(); // 0x0000000180B575A0-0x0000000180B57920
		private void __m__Finally1(); // 0x0000000180B57920-0x0000000180B57980
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B57980-0x0000000180B579C0
	}

	[CompilerGenerated]
	private sealed class _winGame_d__13 : IEnumerator<object> // TypeDefIndex: 2370
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NotifyWin __4__this; // 0x20
		public int useId; // 0x28
		public GameObject listAward; // 0x30
		private List<ResponseDataAward> __7__wrap1; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _winGame_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180B579C0-0x0000000180B57A30
		private bool MoveNext(); // 0x0000000180B57A30-0x0000000180B58230
		private void __m__Finally1(); // 0x0000000180379490-0x00000001803794A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B58230-0x0000000180B58270
	}

	// Constructors
	public NotifyWin(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Start(); // 0x0000000180B56DF0-0x0000000180B56EB0
	public void endBoard(int userId); // 0x0000000180B56EB0-0x0000000180B57250
	[IteratorStateMachine(typeof(_winGame_d__13))]
	public IEnumerator winGame(int useId, GameObject listAward); // 0x0000000180B57250-0x0000000180B57360
	[IteratorStateMachine(typeof(_LoadImageFromUrl_d__14))]
	private IEnumerator LoadImageFromUrl(string url, RawImage rawImage); // 0x0000000180B57360-0x0000000180B57470
}

