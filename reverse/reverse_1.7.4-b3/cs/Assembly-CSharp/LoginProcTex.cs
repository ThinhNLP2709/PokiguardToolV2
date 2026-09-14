/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class LoginProcTex // TypeDefIndex: 1085
{
	// Fields
	private static readonly Dictionary<string, Texture2D> _cache; // 0x00

	// Constructors
	static LoginProcTex(); // 0x000000018066D050-0x000000018066D1C0

	// Methods
	public static Texture2D Stars(int seed, int count, int minPx, int maxPx); // 0x000000018066BA70-0x000000018066C050
	private static void Splat(Color32[] px, int n, int cx, int cy, int r, float peak, float tint); // 0x000000018066C050-0x000000018066C2E0
	public static Texture2D SoftDot(); // 0x000000018066C2E0-0x000000018066C690
	public static Texture2D Vignette(); // 0x000000018066C690-0x000000018066CA90
	private static Texture2D Make(int w, int h, Color32[] px, TextureWrapMode wrap); // 0x000000018066CA90-0x000000018066CC80
	private static Texture2D Store(string key, Texture2D tex); // 0x000000018066CC80-0x000000018066CD30
	public static void Dispose(); // 0x000000018066CD30-0x000000018066D050
}

