/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	public class ShardStore // TypeDefIndex: 2863
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
		public int MaxStar { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FAC70-0x00000001802FAD20 0x000000018028E160-0x000000018028E170
		public int ExchangeCost { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D05EE0-0x0000000180D05EF0 0x0000000180D05EF0-0x0000000180D05F00
		public int TotalShards { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D05F00-0x0000000180D05F10 0x0000000180D05F10-0x0000000180D05F20
		public int ReadyCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180BBBF60-0x0000000180BBBF70 0x0000000180BBBF70-0x0000000180BBBF80
		public int UpgradeCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180BBBF80-0x0000000180BBBF90 0x0000000180BBBF90-0x0000000180BBBFA0
		public int ExchangeCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D05F20-0x0000000180D05F30 0x0000000180D05F30-0x0000000180D05F40
		public bool FilterReady { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B4AD0-0x00000001802B4AE0 0x00000001808D4080-0x00000001808D4090
		public bool Loading { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018047FC70-0x000000018047FC80 0x000000018047FC80-0x000000018047FC90
		public bool Exchanging { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018047FC90-0x000000018047FCA0 0x000000018047FCA0-0x000000018047FCB0
		public bool Loaded { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D05F40-0x0000000180D05F50 0x0000000180D05F50-0x0000000180D05F60
		public int Page { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180562890-0x00000001805628A0 0x00000001805628A0-0x00000001805628B0
		public int Count { get; } // 0x0000000180D06380-0x0000000180D063B0 
		public int TotalPages { get; } // 0x0000000180D063B0-0x0000000180D06400 
	
		// Events
		public event Action Changed {
			add; // 0x0000000180D05F60-0x0000000180D06050
			remove; // 0x0000000180D06050-0x0000000180D06140
		}
		public event Action<string> Toast {
			add; // 0x0000000180D06140-0x0000000180D06260
			remove; // 0x0000000180D06260-0x0000000180D06380
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass64_0 // TypeDefIndex: 2864
		{
			// Fields
			public int rid; // 0x10
			public ShardStore __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass64_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Load_b__0(PetShardListResponse resp); // 0x0000000180D074A0-0x0000000180D07520
			internal void _Load_b__1(string err); // 0x0000000180D07520-0x0000000180D07630
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass66_0 // TypeDefIndex: 2865
		{
			// Fields
			public ShardStore __4__this; // 0x10
			public Action<PetExchangeResponse> onDone; // 0x18
			public PetShardDTO dto; // 0x20
	
			// Constructors
			public __c__DisplayClass66_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Exchange_b__0(PetExchangeResponse resp); // 0x0000000180D07630-0x0000000180D078F0
			internal void _Exchange_b__1(string err); // 0x0000000180D078F0-0x0000000180D07A00
		}
	
		// Constructors
		public ShardStore(); // 0x0000000180D07370-0x0000000180D074A0
	
		// Methods
		public PetShardDTO At(int indexInFiltered); // 0x0000000180D06400-0x0000000180D06470
		public void Reset(); // 0x0000000180D06470-0x0000000180D064D0
		public bool CanExchange(PetShardDTO dto); // 0x0000000180D064D0-0x0000000180D06500
		public bool IsActionable(PetShardDTO dto); // 0x0000000180D06500-0x0000000180D06540
		public void SetPage(int page); // 0x0000000180D06540-0x0000000180D065C0
		public void ToggleFilter(); // 0x0000000180D065C0-0x0000000180D06610
		public void Load(); // 0x0000000180D06610-0x0000000180D06A40
		private void Apply(PetShardListResponse resp); // 0x0000000180D06A40-0x0000000180D06D10
		public void Exchange(PetShardDTO dto, Action<PetExchangeResponse> onDone); // 0x0000000180D06D10-0x0000000180D07320
		public static string SafeName(PetShardDTO dto); // 0x0000000180D07320-0x0000000180D07370
	}
}
