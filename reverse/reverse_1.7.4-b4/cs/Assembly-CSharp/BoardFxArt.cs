/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class BoardFxArt // TypeDefIndex: 2332
{
	// Fields
	private static Texture2D _tex; // 0x00
	private static Sprite _glow; // 0x08
	private static Sprite _ring; // 0x10
	private static Sprite _mote; // 0x18
	private static Sprite _plus; // 0x20
	private static Sprite _comet; // 0x28

	// Properties
	public static Sprite Glow { get; } // 0x0000000180B36550-0x0000000180B365A0 
	public static Sprite Ring { get; } // 0x0000000180B365A0-0x0000000180B365F0 
	public static Sprite Mote { get; } // 0x0000000180B365F0-0x0000000180B36640 
	public static Sprite Plus { get; } // 0x0000000180B36640-0x0000000180B36690 
	public static Sprite Comet { get; } // 0x0000000180B36690-0x0000000180B366E0 

	// Methods
	public static bool Ensure(); // 0x0000000180B366E0-0x0000000180B36C80
	public static void Dispose(); // 0x0000000180B36C80-0x0000000180B36FF0
	private static void DestroySafe(UnityEngine.Object o); // 0x0000000180B36FF0-0x0000000180B37150
	private static void Build(); // 0x0000000180B37150-0x0000000180B37AA0
	private static Sprite Make(string name, Rect r, Vector2 pivot); // 0x0000000180B37AA0-0x0000000180B37BC0
	private static void Set(Color32[] px, int x, int y, float a); // 0x0000000180B37BC0-0x0000000180B37C40
	private static void DrawGlow(Color32[] px, int ox, int oy, int n); // 0x0000000180B37C40-0x0000000180B37EC0
	private static void DrawRing(Color32[] px, int ox, int oy, int n); // 0x0000000180B37EC0-0x0000000180B380F0
	private static void DrawMote(Color32[] px, int ox, int oy, int n); // 0x0000000180B380F0-0x0000000180B382C0
	private static void DrawPlus(Color32[] px, int ox, int oy, int n); // 0x0000000180B382C0-0x0000000180B38570
	private static void DrawComet(Color32[] px, int ox, int oy, int w, int h); // 0x0000000180B38570-0x0000000180B388A0
}

