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

public class GuildShopCell : MonoBehaviour // TypeDefIndex: 934
{
	// Fields
	[SerializeField]
	private Transform rewardContainer; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtCost; // 0x28
	[SerializeField]
	private Transform imgCost; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtLimit; // 0x38
	[SerializeField]
	private Button btnBuy; // 0x40
	[SerializeField]
	private GameObject soldOut; // 0x48
	private const float CELL = 88f; // Metadata: 0x005F0228
	private const string NODE_NAME = "txtName"; // Metadata: 0x005F022C
	private bool _wired; // 0x50
	private UnityEngine.UI.Text _txtName; // 0x58
	private GuildShopItemData _data; // 0x60

	// Properties
	public GuildShopItemData Data { get; } // 0x000000018039E8F0-0x000000018039E900 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 935
	{
		// Fields
		public GuildShopCell __4__this; // 0x10
		public Action<GuildShopItemData> onBuy; // 0x18

		// Constructors
		public __c__DisplayClass15_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x00000001805B2F90-0x00000001805B30B0
	}

	// Constructors
	public GuildShopCell(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x00000001805B0A30-0x00000001805B0A40
	private void EnsureWired(); // 0x00000001805B0A40-0x00000001805B1370
	public void Bind(GuildShopItemData data, Action<GuildShopItemData> onBuy); // 0x00000001805B1370-0x00000001805B1E10
	private void RenderName(List<RewardDisplayHelper.Entry> entries); // 0x00000001805B1E10-0x00000001805B2100
	private UnityEngine.UI.Text EnsureNameNode(); // 0x00000001805B2100-0x00000001805B2BC0
	public void PlayBoughtFx(); // 0x00000001805B2BC0-0x00000001805B2DF0
	private static string CostIconPath(string costType); // 0x00000001805B2DF0-0x00000001805B2F90
}

