/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuildShopCell : MonoBehaviour // TypeDefIndex: 784
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
	private const float CELL = 88f; // Metadata: 0x0068BB27
	private const string NODE_NAME = "txtName"; // Metadata: 0x0068BB2B
	private bool _wired; // 0x50
	private UnityEngine.UI.Text _txtName; // 0x58
	private GuildShopItemData _data; // 0x60

	// Properties
	public GuildShopItemData Data { get; } // 0x0000000180385A10-0x0000000180385A20 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 785
	{
		// Fields
		public GuildShopCell __4__this; // 0x10
		public Action<GuildShopItemData> onBuy; // 0x18

		// Constructors
		public __c__DisplayClass15_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Bind_b__0(); // 0x0000000180496A30-0x0000000180496B40
	}

	// Constructors
	public GuildShopCell(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180483400-0x0000000180483410
	private void EnsureWired(); // 0x0000000180484380-0x0000000180484720
	public void Bind(GuildShopItemData data, Action<GuildShopItemData> onBuy); // 0x0000000180483410-0x0000000180483BD0
	private void RenderName(List<RewardDisplayHelper.Entry> entries); // 0x00000001804848B0-0x0000000180484B60
	private UnityEngine.UI.Text EnsureNameNode(); // 0x0000000180483CD0-0x0000000180484380
	public void PlayBoughtFx(); // 0x0000000180484720-0x00000001804848B0
	private static string CostIconPath(string costType); // 0x0000000180483BD0-0x0000000180483CD0
}

