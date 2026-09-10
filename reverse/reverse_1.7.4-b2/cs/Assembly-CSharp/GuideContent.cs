/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class GuideContent // TypeDefIndex: 669
{
	// Fields
	private static List<Chapter> _chapters; // 0x00
	private const string GOLD = "#FFDD84"; // Metadata: 0x0068B74E
	private const string GREEN = "#7CFF8A"; // Metadata: 0x0068B756
	private const string RED = "#FF8A7A"; // Metadata: 0x0068B75E

	// Properties
	public static List<Chapter> Chapters { get; } // 0x0000000180435840-0x00000001804358C0 

	// Nested types
	public enum BlockKind // TypeDefIndex: 670
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

	public class Item // TypeDefIndex: 671
	{
		// Fields
		public string sprite; // 0x10
		public string title; // 0x18
		public string desc; // 0x20

		// Constructors
		public Item(string sprite, string title, string desc = null); // 0x000000018044EF70-0x000000018044EFE0
	}

	public class Block // TypeDefIndex: 672
	{
		// Fields
		public BlockKind kind; // 0x10
		public string text; // 0x18
		public string sprite; // 0x20
		public List<Item> items; // 0x28
		public float size; // 0x30

		// Constructors
		public Block(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	public class Chapter // TypeDefIndex: 673
	{
		// Fields
		public string title; // 0x10
		public string heading; // 0x18
		public string icon; // 0x20
		public List<Block> blocks; // 0x28

		// Constructors
		public Chapter(string title, string heading, string icon, params Block[] blocks); // 0x000000018042A500-0x000000018042A5D0
	}

	// Methods
	private static Block H(string text, string icon = null); // 0x00000001804351B0-0x0000000180435240
	private static Block P(string text); // 0x0000000180435460-0x00000001804354E0
	private static Block Hero(string sprite, string caption, float height = 150f /* Metadata: 0x0068B745 */); // 0x0000000180435240-0x00000001804352F0
	private static Block Row(float iconSize, params Item[] items); // 0x00000001804354E0-0x00000001804355B0
	private static Block List(float iconSize, params Item[] items); // 0x0000000180435390-0x0000000180435460
	private static Block Gallery(float cellHeight, params Item[] items); // 0x00000001804350E0-0x00000001804351B0
	private static Block Steps(params string[] steps); // 0x00000001804355B0-0x00000001804357B0
	private static Block Tip(string text, string icon = "hand" /* Metadata: 0x0068B749 */); // 0x00000001804357B0-0x0000000180435840
	private static Block Cycle(); // 0x0000000180435080-0x00000001804350E0
	private static Block Board(); // 0x000000018042CF60-0x000000018042CFC0
	private static Item I(string sprite, string title, string desc = null); // 0x00000001804352F0-0x0000000180435390
	private static List<Chapter> Build(); // 0x000000018042CFC0-0x0000000180435080
}

