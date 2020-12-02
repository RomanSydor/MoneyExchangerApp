"use strict"
const BASE_URL = "https://localhost:44302/api"

let focusId = null;

document.getElementById("fromAmountId").onfocus = function() {
    focusId = "fromAmountId";
}

document.getElementById("toAmountId").onfocus = function() {
    focusId = "toAmountId";
}

document.getElementById("btn-exchange").onclick = exchange;

document.getElementById("bth-swap").onclick = swapCurrencies;

function getCurrency(from, amount, to){
    return fetch(`${BASE_URL}/Exchange/${from}/${amount}/${to}`, {method: "POST"}).then(res => res.text());
}

function exchange(){
    let resultElemId;

    if(focusId == null){
        alert("Input value in the field");
        return;
    }
    
    let fromCurrency = document.getElementById("fromCurrencyId").value;
    let toCurrency = document.getElementById("toCurrencyId").value;
    let fromAmount = document.getElementById("fromAmountId").value;
    let toAmount = document.getElementById("toAmountId").value;

    if(fromAmount !== "" && toAmount === "") {
        resultElemId = "toAmountId";
    }
    else if(fromAmount === "" && toAmount !== ""){
        fromCurrency = document.getElementById("toCurrencyId").value;
        toCurrency = document.getElementById("fromCurrencyId").value;
        fromAmount = toAmount;
        resultElemId = "fromAmountId";
    }
    else if(fromAmount !== "" && toAmount !== ""){
        if(focusId === "fromAmountId"){
            resultElemId = "toAmountId";
        }
        else if(focusId === "toAmountId"){
            fromCurrency = document.getElementById("toCurrencyId").value;
            toCurrency = document.getElementById("fromCurrencyId").value;
            fromAmount = toAmount;
            resultElemId = "fromAmountId";
        }
    }

    let result = document.getElementById(resultElemId);
    getCurrency(fromCurrency, fromAmount, toCurrency).then(res => {
        result.value = res;
        return res}).then(res => document
                    .getElementById("oneCost").textContent = `${fromCurrency} 1 = ${toCurrency} ${(parseFloat(res)/parseFloat(fromAmount)).toFixed(4)}`)
                
}
    
function swapCurrencies(){
    let fromCurrency = document.getElementById("fromCurrencyId").value;
    let toCurrency = document.getElementById("toCurrencyId").value;

    let temp = fromCurrency;
    fromCurrency = toCurrency;
    toCurrency = temp;
    
    document.getElementById("fromCurrencyId").value = fromCurrency;
    document.getElementById("toCurrencyId").value = toCurrency;
    
    return;
}