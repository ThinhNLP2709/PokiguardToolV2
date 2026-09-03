/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class PetStarUtil // TypeDefIndex: 702
{
	// Fields
	private const string PET_ICON_DIR = "Image/IconsPet/"; // Metadata: 0x0064C7B8
	public const string PIECE_SPRITE = "Image/piece/pet_piece"; // Metadata: 0x0064C7C8
	public const string UI_DIR = "Image/petStarUI/"; // Metadata: 0x0064C7DE
	public const string SHARED_UI_DIR = "Image/weaponUI/"; // Metadata: 0x0064C7EF
	public const float PIECE_ALPHA = 0.55f; // Metadata: 0x0064C7FF
	public const float PIECE_ASPECT = 0.70535713f; // Metadata: 0x0064C803
	public const float PET_IN_PIECE = 0.8f; // Metadata: 0x0064C807
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
	public const float STAR_OFF_SCALE = 0.82f; // Metadata: 0x0064C80B

	// Constructors
	static PetStarUtil(); // 0x00000001803E6CB0-0x00000001803E6E80

	// Methods
	public static void FitPetInsidePiece(Image imgPet, Vector2 frameSize, Vector2? frameCenter = default); // 0x00000001803E5F90-0x00000001803E6250
	public static string Hex(Color c); // 0x00000001803E6450-0x00000001803E64B0
	public static Sprite LoadPetIcon(long petId); // 0x00000001803E64B0-0x00000001803E6620
	public static Sprite LoadPieceOverlay(); // 0x00000001803E6620-0x00000001803E6790
	public static Sprite LoadUI(string fileName); // 0x00000001803E6790-0x00000001803E6950
	public static string StarText(int star); // 0x00000001803E6C50-0x00000001803E6CB0
	public static string GetElementLabel(string element); // 0x00000001803E6250-0x00000001803E6450
	public static void PaintStarRow(Transform row, int star, int maxStar = 6 /* Metadata: 0x0064C7B7 */); // 0x00000001803E6950-0x00000001803E6C50
	public static void ApplyShardVisual(Image imgPet, Image imgPiece, long petId); // 0x00000001803E5700-0x00000001803E5BF0
	public static Image EnsurePieceOverlay(GameObject item, Image mainImg); // 0x00000001803E5BF0-0x00000001803E5F90
	public static void ApplyPieceOverlay(GameObject item, Image mainImg, bool showPiece); // 0x00000001803E5450-0x00000001803E5700
}

