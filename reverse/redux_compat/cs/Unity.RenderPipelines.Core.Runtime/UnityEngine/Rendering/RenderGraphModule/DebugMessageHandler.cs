/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	internal class DebugMessageHandler : ScriptableObject // TypeDefIndex: 5870
	{
		// Fields
		internal const int k_Version = 2; // Metadata: 0x00661BCF
		private static readonly Guid s_EditorToPlayerGuid; // 0x00
		private static readonly Guid s_PlayerToEditorGuid; // 0x10
		private Action<MessageType, IPayload> m_UserCallback; // 0x18
	
		// Nested types
		public enum MessageType : byte // TypeDefIndex: 5871
		{
			Activate = 0,
			DebugData = 1,
			AnalyticsData = 2
		}
	
		public abstract class IPayload // TypeDefIndex: 5872
		{
			// Fields
			public int version; // 0x10
	
			// Properties
			public bool isCompatible { get; } // 0x0000000181EBF710-0x0000000181EBF720 
	
			// Constructors
			protected IPayload(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public class DebugDataPayload : IPayload // TypeDefIndex: 5873
		{
			// Fields
			public string graphName; // 0x18
			public EntityId executionId; // 0x20
			public RenderGraph.DebugData debugData; // 0x28
	
			// Constructors
			public DebugDataPayload(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public class AnalyticsPayload : IPayload // TypeDefIndex: 5874
		{
			// Fields
			public GraphicsDeviceType graphicsDeviceType; // 0x18
			public DeviceType deviceType; // 0x1C
			public string deviceModel; // 0x20
			public string gpuVendor; // 0x28
			public string gpuName; // 0x30
	
			// Constructors
			public AnalyticsPayload(); // 0x0000000181EBC890-0x0000000181EBC900
		}
	
		// Constructors
		public DebugMessageHandler(); // 0x00000001805F5FD0-0x00000001805F5FE0
		static DebugMessageHandler(); // 0x0000000181EBEE90-0x0000000181EBEF40
	
		// Methods
		private void InternalCallback(MessageEventArgs msg); // 0x0000000181EBE5E0-0x0000000181EBE680
		public void Register(Action<MessageType, IPayload> callback); // 0x0000000181EBE680-0x0000000181EBE790
		public void UnregisterAll(); // 0x0000000181EBED90-0x0000000181EBEE90
		public void Send(MessageType messageType, IPayload payload = null); // 0x0000000181EBE790-0x0000000181EBE860
		internal static byte[] SerializeMessage(MessageType type, IPayload payload = null); // 0x0000000181EBE860-0x0000000181EBED90
		internal static ValueTuple<MessageType, IPayload> DeserializeMessage(byte[] data); // 0x0000000181EBDF00-0x0000000181EBE5E0
	}
}
