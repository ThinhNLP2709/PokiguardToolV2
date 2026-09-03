/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	public class TMP_SpriteCharacter : TMP_TextElement // TypeDefIndex: 11879
	{
		// Fields
		[SerializeField]
		private string m_Name; // 0x30
	
		// Properties
		public string name { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
	
		// Constructors
		public TMP_SpriteCharacter(); // 0x00000001820CC220-0x00000001820CC240
		public TMP_SpriteCharacter(uint unicode, TMP_SpriteGlyph glyph); // 0x00000001820CC1C0-0x00000001820CC220
		public TMP_SpriteCharacter(uint unicode, TMP_SpriteAsset spriteAsset, TMP_SpriteGlyph glyph); // 0x00000001820CC240-0x00000001820CC2C0
		internal TMP_SpriteCharacter(uint unicode, uint glyphIndex); // 0x00000001820CC160-0x00000001820CC1C0
	}
}
