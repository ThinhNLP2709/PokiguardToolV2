/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class GuildRaidUi // TypeDefIndex: 914
{
	// Fields
	private static readonly TimeSpan VN_OFFSET; // 0x00
	private static readonly Color C_ST_LIVE; // 0x08
	private static readonly Color C_ST_UPCOMING; // 0x18
	private static readonly Color C_ST_KILLED; // 0x28
	private static readonly Color C_ST_ESCAPED; // 0x38
	private static readonly Color C_ST_LOCKED; // 0x48
	private static Sprite _circle; // 0x58
	private static bool _circleTried; // 0x60

	// Constructors
	static GuildRaidUi(); // 0x000000018059BD10-0x000000018059BE50

	// Methods
	public static Color StateColor(string state); // 0x0000000180597FA0-0x00000001805982A0
	public static string Stars(int star); // 0x00000001805982A0-0x00000001805982E0
	public static void SkinPill(Image img, Color tint); // 0x00000001805982E0-0x00000001805985A0
	public static Image Glass(MonoBehaviour host, Transform parent, string name, Vector2 pos, Vector2 size); // 0x00000001805985A0-0x0000000180598790
	public static Image MakeImage(Transform parent, string name, Color color); // 0x0000000180598790-0x0000000180598E70
	public static UnityEngine.UI.Text MakeText(Transform parent, string name, Font font, int fontSize, TextAnchor align, Color color); // 0x0000000180598E70-0x0000000180599920
	public static Vector2 SizeForSprite(Sprite s, float longSide, Vector2 fallback); // 0x0000000180599920-0x0000000180599B70
	public static void ApplyIconButton(Button btn, Sprite icon, float longSide, Vector2 fallbackSize); // 0x0000000180599B70-0x000000018059A100
	public static Sprite Art(Transform raidRoot, string key); // 0x000000018059A100-0x000000018059A500
	public static Button MakeRaidButton(Transform parent, string name, Font font, string label, int fontSize, Vector2 pos, Vector2 size, Sprite sprite, Color labelColor); // 0x000000018059A500-0x000000018059AC70
	public static void PlaceText(UnityEngine.UI.Text t, Vector2 pos, Vector2 size); // 0x000000018059AC70-0x000000018059AE90
	public static Sprite CircleSprite(); // 0x000000018059AE90-0x000000018059B140
	private static Sprite MakeCircleSprite(); // 0x000000018059B140-0x000000018059B5A0
	public static void Order(params Component[] nodes); // 0x000000018059B5A0-0x000000018059B710
	public static void Place(RectTransform rt, Vector2 pos, Vector2 size); // 0x000000018059B710-0x000000018059B900
	public static RemoteStyleBinding Bind(Component c, string key); // 0x000000018059B900-0x000000018059BB60
	public static string HourMinute(long epochMs); // 0x000000018059BB60-0x000000018059BD10
}

