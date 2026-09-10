/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerPetStage : MonoBehaviour // TypeDefIndex: 2400
	{
		// Fields
		public const string N_STAGE = "sec_PetStage"; // Metadata: 0x0068EEF9
		public const string N_PET = "img_Pet"; // Metadata: 0x0068EF06
		public const string N_PORTRAIT = "img_Portrait"; // Metadata: 0x0068EF0E
		public const string N_AVATAR = "sec_Avatar"; // Metadata: 0x0068EF1B
		private const float FEET_V = 0.7675781f; // Metadata: 0x0068EF26
		private const float BODY_U = 0.51953125f; // Metadata: 0x0068EF2A
		private const float OFFSET_X = 0.23f; // Metadata: 0x0068EF2E
		private const float OFFSET_Y = 0.0324f; // Metadata: 0x0068EF32
		private const float BOX_W = 0.3578f; // Metadata: 0x0068EF36
		private const float BOX_H = 0.2683f; // Metadata: 0x0068EF3A
		private const float PAD = 10f; // Metadata: 0x0068EF3E
		private RectTransform _stage; // 0x20
		private RectTransform _petRect; // 0x28
		private Animator _anim; // 0x30
		private Image _img; // 0x38
		private PetImageFit _fit; // 0x40
		[CompilerGenerated]
		private long _PetId_k__BackingField; // 0x48
		private int _iconToken; // 0x50
		private bool _built; // 0x54
	
		// Properties
		public long PetId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180319990-0x00000001803199A0 0x00000001807E3DF0-0x00000001807E3E00
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass25_0 // TypeDefIndex: 2401
		{
			// Fields
			public InfoPlayerPetStage __4__this; // 0x10
			public EquipSlotView view; // 0x18
			public int token; // 0x20
			public long wanted; // 0x28
	
			// Constructors
			public __c__DisplayClass25_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _ApplySlotIcon_b__0(Sprite sp); // 0x00000001807F5680-0x00000001807F5750
		}
	
		// Constructors
		public InfoPlayerPetStage(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		public void EnsureBuilt(); // 0x00000001807E3220-0x00000001807E3B10
		private void ConfigureRig(); // 0x00000001807E3150-0x00000001807E3220
		public void Show(long petId); // 0x00000001807E3BC0-0x00000001807E3DF0
		public void ApplySlotIcon(EquipSlotsPresenter slots); // 0x00000001807E2D60-0x00000001807E3050
		private static void SetIcon(EquipSlotView view, Sprite sprite); // 0x00000001807E3B20-0x00000001807E3BC0
		public void Clear(); // 0x00000001807E3050-0x00000001807E3150
		private void OnDisable(); // 0x00000001807E3B10-0x00000001807E3B20
	}
}
