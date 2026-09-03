/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	public class EnumerationOptions // TypeDefIndex: 3676
	{
		// Fields
		[CompilerGenerated]
		private static readonly EnumerationOptions _Compatible_k__BackingField; // 0x00
		[CompilerGenerated]
		private static readonly EnumerationOptions _CompatibleRecursive_k__BackingField; // 0x08
		[CompilerGenerated]
		private static readonly EnumerationOptions _Default_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _RecurseSubdirectories_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _IgnoreInaccessible_k__BackingField; // 0x11
		[CompilerGenerated]
		private int _BufferSize_k__BackingField; // 0x14
		[CompilerGenerated]
		private FileAttributes _AttributesToSkip_k__BackingField; // 0x18
		[CompilerGenerated]
		private MatchType _MatchType_k__BackingField; // 0x1C
		[CompilerGenerated]
		private MatchCasing _MatchCasing_k__BackingField; // 0x20
		[CompilerGenerated]
		private bool _ReturnSpecialDirectories_k__BackingField; // 0x24
	
		// Properties
		internal static EnumerationOptions Compatible { [CompilerGenerated] get; } // 0x00000001815C02A0-0x00000001815C02F0 
		private static EnumerationOptions CompatibleRecursive { [CompilerGenerated] get; } // 0x00000001815C0250-0x00000001815C02A0 
		internal static EnumerationOptions Default { [CompilerGenerated] get; } // 0x00000001815C02F0-0x00000001815C0340 
		public bool RecurseSubdirectories { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		public bool IgnoreInaccessible { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E38E10-0x0000000180E38E20 0x00000001815C0340-0x00000001815C0350
		public int BufferSize { [CompilerGenerated] get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public FileAttributes AttributesToSkip { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public MatchType MatchType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public MatchCasing MatchCasing { [CompilerGenerated] get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public bool ReturnSpecialDirectories { [CompilerGenerated] get; } // 0x000000018153BC50-0x000000018153BC60 
	
		// Constructors
		public EnumerationOptions(); // 0x00000001815C0220-0x00000001815C0250
		static EnumerationOptions(); // 0x00000001815C00F0-0x00000001815C0220
	
		// Methods
		internal static EnumerationOptions FromSearchOption(SearchOption searchOption); // 0x00000001815BFF80-0x00000001815C00F0
	}
}
