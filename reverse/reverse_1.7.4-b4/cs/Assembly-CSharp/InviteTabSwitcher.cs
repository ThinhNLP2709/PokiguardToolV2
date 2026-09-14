/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	static InviteTabSwitcher(); // 0x00000001802C8A90-0x00000001802C8AF0

	// Methods
	private void Awake(); // 0x00000001802C72A0-0x00000001802C72B0
	private void OnEnable(); // 0x00000001802C72B0-0x00000001802C7590
	private void EnsureWired(); // 0x00000001802C7590-0x00000001802C7E70
	private static UnityEngine.UI.Text LabelOf(Button tab); // 0x00000001802C7E70-0x00000001802C8000
	private static string ReadLabel(Button tab); // 0x00000001802C8000-0x00000001802C8130
	private static void SetLabel(Button tab, string value); // 0x00000001802C8130-0x00000001802C8270
	private void Wire(Button btn, UnityAction action); // 0x00000001802C8270-0x00000001802C8380
	public void Select(Display_InvitableUser.Source source); // 0x00000001802C8380-0x00000001802C8610
	private static void Style(Button tab, bool selected); // 0x00000001802C8610-0x00000001802C8A90
	[CompilerGenerated]
	private void _EnsureWired_b__9_0(); // 0x00000001802C8AF0-0x00000001802C8B00
	[CompilerGenerated]
	private void _EnsureWired_b__9_1(); // 0x00000001802C8B00-0x00000001802C8B10
}

