
var KurssiDataModel = /** @class */(function () {

    function KurssiDataModel() {

    }

    return KurssiDataModel;

}());

function initKurssiTallennus() {

    $("#TallennaKurssiButton").click(function () {

        //alert("Toimii!");

        var oppilasKoodi = $("#OppilasKoodi").val();

        var kurssiKoodi = $("#KurssiKoodi").val();

        //var luokkaKoodi = $("#LuokkaKoodi").val();

        //alert("K: " + kurssiKoodi + ", O:" + oppilasKoodi + ", L:" + luokkaKoodi);

        alert("K: " + kurssiKoodi + ", O:" + oppilasKoodi);

        //määritetään muuttuja:

        var data = new KurssiDataModel();

        data.Opiskelijanro = oppilasKoodi;

        data.Kurssikoodi = kurssiKoodi;

        //data.LuokanKoodi = luokkaKoodi;

        //lähetetään JSON-muotoista dataa palvelimelle

        $.ajax({

            type: "POST",

            url: "/läsnäolotieto/TallennaLasnaolo",

            data: JSON.stringify(data),

            contentType: "application/json",

            success: function (data) {

                if (data.success === true) {

                    alert("Asset successfully assigned.");

                }

                else {

                    alert("There was an error: " + data.error);

                }

            },

            dataType: "json"

        });

    });

}

