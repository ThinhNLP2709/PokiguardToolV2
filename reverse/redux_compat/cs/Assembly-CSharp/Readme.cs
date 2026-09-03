/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class Readme : ScriptableObject // TypeDefIndex: 1775
{
	// Fields
	public Texture2D icon; // 0x18
	public string title; // 0x20
	public Section[] sections; // 0x28
	public bool loadedLayout; // 0x30

	// Nested types
	[Serializable]
	public class Section // TypeDefIndex: 1776
	{
		// Fields
		public string heading; // 0x10
		public string text; // 0x18
		public string linkText; // 0x20
		public string url; // 0x28

		// Constructors
		public Section(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	// Constructors
	public Readme(); // 0x00000001805F5FD0-0x00000001805F5FE0
}

