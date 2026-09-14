/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerPetStage : MonoBehaviour // TypeDefIndex: 2845
	{
		// Fields
		public const string N_STAGE = "sec_PetStage"; // Metadata: 0x005F1D75
		public const string N_PET = "img_Pet"; // Metadata: 0x005F1D82
		public const string N_PORTRAIT = "img_Portrait"; // Metadata: 0x005F1D8A
		public const string N_AVATAR = "sec_Avatar"; // Metadata: 0x005F1D97
		private const float FEET_V = 0.7675781f; // Metadata: 0x005F1DA2
		private const float BODY_U = 0.51953125f; // Metadata: 0x005F1DA6
		private const float OFFSET_X = 0.23f; // Metadata: 0x005F1DAA
		private const float OFFSET_Y = 0.0324f; // Metadata: 0x005F1DAE
		private const float BOX_W = 0.3578f; // Metadata: 0x005F1DB2
		private const float BOX_H = 0.2683f; // Metadata: 0x005F1DB6
		private const float PAD = 10f; // Metadata: 0x005F1DBA
		private const float STAR_OF_BOX_W = 0.09f; // Metadata: 0x005F1DBE
		private const float STAR_GAP = 2f; // Metadata: 0x005F1DC2
		private RectTransform _stage; // 0x20
		private RectTransform _petRect; // 0x28
		private Animator _anim; // 0x30
		private Image _img; // 0x38
		private PetImageFit _fit; // 0x40
		private PetStarBadge _starBadge; // 0x48
		private int _star; // 0x50
		private int _starMax; // 0x54
		[CompilerGenerated]
		private long _PetId_k__BackingField; // 0x58
		private int _iconToken; // 0x60
		private bool _built; // 0x64
	
		// Properties
		public long PetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803456E0-0x00000001803456F0 0x00000001803C6050-0x00000001803C6060
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass32_0 // TypeDefIndex: 2846
		{
			// Fields
			public InfoPlayerPetStage __4__this; // 0x10
			public EquipSlotView view; // 0x18
			public int token; // 0x20
			public long wanted; // 0x28
	
			// Constructors
			public __c__DisplayClass32_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ApplySlotIcon_b__0(Sprite sp); // 0x0000000180D02540-0x0000000180D027A0
		}
	
		// Constructors
		public InfoPlayerPetStage(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		public void EnsureBuilt(); // 0x0000000180CFFF80-0x0000000180D01050
		private void BuildStarBadge(); // 0x0000000180D01050-0x0000000180D01320
		public void SetStar(int star, int maxStar); // 0x0000000180D01320-0x0000000180D01440
		private void ConfigureRig(); // 0x0000000180D01440-0x0000000180D01610
		public void Show(long petId); // 0x0000000180D01610-0x0000000180D01A90
		public void ApplySlotIcon(EquipSlotsPresenter slots); // 0x0000000180D01A90-0x0000000180D020C0
		private static void SetIcon(EquipSlotView view, Sprite sprite); // 0x0000000180D020C0-0x0000000180D02250
		public void Clear(); // 0x0000000180D02250-0x0000000180D02530
		private void OnDisable(); // 0x0000000180D02530-0x0000000180D02540
	}
}
