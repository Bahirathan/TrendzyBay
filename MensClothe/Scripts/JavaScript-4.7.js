
var path = location.pathname.split('/');
//var appPath = '/' + hostName + '/';
//var appPath = '/' + path[1] + '/' ;
var appPath = '/';

function OrderDetailTable(objArray, ex, cur) {
   
    var array = typeof objArray != 'object' ? JSON.parse(objArray) : objArray;

    var str = '<table>';
        str += '<thead><tr>';
        str += '<th scope="col"> Item code </th>';
        str += '<th scope="col"> Item Name </th>';
        str += '<th scope="col"> Quantity </th>';
        str += '<th scope="col"> Base Currency Price </th>';
        str += '<th scope="col"> Exchange Price </th>';
        str += '</tr></thead>';
        
    str += '<tbody>';
    for (var i = 0; i < array.length; i++) {
        str += (i % 2 == 0) ? '<tr class="alt">' : '<tr>';
        str += '<td>' + array[i]['ProductID'] + '</td>';
        str += '<td>' + array[i]['PrdName'] + '</td>';
        str += '<td>' + array[i]['quantity'] + '</td>';
        str += '<td>' + array[i]['price']  + '</td>';
        str += '<td>' + array[i]['ExchangePrice'] + '</td>';
      
    }
    str += '</tr>';
    str += '</tbody>'
    str += '</table>';
    return str;
}

function formatPrice(price, cur) {
  return  accounting.formatMoney(price, cur);
}


function setCurrency(curobj) {
  
    var currency = $('#' + curobj.id).val();
    var currencySymbol = curobj.options[curobj.selectedIndex].innerHTML.split('(')[1].split(')')[0];
    var country = curobj.options[curobj.selectedIndex].innerHTML.split('(')[0].trim();
    $.ajax({
        type: "POST",
        async: false,
        cache: false,
        timeout: 30000,
        url: appPath  + "Web_Service/WebService.asmx/setCurrencyDetails",
        data: "{'curnVal': '" + currency + "', 'curnSymbol': '" + currencySymbol + "' , 'Country': '" + country + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        error: OnError
    })
}


function UpdateCartDetails(exchange,currency) {

   
    $.ajax({
        type: "POST",
        url: appPath + "Web_Service/WebService.asmx/getShoppingCartdetails",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        dataType: "json",
        success: function (data) {
      
            $("#cart_details").empty();
            $("#cart_href").empty();
            $('#cart_href').html('View Cart  [  ' + data.d.Items.length + '  ] Items ');
            if (data.d.Items.length > 0) {
                $('#cart_details').append(CreateTableView(data.d.Items, null, false, exchange, currency));
            }
            $('#cart_details').appendTo('#cart_href')
        },
        error: OnError
    });
}


function CreateTableView(objArray, theme, enableHeader,ex, cur) {
    // set optional theme parameter
    if (theme === undefined) {
        theme = 'mediumTable'; //default theme
    }

    if (enableHeader === undefined) {
        enableHeader = true; //default enable headers
    }

    // If the returned data is an object do nothing, else try to parse
    var array = typeof objArray != 'object' ? JSON.parse(objArray) : objArray;

    var str = '<table class="' + theme + '">';

    // table head
    if (enableHeader) {
        str += '<thead><tr>';
        for (var index in array[0]) {
            str += '<th scope="col">' + index + '</th>';
        }
        str += '</tr></thead>';
    }
    else {

        str += '<thead><tr>';
        str += '<th scope="col"> Description </th>';
        str += '<th scope="col"> Quantity </th>';
        str += '<th scope="col"> Price </th>';
        str += '</tr></thead>';



    }

    // ;
    // table body
    str += '<tbody>';
    for (var i = 0; i < array.length; i++) {
        str += (i % 2 == 0) ? '<tr class="alt">' : '<tr>';
        //  for (var index in array[i]) {
        //    if (index == "ProductName") {
        str += '<td>' + array[i]['ProductName'] + '</td>';
        //  }
        //  if (index == "Price") {
        str += '<td>' + array[i]['Quantity'] + '</td>';
        // }
        // if (index == "Quantity") {
        str += '<td>' +formatPrice( array[i]['Price'] * ex, cur)  +'</td>';
        //  }
        str += '<td><input type="button"  id=' + array[i]['ProductID'] + ' onclick="removeCartItem(this);" name="remove"  value="Remove" /></td>';

    }
    str += '</tr>';
    str += '<tr><td><input type="button"  onclick="removeAllCartItems()" name="removeAll"  id="removeAll"  value="Remove All" /></td></tr>';
    //   }
    str += '</tbody>'
    str += '</table>';
    return str;
}


function removeAllCartItems() {
    $.ajax({
        type: "POST",
        async: false,
        cache: false,
        timeout: 30000,
        url: appPath + "Web_Service/WebService.asmx/DeleteAllCartItemClick",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        dataType: "json",
        success: function (data) {

            window.location = window.location;

        },
        error: OnError
    });

}



function ViewDetailClick(obj) {
    var id = (obj.id.indexOf('-') >= 0) ? obj.id.split('-')[1] : obj.id;

    popupwin = window.open(appPath + 'Products/DetailProductResult' + "?resultIndex=" + id + "&isPopup=1", 'Detail', 'height=' + 600 + ',width=' + 520 + ',scrollbars=yes,left=400,top=300');
    popupwin.focus();
}

function Add2CartClick(obj) {

    var id = obj.id.split('_')[0].trim();
    //$("#prdID").val(id);
    $.ajax({
        type: "POST",
        async: false,
        cache: false,
        timeout: 30000,
        url: appPath + "Web_Service/WebService.asmx/SelectedItemClick",
        data: "{_id:'" + id + "'}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: OnSucceess,
        error: OnError
    });
}

function refreshParent() {
    window.onunload = window.opener.location.reload();
}





function redirect2Payment() {
    window.location="PaymentOrder";
}
function redirect2ProductList() {
    //;
    window.location = "Products/ProductResults";

}

function removeCartItem(obj) {
    var id = parseInt(obj.id);
    $.ajax({
        type: "POST",
        async: false,
        cache: false,
        timeout: 30000,
        url: appPath + "Web_Service/WebService.asmx/DeleteCartItemClick",
        contentType: "application/json; charset=utf-8",
        data: "{itemid:'" + id + "'}",
        dataType: "json",
        success: function (data) {
            window.location = window.location;

        },
        error: OnError
    });
    return false;

}


function selectCategory(input) {
    if (input.value) {
        try {
            $.ajax({
                type: "POST",
                url: appPath + "Web_Service/WebService.asmx/SearchCategory",
                data: "{ 'categoryID': '" + input.value + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('#detailform').css('display', '');
                    $('#CatID').val(data.d.categoryid);
                    $('#CategoryName').val(data.d.categoryname);
                    $('#Description').val(data.d.description);
                },

                failure: function (errMsg) {
                    alert(errMsg);
                }
            });
        }
        catch (Exception) {

        }
    }
}

function selectCustomer(input) {
    if (input.value) {
        try {
            $.ajax({
                type: "POST",
                url: appPath + "Web_Service/WebService.asmx/getCustomerDetails",
                data: "{ 'cusID': '" + input.value + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('#detailform').css('display', '');
                    $('#txtName').val(data.d.customername);
                    $('#txtAddress').val(data.d.Address);
                    $('#txtCity').val(data.d.City);
                    $('#txtState').val(data.d.State);
                    $('#txtZip').val(data.d.Zipcode);
                    $('#Country').val(data.d.Country);
                    $('#txtEmail').val(data.d.Email);
                    $('#txtPhone').val(data.d.phone);

                },

                failure: function (errMsg) {
                    alert(errMsg);
                }
            });
        }
        catch (Exception) {

        }
    }
}



function ShowOrderProducts(OrID,exRate,currency) {
    var ProductList = "#OD_DIV" + OrID;
    $.ajax({
        url: appPath + "Web_Service/WebService.asmx/GetOrderDetails",
        type: "POST",
        data: "{_id:'" + OrID + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var OrderDetails = data.d;
            $(ProductList).empty();
            $(ProductList).html(OrderDetailTable(data.d,exRate,currency));
        },
        error: OnError
    });
}


function toggle(obj) {
    var divID = "OD_DIV" + obj;
    var a = "a_" + obj;
    var ele = document.getElementById(divID);
    var text = document.getElementById(a);
    if (ele.style.display == "block") {
        ele.style.display = "none";
        text.innerHTML = "Show Details";
    }
    else {
        ele.style.display = "block";
        text.innerHTML = "Hide Details";
    }
}


function DeleteOrderClick(obj) {
  
       var id = obj.id;
    $.ajax({
        type: "POST",
        async: false,
        cache: false,
        timeout: 30000,
        url: appPath + "Web_Service/WebService.asmx/DeleteOrder",
        contentType: "application/json; charset=utf-8",
        data: "{_id:'" + id + "'}",
        dataType: "json",
        success: OnSucceess,
        error: OnError
    });
}



function selectProduct(input) {
    if (input.value) {
        try {
            $.ajax({
                type: "POST",
                url: appPath + "Web_Service/WebService.asmx/getProductDetails",
                data: "{ 'prdID': '" + input.value + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
               
                    var imgPath = appPath + 'Images/' + data.d.img;

                    $('#detailform').css('display', '');

                    $('#pname').val(data.d.name);
                    $('#img').attr('src', imgPath)
                    .css('display', '')
                    .width(150)
                    .height(200);
                    $('#HiddenImg').val(imgPath);
                    $('#quantity').val(data.d.quantity);
                    $('#discontinued').prop('checked', data.d.isAvailable);
                    $('#ddlSupp').val(data.d.supplierID);
                    $('#ddlCat').val(data.d.categoryID);
                    $('#Price').val(data.d.price);
                    $('#Profitmargin').val(data.d.profitmargin);
                },

                failure: function (errMsg) {
                    alert(errMsg);
                }
            });
        }
        catch (Exception) {

        }
    }
}


function readURL(input) {
   
    if (input.value) {

        try {

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#img')
                .attr('src', e.target.result)
                .css('display', '')
                .width(150)
                .height(200);

            };
            reader.readAsDataURL(input.files[0]);
        }
        catch (Exception) {
            //    ;
            var imagename = appPath + '/Images/' + input.value.split('\\').pop();
            imagename = imagename.replace('//', '/');
            $('#img')
             .attr('src', imagename)
             .css('display', '');
        }
    }
}

function selectSupplier(input) {
    if (input.value) {
        try {
            $.ajax({
                type: "POST",
                url: appPath + "Web_Service/WebService.asmx/getSupplierDetails",
                data: "{ 'SuppID': '" + input.value + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('#detailform').css('display', '');
                    $('#txtCompanyName').val(data.d.companyname);
                    $('#txtAddress').val(data.d.address);
                    $('#txtZip').val(data.d.postalcode);
                    $('#txtPhone').val(data.d.phone);
                    $('#txtState').val(data.d.region);
                    $('#txtCity').val(data.d.city);
                    $('#txtEmail').val(data.d.Email);
                    $('#txtCountry').val(data.d.country);
                    $('#txtName').val(data.d.contactname);
                },

                failure: function (errMsg) {
                    alert(errMsg);
                }
            });
        }
        catch (Exception) {

        }
    }
}

function DeleteSupplier() {
   
    var id = $('#DDLid').val();
    $.ajax({
        type: "POST",
        url: appPath + "Web_Service/WebService.asmx/DeleteSupplier",
        contentType: "application/json; charset=utf-8",
        data: "{_id:'" + id + "'}",
        dataType: "json",
        success: OnSucceess,
        error: OnError
    });
}


function DeleteCustomer(obj) {

    var id = obj.id;
    $.ajax({
        type: "POST",
        url: appPath + "Web_Service/WebService.asmx/DeleteCustomer",
        contentType: "application/json; charset=utf-8",
        data: "{_id:'" + id + "'}",
        dataType: "json",
        success: OnSucceess,
        error: OnError
    });
}










function btnSubmit_Click(CustomerDetails, carddetails, amount, PayPalReturnRequest) {
    //  ;
    $.ajax({
        type: "POST",
        url: appPath + "Web_Service/WebService.asmx/ProcessPayment",
        contentType: "application/json; charset=utf-8",
        data: "{cus:'" + CustomerDetails + "',ccard:'" + carddetails + "',Amount:'" + amount + "',PayPalReturnRequest:'" + PayPalReturnRequest + "'}",
        success: OnSucceess,
        error: OnError
    })

}
function SeearchAddCartClick(obj) {
    //;
    var id = obj;
    $("#productid").val(id);
    return true;
}



function selecpayment(obj) {

    var ddlValue = $("#paymentType").val();

    if (ddlValue == "DY") {
        $("#CCdetails").css('display', 'none');
        $("#Ondelivery").css('display', '');
        $("#payByCC").css('display', 'none');
    }
    else if (ddlValue == "PP") {
        $("#CCdetails").css('display', 'none');
        $("#Ondelivery").css('display', 'none');
        $("#payByCC").css('display', '');

    }
    else if (ddlValue == "CC") {
        $("#CCdetails").css('display', '');
        $("#payByCC").css('display', '');
        $("#Ondelivery").css('display', 'none');
    }
}








function OnSucceess() {

}
function OnError(xhr, ErrorText, thrownError) {
    var err = eval("(" + xhr.responseText + ")");
    alert(xhr.responseText);
}




