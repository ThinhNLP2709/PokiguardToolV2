/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerAvatarTap : MonoBehaviour, IPointerClickHandler // TypeDefIndex: 2367
	{
		// Fields
		public const string NODE_NAME = "tapAvatar"; // Metadata: 0x0068EDA6
		public const string N_PORTRAIT = "img_Portrait"; // Metadata: 0x0068EDB0
		public const string N_AVATAR = "sec_Avatar"; // Metadata: 0x0068EDBD
		[NonSerialized]
		public Action onTap; // 0x20
		[CompilerGenerated]
		private RectTransform _Anchor_k__BackingField; // 0x28
	
		// Properties
		public RectTransform Anchor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FF640-0x00000001802FF650 0x0000000180308AC0-0x0000000180308AD0
	
		// Constructors
		public InfoPlayerAvatarTap(); // 0x00000001802EBA70-0x00000001802EBAF0
	
		// Methods
		public void OnPointerClick(PointerEventData eventData); // 0x000000018033FE40-0x000000018033FE60
		public static InfoPlayerAvatarTap Ensure(Transform popupRoot, Action onTap); // 0x00000001807D8AB0-0x00000001807D8F60
	}
}
