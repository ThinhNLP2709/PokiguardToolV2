/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class BoardFxArt // TypeDefIndex: 2325
{
	// Fields
	private static Texture2D _tex; // 0x00
	private static Sprite _glow; // 0x08
	private static Sprite _ring; // 0x10
	private static Sprite _mote; // 0x18
	private static Sprite _plus; // 0x20
	private static Sprite _comet; // 0x28

	// Properties
	public static Sprite Glow { get; } // 0x0000000180B29370-0x0000000180B293C0 
	public static Sprite Ring { get; } // 0x0000000180B293C0-0x0000000180B29410 
	public static Sprite Mote { get; } // 0x0000000180B29410-0x0000000180B29460 
	public static Sprite Plus { get; } // 0x0000000180B29460-0x0000000180B294B0 
	public static Sprite Comet { get; } // 0x0000000180B294B0-0x0000000180B29500 

	// Methods
	public static bool Ensure(); // 0x0000000180B29500-0x0000000180B29AA0
	public static void Dispose(); // 0x0000000180B29AA0-0x0000000180B29E10
	private static void DestroySafe(UnityEngine.Object o); // 0x0000000180B29E10-0x0000000180B29F70
	private static void Build(); // 0x0000000180B29F70-0x0000000180B2A8C0
	private static Sprite Make(string name, Rect r, Vector2 pivot); // 0x0000000180B2A8C0-0x0000000180B2A9E0
	private static void Set(Color32[] px, int x, int y, float a); // 0x0000000180B2A9E0-0x0000000180B2AA60
	private static void DrawGlow(Color32[] px, int ox, int oy, int n); // 0x0000000180B2AA60-0x0000000180B2ACE0
	private static void DrawRing(Color32[] px, int ox, int oy, int n); // 0x0000000180B2ACE0-0x0000000180B2AF10
	private static void DrawMote(Color32[] px, int ox, int oy, int n); // 0x0000000180B2AF10-0x0000000180B2B0E0
	private static void DrawPlus(Color32[] px, int ox, int oy, int n); // 0x0000000180B2B0E0-0x0000000180B2B390
	private static void DrawComet(Color32[] px, int ox, int oy, int w, int h); // 0x0000000180B2B390-0x0000000180B2B6C0
}

