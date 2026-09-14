/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class CanDauVanGuideDrawer : MonoBehaviour // TypeDefIndex: 409
{
	// Fields
	public const float W = 520f; // Metadata: 0x005EDE32
	public const float H = 600f; // Metadata: 0x005EDE36
	public const float Y = 144f; // Metadata: 0x005EDE3A
	public const float TITLE_Y = 18f; // Metadata: 0x005EDE3E
	public const float TITLE_H = 50f; // Metadata: 0x005EDE42
	public const float TITLE_FONT = 34f; // Metadata: 0x005EDE46
	public const float BODY_X = 24f; // Metadata: 0x005EDE4A
	public const float BODY_Y = 74f; // Metadata: 0x005EDE4E
	public const float BODY_W = 472f; // Metadata: 0x005EDE52
	public const float BODY_H = 150f; // Metadata: 0x005EDE56
	public const float BODY_FONT = 22f; // Metadata: 0x005EDE5A
	public const float ROW_X = 24f; // Metadata: 0x005EDE5E
	public const float ROW_Y0 = 236f; // Metadata: 0x005EDE62
	public const float ROW_STEP = 38f; // Metadata: 0x005EDE66
	public const float ROW_W = 472f; // Metadata: 0x005EDE6A
	public const float ROW_H = 34f; // Metadata: 0x005EDE6E
	public const float ROW_ICON = 30f; // Metadata: 0x005EDE72
	public const float ROW_TEXT_X = 40f; // Metadata: 0x005EDE76
	public const float ROW_FONT = 20f; // Metadata: 0x005EDE7A
	public const int ROWS = 9; // Metadata: 0x005EDE7E
	public const float CLOSE = 64f; // Metadata: 0x005EDE7F
	public const float CLOSE_PAD = 12f; // Metadata: 0x005EDE83
	public const float CLOSE_HIT = 96f; // Metadata: 0x005EDE87
	public const float SLIDE_TIME = 0.28f; // Metadata: 0x005EDE8B
	public const string TITLE = "H\u01AF\u1EDANG D\u1EAAN"; // Metadata: 0x005EDE8F
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
	public bool IsOpen { get; } // 0x000000018033B8D0-0x000000018033B8E0 

	// Constructors
	public CanDauVanGuideDrawer(); // 0x000000018033D740-0x000000018033D900

	// Methods
	public static CanDauVanGuideDrawer Build(MonoBehaviour host, Transform parent); // 0x000000018033B8E0-0x000000018033BB10
	private void BuildBody(); // 0x000000018033BB10-0x000000018033C820
	public void SetEdgeX(float edgeX); // 0x000000018033C820-0x000000018033C950
	public void Show(CanDauVanState s); // 0x000000018033C950-0x000000018033CB00
	public void Hide(); // 0x000000018033CB00-0x000000018033CBF0
	public void HideImmediate(); // 0x000000018033CBF0-0x000000018033CD80
	public void Toggle(CanDauVanState s); // 0x000000018033CD80-0x000000018033CDA0
	public void Render(CanDauVanState s); // 0x000000018033CDA0-0x000000018033D050
	private void FillRow(int n, CanDauVanTile t); // 0x000000018033D050-0x000000018033D740
	[CompilerGenerated]
	private void _Hide_b__40_0(); // 0x000000018033D900-0x000000018033DA60
}

