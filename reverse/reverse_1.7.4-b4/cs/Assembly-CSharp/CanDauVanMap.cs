/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class CanDauVanMap // TypeDefIndex: 411
{
	// Methods
	public static float WaveFreq(int trackLen); // 0x0000000180342AF0-0x0000000180342B60
	public static Vector2 TilePos(int step, int trackLen); // 0x0000000180342B60-0x0000000180342C20
	public static Vector2 TileAnchored(int step, int trackLen); // 0x0000000180342C20-0x0000000180342CE0
	public static Vector2 HeroAnchored(int step, int trackLen); // 0x0000000180342CE0-0x0000000180342D20
	public static float ContentWidth(int trackLen); // 0x0000000180342D20-0x0000000180342D50
	public static float CameraX(int step, float viewportW, float contentW, bool loop); // 0x0000000180342D50-0x0000000180342DC0
	public static int Wrap(int idx, int trackLen); // 0x0000000180342DC0-0x0000000180342DE0
	public static int CenterLo(int center, int trackLen); // 0x0000000180342DE0-0x0000000180342E10
	public static int SpanLo(int a, int b, int trackLen); // 0x0000000180342E10-0x0000000180342E40
	public static int RingStep(int idx, int lo, int trackLen); // 0x0000000180342E40-0x0000000180342E60
	public static int StepToward(int fromStep, int idx, int trackLen, bool loop); // 0x0000000180342E60-0x0000000180342EA0
	public static int NearestStep(int idx, int near, int trackLen); // 0x0000000180342EA0-0x0000000180342EE0
	public static int[] PathBetween(int from, int to, int trackLen, bool loop); // 0x0000000180342EE0-0x0000000180343060
}

