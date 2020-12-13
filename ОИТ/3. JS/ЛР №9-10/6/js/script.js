document.getElementById('nav').onmouseover = function(event) {
    //отслеживает нахождение мыши внутри блока
    let target = event.target;
    //отслеживаем клик
    if (target.className == 'menu-item') {
        let s = target.getElementsByClassName('submenu');
        closeMenu();
        s[0].style.display = 'block';
        //массив, содержащий ложное меню
    }
}
document.onmouseover = function(event) {
    let target = event.target;
    if (target.className != 'menu-item' && target.className != 'submenu') {
        closeMenu();
    }
}

function closeMenu() {
    //получение всех элементов подменю в блоке nav, присваивание display: none
    let menu = document.getElementById('nav');
    let subm = document.getElementsByClassName('submenu');
    for (let i = 0; i < subm.length; i++) {
        subm[i].style.display = "none";
    }
}