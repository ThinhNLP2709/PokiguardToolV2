/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.Avatar
{
	public static class AvatarComposite // TypeDefIndex: 2890
	{
		// Properties
		public static bool Enabled { get; } // 0x0000000180D34170-0x0000000180D341E0 
	
		// Methods
		public static bool TryParse(string layers, out AvatarLayerSpec spec); // 0x0000000180D341E0-0x0000000180D341F0
		public static Sprite TryGet(string layers, AvatarCompositeOptions o); // 0x0000000180D341F0-0x0000000180D342B0
		public static void Request(string layers, AvatarCompositeOptions o, object owner, Action<Sprite> onReady); // 0x0000000180D342B0-0x0000000180D34970
		public static void Release(object owner); // 0x0000000180D34970-0x0000000180D349C0
	}
}
