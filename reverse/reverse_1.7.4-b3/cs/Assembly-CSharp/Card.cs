/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class Card : MonoBehaviour // TypeDefIndex: 2240
{
	// Fields
	public int idCard; // 0x20
	public string idCardUser; // 0x28
	public string cardDetail; // 0x30
	public int value; // 0x38
	public int lever; // 0x3C
	public int conditionUse; // 0x40
	private Active active; // 0x48
	private ListCard listCard; // 0x50
	private CardFight cardFight; // 0x58
	private Button btn; // 0x60
	private Board board; // 0x68
	private string url; // 0x70
	public Image cardImage; // 0x78

	// Constructors
	public Card(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Start(); // 0x0000000180AC5900-0x0000000180AC5CD0
	public void Initialize(int id, int level = 1 /* Metadata: 0x005F0874 */); // 0x0000000180AC5CD0-0x0000000180AC5CF0
	public void Initialize(CardInfo cardInfo); // 0x0000000180AC5CF0-0x0000000180AC61F0
	public void OnClickCard(); // 0x0000000180AC61F0-0x0000000180AC6720
	private string GetCardTypeName(); // 0x0000000180AC6720-0x0000000180AC6820
	public void Setup(ListCard listCardReference); // 0x0000000180AC6820-0x0000000180AC6930
}

