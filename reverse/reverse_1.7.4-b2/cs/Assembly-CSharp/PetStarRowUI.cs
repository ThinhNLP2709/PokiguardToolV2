/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class PetStarRowUI : MonoBehaviour // TypeDefIndex: 890
{
	// Fields
	public const string NODE = "starRow"; // Metadata: 0x0068BE63
	[Tooltip("\u1EA8n h\u1EB3n c\u1EA3 d\u1EA3i khi pet ch\u01B0a n\u00E2ng sao (0 sao).")]
	public bool hideWhenZero; // 0x20
	[Tooltip("Tr\u1EA7n sao hi\u1EC3n th\u1ECB. Server tr\u1EA3 maxStar \u0111\u1ED9ng; 0 = d\u00F9ng s\u1ED1 node con c\u00F3 s\u1EB5n.")]
	public int maxStar; // 0x24
	private int _lastStar; // 0x28
	private int _lastMax; // 0x2C

	// Constructors
	public PetStarRowUI(); // 0x00000001804C29D0-0x00000001804C29F0

	// Methods
	public void SetStar(int star, int maxStarOverride = 0 /* Metadata: 0x0068BE61 */); // 0x00000001804C28D0-0x00000001804C29D0
	public void Invalidate(); // 0x00000001804C28C0-0x00000001804C28D0
	public static PetStarRowUI FindUnder(Component petItem); // 0x00000001804C27C0-0x00000001804C28C0
	public static void Apply(Component petItem, int star, int maxStar = 6 /* Metadata: 0x0068BE62 */); // 0x00000001804C2720-0x00000001804C27C0
}

