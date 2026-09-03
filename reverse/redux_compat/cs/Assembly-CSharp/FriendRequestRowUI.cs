/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class FriendRequestRowUI : MonoBehaviour // TypeDefIndex: 537
{
	// Fields
	[SerializeField]
	private Image imgAvatar; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtLevel; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtTime; // 0x38
	[SerializeField]
	private Button btnAccept; // 0x40
	[SerializeField]
	private Button btnDecline; // 0x48
	[SerializeField]
	private Button btnCancel; // 0x50
	[SerializeField]
	private GameObject txtPendingTag; // 0x58
	private FriendRequestItemData _data; // 0x60

	// Properties
	public FriendRequestItemData Data { get; } // 0x0000000180333260-0x0000000180333490 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 538
	{
		// Fields
		public FriendRequestRowUI __4__this; // 0x10
		public Action<FriendRequestItemData> onAccept; // 0x18
		public Action<FriendRequestItemData> onDecline; // 0x20
		public Action<FriendRequestItemData> onCancel; // 0x28

		// Constructors
		public __c__DisplayClass13_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Bind_b__0(); // 0x000000018038D2B0-0x000000018038D310
		internal void _Bind_b__1(); // 0x000000018038D310-0x000000018038D370
		internal void _Bind_b__2(); // 0x000000018038D370-0x000000018038D3D0
	}

	// Constructors
	public FriendRequestRowUI(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x00000001803894F0-0x0000000180389500
	private void AutoFindRefs(); // 0x0000000180389110-0x00000001803894F0
	public void Bind(FriendRequestItemData data, Action<FriendRequestItemData> onAccept, Action<FriendRequestItemData> onDecline, Action<FriendRequestItemData> onCancel); // 0x0000000180389500-0x0000000180389A50
	public void SetBusy(bool busy); // 0x0000000180389A50-0x0000000180389B30
}

