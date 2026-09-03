/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace UnityEngine.U2D
{
	internal class SpriteShapeCopyUtility<T> // TypeDefIndex: 13989
		where T : struct
	{
		// Constructors
		public SpriteShapeCopyUtility();
	
		// Methods
		internal static void Copy(NativeSlice<T> dst, T[] src, int length);
		internal static void Copy(T[] dst, NativeSlice<T> src, int length);
	}
}
