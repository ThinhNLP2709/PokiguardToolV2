# Opus — bảng KNOWN/UNKNOWN (knowledge audit)

Ghi theo code và tài liệu tại commit `5c887b77` (23/11/2026), cập nhật sau U1 (24/11/2026,
[báo cáo](reports/U1_report.md)). Mỗi phase sau phải cập nhật khi
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
| Boss có Khiên thì Hút không lấy được | KNOWN (quan sát U2, đã ghi kiến thức chung) | `tools/u2_steal_shield_check.py`: Khiên > 0 và ăn Hút → 0 lần lấy được nếu boss chưa bị đánh trước; 16/16 lần lấy được đều sau đòn vào boss | Lượng Khiên bị phá, thứ tự xử lý UNKNOWN |
| Hút = theft trong lõi chung | KNOWN | `reasoning_common_tactics._drain_fills` | Denial có/không chưa có (U5) |
| Refill do server sinh | KNOWN | `research/spawn/spawn_research.md` | Phân phối UNKNOWN; SPAWN chưa thu (U2) |
| Tỷ lệ rơi viên/may mắn | STATIC | `dotDropPct`, `luckyDotTag`, `luckPct` | Chưa rõ nghĩa (U2) |
| Hệ số viên x1–x7 | KNOWN | `state.py` | — |
| 1 viên Mana = 30, Nộ = 20 | USER | `reasoning_common_models.RESOURCE_DECLARATION` | Kiểm lại từ log (U9) |
| Nộ tối đa 250, mốc 100 | USER | `gameplay_rules.md` | — |
| Ăn Kiếm khi Nộ ≥ 100 thì trừ 100 Nộ (`FULL_POWER`) | KNOWN (log U1) | Icarus: Nộ 115/125/140/250 bị trừ 100; Nộ 95 không bị trừ | Chưa có mẫu sạch ở đúng 100; luật K6 D-U1 |
| Công thức sát thương | UNKNOWN | `damage_*` research, chưa deploy | Quantile Tier 1 (U9) |
| Chi phí tiến hóa/skill/chưởng | KNOWN | runtime Fusion/CardData/`PetSkillCapability` | Không hard-code |
| Tỷ lệ tiến hóa thành công | STATIC | `fusionPityFails/fusionPityPercent` | Kiểm (U2), dùng ở U6b |
| Chính sách nước boss | KNOWN (3/3) | 13 khoảng B17, max-Sword | Chưa đủ kết luận chung (U9) |
| PASS 2/3, lượt đầu | KNOWN | `game_owned_idle.py`, `pass_evidence` | Giữ nguyên |
| Lõi chung có G4 | GAP | `reasoning_common_problem.PROFILES` | Thêm ở U4; bench U1 dùng schema G4 riêng, không alias |
| Đề xuất EVOLVE/CAST/giữ skill tới host | GAP | `apply_common_action`, `galaxy_strategy_allows` | U6a |
| Worker suy luận trong bản EXE | GAP | `load_common_authority` chặn package | U1 đã đo 1 host, đề xuất envelope E1–E4; admission ở U8 |
| Worker suy luận cho Coop | GAP | `UI_REASONING_TEAM_MODEL_PENDING` | U13 |
| Mốc combo G4 9–13, cộng x1–x7 | USER | `galaxy_shadow_sword.py` | — |
| Hình ấn Mega Icarus/T-Rex | KNOWN (tĩnh B15) | `mega_icarus.py` | — |
| Pha skill Galaxy G1/G3 | KNOWN (B15 native) | `galaxy_skill_phase.py` | — |
| Bench cùng bàn + corpus đóng băng | KNOWN | `tools/reasoning_u1_bench.py`, [artifacts U1](artifacts/u1_20261124/) | Portable 192 + local 255 case; digest `f35e6991…` làm mốc parity U4 |
| Ngân sách đường worker R | KNOWN (1 host) | U1 §7: chờ ≈ 30,5 + 1,93 × compute; p99 566 ms trên budget 4000 ms | Máy thứ hai GAP |
| Lõi chung trên bàn Galaxy | GAP | U1 §6.2: vi phạm K6 (Nộ ≥ 100) ở 6/59 bàn; thu ít Mana/Nộ cần ở 26/40 nước đổi | Phải xử lý trước U10 |
| Suy luận Mega theo K6/K7 | GAP | U1: ăn Kiếm khi Nộ ≥ 100 ở Icarus 14/88, T-Rex 2/10; chấm điểm bảo vệ ở mọi mức máu | Sửa ở U4/U5, nghiệm thu U11 |
| Lookahead lõi chung cho Mega `skill_cost_ready` | GAP | U1 §6.5: 122/122 `FUTURE_INCOMPLETE`, one-step ≡ full | U5 |
| Read span > 100 ms làm bỏ kết quả R | KNOWN tỷ lệ, nguyên nhân UNKNOWN | Icarus 27/115, T-Rex 13/23, Demon 0/240 | Giữ gate; điều tra ở U2/U8 |
| Nhánh R không có reaction delay/jitter input | KNOWN (code) | `win32_input.py` (`reasoned`) | Hỏi ở D-U1; rà ở U8 |
| Quyết định Demon tái lập ở source hiện tại | KNOWN | U1 §6.4: 130/130 từ 20/11; 15/101 lệch ở 18–19/11 | Giữ checkpoint Demon |
