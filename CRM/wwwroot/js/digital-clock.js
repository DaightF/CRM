// digital-clock.js

function updateClock() {
    var now = new Date();
    var dname = now.getDay(),
        mo = now.getMonth(),
        dnum = now.getDate(),
        yr = now.getFullYear(),
        hou = now.getHours(),
        min = now.getMinutes(),
        sec = now.getSeconds(),
        pe = "AM";

    if (hou >= 12) pe = "PM";
    if (hou == 0) hou = 12;
    if (hou > 12) hou -= 12;

    Number.prototype.pad = function (digits) {
        var n = this.toString();
        while (n.length < digits) n = "0" + n;
        return n;
    }

    var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    var week = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    var ids = ["dayname", "month", "daynum", "year", "hour", "minutes", "seconds", "period"];
    var values = [week[dname], months[mo], dnum.pad(2), yr, hou.pad(2), min.pad(2), sec.pad(2), pe];
    for (var i = 0; i < ids.length; i++)
        document.getElementById(ids[i]).textContent = values[i];
}

function initClock() {
    updateClock();
    setInterval(updateClock, 1000);
}

document.addEventListener("DOMContentLoaded", initClock);
