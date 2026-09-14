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

[DisallowMultipleComponent]
public class CoopRoomGuidePopup : MonoBehaviour // TypeDefIndex: 17
{
	// Fields
	public const string NODE_NAME = "[CoopRoomGuide]"; // Metadata: 0x005EE882
	private const float FRAME_W = 1774f; // Metadata: 0x005EE892
	private const float FRAME_H = 887f; // Metadata: 0x005EE896
	private const float DIM_OVERSCAN = 600f; // Metadata: 0x005EE89A
	private const float BOX_W = 1320f; // Metadata: 0x005EE89E
	private const float BOX_H = 780f; // Metadata: 0x005EE8A2
	private const float BOX_X = 227f; // Metadata: 0x005EE8A6
	private const float BOX_Y = 44f; // Metadata: 0x005EE8AA
	private const float TITLE_Y = 18f; // Metadata: 0x005EE8AE
	private const float TITLE_H = 54f; // Metadata: 0x005EE8B2
	private const float TITLE_FS = 38f; // Metadata: 0x005EE8B6
	private const float CLOSE_X = 1222f; // Metadata: 0x005EE8BA
	private const float CLOSE_Y = 12f; // Metadata: 0x005EE8BE
	private const float CLOSE_W = 78f; // Metadata: 0x005EE8C2
	private const float CLOSE_H = 80f; // Metadata: 0x005EE8C6
	private const float VP_X = 34f; // Metadata: 0x005EE8CA
	private const float VP_Y = 96f; // Metadata: 0x005EE8CE
	private const float VP_W = 1252f; // Metadata: 0x005EE8D2
	private const float VP_H = 636f; // Metadata: 0x005EE8D6
	private const float HINT_Y = 740f; // Metadata: 0x005EE8DA
	private const float HINT_H = 28f; // Metadata: 0x005EE8DE
	private const float HEAD_FS = 30f; // Metadata: 0x005EE8E2
	private const float BODY_FS = 24f; // Metadata: 0x005EE8E6
	private const float DIV_H = 2f; // Metadata: 0x005EE8EA
	private static readonly Color BODY_COLOR; // 0x00
	private bool _built; // 0x20
	private RectTransform _infoRoot; // 0x28
	private RectTransform _content; // 0x30
	private RectTransform _box; // 0x38
	private RectTransform _list; // 0x40
	private CanvasGroup _group; // 0x48
	private ScrollRect _scroll; // 0x50

	// Properties
	public bool IsOpen { get; } // 0x000000018029FEF0-0x00000001802A0050 

	// Nested types
	public struct Section // TypeDefIndex: 18
	{
		// Fields
		public string head; // 0x00
		public string body; // 0x08
	}

	// Constructors
	public CoopRoomGuidePopup(); // 0x000000018028A560-0x000000018028A5B0
	static CoopRoomGuidePopup(); // 0x00000001802A3230-0x00000001802A3280

	// Methods
	public static CoopRoomGuidePopup Mount(Transform host); // 0x00000001802A0050-0x00000001802A0670
	public void Open(); // 0x00000001802A0670-0x00000001802A0B70
	public void Close(); // 0x00000001802A0B70-0x00000001802A0DE0
	public void CloseImmediate(); // 0x00000001802A0DE0-0x00000001802A10D0
	private void OnDisable(); // 0x00000001802A10D0-0x00000001802A12E0
	private void Build(); // 0x00000001802A12E0-0x00000001802A1BD0
	private void BuildScroll(); // 0x00000001802A1BD0-0x00000001802A2320
	private void Fill(List<Section> secs); // 0x00000001802A2320-0x00000001802A26D0
	private void AddHeading(int index, string label); // 0x00000001802A26D0-0x00000001802A2860
	private void AddBody(int index, string body); // 0x00000001802A2860-0x00000001802A2A50
	private void AddDivider(int index); // 0x00000001802A2A50-0x00000001802A2C00
	private static void Wrap(UnityEngine.UI.Text t); // 0x00000001802A2C00-0x00000001802A2DC0
	public static List<Section> BuildSections(); // 0x00000001802A2DC0-0x00000001802A30E0
	public static void Add(List<Section> list, string head, string body); // 0x00000001802A30E0-0x00000001802A3230
	[CompilerGenerated]
	private void _Close_b__37_0(); // 0x00000001802A3280-0x00000001802A3460
}

