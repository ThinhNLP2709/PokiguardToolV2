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

public static class PetStarUtil // TypeDefIndex: 1147
{
	// Fields
	public static readonly Color ColorStarOn; // 0x00
	public static readonly Color ColorStarOff; // 0x10
	public static readonly Color ColorHp; // 0x20
	public static readonly Color ColorAtk; // 0x30
	public static readonly Color ColorMana; // 0x40
	public static readonly Color ColorGain; // 0x50
	public static readonly Color ColorMuted; // 0x60
	public static readonly Color ColorShard; // 0x70
	private static readonly Dictionary<long, Sprite> _petCache; // 0x80
	private static readonly Dictionary<string, Sprite> _uiCache; // 0x88
	private static Sprite _pieceSprite; // 0x90
	private static bool _pieceLoaded; // 0x98

	// Constructors
	static PetStarUtil(); // 0x00000001806A34B0-0x00000001806A3730

	// Methods
	public static void FitPetInsidePiece(Image imgPet, Vector2 frameSize, Vector2? frameCenter = default); // 0x00000001806A0A30-0x00000001806A0EC0
	public static Sprite LoadPetIcon(long petId); // 0x00000001806A0EC0-0x00000001806A10A0
	public static Sprite LoadPieceOverlay(); // 0x00000001806A10A0-0x00000001806A1300
	public static Sprite LoadUI(string fileName); // 0x00000001806A1300-0x00000001806A1580
	public static string StarText(int star); // 0x00000001806A1580-0x00000001806A15E0
	public static string GetElementLabel(string element); // 0x00000001806A15E0-0x00000001806A1690
	public static void PaintStarRow(Transform row, int star, int maxStar = 6 /* Metadata: 0x005EF4DB */); // 0x00000001806A1690-0x00000001806A1C10
	public static void ApplyShardVisual(Image imgPet, Image imgPiece, long petId); // 0x00000001806A1C10-0x00000001806A2590
	public static Image EnsurePieceOverlay(GameObject item, Image mainImg); // 0x00000001806A2590-0x00000001806A2E30
	public static void ApplyPieceOverlay(GameObject item, Image mainImg, bool showPiece); // 0x00000001806A2E30-0x00000001806A34B0
}

