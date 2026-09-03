/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[CategoryInfo(Name = "R: Film Grain Textures", Order = 1000)]
	[ElementInfo(Order = 0)]
	[HideInInspector]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	internal sealed class UniversalRenderPipelineFilmGrainResources : IRenderPipelineResources // TypeDefIndex: 9694
	{
		// Fields
		[ResourcePaths(new string[10] {"Textures/FilmGrain/Thin01.png", "Textures/FilmGrain/Thin02.png", "Textures/FilmGrain/Medium01.png", "Textures/FilmGrain/Medium02.png", "Textures/FilmGrain/Medium03.png", "Textures/FilmGrain/Medium04.png", "Textures/FilmGrain/Medium05.png", "Textures/FilmGrain/Medium06.png", "Textures/FilmGrain/Large01.png", "Textures/FilmGrain/Large02.png" }, SearchType.ProjectPath)]
		[SerializeField]
		private Texture2D[] m_Textures; // 0x10
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x18
	
		// Properties
		public Texture2D[] textures { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000181FD7490-0x0000000181FD7500
		public int version { get; } // 0x0000000180B23260-0x0000000180B23270 
		public bool isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Constructors
		public UniversalRenderPipelineFilmGrainResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
