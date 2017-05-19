
function popitup(url, name, h, w) {
    var newwindow=window.open(url,name,'height=' + h+',width='+w);
    if (window.focus) {newwindow.focus()}
    return false;
}

var localFT = true;

function colorsetting() {
    if (typeof (Storage) !== "undefined") {
        if (Storage.firsttime =="undefined") {
            localStorage.firsttime = true;
            localStorage.bcolor = "#16151b";
            localFT = false;
        } else {
            if (!localFT) {
                if (localStorage.bcolor == "#16151b") {
                    localStorage.bcolor = "#f2c390";
                } else {
                    localStorage.bcolor = "#16151b";
                }
            } else {
                
                localFT = false;
            }
        }

        
        var buttoncolor;
        var backcolor;
        var picker;
        var wordcolor;


    if (localStorage.bcolor == "#16151b") {
        buttoncolor = '#3c3949';
        backcolor = "#16151b";
        picker = "#c0d6e4";
        wordcolor = "white";
        document.body.style.backgroundImage = "none";
            
        } else {
            buttoncolor = '#c0d6e4';
            backcolor = "#f2c390";
            picker = "#16151b";
            wordcolor = "black";
            document.body.style.backgroundImage = "url('elegantblue.jpg')";
            
        }

            document.getElementById('colorpicker').style.backgroundColor = picker;
            document.body.style.backgroundColor = backcolor;
            document.getElementById('compose-button').style.backgroundColor = buttoncolor;
            document.getElementById('inbox-button').style.backgroundColor = buttoncolor;
            document.getElementById('template-button').style.backgroundColor = buttoncolor;
            document.getElementById('info-button').style.backgroundColor = buttoncolor;
            document.getElementById('compose-button').style.color = wordcolor;
            document.getElementById('inbox-button').style.color = wordcolor;
            document.getElementById('template-button').style.color = wordcolor;
            document.getElementById('info-button').style.color = wordcolor;
    } else {
        document.getElementById('colorpicker').remove();
        //alert("Sorry, your browser does not support web storage...");
    }
}


document.getElementById("colorpicker").addEventListener('click', colorsetting);

document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('#compose-button').addEventListener('click', function () {
        //popitup("http://issacemail.com/AppConnection/Compose", "750", "650");
        popitup("http://localhost:54238/AppConnection/Compose", "compose", "700", "750");
        //window.open("http://localhost:54238/AppConnection/Compose",  'height=' + '600' + ',width=' + '500');
    });
    document.querySelector('#inbox-button').addEventListener('click', function () {
        //popitup("http://issacemail.com/AppConnection/Inbox", "650", "750");
        popitup("http://localhost:54238/AppConnection/Inbox","Inbox", "650", "750");
        //window.open("http://issacemail.com/AppConnection/Inbox",  'height=' + '600' + ',width=' + '500');

    });
    document.querySelector('#template-button').addEventListener('click', function () {
        //popitup("http://issacemail.com/TemplateMaker/PersonalTemplateCreater", "650", "750");
        popitup("http://localhost:54238/TemplateMaker/PersonalTemplateCreater","ptemplate", "650", "750");
        //window.open("http://issacemail.com/AppConnection/Inbox",  'height=' + '600' + ',width=' + '500');

    });
    document.querySelector('#info-button').addEventListener('click', function () {
        //popitup("http://issacemail.com/UserInfoes/create", "650", "750");
        popitup("http://localhost:54238/UserInfoes/create", "UserInfo", "650", "750");
        //window.open("http://issacemail.com/AppConnection/Inbox",  'height=' + '600' + ',width=' + '500');

    });
});

colorsetting();
