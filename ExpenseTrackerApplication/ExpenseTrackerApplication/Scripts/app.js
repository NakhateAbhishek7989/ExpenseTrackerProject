var explimitinput = localStorage.getItem("explimitinput");
if (explimitinput != null)
{
    explimitinput = JSON.parse(explimitinput);
    var showTotExplimit = document.querySelector("#showTotExplimit");
    showTotExplimit.innerHTML = explimitinput;

}

var expSum = 0;
var expAmt = document.querySelectorAll("#amount");
if (expAmt)
{
    for (var i = 0; i < expAmt.length; i++)
    {
        expSum = expSum + Number(expAmt[i].textContent);
    }

    var totExp = document.querySelector("#showTotExp");
    totExp.innerHTML = expSum;

}

if (Number(explimitinput) < expSum)
{
    totExp.innerHTML = expSum + "*Limit Cross";
}

var showRemExp = document.querySelector("#showRemExp");
if (showRemExp) {
    expRemaining = Number(explimitinput) - expSum;
    showRemExp.innerHTML = expRemaining;
}


