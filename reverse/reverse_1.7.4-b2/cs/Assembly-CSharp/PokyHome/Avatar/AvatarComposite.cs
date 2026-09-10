/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.Avatar
{
	public static class AvatarComposite // TypeDefIndex: 2443
	{
		// Properties
		public static bool Enabled { get; } // 0x00000001807FE110-0x00000001807FE170 
	
		// Methods
		public static bool TryParse(string layers, out AvatarLayerSpec spec); // 0x00000001807FE100-0x00000001807FE110
		public static Sprite TryGet(string layers, AvatarCompositeOptions o); // 0x00000001807FE050-0x00000001807FE100
		public static void Request(string layers, AvatarCompositeOptions o, object owner, Action<Sprite> onReady); // 0x00000001807FDA70-0x00000001807FE050
		public static void Release(object owner); // 0x00000001807FD8C0-0x00000001807FDA70
	}
}
