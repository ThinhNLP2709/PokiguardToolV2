/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class FriendRequestRowUI : MonoBehaviour // TypeDefIndex: 706
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
	public FriendRequestItemData Data { get; } // 0x000000018039E8F0-0x000000018039E900 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 707
	{
		// Fields
		public FriendRequestRowUI __4__this; // 0x10
		public Action<FriendRequestItemData> onAccept; // 0x18
		public Action<FriendRequestItemData> onDecline; // 0x20
		public Action<FriendRequestItemData> onCancel; // 0x28

		// Constructors
		public __c__DisplayClass13_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x00000001804AC4C0-0x00000001804AC520
		internal void _Bind_b__1(); // 0x00000001804AC520-0x00000001804AC580
		internal void _Bind_b__2(); // 0x00000001804AC580-0x00000001804AC5E0
	}

	// Constructors
	public FriendRequestRowUI(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x00000001804AA950-0x00000001804AA960
	private void AutoFindRefs(); // 0x00000001804AA960-0x00000001804AB5E0
	public void Bind(FriendRequestItemData data, Action<FriendRequestItemData> onAccept, Action<FriendRequestItemData> onDecline, Action<FriendRequestItemData> onCancel); // 0x00000001804AB5E0-0x00000001804AC280
	public void SetBusy(bool busy); // 0x00000001804AC280-0x00000001804AC4C0
}

