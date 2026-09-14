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

[DisallowMultipleComponent]
public class ElementGatePopup : MonoBehaviour // TypeDefIndex: 21
{
	// Fields
	private const string BG_SPRITE = "Image/FusionUI/bgPopupAlert"; // Metadata: 0x005ED51F
	private const string BTN_SPRITE = "Image/FusionUI/btnBlue"; // Metadata: 0x005ED53B
	private const string CELL_BG_SPRITE = "Image/petK/Circle Bg Dark"; // Metadata: 0x005ED552
	private const string GLOW_SPRITE = "Image/FusionUI/haoquang"; // Metadata: 0x005ED56C
	private const float PANEL_W = 900f; // Metadata: 0x005ED584
	private const float PANEL_H = 580f; // Metadata: 0x005ED588
	private const float CELL = 118f; // Metadata: 0x005ED58C
	private const float CELL_GAP = 34f; // Metadata: 0x005ED590
	private static ElementGatePopup _instance; // 0x00
	private GameObject _panel; // 0x20
	private bool _closing; // 0x28

	// Constructors
	public ElementGatePopup(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static void Show(ElementGateUI gate); // 0x00000001802A5190-0x00000001802A5290
	public static void Show(IList<string> required, IList<string> missing); // 0x00000001802A5290-0x00000001802A5490
	public static void Hide(); // 0x00000001802A5490-0x00000001802A5790
	private void OnDestroy(); // 0x00000001802A5790-0x00000001802A5950
	private void Build(IList<string> required, IList<string> missing); // 0x00000001802A5950-0x00000001802A7490
	private void BuildRow(Transform parent, IList<string> required, IList<string> missing); // 0x00000001802A7490-0x00000001802A7D00
	private void Close(); // 0x00000001802A7D00-0x00000001802A7ED0
	private static Image NewImage(Transform parent, string name, Sprite sprite, Color color); // 0x00000001802A7ED0-0x00000001802A8120
	private static UnityEngine.UI.Text NewText(Transform parent, string name, string content, int size, FontStyle style, Color color, Vector2 pos, Vector2 sizeDelta); // 0x00000001802A8120-0x00000001802A8550
	[CompilerGenerated]
	private void _Close_b__17_0(); // 0x00000001802A8550-0x00000001802A8640
}

