/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[Serializable]
public class HubBootstrapData // TypeDefIndex: 1268
{
	// Fields
	public UserDTO user; // 0x10
	public EnergyInfoDTO energy; // 0x18
	public long giftCount; // 0x20
	[Obsolete("Server v2 kh\u00F4ng sinh n\u1EEFa (app.hub.bootstrap.legacyLists=false). H\u1ED9p th\u01B0 t\u1EF1 t\u1EA3i khi m\u1EDF.")]
	public List<GiftDTO> pendingGifts; // 0x28
	[Obsolete("Server v2 kh\u00F4ng sinh n\u1EEFa (app.hub.bootstrap.legacyLists=false). Panel Nhi\u1EC7m v\u1EE5 t\u1EF1 t\u1EA3i.")]
	public List<QuestData> dailyQuests; // 0x30
	public ThongBaoListData notifications; // 0x38
	[Obsolete("Server v2 kh\u00F4ng sinh n\u1EEFa (app.hub.bootstrap.petLibrary=false). Th\u01B0 vi\u1EC7n d\u00F9ng /pets/paginated.")]
	public List<PetLibDTO> petLibrary; // 0x40
	public long serverTime; // 0x48
	public HubBadgesData badges; // 0x50

	// Constructors
	public HubBootstrapData(); // 0x00000001802E9CB0-0x00000001802E9CC0
}

