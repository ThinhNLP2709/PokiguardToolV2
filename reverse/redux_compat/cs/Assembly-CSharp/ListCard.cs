/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ListCard : MonoBehaviour // TypeDefIndex: 1691
{
	// Fields
	public int slCard; // 0x20
	public Button cardPrefab; // 0x28
	public float spacing; // 0x30
	public GameObject onCard; // 0x38
	public List<CardInfo> cardInfos; // 0x40
	private List<Card> activeCards; // 0x48

	// Constructors
	public ListCard(); // 0x00000001805DE4B0-0x00000001805DE580

	// Methods
	public void SetCardInfos(List<CardInfo> newCardInfos); // 0x00000001805DE470-0x00000001805DE4A0
	private void Start(); // 0x00000001805DE4A0-0x00000001805DE4B0
	private void InitializeCards(); // 0x00000001805DDF20-0x00000001805DE160
	public void RemoveCard(Card cardToRemove); // 0x00000001805DE2B0-0x00000001805DE470
	private void RearrangeCards(); // 0x00000001805DE160-0x00000001805DE2B0
}

