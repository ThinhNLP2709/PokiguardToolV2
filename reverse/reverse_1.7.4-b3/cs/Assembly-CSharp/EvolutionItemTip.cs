/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome.InfoPlayer;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class EvolutionItemTip // TypeDefIndex: 1128
{
	// Fields
	private static readonly Color ShortColor; // 0x00
	private static readonly Color EnoughColor; // 0x10
	private static readonly Dictionary<string, Sprite[]> _sheetCache; // 0x20

	// Constructors
	static EvolutionItemTip(); // 0x0000000180692FB0-0x0000000180693100

	// Methods
	public static InfoPlayerActionTooltip.Model Stone(long stoneId, int have, int need); // 0x00000001806919F0-0x0000000180691B80
	public static InfoPlayerActionTooltip.Model EItem(int idx1to4, int have, int need); // 0x0000000180691B80-0x0000000180691EC0
	public static InfoPlayerActionTooltip.Model Crystal(int have, int need); // 0x0000000180691EC0-0x0000000180691FF0
	public static InfoPlayerActionTooltip.Model Core(int idx1to9, int have, int need, Action onSwap); // 0x0000000180691FF0-0x00000001806922F0
	public static EvolutionItemTipTarget Attach(GameObject go, Func<InfoPlayerActionTooltip.Model> build, RectTransform anchor); // 0x00000001806922F0-0x0000000180692500
	private static InfoPlayerActionTooltip.Model NewModel(string title, Sprite icon); // 0x0000000180692500-0x0000000180692670
	private static void AddCounts(InfoPlayerActionTooltip.Model m, int have, int need); // 0x0000000180692670-0x0000000180692920
	private static string Rich(Color c, string text); // 0x0000000180692920-0x0000000180692A40
	private static string Desc(string prop, string fallback); // 0x0000000180692A40-0x0000000180692AE0
	private static Sprite EItemSprite(int i); // 0x0000000180692AE0-0x0000000180692C80
	private static Sprite SheetSprite(string sheetPath, string subName); // 0x0000000180692C80-0x0000000180692FB0
}

