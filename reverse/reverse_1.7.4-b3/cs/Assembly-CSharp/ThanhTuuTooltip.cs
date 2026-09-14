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
public sealed class ThanhTuuTooltip : MonoBehaviour // TypeDefIndex: 1311
{
	// Fields
	public const float W = 560f; // Metadata: 0x005EF96D
	public const float MIN_H = 130f; // Metadata: 0x005EF971
	public const float PAD_X = 16f; // Metadata: 0x005EF975
	public const float PAD_Y = 12f; // Metadata: 0x005EF979
	public const float LINE_GAP = 4f; // Metadata: 0x005EF97D
	public const float NAME_FONT = 22f; // Metadata: 0x005EF981
	public const float BODY_FONT = 20f; // Metadata: 0x005EF985
	public const float GAP = 4f; // Metadata: 0x005EF989
	public const float EDGE = 8f; // Metadata: 0x005EF98D
	public const string LABEL_USE = "C\u00F4ng d\u1EE5ng: "; // Metadata: 0x005EF991
	public const string LABEL_SOURCE = "Ngu\u1ED3n: "; // Metadata: 0x005EF9A0
	public static readonly Color BG; // 0x00
	public static readonly Color BORDER; // 0x10
	public static readonly Color NAME_COLOR; // 0x20
	private RectTransform _root; // 0x20
	private RectTransform _space; // 0x28
	private Image _bg; // 0x30
	private Image _border; // 0x38
	private UnityEngine.UI.Text _name; // 0x40
	private UnityEngine.UI.Text _use; // 0x48
	private UnityEngine.UI.Text _source; // 0x50
	private static readonly Vector3[] _corners; // 0x30

	// Properties
	public bool IsShowing { get; } // 0x0000000180746500-0x0000000180746660 

	// Constructors
	public ThanhTuuTooltip(); // 0x000000018028A560-0x000000018028A5B0
	static ThanhTuuTooltip(); // 0x00000001807488D0-0x0000000180748AB0

	// Methods
	public static ThanhTuuTooltip Build(RectTransform parent); // 0x0000000180746660-0x00000001807471A0
	private static void Wrap(UnityEngine.UI.Text t); // 0x00000001807471A0-0x00000001807472A0
	public void Show(RectTransform anchor, string title, string use, string source); // 0x00000001807472A0-0x00000001807479E0
	public void Hide(); // 0x00000001807479E0-0x0000000180747BB0
	private static float LineHeight(UnityEngine.UI.Text t, float width, float min); // 0x0000000180747BB0-0x0000000180747D40
	private void PlaceNear(RectTransform anchor, float w, float h); // 0x0000000180747D40-0x0000000180748260
	private Rect VisibleRect(); // 0x0000000180748260-0x00000001807488D0
}

