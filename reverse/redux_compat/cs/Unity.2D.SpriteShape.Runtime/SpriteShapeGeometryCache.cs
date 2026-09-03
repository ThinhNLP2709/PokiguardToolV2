/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.U2D;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

[AddComponentMenu("")]
internal class SpriteShapeGeometryCache : MonoBehaviour // TypeDefIndex: 13959
{
	// Fields
	[HideInInspector]
	[SerializeField]
	private int m_MaxArrayCount; // 0x20
	[HideInInspector]
	[SerializeField]
	private Vector3[] m_PosArray; // 0x28
	[HideInInspector]
	[SerializeField]
	private Vector2[] m_Uv0Array; // 0x30
	[HideInInspector]
	[SerializeField]
	private Vector4[] m_TanArray; // 0x38
	[HideInInspector]
	[SerializeField]
	private ushort[] m_IndexArray; // 0x40
	[HideInInspector]
	[SerializeField]
	private SpriteShapeGeometryInfo[] m_GeomArray; // 0x48
	private bool m_RequiresUpdate; // 0x50
	private bool m_RequiresUpload; // 0x51
	private NativeSlice<Vector3> m_PosArrayCache; // 0x58
	private NativeSlice<Vector2> m_Uv0ArrayCache; // 0x68
	private NativeSlice<Vector4> m_TanArrayCache; // 0x78
	private NativeArray<ushort> m_IndexArrayCache; // 0x88
	private NativeArray<SpriteShapeSegment> m_GeomArrayCache; // 0x98

	// Properties
	internal ushort[] indexArray { get; } // 0x0000000180377940-0x0000000180377950 
	internal Vector3[] posArray { get; } // 0x000000018033D240-0x000000018033D250 
	public Vector4[] tanArray { get; } // 0x00000001803272A0-0x00000001803272B0 
	internal int maxArrayCount { get; } // 0x0000000180C4F680-0x0000000180C4F690 
	internal bool requiresUpdate { get; } // 0x0000000180377920-0x0000000180377930 
	internal bool requiresUpload { get; } // 0x00000001802F4040-0x00000001802F4050 

	// Constructors
	public SpriteShapeGeometryCache(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void OnEnable(); // 0x0000000181C58AD0-0x0000000181C58AE0
	internal void SetGeometryCache(int _maxArrayCount, NativeSlice<Vector3> _posArray, NativeSlice<Vector2> _uv0Array, NativeSlice<Vector4> _tanArray, NativeArray<ushort> _indexArray, NativeArray<SpriteShapeSegment> _geomArray); // 0x0000000181C58AE0-0x0000000181C58B30
	internal void UpdateGeometryCache(); // 0x0000000181C58B30-0x0000000181C58DD0
	internal JobHandle Upload(SpriteShapeRenderer sr, SpriteShapeController sc); // 0x0000000181C58DD0-0x0000000181C59080
}

