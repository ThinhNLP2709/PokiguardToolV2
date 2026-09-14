/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome.InfoPlayer;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class EvolutionItemTip // TypeDefIndex: 1130
{
	// Fields
	private static readonly Color ShortColor; // 0x00
	private static readonly Color EnoughColor; // 0x10
	private static readonly Dictionary<string, Sprite[]> _sheetCache; // 0x20

	// Constructors
	static EvolutionItemTip(); // 0x0000000180694990-0x0000000180694AE0

	// Methods
	public static InfoPlayerActionTooltip.Model Stone(long stoneId, int have, int need); // 0x00000001806933D0-0x0000000180693560
	public static InfoPlayerActionTooltip.Model EItem(int idx1to4, int have, int need); // 0x0000000180693560-0x00000001806938A0
	public static InfoPlayerActionTooltip.Model Crystal(int have, int need); // 0x00000001806938A0-0x00000001806939D0
	public static InfoPlayerActionTooltip.Model Core(int idx1to9, int have, int need, Action onSwap); // 0x00000001806939D0-0x0000000180693CD0
	public static EvolutionItemTipTarget Attach(GameObject go, Func<InfoPlayerActionTooltip.Model> build, RectTransform anchor); // 0x0000000180693CD0-0x0000000180693EE0
	private static InfoPlayerActionTooltip.Model NewModel(string title, Sprite icon); // 0x0000000180693EE0-0x0000000180694050
	private static void AddCounts(InfoPlayerActionTooltip.Model m, int have, int need); // 0x0000000180694050-0x0000000180694300
	private static string Rich(Color c, string text); // 0x0000000180694300-0x0000000180694420
	private static string Desc(string prop, string fallback); // 0x0000000180694420-0x00000001806944C0
	private static Sprite EItemSprite(int i); // 0x00000001806944C0-0x0000000180694660
	private static Sprite SheetSprite(string sheetPath, string subName); // 0x0000000180694660-0x0000000180694990
}

