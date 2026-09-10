/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class FriendRequestRowUI : MonoBehaviour // TypeDefIndex: 614
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
	public FriendRequestItemData Data { get; } // 0x0000000180385A10-0x0000000180385A20 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 615
	{
		// Fields
		public FriendRequestRowUI __4__this; // 0x10
		public Action<FriendRequestItemData> onAccept; // 0x18
		public Action<FriendRequestItemData> onDecline; // 0x20
		public Action<FriendRequestItemData> onCancel; // 0x28

		// Constructors
		public __c__DisplayClass13_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Bind_b__0(); // 0x00000001803F5AC0-0x00000001803F5B20
		internal void _Bind_b__1(); // 0x00000001803F5B20-0x00000001803F5B80
		internal void _Bind_b__2(); // 0x00000001803F5B80-0x00000001803F5BE0
	}

	// Constructors
	public FriendRequestRowUI(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x00000001803F2760-0x00000001803F2770
	private void AutoFindRefs(); // 0x00000001803F2380-0x00000001803F2760
	public void Bind(FriendRequestItemData data, Action<FriendRequestItemData> onAccept, Action<FriendRequestItemData> onDecline, Action<FriendRequestItemData> onCancel); // 0x00000001803F2770-0x00000001803F2D00
	public void SetBusy(bool busy); // 0x00000001803F2D00-0x00000001803F2DE0
}

