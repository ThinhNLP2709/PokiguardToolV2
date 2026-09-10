/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	public class ShardStore // TypeDefIndex: 2418
	{
		// Fields
		public const int PAGE_SIZE = 20; // Metadata: 0x0068EFD1
		[CompilerGenerated]
		private int _MaxStar_k__BackingField; // 0x10
		[CompilerGenerated]
		private int _ExchangeCost_k__BackingField; // 0x14
		[CompilerGenerated]
		private int _TotalShards_k__BackingField; // 0x18
		[CompilerGenerated]
		private int _ReadyCount_k__BackingField; // 0x1C
		[CompilerGenerated]
		private int _UpgradeCount_k__BackingField; // 0x20
		[CompilerGenerated]
		private int _ExchangeCount_k__BackingField; // 0x24
		[CompilerGenerated]
		private bool _FilterReady_k__BackingField; // 0x28
		[CompilerGenerated]
		private bool _Loading_k__BackingField; // 0x29
		[CompilerGenerated]
		private bool _Exchanging_k__BackingField; // 0x2A
		[CompilerGenerated]
		private bool _Loaded_k__BackingField; // 0x2B
		[CompilerGenerated]
		private int _Page_k__BackingField; // 0x2C
		public readonly List<PetShardDTO> Sorted; // 0x30
		[CompilerGenerated]
		private Action Changed; // 0x38
		[CompilerGenerated]
		private Action<string> Toast; // 0x40
		private int _userId; // 0x48
		private int _requestId; // 0x4C
	
		// Properties
		public int MaxStar { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802EA4B0-0x00000001802EA4C0 0x000000018031CA70-0x000000018031CA80
		public int ExchangeCost { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807C4BF0-0x00000001807C4C00 0x00000001807F33E0-0x00000001807F33F0
		public int TotalShards { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807F3260-0x00000001807F3270 0x00000001807F3420-0x00000001807F3430
		public int ReadyCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807F3200-0x00000001807F3210 0x00000001807F3410-0x00000001807F3420
		public int UpgradeCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807F3270-0x00000001807F3280 0x00000001807F3430-0x00000001807F3440
		public int ExchangeCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807F31E0-0x00000001807F31F0 0x00000001807F33F0-0x00000001807F3400
		public bool FilterReady { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180385C40-0x0000000180385C50 0x00000001805A9C80-0x00000001805A9C90
		public bool Loading { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018042A220-0x000000018042A230 0x000000018042A4E0-0x000000018042A4F0
		public bool Exchanging { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018042A230-0x000000018042A240 0x000000018042A4F0-0x000000018042A500
		public bool Loaded { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807F31F0-0x00000001807F3200 0x00000001807F3400-0x00000001807F3410
		public int Page { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018043A930-0x000000018043A940 0x000000018043AAA0-0x000000018043AAB0
		public int Count { get; } // 0x00000001807F31B0-0x00000001807F31E0 
		public int TotalPages { get; } // 0x00000001807F3210-0x00000001807F3260 
	
		// Events
		public event Action Changed {
			add; // 0x00000001807F3050-0x00000001807F30F0
			remove; // 0x00000001807F3280-0x00000001807F3320
		}
		public event Action<string> Toast {
			add; // 0x00000001807F30F0-0x00000001807F31B0
			remove; // 0x00000001807F3320-0x00000001807F33E0
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass64_0 // TypeDefIndex: 2419
		{
			// Fields
			public int rid; // 0x10
			public ShardStore __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass64_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Load_b__0(PetShardListResponse resp); // 0x00000001807F62D0-0x00000001807F6350
			internal void _Load_b__1(string err); // 0x00000001807F6350-0x00000001807F6450
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass66_0 // TypeDefIndex: 2420
		{
			// Fields
			public ShardStore __4__this; // 0x10
			public Action<PetExchangeResponse> onDone; // 0x18
			public PetShardDTO dto; // 0x20
	
			// Constructors
			public __c__DisplayClass66_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _Exchange_b__0(PetExchangeResponse resp); // 0x00000001807F6450-0x00000001807F66A0
			internal void _Exchange_b__1(string err); // 0x00000001807F66A0-0x00000001807F67A0
		}
	
		// Constructors
		public ShardStore(); // 0x00000001807F2FC0-0x00000001807F3050
	
		// Methods
		public PetShardDTO At(int indexInFiltered); // 0x00000001807F2780-0x00000001807F27D0
		public void Reset(); // 0x00000001807F2E40-0x00000001807F2EA0
		public bool CanExchange(PetShardDTO dto); // 0x00000001807F27D0-0x00000001807F27F0
		public bool IsActionable(PetShardDTO dto); // 0x00000001807F2B90-0x00000001807F2BF0
		public void SetPage(int page); // 0x00000001807F2EF0-0x00000001807F2F70
		public void ToggleFilter(); // 0x00000001807F2F70-0x00000001807F2FC0
		public void Load(); // 0x00000001807F2BF0-0x00000001807F2E40
		private void Apply(PetShardListResponse resp); // 0x00000001807F24D0-0x00000001807F2780
		public void Exchange(PetShardDTO dto, Action<PetExchangeResponse> onDone); // 0x00000001807F27F0-0x00000001807F2B90
		public static string SafeName(PetShardDTO dto); // 0x00000001807F2EA0-0x00000001807F2EF0
	}
}
