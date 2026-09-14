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

public class GuildShopCell : MonoBehaviour // TypeDefIndex: 932
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
	private const float CELL = 88f; // Metadata: 0x005EEE5A
	private const string NODE_NAME = "txtName"; // Metadata: 0x005EEE5E
	private bool _wired; // 0x50
	private UnityEngine.UI.Text _txtName; // 0x58
	private GuildShopItemData _data; // 0x60

	// Properties
	public GuildShopItemData Data { get; } // 0x000000018039E720-0x000000018039E730 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 933
	{
		// Fields
		public GuildShopCell __4__this; // 0x10
		public Action<GuildShopItemData> onBuy; // 0x18

		// Constructors
		public __c__DisplayClass15_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x00000001805B1630-0x00000001805B1750
	}

	// Constructors
	public GuildShopCell(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x00000001805AF0D0-0x00000001805AF0E0
	private void EnsureWired(); // 0x00000001805AF0E0-0x00000001805AFA10
	public void Bind(GuildShopItemData data, Action<GuildShopItemData> onBuy); // 0x00000001805AFA10-0x00000001805B04B0
	private void RenderName(List<RewardDisplayHelper.Entry> entries); // 0x00000001805B04B0-0x00000001805B07A0
	private UnityEngine.UI.Text EnsureNameNode(); // 0x00000001805B07A0-0x00000001805B1260
	public void PlayBoughtFx(); // 0x00000001805B1260-0x00000001805B1490
	private static string CostIconPath(string costType); // 0x00000001805B1490-0x00000001805B1630
}

