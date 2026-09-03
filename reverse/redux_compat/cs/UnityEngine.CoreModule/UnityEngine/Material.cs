/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("Material", PersistentTypeId = 21)]
	[NativeHeader("Runtime/Shaders/Material.h")]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	public class Material : Object // TypeDefIndex: 7573
	{
		// Fields
		private static readonly int k_ColorId; // 0x00
		private static readonly int k_MainTexId; // 0x04
	
		// Properties
		public Shader shader { get; set; } // 0x00000001821B2AF0-0x00000001821B2BA0 0x00000001821B3670-0x00000001821B3730
		public Color color { get; set; } // 0x00000001821B2120-0x00000001821B22D0 0x00000001821B2BA0-0x00000001821B2D50
		public Texture mainTexture { get; set; } // 0x00000001821B2740-0x00000001821B2840 0x00000001821B3370-0x00000001821B3540
		public Vector2 mainTextureOffset { get; set; } // 0x00000001821B2540-0x00000001821B2640 0x00000001821B3010-0x00000001821B31C0
		public Vector2 mainTextureScale { get; set; } // 0x00000001821B2640-0x00000001821B2740 0x00000001821B31C0-0x00000001821B3370
		public int renderQueue { [NativeName("GetActualRenderQueue")] get; [NativeName("SetCustomRenderQueue")] set; } // 0x00000001821B2A20-0x00000001821B2AB0 0x00000001821B3580-0x00000001821B3620
		public int rawRenderQueue { [NativeName("GetCustomRenderQueue")] get; } // 0x00000001821B2950-0x00000001821B29E0 
		public LocalKeyword[] enabledKeywords { get; set; } // 0x00000001821AA5F0-0x00000001821AA680 0x00000001821AF470-0x00000001821AF510
		public MaterialGlobalIlluminationFlags globalIlluminationFlags { get; set; } // 0x00000001821B24B0-0x00000001821B2540 0x00000001821B2F70-0x00000001821B3010
		public bool doubleSidedGI { get; set; } // 0x00000001821B2310-0x00000001821B23A0 0x00000001821B2DA0-0x00000001821B2E40
		[NativeProperty("EnableInstancingVariants")]
		public bool enableInstancing { get; set; } // 0x00000001821B23E0-0x00000001821B2470 0x00000001821B2E90-0x00000001821B2F30
		public int passCount { [NativeName("GetShader()->GetPassCount")] get; } // 0x00000001821B2880-0x00000001821B2910 
		public string[] shaderKeywords { get; set; } // 0x00000001821ABB70-0x00000001821ABC00 0x00000001821B0D40-0x00000001821B0DE0
	
		// Constructors
		public Material(Shader shader); // 0x00000001821B1E70-0x00000001821B1FA0
		[RequiredByNativeCode]
		public Material(Material source); // 0x00000001821B1FF0-0x00000001821B2120
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Creating materials from shader source string is no longer supported. Use Shader assets instead.", true)]
		public Material(string contents); // 0x00000001821B1FA0-0x00000001821B1FF0
		static Material(); // 0x00000001821B1DF0-0x00000001821B1E70
	
		// Methods
		[Obsolete("Creating materials from shader source string will be removed in the future. Use Shader assets instead.", true)]
		public static Material Create(string scriptContents); // 0x00000001821A8180-0x00000001821A8200
		[FreeFunction("MaterialScripting::CreateWithShader")]
		private static void CreateWithShader([Writable] Material self, [NotNull] Shader shader); // 0x00000001821A80C0-0x00000001821A8180
		[FreeFunction("MaterialScripting::CreateWithMaterial")]
		private static void CreateWithMaterial([Writable] Material self, [NotNull] Material source); // 0x00000001821A7FB0-0x00000001821A8070
		internal static Material GetDefaultMaterial(); // 0x00000001821AA480-0x00000001821AA500
		internal static Material GetDefaultParticleMaterial(); // 0x00000001821AA530-0x00000001821AA5B0
		internal static Material GetDefaultLineMaterial(); // 0x00000001821AA3D0-0x00000001821AA450
		[NativeName("GetFirstPropertyNameIdByAttributeFromScript")]
		private int GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags attributeFlag); // 0x00000001821AA6C0-0x00000001821AA760
		[NativeName("HasPropertyFromScript")]
		public bool HasProperty(int nameID); // 0x00000001821ADD30-0x00000001821ADDD0
		public bool HasProperty(string name); // 0x00000001821ADDD0-0x00000001821ADE80
		[NativeName("HasFloatFromScript")]
		private bool HasFloatImpl(int name); // 0x00000001821AD880-0x00000001821AD920
		public bool HasFloat(string name); // 0x00000001821AD920-0x00000001821AD9D0
		public bool HasFloat(int nameID); // 0x00000001821AD880-0x00000001821AD920
		public bool HasInt(string name); // 0x00000001821AD920-0x00000001821AD9D0
		public bool HasInt(int nameID); // 0x00000001821AD880-0x00000001821AD920
		[NativeName("HasIntegerFromScript")]
		private bool HasIntImpl(int name); // 0x00000001821ADA10-0x00000001821ADAB0
		public bool HasInteger(string name); // 0x00000001821ADAB0-0x00000001821ADB60
		public bool HasInteger(int nameID); // 0x00000001821ADA10-0x00000001821ADAB0
		[NativeName("HasTextureFromScript")]
		private bool HasTextureImpl(int name); // 0x00000001821ADEC0-0x00000001821ADF60
		public bool HasTexture(string name); // 0x00000001821ADF60-0x00000001821AE010
		public bool HasTexture(int nameID); // 0x00000001821ADEC0-0x00000001821ADF60
		[NativeName("HasMatrixFromScript")]
		private bool HasMatrixImpl(int name); // 0x00000001821ADBA0-0x00000001821ADC40
		public bool HasMatrix(string name); // 0x00000001821ADC40-0x00000001821ADCF0
		public bool HasMatrix(int nameID); // 0x00000001821ADBA0-0x00000001821ADC40
		[NativeName("HasVectorFromScript")]
		private bool HasVectorImpl(int name); // 0x00000001821AD610-0x00000001821AD6B0
		public bool HasVector(string name); // 0x00000001821AD560-0x00000001821AD610
		public bool HasVector(int nameID); // 0x00000001821AD610-0x00000001821AD6B0
		public bool HasColor(string name); // 0x00000001821AD560-0x00000001821AD610
		public bool HasColor(int nameID); // 0x00000001821AD610-0x00000001821AD6B0
		[NativeName("HasBufferFromScript")]
		private bool HasBufferImpl(int name); // 0x00000001821AD410-0x00000001821AD4B0
		public bool HasBuffer(string name); // 0x00000001821AD4B0-0x00000001821AD560
		public bool HasBuffer(int nameID); // 0x00000001821AD410-0x00000001821AD4B0
		[NativeName("HasConstantBufferFromScript")]
		private bool HasConstantBufferImpl(int name); // 0x00000001821AD6F0-0x00000001821AD790
		public bool HasConstantBuffer(string name); // 0x00000001821AD790-0x00000001821AD840
		public bool HasConstantBuffer(int nameID); // 0x00000001821AD6F0-0x00000001821AD790
		public void EnableKeyword(string keyword); // 0x00000001821A86B0-0x00000001821A8870
		public void DisableKeyword(string keyword); // 0x00000001821A8300-0x00000001821A84C0
		public bool IsKeywordEnabled(string keyword); // 0x00000001821AE150-0x00000001821AE310
		[FreeFunction("MaterialScripting::EnableKeyword", HasExplicitThis = true)]
		private void EnableLocalKeyword(LocalKeyword keyword); // 0x00000001821A88C0-0x00000001821A8960
		[FreeFunction("MaterialScripting::DisableKeyword", HasExplicitThis = true)]
		private void DisableLocalKeyword(LocalKeyword keyword); // 0x00000001821A8510-0x00000001821A85B0
		[FreeFunction("MaterialScripting::SetKeyword", HasExplicitThis = true)]
		private void SetLocalKeyword(LocalKeyword keyword, bool value); // 0x00000001821AFFF0-0x00000001821B00A0
		[FreeFunction("MaterialScripting::IsKeywordEnabled", HasExplicitThis = true)]
		private bool IsLocalKeywordEnabled(LocalKeyword keyword); // 0x00000001821AE360-0x00000001821AE400
		public void EnableKeyword([IsReadOnly] in LocalKeyword keyword); // 0x00000001821A8600-0x00000001821A86B0
		public void DisableKeyword([IsReadOnly] in LocalKeyword keyword); // 0x00000001821A8250-0x00000001821A8300
		public void SetKeyword([IsReadOnly] in LocalKeyword keyword, bool value); // 0x00000001821AFED0-0x00000001821AFF90
		public bool IsKeywordEnabled([IsReadOnly] in LocalKeyword keyword); // 0x00000001821AE0A0-0x00000001821AE150
		[FreeFunction("MaterialScripting::GetEnabledKeywords", HasExplicitThis = true)]
		private LocalKeyword[] GetEnabledKeywords(); // 0x00000001821AA5F0-0x00000001821AA680
		[FreeFunction("MaterialScripting::SetEnabledKeywords", HasExplicitThis = true)]
		private void SetEnabledKeywords(LocalKeyword[] keywords); // 0x00000001821AF470-0x00000001821AF510
		[FreeFunction("MaterialScripting::SetShaderPassEnabled", HasExplicitThis = true)]
		public void SetShaderPassEnabled(string passName, bool enabled); // 0x00000001821B0E40-0x00000001821B1000
		[FreeFunction("MaterialScripting::GetShaderPassEnabled", HasExplicitThis = true)]
		public bool GetShaderPassEnabled(string passName); // 0x00000001821ABC50-0x00000001821ABE10
		public string GetPassName(int pass); // 0x00000001821AB840-0x00000001821AB980
		public int FindPass(string passName); // 0x00000001821A9770-0x00000001821A9930
		public void SetOverrideTag(string tag, string val); // 0x00000001821B0830-0x00000001821B0AE0
		[NativeName("GetTag")]
		private string GetTagImpl(string tag, bool currentSubShaderOnly, string defaultValue); // 0x00000001821ABE80-0x00000001821AC1A0
		public string GetTag(string tag, bool searchFallbacks, string defaultValue); // 0x00000001821AC210-0x00000001821AC230
		public string GetTag(string tag, bool searchFallbacks); // 0x00000001821AC1A0-0x00000001821AC210
		[FreeFunction("MaterialScripting::Lerp", HasExplicitThis = true, ThrowsException = true)]
		public void Lerp(Material start, Material end, float t); // 0x00000001821AE470-0x00000001821AE560
		[FreeFunction("MaterialScripting::SetPass", HasExplicitThis = true)]
		public bool SetPass(int pass); // 0x00000001821B0B20-0x00000001821B0BC0
		[FreeFunction("MaterialScripting::CopyPropertiesFrom", HasExplicitThis = true)]
		public void CopyPropertiesFromMaterial(Material mat); // 0x00000001821A7EA0-0x00000001821A7F60
		[FreeFunction("MaterialScripting::CopyMatchingPropertiesFrom", HasExplicitThis = true)]
		public void CopyMatchingPropertiesFromMaterial(Material mat); // 0x00000001821A7D90-0x00000001821A7E50
		[FreeFunction("MaterialScripting::GetShaderKeywords", HasExplicitThis = true)]
		private string[] GetShaderKeywords(); // 0x00000001821ABB70-0x00000001821ABC00
		[FreeFunction("MaterialScripting::SetShaderKeywords", HasExplicitThis = true)]
		private void SetShaderKeywords(string[] names); // 0x00000001821B0D40-0x00000001821B0DE0
		[FreeFunction("MaterialScripting::GetPropertyNames", HasExplicitThis = true)]
		private string[] GetPropertyNamesImpl(int propertyType); // 0x00000001821ABA90-0x00000001821ABB30
		[FreeFunction("MaterialScripting::GetPropertyCount", HasExplicitThis = true)]
		internal int GetPropertyCount(); // 0x00000001821AB9C0-0x00000001821ABA50
		public int ComputeCRC(); // 0x00000001821A7CB0-0x00000001821A7D40
		[FreeFunction("MaterialScripting::GetTexturePropertyNames", HasExplicitThis = true)]
		public string[] GetTexturePropertyNames(); // 0x00000001821ACAD0-0x00000001821ACB60
		[FreeFunction("MaterialScripting::GetTexturePropertyNameIDs", HasExplicitThis = true)]
		public int[] GetTexturePropertyNameIDs(); // 0x00000001821AC6A0-0x00000001821AC810
		[FreeFunction("MaterialScripting::GetTexturePropertyNamesInternal", HasExplicitThis = true)]
		private void GetTexturePropertyNamesInternal([NotNull] out List<string> outNames); // 0x00000001821AC8D0-0x00000001821AC990
		[FreeFunction("MaterialScripting::GetTexturePropertyNameIDsInternal", HasExplicitThis = true)]
		private void GetTexturePropertyNameIDsInternal([NotNull] out List<int> outNames); // 0x00000001821AC470-0x00000001821AC650
		public void GetTexturePropertyNames(List<string> outNames); // 0x00000001821AC9D0-0x00000001821ACAD0
		public void GetTexturePropertyNameIDs(List<int> outNames); // 0x00000001821AC810-0x00000001821AC880
		[NativeName("SetIntFromScript")]
		private void SetIntImpl(int name, int value); // 0x00000001821AFBF0-0x00000001821AFCA0
		[NativeName("SetFloatFromScript")]
		private void SetFloatImpl(int name, float value); // 0x00000001821AF9E0-0x00000001821AFA90
		[NativeName("SetColorFromScript")]
		private void SetColorImpl(int name, Color value); // 0x00000001821AEDE0-0x00000001821AEE90
		[NativeName("SetMatrixFromScript")]
		private void SetMatrixImpl(int name, Matrix4x4 value); // 0x00000001821B0570-0x00000001821B0620
		[NativeName("SetTextureFromScript")]
		private void SetTextureImpl(int name, Texture value); // 0x00000001821B1050-0x00000001821B1120
		[NativeName("SetRenderTextureFromScript")]
		private void SetRenderTextureImpl(int name, RenderTexture value, RenderTextureSubElement element); // 0x00000001821B0C20-0x00000001821B0CF0
		[NativeName("SetBufferFromScript")]
		private void SetBufferImpl(int name, ComputeBuffer value); // 0x00000001821AE5B0-0x00000001821AE680
		[NativeName("SetBufferFromScript")]
		private void SetGraphicsBufferImpl(int name, GraphicsBuffer value); // 0x00000001821AE680-0x00000001821AE750
		[NativeName("SetConstantBufferFromScript")]
		private void SetConstantBufferImpl(int name, ComputeBuffer value, int offset, int size); // 0x00000001821AF060-0x00000001821AF130
		[NativeName("SetConstantBufferFromScript")]
		private void SetConstantGraphicsBufferImpl(int name, GraphicsBuffer value, int offset, int size); // 0x00000001821AF210-0x00000001821AF2E0
		[NativeName("GetIntFromScript")]
		private int GetIntImpl(int name); // 0x00000001821AADC0-0x00000001821AAE60
		[NativeName("GetFloatFromScript")]
		private float GetFloatImpl(int name); // 0x00000001821AAC30-0x00000001821AACD0
		[NativeName("GetColorFromScript")]
		private Color GetColorImpl(int name); // 0x00000001821A9F90-0x00000001821AA050
		[NativeName("GetMatrixFromScript")]
		private Matrix4x4 GetMatrixImpl(int name); // 0x00000001821AB540-0x00000001821AB600
		[NativeName("GetTextureFromScript")]
		private Texture GetTextureImpl(int name); // 0x00000001821AC270-0x00000001821AC330
		[NativeName("GetBufferFromScript")]
		private GraphicsBufferHandle GetBufferImpl(int name); // 0x00000001821A9980-0x00000001821A9A30
		[NativeName("GetConstantBufferFromScript")]
		private GraphicsBufferHandle GetConstantBufferImpl(int name); // 0x00000001821AA230-0x00000001821AA2E0
		[FreeFunction(Name = "MaterialScripting::SetFloatArray", HasExplicitThis = true)]
		private void SetFloatArrayImpl(int name, float[] values, int count); // 0x00000001821AF570-0x00000001821AF690
		[FreeFunction(Name = "MaterialScripting::SetVectorArray", HasExplicitThis = true)]
		private void SetVectorArrayImpl(int name, Vector4[] values, int count); // 0x00000001821B1820-0x00000001821B1940
		[FreeFunction(Name = "MaterialScripting::SetColorArray", HasExplicitThis = true)]
		private void SetColorArrayImpl(int name, Color[] values, int count); // 0x00000001821AE970-0x00000001821AEA90
		[FreeFunction(Name = "MaterialScripting::SetMatrixArray", HasExplicitThis = true)]
		private void SetMatrixArrayImpl(int name, Matrix4x4[] values, int count); // 0x00000001821B0100-0x00000001821B0220
		[FreeFunction(Name = "MaterialScripting::GetFloatArray", HasExplicitThis = true)]
		private float[] GetFloatArrayImpl(int name); // 0x00000001821AA890-0x00000001821AAA10
		[FreeFunction(Name = "MaterialScripting::GetVectorArray", HasExplicitThis = true)]
		private Vector4[] GetVectorArrayImpl(int name); // 0x00000001821ACED0-0x00000001821AD050
		[FreeFunction(Name = "MaterialScripting::GetColorArray", HasExplicitThis = true)]
		private Color[] GetColorArrayImpl(int name); // 0x00000001821A9C20-0x00000001821A9D60
		[FreeFunction(Name = "MaterialScripting::GetMatrixArray", HasExplicitThis = true)]
		private Matrix4x4[] GetMatrixArrayImpl(int name); // 0x00000001821AB190-0x00000001821AB310
		[FreeFunction(Name = "MaterialScripting::GetFloatArrayCount", HasExplicitThis = true)]
		private int GetFloatArrayCountImpl(int name); // 0x00000001821AA7A0-0x00000001821AA840
		[FreeFunction(Name = "MaterialScripting::GetVectorArrayCount", HasExplicitThis = true)]
		private int GetVectorArrayCountImpl(int name); // 0x00000001821ACDE0-0x00000001821ACE80
		[FreeFunction(Name = "MaterialScripting::GetColorArrayCount", HasExplicitThis = true)]
		private int GetColorArrayCountImpl(int name); // 0x00000001821A9B30-0x00000001821A9BD0
		[FreeFunction(Name = "MaterialScripting::GetMatrixArrayCount", HasExplicitThis = true)]
		private int GetMatrixArrayCountImpl(int name); // 0x00000001821AB0A0-0x00000001821AB140
		[FreeFunction(Name = "MaterialScripting::ExtractFloatArray", HasExplicitThis = true)]
		private void ExtractFloatArrayImpl(int name, out float[] val); // 0x00000001821A8D20-0x00000001821A8E30
		[FreeFunction(Name = "MaterialScripting::ExtractVectorArray", HasExplicitThis = true)]
		private void ExtractVectorArrayImpl(int name, out Vector4[] val); // 0x00000001821A9400-0x00000001821A9510
		[FreeFunction(Name = "MaterialScripting::ExtractColorArray", HasExplicitThis = true)]
		private void ExtractColorArrayImpl(int name, out Color[] val); // 0x00000001821A89B0-0x00000001821A8AC0
		[FreeFunction(Name = "MaterialScripting::ExtractMatrixArray", HasExplicitThis = true)]
		private void ExtractMatrixArrayImpl(int name, out Matrix4x4[] val); // 0x00000001821A9090-0x00000001821A91A0
		[NativeName("GetTextureScaleAndOffsetFromScript")]
		internal Vector4 GetTextureScaleAndOffsetImpl(int name); // 0x00000001821ACBB0-0x00000001821ACC70
		[NativeName("SetTextureOffsetFromScript")]
		private void SetTextureOffsetImpl(int name, Vector2 offset); // 0x00000001821B1170-0x00000001821B1220
		[NativeName("SetTextureScaleFromScript")]
		private void SetTextureScaleImpl(int name, Vector2 scale); // 0x00000001821B13E0-0x00000001821B1490
		private void SetFloatArray(int name, float[] values, int count); // 0x00000001821AF790-0x00000001821AF990
		private void SetVectorArray(int name, Vector4[] values, int count); // 0x00000001821B1970-0x00000001821B1B70
		private void SetColorArray(int name, Color[] values, int count); // 0x00000001821AEB90-0x00000001821AED90
		private void SetMatrixArray(int name, Matrix4x4[] values, int count); // 0x00000001821B0270-0x00000001821B0470
		private void ExtractFloatArray(int name, List<float> values); // 0x00000001821A8E30-0x00000001821A9040
		private void ExtractVectorArray(int name, List<Vector4> values); // 0x00000001821A9510-0x00000001821A9720
		private void ExtractColorArray(int name, List<Color> values); // 0x00000001821A8AC0-0x00000001821A8CD0
		private void ExtractMatrixArray(int name, List<Matrix4x4> values); // 0x00000001821A91A0-0x00000001821A93B0
		public void SetInt(string name, int value); // 0x00000001821AFCA0-0x00000001821AFD60
		public void SetInt(int nameID, int value); // 0x00000001821AFD60-0x00000001821AFE10
		public void SetFloat(string name, float value); // 0x00000001821AFA90-0x00000001821AFB50
		public void SetFloat(int nameID, float value); // 0x00000001821AF9E0-0x00000001821AFA90
		public void SetInteger(string name, int value); // 0x00000001821AFE10-0x00000001821AFED0
		public void SetInteger(int nameID, int value); // 0x00000001821AFBF0-0x00000001821AFCA0
		public void SetColor(string name, Color value); // 0x00000001821AEF40-0x00000001821AF000
		public void SetColor(int nameID, Color value); // 0x00000001821AEE90-0x00000001821AEF40
		public void SetVector(string name, Vector4 value); // 0x00000001821B1D10-0x00000001821B1DF0
		public void SetVector(int nameID, Vector4 value); // 0x00000001821B1C40-0x00000001821B1D10
		public void SetMatrix(string name, Matrix4x4 value); // 0x00000001821B0620-0x00000001821B0700
		public void SetMatrix(int nameID, Matrix4x4 value); // 0x00000001821B0700-0x00000001821B07D0
		public void SetTexture(string name, Texture value); // 0x00000001821B1600-0x00000001821B16E0
		public void SetTexture(int nameID, Texture value); // 0x00000001821B1050-0x00000001821B1120
		public void SetTexture(string name, RenderTexture value, RenderTextureSubElement element); // 0x00000001821B16E0-0x00000001821B17C0
		public void SetTexture(int nameID, RenderTexture value, RenderTextureSubElement element); // 0x00000001821B0C20-0x00000001821B0CF0
		public void SetBuffer(string name, ComputeBuffer value); // 0x00000001821AE750-0x00000001821AE830
		public void SetBuffer(int nameID, ComputeBuffer value); // 0x00000001821AE5B0-0x00000001821AE680
		public void SetBuffer(string name, GraphicsBuffer value); // 0x00000001821AE830-0x00000001821AE910
		public void SetBuffer(int nameID, GraphicsBuffer value); // 0x00000001821AE680-0x00000001821AE750
		public void SetConstantBuffer(string name, ComputeBuffer value, int offset, int size); // 0x00000001821AF2E0-0x00000001821AF3C0
		public void SetConstantBuffer(int nameID, ComputeBuffer value, int offset, int size); // 0x00000001821AF060-0x00000001821AF130
		public void SetConstantBuffer(string name, GraphicsBuffer value, int offset, int size); // 0x00000001821AF130-0x00000001821AF210
		public void SetConstantBuffer(int nameID, GraphicsBuffer value, int offset, int size); // 0x00000001821AF210-0x00000001821AF2E0
		public void SetFloatArray(string name, List<float> values); // 0x00000001821AF740-0x00000001821AF790
		public void SetFloatArray(int nameID, List<float> values); // 0x00000001821AF710-0x00000001821AF740
		public void SetFloatArray(string name, float[] values); // 0x00000001821AF6C0-0x00000001821AF710
		public void SetFloatArray(int nameID, float[] values); // 0x00000001821AF690-0x00000001821AF6C0
		public void SetColorArray(string name, List<Color> values); // 0x00000001821AEB40-0x00000001821AEB90
		public void SetColorArray(int nameID, List<Color> values); // 0x00000001821AEB10-0x00000001821AEB40
		public void SetColorArray(string name, Color[] values); // 0x00000001821AEA90-0x00000001821AEAE0
		public void SetColorArray(int nameID, Color[] values); // 0x00000001821AEAE0-0x00000001821AEB10
		public void SetVectorArray(string name, List<Vector4> values); // 0x00000001821B1BA0-0x00000001821B1BF0
		public void SetVectorArray(int nameID, List<Vector4> values); // 0x00000001821B1940-0x00000001821B1970
		public void SetVectorArray(string name, Vector4[] values); // 0x00000001821B1BF0-0x00000001821B1C40
		public void SetVectorArray(int nameID, Vector4[] values); // 0x00000001821B1B70-0x00000001821B1BA0
		public void SetMatrixArray(string name, List<Matrix4x4> values); // 0x00000001821B0220-0x00000001821B0270
		public void SetMatrixArray(int nameID, List<Matrix4x4> values); // 0x00000001821B0470-0x00000001821B04A0
		public void SetMatrixArray(string name, Matrix4x4[] values); // 0x00000001821B04D0-0x00000001821B0520
		public void SetMatrixArray(int nameID, Matrix4x4[] values); // 0x00000001821B04A0-0x00000001821B04D0
		public int GetInt(string name); // 0x00000001821AAE60-0x00000001821AAF10
		public int GetInt(int nameID); // 0x00000001821AAF10-0x00000001821AAFB0
		public float GetFloat(string name); // 0x00000001821AACD0-0x00000001821AAD80
		public float GetFloat(int nameID); // 0x00000001821AAC30-0x00000001821AACD0
		public int GetInteger(string name); // 0x00000001821AAFB0-0x00000001821AB060
		public int GetInteger(int nameID); // 0x00000001821AADC0-0x00000001821AAE60
		public Color GetColor(string name); // 0x00000001821AA050-0x00000001821AA120
		public Color GetColor(int nameID); // 0x00000001821AA120-0x00000001821AA1E0
		public Vector4 GetVector(string name); // 0x00000001821AD230-0x00000001821AD300
		public Vector4 GetVector(int nameID); // 0x00000001821AD300-0x00000001821AD3D0
		public Matrix4x4 GetMatrix(string name); // 0x00000001821AB600-0x00000001821AB700
		public Matrix4x4 GetMatrix(int nameID); // 0x00000001821AB700-0x00000001821AB7F0
		public Texture GetTexture(string name); // 0x00000001821ACD60-0x00000001821ACD90
		public Texture GetTexture(int nameID); // 0x00000001821ACD90-0x00000001821ACDA0
		public GraphicsBufferHandle GetBuffer(string name); // 0x00000001821A9A30-0x00000001821A9AF0
		public GraphicsBufferHandle GetConstantBuffer(string name); // 0x00000001821AA2E0-0x00000001821AA3A0
		public float[] GetFloatArray(string name); // 0x00000001821AAAD0-0x00000001821AABA0
		public float[] GetFloatArray(int nameID); // 0x00000001821AAA10-0x00000001821AAAD0
		public Color[] GetColorArray(string name); // 0x00000001821A9E70-0x00000001821A9F40
		public Color[] GetColorArray(int nameID); // 0x00000001821A9DA0-0x00000001821A9E60
		public Vector4[] GetVectorArray(string name); // 0x00000001821AD050-0x00000001821AD120
		public Vector4[] GetVectorArray(int nameID); // 0x00000001821AD120-0x00000001821AD1E0
		public Matrix4x4[] GetMatrixArray(string name); // 0x00000001821AB350-0x00000001821AB420
		public Matrix4x4[] GetMatrixArray(int nameID); // 0x00000001821AB430-0x00000001821AB4F0
		public void GetFloatArray(string name, List<float> values); // 0x00000001821AABA0-0x00000001821AABE0
		public void GetFloatArray(int nameID, List<float> values); // 0x00000001821AABE0-0x00000001821AABF0
		public void GetColorArray(string name, List<Color> values); // 0x00000001821A9D60-0x00000001821A9DA0
		public void GetColorArray(int nameID, List<Color> values); // 0x00000001821A9E60-0x00000001821A9E70
		public void GetVectorArray(string name, List<Vector4> values); // 0x00000001821AD1F0-0x00000001821AD230
		public void GetVectorArray(int nameID, List<Vector4> values); // 0x00000001821AD1E0-0x00000001821AD1F0
		public void GetMatrixArray(string name, List<Matrix4x4> values); // 0x00000001821AB310-0x00000001821AB350
		public void GetMatrixArray(int nameID, List<Matrix4x4> values); // 0x00000001821AB420-0x00000001821AB430
		public void SetTextureOffset(string name, Vector2 value); // 0x00000001821B1220-0x00000001821B12E0
		public void SetTextureOffset(int nameID, Vector2 value); // 0x00000001821B12E0-0x00000001821B1390
		public void SetTextureScale(string name, Vector2 value); // 0x00000001821B1490-0x00000001821B1550
		public void SetTextureScale(int nameID, Vector2 value); // 0x00000001821B1550-0x00000001821B1600
		public Vector2 GetTextureOffset(string name); // 0x00000001821AC3F0-0x00000001821AC420
		public Vector2 GetTextureOffset(int nameID); // 0x00000001821AC330-0x00000001821AC3F0
		public Vector2 GetTextureScale(string name); // 0x00000001821ACD30-0x00000001821ACD60
		public Vector2 GetTextureScale(int nameID); // 0x00000001821ACC70-0x00000001821ACD30
		public string[] GetPropertyNames(MaterialPropertyType type); // 0x00000001821ABA90-0x00000001821ABB30
		private static void CreateWithShader_Injected([Writable] Material self, IntPtr shader); // 0x00000001821A8070-0x00000001821A80C0
		private static void CreateWithMaterial_Injected([Writable] Material self, IntPtr source); // 0x00000001821A7F60-0x00000001821A7FB0
		private static IntPtr GetDefaultMaterial_Injected(); // 0x00000001821AA450-0x00000001821AA480
		private static IntPtr GetDefaultParticleMaterial_Injected(); // 0x00000001821AA500-0x00000001821AA530
		private static IntPtr GetDefaultLineMaterial_Injected(); // 0x00000001821AA3A0-0x00000001821AA3D0
		private static IntPtr get_shader_Injected(IntPtr _unity_self); // 0x00000001821B2AB0-0x00000001821B2AF0
		private static void set_shader_Injected(IntPtr _unity_self, IntPtr value); // 0x00000001821B3620-0x00000001821B3670
		private static int GetFirstPropertyNameIdByAttribute_Injected(IntPtr _unity_self, ShaderPropertyFlags attributeFlag); // 0x00000001821AA680-0x00000001821AA6C0
		private static bool HasProperty_Injected(IntPtr _unity_self, int nameID); // 0x00000001821ADCF0-0x00000001821ADD30
		private static bool HasFloatImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821AD840-0x00000001821AD880
		private static bool HasIntImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821AD9D0-0x00000001821ADA10
		private static bool HasTextureImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821ADE80-0x00000001821ADEC0
		private static bool HasMatrixImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821ADB60-0x00000001821ADBA0
		private static bool HasVectorImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821AE010-0x00000001821AE050
		private static bool HasBufferImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821AD3D0-0x00000001821AD410
		private static bool HasConstantBufferImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821AD6B0-0x00000001821AD6F0
		private static int get_renderQueue_Injected(IntPtr _unity_self); // 0x00000001821B29E0-0x00000001821B2A20
		private static void set_renderQueue_Injected(IntPtr _unity_self, int value); // 0x00000001821B3540-0x00000001821B3580
		private static int get_rawRenderQueue_Injected(IntPtr _unity_self); // 0x00000001821B2910-0x00000001821B2950
		private static void EnableKeyword_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword); // 0x00000001821A85B0-0x00000001821A8600
		private static void DisableKeyword_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword); // 0x00000001821A8200-0x00000001821A8250
		private static bool IsKeywordEnabled_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword); // 0x00000001821AE050-0x00000001821AE0A0
		private static void EnableLocalKeyword_Injected(IntPtr _unity_self, in LocalKeyword keyword); // 0x00000001821A8870-0x00000001821A88C0
		private static void DisableLocalKeyword_Injected(IntPtr _unity_self, in LocalKeyword keyword); // 0x00000001821A84C0-0x00000001821A8510
		private static void SetLocalKeyword_Injected(IntPtr _unity_self, in LocalKeyword keyword, bool value); // 0x00000001821AFF90-0x00000001821AFFF0
		private static bool IsLocalKeywordEnabled_Injected(IntPtr _unity_self, in LocalKeyword keyword); // 0x00000001821AE310-0x00000001821AE360
		private static LocalKeyword[] GetEnabledKeywords_Injected(IntPtr _unity_self); // 0x00000001821AA5B0-0x00000001821AA5F0
		private static void SetEnabledKeywords_Injected(IntPtr _unity_self, LocalKeyword[] keywords); // 0x00000001821AF420-0x00000001821AF470
		private static MaterialGlobalIlluminationFlags get_globalIlluminationFlags_Injected(IntPtr _unity_self); // 0x00000001821B2470-0x00000001821B24B0
		private static void set_globalIlluminationFlags_Injected(IntPtr _unity_self, MaterialGlobalIlluminationFlags value); // 0x00000001821B2F30-0x00000001821B2F70
		private static bool get_doubleSidedGI_Injected(IntPtr _unity_self); // 0x00000001821B22D0-0x00000001821B2310
		private static void set_doubleSidedGI_Injected(IntPtr _unity_self, bool value); // 0x00000001821B2D50-0x00000001821B2DA0
		private static bool get_enableInstancing_Injected(IntPtr _unity_self); // 0x00000001821B23A0-0x00000001821B23E0
		private static void set_enableInstancing_Injected(IntPtr _unity_self, bool value); // 0x00000001821B2E40-0x00000001821B2E90
		private static int get_passCount_Injected(IntPtr _unity_self); // 0x00000001821B2840-0x00000001821B2880
		private static void SetShaderPassEnabled_Injected(IntPtr _unity_self, ref ManagedSpanWrapper passName, bool enabled); // 0x00000001821B0DE0-0x00000001821B0E40
		private static bool GetShaderPassEnabled_Injected(IntPtr _unity_self, ref ManagedSpanWrapper passName); // 0x00000001821ABC00-0x00000001821ABC50
		private static void GetPassName_Injected(IntPtr _unity_self, int pass, ); // 0x00000001821AB7F0-0x00000001821AB840
		private static int FindPass_Injected(IntPtr _unity_self, ref ManagedSpanWrapper passName); // 0x00000001821A9720-0x00000001821A9770
		private static void SetOverrideTag_Injected(IntPtr _unity_self, ref ManagedSpanWrapper tag, ref ManagedSpanWrapper val); // 0x00000001821B07D0-0x00000001821B0830
		private static void GetTagImpl_Injected(IntPtr _unity_self, ref ManagedSpanWrapper tag, bool currentSubShaderOnly, ref ManagedSpanWrapper defaultValue, ); // 0x00000001821ABE10-0x00000001821ABE80
		private static void Lerp_Injected(IntPtr _unity_self, IntPtr start, IntPtr end, float t); // 0x00000001821AE400-0x00000001821AE470
		private static bool SetPass_Injected(IntPtr _unity_self, int pass); // 0x00000001821B0AE0-0x00000001821B0B20
		private static void CopyPropertiesFromMaterial_Injected(IntPtr _unity_self, IntPtr mat); // 0x00000001821A7E50-0x00000001821A7EA0
		private static void CopyMatchingPropertiesFromMaterial_Injected(IntPtr _unity_self, IntPtr mat); // 0x00000001821A7D40-0x00000001821A7D90
		private static string[] GetShaderKeywords_Injected(IntPtr _unity_self); // 0x00000001821ABB30-0x00000001821ABB70
		private static void SetShaderKeywords_Injected(IntPtr _unity_self, string[] names); // 0x00000001821B0CF0-0x00000001821B0D40
		private static string[] GetPropertyNamesImpl_Injected(IntPtr _unity_self, int propertyType); // 0x00000001821ABA50-0x00000001821ABA90
		private static int GetPropertyCount_Injected(IntPtr _unity_self); // 0x00000001821AB980-0x00000001821AB9C0
		private static int ComputeCRC_Injected(IntPtr _unity_self); // 0x00000001821A7C70-0x00000001821A7CB0
		private static string[] GetTexturePropertyNames_Injected(IntPtr _unity_self); // 0x00000001821AC990-0x00000001821AC9D0
		private static void GetTexturePropertyNameIDs_Injected(IntPtr _unity_self, ); // 0x00000001821AC650-0x00000001821AC6A0
		private static void GetTexturePropertyNamesInternal_Injected(IntPtr _unity_self, out List<string> outNames); // 0x00000001821AC880-0x00000001821AC8D0
		private static void GetTexturePropertyNameIDsInternal_Injected(IntPtr _unity_self, out BlittableListWrapper outNames); // 0x00000001821AC420-0x00000001821AC470
		private static void SetIntImpl_Injected(IntPtr _unity_self, int name, int value); // 0x00000001821AFBA0-0x00000001821AFBF0
		private static void SetFloatImpl_Injected(IntPtr _unity_self, int name, float value); // 0x00000001821AF990-0x00000001821AF9E0
		private static void SetColorImpl_Injected(IntPtr _unity_self, int name, in Color value); // 0x00000001821AED90-0x00000001821AEDE0
		private static void SetMatrixImpl_Injected(IntPtr _unity_self, int name, in Matrix4x4 value); // 0x00000001821B0520-0x00000001821B0570
		private static void SetTextureImpl_Injected(IntPtr _unity_self, int name, IntPtr value); // 0x00000001821B1000-0x00000001821B1050
		private static void SetRenderTextureImpl_Injected(IntPtr _unity_self, int name, IntPtr value, RenderTextureSubElement element); // 0x00000001821B0BC0-0x00000001821B0C20
		private static void SetBufferImpl_Injected(IntPtr _unity_self, int name, IntPtr value); // 0x00000001821AE560-0x00000001821AE5B0
		private static void SetGraphicsBufferImpl_Injected(IntPtr _unity_self, int name, IntPtr value); // 0x00000001821AFB50-0x00000001821AFBA0
		private static void SetConstantBufferImpl_Injected(IntPtr _unity_self, int name, IntPtr value, int offset, int size); // 0x00000001821AF000-0x00000001821AF060
		private static void SetConstantGraphicsBufferImpl_Injected(IntPtr _unity_self, int name, IntPtr value, int offset, int size); // 0x00000001821AF3C0-0x00000001821AF420
		private static int GetIntImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821AAD80-0x00000001821AADC0
		private static float GetFloatImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821AABF0-0x00000001821AAC30
		private static void GetColorImpl_Injected(IntPtr _unity_self, int name, ); // 0x00000001821A9F40-0x00000001821A9F90
		private static void GetMatrixImpl_Injected(IntPtr _unity_self, int name, ); // 0x00000001821AB4F0-0x00000001821AB540
		private static IntPtr GetTextureImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821AC230-0x00000001821AC270
		private static void GetBufferImpl_Injected(IntPtr _unity_self, int name, ); // 0x00000001821A9930-0x00000001821A9980
		private static void GetConstantBufferImpl_Injected(IntPtr _unity_self, int name, ); // 0x00000001821AA1E0-0x00000001821AA230
		private static void SetFloatArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count); // 0x00000001821AF510-0x00000001821AF570
		private static void SetVectorArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count); // 0x00000001821B17C0-0x00000001821B1820
		private static void SetColorArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count); // 0x00000001821AE910-0x00000001821AE970
		private static void SetMatrixArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count); // 0x00000001821B00A0-0x00000001821B0100
		private static void GetFloatArrayImpl_Injected(IntPtr _unity_self, int name, ); // 0x00000001821AA840-0x00000001821AA890
		private static void GetVectorArrayImpl_Injected(IntPtr _unity_self, int name, ); // 0x00000001821ACE80-0x00000001821ACED0
		private static void GetColorArrayImpl_Injected(IntPtr _unity_self, int name, ); // 0x00000001821A9BD0-0x00000001821A9C20
		private static void GetMatrixArrayImpl_Injected(IntPtr _unity_self, int name, ); // 0x00000001821AB140-0x00000001821AB190
		private static int GetFloatArrayCountImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821AA760-0x00000001821AA7A0
		private static int GetVectorArrayCountImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821ACDA0-0x00000001821ACDE0
		private static int GetColorArrayCountImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821A9AF0-0x00000001821A9B30
		private static int GetMatrixArrayCountImpl_Injected(IntPtr _unity_self, int name); // 0x00000001821AB060-0x00000001821AB0A0
		private static void ExtractFloatArrayImpl_Injected(IntPtr _unity_self, int name, out BlittableArrayWrapper val); // 0x00000001821A8CD0-0x00000001821A8D20
		private static void ExtractVectorArrayImpl_Injected(IntPtr _unity_self, int name, out BlittableArrayWrapper val); // 0x00000001821A93B0-0x00000001821A9400
		private static void ExtractColorArrayImpl_Injected(IntPtr _unity_self, int name, out BlittableArrayWrapper val); // 0x00000001821A8960-0x00000001821A89B0
		private static void ExtractMatrixArrayImpl_Injected(IntPtr _unity_self, int name, out BlittableArrayWrapper val); // 0x00000001821A9040-0x00000001821A9090
		private static void GetTextureScaleAndOffsetImpl_Injected(IntPtr _unity_self, int name, ); // 0x00000001821ACB60-0x00000001821ACBB0
		private static void SetTextureOffsetImpl_Injected(IntPtr _unity_self, int name, in Vector2 offset); // 0x00000001821B1120-0x00000001821B1170
		private static void SetTextureScaleImpl_Injected(IntPtr _unity_self, int name, in Vector2 scale); // 0x00000001821B1390-0x00000001821B13E0
	}
}
