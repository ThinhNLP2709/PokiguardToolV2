/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeAvatar : MonoBehaviour // TypeDefIndex: 1874
	{
		// Fields
		[Tooltip("\u1EA2nh \u0111\u1EA1i di\u1EC7n (node \'Image\' \u2014 RawImage, b\u1EA3n g\u1ED1c kh\u00F4ng c\u00F3 texture).")]
		public RawImage avatarRaw; // 0x20
		[Tooltip("Vi\u1EC1n quanh \u1EA3nh (node \'ImageAvatarFrame\').")]
		public RawImage frameRaw; // 0x28
		[Tooltip("Ch\u1EEF c\u1EA5p (node \'TextLevel\').")]
		public UnityEngine.UI.Text levelText; // 0x30
		private int _avtId; // 0x38
	
		// Constructors
		public PokyHomeAvatar(); // 0x000000018062A1E0-0x000000018062A1F0
	
		// Methods
		public void Bind(UserDTO user); // 0x000000018062A030-0x000000018062A1E0
	}
}
