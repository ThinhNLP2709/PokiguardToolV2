/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[AddComponentMenu("Rendering/Adaptive Probe Volume")]
	[ExecuteAlways]
	public class ProbeVolume : MonoBehaviour // TypeDefIndex: 5592
	{
		// Fields
		[SerializeField]
		private Version version; // 0x20
		[Obsolete("Use mode instead. #from(2023.1)")]
		[SerializeField]
		public bool globalVolume; // 0x24
		[Tooltip("When set to Global this Probe Volume considers all renderers with Contribute Global Illumination enabled. Local only considers renderers in the scene.\nThis list updates every time the Scene is saved or the lighting is baked.")]
		public Mode mode; // 0x28
		public Vector3 size; // 0x2C
		[HideInInspector]
		[Min(0f)]
		public bool overrideRendererFilters; // 0x38
		[HideInInspector]
		[Min(0f)]
		public float minRendererVolumeSize; // 0x3C
		public LayerMask objectLayerMask; // 0x40
		[HideInInspector]
		public int lowestSubdivLevelOverride; // 0x44
		[HideInInspector]
		public int highestSubdivLevelOverride; // 0x48
		[HideInInspector]
		public bool overridesSubdivLevels; // 0x4C
		[SerializeField]
		internal bool mightNeedRebaking; // 0x4D
		[SerializeField]
		internal Matrix4x4 cachedTransform; // 0x50
		[SerializeField]
		internal int cachedHashCode; // 0x90
		[HideInInspector]
		[Tooltip("Whether Unity should fill empty space between renderers with bricks at the highest subdivision level.")]
		public bool fillEmptySpaces; // 0x94
	
		// Nested types
		private enum Version // TypeDefIndex: 5593
		{
			Initial = 0,
			LocalMode = 1,
			InvertOverrideLevels = 2,
			Count = 3
		}
	
		public enum Mode // TypeDefIndex: 5594
		{
			Global = 0,
			Scene = 1,
			Local = 2
		}
	
		// Constructors
		public ProbeVolume(); // 0x0000000181E88630-0x0000000181E88690
	
		// Methods
		private void Awake(); // 0x0000000181E88600-0x0000000181E88630
	}
}
