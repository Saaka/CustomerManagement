angular.module('customerManager')
    .service('alertService', function () {

        this.confirm = function (title, message, onClose) {
            swal({
                title: title,
                text: message,
                type: "warning",
                showCancelButton: true,
                closeOnConfirm: true,
                closeOnCancel: true
            },
            onClose);
        };

        this.success = function (title, message, onClose) {
            swal({ 
                title: title, 
                text: message 
            }, function () {
                if (onClose) {
                    onClose();
                }
            });
        };
    });