"use strict"
const BASE_URL = "https://localhost:44302/api"

let focusId = null;

document.getElementById("fromAmountId").onfocus = function() {
    focusId = "fromAmountId"
}

document.getElementById("toAmountId").onfocus = function() {
    focusId = "toAmountId"
}

document.getElementById("btn-exchange").onclick = exchange;

function getCurrency(from, amount, to){
    return fetch(`${BASE_URL}/Exchange/${from}/${amount}/${to}`, {method: "POST"}).then(res => res.text())
}

function exchange(){
    let resultElemId;

    if(focusId == null)
        return;

    let fromCurrency = null;
    let toCurrency = null;

    let focusEl = document.getElementById(focusId);

    let amount = focusEl.value;
    
    if(amount === "") {
        alert("idi nax")
        return;
    }

    if(focusId === "fromAmountId") {
        fromCurrency = document.getElementById("fromCurrencyId").value
        toCurrency = document.getElementById("toCurrencyId").value
        resultElemId = "toAmountId";
    }
    else {
        fromCurrency = document.getElementById("toCurrencyId").value
        toCurrency = document.getElementById("fromCurrencyId").value
        resultElemId = "fromAmountId"
    }

    let result = document.getElementById(resultElemId);
    getCurrency(fromCurrency, amount, toCurrency).then(res => result.value = res)
}