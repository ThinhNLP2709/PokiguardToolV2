/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class MegaIcarusPattern // TypeDefIndex: 2358
{
	// Fields
	public static readonly Vector2Int[] Cells; // 0x00

	// Constructors
	static MegaIcarusPattern(); // 0x0000000180B47FC0-0x0000000180B484E0

	// Methods
	public static int ColOffset(int boardWidth); // 0x0000000180B47BA0-0x0000000180B47BB0
	public static int TopRow(int boardHeight); // 0x0000000180B47BB0-0x0000000180B47BC0
	public static Vector2Int ToBoardCell(Vector2Int gridCell, int boardWidth, int boardHeight); // 0x0000000180B47BC0-0x0000000180B47C50
	public static List<Vector2Int> BoardCells(int boardWidth, int boardHeight); // 0x0000000180B47C50-0x0000000180B47E50
	public static bool Contains(int col, int row, int boardWidth, int boardHeight); // 0x0000000180B47E50-0x0000000180B47F30
	public static Vector2 GridCenterCell(int boardWidth, int boardHeight); // 0x0000000180B47F30-0x0000000180B47FC0
}

