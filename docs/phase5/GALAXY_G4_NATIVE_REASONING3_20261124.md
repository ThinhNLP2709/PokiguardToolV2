# G4 — chốt ba trận Suy luận trên Argilpus ngày 24/11/2026

## Kết quả

Run `73788d6ceb2a49eb8a228b25016a1fa8`, G4 Combo (Shadow Sword), Galaxy
chính, không tiến hóa, Solo Argilpus lv170. Source giữ nguyên
`ace28cad14498ca885aa04cbd0b52967225eb897b510bfcab9c44ed7ed9ca8a7`.

**3/3 WIN**, nhận thưởng và về BOSS_LOBBY, `FARM_TARGET_COMPLETED`.
Không technical abort/recovery, safe stop, timeout ACK, sai lượt, input
trùng/misclick/partial, tiến hóa, PASS hoặc bấm thẻ skill. Người dùng tự
Start rồi đóng tool sau bài; không dùng Computer Use hoặc mở thêm trận.

| Match | SWAP gửi | ACK thường | Kết trận trước ACK | Combo cuối đã biết trước input |
|---|---:|---:|---:|---|
| `M_7fd85627` | 1 | 0 | 1 | 12 viên / 12 đơn vị, mốc 12 |
| `M_93122d3e` | 6 | 5 | 1 | 20 viên / 21 đơn vị, mốc 13 |
| `M_e648e16c` | 2 | 1 | 1 | 9 viên / 9 đơn vị, mốc 9 |

Giữ đúng **9 gửi / 6 ACK / 3 terminal không ACK thường**, không đổi thành
9/9 ACK. Ba action cuối có `ACTION_ABORTED_STATE_CHANGED` với lý do
`COMBAT_LIFECYCLE_ENDED`, đồng thời có `MATCH_GAME_OVER`, winner
`__PLAYERS__` và boss HP=0. Trong cửa sổ sau mỗi action đều lưu được một
response local có đúng match/actor và raw SWAP khớp phép đổi tọa độ native
sang screen đã dùng trong normalizer. Đây là đối chiếu hồi cứu bổ sung;
không sửa binding raw UNKNOWN hoặc bộ đếm ACK của controller.

Ba event `postmatch_observation_timeout` là chờ quan sát sau combat một
giây; trong cohort này farm vẫn nhận thưởng, vào trận sau và hoàn thành.
Chúng không phải farm safe stop. Không khái quát mọi timeout thành vô hại.

## Quyết định và phép đếm combo

Ba controller ghi `galaxyReasoningEnabled=true`; session là
`G4_COMBO_BOARD_TACTICS`, không phải common worker. Cả chín source identity
ghép được policy trước input với action đã gửi. Replay chính hàm production
`plan_g4(reasoning=True)` trên board/stat đã ghi khớp **9/9 hành động và
9/9 toàn bộ facts**, không dùng refill thực hoặc chỉnh weights.

Chín quyết định đều chọn mức Kiếm phản đòn đã biết thấp nhất là 0. Điều
này không chứng nhận an toàn sau refill hoặc loại trừ boss dùng skill.
Có nhánh TRIGGER, BEST_AVAILABLE, PROTECT và HEALING_COMBO; không gặp
setup budget exhausted. Không có nhãn tối ưu hoặc chứng nhận sống sót.

Phép đếm dùng `total.total_effective`, tách khỏi `total.total_cells` và
gồm cascade đã biết. Ba nước có số hiệu dụng khác số viên: 6→7, 3→4 và
20→21. Board thu được có x1/x2/x3; **chưa có mẫu x7 runtime**. Đây là kiểm
tính toán trên board native đã ghi, chưa là phép đo riêng chứng minh server
đếm từng multiplier trong nội tại: DESTROY vẫn không gắn tag/multiplier
đầy đủ và refill có thể tạo thêm combo.

## BASIC và Suy luận trên cùng bàn

Baseline là chính `plan_g4(reasoning=False)` trên cùng trạng thái trước
input, cùng route/passive/board/stat. Đây là **replay nhánh production**,
không phải native BASIC proposal, không chạy lại toàn bộ input gate.

**Hai nước đổi, bảy nước giữ.** Hai nước đổi đều ở trận `M_93122d3e`,
đã có ACK thường:

- Lượt 7: BASIC lấy 4 Mana + 3 Nộ; R lấy 3 Nộ + 4 Hút. Cả hai có 7 đơn
  vị, chưa tới mốc nội tại, Kiếm phản đòn đã biết đều 0. Hút là cơ hội bảo
  vệ tài nguyên; không tự coi nó ngăn được skill hoặc hút cả Mana lẫn Nộ.
- Lượt 9: BASIC lấy 4 Mana + 3 Nộ; R lấy 4 Máu, combo 7→4. Cả hai chưa
  kích hoạt nội tại và không chừa Kiếm đã biết. Đây là đánh đổi hồi Máu
  với tích tài nguyên dưới pressure proxy, không phải bằng chứng R tối ưu.

Ba nước cuối giống BASIC về hành động. Vì vậy không quy cả ba WIN cho
khả năng chọn nước khác của R, không dùng ít lượt hơn làm thước đo.

## Hiệu ứng đã ghi và điều chưa thể suy

Lưu đủ chín response local; raw STAT_CHANGE có 21 phép số học khớp và
hai lần pattern chạm trần Nộ. Bốn endpoint local khớp mỗi response, tổng
36 kiểm. Có sáu BOSS_HP operation: ba phép trừ khớp, ba pattern chạm sàn
0; không đồng nhất delta damage báo với lượng HP mất thực.

Các response cuối chứa thêm BOSS_HP operation không được ghi thành bước
DAMAGE tương ứng trong `combatSteps`:

| Match | Delta BOSS_HP bổ sung được báo | HP boss sau | HEAL bổ sung trong response |
|---|---:|---:|---:|
| `M_7fd85627` | -2.265.121 | 0 | 45.302 |
| `M_93122d3e` | -3.208.878 | 0 | 55.366, lên max HP |
| `M_e648e16c` | -894.921 | 0 | Không có bước HEAL bổ sung |

Thứ tự và mốc combo tương thích nội tại G4; operation không có skill ID/
nhãn nguồn riêng nên giữ attribution UNKNOWN. Không chỉ cộng các bước
DAMAGE thường (50.416/151.248) rồi kết luận nội tại không gây damage.
Không gán toàn bộ HEAL thành lifesteal nội tại, fit công thức damage,
khẳng định crit hoặc suy thời hạn Kiên Định từ những mẫu này.

G4 được người dùng xác nhận; response cùng actor ghi petId=2859, level14.
Đó không phải bộ phân loại pet G4 tự động. Không dựng CardUI/cost cast
cho nội tại hoặc dùng receipt active skill để chứa một SWAP.

## Bàn giao và kiểm dữ liệu

`galaxy_shadow_sword` **chưa nằm trong PROFILES của CommonProblem hiện
hành**. Giữ fixture G4 có schema riêng, không giả G4 thành `galaxy` hoặc
`simple`, không sửa schema/runtime trong đợt thu này. Agent lõi nhận dữ
liệu để bổ sung adapter/coverage sau; bài này không nghiệm thu common rollout.

- [Closure](artifacts/g4_reasoning3_20261124_230608/review/closure.json),
  [chín pre-state, cặp quyết định và response](artifacts/g4_reasoning3_20261124_230608/review/evidence_pack.json).
- [Verification](artifacts/g4_reasoning3_20261124_230608/review/verification.json):
  10 file raw kiểm hash, chín replay/facts khớp, 36 endpoint khớp, source
  không đổi; không tạo training/optimal label hoặc fit damage model.
- [Fixture G4 riêng](../../tests/fixtures/g4_native_reasoning3_20261124/cases.json).
- [Kế hoạch thu](mega_galaxy_handoff_20261124/collection_plan.json).

Đủ ba trận G4 theo yêu cầu. G1/G3/G4 mỗi nhóm ba trận đã hoàn tất; G2 giữ
một trận R đã chốt. Không cần thêm trận cùng boss để tăng bộ đếm. Chưa
kiểm nhánh tiến hóa, boss đủ mạnh sống sau trigger hoặc toàn bộ multiplier.
