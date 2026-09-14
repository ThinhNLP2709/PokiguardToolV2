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

public static class GuildSkin // TypeDefIndex: 939
{
	// Fields
	public static readonly Color TITLE; // 0x00
	public static readonly Color GOLD_NUM; // 0x10
	public static readonly Color EXP_CYAN; // 0x20
	public static readonly Color LABEL; // 0x30
	public static readonly Color WARN; // 0x40
	public static readonly Color OUTLINE; // 0x50
	public static readonly Color POOL_FILL; // 0x60
	public static readonly Color EXP_FILL; // 0x70
	public static readonly Color POPUP_TINT; // 0x80
	private static readonly Dictionary<string, Sprite> _cache; // 0x90
	private static bool _warned; // 0x98
	private static Sprite[] _fframe; // 0xA0
	private static bool _fframeTried; // 0xA8
	private static Sprite _pokyBtn; // 0xB0
	private static bool _pokyBtnTried; // 0xB8

	// Constructors
	static GuildSkin(); // 0x00000001805B7B90-0x00000001805B7D60

	// Methods
	public static Sprite Get(string name); // 0x00000001805B5F10-0x00000001805B61E0
	public static Sprite PokyBarTrack(); // 0x00000001805B61E0-0x00000001805B64E0
	public static Sprite PokyFrame(); // 0x00000001805B64E0-0x00000001805B6550
	public static Sprite PokyGold(); // 0x00000001805B6550-0x00000001805B65C0
	public static Sprite PokyButton(Transform anyNodeInPanel); // 0x00000001805B65C0-0x00000001805B6D00
	public static bool ApplyButton(Image img, Transform anyNodeInPanel, Color tint); // 0x00000001805B6D00-0x00000001805B6F50
	public static bool ApplyBarTrack(Image img); // 0x00000001805B6F50-0x00000001805B7190
	public static bool ApplyFrame(Image img, Color tint); // 0x00000001805B7190-0x00000001805B7460
	public static bool Apply(Image img, string name, Color tint, Image.Type type = Image.Type.Sliced /* Metadata: 0x005EEE66 */); // 0x00000001805B7460-0x00000001805B7660
	public static void AddOutline(UnityEngine.UI.Text t, float dist = 2f /* Metadata: 0x005EEE67 */); // 0x00000001805B7660-0x00000001805B78C0
	public static void EnsureRaycaster(Transform node); // 0x00000001805B78C0-0x00000001805B7B90
}

