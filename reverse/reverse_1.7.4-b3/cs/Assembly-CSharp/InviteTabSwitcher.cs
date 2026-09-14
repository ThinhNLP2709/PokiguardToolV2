/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class InviteTabSwitcher : MonoBehaviour // TypeDefIndex: 47
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
	private string _labelAllDefault; // 0x40

	// Constructors
	public InviteTabSwitcher(); // 0x000000018028A560-0x000000018028A5B0
	static InviteTabSwitcher(); // 0x00000001802C8A60-0x00000001802C8AC0

	// Methods
	private void Awake(); // 0x00000001802C7270-0x00000001802C7280
	private void OnEnable(); // 0x00000001802C7280-0x00000001802C7560
	private void EnsureWired(); // 0x00000001802C7560-0x00000001802C7E40
	private static UnityEngine.UI.Text LabelOf(Button tab); // 0x00000001802C7E40-0x00000001802C7FD0
	private static string ReadLabel(Button tab); // 0x00000001802C7FD0-0x00000001802C8100
	private static void SetLabel(Button tab, string value); // 0x00000001802C8100-0x00000001802C8240
	private void Wire(Button btn, UnityAction action); // 0x00000001802C8240-0x00000001802C8350
	public void Select(Display_InvitableUser.Source source); // 0x00000001802C8350-0x00000001802C85E0
	private static void Style(Button tab, bool selected); // 0x00000001802C85E0-0x00000001802C8A60
	[CompilerGenerated]
	private void _EnsureWired_b__9_0(); // 0x00000001802C8AC0-0x00000001802C8AD0
	[CompilerGenerated]
	private void _EnsureWired_b__9_1(); // 0x00000001802C8AD0-0x00000001802C8AE0
}

