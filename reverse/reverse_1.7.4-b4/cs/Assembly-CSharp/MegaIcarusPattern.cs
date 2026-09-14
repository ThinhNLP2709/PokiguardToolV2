/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class MegaIcarusPattern // TypeDefIndex: 2365
{
	// Fields
	public static readonly Vector2Int[] Cells; // 0x00

	// Constructors
	static MegaIcarusPattern(); // 0x0000000180B55240-0x0000000180B55760

	// Methods
	public static int ColOffset(int boardWidth); // 0x0000000180B54E20-0x0000000180B54E30
	public static int TopRow(int boardHeight); // 0x0000000180B54E30-0x0000000180B54E40
	public static Vector2Int ToBoardCell(Vector2Int gridCell, int boardWidth, int boardHeight); // 0x0000000180B54E40-0x0000000180B54ED0
	public static List<Vector2Int> BoardCells(int boardWidth, int boardHeight); // 0x0000000180B54ED0-0x0000000180B550D0
	public static bool Contains(int col, int row, int boardWidth, int boardHeight); // 0x0000000180B550D0-0x0000000180B551B0
	public static Vector2 GridCenterCell(int boardWidth, int boardHeight); // 0x0000000180B551B0-0x0000000180B55240
}

