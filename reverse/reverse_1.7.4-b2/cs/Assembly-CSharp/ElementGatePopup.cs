/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class ElementGatePopup : MonoBehaviour // TypeDefIndex: 18
{
	// Fields
	private const string BG_SPRITE = "Image/FusionUI/bgPopupAlert"; // Metadata: 0x0068A8C9
	private const string BTN_SPRITE = "Image/FusionUI/btnBlue"; // Metadata: 0x0068A8E5
	private const string CELL_BG_SPRITE = "Image/petK/Circle Bg Dark"; // Metadata: 0x0068A8FC
	private const string GLOW_SPRITE = "Image/FusionUI/haoquang"; // Metadata: 0x0068A916
	private const float PANEL_W = 900f; // Metadata: 0x0068A92E
	private const float PANEL_H = 580f; // Metadata: 0x0068A932
	private const float CELL = 118f; // Metadata: 0x0068A936
	private const float CELL_GAP = 34f; // Metadata: 0x0068A93A
	private static ElementGatePopup _instance; // 0x00
	private GameObject _panel; // 0x20
	private bool _closing; // 0x28

	// Constructors
	public ElementGatePopup(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static void Show(ElementGateUI gate); // 0x00000001802FCB00-0x00000001802FCCD0
	public static void Show(IList<string> required, IList<string> missing); // 0x00000001802FC9A0-0x00000001802FCB00
	public static void Hide(); // 0x00000001802FC330-0x00000001802FC4B0
	private void OnDestroy(); // 0x00000001802FC8F0-0x00000001802FC9A0
	private void Build(IList<string> required, IList<string> missing); // 0x00000001802FB670-0x00000001802FC230
	private void BuildRow(Transform parent, IList<string> required, IList<string> missing); // 0x00000001802FAEA0-0x00000001802FB670
	private void Close(); // 0x00000001802FC230-0x00000001802FC330
	private static Image NewImage(Transform parent, string name, Sprite sprite, Color color); // 0x00000001802FC4B0-0x00000001802FC670
	private static UnityEngine.UI.Text NewText(Transform parent, string name, string content, int size, FontStyle style, Color color, Vector2 pos, Vector2 sizeDelta); // 0x00000001802FC670-0x00000001802FC8F0
	[CompilerGenerated]
	private void _Close_b__17_0(); // 0x00000001802FCCD0-0x00000001802FCD40
}

