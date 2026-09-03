/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.U2D.Common;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[AddComponentMenu("2D Animation/Sprite Resolver")]
	[DefaultExecutionOrder(-20)]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.2d.animation@16.0/manual/SL-Resolver.html")]
	[MovedFrom("UnityEngine.Experimental.U2D.Animation")]
	public class SpriteResolver : MonoBehaviour, IPreviewable // TypeDefIndex: 14406
	{
		// Fields
		[SerializeField]
		private float m_CategoryHash; // 0x20
		[SerializeField]
		private float m_labelHash; // 0x24
		[SerializeField]
		private float m_SpriteKey; // 0x28
		[DiscreteEvaluation]
		[SerializeField]
		private int m_SpriteHash; // 0x2C
		private int m_CategoryHashInt; // 0x30
		private int m_LabelHashInt; // 0x34
		private int m_PreviousCategoryHash; // 0x38
		private int m_PreviousLabelHash; // 0x3C
		private int m_PreviousSpriteKeyInt; // 0x40
		private int m_PreviousSpriteHash; // 0x44
	
		// Properties
		private SpriteRenderer spriteRenderer { get; } // 0x0000000181C24EC0-0x0000000181C24F00 
		public SpriteLibrary spriteLibrary { get; } // 0x0000000181C24E70-0x0000000181C24EC0 
	
		// Constructors
		public SpriteResolver(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void Reset(); // 0x0000000181C24550-0x0000000181C24630
		private void SetSprite(Sprite sprite); // 0x0000000181C24A70-0x0000000181C24E70
		private void OnEnable(); // 0x0000000181C24520-0x0000000181C24540
		private void InitializeSerializedData(); // 0x0000000181C24180-0x0000000181C244D0
		public bool SetCategoryAndLabel(string category, string label); // 0x0000000181C24A30-0x0000000181C24A70
		public string GetCategory(); // 0x0000000181C23E50-0x0000000181C23F40
		public string GetLabel(); // 0x0000000181C23F40-0x0000000181C24030
		public void OnPreviewUpdate(); // 0x00000001802E76C0-0x00000001802E76D0
		private static bool IsInGUIUpdateLoop(); // 0x0000000181C244D0-0x0000000181C24510
		internal void LateUpdate(); // 0x0000000181C24510-0x0000000181C24520
		private void ResolveUpdatedValue(); // 0x0000000181C24830-0x0000000181C24A30
		internal static int ConvertCategoryLabelHashToSpriteKey(SpriteLibrary library, int categoryHash, int labelHash); // 0x0000000181C23A30-0x0000000181C23E50
		internal Sprite GetSprite(out bool validEntry); // 0x0000000181C24030-0x0000000181C24180
		public bool ResolveSpriteToSpriteRenderer(); // 0x0000000181C24630-0x0000000181C24830
		private void OnTransformParentChanged(); // 0x0000000181C24540-0x0000000181C24550
	}
}
