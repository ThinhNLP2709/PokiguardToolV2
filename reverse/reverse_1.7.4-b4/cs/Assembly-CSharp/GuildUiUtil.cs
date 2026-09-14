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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class GuildUiUtil // TypeDefIndex: 948
{
	// Fields
	private static readonly HashSet<string> _warned; // 0x00

	// Constructors
	static GuildUiUtil(); // 0x00000001805C94B0-0x00000001805C9590

	// Methods
	public static void WarnOnce(string view, string nodeName); // 0x00000001805C4790-0x00000001805C4980
	public static Transform FindDeep(Transform root, string nodeName); // 0x00000001805C4980-0x00000001805C4C10
	public static T Find<T>(Transform root, string nodeName)
		where T : Component;
	public static GameObject FindGo(Transform root, string nodeName); // 0x00000001805C4C10-0x00000001805C4D40
	public static void Wire(Button b, UnityAction action); // 0x00000001805C4D40-0x00000001805C4E50
	public static void Wire(Transform root, string nodeName, UnityAction action); // 0x00000001805C4E50-0x00000001805C4EF0
	public static bool WireTouch(Transform root, string nodeName, UnityAction action); // 0x00000001805C4EF0-0x00000001805C5260
	public static void SetActive(GameObject go, bool on); // 0x00000001805C5260-0x00000001805C53F0
	public static void SetActive(Component c, bool on); // 0x00000001805C53F0-0x00000001805C5520
	public static void SetText(UnityEngine.UI.Text t, string value); // 0x00000001805C5520-0x00000001805C5680
	public static void ApplySprite(Transform node, Sprite sprite); // 0x00000001805C5680-0x00000001805C5F50
	private static void RevealGraphic(Graphic g); // 0x00000001805C5F50-0x00000001805C60B0
	public static void FitRaw(RawImage raw, Sprite sprite); // 0x00000001805C60B0-0x00000001805C6480
	public static void ApplyPath(Transform node, string resourcePath); // 0x00000001805C6480-0x00000001805C6940
	public static void ApplyAvatar(Transform row, long avtId, int level); // 0x00000001805C6940-0x00000001805C69C0
	public static void ApplyAvatar(Transform row, long avtId, int level, string avatarLayers); // 0x00000001805C69C0-0x00000001805C6FE0
	public static void SetLevel(Transform root, int level); // 0x00000001805C6FE0-0x00000001805C7470
	public static void ShowGuildNameUnder(UnityEngine.UI.Text sample, string guildName); // 0x00000001805C7470-0x00000001805C7E70
	public static string NewNonce(); // 0x00000001805C7E70-0x00000001805C7F10
	public static void PolishRewardCells(List<GameObject> cells); // 0x00000001805C7F10-0x00000001805C8770
	public static void Notice(string msg, float sec = 2.5f /* Metadata: 0x005F0337 */); // 0x00000001805C8770-0x00000001805C88A0
	public static string FriendlyError(string err); // 0x00000001805C88A0-0x00000001805C8990
	public static Image GoldIcon(Transform parent, string name, float x, float y, float w, float h); // 0x00000001805C8990-0x00000001805C8C80
	public static Sprite GoldSprite(); // 0x00000001805C8C80-0x00000001805C9020
	public static void BoostFonts(Transform root); // 0x00000001805C9020-0x00000001805C91E0
	public static UnityEngine.UI.Text BoostFont(UnityEngine.UI.Text t); // 0x00000001805C91E0-0x00000001805C94B0
}

