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

public static class PetStarUtil // TypeDefIndex: 1149
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
	static PetStarUtil(); // 0x00000001806A4F90-0x00000001806A5210

	// Methods
	public static void FitPetInsidePiece(Image imgPet, Vector2 frameSize, Vector2? frameCenter = default); // 0x00000001806A2510-0x00000001806A29A0
	public static Sprite LoadPetIcon(long petId); // 0x00000001806A29A0-0x00000001806A2B80
	public static Sprite LoadPieceOverlay(); // 0x00000001806A2B80-0x00000001806A2DE0
	public static Sprite LoadUI(string fileName); // 0x00000001806A2DE0-0x00000001806A3060
	public static string StarText(int star); // 0x00000001806A3060-0x00000001806A30C0
	public static string GetElementLabel(string element); // 0x00000001806A30C0-0x00000001806A3170
	public static void PaintStarRow(Transform row, int star, int maxStar = 6 /* Metadata: 0x005F08A8 */); // 0x00000001806A3170-0x00000001806A36F0
	public static void ApplyShardVisual(Image imgPet, Image imgPiece, long petId); // 0x00000001806A36F0-0x00000001806A4070
	public static Image EnsurePieceOverlay(GameObject item, Image mainImg); // 0x00000001806A4070-0x00000001806A4910
	public static void ApplyPieceOverlay(GameObject item, Image mainImg, bool showPiece); // 0x00000001806A4910-0x00000001806A4F90
}

