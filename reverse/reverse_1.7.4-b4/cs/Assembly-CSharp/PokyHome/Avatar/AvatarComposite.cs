/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.Avatar
{
	public static class AvatarComposite // TypeDefIndex: 2897
	{
		// Properties
		public static bool Enabled { get; } // 0x0000000180D41F30-0x0000000180D41FA0 
	
		// Methods
		public static bool TryParse(string layers, out AvatarLayerSpec spec); // 0x0000000180D41FA0-0x0000000180D41FB0
		public static Sprite TryGet(string layers, AvatarCompositeOptions o); // 0x0000000180D41FB0-0x0000000180D42070
		public static void Request(string layers, AvatarCompositeOptions o, object owner, Action<Sprite> onReady); // 0x0000000180D42070-0x0000000180D42730
		public static void Release(object owner); // 0x0000000180D42730-0x0000000180D42780
	}
}
