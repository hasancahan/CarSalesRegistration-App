$(document).ready(function () {
    var customerTable = $('#customersTable').DataTable({
        ajax: "/api/Registration/GetCustomerCallRecorder",
        columns: [
            { data: "fullName" },
            { data: "subject" },
            { data: "vehicleOfInterestandModel" },
            { data: "packageEngine" },
            { data: "transferredPerson" },
            { data: "location" },
            { data: "phoneNumber" },
            {
                data: "dateandTime", render: function (data) {
                    return new Date(data).toLocaleString();
                }
            },
            { data: "notes" },
            {
                data: null,
                render: function (data, type, row) {
                    return `
                    <div class="button-container">
                        <button class="editBtn"><i class="fa-solid fa-user-pen"></i></button>
                        <button class="deleteBtn"><i class="fa-solid fa-user-xmark"></i></button>
                    </div>

                    `;
                }
            }
        ]
    });

    // Yeni kayýt modal açma
    $('#addCustomerBtn').on('click', function () {
        $('#customerModal').show();
        $('#modalTitle').text('Yeni Cagri Kaydi');
        $('#customerForm')[0].reset();
        $('#customerId').val('');
    });

    // Modal kapatma
    $('.close').on('click', function () {
        $('#customerModal').hide();
    });

    // Form gönderimi (Ekleme ve Güncelleme)
    $('#customerForm').on('submit', function (e) {
        e.preventDefault();

        var formData = {
            Id: $('#customerId').val() ? $('#customerId').val() : generateGuid(),
            FullName: $('#fullName').val(),
            Subject: $('#subject').val(),
            VehicleOfInterestandModel: $('#vehicleOfInterestandModel').val(),
            PackageEngine: $('#packageEngine').val(),
            TransferredPerson: $('#transferredPerson').val(),
            Location: $('#location').val(),
            PhoneNumber: $('#phoneNumber').val(),
            Notes: $('#notes').val()
        };

        if ($('#customerId').val()) {
            updateCustomer(formData);  // Güncelleme iþlemi
        } else {
            createCustomer(formData);  // Yeni kayýt ekleme iþlemi
        }
    });

    // Yeni Kayýt (Create) fonksiyonu
    function createCustomer(formData) {
        $.ajax({
            url: '/api/Registration/CreateCustomerCallRecorder',
            type: 'POST',
            contentType: "application/json",
            data: JSON.stringify(formData),
            success: function () {
                $('#customerModal').hide();
                customerTable.ajax.reload();
            },
            error: function () {
                alert("Bir hata oluþtu.");
            }
        });
    }

    // Güncelleme (Update) fonksiyonu
    function updateCustomer(formData) {
        $.ajax({
            url: '/api/Registration/UpdateCustomerCallRecorder',
            type: 'PUT',
            contentType: "application/json",
            data: JSON.stringify(formData),
            success: function () {
                $('#customerModal').hide();
                customerTable.ajax.reload();
            },
            error: function () {
                alert("Bir hata oluþtu.");
            }
        });
    }

    // Düzenleme butonuna týklama
    $('#customersTable tbody').on('click', '.editBtn', function () {
        var data = customerTable.row($(this).parents('tr')).data();
        $('#customerId').val(data.id);
        $('#fullName').val(data.fullName);
        $('#subject').val(data.subject);
        $('#vehicleOfInterestandModel').val(data.vehicleOfInterestandModel);
        $('#packageEngine').val(data.packageEngine);
        $('#transferredPerson').val(data.transferredPerson);
        $('#location').val(data.location);
        $('#phoneNumber').val(data.phoneNumber);
        $('#notes').val(data.notes);
        $('#modalTitle').text('Duzenle');
        $('#customerModal').show();
    });

    // Silme butonuna týklama
    $('#customersTable tbody').on('click', '.deleteBtn', function () {
        var data = customerTable.row($(this).parents('tr')).data();
        if (confirm("Bu kaydi silmek istediginize emin misiniz?")) {
            $.ajax({
                url: '/api/Registration/DeleteCustomerCallRecorder/' + data.id,
                type: 'DELETE',
                success: function () {
                    customerTable.ajax.reload();
                },
                error: function () {
                    alert("Bir hata oluþtu.");
                }
            });
        }
    });
});

// GUID oluþturma fonksiyonu
function generateGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0,
            v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}