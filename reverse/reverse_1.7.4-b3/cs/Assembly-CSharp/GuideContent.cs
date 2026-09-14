/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class GuideContent // TypeDefIndex: 759
{
	// Fields
	private static List<Chapter> _chapters; // 0x00

	// Properties
	public static List<Chapter> Chapters { get; } // 0x00000001804DFF50-0x00000001804E0010 

	// Nested types
	public enum BlockKind // TypeDefIndex: 760
	{
		Heading = 0,
		Text = 1,
		Hero = 2,
		IconRow = 3,
		IconList = 4,
		Gallery = 5,
		Steps = 6,
		Tip = 7,
		Cycle = 8,
		Board = 9
	}

	public class Item // TypeDefIndex: 761
	{
		// Fields
		public string sprite; // 0x10
		public string title; // 0x18
		public string desc; // 0x20

		// Constructors
		public Item(string sprite, string title, string desc = null); // 0x00000001804E6460-0x00000001804E6560
	}

	public class Block // TypeDefIndex: 762
	{
		// Fields
		public BlockKind kind; // 0x10
		public string text; // 0x18
		public string sprite; // 0x20
		public List<Item> items; // 0x28
		public float size; // 0x30

		// Constructors
		public Block(); // 0x000000018028A320-0x000000018028A330
	}

	public class Chapter // TypeDefIndex: 763
	{
		// Fields
		public string title; // 0x10
		public string heading; // 0x18
		public string icon; // 0x20
		public List<Block> blocks; // 0x28

		// Constructors
		public Chapter(string title, string heading, string icon, params Block[] blocks); // 0x00000001804E6560-0x00000001804E6750
	}

	// Methods
	private static Block H(string text, string icon = null); // 0x00000001804E0010-0x00000001804E0120
	private static Block P(string text); // 0x00000001804E0120-0x00000001804E01C0
	private static Block Row(float iconSize, params Item[] items); // 0x00000001804E01C0-0x00000001804E02E0
	private static Block List(float iconSize, params Item[] items); // 0x00000001804E02E0-0x00000001804E0400
	private static Block Gallery(float cellHeight, params Item[] items); // 0x00000001804E0400-0x00000001804E0520
	private static Block Steps(params string[] steps); // 0x00000001804E0520-0x00000001804E0730
	private static Block Tip(string text, string icon = "hand" /* Metadata: 0x005EE687 */); // 0x00000001804E0730-0x00000001804E0840
	private static Block Cycle(); // 0x00000001804E0840-0x00000001804E0890
	private static Block Board(); // 0x00000001804E0890-0x00000001804E08E0
	private static Item I(string sprite, string title, string desc = null); // 0x00000001804E08E0-0x00000001804E0970
	private static List<Chapter> Build(); // 0x00000001804E0970-0x00000001804E6460
}

