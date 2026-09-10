/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class GuildUiUtil // TypeDefIndex: 793
{
	// Fields
	private static readonly HashSet<string> _warned; // 0x00

	// Constructors
	static GuildUiUtil(); // 0x000000018048C4D0-0x000000018048C560

	// Methods
	public static void WarnOnce(string view, string nodeName); // 0x000000018048BF00-0x000000018048C0D0
	public static Transform FindDeep(Transform root, string nodeName); // 0x000000018048A080-0x000000018048A1B0
	public static T Find<T>(Transform root, string nodeName)
		where T : Component;
	public static GameObject FindGo(Transform root, string nodeName); // 0x000000018048A1B0-0x000000018048A260
	public static void Wire(Button b, UnityAction action); // 0x000000018048C430-0x000000018048C4D0
	public static void Wire(Transform root, string nodeName, UnityAction action); // 0x000000018048C330-0x000000018048C430
	public static bool WireTouch(Transform root, string nodeName, UnityAction action); // 0x000000018048C0D0-0x000000018048C330
	public static void SetActive(GameObject go, bool on); // 0x000000018048B380-0x000000018048B410
	public static void SetActive(Component c, bool on); // 0x000000018048B410-0x000000018048B520
	public static void SetText(UnityEngine.UI.Text t, string value); // 0x000000018048B760-0x000000018048B810
	public static void ApplySprite(Transform node, Sprite sprite); // 0x0000000180489C20-0x0000000180489FE0
	private static void RevealGraphic(Graphic g); // 0x000000018048B290-0x000000018048B380
	public static void FitRaw(RawImage raw, Sprite sprite); // 0x000000018048A260-0x000000018048A490
	public static void ApplyPath(Transform node, string resourcePath); // 0x0000000180489A10-0x0000000180489C20
	public static void ApplyAvatar(Transform row, long avtId, int level); // 0x0000000180489650-0x00000001804896D0
	public static void ApplyAvatar(Transform row, long avtId, int level, string avatarLayers); // 0x00000001804896D0-0x0000000180489A10
	public static void SetLevel(Transform root, int level); // 0x000000018048B520-0x000000018048B760
	public static void ShowGuildNameUnder(UnityEngine.UI.Text sample, string guildName); // 0x000000018048B810-0x000000018048BF00
	public static void FixScrollBox(Transform scrollView, Vector2 pos, Vector2 size, float spacing = 6f /* Metadata: 0x0068BBE4 */, int padTop = 4 /* Metadata: 0x0068BBE8 */, int padBottom = 4 /* Metadata: 0x0068BBE9 */); // 0x000000018048A490-0x000000018048AB80
	private static void DestroySafe(Component c); // 0x0000000180489FE0-0x000000018048A080
	public static string NewNonce(); // 0x000000018048AC00-0x000000018048AC60
	public static void PolishRewardCells(List<GameObject> cells); // 0x000000018048AD40-0x000000018048B290
	public static void Notice(string msg, float sec = 2.5f /* Metadata: 0x0068BBEA */); // 0x000000018048AC60-0x000000018048AD40
	public static string FriendlyError(string err); // 0x000000018048AB80-0x000000018048AC00
}

