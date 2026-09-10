/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ChatController : MonoBehaviour // TypeDefIndex: 2052
{
	// Fields
	public TMP_InputField ChatInputField; // 0x20
	public TMP_Text ChatDisplayOutput; // 0x28
	public Scrollbar ChatScrollbar; // 0x30

	// Constructors
	public ChatController(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void OnEnable(); // 0x0000000180713660-0x0000000180713710
	private void OnDisable(); // 0x00000001807135C0-0x0000000180713660
	private void AddToChatOutput(string newText); // 0x0000000180713250-0x00000001807135C0
}

