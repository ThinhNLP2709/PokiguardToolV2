# Opus — bảng KNOWN/UNKNOWN (knowledge audit)

Ghi theo code và tài liệu tại commit `5c887b77` (23/11/2026). Mỗi phase sau phải cập nhật khi
một mục đổi trạng thái. Nhãn: **KNOWN** (code/runtime đã kiểm), **USER** (khai báo của user),
**STATIC** (khai báo tĩnh trong reverse, chưa kiểm runtime), **HYPOTHESIS** (giả thuyết),
**UNKNOWN**, **GAP** (code chưa có).

| Năng lực | Trạng thái | Module / nguồn | Ghi chú, phase xử lý |
|---|---|---|---|
| Boss ID của phiên | KNOWN | `normalized_boss_id` đã pin trong config | Key registry boss (U2/U4) |
| Đảo/level của boss | KNOWN | `chinh_phuc_map.read_chinh_phuc_target_metadata` | Chưa vào snapshot suy luận (U2) |
| petId boss trong snapshot | GAP | `ParticipantState` không có petId | Thêm từ config/player context (U2) |
| HP/Mana/Nộ/Khiên/Attack hai bên | KNOWN | `player_stats.py` → `ParticipantState` | Có cả Khiên boss |
| Boss tự bơm Mana/Nộ, ra skill (Đảo Cổ Đại+) | USER | `boss_threat.py`, `boss_skill_knowledge.md` | Lượng/tần suất UNKNOWN (U5/U9) |
| Ngưỡng skill boss | UNKNOWN | — | Học từ log (U9) |
| Cooldown/stack skill boss | STATIC | `MatchPlayerSnapshotDTO.skillCooldownLeft/skillStacks…` | Chiếu từ JSON, kiểm (U2) |
| Boss hồi máu | KNOWN (1 mẫu) | Raijin: +18.414.835 HP | Ngưỡng/lượng chung UNKNOWN (U9) |
| Hút ra Mana hoặc Nộ | KNOWN | B17 `stealType` MANA/POWER | Cách server chọn và lượng UNKNOWN (U9) |
| Boss có Khiên thì Hút không lấy được | HYPOTHESIS | User 23/11 | Kiểm STEAL khi Khiên boss > 0 (U1/U2) |
| Hút = theft trong lõi chung | KNOWN | `reasoning_common_tactics._drain_fills` | Denial có/không chưa có (U5) |
| Refill do server sinh | KNOWN | `research/spawn/spawn_research.md` | Phân phối UNKNOWN; SPAWN chưa thu (U2) |
| Tỷ lệ rơi viên/may mắn | STATIC | `dotDropPct`, `luckyDotTag`, `luckPct` | Chưa rõ nghĩa (U2) |
| Hệ số viên x1–x7 | KNOWN | `state.py` | — |
| 1 viên Mana = 30, Nộ = 20 | USER | `reasoning_common_models.RESOURCE_DECLARATION` | Kiểm lại từ log (U9) |
| Nộ tối đa 250, mốc 100 | USER | `gameplay_rules.md` | — |
| Công thức sát thương | UNKNOWN | `damage_*` research, chưa deploy | Quantile Tier 1 (U9) |
| Chi phí tiến hóa/skill/chưởng | KNOWN | runtime Fusion/CardData/`PetSkillCapability` | Không hard-code |
| Tỷ lệ tiến hóa thành công | STATIC | `fusionPityFails/fusionPityPercent` | Kiểm (U2), dùng ở U6b |
| Chính sách nước boss | KNOWN (3/3) | 13 khoảng B17, max-Sword | Chưa đủ kết luận chung (U9) |
| PASS 2/3, lượt đầu | KNOWN | `game_owned_idle.py`, `pass_evidence` | Giữ nguyên |
| Lõi chung có G4 | GAP | `reasoning_common_problem.PROFILES` | Thêm ở U4 |
| Đề xuất EVOLVE/CAST/giữ skill tới host | GAP | `apply_common_action`, `galaxy_strategy_allows` | U6a |
| Worker suy luận trong bản EXE | GAP | `load_common_authority` chặn package | Admission theo số đo (U1/U8) |
| Worker suy luận cho Coop | GAP | `UI_REASONING_TEAM_MODEL_PENDING` | U13 |
| Mốc combo G4 9–13, cộng x1–x7 | USER | `galaxy_shadow_sword.py` | — |
| Hình ấn Mega Icarus/T-Rex | KNOWN (tĩnh B15) | `mega_icarus.py` | — |
| Pha skill Galaxy G1/G3 | KNOWN (B15 native) | `galaxy_skill_phase.py` | — |
