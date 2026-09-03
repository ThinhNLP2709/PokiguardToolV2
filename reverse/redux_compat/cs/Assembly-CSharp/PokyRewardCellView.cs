/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class PokyRewardCellView : MonoBehaviour // TypeDefIndex: 721
{
	// Fields
	[Tooltip("\u00D4 \u1EA3nh CH\u00CDNH c\u1EE7a ph\u1EA7n qu\u00E0 (g\u1ED1c Poky: ItemView/RawImage).")]
	public Image imgIcon; // 0x20
	[Tooltip("Khung \u0111\u1ED9 hi\u1EBFm v\u1EBD \u0110\u00C8 l\u00EAn icon (g\u1ED1c Poky: ItemView/RawImageFrame). T\u1EAFt s\u1EB5n \u2014 ch\u01B0a c\u00F3 d\u1EEF li\u1EC7u \u0111\u1ED9 hi\u1EBFm cho qu\u00E0.")]
	public Image imgFrame; // 0x28
	[Tooltip("L\u1EDBp ph\u1EE7 M\u1EA2NH \u1EDF g\u00F3c tr\u00EAn-tr\u00E1i, 25\u00D725 (g\u1ED1c Poky: node \'piece\'). Ch\u1EC9 b\u1EADt khi qu\u00E0 l\u00E0 m\u1EA3nh pet / m\u1EA3nh v\u0169 kh\u00ED.")]
	public Image imgPiece; // 0x30
	[Tooltip("S\u1ED1 l\u01B0\u1EE3ng \'x100\' d\u01B0\u1EDBi icon (g\u1ED1c Poky: txtQuantity).")]
	public UnityEngine.UI.Text txtQuantity; // 0x38
	public float naturalSize; // 0x40
	private const string PIECE_SPRITE = "Image/piece/pet_piece"; // Metadata: 0x0064C85F
	private static Sprite _pieceSprite; // 0x00
	private static bool _pieceLoaded; // 0x08

	// Constructors
	public PokyRewardCellView(); // 0x00000001803E7710-0x00000001803E7720

	// Methods
	public void Bind(Sprite icon, string amount, bool isPiece); // 0x00000001803E7230-0x00000001803E75E0
	private static Sprite LoadPiece(); // 0x00000001803E75E0-0x00000001803E7710
}

