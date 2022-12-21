let Danik = {
    name: "Danik",
    age: 25,
    addres: "Kibuzki",
    family: {
        mom: "mom",
        dad:"dad"
        }
};

for (let item in Danik) {
    ` key ${item}| value ${Danik[item]}`
    if (item === typeof ("object")) {
        for (let secondItem in item) {
            

        }
    }
}

let wather = {
    "coord": {
        "lon": 34.7722,
        "lat": 32.0114
    },
    "weather": [
        {
            "id": 801,
            "main": "Clouds",
            "description": "few clouds",
            "icon": "02n"
        }],
    "base": "stations",
    "main": {
        "temp": 290.25,
        "feels_like": 290.08,
        "temp_min": 288.16, "temp_max": 291.28, "pressure": 1012, "humidity": 79
    }, "visibility": 10000, "wind": { "speed": 2.57, "deg": 120 }, "clouds": { "all": 20 }, "dt": 1669744840, "sys": { "type": 2, "id": 2005256, "country": "IL", "sunrise": 1669695712, "sunset": 1669732607 }, "timezone": 7200, "id": 294751, "name": "Holon", "cod": 200
}

