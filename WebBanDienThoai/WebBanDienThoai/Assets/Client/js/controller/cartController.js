//Sử dụng Ajax để tạo chức năng cập nhật, xoá giỏ hàng
var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });

        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });

        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert('Xoá thành công!');
                        window.location.href = "/Cart";
                    }
                }
            })
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert('Xoá thành công!');
                        window.location.href = "/Cart";
                    }
                }
            })
        });

        $('#btnUpdate').off('click').on('click', function () {
            
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data('id')                  
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert('Cập nhật thành công!');
                        location.reload();
                        //window.location.href = "/Cart";                       
                    }
                },
                error: function () {
                    alert('Cập nhật không thành công. Vui lòng thử lại!');
                }
            });
           
        });     
    }
}
cart.init();