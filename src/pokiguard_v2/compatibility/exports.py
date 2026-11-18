"""Read Inspector and Il2CppDumper exports as evidence; no game/process access.

Names retain namespaces/nesting. Export-specific backing-field spelling is
normalized, but field ownership, static qualifiers, types and offsets are not.
"""
import json,re
from pathlib import Path

FIELD=re.compile(r'^\s*(?:public|private|internal|protected)\s+(?!const\s)(.+?)\s+([^\s;]+);\s*//\s*(0x[\da-fA-F]+)\s*$')
DECL=re.compile(r'^(?:public|private|internal|protected|abstract|sealed|static|readonly|ref|partial|\s)+\s*(class|struct|enum|interface)\s+(.+?)(?:\s+:.*)?\s+//\s*TypeDefIndex:\s*(\d+)\s*$',re.M)


def field_name(value):return value.replace('<','_').replace('>','_')


def parse_fields(text):
    result={}
    for line in text.splitlines():
        if line.strip().startswith(('// Properties','// Events','// Nested','// Constructors','// Methods')):break
        found=FIELD.fullmatch(line)
        if found:
            name=field_name(found[2])
            if name in result:raise ValueError('duplicate field '+name)
            result[name]=dict(type=found[1],offset=int(found[3],16))
    return result


def inspector_fields(path,*,nested=None):
    text=Path(path).read_text('utf-8-sig')
    if nested:
        match=re.search(r'\b(?:class|struct|enum)\s+'+re.escape(nested)+r'\b[^\r\n]*\n\s*\{',text)
        if match is None:raise ValueError('nested declaration not found: '+nested)
        text=text[match.end():]
    return parse_fields(text)


def dumper_types(directory):
    """Qualified name -> exact image/declaration. Duplicate names are rejected."""
    text=(Path(directory)/'dump.cs').read_text('utf-8-sig')
    images=sorted((int(start),name.removesuffix('.dll')) for name,start in re.findall(r'^// Image \d+: (.+?) - (\d+)$',text,re.M))
    result={}
    for chunk in re.split(r'^// Namespace: ',text,flags=re.M)[1:]:
        namespace,_,body=chunk.partition('\n');namespace=namespace.strip()
        declaration=DECL.search(body)
        if declaration is None:continue
        kind,name,index=declaration.groups();index=int(index)
        full=(namespace+'.' if namespace else '')+name.strip()
        image=next(image for start,image in reversed(images) if start<=index)
        key=(image,full)
        if key in result:raise ValueError('ambiguous exported type '+repr(key))
        content=body[declaration.end():]
        fields_error=None
        try:fields=parse_fields(content)
        except ValueError as exc:fields=None;fields_error=str(exc)
        result[key]=dict(image=image,name=full,index=index,kind=kind,fields=fields,
            fields_error=fields_error,text=content,namespace=namespace)
    return result


def dumper_script(directory):
    data=json.loads((Path(directory)/'script.json').read_text('utf-8-sig'))
    for name in ('ScriptMethod','ScriptMetadata','Addresses'):
        if type(data.get(name)) is not list:raise ValueError('missing Dumper section '+name)
    return data


def unique(rows,name):
    found=[r for r in rows if r.get('Name')==name]
    if len(found)!=1:raise ValueError('expected unique exported symbol '+name+': '+str(len(found)))
    return found[0]


def inspector_type_name(symbol):
    """Decode the simple namespace/nesting part of Inspector's TypeInfo name."""
    aliases={
        'Dictionary<string, object>':'System.Collections.Generic.Dictionary<string, object>',
        'List<PendingAction>':'System.Collections.Generic.List<UnityMainThreadDispatcher.PendingAction>',
        'Queue<PendingAction>':'System.Collections.Generic.Queue<UnityMainThreadDispatcher.PendingAction>',
        'int':'System.Int32','long':'System.Int64','string':'System.String'}
    if symbol['dotNetType'] in aliases:return aliases[symbol['dotNetType']]
    rest=symbol['name'].removeprefix('_ZN8TypeInfo');parts=[]
    while rest and rest[0].isdigit():
        length=re.match(r'\d+',rest)[0];rest=rest[len(length):];n=int(length)
        parts.append(rest[:n]);rest=rest[n:]
    if rest!='E' or not parts:raise ValueError('unsupported Inspector TypeInfo encoding '+symbol['name'])
    return '.'.join(parts).replace('__c__DisplayClass','<>c__DisplayClass')


def normalized_type(value):
    # Exact aliases only; never erase arbitrary namespaces or generic ownership.
    value=re.sub(r'\s+','',value)
    for long,short in (('System.Int32','int'),('System.Int64','long'),('System.String','string'),
        ('System.Object','object'),('System.Boolean','bool'),('System.Single','float'),('System.Double','double')):
        value=re.sub(r'(?<![\w.])'+re.escape(long)+r'(?![\w.])',short,value)
    return value
