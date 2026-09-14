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

public static class GuildSkin // TypeDefIndex: 941
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
	static GuildSkin(); // 0x00000001805B94F0-0x00000001805B96C0

	// Methods
	public static Sprite Get(string name); // 0x00000001805B7870-0x00000001805B7B40
	public static Sprite PokyBarTrack(); // 0x00000001805B7B40-0x00000001805B7E40
	public static Sprite PokyFrame(); // 0x00000001805B7E40-0x00000001805B7EB0
	public static Sprite PokyGold(); // 0x00000001805B7EB0-0x00000001805B7F20
	public static Sprite PokyButton(Transform anyNodeInPanel); // 0x00000001805B7F20-0x00000001805B8660
	public static bool ApplyButton(Image img, Transform anyNodeInPanel, Color tint); // 0x00000001805B8660-0x00000001805B88B0
	public static bool ApplyBarTrack(Image img); // 0x00000001805B88B0-0x00000001805B8AF0
	public static bool ApplyFrame(Image img, Color tint); // 0x00000001805B8AF0-0x00000001805B8DC0
	public static bool Apply(Image img, string name, Color tint, Image.Type type = Image.Type.Sliced /* Metadata: 0x005F0234 */); // 0x00000001805B8DC0-0x00000001805B8FC0
	public static void AddOutline(UnityEngine.UI.Text t, float dist = 2f /* Metadata: 0x005F0235 */); // 0x00000001805B8FC0-0x00000001805B9220
	public static void EnsureRaycaster(Transform node); // 0x00000001805B9220-0x00000001805B94F0
}

