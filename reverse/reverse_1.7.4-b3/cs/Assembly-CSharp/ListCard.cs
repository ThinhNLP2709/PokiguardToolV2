/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ListCard : MonoBehaviour // TypeDefIndex: 2346
{
	// Fields
	public int slCard; // 0x20
	public Button cardPrefab; // 0x28
	public float spacing; // 0x30
	public GameObject onCard; // 0x38
	public List<CardInfo> cardInfos; // 0x40
	private List<Card> activeCards; // 0x48

	// Constructors
	public ListCard(); // 0x0000000180B3EBC0-0x0000000180B3ED70

	// Methods
	public void SetCardInfos(List<CardInfo> newCardInfos); // 0x0000000180B3E460-0x0000000180B3E4C0
	private void Start(); // 0x0000000180B3E4C0-0x0000000180B3E4D0
	private void InitializeCards(); // 0x0000000180B3E4D0-0x0000000180B3E8A0
	public void RemoveCard(Card cardToRemove); // 0x0000000180B3E8A0-0x0000000180B3E9B0
	private void RearrangeCards(); // 0x0000000180B3E9B0-0x0000000180B3EBC0
}

