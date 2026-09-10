/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class InviteTabSwitcher : MonoBehaviour // TypeDefIndex: 46
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
	private const string LABEL_GUILD = "Bang h\u1ED9i"; // Metadata: 0x0068AA54
	private string _labelAllDefault; // 0x40

	// Constructors
	public InviteTabSwitcher(); // 0x00000001802EBA70-0x00000001802EBAF0
	static InviteTabSwitcher(); // 0x000000018030C2B0-0x000000018030C310

	// Methods
	private void Awake(); // 0x000000018030B590-0x000000018030B5A0
	private void OnEnable(); // 0x000000018030BAE0-0x000000018030BC90
	private void EnsureWired(); // 0x000000018030B5A0-0x000000018030BA30
	private static UnityEngine.UI.Text LabelOf(Button tab); // 0x000000018030BA30-0x000000018030BAE0
	private static string ReadLabel(Button tab); // 0x000000018030BC90-0x000000018030BD40
	private static void SetLabel(Button tab, string value); // 0x000000018030BE20-0x000000018030BEE0
	private void Wire(Button btn, UnityAction action); // 0x000000018030C210-0x000000018030C2B0
	public void Select(Display_InvitableUser.Source source); // 0x000000018030BD40-0x000000018030BE20
	private static void Style(Button tab, bool selected); // 0x000000018030BEE0-0x000000018030C110
	[CompilerGenerated]
	private void _EnsureWired_b__10_0(); // 0x000000018030C110-0x000000018030C140
	[CompilerGenerated]
	private void _EnsureWired_b__10_1(); // 0x000000018030C140-0x000000018030C210
}

