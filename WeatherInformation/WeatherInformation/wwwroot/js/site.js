(function ($) {

    function ajaxHelper(options) {
        var url = options.url;
        var data;
        if (options.data) {
            data = JSON.stringify(options.data);
        }
        var method = options.method;
        var headerObject =
        {
            "Content-Type": "application/json"
        };
        return $.ajax({
            url: url,
            method: method,
            data: data,
            headers: headerObject
        }).fail(function (jqXHR, any, errorTxt) {
            console.log(jqXHR);
        }).always(function () {

        });
    };
    ajaxHelper({
        url: "/api/country/getCountries",
        method: 'GET'
    }).done(function (countries) {
        $.each(countries, function (ix, countryObj) {
            $('#country').append('<option value="' + countryObj.id + '">' + countryObj.name + '</option>');
        });
        $('#country').on('change', function () {
            var countryID = $(this).val();
            $('#city').empty();
            ajaxHelper({
                url: "/api/city/getAllCitiesByCountryID/" + countryID,
                method: 'GET'
            }).done(function (cities) {
                $.each(cities, function (ix, cityObj) {
                    $('#city').append('<option value="' + cityObj.id + '">' + cityObj.name + '</option>');
                });
            });
        });

        $('#city').on('change', function () {
            var cityName = $(this).find("option:selected").html();
            ajaxHelper({
                url: "/api/weather/getWeatherInfoByCityName/" + cityName,
                method: 'GET'
            }).done(function (weatherInfo) {
                console.log(weatherInfo);
            });
        });
    });
})(jQuery)