/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class GuildRaidUi // TypeDefIndex: 916
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
	static GuildRaidUi(); // 0x000000018059D670-0x000000018059D7B0

	// Methods
	public static Color StateColor(string state); // 0x0000000180599900-0x0000000180599C00
	public static string Stars(int star); // 0x0000000180599C00-0x0000000180599C40
	public static void SkinPill(Image img, Color tint); // 0x0000000180599C40-0x0000000180599F00
	public static Image Glass(MonoBehaviour host, Transform parent, string name, Vector2 pos, Vector2 size); // 0x0000000180599F00-0x000000018059A0F0
	public static Image MakeImage(Transform parent, string name, Color color); // 0x000000018059A0F0-0x000000018059A7D0
	public static UnityEngine.UI.Text MakeText(Transform parent, string name, Font font, int fontSize, TextAnchor align, Color color); // 0x000000018059A7D0-0x000000018059B280
	public static Vector2 SizeForSprite(Sprite s, float longSide, Vector2 fallback); // 0x000000018059B280-0x000000018059B4D0
	public static void ApplyIconButton(Button btn, Sprite icon, float longSide, Vector2 fallbackSize); // 0x000000018059B4D0-0x000000018059BA60
	public static Sprite Art(Transform raidRoot, string key); // 0x000000018059BA60-0x000000018059BE60
	public static Button MakeRaidButton(Transform parent, string name, Font font, string label, int fontSize, Vector2 pos, Vector2 size, Sprite sprite, Color labelColor); // 0x000000018059BE60-0x000000018059C5D0
	public static void PlaceText(UnityEngine.UI.Text t, Vector2 pos, Vector2 size); // 0x000000018059C5D0-0x000000018059C7F0
	public static Sprite CircleSprite(); // 0x000000018059C7F0-0x000000018059CAA0
	private static Sprite MakeCircleSprite(); // 0x000000018059CAA0-0x000000018059CF00
	public static void Order(params Component[] nodes); // 0x000000018059CF00-0x000000018059D070
	public static void Place(RectTransform rt, Vector2 pos, Vector2 size); // 0x000000018059D070-0x000000018059D260
	public static RemoteStyleBinding Bind(Component c, string key); // 0x000000018059D260-0x000000018059D4C0
	public static string HourMinute(long epochMs); // 0x000000018059D4C0-0x000000018059D670
}

