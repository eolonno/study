let table = document.createElement("table");
let tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "Свойство";
tr.appendChild(document.createElement("td")).innerHTML = "Значение";
 
tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "userAgent";
tr.appendChild(document.createElement("td")).innerHTML = navigator.userAgent;

tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "appVersion";
tr.appendChild(document.createElement("td")).innerHTML = navigator.appVersion;

tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "appCodeName";
tr.appendChild(document.createElement("td")).innerHTML = navigator.appCodeName;

tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "platform";
tr.appendChild(document.createElement("td")).innerHTML = navigator.platform;

tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "javaEnabled()";
tr.appendChild(document.createElement("td")).innerHTML = navigator.javaEnabled();

tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "height";
tr.appendChild(document.createElement("td")).innerHTML = screen.height;

tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "width";
tr.appendChild(document.createElement("td")).innerHTML = screen.width;

tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "colorDepth";
tr.appendChild(document.createElement("td")).innerHTML = screen.colorDepth;

tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "length";
tr.appendChild(document.createElement("td")).innerHTML = history.length;

tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "href";
tr.appendChild(document.createElement("td")).innerHTML = location.href;

tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "pathnam";
tr.appendChild(document.createElement("td")).innerHTML = location.pathnam;

tr = table.appendChild(document.createElement("tr"));
tr.appendChild(document.createElement("td")).innerHTML = "host";
tr.appendChild(document.createElement("td")).innerHTML = location.host;

document.body.appendChild(table);
 