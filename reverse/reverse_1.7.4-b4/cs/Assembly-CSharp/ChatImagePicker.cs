/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class ChatImagePicker // TypeDefIndex: 493
{
	// Nested types
	private struct OpenFileName // TypeDefIndex: 494
	{
		// Fields
		public int structSize; // 0x00
		public IntPtr hwndOwner; // 0x08
		public IntPtr hInstance; // 0x10
		public string filter; // 0x18
		public string customFilter; // 0x20
		public int maxCustFilter; // 0x28
		public int filterIndex; // 0x2C
		public string file; // 0x30
		public int maxFile; // 0x38
		public string fileTitle; // 0x40
		public int maxFileTitle; // 0x48
		public string initialDir; // 0x50
		public string title; // 0x58
		public int flags; // 0x60
		public short fileOffset; // 0x64
		public short fileExtension; // 0x66
		public string defExt; // 0x68
		public IntPtr custData; // 0x70
		public IntPtr hook; // 0x78
		public string templateName; // 0x80
		public IntPtr reservedPtr; // 0x88
		public int reservedInt; // 0x90
		public int flagsEx; // 0x94
	}

	// Methods
	public static void PickJpeg(int maxSide, Action<byte[], int, int> onPicked, Action<string> onFail); // 0x0000000180397D90-0x0000000180397DF0
	private static void EncodeFromFile(string path, int maxSide, Action<byte[], int, int> onPicked, Action<string> onFail); // 0x0000000180397DF0-0x0000000180398260
	private static void EncodeTexture(Texture2D src, int maxSide, bool destroySource, Action<byte[], int, int> onPicked, Action<string> onFail); // 0x0000000180398260-0x00000001803989B0
	private static Texture2D Downscale(Texture2D src, int nw, int nh); // 0x00000001803989B0-0x0000000180399030
	private static extern bool GetOpenFileNameW([In, Out] OpenFileName ofn); // 0x0000000180399030-0x0000000180399200
	private static string OpenFileDialogWin(); // 0x0000000180399200-0x00000001803998A0
}

