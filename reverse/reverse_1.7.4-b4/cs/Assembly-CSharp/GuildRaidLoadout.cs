/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class GuildRaidLoadout // TypeDefIndex: 888
{
	// Fields
	private static readonly List<CardData> _deck; // 0x00
	private static bool _loaded; // 0x08
	private static List<CardData> _inventory; // 0x10
	private static string _invOwner; // 0x18
	private static readonly Dictionary<int, PetUserDTO> _seenPets; // 0x20

	// Properties
	public static List<CardData> Deck { get; } // 0x0000000180569090-0x00000001805690F0 
	public static int Count { get; } // 0x00000001805690F0-0x0000000180569160 
	public static int PetId { get; } // 0x000000018056A590-0x000000018056A5A0 
	public static int PetIdRaw { get; } // 0x0000000180550FD0-0x0000000180550FE0 
	public static List<CardData> Inventory { get; } // 0x000000018056A710-0x000000018056A7C0 

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 889
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Comparison<CardData> __9__40_0; // 0x08

		// Constructors
		static __c(); // 0x000000018056B650-0x000000018056B6F0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal int _FilterAndSort_b__40_0(CardData a, CardData b); // 0x000000018056B6F0-0x000000018056B740
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass39_0 // TypeDefIndex: 890
	{
		// Fields
		public bool done; // 0x10
		public RoomBootstrapData data; // 0x18
		public string failReason; // 0x20

		// Constructors
		public __c__DisplayClass39_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _FetchInventory_b__0(RoomBootstrapData d); // 0x00000001802B4FE0-0x00000001802B5040
		internal void _FetchInventory_b__1(string r); // 0x00000001803C2EA0-0x00000001803C2F00
	}

	[CompilerGenerated]
	private sealed class _FetchInventory_d__39 : IEnumerator<object> // TypeDefIndex: 891
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> onError; // 0x20
		private __c__DisplayClass39_0 __8__1; // 0x28
		public Action<List<CardData>> onDone; // 0x30
		private ChatService _cs_5__2; // 0x38
		private Action<RoomBootstrapData> _onResp_5__3; // 0x40
		private Action<string> _onFail_5__4; // 0x48
		private float _t_5__5; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FetchInventory_d__39(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018056B740-0x000000018056B8A0
		private bool MoveNext(); // 0x000000018056B8A0-0x000000018056BF40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018056BF40-0x000000018056BF80
	}

	// Constructors
	static GuildRaidLoadout(); // 0x000000018056B4A0-0x000000018056B650

	// Methods
	public static List<int> CardIds(); // 0x0000000180569160-0x00000001805692F0
	public static int CountOf(long cardId); // 0x00000001805692F0-0x00000001805693C0
	public static bool IsAttack(CardData c); // 0x00000001805693C0-0x0000000180569460
	public static bool CanAdd(CardData card, out string reason); // 0x0000000180569460-0x0000000180569910
	public static bool Add(CardData card); // 0x0000000180569910-0x00000001805699C0
	public static void RemoveAt(int index); // 0x00000001805699C0-0x0000000180569A50
	public static bool RemoveLast(long cardId); // 0x0000000180569A50-0x0000000180569B40
	public static string CardName(CardData c); // 0x0000000180569B40-0x0000000180569C10
	public static string ArtPath(CardData c); // 0x0000000180569C10-0x0000000180569C70
	private static void EnsureOwner(); // 0x0000000180569C70-0x0000000180569F00
	private static string CurrentUser(); // 0x0000000180569F00-0x0000000180569FA0
	private static void EnsureLoaded(); // 0x0000000180569FA0-0x000000018056A010
	private static void LoadFromPrefs(); // 0x000000018056A010-0x000000018056A3C0
	public static void Save(); // 0x000000018056A3C0-0x000000018056A590
	public static void SetPet(int petId); // 0x000000018056A5A0-0x000000018056A5B0
	public static void RememberPet(PetUserDTO pet); // 0x000000018056A5B0-0x000000018056A660
	public static PetUserDTO SeenPet(int petId); // 0x000000018056A660-0x000000018056A710
	public static void LoadInventory(Action<List<CardData>> onDone, Action<string> onError); // 0x000000018056A7C0-0x000000018056AAD0
	[IteratorStateMachine(typeof(_FetchInventory_d__39))]
	private static IEnumerator FetchInventory(Action<List<CardData>> onDone, Action<string> onError); // 0x000000018056AAD0-0x000000018056ABE0
	private static List<CardData> FilterAndSort(List<CardData> src); // 0x000000018056ABE0-0x000000018056AED0
	private static void Prune(); // 0x000000018056AED0-0x000000018056B4A0
}

