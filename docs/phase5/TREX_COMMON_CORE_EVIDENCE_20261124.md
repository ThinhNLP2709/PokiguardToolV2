# T-Rex — xử lý offline log cũ cho lõi suy luận chung

24/11/2026, Asia/Saigon. Đã xử lý T-Rex theo cùng định dạng CommonProblem
của bộ Icarus. Chỉ thêm exporter/fixture/tests; không sửa core, cách đánh,
weights, registry hình ấn, luật PASS, reader hoặc input. Không live, build,
đổi version, commit/push hoặc sửa plan/tài liệu của agent lõi.

## Kết quả

| Hạng mục | Kết quả |
|---|---|
| Log cast đã audit | 112 lần thành công, 7 match thuộc 2 run lịch sử |
| Đầu vào CommonProblem dùng được | 110 |
| Case bị loại khỏi replay | 2 có pre-policy state mâu thuẫn trong cùng identity |
| Negative reference zero input | 4 INVALIDATED, không tính thành skill đã bấm |
| Endpoint Mana/Nộ nhất quán trong nhóm 110 | 103; đây là quan sát net, không phải cost/refund |
| Skill effect server đủ nguồn | 0; không có ordered damage/heal/resource operations |
| Replay core hiện tại | 108 giữ skill; 2 đề xuất swap |
| Tự hồi máu Icarus được cộng cho T-Rex | 0 |
| Kiểm thử | 18 test T-Rex; tổng focused CI 518 PASS |

121 file input đã được pin và xác minh SHA; chạy lại cho cùng evidence pack.
Dữ liệu đến từ log tháng 11 ngày 8 và 11, nằm trong Downloads/log. Bản
inventory ngày 23/11 được giữ nguyên, không ghi lại raw hoặc xóa bản gốc.

Các source/build hash **của game/tool lịch sử** không có đủ nguồn nên giữ
UNKNOWN. Không lấy hash B17/source hiện tại gắn vào các trận cũ, không pool
chúng vào cohort Icarus No.11 lv185 để fit một công thức chung.

## Những gì dữ liệu chứng minh và chưa chứng minh

Tất cả case giữ được đều có thẻ MEGA_TREX_CLICK_ONLY, chi phí đọc được
200 Mana/200 Nộ, skill source EVOLUTION_TARGET; route pet thường → Mega.
Đây là cost/route quan sát trong cohort, không hard-code cho mọi T-Rex hoặc
nghiệm thu route Mega chính → pet thường.

Ấn T-Rex dùng đúng registry riêng 30 ô. T-Rex và Icarus có 22 ô khác nhau
khi lấy hiệu đối xứng. Exporter đếm cả số ô thật và tổng multiplier tại
bàn trước nước, không áp mask Icarus cho T-Rex. Tuy nhiên, log cũ thiếu
DESTROY có nguồn đầy đủ để đối chiếu hiệu ứng; **không gọi 110 đếm ấn
conditional là 110 native witness của hình phá thực**.

Mỗi đầu vào ghép bằng controller source identity, match/session/turn/seq/
board hash, actual click và capability trước click. Các pre-policy row
cùng source phải đồng ý về board, stats và điều kiện skill. Hai case
`M_91294d21`/81 và `M_3907c494`/127 không đồng ý nên bị loại; không chọn
row mới nhất rồi bỏ qua mâu thuẫn. Không quy đây thành lỗi game hoặc lỗi
đánh từ việc audit offline thấy thiếu bằng chứng.

Đây là **reconstruction từ policy row lịch sử**, không phải fresh
skillActionContext collector mới. Hash raw tag của board không được tái
dựng từ gem name đã rút gọn; chỉ giữ hash identity đã ghi, semantic board
và SHA file nguồn. Không đoán lại tag hoặc ownership pointer.

## Kiểm T-Rex có bị gán nhầm hồi máu Icarus không

Không thấy core hiện tại gán cờ hồi máu riêng của Icarus cho T-Rex trong
phạm vi này. Effect T-Rex dùng `self_heal_present=false` để **không cộng
credit**, kèm `self_heal_knowledge=UNKNOWN_NOT_CREDITED`. Điều đó không
chứng minh T-Rex không thể hồi HP từ viên Máu, hiệu ứng khác hoặc route
tiến hóa; chỉ là không có chứng cứ để cộng sẵn một lần hồi skill riêng.

LIFESTEAL/FUSION_LIFESTEAL có nhãn rõ trong bộ Icarus mới không được chuyển
sang T-Rex. Log T-Rex có post HP/resource nhưng không có từng bước để tách
heal, Hút, khiên, boss damage hoặc buff; không fit từ chênh lệch HP giữa
các lượt và không giữ nhãn “skill cứu sống” chỉ vì trận thắng.

Các case skill này có HP thấp nhất khoảng **33,43%**; chưa có native
witness dưới 30%. Sensitivity giả lập HP thấp kiểm được rằng cơ hội hồi
intrinsic của T-Rex vẫn 0, còn thu viên Máu vẫn là lợi ích resource theo
model cũ. Không coi sensitivity là một trận cứu nguy thực.

Log cũ còn thiếu trường Tự bảo vệ. Trong bộ reconstruction, setting giữ
null với nghĩa **không biết lựa chọn lịch sử**, không điền thành “Không”,
30% hoặc mặc định hiện tại. Không migrate setting hoặc thay policy từ
thiếu hụt này.

## Hai case core đề xuất đổi nước

Đối chiếu trên cùng snapshot, không dùng kết quả tương lai:

| Match/lượt | Skill incumbent | Swap core đề xuất | Giới hạn |
|---|---|---|---|
| `M_896e1cb4`/73 | 2 Kiếm hiệu dụng trong ấn; tốn 200 Mana/200 Nộ | Thu 7 Kiếm hiệu dụng; known Sword reply 5 → 0, không tốn cost skill | Đổi lại mất nhiều Mana/Nộ/Máu/Khiên/Hút của vùng skill; không biết refill/damage |
| `M_a2158932`/95 | 12 Kiếm hiệu dụng trong ấn; tốn 200/200 | Thu 6 Kiếm; known Sword reply 5 → 0, ít ô refill chưa biết hơn | Ít Kiếm/tài nguyên lấy ngay hơn; không biết bên nào gây damage/giữ HP tốt hơn |

Cả hai có lợi ích và chi phí riêng; classifier vẫn INSUFFICIENT_DATA do
khác horizon và thiếu hiệu ứng. Không gán chúng là “R thắng BASIC”, không
tuning weights để bắt core chọn theo ý muốn. 108 giữ skill cũng không
được dùng làm nhãn 108 nước tối ưu.

## Bàn giao cho agent lõi chung

- [Exporter offline](../../tools/prepare_trex_core_evidence.py) tái dùng
  solver, CommonProblem/EffectChoice và planner hiện có.
- [Evidence pack 110 case](artifacts/trex_core_evidence_20261124/evidence_pack.json)
  có CommonProblem trước action, conditional seal counts, replay và
  comparison; `observation` nằm riêng, ordered server effects luôn null.
- [Fixture rút gọn](../../tests/fixtures/trex_core_20261124/cases.json) có
  mẫu cả 7 match, 2 pre-state conflict và 2 ca đổi swap. Đã bỏ plaintext
  username trong source; không tạo lại action authority từ fixture.
- [Verification và isolation](artifacts/trex_core_evidence_20261124/verification.json),
  [script tái hiện](artifacts/trex_core_evidence_20261124/verify.py),
  [CI transcript](artifacts/trex_core_evidence_20261124/ci_final.log).

Đã kiểm: thay HP/resource/nhãn thắng sau skill không đổi CommonProblem
hoặc quyết định replay; sai family/cost/card/session/route, thiếu một
nguồn lực, board sai domain và zero input không được sửa bằng future data.

**Mốc offline T-Rex này đã xong.** Lõi chung có thể dùng bộ này cho
U1/U5/U6 và kiểm phân biệt hai Mega. Không cần lặp trận để tăng số lượng.
Nếu cần hiệu chỉnh damage/heal T-Rex thật thì cần bài riêng trên collector
mới có hypothesis/coverage cụ thể; các log hiện tại không khôi phục được
những effect chưa từng được giữ. Không mở cap hoặc test live trong mốc này.

```powershell
$env:PYTHONPATH = 'src'
python -B -m unittest tests.test_trex_core_evidence -q
python -B docs/phase5/artifacts/trex_core_evidence_20261124/verify.py
```
## Bổ sung native hiện hành

[Một trận Archon → Mega T-Rex Suy luận ngày 24/11](MEGA_TREX_REASONING1_NATIVE_20261124.md)
đã có fresh context, ordered skill effects và 10 cặp SWAP native cùng bàn.
Đây là cohort mới, không sửa source UNKNOWN hoặc nâng binding của 112 cast
lịch sử trong báo cáo dưới đây. Terminal skill hiện hành vẫn UNBOUND.
