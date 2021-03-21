var options={
    enableHighAccuracy: true,
    timeout: 5500,
    maximumAge: 10000 // 10s
}

function getPosition(){
    return new Promise((res,rej)=>{
        navigator.geolocation.getCurrentPosition(res,rej)
    }).catch(_=>{});
}

window.methods = {
    GetLocation:  async () =>{
        var pos = await getPosition();
        
        var location = null;
        if(pos!=undefined){
            location = [pos.coords.latitude, pos.coords.longitude];
        }
        return location;
    },
    SetGoogle: (inp, dotnetHelper)=>{
        const options = {
            fields: ["geometry", "name"],
            types: ["(cities)"],
        }
        var autocomplete = new google.maps.places.Autocomplete(inp,options);

        google.maps.event.addListener(autocomplete, "place_changed", function(){
            var near_place = autocomplete.getPlace();
            var lat = near_place.geometry.location.lat();
            var lng = near_place.geometry.location.lng();
            var name = near_place.name;


            dotnetHelper.invokeMethodAsync("OnPlaceChanged", lat, lng, name);

        })
    }
}