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

public class ApiLoadRoom : MonoBehaviour // TypeDefIndex: 1998
{
	// Fields
	private const string apiUrl = "https://pokiwar70-production.up.railway.app/api/v1/roomWait/join"; // Metadata: 0x0068DE36
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
	public Action OnComplete { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000180308AB0-0x0000000180308AC0 0x0000000180308B10-0x0000000180308B20

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 1999
	{
		// Fields
		public Button button; // 0x10
		public ApiLoadRoom __4__this; // 0x18

		// Constructors
		public __c__DisplayClass15_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Update_b__0(); // 0x0000000180726E40-0x0000000180726F00
	}

	[CompilerGenerated]
	private sealed class _CallJoinRoomApi_d__16 : IEnumerator<object> // TypeDefIndex: 2000
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CallJoinRoomApi_d__16(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180723520-0x0000000180723590
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180723590-0x00000001807235D0
	}

	// Constructors
	public ApiLoadRoom(); // 0x0000000180711450-0x00000001807114D0

	// Methods
	public void LoadBoardCard(Button button); // 0x0000000180711110-0x00000001807111D0
	private void Update(); // 0x00000001807111D0-0x0000000180711450
	[IteratorStateMachine(typeof(_CallJoinRoomApi_d__16))]
	public IEnumerator CallJoinRoomApi(int userId, int enemyPetId); // 0x00000001807110C0-0x0000000180711110
}

