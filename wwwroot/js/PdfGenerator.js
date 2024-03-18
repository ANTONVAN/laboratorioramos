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
    var ifra = document.createElement('iframe');
    ifra.setAttribute("src", "data:application/pdf;base64," + byteBase64);
    ifra.style.with = "100%";
    ifra.style.height = "680%";
    document.getElementById(iframeID).appendChild(ifra);
}