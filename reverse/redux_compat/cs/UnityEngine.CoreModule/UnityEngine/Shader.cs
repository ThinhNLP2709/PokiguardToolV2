/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("Shader", PersistentTypeId = 48)]
	[NativeHeader("Runtime/Shaders/ShaderNameRegistry.h")]
	[NativeHeader("Runtime/Shaders/GpuPrograms/ShaderVariantCollection.h")]
	[NativeHeader("Runtime/Shaders/Keywords/KeywordSpaceScriptBindings.h")]
	[NativeHeader("Runtime/Misc/ResourceManager.h")]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	[NativeHeader("Runtime/Shaders/ComputeShader.h")]
	[NativeHeader("Runtime/Shaders/Shader.h")]
	public sealed class Shader : Object // TypeDefIndex: 7572
	{
		// Properties
		[Obsolete("Use Graphics.activeTier instead (UnityUpgradable) -> UnityEngine.Graphics.activeTier", true)]
		public static ShaderHardwareTier globalShaderHardwareTier { get; set; } // 0x00000001821C66C0-0x00000001821C6720 0x00000001821C6CF0-0x00000001821C6D60
		[NativeProperty("MaxChunksRuntimeOverride")]
		public static int maximumChunksOverride { get; set; } // 0x00000001821C6880-0x00000001821C68B0 0x00000001821C6D60-0x00000001821C6DA0
		[NativeProperty("MaximumShaderLOD")]
		public int maximumLOD { get; set; } // 0x00000001821C68F0-0x00000001821C6950 0x00000001821C6DE0-0x00000001821C6E40
		[NativeProperty("GlobalMaximumShaderLOD")]
		public static int globalMaximumLOD { get; set; } // 0x00000001821C6590-0x00000001821C65C0 0x00000001821C6B30-0x00000001821C6B70
		public bool isSupported { [NativeMethod("IsSupported")] get; } // 0x00000001821C6760-0x00000001821C67C0 
		public static string globalRenderPipeline { get; set; } // 0x00000001821C6600-0x00000001821C66C0 0x00000001821C6BB0-0x00000001821C6CF0
		public static GlobalKeyword[] enabledGlobalKeywords { get; } // 0x00000001821C6570-0x00000001821C6580 
		public static GlobalKeyword[] globalKeywords { get; } // 0x00000001821C6580-0x00000001821C6590 
		public LocalKeywordSpace keywordSpace { get; } // 0x00000001821C6810-0x00000001821C6880 
		public int renderQueue { [FreeFunction("ShaderScripting::GetRenderQueue", HasExplicitThis = true)] get; } // 0x00000001821C6A30-0x00000001821C6A90 
		internal DisableBatchingType disableBatching { [FreeFunction("ShaderScripting::GetDisableBatchingType", HasExplicitThis = true)] get; } // 0x00000001821C6510-0x00000001821C6570 
		public int passCount { [FreeFunction(Name = "ShaderScripting::GetPassCount", HasExplicitThis = true)] get; } // 0x00000001821C6990-0x00000001821C69F0 
		public int subshaderCount { [FreeFunction(Name = "ShaderScripting::GetSubshaderCount", HasExplicitThis = true)] get; } // 0x00000001821C6AD0-0x00000001821C6B30 
	
		// Constructors
		private Shader(); // 0x00000001821C6480-0x00000001821C64D0
	
		// Methods
		public static Shader Find(string name); // 0x00000001821C1550-0x00000001821C15C0
		[FreeFunction("GetBuiltinResource<Shader>")]
		internal static Shader FindBuiltin(string name); // 0x00000001821C0AA0-0x00000001821C0C60
		[FreeFunction("ShaderScripting::CreateFromCompiledData")]
		internal static Shader CreateFromCompiledData(byte[] compiledData, Shader[] dependencies); // 0x00000001821BFD70-0x00000001821BFE30
		[FreeFunction("keywords::GetEnabledGlobalKeywords")]
		internal static GlobalKeyword[] GetEnabledGlobalKeywords(); // 0x00000001821C1990-0x00000001821C1AA0
		[FreeFunction("keywords::GetAllGlobalKeywords")]
		internal static GlobalKeyword[] GetAllGlobalKeywords(); // 0x00000001821C1600-0x00000001821C1710
		[FreeFunction("ShaderScripting::EnableKeyword")]
		public static void EnableKeyword(string keyword); // 0x00000001821C0130-0x00000001821C0270
		[FreeFunction("ShaderScripting::DisableKeyword")]
		public static void DisableKeyword(string keyword); // 0x00000001821BFEF0-0x00000001821C0030
		[FreeFunction("ShaderScripting::IsKeywordEnabled")]
		public static bool IsKeywordEnabled(string keyword); // 0x00000001821C4740-0x00000001821C4890
		[FreeFunction("ShaderScripting::EnableKeyword")]
		internal static void EnableKeywordFast(GlobalKeyword keyword); // 0x00000001821C00B0-0x00000001821C00F0
		[FreeFunction("ShaderScripting::DisableKeyword")]
		internal static void DisableKeywordFast(GlobalKeyword keyword); // 0x00000001821BFE70-0x00000001821BFEB0
		[FreeFunction("ShaderScripting::SetKeyword")]
		internal static void SetKeywordFast(GlobalKeyword keyword, bool value); // 0x00000001821C6120-0x00000001821C6160
		[FreeFunction("ShaderScripting::IsKeywordEnabled")]
		internal static bool IsKeywordEnabledFast(GlobalKeyword keyword); // 0x00000001821C46C0-0x00000001821C4700
		public static void EnableKeyword([IsReadOnly] in GlobalKeyword keyword); // 0x00000001821C0270-0x00000001821C02B0
		public static void DisableKeyword([IsReadOnly] in GlobalKeyword keyword); // 0x00000001821C0030-0x00000001821C0070
		public static void SetKeyword([IsReadOnly] in GlobalKeyword keyword, bool value); // 0x00000001821C6160-0x00000001821C61A0
		public static bool IsKeywordEnabled([IsReadOnly] in GlobalKeyword keyword); // 0x00000001821C4890-0x00000001821C48D0
		[FreeFunction("ShaderScripting::GetGlobalPropertyCount")]
		internal static int GetGlobalPropertyCount(); // 0x00000001821C23E0-0x00000001821C2410
		[FreeFunction("ShaderScripting::GetGlobalPropertyCount")]
		private static int GetGlobalPropertyCountImpl(int propertyType); // 0x00000001821C23A0-0x00000001821C23E0
		[FreeFunction("ShaderScripting::ExtractGlobalPropertyNames")]
		private static void ExtractGlobalPropertyNamesImpl(int propertyType, out string[] names); // 0x00000001821C06F0-0x00000001821C0730
		[FreeFunction]
		public static void WarmupAllShaders(); // 0x00000001821C6450-0x00000001821C6480
		[FreeFunction("ShaderScripting::TagToID")]
		internal static int TagToID(string name); // 0x00000001821C61E0-0x00000001821C6330
		[FreeFunction("ShaderScripting::IDToTag")]
		internal static string IDToTag(int name); // 0x00000001821C4360-0x00000001821C4420
		[FreeFunction(Name = "ShaderScripting::PropertyToID", IsThreadSafe = true)]
		public static int PropertyToID(string name); // 0x00000001821C4940-0x00000001821C4A90
		[FreeFunction(Name = "ShaderScripting::PropertyIDToName", IsThreadSafe = true)]
		public static bool TryConvertPropertyIDToName(int propertyID, out string name); // 0x00000001821C6370-0x00000001821C6450
		public static string PropertyIDToName(int id); // 0x00000001821C48D0-0x00000001821C4900
		public Shader GetDependency(string name); // 0x00000001821C1760-0x00000001821C1950
		[FreeFunction(Name = "ShaderScripting::GetPassCountInSubshader", HasExplicitThis = true)]
		public int GetPassCountInSubshader(int subshaderIndex); // 0x00000001821C2940-0x00000001821C29A0
		public ShaderTagId FindPassTagValue(int passIndex, ShaderTagId tagName); // 0x00000001821C0E10-0x00000001821C0F20
		public ShaderTagId FindPassTagValue(int subshaderIndex, int passIndex, ShaderTagId tagName); // 0x00000001821C0C60-0x00000001821C0E10
		public ShaderTagId FindSubshaderTagValue(int subshaderIndex, ShaderTagId tagName); // 0x00000001821C10F0-0x00000001821C1250
		[FreeFunction(Name = "ShaderScripting::FindPassTagValue", HasExplicitThis = true)]
		private int Internal_FindPassTagValue(int passIndex, int tagName); // 0x00000001821C4550-0x00000001821C45C0
		[FreeFunction(Name = "ShaderScripting::FindPassTagValue", HasExplicitThis = true)]
		private int Internal_FindPassTagValueInSubShader(int subShaderIndex, int passIndex, int tagName); // 0x00000001821C4480-0x00000001821C4500
		[FreeFunction(Name = "ShaderScripting::FindSubshaderTagValue", HasExplicitThis = true)]
		private int Internal_FindSubshaderTagValue(int subShaderIndex, int tagName); // 0x00000001821C4610-0x00000001821C4680
		[FreeFunction("ShaderScripting::SetGlobalInt")]
		private static void SetGlobalIntImpl(int name, int value); // 0x00000001821C53D0-0x00000001821C5410
		[FreeFunction("ShaderScripting::SetGlobalFloat")]
		private static void SetGlobalFloatImpl(int name, float value); // 0x00000001821C52F0-0x00000001821C5340
		[FreeFunction("ShaderScripting::SetGlobalVector")]
		private static void SetGlobalVectorImpl(int name, Vector4 value); // 0x00000001821C5FF0-0x00000001821C6030
		[FreeFunction("ShaderScripting::SetGlobalMatrix")]
		private static void SetGlobalMatrixImpl(int name, Matrix4x4 value); // 0x00000001821C5880-0x00000001821C58C0
		[FreeFunction("ShaderScripting::SetGlobalTexture")]
		private static void SetGlobalTextureImpl(int name, Texture value); // 0x00000001821C5B70-0x00000001821C5BC0
		[FreeFunction("ShaderScripting::SetGlobalRenderTexture")]
		private static void SetGlobalRenderTextureImpl(int name, RenderTexture value, RenderTextureSubElement element); // 0x00000001821C5AD0-0x00000001821C5B30
		[FreeFunction("ShaderScripting::SetGlobalBuffer")]
		private static void SetGlobalBufferImpl(int name, ComputeBuffer value); // 0x00000001821C4AD0-0x00000001821C4B20
		[FreeFunction("ShaderScripting::SetGlobalBuffer")]
		private static void SetGlobalGraphicsBufferImpl(int name, GraphicsBuffer value); // 0x00000001821C4B20-0x00000001821C4B70
		[FreeFunction("ShaderScripting::SetGlobalConstantBuffer")]
		private static void SetGlobalConstantBufferImpl(int name, ComputeBuffer value, int offset, int size); // 0x00000001821C4D70-0x00000001821C4DE0
		[FreeFunction("ShaderScripting::SetGlobalConstantBuffer")]
		private static void SetGlobalConstantGraphicsBufferImpl(int name, GraphicsBuffer value, int offset, int size); // 0x00000001821C4EE0-0x00000001821C4F50
		[FreeFunction("ShaderScripting::SetGlobalRayTracingAccelerationStructure")]
		private static void SetGlobalRayTracingAccelerationStructureImpl(int name, RayTracingAccelerationStructure accelerationStructure); // 0x00000001821C59D0-0x00000001821C5A20
		[FreeFunction("ShaderScripting::GetGlobalInt")]
		private static int GetGlobalIntImpl(int name); // 0x00000001821C1E70-0x00000001821C1EB0
		[FreeFunction("ShaderScripting::GetGlobalFloat")]
		private static float GetGlobalFloatImpl(int name); // 0x00000001821C1DF0-0x00000001821C1E30
		[FreeFunction("ShaderScripting::GetGlobalVector")]
		private static Vector4 GetGlobalVectorImpl(int name); // 0x00000001821C27E0-0x00000001821C2830
		[FreeFunction("ShaderScripting::GetGlobalMatrix")]
		private static Matrix4x4 GetGlobalMatrixImpl(int name); // 0x00000001821C2230-0x00000001821C2290
		[FreeFunction("ShaderScripting::GetGlobalTexture")]
		private static Texture GetGlobalTextureImpl(int name); // 0x00000001821C2450-0x00000001821C24B0
		[FreeFunction("ShaderScripting::SetGlobalFloatArray")]
		private static void SetGlobalFloatArrayImpl(int name, float[] values, int count); // 0x00000001821C5000-0x00000001821C50A0
		[FreeFunction("ShaderScripting::SetGlobalVectorArray")]
		private static void SetGlobalVectorArrayImpl(int name, Vector4[] values, int count); // 0x00000001821C5CC0-0x00000001821C5D60
		[FreeFunction("ShaderScripting::SetGlobalMatrixArray")]
		private static void SetGlobalMatrixArrayImpl(int name, Matrix4x4[] values, int count); // 0x00000001821C5550-0x00000001821C55F0
		[FreeFunction("ShaderScripting::GetGlobalFloatArray")]
		private static float[] GetGlobalFloatArrayImpl(int name); // 0x00000001821C1BF0-0x00000001821C1D10
		[FreeFunction("ShaderScripting::GetGlobalVectorArray")]
		private static Vector4[] GetGlobalVectorArrayImpl(int name); // 0x00000001821C25A0-0x00000001821C26C0
		[FreeFunction("ShaderScripting::GetGlobalMatrixArray")]
		private static Matrix4x4[] GetGlobalMatrixArrayImpl(int name); // 0x00000001821C1FF0-0x00000001821C2110
		[FreeFunction("ShaderScripting::GetGlobalFloatArrayCount")]
		private static int GetGlobalFloatArrayCountImpl(int name); // 0x00000001821C1B70-0x00000001821C1BB0
		[FreeFunction("ShaderScripting::GetGlobalVectorArrayCount")]
		private static int GetGlobalVectorArrayCountImpl(int name); // 0x00000001821C2520-0x00000001821C2560
		[FreeFunction("ShaderScripting::GetGlobalMatrixArrayCount")]
		private static int GetGlobalMatrixArrayCountImpl(int name); // 0x00000001821C1F70-0x00000001821C1FB0
		[FreeFunction("ShaderScripting::ExtractGlobalFloatArray")]
		private static void ExtractGlobalFloatArrayImpl(int name, out float[] val); // 0x00000001821C02F0-0x00000001821C0380
		[FreeFunction("ShaderScripting::ExtractGlobalVectorArray")]
		private static void ExtractGlobalVectorArrayImpl(int name, out Vector4[] val); // 0x00000001821C0880-0x00000001821C0910
		[FreeFunction("ShaderScripting::ExtractGlobalMatrixArray")]
		private static void ExtractGlobalMatrixArrayImpl(int name, out Matrix4x4[] val); // 0x00000001821C0510-0x00000001821C05A0
		private static void SetGlobalFloatArray(int name, float[] values, int count); // 0x00000001821C5130-0x00000001821C52B0
		private static void SetGlobalVectorArray(int name, Vector4[] values, int count); // 0x00000001821C5DE0-0x00000001821C5F60
		private static void SetGlobalMatrixArray(int name, Matrix4x4[] values, int count); // 0x00000001821C5610-0x00000001821C5790
		private static void ExtractGlobalFloatArray(int name, List<float> values); // 0x00000001821C0380-0x00000001821C04D0
		private static void ExtractGlobalVectorArray(int name, List<Vector4> values); // 0x00000001821C0910-0x00000001821C0A60
		private static void ExtractGlobalMatrixArray(int name, List<Matrix4x4> values); // 0x00000001821C05A0-0x00000001821C06F0
		private static void ExtractGlobalPropertyNames(MaterialPropertyType type, List<string> names); // 0x00000001821C0730-0x00000001821C0840
		public static void SetGlobalInt(string name, int value); // 0x00000001821C5410-0x00000001821C5460
		public static void SetGlobalInt(int nameID, int value); // 0x00000001821C5460-0x00000001821C54B0
		public static void SetGlobalFloat(string name, float value); // 0x00000001821C5340-0x00000001821C5390
		public static void SetGlobalFloat(int nameID, float value); // 0x00000001821C52F0-0x00000001821C5340
		public static void SetGlobalInteger(string name, int value); // 0x00000001821C54B0-0x00000001821C5500
		public static void SetGlobalInteger(int nameID, int value); // 0x00000001821C53D0-0x00000001821C5410
		public static void SetGlobalVector(string name, Vector4 value); // 0x00000001821C6030-0x00000001821C6090
		public static void SetGlobalVector(int nameID, Vector4 value); // 0x00000001821C6090-0x00000001821C60D0
		public static void SetGlobalColor(string name, Color value); // 0x00000001821C4CA0-0x00000001821C4D10
		public static void SetGlobalColor(int nameID, Color value); // 0x00000001821C4C30-0x00000001821C4CA0
		public static void SetGlobalMatrix(string name, Matrix4x4 value); // 0x00000001821C58C0-0x00000001821C5930
		public static void SetGlobalMatrix(int nameID, Matrix4x4 value); // 0x00000001821C5930-0x00000001821C5990
		public static void SetGlobalTexture(string name, Texture value); // 0x00000001821C5C20-0x00000001821C5C70
		public static void SetGlobalTexture(int nameID, Texture value); // 0x00000001821C5B70-0x00000001821C5BC0
		public static void SetGlobalTexture(string name, RenderTexture value, RenderTextureSubElement element); // 0x00000001821C5BC0-0x00000001821C5C20
		public static void SetGlobalTexture(int nameID, RenderTexture value, RenderTextureSubElement element); // 0x00000001821C5AD0-0x00000001821C5B30
		public static void SetGlobalBuffer(string name, ComputeBuffer value); // 0x00000001821C4B70-0x00000001821C4BD0
		public static void SetGlobalBuffer(int nameID, ComputeBuffer value); // 0x00000001821C4AD0-0x00000001821C4B20
		public static void SetGlobalBuffer(string name, GraphicsBuffer value); // 0x00000001821C4BD0-0x00000001821C4C30
		public static void SetGlobalBuffer(int nameID, GraphicsBuffer value); // 0x00000001821C4B20-0x00000001821C4B70
		public static void SetGlobalConstantBuffer(string name, ComputeBuffer value, int offset, int size); // 0x00000001821C4E60-0x00000001821C4EE0
		public static void SetGlobalConstantBuffer(int nameID, ComputeBuffer value, int offset, int size); // 0x00000001821C4D70-0x00000001821C4DE0
		public static void SetGlobalConstantBuffer(string name, GraphicsBuffer value, int offset, int size); // 0x00000001821C4DE0-0x00000001821C4E60
		public static void SetGlobalConstantBuffer(int nameID, GraphicsBuffer value, int offset, int size); // 0x00000001821C4EE0-0x00000001821C4F50
		public static void SetGlobalRayTracingAccelerationStructure(string name, RayTracingAccelerationStructure value); // 0x00000001821C5A20-0x00000001821C5A80
		public static void SetGlobalRayTracingAccelerationStructure(int nameID, RayTracingAccelerationStructure value); // 0x00000001821C59D0-0x00000001821C5A20
		public static void SetGlobalFloatArray(string name, List<float> values); // 0x00000001821C52B0-0x00000001821C52F0
		public static void SetGlobalFloatArray(int nameID, List<float> values); // 0x00000001821C5100-0x00000001821C5130
		public static void SetGlobalFloatArray(string name, float[] values); // 0x00000001821C50C0-0x00000001821C5100
		public static void SetGlobalFloatArray(int nameID, float[] values); // 0x00000001821C50A0-0x00000001821C50C0
		public static void SetGlobalVectorArray(string name, List<Vector4> values); // 0x00000001821C5DA0-0x00000001821C5DE0
		public static void SetGlobalVectorArray(int nameID, List<Vector4> values); // 0x00000001821C5F80-0x00000001821C5FB0
		public static void SetGlobalVectorArray(string name, Vector4[] values); // 0x00000001821C5D60-0x00000001821C5DA0
		public static void SetGlobalVectorArray(int nameID, Vector4[] values); // 0x00000001821C5F60-0x00000001821C5F80
		public static void SetGlobalMatrixArray(string name, List<Matrix4x4> values); // 0x00000001821C5800-0x00000001821C5840
		public static void SetGlobalMatrixArray(int nameID, List<Matrix4x4> values); // 0x00000001821C57D0-0x00000001821C5800
		public static void SetGlobalMatrixArray(string name, Matrix4x4[] values); // 0x00000001821C5790-0x00000001821C57D0
		public static void SetGlobalMatrixArray(int nameID, Matrix4x4[] values); // 0x00000001821C55F0-0x00000001821C5610
		public static int GetGlobalInt(string name); // 0x00000001821C1EF0-0x00000001821C1F30
		public static int GetGlobalInt(int nameID); // 0x00000001821C1EB0-0x00000001821C1EF0
		public static float GetGlobalFloat(string name); // 0x00000001821C1E30-0x00000001821C1E70
		public static float GetGlobalFloat(int nameID); // 0x00000001821C1DF0-0x00000001821C1E30
		public static int GetGlobalInteger(string name); // 0x00000001821C1F30-0x00000001821C1F70
		public static int GetGlobalInteger(int nameID); // 0x00000001821C1E70-0x00000001821C1EB0
		public static Vector4 GetGlobalVector(string name); // 0x00000001821C2890-0x00000001821C2900
		public static Vector4 GetGlobalVector(int nameID); // 0x00000001821C2830-0x00000001821C2890
		public static Color GetGlobalColor(string name); // 0x00000001821C1B00-0x00000001821C1B70
		public static Color GetGlobalColor(int nameID); // 0x00000001821C1AA0-0x00000001821C1B00
		public static Matrix4x4 GetGlobalMatrix(string name); // 0x00000001821C2290-0x00000001821C2320
		public static Matrix4x4 GetGlobalMatrix(int nameID); // 0x00000001821C2320-0x00000001821C23A0
		public static Texture GetGlobalTexture(string name); // 0x00000001821C24B0-0x00000001821C2520
		public static Texture GetGlobalTexture(int nameID); // 0x00000001821C2450-0x00000001821C24B0
		public static float[] GetGlobalFloatArray(string name); // 0x00000001821C1D10-0x00000001821C1D60
		public static float[] GetGlobalFloatArray(int nameID); // 0x00000001821C1DA0-0x00000001821C1DF0
		public static Vector4[] GetGlobalVectorArray(string name); // 0x00000001821C2750-0x00000001821C27A0
		public static Vector4[] GetGlobalVectorArray(int nameID); // 0x00000001821C26C0-0x00000001821C2710
		public static Matrix4x4[] GetGlobalMatrixArray(string name); // 0x00000001821C21A0-0x00000001821C21F0
		public static Matrix4x4[] GetGlobalMatrixArray(int nameID); // 0x00000001821C2110-0x00000001821C2160
		public static void GetGlobalFloatArray(string name, List<float> values); // 0x00000001821C1D70-0x00000001821C1DA0
		public static void GetGlobalFloatArray(int nameID, List<float> values); // 0x00000001821C1D60-0x00000001821C1D70
		public static void GetGlobalVectorArray(string name, List<Vector4> values); // 0x00000001821C2720-0x00000001821C2750
		public static void GetGlobalVectorArray(int nameID, List<Vector4> values); // 0x00000001821C2710-0x00000001821C2720
		public static void GetGlobalMatrixArray(string name, List<Matrix4x4> values); // 0x00000001821C2160-0x00000001821C2190
		public static void GetGlobalMatrixArray(int nameID, List<Matrix4x4> values); // 0x00000001821C2190-0x00000001821C21A0
		internal static void GetGlobalPropertyNames(MaterialPropertyType type, List<string> names); // 0x00000001821C0730-0x00000001821C0840
		[FreeFunction("ShaderScripting::GetPropertyName")]
		private static string GetPropertyName([NotNull] Shader shader, int propertyIndex); // 0x00000001821C3790-0x00000001821C38E0
		[FreeFunction("ShaderScripting::GetPropertyNameId")]
		private static int GetPropertyNameId([NotNull] Shader shader, int propertyIndex); // 0x00000001821C36A0-0x00000001821C3740
		[FreeFunction("ShaderScripting::GetPropertyType")]
		private static ShaderPropertyType GetPropertyType([NotNull] Shader shader, int propertyIndex); // 0x00000001821C3FE0-0x00000001821C4080
		[FreeFunction("ShaderScripting::GetPropertyDescription")]
		private static string GetPropertyDescription([NotNull] Shader shader, int propertyIndex); // 0x00000001821C32D0-0x00000001821C3420
		[FreeFunction("ShaderScripting::GetPropertyFlags")]
		private static ShaderPropertyFlags GetPropertyFlags([NotNull] Shader shader, int propertyIndex); // 0x00000001821C3510-0x00000001821C35B0
		[FreeFunction("ShaderScripting::GetPropertyAttributes")]
		private static string[] GetPropertyAttributes([NotNull] Shader shader, int propertyIndex); // 0x00000001821C2A90-0x00000001821C2B30
		[FreeFunction("ShaderScripting::GetPropertyDefaultIntValue")]
		private static int GetPropertyDefaultIntValue([NotNull] Shader shader, int propertyIndex); // 0x00000001821C2F00-0x00000001821C2FA0
		[FreeFunction("ShaderScripting::GetPropertyDefaultValue")]
		internal static Vector4 GetPropertyDefaultValue([NotNull] Shader shader, int propertyIndex); // 0x00000001821C2FF0-0x00000001821C30B0
		[FreeFunction("ShaderScripting::GetPropertyTextureDimension")]
		internal static TextureDimension GetPropertyTextureDimension([NotNull] Shader shader, int propertyIndex); // 0x00000001821C3D90-0x00000001821C3E30
		[FreeFunction("ShaderScripting::GetPropertyTextureDefaultName")]
		private static string GetPropertyTextureDefaultName([NotNull] Shader shader, int propertyIndex); // 0x00000001821C3AF0-0x00000001821C3C40
		[FreeFunction("ShaderScripting::GetValuesForExtractMaterialProperty")]
		internal static void GetValuesForExtractMaterialProperty([NotNull] Shader shader, int propertyIndex, out string name, out string description, out ShaderPropertyFlags flags, out ShaderPropertyType type, out Vector4 defaultValue, out TextureDimension textureDimension); // 0x00000001821C4190-0x00000001821C4320
		[FreeFunction("ShaderScripting::FindTextureStack")]
		private static bool FindTextureStackImpl([NotNull] Shader s, int propertyIdx, out string stackName, out int layerIndex); // 0x00000001821C12B0-0x00000001821C1410
		private static void CheckPropertyIndex(Shader s, int propertyIndex); // 0x00000001821BFC70-0x00000001821BFD20
		public int GetPropertyCount(); // 0x00000001821C2B70-0x00000001821C2BD0
		public int FindPropertyIndex(string propertyName); // 0x00000001821C0F70-0x00000001821C10F0
		public string GetPropertyName(int propertyIndex); // 0x00000001821C38E0-0x00000001821C3910
		public int GetPropertyNameId(int propertyIndex); // 0x00000001821C35F0-0x00000001821C36A0
		public ShaderPropertyType GetPropertyType(int propertyIndex); // 0x00000001821C4080-0x00000001821C4130
		public string GetPropertyDescription(int propertyIndex); // 0x00000001821C32A0-0x00000001821C32D0
		public ShaderPropertyFlags GetPropertyFlags(int propertyIndex); // 0x00000001821C3460-0x00000001821C3510
		public string[] GetPropertyAttributes(int propertyIndex); // 0x00000001821C29E0-0x00000001821C2A90
		public float GetPropertyDefaultFloatValue(int propertyIndex); // 0x00000001821C2BD0-0x00000001821C2D50
		public Vector4 GetPropertyDefaultVectorValue(int propertyIndex); // 0x00000001821C30B0-0x00000001821C3250
		public Vector2 GetPropertyRangeLimits(int propertyIndex); // 0x00000001821C3910-0x00000001821C3AA0
		public int GetPropertyDefaultIntValue(int propertyIndex); // 0x00000001821C2D90-0x00000001821C2F00
		public TextureDimension GetPropertyTextureDimension(int propertyIndex); // 0x00000001821C3E30-0x00000001821C3FA0
		public string GetPropertyTextureDefaultName(int propertyIndex); // 0x00000001821C3C40-0x00000001821C3D50
		public bool FindTextureStack(int propertyIndex, out string stackName, out int layerIndex); // 0x00000001821C1410-0x00000001821C1550
		private static IntPtr FindBuiltin_Injected(ref ManagedSpanWrapper name); // 0x00000001821C0A60-0x00000001821C0AA0
		private static IntPtr CreateFromCompiledData_Injected(ref ManagedSpanWrapper compiledData, Shader[] dependencies); // 0x00000001821BFD20-0x00000001821BFD70
		private static int get_maximumLOD_Injected(IntPtr _unity_self); // 0x00000001821C68B0-0x00000001821C68F0
		private static void set_maximumLOD_Injected(IntPtr _unity_self, int value); // 0x00000001821C6DA0-0x00000001821C6DE0
		private static bool get_isSupported_Injected(IntPtr _unity_self); // 0x00000001821C6720-0x00000001821C6760
		private static void get_globalRenderPipeline_Injected(); // 0x00000001821C65C0-0x00000001821C6600
		private static void set_globalRenderPipeline_Injected(ref ManagedSpanWrapper value); // 0x00000001821C6B70-0x00000001821C6BB0
		private static void get_keywordSpace_Injected(IntPtr _unity_self, ); // 0x00000001821C67C0-0x00000001821C6810
		private static void GetEnabledGlobalKeywords_Injected(); // 0x00000001821C1950-0x00000001821C1990
		private static void GetAllGlobalKeywords_Injected(); // 0x00000001821C15C0-0x00000001821C1600
		private static void EnableKeyword_Injected(ref ManagedSpanWrapper keyword); // 0x00000001821C00F0-0x00000001821C0130
		private static void DisableKeyword_Injected(ref ManagedSpanWrapper keyword); // 0x00000001821BFEB0-0x00000001821BFEF0
		private static bool IsKeywordEnabled_Injected(ref ManagedSpanWrapper keyword); // 0x00000001821C4700-0x00000001821C4740
		private static void EnableKeywordFast_Injected(in GlobalKeyword keyword); // 0x00000001821C0070-0x00000001821C00B0
		private static void DisableKeywordFast_Injected(in GlobalKeyword keyword); // 0x00000001821BFE30-0x00000001821BFE70
		private static void SetKeywordFast_Injected(in GlobalKeyword keyword, bool value); // 0x00000001821C60D0-0x00000001821C6120
		private static bool IsKeywordEnabledFast_Injected(in GlobalKeyword keyword); // 0x00000001821C4680-0x00000001821C46C0
		private static int get_renderQueue_Injected(IntPtr _unity_self); // 0x00000001821C69F0-0x00000001821C6A30
		private static DisableBatchingType get_disableBatching_Injected(IntPtr _unity_self); // 0x00000001821C64D0-0x00000001821C6510
		private static int TagToID_Injected(ref ManagedSpanWrapper name); // 0x00000001821C61A0-0x00000001821C61E0
		private static void IDToTag_Injected(int name, ); // 0x00000001821C4320-0x00000001821C4360
		private static int PropertyToID_Injected(ref ManagedSpanWrapper name); // 0x00000001821C4900-0x00000001821C4940
		private static bool TryConvertPropertyIDToName_Injected(int propertyID, out ManagedSpanWrapper name); // 0x00000001821C6330-0x00000001821C6370
		private static IntPtr GetDependency_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x00000001821C1710-0x00000001821C1760
		private static int get_passCount_Injected(IntPtr _unity_self); // 0x00000001821C6950-0x00000001821C6990
		private static int get_subshaderCount_Injected(IntPtr _unity_self); // 0x00000001821C6A90-0x00000001821C6AD0
		private static int GetPassCountInSubshader_Injected(IntPtr _unity_self, int subshaderIndex); // 0x00000001821C2900-0x00000001821C2940
		private static int Internal_FindPassTagValue_Injected(IntPtr _unity_self, int passIndex, int tagName); // 0x00000001821C4500-0x00000001821C4550
		private static int Internal_FindPassTagValueInSubShader_Injected(IntPtr _unity_self, int subShaderIndex, int passIndex, int tagName); // 0x00000001821C4420-0x00000001821C4480
		private static int Internal_FindSubshaderTagValue_Injected(IntPtr _unity_self, int subShaderIndex, int tagName); // 0x00000001821C45C0-0x00000001821C4610
		private static void SetGlobalVectorImpl_Injected(int name, in Vector4 value); // 0x00000001821C5FB0-0x00000001821C5FF0
		private static void SetGlobalMatrixImpl_Injected(int name, in Matrix4x4 value); // 0x00000001821C5840-0x00000001821C5880
		private static void SetGlobalTextureImpl_Injected(int name, IntPtr value); // 0x00000001821C5B30-0x00000001821C5B70
		private static void SetGlobalRenderTextureImpl_Injected(int name, IntPtr value, RenderTextureSubElement element); // 0x00000001821C5A80-0x00000001821C5AD0
		private static void SetGlobalBufferImpl_Injected(int name, IntPtr value); // 0x00000001821C4A90-0x00000001821C4AD0
		private static void SetGlobalGraphicsBufferImpl_Injected(int name, IntPtr value); // 0x00000001821C5390-0x00000001821C53D0
		private static void SetGlobalConstantBufferImpl_Injected(int name, IntPtr value, int offset, int size); // 0x00000001821C4D10-0x00000001821C4D70
		private static void SetGlobalConstantGraphicsBufferImpl_Injected(int name, IntPtr value, int offset, int size); // 0x00000001821C4F50-0x00000001821C4FB0
		private static void SetGlobalRayTracingAccelerationStructureImpl_Injected(int name, IntPtr accelerationStructure); // 0x00000001821C5990-0x00000001821C59D0
		private static void GetGlobalVectorImpl_Injected(int name, ); // 0x00000001821C27A0-0x00000001821C27E0
		private static void GetGlobalMatrixImpl_Injected(int name, ); // 0x00000001821C21F0-0x00000001821C2230
		private static IntPtr GetGlobalTextureImpl_Injected(int name); // 0x00000001821C2410-0x00000001821C2450
		private static void SetGlobalFloatArrayImpl_Injected(int name, ref ManagedSpanWrapper values, int count); // 0x00000001821C4FB0-0x00000001821C5000
		private static void SetGlobalVectorArrayImpl_Injected(int name, ref ManagedSpanWrapper values, int count); // 0x00000001821C5C70-0x00000001821C5CC0
		private static void SetGlobalMatrixArrayImpl_Injected(int name, ref ManagedSpanWrapper values, int count); // 0x00000001821C5500-0x00000001821C5550
		private static void GetGlobalFloatArrayImpl_Injected(int name, ); // 0x00000001821C1BB0-0x00000001821C1BF0
		private static void GetGlobalVectorArrayImpl_Injected(int name, ); // 0x00000001821C2560-0x00000001821C25A0
		private static void GetGlobalMatrixArrayImpl_Injected(int name, ); // 0x00000001821C1FB0-0x00000001821C1FF0
		private static void ExtractGlobalFloatArrayImpl_Injected(int name, out BlittableArrayWrapper val); // 0x00000001821C02B0-0x00000001821C02F0
		private static void ExtractGlobalVectorArrayImpl_Injected(int name, out BlittableArrayWrapper val); // 0x00000001821C0840-0x00000001821C0880
		private static void ExtractGlobalMatrixArrayImpl_Injected(int name, out BlittableArrayWrapper val); // 0x00000001821C04D0-0x00000001821C0510
		private static void GetPropertyName_Injected(IntPtr shader, int propertyIndex, ); // 0x00000001821C3740-0x00000001821C3790
		private static int GetPropertyNameId_Injected(IntPtr shader, int propertyIndex); // 0x00000001821C35B0-0x00000001821C35F0
		private static ShaderPropertyType GetPropertyType_Injected(IntPtr shader, int propertyIndex); // 0x00000001821C3FA0-0x00000001821C3FE0
		private static void GetPropertyDescription_Injected(IntPtr shader, int propertyIndex, ); // 0x00000001821C3250-0x00000001821C32A0
		private static ShaderPropertyFlags GetPropertyFlags_Injected(IntPtr shader, int propertyIndex); // 0x00000001821C3420-0x00000001821C3460
		private static string[] GetPropertyAttributes_Injected(IntPtr shader, int propertyIndex); // 0x00000001821C29A0-0x00000001821C29E0
		private static int GetPropertyDefaultIntValue_Injected(IntPtr shader, int propertyIndex); // 0x00000001821C2D50-0x00000001821C2D90
		private static void GetPropertyDefaultValue_Injected(IntPtr shader, int propertyIndex, ); // 0x00000001821C2FA0-0x00000001821C2FF0
		private static TextureDimension GetPropertyTextureDimension_Injected(IntPtr shader, int propertyIndex); // 0x00000001821C3D50-0x00000001821C3D90
		private static void GetPropertyTextureDefaultName_Injected(IntPtr shader, int propertyIndex, ); // 0x00000001821C3AA0-0x00000001821C3AF0
		private static void GetValuesForExtractMaterialProperty_Injected(IntPtr shader, int propertyIndex, out ManagedSpanWrapper name, out ManagedSpanWrapper description, out ShaderPropertyFlags flags, out ShaderPropertyType type, out Vector4 defaultValue, out TextureDimension textureDimension); // 0x00000001821C4130-0x00000001821C4190
		private static bool FindTextureStackImpl_Injected(IntPtr s, int propertyIdx, out ManagedSpanWrapper stackName, out int layerIndex); // 0x00000001821C1250-0x00000001821C12B0
		private static int GetPropertyCount_Injected(IntPtr _unity_self); // 0x00000001821C2B30-0x00000001821C2B70
		private static int FindPropertyIndex_Injected(IntPtr _unity_self, ref ManagedSpanWrapper propertyName); // 0x00000001821C0F20-0x00000001821C0F70
	}
}
