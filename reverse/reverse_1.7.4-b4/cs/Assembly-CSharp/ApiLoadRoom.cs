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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ApiLoadRoom : MonoBehaviour // TypeDefIndex: 2402
{
	// Fields
	private const string apiUrl = "https://pokiwar70-production.up.railway.app/api/v1/roomWait/join"; // Metadata: 0x005F1F77
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
	public Action OnComplete { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001802BA5D0-0x00000001802BA5E0 0x00000001802BA5E0-0x00000001802BA640

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 2403
	{
		// Fields
		public Button button; // 0x10
		public ApiLoadRoom __4__this; // 0x18

		// Constructors
		public __c__DisplayClass15_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Update_b__0(); // 0x0000000180B68BD0-0x0000000180B68C00
	}

	[CompilerGenerated]
	private sealed class _CallJoinRoomApi_d__16 : IEnumerator<object> // TypeDefIndex: 2404
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CallJoinRoomApi_d__16(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180B68C00-0x0000000180B68C80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180B68C80-0x0000000180B68CC0
	}

	// Constructors
	public ApiLoadRoom(); // 0x0000000180B68AD0-0x0000000180B68BD0

	// Methods
	public void LoadBoardCard(Button button); // 0x0000000180B68380-0x0000000180B68670
	private void Update(); // 0x0000000180B68670-0x0000000180B68A90
	[IteratorStateMachine(typeof(_CallJoinRoomApi_d__16))]
	public IEnumerator CallJoinRoomApi(int userId, int enemyPetId); // 0x0000000180B68A90-0x0000000180B68AD0
}

