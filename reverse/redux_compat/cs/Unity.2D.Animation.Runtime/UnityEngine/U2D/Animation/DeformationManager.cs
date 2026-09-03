/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D.Animation.Profiler;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal class DeformationManager : ScriptableObject // TypeDefIndex: 14349
	{
		// Fields
		private static DeformationManager s_Instance; // 0x00
		private BaseDeformationSystem[] m_DeformationSystems; // 0x18
		[SerializeField]
		private GameObject m_Helper; // 0x20
		[CompilerGenerated]
		private bool _canUseGpuDeformation_k__BackingField; // 0x28
		private bool m_WasUsingSRPBatcherLastFrame; // 0x29
		private bool m_WasUsingGpuDeformationLastFrame; // 0x2A
		private bool m_HandleDeformationChange; // 0x2B
	
		// Properties
		public static DeformationManager instance { get; } // 0x0000000181C1C3A0-0x0000000181C1C4F0 
		private UniversalRenderPipelineAsset urpPipelineAsset { get; } // 0x0000000181C1C4F0-0x0000000181C1C5C0 
		internal GameObject helperGameObject { get; } // 0x00000001802F8630-0x00000001802F8640 
		private bool canUseGpuDeformation { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
	
		// Constructors
		public DeformationManager(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		private void OnEnable(); // 0x0000000181C1BEC0-0x0000000181C1BFB0
		private void Init(); // 0x0000000181C1BAA0-0x0000000181C1BAC0
		private void CreateBatchSystems(); // 0x0000000181C1B230-0x0000000181C1B490
		private void CreateHelper(); // 0x0000000181C1B490-0x0000000181C1B640
		private void OnHelperDestroyed(GameObject helperGo); // 0x0000000181C1BFB0-0x0000000181C1C040
		private void OnDisable(); // 0x0000000181C1BCE0-0x0000000181C1BEC0
		internal void Update(); // 0x0000000181C1C280-0x0000000181C1C3A0
		[Conditional("ENABLE_PROFILER")]
		private void EmitProfilerData(); // 0x0000000181C1B640-0x0000000181C1BA10
		private SpriteSkinProfilerFrameData.SpriteSkinType GetDeformationType(Type deformationType); // 0x0000000181C1BA10-0x0000000181C1BAA0
		private bool UpdateGpuDeformationConfig(); // 0x0000000181C1C1D0-0x0000000181C1C280
		private void MoveSpriteSkinsToActiveSystem(); // 0x0000000181C1BAC0-0x0000000181C1BCE0
		internal void AddSpriteSkin(SpriteSkin spriteSkin, bool isUpdateSpriteDeformationData = true /* Metadata: 0x006A965F */); // 0x0000000181C1AFB0-0x0000000181C1B230
		internal void RemoveBoneTransforms(SpriteSkin spriteSkin); // 0x0000000181C1C040-0x0000000181C1C1D0
		internal void AddSpriteSkinBoneTransform(SpriteSkin spriteSkin); // 0x0000000181C1AF30-0x0000000181C1AFB0
	}
}
