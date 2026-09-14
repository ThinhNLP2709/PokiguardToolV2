/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerAvatarTap : MonoBehaviour, IPointerClickHandler // TypeDefIndex: 2817
	{
		// Fields
		public const string NODE_NAME = "tapAvatar"; // Metadata: 0x005F3069
		public const string N_PORTRAIT = "img_Portrait"; // Metadata: 0x005F3073
		public const string N_AVATAR = "sec_Avatar"; // Metadata: 0x005F3080
		[NonSerialized]
		public Action onTap; // 0x20
		[CompilerGenerated]
		private RectTransform _Anchor_k__BackingField; // 0x28
	
		// Properties
		public RectTransform Anchor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8730-0x00000001802A8740 0x00000001802BA510-0x00000001802BA570
	
		// Constructors
		public InfoPlayerAvatarTap(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		public void OnPointerClick(PointerEventData eventData); // 0x000000018030A6B0-0x000000018030A6D0
		public static InfoPlayerAvatarTap Ensure(Transform popupRoot, Action onTap); // 0x0000000180CF7370-0x0000000180CF7D30
	}
}
