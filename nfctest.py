import binascii
import json
import nfc

def nfctagtodict(nfctag):

    dic = {}

    if isinstance(nfctag, nfc.tag.Tag):
        dic['identifier'] = binascii.hexlify(nfctag.identifier).upper()
        dic['is_authenticated'] = nfctag.is_authenticated
        dic['is_present'] = nfctag.is_present
        dic['product'] = nfctag.product
        dic['type'] = nfctag.type

    if isinstance(nfctag, nfc.tag.tt3.Type3Tag):
        dic['idm'] = binascii.hexlify(nfctag.idm).upper()
        dic['pmm'] = binascii.hexlify(nfctag.pmm).upper()
        dic['sys'] = nfctag.sys

    if isinstance(nfctag, nfc.tag.tt3_sony.FelicaStandard):
        pass

    if isinstance(nfctag, nfc.tag.tt3_sony.FelicaMobile):
        pass

    if isinstance(nfctag, nfc.tag.tt3_sony.FelicaLite):
        pass

    if isinstance(nfctag, nfc.tag.tt3_sony.FelicaLiteS):
        pass

    if isinstance(nfctag, nfc.tag.tt3_sony.FelicaPlug):
        pass

    return dic


def connected(tag):
    print(json.dumps(nfctagtodict(tag)))


clf = nfc.ContactlessFrontend('usb')
if clf:
    clf.connect(rdwr={
        'targets': ['212F', '424F'],
        'on-connect': connected,
    })

    clf.close()