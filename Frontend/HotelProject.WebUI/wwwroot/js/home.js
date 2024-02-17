function isValidEmail(email) {
    var regex = /^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$/;
    return regex.test(email);
}

$(document).on('click', '#signUpNews', function (event) {
    event.preventDefault();
    event.stopPropagation();

    const emailAdress = $('#newsMail').val();

    const addSubscribeDto = {
        Email: emailAdress
    }

    if (isValidEmail(emailAdress)) {
        $.ajax({
            url: '/Subscribe/Add/',
            type: 'POST',
            contentType: "application/json",
            data: JSON.stringify(addSubscribeDto),
            success: function (response) {
                const parsedData = JSON.parse(response);
                if (parsedData.ResultStatus === true) {
                    Swal.fire({
                        title: "Başarıyla Eklendi!",
                        text: `${parsedData.data.Email} başarıyla eklendi.`,
                        icon: "success"
                    });
                } else {
                    Swal.fire({
                        title: "Hata Oluştu!",
                        text: `${parsedData.data.Email} e-posta adresi eklenirken bir hata oluştu. Hata kodu ${parsedData.StatusCode}`,
                        icon: "error"
                    });
                }
            },
            error: function (err) {
                Swal.fire({
                    title: "Hata Oluştu!",
                    text: `Lütfen, yönetici ile iletişime geçiniz. Hata kodu : ${err.responseText}`,
                    icon: "error"
                });
            }
        })
    } else {
        Swal.fire({
            title: "E-posta Adresi Geçersiz!",
            text: "Lütfen, geçerli bir e-posta adresi giriniz.",
            icon: "error"
        });
    }
})