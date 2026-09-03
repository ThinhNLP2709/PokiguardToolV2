/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal sealed class StpHistory : CameraHistoryItem // TypeDefIndex: 9491
	{
		// Fields
		private STP.HistoryContext[] m_historyContexts; // 0x20
	
		// Constructors
		public StpHistory(); // 0x0000000181F98EF0-0x0000000181F98F50
	
		// Methods
		public override void OnCreate(BufferedRTHandleSystem owner, uint typeId); // 0x0000000181F98C80-0x0000000181F98D50
		public override void Reset(); // 0x0000000181F98D50-0x0000000181F98DC0
		internal STP.HistoryContext GetHistoryContext(int eyeIndex); // 0x0000000181F98C50-0x0000000181F98C80
		internal bool Update(UniversalCameraData cameraData); // 0x0000000181F98DC0-0x0000000181F98EF0
	}
}
