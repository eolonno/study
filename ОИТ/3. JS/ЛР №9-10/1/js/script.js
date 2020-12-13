let flag = false;
function drag() {
    let obj = event.target;
    onmousemove = function() {
        if (flag) {
            obj.style.top = event.clientY - (obj.style.height / 2) + "px";
            obj.style.left = event.clientX - (obj.style.width / 2) + "px";
        }
    }
    
}
onclick = function(){
	flag = !flag;
}