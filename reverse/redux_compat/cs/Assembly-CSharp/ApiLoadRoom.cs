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

public class ApiLoadRoom : MonoBehaviour // TypeDefIndex: 1719
{
	// Fields
	private const string apiUrl = "https://pokiwar70-production.up.railway.app/api/v1/roomWait/join"; // Metadata: 0x0064D9F7
	public LoadDataCard loadDataCard; // 0x20
	public LoadDataPet loadDataPet; // 0x28
	public LoadRoom loadRoom; // 0x30
	[CompilerGenerated]
	private Action _OnComplete_k__BackingField; // 0x38
	public int check; // 0x40
	public List<Button> imageButtons; // 0x48
	public Button selectBtn; // 0x50
	public GameObject btnDown; // 0x58
	public GameObject boardCard; // 0x60
	private HashSet<Button> buttonsWithEvent; // 0x68

	// Properties
	public Action OnComplete { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 1720
	{
		// Fields
		public Button button; // 0x10
		public ApiLoadRoom __4__this; // 0x18

		// Constructors
		public __c__DisplayClass15_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Update_b__0(); // 0x00000001805E89C0-0x00000001805E8A80
	}

	[CompilerGenerated]
	private sealed class _CallJoinRoomApi_d__16 : IEnumerator<object> // TypeDefIndex: 1721
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CallJoinRoomApi_d__16(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805E48E0-0x00000001805E4950
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805E4950-0x00000001805E4990
	}

	// Constructors
	public ApiLoadRoom(); // 0x00000001805D4B90-0x00000001805D4C10

	// Methods
	public void LoadBoardCard(Button button); // 0x00000001805D4850-0x00000001805D4910
	private void Update(); // 0x00000001805D4910-0x00000001805D4B90
	[IteratorStateMachine(typeof(_CallJoinRoomApi_d__16))]
	public IEnumerator CallJoinRoomApi(int userId, int enemyPetId); // 0x00000001805D4800-0x00000001805D4850
}

