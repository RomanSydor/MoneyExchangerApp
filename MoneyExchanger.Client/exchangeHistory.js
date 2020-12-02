"use strict"
const BASE_URL = "https://localhost:44302/api"

document.body.onload = getExchangeHistory;

function getExchangeHistory() {
    $.ajax({
        url: `${BASE_URL}/Exchange`,
        method: 'GET',
        success: function (data) {
            $('#data').empty();
            $.each(data, function (index, value) {
                var row = $('<tr><td>' + value.fromAmount + '</td><td>'
                    + value.fromCurrency + '</td><td>'
                    + value.toAmount + '</td><td>'
                    + value.toCurrency + '</td><td>' 
                    + value.date + '</td>' +
                    '</tr > ');
                $('#data').append(row);
            });
        }
    });
}