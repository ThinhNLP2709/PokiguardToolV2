/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	public class ShardStore // TypeDefIndex: 2870
	{
		// Fields
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
		public int MaxStar { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FACA0-0x00000001802FAD50 0x000000018028E160-0x000000018028E170
		public int ExchangeCost { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D13960-0x0000000180D13970 0x0000000180D13970-0x0000000180D13980
		public int TotalShards { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D13980-0x0000000180D13990 0x0000000180D13990-0x0000000180D139A0
		public int ReadyCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180BC9380-0x0000000180BC9390 0x0000000180BC9390-0x0000000180BC93A0
		public int UpgradeCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180BC93A0-0x0000000180BC93B0 0x0000000180BC93B0-0x0000000180BC93C0
		public int ExchangeCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D139A0-0x0000000180D139B0 0x0000000180D139B0-0x0000000180D139C0
		public bool FilterReady { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B4AD0-0x00000001802B4AE0 0x00000001808D6F80-0x00000001808D6F90
		public bool Loading { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180480EE0-0x0000000180480EF0 0x0000000180480EF0-0x0000000180480F00
		public bool Exchanging { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180480F00-0x0000000180480F10 0x0000000180480F10-0x0000000180480F20
		public bool Loaded { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D139C0-0x0000000180D139D0 0x0000000180D139D0-0x0000000180D139E0
		public int Page { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805641C0-0x00000001805641D0 0x00000001805641D0-0x00000001805641E0
		public int Count { get; } // 0x0000000180D13E00-0x0000000180D13E30 
		public int TotalPages { get; } // 0x0000000180D13E30-0x0000000180D13E80 
	
		// Events
		public event Action Changed {
			add; // 0x0000000180D139E0-0x0000000180D13AD0
			remove; // 0x0000000180D13AD0-0x0000000180D13BC0
		}
		public event Action<string> Toast {
			add; // 0x0000000180D13BC0-0x0000000180D13CE0
			remove; // 0x0000000180D13CE0-0x0000000180D13E00
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass64_0 // TypeDefIndex: 2871
		{
			// Fields
			public int rid; // 0x10
			public ShardStore __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass64_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Load_b__0(PetShardListResponse resp); // 0x0000000180D14F60-0x0000000180D14FE0
			internal void _Load_b__1(string err); // 0x0000000180D14FE0-0x0000000180D150F0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass66_0 // TypeDefIndex: 2872
		{
			// Fields
			public ShardStore __4__this; // 0x10
			public Action<PetExchangeResponse> onDone; // 0x18
			public PetShardDTO dto; // 0x20
	
			// Constructors
			public __c__DisplayClass66_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Exchange_b__0(PetExchangeResponse resp); // 0x0000000180D150F0-0x0000000180D153B0
			internal void _Exchange_b__1(string err); // 0x0000000180D153B0-0x0000000180D154C0
		}
	
		// Constructors
		public ShardStore(); // 0x0000000180D14E30-0x0000000180D14F60
	
		// Methods
		public PetShardDTO At(int indexInFiltered); // 0x0000000180D13E80-0x0000000180D13EF0
		public void Reset(); // 0x0000000180D13EF0-0x0000000180D13F50
		public bool CanExchange(PetShardDTO dto); // 0x0000000180D13F50-0x0000000180D13F80
		public bool IsActionable(PetShardDTO dto); // 0x0000000180D13F80-0x0000000180D13FC0
		public void SetPage(int page); // 0x0000000180D13FC0-0x0000000180D14040
		public void ToggleFilter(); // 0x0000000180D14040-0x0000000180D14090
		public void Load(); // 0x0000000180D14090-0x0000000180D144E0
		private void Apply(PetShardListResponse resp); // 0x0000000180D144E0-0x0000000180D147B0
		public void Exchange(PetShardDTO dto, Action<PetExchangeResponse> onDone); // 0x0000000180D147B0-0x0000000180D14DE0
		public static string SafeName(PetShardDTO dto); // 0x0000000180D14DE0-0x0000000180D14E30
	}
}
