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
public sealed class ThanhTuuTooltip : MonoBehaviour // TypeDefIndex: 1313
{
	// Fields
	public const float W = 560f; // Metadata: 0x005F0D3A
	public const float MIN_H = 130f; // Metadata: 0x005F0D3E
	public const float PAD_X = 16f; // Metadata: 0x005F0D42
	public const float PAD_Y = 12f; // Metadata: 0x005F0D46
	public const float LINE_GAP = 4f; // Metadata: 0x005F0D4A
	public const float NAME_FONT = 22f; // Metadata: 0x005F0D4E
	public const float BODY_FONT = 20f; // Metadata: 0x005F0D52
	public const float GAP = 4f; // Metadata: 0x005F0D56
	public const float EDGE = 8f; // Metadata: 0x005F0D5A
	public const string LABEL_USE = "C\u00F4ng d\u1EE5ng: "; // Metadata: 0x005F0D5E
	public const string LABEL_SOURCE = "Ngu\u1ED3n: "; // Metadata: 0x005F0D6D
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
	public bool IsShowing { get; } // 0x00000001807482B0-0x0000000180748410 

	// Constructors
	public ThanhTuuTooltip(); // 0x000000018028A560-0x000000018028A5B0
	static ThanhTuuTooltip(); // 0x000000018074A680-0x000000018074A860

	// Methods
	public static ThanhTuuTooltip Build(RectTransform parent); // 0x0000000180748410-0x0000000180748F50
	private static void Wrap(UnityEngine.UI.Text t); // 0x0000000180748F50-0x0000000180749050
	public void Show(RectTransform anchor, string title, string use, string source); // 0x0000000180749050-0x0000000180749790
	public void Hide(); // 0x0000000180749790-0x0000000180749960
	private static float LineHeight(UnityEngine.UI.Text t, float width, float min); // 0x0000000180749960-0x0000000180749AF0
	private void PlaceNear(RectTransform anchor, float w, float h); // 0x0000000180749AF0-0x000000018074A010
	private Rect VisibleRect(); // 0x000000018074A010-0x000000018074A680
}

