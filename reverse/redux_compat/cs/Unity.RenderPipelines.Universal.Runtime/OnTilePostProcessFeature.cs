/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

[DisallowMultipleRendererFeature("On Tile Post Processing")]
public class OnTilePostProcessFeature : ScriptableRendererFeature // TypeDefIndex: 9291
{
	// Fields
	[HideInInspector]
	[SerializeField]
	private PostProcessData m_PostProcessData; // 0x28
	private RenderPassEvent postProcessingEvent; // 0x30
	private Material m_OnTilePostProcessMaterial; // 0x38
	private ColorGradingLutPass m_ColorGradingLutPass; // 0x40
	private OnTilePostProcessPass m_OnTilePostProcessPass; // 0x48

	// Constructors
	public OnTilePostProcessFeature(); // 0x0000000181F59E70-0x0000000181F59E80

	// Methods
	private bool TryLoadResources(); // 0x0000000181F59C20-0x0000000181F59E70
	public override void Create(); // 0x0000000181F599E0-0x0000000181F59C00
	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData); // 0x0000000181F596F0-0x0000000181F599E0
	protected override void Dispose(bool disposing); // 0x0000000181F59C00-0x0000000181F59C20
}

