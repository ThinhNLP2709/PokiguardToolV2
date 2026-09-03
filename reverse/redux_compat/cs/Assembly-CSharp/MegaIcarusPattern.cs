/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class MegaIcarusPattern // TypeDefIndex: 1696
{
	// Fields
	public const int GridCols = 8; // Metadata: 0x0064D9AA
	public const int GridRows = 7; // Metadata: 0x0064D9AB
	public const float SettledPitchPixels = 32.3f; // Metadata: 0x0064D9AC
	public static readonly Vector2Int[] Cells; // 0x00

	// Constructors
	static MegaIcarusPattern(); // 0x00000001805DFEA0-0x00000001805E0360

	// Methods
	public static int ColOffset(int boardWidth); // 0x00000001805DFCA0-0x00000001805DFCB0
	public static int TopRow(int boardHeight); // 0x00000001805DFE90-0x00000001805DFEA0
	public static Vector2Int ToBoardCell(Vector2Int gridCell, int boardWidth, int boardHeight); // 0x00000001805DFE10-0x00000001805DFE90
	public static List<Vector2Int> BoardCells(int boardWidth, int boardHeight); // 0x00000001805DFAD0-0x00000001805DFCA0
	public static bool Contains(int col, int row, int boardWidth, int boardHeight); // 0x00000001805DFCB0-0x00000001805DFD90
	public static Vector2 GridCenterCell(int boardWidth, int boardHeight); // 0x00000001805DFD90-0x00000001805DFE10
}

