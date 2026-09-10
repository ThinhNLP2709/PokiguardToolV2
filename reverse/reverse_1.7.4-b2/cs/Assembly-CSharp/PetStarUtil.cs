/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class PetStarUtil // TypeDefIndex: 891
{
	// Fields
	private const string PET_ICON_DIR = "Image/IconsPet/"; // Metadata: 0x0068BE6C
	public const string PIECE_SPRITE = "Image/piece/pet_piece"; // Metadata: 0x0068BE7C
	public const string UI_DIR = "Image/petStarUI/"; // Metadata: 0x0068BE92
	public const string SHARED_UI_DIR = "Image/weaponUI/"; // Metadata: 0x0068BEA3
	public const float PIECE_ALPHA = 0.55f; // Metadata: 0x0068BEB3
	public const float PIECE_ASPECT = 0.70535713f; // Metadata: 0x0068BEB7
	public const float PET_IN_PIECE = 0.8f; // Metadata: 0x0068BEBB
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
	public const float STAR_OFF_SCALE = 0.82f; // Metadata: 0x0068BEBF

	// Constructors
	static PetStarUtil(); // 0x00000001804C40F0-0x00000001804C42C0

	// Methods
	public static void FitPetInsidePiece(Image imgPet, Vector2 frameSize, Vector2? frameCenter = default); // 0x00000001804C3530-0x00000001804C37F0
	public static string Hex(Color c); // 0x00000001804C3890-0x00000001804C38F0
	public static Sprite LoadPetIcon(long petId); // 0x00000001804C38F0-0x00000001804C3A60
	public static Sprite LoadPieceOverlay(); // 0x00000001804C3A60-0x00000001804C3BD0
	public static Sprite LoadUI(string fileName); // 0x00000001804C3BD0-0x00000001804C3D90
	public static string StarText(int star); // 0x00000001804C4090-0x00000001804C40F0
	public static string GetElementLabel(string element); // 0x00000001804C37F0-0x00000001804C3890
	public static void PaintStarRow(Transform row, int star, int maxStar = 6 /* Metadata: 0x0068BE6B */); // 0x00000001804C3D90-0x00000001804C4090
	public static void ApplyShardVisual(Image imgPet, Image imgPiece, long petId); // 0x00000001804C2CA0-0x00000001804C3190
	public static Image EnsurePieceOverlay(GameObject item, Image mainImg); // 0x00000001804C3190-0x00000001804C3530
	public static void ApplyPieceOverlay(GameObject item, Image mainImg, bool showPiece); // 0x00000001804C29F0-0x00000001804C2CA0
}

