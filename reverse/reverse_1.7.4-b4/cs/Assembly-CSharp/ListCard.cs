/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ListCard : MonoBehaviour // TypeDefIndex: 2353
{
	// Fields
	public int slCard; // 0x20
	public Button cardPrefab; // 0x28
	public float spacing; // 0x30
	public GameObject onCard; // 0x38
	public List<CardInfo> cardInfos; // 0x40
	private List<Card> activeCards; // 0x48

	// Constructors
	public ListCard(); // 0x0000000180B4BE40-0x0000000180B4BFF0

	// Methods
	public void SetCardInfos(List<CardInfo> newCardInfos); // 0x0000000180B4B6E0-0x0000000180B4B740
	private void Start(); // 0x0000000180B4B740-0x0000000180B4B750
	private void InitializeCards(); // 0x0000000180B4B750-0x0000000180B4BB20
	public void RemoveCard(Card cardToRemove); // 0x0000000180B4BB20-0x0000000180B4BC30
	private void RearrangeCards(); // 0x0000000180B4BC30-0x0000000180B4BE40
}

