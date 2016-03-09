angular.module('customerManager')
    .service('alertService', ['toaster', function (toaster) {

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

        this.success = function (title, message) {
            toaster.pop({
                type: 'success',
                title: title,
                body: message,
                timeout: 3000
            });
        };

        this.error = function (title, message) {
            toaster.pop({
                type: 'error',
                title: title,
                body: message,
                timeout: 3000
            });
        };

        this.loader = function (message) {
            swal({
                title: "<span><i class='fa fa-refresh fa-spin fa-2x'></i></span>",
                text: "<h2>" + message + "</h2>",
                html: true,
                showConfirmButton: false,
                closeOnCancel: false,
                closeOnConfirm: false
            });
        };

        this.close = function () {
            swal.close();
        }
    }]);