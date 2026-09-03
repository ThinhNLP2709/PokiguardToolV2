/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.U2D.Common;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[AddComponentMenu("2D Animation/Sprite Skin")]
	[DefaultExecutionOrder(10)]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.2d.animation@16.0/manual/SpriteSkin.html")]
	[MovedFrom("UnityEngine.U2D.Experimental.Animation")]
	[Preserve]
	[RequireComponent(typeof(SpriteRenderer))]
	public sealed class SpriteSkin : MonoBehaviour, IPreviewable, ISerializationCallbackReceiver // TypeDefIndex: 14411
	{
		// Fields
		[SerializeField]
		private Transform m_RootBone; // 0x20
		[SerializeField]
		private Transform[] m_BoneTransforms; // 0x28
		[SerializeField]
		private Bounds m_Bounds; // 0x30
		[SerializeField]
		private bool m_AlwaysUpdate; // 0x48
		[SerializeField]
		private bool m_AutoRebind; // 0x49
		[SerializeField]
		private BoundsMode m_BoundsMode; // 0x4C
		private SpriteRenderer m_SpriteRenderer; // 0x50
		private EntityId m_CurrentDeformSprite; // 0x58
		private EntityId m_SpriteId; // 0x60
		private bool m_IsValid; // 0x68
		private SpriteSkinState m_State; // 0x6C
		private bool m_ForceCpuDeformation; // 0x70
		private EntityId m_TextureId; // 0x78
		private EntityId m_TransformId; // 0x80
		private NativeArray<EntityId> m_BoneTransformId; // 0x88
		private EntityId m_RootBoneTransformId; // 0x98
		private NativeCustomSlice<Vector3> m_SpriteVertices; // 0xA0
		private NativeCustomSlice<Vector4> m_SpriteTangents; // 0xB0
		private NativeCustomSlice<BoneWeight> m_SpriteBoneWeights; // 0xC0
		private NativeCustomSlice<Matrix4x4> m_SpriteBindPoses; // 0xD0
		private bool m_SpriteHasTangents; // 0xE0
		private int m_SpriteVertexStreamSize; // 0xE4
		private int m_SpriteVertexCount; // 0xE8
		private int m_SpriteTangentVertexOffset; // 0xEC
		private int m_DataIndex; // 0xF0
		private bool m_BoneCacheUpdateToDate; // 0xF4
		internal Dictionary<int, List<TransformData>> hierarchyCache; // 0xF8
		private NativeArray<int> m_OutlineIndexCache; // 0x100
		private NativeArray<Vector3> m_StaticOutlineVertexCache; // 0x110
		private NativeArray<Vector3> m_DeformedOutlineVertexCache; // 0x120
		private Sprite m_Sprite; // 0x130
		private NativeArray<Bounds> m_BoneBounds; // 0x138
		[CompilerGenerated]
		private DeformationMethods _currentDeformationMethod_k__BackingField; // 0x148
		private BaseDeformationSystem m_DeformationSystem; // 0x150
		private int _outlineDependencyCount; // 0x158
	
		// Properties
		internal NativeArray<Bounds> boneBounds { get; } // 0x0000000181C2D2E0-0x0000000181C2D2F0 
		internal NativeArray<EntityId> boneTransformId { get; } // 0x0000000181C2D2F0-0x0000000181C2D300 
		internal EntityId rootBoneTransformId { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		internal DeformationMethods currentDeformationMethod { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180531AE0-0x0000000180531AF0 0x0000000181C2D560-0x0000000181C2D570
		internal BaseDeformationSystem DeformationSystem { get; } // 0x0000000181C0F6E0-0x0000000181C0F6F0 
		internal bool isOutlineDataRequired { get; } // 0x0000000181C2D320-0x0000000181C2D330 
		internal NativeArray<int> outlineIndices { get; } // 0x0000000181C2D350-0x0000000181C2D360 
		internal NativeArray<Vector3> outlineVertices { get; } // 0x0000000181C2D360-0x0000000181C2D450 
		internal int vertexDeformationHash { get; } // 0x0000000181C2D470-0x0000000181C2D4A0 
		internal Sprite sprite { get; } // 0x0000000181C2D460-0x0000000181C2D470 
		internal SpriteRenderer spriteRenderer { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		internal NativeCustomSlice<BoneWeight> spriteBoneWeights { get; } // 0x0000000181C2D450-0x0000000181C2D460 
		internal int dataIndex { get; } // 0x0000000181C0F730-0x0000000181C0F740 
		public bool autoRebind { get; set; } // 0x0000000181A42150-0x0000000181A42160 0x0000000181C2D4A0-0x0000000181C2D530
		public BoundsMode boundsMode { get; set; } // 0x000000018033D1B0-0x000000018033D1C0 0x0000000181C2D530-0x0000000181C2D540
		public Transform[] boneTransforms { get; } // 0x000000018033D240-0x000000018033D250 
		public Transform rootBone { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal Bounds bounds { get; set; } // 0x0000000181C2D300-0x0000000181C2D320 0x0000000181C2D540-0x0000000181C2D560
		public bool alwaysUpdate { get; set; } // 0x00000001804EFDA0-0x00000001804EFDB0 0x0000000180C47C30-0x0000000180C47C40
		public bool forceCpuDeformation { get; set; } // 0x0000000180643BD0-0x0000000180643BE0 0x0000000181C2D570-0x0000000181C2D5C0
		internal bool isValid { get; } // 0x0000000181C2D330-0x0000000181C2D350 
	
		// Nested types
		internal struct TransformData // TypeDefIndex: 14412
		{
			// Fields
			public string fullName; // 0x00
			public Transform transform; // 0x08
		}
	
		// Constructors
		public SpriteSkin(); // 0x0000000181C2D1E0-0x0000000181C2D2E0
	
		// Methods
		internal void RegisterOutlineDependency(); // 0x0000000181C2C800-0x0000000181C2C810
		internal void UnregisterOutlineDependency(); // 0x0000000181C2CC50-0x0000000181C2CC70
		internal void SetDataIndex(int index); // 0x0000000181C2CB60-0x0000000181C2CB70
		public SpriteSkinState SetBoneTransforms(Transform[] boneTransformsArray); // 0x0000000181C2CB00-0x0000000181C2CB60
		public SpriteSkinState SetRootBone(Transform rootBoneTransform); // 0x0000000181C2CBC0-0x0000000181C2CC50
		public bool ResetBindPose(); // 0x0000000181C2C810-0x0000000181C2C9D0
		internal void Awake(); // 0x0000000181C29F60-0x0000000181C2A050
		private void OnEnable(); // 0x0000000181C2C280-0x0000000181C2C4C0
		private void OnDisable(); // 0x0000000181C2C040-0x0000000181C2C280
		private void RefreshBoneTransforms(); // 0x0000000181C2C6B0-0x0000000181C2C800
		private void OnSpriteChanged(SpriteRenderer updatedSpriteRenderer); // 0x0000000181C2C4C0-0x0000000181C2C580
		private void CacheBoneTransformIds(); // 0x0000000181C2A110-0x0000000181C2A3F0
		private void OnBoneTransformChanged(); // 0x0000000181C2BFB0-0x0000000181C2C040
		public void OnBeforeSerialize(); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnAfterDeserialize(); // 0x00000001802E76C0-0x00000001802E76D0
		private void OnBeforeSerializeBatch(); // 0x00000001802E76C0-0x00000001802E76D0
		private void OnAfterSerializeBatch(); // 0x00000001802E76C0-0x00000001802E76D0
		private SpriteSkinState CacheValidFlag(); // 0x0000000181C2B110-0x0000000181C2B150
		internal bool BatchValidate(); // 0x0000000181C2A050-0x0000000181C2A110
		private void Reset(); // 0x0000000181C2CA80-0x0000000181C2CB00
		private void ResetBoneTransformIdCache(); // 0x0000000181C2C9D0-0x0000000181C2CA30
		public bool HasCurrentDeformedVertices(); // 0x0000000181C2BC90-0x0000000181C2BCD0
		internal NativeArray<byte> GetCurrentDeformedVertices(); // 0x0000000181C2B750-0x0000000181C2B8B0
		internal NativeSlice<PositionVertex> GetCurrentDeformedVertexPositions(); // 0x0000000181C2B5C0-0x0000000181C2B750
		internal NativeSlice<PositionTangentVertex> GetCurrentDeformedVertexPositionsAndTangents(); // 0x0000000181C2B430-0x0000000181C2B5C0
		public IEnumerable<Vector3> GetDeformedVertexPositionData(); // 0x0000000181C2B8B0-0x0000000181C2BA90
		public IEnumerable<Vector4> GetDeformedVertexTangentData(); // 0x0000000181C2BA90-0x0000000181C2BC90
		private void DisposeOutlineCaches(); // 0x0000000181C2B3A0-0x0000000181C2B430
		public void OnPreviewUpdate(); // 0x00000001802E76C0-0x00000001802E76D0
		internal void PostDeform(); // 0x0000000181C2C580-0x0000000181C2C6B0
		private void CacheCurrentSprite(bool rebind); // 0x0000000181C2A3F0-0x0000000181C2A760
		internal void UpdateSpriteDeformationData(); // 0x0000000181C2CD80-0x0000000181C2D1E0
		private void UpdateDeformedOutlineCache(); // 0x0000000181C2CC70-0x0000000181C2CD80
		private void CacheSpriteOutline(); // 0x0000000181C2AE00-0x0000000181C2B110
		private void CacheOutlineIndices(out int maxIndex); // 0x0000000181C2AB10-0x0000000181C2ACA0
		private void CacheOutlineVertices(int cacheSize); // 0x0000000181C2ACA0-0x0000000181C2AE00
		internal void CopyToSpriteSkinData(ref SpriteSkinData data); // 0x0000000181C2B150-0x0000000181C2B2C0
		internal bool NeedToUpdateDeformationCache(); // 0x0000000181C2BED0-0x0000000181C2BFB0
		internal bool NeedToUpdateBoneBounds(); // 0x0000000181C2BCD0-0x0000000181C2BED0
		internal void CacheHierarchy(bool forceCreateCache = false /* Metadata: 0x006A96F9 */); // 0x0000000181C2A760-0x0000000181C2AB10
		internal void DeactivateSkinning(); // 0x0000000181C2B330-0x0000000181C2B3A0
		internal void ResetSprite(); // 0x0000000181C2CA30-0x0000000181C2CA80
		internal void SetDeformationSystem(BaseDeformationSystem newDeformationSystem); // 0x0000000181C2CB70-0x0000000181C2CBC0
		private static int CountChildren(Transform transform); // 0x0000000181C2B2C0-0x0000000181C2B330
	}
}
