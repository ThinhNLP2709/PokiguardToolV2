/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class GuideContent // TypeDefIndex: 592
{
	// Fields
	private static List<Chapter> _chapters; // 0x00

	// Properties
	public static List<Chapter> Chapters { get; } // 0x00000001803AAE20-0x00000001803AAEA0 

	// Nested types
	public class Chapter // TypeDefIndex: 593
	{
		// Fields
		public string title; // 0x10
		public string heading; // 0x18
		public string body; // 0x20

		// Constructors
		public Chapter(string title, string heading, string body); // 0x00000001803A7D10-0x00000001803A7D80
	}

	// Methods
	private static List<Chapter> Build(); // 0x00000001803AA5C0-0x00000001803AAE20
}

