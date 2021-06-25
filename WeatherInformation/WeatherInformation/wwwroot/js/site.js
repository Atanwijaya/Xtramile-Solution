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
        $('#country').val("");
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
                $('#city').val("");
            });
        });

        $('#city').on('change', function () {
            var cityName = $(this).find("option:selected").html();
            ajaxHelper({
                url: "/api/weather/getWeatherConditionByCityName/" + cityName,
                method: 'GET'
            }).done(function (weatherInfo) {
                $('#cityTxt').html($('#city option:selected').html());
                $('#countryTxt').html($('#country option:selected').html());
                $('#longitude').html(weatherInfo.coordinate.longitude);
                $('#latitude').html(weatherInfo.coordinate.latitude);
                $('#time').html(weatherInfo.time);
                $('#speed').html(weatherInfo.wind.speed);
                $('#direction').html(weatherInfo.wind.direction);
                $('#visibility').html(weatherInfo.visibility);
                $('#temp').html(weatherInfo.temperature);
                $('#humidity').html(weatherInfo.humidity);
                $('#pressure').html(weatherInfo.pressure);
                $('#skyconditions').empty();
                $.each(weatherInfo.skyCondition, function (ix, conStr) {
                    $('#skyconditions').append('<div>' + conStr + '</div>');
                });
            });
        });
    });
})(jQuery)