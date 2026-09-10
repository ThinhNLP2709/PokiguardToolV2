/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class GuildRole // TypeDefIndex: 758
{
	// Fields
	public const int MASTER = 1; // Metadata: 0x0068BABA
	public const int VICE = 2; // Metadata: 0x0068BABB
	public const int ELDER = 3; // Metadata: 0x0068BABC
	public const int MEMBER = 4; // Metadata: 0x0068BABD

	// Methods
	public static string Name(int role); // 0x000000018047D700-0x000000018047D820
	public static Color Color(int role); // 0x000000018047D680-0x000000018047D700
	public static int Clamp(int role); // 0x000000018047D670-0x000000018047D680
	public static bool CanManageRequests(int myRole); // 0x000000018047D640-0x000000018047D650
	public static bool CanEditGuild(int myRole); // 0x000000018047D610-0x000000018047D620
	public static bool CanKick(int myRole, int targetRole); // 0x000000018047D620-0x000000018047D640
	public static bool CanDemote(int myRole, int targetRole); // 0x000000018047D5F0-0x000000018047D610
	public static bool CanPromote(int myRole, int targetRole); // 0x000000018047D650-0x000000018047D670
}

