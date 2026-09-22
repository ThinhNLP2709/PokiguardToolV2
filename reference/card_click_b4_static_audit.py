"""Export read-only b4 card-click/target transport evidence."""
import audition_b4_static_audit as audit


if __name__ == "__main__":
    audit.SELECT = {
        "CardUI": {"Start", "_Start_b__207_0", "OnMega1ToggleChanged",
                   "OnMega2ToggleChanged", "SendSkillHintSafe", "SendSkillHintNow"},
        "CardUIPVP": {"Start", "_Start_b__176_0"},
        "CardPhotonSync": {"RequestUseCard"},
        "CardPhotonSyncPVP": {"RequestUseCard"},
        "CardDisabledClickHint": {"OnPointerDown", "OnPointerClick"},
        "MatchService": {"SendCardUse"},
        "WsMatchClient": {"SendCardUse", "SendSkillHint"},
        "ChatService": {"SendMatchCardUse", "SendMatchMove", "SendMatchSkillHint"},
    }
    audit.main(prefix="card_click_b4",
               title="Card click / board coordinates, 1.7.4-b4 static evidence",
               include_qte_coroutines=False)
