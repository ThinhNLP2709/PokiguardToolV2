/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 62: UnityEngine.TextRenderingModule.dll - Assembly: UnityEngine.TextRenderingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15763-15782

namespace UnityEngine
{
	[UsedByNativeCode]
	public struct CharacterInfo // TypeDefIndex: 15777
	{
		// Fields
		public int index; // 0x00
		[Obsolete("CharacterInfo.uv is deprecated. Use uvBottomLeft, uvBottomRight, uvTopRight or uvTopLeft instead.")]
		public Rect uv; // 0x04
		[Obsolete("CharacterInfo.vert is deprecated. Use minX, maxX, minY, maxY instead.")]
		public Rect vert; // 0x14
		[NativeName("advance")]
		[Obsolete("CharacterInfo.width is deprecated. Use advance instead.")]
		public float width; // 0x24
		public int size; // 0x28
		public FontStyle style; // 0x2C
		[Obsolete("CharacterInfo.flipped is deprecated. Use uvBottomLeft, uvBottomRight, uvTopRight or uvTopLeft instead, which will be correct regardless of orientation.")]
		public bool flipped; // 0x30
	}
}
