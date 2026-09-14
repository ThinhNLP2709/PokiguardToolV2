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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class GuildUiUtil // TypeDefIndex: 946
{
	// Fields
	private static readonly HashSet<string> _warned; // 0x00

	// Constructors
	static GuildUiUtil(); // 0x00000001805C7B30-0x00000001805C7C10

	// Methods
	public static void WarnOnce(string view, string nodeName); // 0x00000001805C2E30-0x00000001805C3020
	public static Transform FindDeep(Transform root, string nodeName); // 0x00000001805C3020-0x00000001805C32B0
	public static T Find<T>(Transform root, string nodeName)
		where T : Component;
	public static GameObject FindGo(Transform root, string nodeName); // 0x00000001805C32B0-0x00000001805C33E0
	public static void Wire(Button b, UnityAction action); // 0x00000001805C33E0-0x00000001805C34F0
	public static void Wire(Transform root, string nodeName, UnityAction action); // 0x00000001805C34F0-0x00000001805C3590
	public static bool WireTouch(Transform root, string nodeName, UnityAction action); // 0x00000001805C3590-0x00000001805C3900
	public static void SetActive(GameObject go, bool on); // 0x00000001805C3900-0x00000001805C3A90
	public static void SetActive(Component c, bool on); // 0x00000001805C3A90-0x00000001805C3BC0
	public static void SetText(UnityEngine.UI.Text t, string value); // 0x00000001805C3BC0-0x00000001805C3D20
	public static void ApplySprite(Transform node, Sprite sprite); // 0x00000001805C3D20-0x00000001805C45F0
	private static void RevealGraphic(Graphic g); // 0x00000001805C45F0-0x00000001805C4750
	public static void FitRaw(RawImage raw, Sprite sprite); // 0x00000001805C4750-0x00000001805C4B20
	public static void ApplyPath(Transform node, string resourcePath); // 0x00000001805C4B20-0x00000001805C4FE0
	public static void ApplyAvatar(Transform row, long avtId, int level); // 0x00000001805C4FE0-0x00000001805C5060
	public static void ApplyAvatar(Transform row, long avtId, int level, string avatarLayers); // 0x00000001805C5060-0x00000001805C5680
	public static void SetLevel(Transform root, int level); // 0x00000001805C5680-0x00000001805C5B10
	public static void ShowGuildNameUnder(UnityEngine.UI.Text sample, string guildName); // 0x00000001805C5B10-0x00000001805C6510
	public static string NewNonce(); // 0x00000001805C6510-0x00000001805C65B0
	public static void PolishRewardCells(List<GameObject> cells); // 0x00000001805C65B0-0x00000001805C6E10
	public static void Notice(string msg, float sec = 2.5f /* Metadata: 0x005EEF6A */); // 0x00000001805C6E10-0x00000001805C6F40
	public static string FriendlyError(string err); // 0x00000001805C6F40-0x00000001805C7010
	public static Image GoldIcon(Transform parent, string name, float x, float y, float w, float h); // 0x00000001805C7010-0x00000001805C7300
	public static Sprite GoldSprite(); // 0x00000001805C7300-0x00000001805C76A0
	public static void BoostFonts(Transform root); // 0x00000001805C76A0-0x00000001805C7860
	public static UnityEngine.UI.Text BoostFont(UnityEngine.UI.Text t); // 0x00000001805C7860-0x00000001805C7B30
}

