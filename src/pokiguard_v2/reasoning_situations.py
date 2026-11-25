"""Situation labels (plan Appendix B, D-U1) with Vietnamese reasons; evidence or UNKNOWN.

Descriptive only: labels never select an action, fit damage or replace BASIC.
Inputs are the immutable problem facts and, optionally, existing move evaluations.
"""

SCHEMA = 'pokiguard.reasoning_situations.v1'
RAGE_STYLES = ('galaxy', 'mega_icarus_spam_skill')
MODEL_REQUIRED = {
    'S01': 'Kết liễu chắc cần mô hình sát thương; chưa có nên không kích hoạt',
    'S02': 'Phòng thủ theo sát thương boss cần mô hình sát thương',
    'S03': 'Hút đổi khả năng ra skill của boss cần ngưỡng skill boss',
    'S04': 'Hút không đổi khả năng skill cần ngưỡng skill boss',
    'S06': 'Vùng hồi máu của boss chưa có dữ liệu ngưỡng',
    'S08': 'Burst sau skill cần mô hình sát thương boss',
    'S11': 'Nước Hút của boss cần phép chiếu phản hồi boss',
    'S13': 'Hazard mở cột sâu cần mô hình refill',
    'S14': 'Setup lượt sau cần lookahead hoàn tất',
}


def _label(code, status, reason, **evidence):
    return dict(code=code, status=status, reason_vi=reason, evidence=evidence)


def _number(value):
    return value if type(value) is int else None


def situations(play_style, facts, evaluations=None):
    facts = facts if type(facts) is dict else {}
    own = facts.get('self') if type(facts.get('self')) is dict else {}
    boss = facts.get('opponent') if type(facts.get('opponent')) is dict else {}
    labels = [_label(code, 'UNKNOWN', reason) for code, reason in MODEL_REQUIRED.items()]
    labels.append(_label('S05', 'UNKNOWN', 'Thiếu ngưỡng skill, lượng tự bơm và lượng Hút của boss; không suy đoán'))
    need = facts.get('resource_requirements') if type(facts.get('resource_requirements')) is dict else {}
    have = dict(mana=_number(own.get('mana')), rage=_number(own.get('rage')))
    if not need or any(have.get(k) is None for k in need):
        labels.append(_label('S07', 'UNKNOWN', 'Chưa biết cost skill hoặc tài nguyên hiện tại', requirements=need))
    else:
        ready = all(have[k] >= v for k, v in need.items())
        labels.append(_label('S07', 'ACTIVE' if ready else 'INACTIVE',
            'Skill đủ tài nguyên: so bắn ngay với giữ' if ready else 'Skill chưa đủ tài nguyên',
            requirements=need, current=have))
    evolution = facts.get('evolution') if type(facts.get('evolution')) is dict else {}
    if evolution.get('pending') is True:
        labels.append(_label('S09', 'ACTIVE', 'Đang chờ tiến hóa: chọn tiến hóa ngay hay giữ Mana cần D-U6',
            mana_cost=evolution.get('mana_cost')))
    full = [k for k, cap in (('mana', 'max_mana'), ('rage', 'max_rage'))
            if _number(own.get(k)) is not None and _number(own.get(cap)) and own[k] >= own[cap]]
    if full:
        labels.append(_label('S10', 'ACTIVE', 'Tài nguyên đã đầy: không ăn chỉ vì tài nguyên đó', full=full))
    if type(evaluations) in (list, tuple) and evaluations:
        left = [getattr(getattr(m, 'sword_risk', None), 'opponent_sword_reply_effective_max', None) for m in evaluations]
        if all(type(v) is int for v in left):
            status = 'ACTIVE' if min(left) > 0 else 'INACTIVE'
            labels.append(_label('S12', status, 'Mọi nước đều chừa Kiếm: chừa ít nhất, vẫn đi nước, không dừng'
                if status == 'ACTIVE' else 'Có nước không chừa Kiếm đã biết cho boss', minimum_left=min(left)))
    shield = _number(boss.get('shield'))
    if shield is None:
        labels.append(_label('S20', 'UNKNOWN', 'Chưa biết Khiên của boss'))
    elif shield > 0:
        labels.append(_label('S20', 'ACTIVE', 'Boss còn Khiên: Hút không lấy được tài nguyên trừ khi boss đã bị '
            'đánh trước trong cùng nước (quan sát U2)', boss_shield=shield))
    hp, max_hp = _number(boss.get('hp')), _number(boss.get('max_hp'))
    if hp is not None and max_hp:
        if hp / max_hp <= .30:
            labels.append(_label('S21', 'ACTIVE', 'Boss máu thấp: giữ finisher BASIC, Suy luận chỉ so sánh',
                boss_hp_ratio=round(hp / max_hp, 4)))
    rage = _number(own.get('rage'))
    if play_style in RAGE_STYLES and rage is not None and rage >= 100:
        labels.append(_label('K6', 'ACTIVE', 'Nộ từ 100: ăn Kiếm sẽ trừ 100 Nộ cho đòn đánh, không ăn Kiếm '
            'trừ khi Nộ đầy 250 và bất lợi (D-U1)', rage=rage, max_rage=_number(own.get('max_rage'))))
    style = {'galaxy_shadow_sword': ('S16', 'G4: mốc combo, bảo vệ và route tiến hóa'),
             'galaxy': ('S17', 'Galaxy: đi theo pha runtime'),
             'mega_icarus_spam_skill': ('S18', 'Mega: ấn so với bảo vệ/hồi máu'),
             'bu_win': ('S22', 'Bú win: mục tiêu đội, không tự sống một mình')}.get(play_style)
    if style:
        labels.append(_label(style[0], 'ACTIVE', style[1]))
    return tuple(sorted(labels, key=lambda x: x['code']))
