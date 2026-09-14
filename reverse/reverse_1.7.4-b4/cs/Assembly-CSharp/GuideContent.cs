/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class GuideContent // TypeDefIndex: 760
{
	// Fields
	private static List<Chapter> _chapters; // 0x00

	// Properties
	public static List<Chapter> Chapters { get; } // 0x00000001804E15C0-0x00000001804E1680 

	// Nested types
	public enum BlockKind // TypeDefIndex: 761
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

	public class Item // TypeDefIndex: 762
	{
		// Fields
		public string sprite; // 0x10
		public string title; // 0x18
		public string desc; // 0x20

		// Constructors
		public Item(string sprite, string title, string desc = null); // 0x00000001804E7AD0-0x00000001804E7BD0
	}

	public class Block // TypeDefIndex: 763
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

	public class Chapter // TypeDefIndex: 764
	{
		// Fields
		public string title; // 0x10
		public string heading; // 0x18
		public string icon; // 0x20
		public List<Block> blocks; // 0x28

		// Constructors
		public Chapter(string title, string heading, string icon, params Block[] blocks); // 0x00000001804E7BD0-0x00000001804E7DC0
	}

	// Methods
	private static Block H(string text, string icon = null); // 0x00000001804E1680-0x00000001804E1790
	private static Block P(string text); // 0x00000001804E1790-0x00000001804E1830
	private static Block Row(float iconSize, params Item[] items); // 0x00000001804E1830-0x00000001804E1950
	private static Block List(float iconSize, params Item[] items); // 0x00000001804E1950-0x00000001804E1A70
	private static Block Gallery(float cellHeight, params Item[] items); // 0x00000001804E1A70-0x00000001804E1B90
	private static Block Steps(params string[] steps); // 0x00000001804E1B90-0x00000001804E1DA0
	private static Block Tip(string text, string icon = "hand" /* Metadata: 0x005EFA58 */); // 0x00000001804E1DA0-0x00000001804E1EB0
	private static Block Cycle(); // 0x00000001804E1EB0-0x00000001804E1F00
	private static Block Board(); // 0x00000001804E1F00-0x00000001804E1F50
	private static Item I(string sprite, string title, string desc = null); // 0x00000001804E1F50-0x00000001804E1FE0
	private static List<Chapter> Build(); // 0x00000001804E1FE0-0x00000001804E7AD0
}

