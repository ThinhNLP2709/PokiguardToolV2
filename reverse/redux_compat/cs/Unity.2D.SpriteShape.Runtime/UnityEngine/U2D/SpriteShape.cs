/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace UnityEngine.U2D
{
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.2d.spriteshape@latest/index.html?subfolder=/manual/SSProfile.html")]
	public class SpriteShape : ScriptableObject // TypeDefIndex: 13997
	{
		// Fields
		[SerializeField]
		private List<AngleRange> m_Angles; // 0x18
		[SerializeField]
		private Texture2D m_FillTexture; // 0x20
		[SerializeField]
		private List<CornerSprite> m_CornerSprites; // 0x28
		[SerializeField]
		private float m_FillOffset; // 0x30
		[SerializeField]
		private bool m_UseSpriteBorders; // 0x34
	
		// Properties
		public List<AngleRange> angleRanges { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public Texture2D fillTexture { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public List<CornerSprite> cornerSprites { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public float fillOffset { get; set; } // 0x00000001806CCB40-0x00000001806CCB50 0x00000001806CCD50-0x00000001806CCD60
		public bool useSpriteBorders { get; set; } // 0x00000001816DAFD0-0x00000001816DAFE0 0x0000000181C10650-0x0000000181C10660
	
		// Constructors
		public SpriteShape(); // 0x0000000181C594E0-0x0000000181C595B0
	
		// Methods
		private CornerSprite GetCornerSprite(CornerType cornerType); // 0x0000000181C59080-0x0000000181C59150
		private void ResetCornerList(); // 0x0000000181C59290-0x0000000181C59490
		private void OnValidate(); // 0x0000000181C59260-0x0000000181C59290
		private void Reset(); // 0x0000000181C59490-0x0000000181C594E0
		internal static int GetSpriteShapeHashCode(SpriteShape spriteShape); // 0x0000000181C59150-0x0000000181C59260
	}
}
