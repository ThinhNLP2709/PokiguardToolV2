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
public class PetStarBadge : MonoBehaviour // TypeDefIndex: 1133
{
	// Fields
	public const string NODE = "petStarBadge"; // Metadata: 0x005F0810
	public const int DEFAULT_MAX = 6; // Metadata: 0x005F081D
	private const int HARD_MAX = 12; // Metadata: 0x005F081E
	private const string STAR_SPRITE = "gold_star"; // Metadata: 0x005F081F
	[Tooltip("C\u1EA1nh m\u1ED9t \u00F4 sao (\u0111\u01A1n v\u1ECB local c\u1EE7a node cha).")]
	public float starSize; // 0x20
	[Tooltip("Kho\u1EA3ng h\u1EDF gi\u1EEFa hai \u00F4 sao.")]
	public float spacing; // 0x24
	[Tooltip("V\u1EBD c\u1EA3 \u00F4 sao CH\u01AFA \u0111\u1EA1t (x\u00E1m, nh\u1ECF h\u01A1n) hay ch\u1EC9 v\u1EBD s\u1ED1 sao \u0111ang c\u00F3.")]
	public bool showEmptySlots; // 0x28
	[Tooltip("\u1EA8n h\u1EB3n c\u1EA3 d\u1EA3i khi pet ch\u01B0a n\u00E2ng sao.")]
	public bool hideWhenZero; // 0x29
	public float maxWidth; // 0x2C
	public const float MIN_STAR_SIZE = 7f; // Metadata: 0x005F0829
	private RectTransform _rect; // 0x30
	private readonly List<Image> _cells; // 0x38
	private int _lastStar; // 0x40
	private int _lastMax; // 0x44
	private float _lastMaxWidth; // 0x48
	private const float LABEL_EDGE_PAD = 3f; // Metadata: 0x005F082D
	private const float LABEL_TEXT_GAP = 4f; // Metadata: 0x005F0831
	public const float MATCH_STAR_SIZE = 13f; // Metadata: 0x005F0835

	// Constructors
	public PetStarBadge(); // 0x0000000180699760-0x0000000180699880

	// Methods
	public static PetStarBadge Ensure(Transform parent, string nodeName = "petStarBadge" /* Metadata: 0x005F07FD */); // 0x0000000180697430-0x00000001806979C0
	private void Awake(); // 0x00000001806979C0-0x0000000180697A90
	public void Place(Vector2 anchorXY, float pivotX, Vector2 anchoredPos); // 0x0000000180697A90-0x0000000180697E00
	public void SetStar(int star, int maxStar = 0 /* Metadata: 0x005F080A */); // 0x0000000180697E00-0x0000000180698310
	public void Invalidate(); // 0x0000000180698310-0x0000000180698330
	public static PetStarBadge Apply(Transform parent, int star, int maxStar, Vector2 anchorXY, float pivotX, Vector2 anchoredPos, float size = 14f /* Metadata: 0x005F080B */, bool showEmpty = true /* Metadata: 0x005F080F */); // 0x0000000180698330-0x00000001806984B0
	public static void AttachToLabel(UnityEngine.UI.Text label, int star); // 0x00000001806984B0-0x0000000180698850
	private void BuildCells(int count); // 0x0000000180698850-0x0000000180699270
	private void Layout(int count); // 0x0000000180699270-0x0000000180699760
}

