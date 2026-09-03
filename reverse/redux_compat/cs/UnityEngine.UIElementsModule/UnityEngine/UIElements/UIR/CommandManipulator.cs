/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal static class CommandManipulator // TypeDefIndex: 5019
	{
		// Methods
		public static void ReplaceHeadCommands(RenderTreeManager renderTreeManager, RenderData renderData, EntryProcessor processor); // 0x00000001823F43C0-0x00000001823F4650
		public static void ReplaceTailCommands(RenderTreeManager renderTreeManager, RenderData renderData, EntryProcessor processor); // 0x00000001823F4650-0x00000001823F49C0
		private static RenderChainCommand FindPrevCommand(RenderData candidate, bool searchFromHead); // 0x00000001823F3C90-0x00000001823F3D10
		private static void FindHeadCommandInsertionPoint(RenderData renderData, out RenderChainCommand prev, out RenderChainCommand next); // 0x00000001823F3B60-0x00000001823F3C90
		private static void FindTailCommandInsertionPoint(RenderData renderData, out RenderChainCommand prev, out RenderChainCommand next); // 0x00000001823F3D10-0x00000001823F3E20
		private static void RemoveChain(RenderTree renderTree, RenderChainCommand first, RenderChainCommand last); // 0x00000001823F3F80-0x00000001823F4090
		public static void ResetCommands(RenderTreeManager renderTreeManager, RenderData renderData); // 0x00000001823F49C0-0x00000001823F4CB0
		private static void InjectCommandInBetween(RenderChainCommand cmd, bool isHeadCommand, RenderChainCommand prev, RenderChainCommand next); // 0x00000001823F3E20-0x00000001823F3F80
		public static void DisableElementRendering(RenderTreeManager renderTreeManager, VisualElement ve, bool renderingDisabled); // 0x00000001823F3140-0x00000001823F3B60
		private static void RemoveSingleCommand(RenderTreeManager renderTreeManager, RenderData renderData, RenderChainCommand cmd); // 0x00000001823F4090-0x00000001823F43C0
	}
}
