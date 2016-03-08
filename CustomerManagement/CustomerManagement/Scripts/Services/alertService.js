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

        this.error = function (title, message, onClose) {
            swal({title: title,
                text: message,
                type: 'error'
            }, function() {
                if(onClose) {
                    onClose();
                }
            });
        };

        this.loader = function () {
            swal({
                title: "<span><i class='fa fa-refresh fa-spin'></i></span>",
                text: "Loading data",
                html: true,
                showConfirmButton: false
            });
        };

        this.close = function () {
            swal.close();
        }
    });