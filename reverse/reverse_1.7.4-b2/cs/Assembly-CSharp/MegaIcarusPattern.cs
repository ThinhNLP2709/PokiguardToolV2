/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class MegaIcarusPattern // TypeDefIndex: 1974
{
	// Fields
	public const int GridCols = 8; // Metadata: 0x0068DDD9
	public const int GridRows = 7; // Metadata: 0x0068DDDA
	public const float SettledPitchPixels = 32.3f; // Metadata: 0x0068DDDB
	public static readonly Vector2Int[] Cells; // 0x00

	// Constructors
	static MegaIcarusPattern(); // 0x000000018070A8F0-0x000000018070ADB0

	// Methods
	public static int ColOffset(int boardWidth); // 0x000000018070A6F0-0x000000018070A700
	public static int TopRow(int boardHeight); // 0x000000018070A8E0-0x000000018070A8F0
	public static Vector2Int ToBoardCell(Vector2Int gridCell, int boardWidth, int boardHeight); // 0x000000018070A860-0x000000018070A8E0
	public static List<Vector2Int> BoardCells(int boardWidth, int boardHeight); // 0x000000018070A520-0x000000018070A6F0
	public static bool Contains(int col, int row, int boardWidth, int boardHeight); // 0x000000018070A700-0x000000018070A7E0
	public static Vector2 GridCenterCell(int boardWidth, int boardHeight); // 0x000000018070A7E0-0x000000018070A860
}

