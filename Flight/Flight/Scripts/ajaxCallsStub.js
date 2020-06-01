Discounts = [
     {
         Id : 1000,
         AirlineName: "Elal",
         From: "TLV",
         To: "JFK",
        DiscountStart: "2013-03-18T13:00",
        DiscountEnd: "2013-03-18T13:00",
         AirlineDiscount: 10
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

    if (method == "GET" && api == "../api/Discounts") {
        successCB(Discounts);
        return;
    }

    else if (method == "PUT" && api == "../api/Discounts") {
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


    else if (method == "POST" && api == "../api/Discounts") {
        
        let dicount = JSON.parse(data);
        dicount.Id = id;
        Discounts.push(dicount);
        successCB(Discounts);
        id++;
        //errorCB("did not manage to insert the new car into the DB");
    }

    else if (method == "DELETE") {
        splitArr = api.split('/');
        let id = splitArr[splitArr.length - 1];
        temp = [];
        index = 0;
        for (var i = 0; i < Cars.length; i++) {
            if (parseInt(Cars[i].Id) != id) {
                temp[index] = Cars[i];
                index++;
            }
        }
        Cars = temp;
        successCB(Cars);
    }


}

function getMaxId(cars){
    let max = 0;
    for (var i = 0; i < cars.length; i++) {
        if (cars[i].Id > max)
            max = cars[i].Id;
    }
    return max;
}