/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal class ConstantBufferSingleton<CBType> : ConstantBuffer<CBType> // TypeDefIndex: 5345
		where CBType : struct
	{
		// Fields
		private static ConstantBufferSingleton<CBType> s_Instance;
	
		// Properties
		internal static ConstantBufferSingleton<CBType> instance { get; set; }
	
		// Constructors
		public ConstantBufferSingleton();
	
		// Methods
		public override void Release();
	}
}
