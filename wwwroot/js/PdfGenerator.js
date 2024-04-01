function DownloadPDF(filename, byteBase64) {
    var oLink = document.createElement('a');
    oLink.download = filename;
    oLink.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(oLink);
    oLink.click();
    document.body.removeChild(oLink);
}

function ViewPDF(iframeID, byteBase64) {
    document.getElementById(iframeID).innerHTML = "";
    var contentType = 'application/pdf';
    var blob = b64toBlob(byteBase64, contentType);
    var blobUrl = URL.createObjectURL(blob);
    var ifra = document.createElement('iframe');
    ifra.setAttribute("src", blobUrl);
    ifra.style.with = "100%";
    ifra.style.height = "680%";
    document.getElementById(iframeID).appendChild(ifra);
}

function b64toBlob(b64Data, contentType, sliceSize) {
    contentType = contentType || '';
    sliceSize = sliceSize || 512;

    var byteCharacters = atob(b64Data);
    var byteArrays = [];

    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        var slice = byteCharacters.slice(offset, offset + sliceSize);

        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        var byteArray = new Uint8Array(byteNumbers);

        byteArrays.push(byteArray);
    }

    var blob = new Blob(byteArrays, { type: contentType });
    return blob;
}