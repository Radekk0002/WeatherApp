function SetGoogle(inp, dotnetHelper){

    const options = {
        fields: ["geometry", "name"],
    }
    var autocomplete = new google.maps.places.Autocomplete(inp,options);
    
    google.maps.event.addListener(autocomplete, "place_changed", function(){
        var near_place = autocomplete.getPlace();
        var lat = near_place.geometry.location.lat();
        var lng = near_place.geometry.location.lng();
        var tmp = inp.value.split(',');
        var name = tmp[0] + ", " + tmp[1];
        
        dotnetHelper.invokeMethodAsync("OnPlaceChanged", lat, lng, name);

    })
}