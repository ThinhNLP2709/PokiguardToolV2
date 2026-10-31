"""Explicit OFFLINE fault targets. No production module imports this file."""
import json
import os
import time


def retain(wire, cancel):
    return dict(schema="pokiguard.reasoning.reply.v2", job_id=wire["job_id"],
        generation=wire["generation"], binding=wire["binding"], disposition="RETAIN_BASELINE",
        reason="OFFLINE_CONTROL", proposal=None, compute_ns=1, input_authority=False,
        r2_promotion=False, summary={})


def cooperative(wire, cancel):
    cancel.wait(10)
    return retain(wire, cancel)


def hang(wire, cancel):
    time.sleep(60)
    return retain(wire, cancel)


def crash(wire, cancel):
    os._exit(17)


def corrupt(wire, cancel):
    return b"{BROKEN"


def oversize(wire, cancel):
    return b"x" * (32768 + 1)


def nonfinite(wire, cancel):
    reply = retain(wire, cancel)
    reply["compute_ns"] = float("nan")
    return json.dumps(reply).encode()


def mismatch(wire, cancel):
    reply = retain(wire, cancel)
    reply["binding"] = dict(reply["binding"], config_hash="0" * 64)
    return reply


def raises(wire, cancel):
    raise RuntimeError("OFFLINE injected planner exception")


def log_denied(connection, directory, stem, limits):
    connection.send_bytes(b"READY")
    connection.recv_bytes()
    connection.send_bytes(b"PermissionError:OFFLINE injected denied write")
    connection.close()


def log_disk_full(connection, directory, stem, limits):
    connection.send_bytes(b"READY")
    connection.recv_bytes()
    connection.send_bytes(b"OSError:OFFLINE injected ENOSPC")
    connection.close()


def log_hang(connection, directory, stem, limits):
    connection.send_bytes(b"READY")
    connection.recv_bytes()
    time.sleep(60)


def log_crash(connection, directory, stem, limits):
    connection.send_bytes(b"READY")
    connection.recv_bytes()
    os._exit(19)
