Discounts = [
     {
         Id : 1000,
         AirlineName: "Elal",
         From: "TLV",
         To: "JFK",
         DiscountStart: "2013-03-18T13:00",
         DiscountEnd: "2013-03-18T13:00",
         AirlineDiscount: 10
    },
    {
        Id: 1001,
        AirlineName: "AIRLines",
        From: "TLV",
        To: "AMS",
        DiscountStart: "2013-03-18T13:00",
        DiscountEnd: "2013-03-18T13:00",
        AirlineDiscount: 20
    }
];

Orders = [
    {
        OrderID: 1000,
        Name: "RonRamal",
        Email: "RonRamal@outlook.com",
        AirlineName: "Elal",
        AirportFrom: "TLV",
        AirportTo: "JFK",
        Departure: "2020-06-10T13:00",
        Arrival: "2020-06-20T13:00",
        Price: 10
    },
    {
        OrderID: 1001,
        Name: "GuyGareba",
        Email: "GuyGareba@outlook.com",
        AirlineName: "RonAir",
        AirportFrom: "AMS",
        AirportTo: "JFK",
        Departure: "2020-06-10T13:00",
        Arrival: "2020-06-20T13:00",
        Price: 20
    }
];

var id = 1001;
function ajaxCall(method, api, data, successCB, errorCB) {
    //$.ajax({
    //    type: method,
    //    url: api,
    //    data: data,
    //    cache: false,
    //    contentType: "application/json",
    //    dataType: "json",
    //    success: successCB,
    //    error: errorCB
    //});

    if (method == "GET" && api == "../api/Discount") {
        successCB(Discounts);
        return;
    }
    if (method == "GET" && api == "../api/Flights") {
        successCB(Orders);
        return;
    }

    else if (method == "PUT" && api == "../api/Discount") {
        let car = JSON.parse(data);
        for (var i = 0; i < Cars.length; i++) {
            if (Cars[i].Id == car.Id) {
                Cars[i] = car;
                
                successCB(Cars);
                return;
            }
        }

        errorCB("did not manage to update the DB");
    }


    else if (method == "POST" && api == "../api/Discount") {
        
        let dicount = JSON.parse(data);
        dicount.Id = getMaxId(Discounts) + 1;
        Discounts.push(dicount);
        successCB(Discounts);
        //errorCB("did not manage to insert the new car into the DB");
    }

    else if (method == "DELETE") {
        splitArr = api.split('/');
        let id = splitArr[splitArr.length - 1];
        temp = [];
        index = 0;
        for (var i = 0; i < Discounts.length; i++) {
            if (parseInt(Discounts[i].Id) != id) {
                temp[index] = Discounts[i];
                index++;
            }
        }
        Discounts = temp;
        successCB(Discounts);
    }


}

function getMaxId(Discounts){
    let max = 0;
    for (var i = 0; i < Discounts.length; i++) {
        if (Discounts[i].Id > max)
            max = Discounts[i].Id;
    }
    return max;
}