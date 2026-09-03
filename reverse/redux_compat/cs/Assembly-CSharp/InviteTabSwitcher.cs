/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class InviteTabSwitcher : MonoBehaviour // TypeDefIndex: 37
{
	// Fields
	[SerializeField]
	private Button tabAll; // 0x20
	[SerializeField]
	private Button tabFriends; // 0x28
	[SerializeField]
	private Display_InvitableUser list; // 0x30
	private static readonly Color LABEL_ACTIVE; // 0x00
	private static readonly Color LABEL_INACTIVE; // 0x10
	private bool _wired; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass9_0 // TypeDefIndex: 38
	{
		// Fields
		public InviteTabSwitcher __4__this; // 0x10
		public Display_InvitableUser.Source source; // 0x18

		// Constructors
		public __c__DisplayClass9_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Wire_b__0(); // 0x000000018030FA40-0x000000018030FA70
	}

	// Constructors
	public InviteTabSwitcher(); // 0x00000001802E7A70-0x00000001802E7BC0
	static InviteTabSwitcher(); // 0x00000001802FE700-0x00000001802FE760

	// Methods
	private void Awake(); // 0x00000001802FDF60-0x00000001802FDF70
	private void OnEnable(); // 0x00000001802FE1F0-0x00000001802FE2C0
	private void EnsureWired(); // 0x00000001802FDF70-0x00000001802FE1F0
	private void Wire(Button btn, Display_InvitableUser.Source source); // 0x00000001802FE5D0-0x00000001802FE700
	public void Select(Display_InvitableUser.Source source); // 0x00000001802FE2C0-0x00000001802FE3A0
	private static void Style(Button tab, bool selected); // 0x00000001802FE3A0-0x00000001802FE5D0
}

