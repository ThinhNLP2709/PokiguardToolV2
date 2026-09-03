/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class CommandListManager : IDisposable // TypeDefIndex: 5018
	{
		// Fields
		private readonly IntPtr m_VertexDecl; // 0x10
		private readonly IntPtr m_DefaultStencilState; // 0x18
		private uint m_SafeFrameIndex; // 0x20
		private Stack<CommandList> m_CommandListPool; // 0x28
		private CommandList m_DefaultCommandList; // 0x30
		private List<CommandList>[] m_CommandListsArray; // 0x38
		private List<CommandList> m_CurrentFrameCommandLists; // 0x40
		private List<UIRenderer> m_UIRenderersWithDrawCallData; // 0x48
		private List<PanelRenderer> m_PanelRenderersWithDrawCallData; // 0x50
		private TextureSlotCount m_TextureSlotCount; // 0x58
		private List<SerializedCommand> m_SerializedCommands; // 0x60
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x68
	
		// Properties
		public CommandList defaultCommandList { get; } // 0x000000018031E110-0x000000018031E120 
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B25580-0x0000000180B25590 0x0000000180B262C0-0x0000000180B262D0
	
		// Constructors
		public CommandListManager(IntPtr vertexDecl, IntPtr defaultStencilState); // 0x00000001823F2070-0x00000001823F2300
	
		// Methods
		public CommandList GetOrCreateCommandList(VisualElement owner, Material material, CommandFlags commandFlags); // 0x00000001823F1C60-0x00000001823F1DC0
		public void AdvanceFrame(); // 0x00000001823F1330-0x00000001823F15A0
		public void BeginSerialize(TextureSlotCount textureSlotCount); // 0x00000001823F15A0-0x00000001823F15E0
		public void EndSerialize(); // 0x00000001823F1860-0x00000001823F1C60
		public void Dispose(); // 0x00000001823F1850-0x00000001823F1860
		public void ResetUIRendererDrawCallData(); // 0x00000001823F1DC0-0x00000001823F2070
		protected void Dispose(bool disposing); // 0x00000001823F15E0-0x00000001823F1850
	}
}
