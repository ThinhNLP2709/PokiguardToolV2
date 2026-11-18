"""Maintainer GitHub API client. Credentials stay in memory and are never logged."""
from __future__ import annotations
import json
import os
import subprocess
import urllib.request


class GitHubClient:
    def __init__(self, repository: str):
        import re
        if not re.fullmatch(r'[A-Za-z0-9_.-]+/[A-Za-z0-9_.-]+',repository):
            raise ValueError('Invalid repository')
        self.repository=repository
        token=os.environ.get('GH_TOKEN') or os.environ.get('GITHUB_TOKEN')
        if not token:
            result=subprocess.run(['git','credential','fill'],input='protocol=https\nhost=github.com\n\n',
                text=True,capture_output=True,timeout=12,
                env=dict(os.environ,GIT_TERMINAL_PROMPT='0',GCM_INTERACTIVE='Never'))
            values=dict(line.split('=',1) for line in result.stdout.splitlines() if '=' in line)
            token=values.get('password')
        if not token:raise RuntimeError('Sign in to GitHub through Git Credential Manager or gh first.')
        self._token=token

    def request(self, suffix: str, body=None, *, method=None):
        request=urllib.request.Request('https://api.github.com/repos/'+self.repository+'/'+suffix,
            data=None if body is None else json.dumps(body).encode(),method=method,
            headers={'Authorization':'Bearer '+self._token,'Accept':'application/vnd.github+json',
                     'Content-Type':'application/json','User-Agent':'Pokiguard-release-maintainer'})
        with urllib.request.urlopen(request,timeout=30) as response:
            raw=response.read()
            return json.loads(raw) if raw else None
