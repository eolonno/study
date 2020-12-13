let newWin = window.open("", "first window", "width=500,height=500");
newWin.document.write("Hello! I'm " + newWin.name);

let newWin2 = open("about:blank", "second window", "width=500,height=500");
newWin2.document.write("It's second page, namely " + newWin2.name);
