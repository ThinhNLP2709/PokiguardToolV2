/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome.InfoPlayer;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class EvolutionItemTip // TypeDefIndex: 873
{
	// Fields
	public const string CFG_KEY = "evotip"; // Metadata: 0x0068BDB7
	private const string EITEM_SHEET_1 = "Image/stone/item1"; // Metadata: 0x0068BDBE
	private const string EITEM_SHEET_234 = "Image/stone/item1234"; // Metadata: 0x0068BDD0
	private const string CRYSTAL_SHEET = "Image/stone/imtemPoint"; // Metadata: 0x0068BDE5
	private const string CRYSTAL_SPRITE = "imtemPoint_0"; // Metadata: 0x0068BDFC
	private static readonly Color ShortColor; // 0x00
	private static readonly Color EnoughColor; // 0x10
	private static readonly Dictionary<string, Sprite[]> _sheetCache; // 0x20

	// Constructors
	static EvolutionItemTip(); // 0x00000001804B2670-0x00000001804B27B0

	// Methods
	public static InfoPlayerActionTooltip.Model Stone(long stoneId, int have, int need); // 0x00000001804B2530-0x00000001804B2670
	public static InfoPlayerActionTooltip.Model EItem(int idx1to4, int have, int need); // 0x00000001804B1E70-0x00000001804B20D0
	public static InfoPlayerActionTooltip.Model Crystal(int have, int need); // 0x00000001804B1B60-0x00000001804B1C60
	public static InfoPlayerActionTooltip.Model Core(int idx1to9, int have, int need, Action onSwap); // 0x00000001804B18F0-0x00000001804B1B60
	public static EvolutionItemTipTarget Attach(GameObject go, Func<InfoPlayerActionTooltip.Model> build, RectTransform anchor); // 0x00000001804B17F0-0x00000001804B18F0
	private static InfoPlayerActionTooltip.Model NewModel(string title, Sprite icon); // 0x00000001804B20D0-0x00000001804B21A0
	private static void AddCounts(InfoPlayerActionTooltip.Model m, int have, int need); // 0x00000001804B1620-0x00000001804B17F0
	private static string Rich(Color c, string text); // 0x00000001804B21A0-0x00000001804B22D0
	private static string Desc(string prop, string fallback); // 0x00000001804B1C60-0x00000001804B1D00
	private static Sprite EItemSprite(int i); // 0x00000001804B1D00-0x00000001804B1E70
	private static Sprite SheetSprite(string sheetPath, string subName); // 0x00000001804B22D0-0x00000001804B2530
}

