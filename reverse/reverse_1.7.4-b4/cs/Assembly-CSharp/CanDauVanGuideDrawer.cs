/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class CanDauVanGuideDrawer : MonoBehaviour // TypeDefIndex: 409
{
	// Fields
	public const float W = 520f; // Metadata: 0x005EF202
	public const float H = 600f; // Metadata: 0x005EF206
	public const float Y = 144f; // Metadata: 0x005EF20A
	public const float TITLE_Y = 18f; // Metadata: 0x005EF20E
	public const float TITLE_H = 50f; // Metadata: 0x005EF212
	public const float TITLE_FONT = 34f; // Metadata: 0x005EF216
	public const float BODY_X = 24f; // Metadata: 0x005EF21A
	public const float BODY_Y = 74f; // Metadata: 0x005EF21E
	public const float BODY_W = 472f; // Metadata: 0x005EF222
	public const float BODY_H = 150f; // Metadata: 0x005EF226
	public const float BODY_FONT = 22f; // Metadata: 0x005EF22A
	public const float ROW_X = 24f; // Metadata: 0x005EF22E
	public const float ROW_Y0 = 236f; // Metadata: 0x005EF232
	public const float ROW_STEP = 38f; // Metadata: 0x005EF236
	public const float ROW_W = 472f; // Metadata: 0x005EF23A
	public const float ROW_H = 34f; // Metadata: 0x005EF23E
	public const float ROW_ICON = 30f; // Metadata: 0x005EF242
	public const float ROW_TEXT_X = 40f; // Metadata: 0x005EF246
	public const float ROW_FONT = 20f; // Metadata: 0x005EF24A
	public const int ROWS = 9; // Metadata: 0x005EF24E
	public const float CLOSE = 64f; // Metadata: 0x005EF24F
	public const float CLOSE_PAD = 12f; // Metadata: 0x005EF253
	public const float CLOSE_HIT = 96f; // Metadata: 0x005EF257
	public const float SLIDE_TIME = 0.28f; // Metadata: 0x005EF25B
	public const string TITLE = "H\u01AF\u1EDANG D\u1EAAN"; // Metadata: 0x005EF25F
	private MonoBehaviour _host; // 0x20
	private RectTransform _root; // 0x28
	private UnityEngine.UI.Text _title; // 0x30
	private UnityEngine.UI.Text _body; // 0x38
	private readonly RectTransform[] _rows; // 0x40
	private readonly Image[] _rowIcons; // 0x48
	private readonly UnityEngine.UI.Text[] _rowTexts; // 0x50
	private bool _open; // 0x58
	private float _edgeX; // 0x5C

	// Properties
	public bool IsOpen { get; } // 0x000000018033B9F0-0x000000018033BA00 

	// Constructors
	public CanDauVanGuideDrawer(); // 0x000000018033D860-0x000000018033DA20

	// Methods
	public static CanDauVanGuideDrawer Build(MonoBehaviour host, Transform parent); // 0x000000018033BA00-0x000000018033BC30
	private void BuildBody(); // 0x000000018033BC30-0x000000018033C940
	public void SetEdgeX(float edgeX); // 0x000000018033C940-0x000000018033CA70
	public void Show(CanDauVanState s); // 0x000000018033CA70-0x000000018033CC20
	public void Hide(); // 0x000000018033CC20-0x000000018033CD10
	public void HideImmediate(); // 0x000000018033CD10-0x000000018033CEA0
	public void Toggle(CanDauVanState s); // 0x000000018033CEA0-0x000000018033CEC0
	public void Render(CanDauVanState s); // 0x000000018033CEC0-0x000000018033D170
	private void FillRow(int n, CanDauVanTile t); // 0x000000018033D170-0x000000018033D860
	[CompilerGenerated]
	private void _Hide_b__40_0(); // 0x000000018033DA20-0x000000018033DB80
}

