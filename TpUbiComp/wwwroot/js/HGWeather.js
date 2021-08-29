function HgInit() {

    var cityId = parseInt(GetSearchParams("idCity"));
    var url = "https://api.hgbrasil.com/weather?format=json-cors&key=6b68685d&woeid=";

    switch (cityId) {
        case 1:
        default:        
            url += '455821';
            break;
        case 2:
            url += '455827';
            break;
        case 3:
            url += '455825';
            break;
        case 4:
            url += '615702';
            break;        
    }

    $.ajax({
        url: url,
        data: null,
        success: (data) => { WriteWeatherNotifications(data.results) }
    });
}

function WriteWeatherNotifications(data) {

    var template = `
        <li class="list-group-item">
            <div class="row">
                <div class="col">
                    <div class="d-flex">
                        <div class="ml-3">
                            <h5 class="font-weight-bold mb-1">
                                {0}
                            </h5>
                            <p class="mb-3">
                                {1}
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </li>`;
    var conditionCode = parseInt(data.condition_code);

    var alert = String.format(template, data.description, `A temperatura atual da cidade é de ${data.temp}º`);
    $("#notification-list-scroll").append(alert);

    if (conditionCode.between(0, 4)) {
        $("#notification-list-scroll").append(
            String.format(template, "Alerta de clima intenso", `Atenção, devido as condições atuais evite sair de casa no momento.`)
        );
    }
    else if (conditionCode.between(37, 40)) {
        $("#notification-list-scroll").append(
            String.format(template, "Alerta para chuvas", `Atenção, devido as condições atuais evite sair a pé ou de bicicleta.`)
        );
    }
}

function GetSearchParams(k) {
    var p = {};
    location.search.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (s, k, v) { p[k] = v })
    return k ? p[k] : p;
}

// First, checks if it isn't implemented yet.
if (!String.format) {
    String.format = function (format) {
        var args = Array.prototype.slice.call(arguments, 1);
        return format.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
                ? args[number]
                : match
                ;
        });
    };
}

Number.prototype.between = function (a, b) {
    var min = Math.min.apply(Math, [a, b]),
        max = Math.max.apply(Math, [a, b]);
    return this >= min && this <= max;
};