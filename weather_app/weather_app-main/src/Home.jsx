import React, { useEffect, useState } from 'react';
import './Home.css';
import Icons from './components/icons';
import BarChart from './echarts/BarChart';


import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet'
import 'leaflet/dist/leaflet.css'
import './mapa.css';
import L from 'leaflet'
import icon from 'leaflet/dist/images/Marker-icon.png'
import iconshadow from 'leaflet/dist/images/Marker-icon.png'



import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSun, faCloudSun, faCloud, faCloudShowersHeavy, faSnowflake, faSmog, faBolt, faCloudRain, faWind } from '@fortawesome/free-solid-svg-icons';
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";

const Home = () => {


    const [forecast, setForecast] = useState([]);

    // Api Key for the Api string
    const apiKey = '383824eaecc7d80737ecf7a5cf964baa';

    // Data for the app
    const [searchQuery, setSearchQuery] = useState('');
    const [city, setCity] = useState('Puebla');
    const [temperature, setTemperature] = useState(0);
    const [max, setMax] = useState(0);
    const [min, setMin] = useState(0);
    const [feel, setFeel] = useState(0);
    const [wind, setWind] = useState(0);
    const [description, setDescription] = useState('');
    const [humidity, setHumidity] = useState(0);

    // Data returned for function getGeo
    const [lat, setLat] = useState(0);
    const [lon, setLon] = useState(0);



    let IconUbicacion = new L.icon({
        iconUrl: icon,
        iconshadow: iconshadow,
        iconSize: [30, 50],
        iconAnchor: [30, 40],
        shadowAnchor: [20, 45],
        popupAnchor: [-3 - 78]

    })

    const Mapa = () => {
        return (
            <div>
                <MapContainer center={[lat, lon]} zoom={13} scrollWheelZoom={false} className='mapa'>
                    <TileLayer
                        attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                    />
                    <Marker position={[lat, lon]} icon={IconUbicacion}>
                        <Popup>
                            A pretty CSS3 popup. <br /> Easily customizable.
                        </Popup>
                    </Marker>
                </MapContainer>
            </div>
        )
    }

    // Data for graphic
    const [data, setData] = useState({ labels: [], serie: [] });

    // Function to get the latitude and longitude
    const getGeo = async (city, limit) => {
        const url = `http://api.openweathermap.org/geo/1.0/direct?q=${city}&limit=${limit}&appid=${apiKey}`;

        // Try get the data from the Api and save data
        try {
            const response = await fetch(url);
            const data = await response.json();
            console.log(data)
            // Values are asigned to variables
            setLat(data[0].lat);
            setLon(data[0].lon);
        }
        catch (error) {
            console.log(error)
        }
    }


    const getConversion = (kelvin) => {
        return (kelvin - 273.15).toFixed(1);
    }
    const getWeatherforecast = async (city) => {
        const url = `https://api.openweathermap.org/data/2.5/forecast?q=${city}&appid=${apiKey}&cnt=100`;
        try {
            const response = await fetch(url);
            const data = await response.json();

            const forecastData = [];
            const processedDays = new Set();
            data.list.forEach((item) => {
                const fecha = new Date(item.dt_txt);
                const dia = fecha.getDate();
                if (!processedDays.has(dia)) {
                    forecastData.push(item);
                    processedDays.add(dia);
                }
            });

            setForecast(forecastData);
            console.log(forecastData);
        } catch (error) {
            console.log(error);
        }
    }



    useEffect(() => {
        getGeo('Puebla', 1);
        getWeatherforecast('Puebla');
    }, []);

    const obtenerDiaSemana = (fechaString) => {
        const fecha = new Date(fechaString);
        const diasSemana = ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado', 'Domingo'];
        return diasSemana[fecha.getDay()];
    }


    const descripcionEnEspanol = (descripcion) => {
        switch (descripcion.toLowerCase()) {
            case 'clear sky':
                return 'Despejado';
            case 'few clouds':
                return 'Algunas nubes';
            case 'scattered clouds':
                return 'Nubes dispersas';
            case 'broken clouds':
                return 'Nublado';
            case 'shower rain':
            case 'rain':
                return 'Lluvia';
            case 'thunderstorm':
                return 'Tormenta eléctrica';
            case 'snow':
                return 'Nieve';
            case 'mist':
                return 'Neblina';
            case 'overcast clouds':
                return 'Nublado';
            case 'light rain':
                return 'Lluvia ligera';
            default:
                return descripcion;
        }
    };

    const obtenerIconoClima = (descripcion) => {
        switch (descripcion.toLowerCase()) {
            case 'clear sky':
            case 'few clouds':
                return <FontAwesomeIcon icon={faSun} style={{ color: "#FFD43B", }} size="4x" />;
            case 'scattered clouds':
            case 'broken clouds':
                return <FontAwesomeIcon icon={faCloudSun} style={{ color: "#ff780a", }} size="4x" />;
            case 'overcast clouds':
            case 'clouds':
                return <FontAwesomeIcon icon={faCloud} style={{ color: "#74C0FC", }} size="4x" />;
            case 'shower rain':
            case 'rain':
                return <FontAwesomeIcon icon={faCloudShowersHeavy} style={{ color: "#FFD43B", }} size="4x" />;
            case 'light rain':
                return <FontAwesomeIcon icon={faCloudRain} style={{ color: "#FFD43B", }} size="4x" />;
            case 'moderate rain':
            case 'heavy intensity rain':
                return <FontAwesomeIcon icon={faCloudRain} style={{ color: "#FFD43B", }} size="4x" />;
            case 'snow':
            case 'light snow':
            case 'heavy snow':
                return <FontAwesomeIcon icon={faSnowflake} style={{ color: "#FFD43B", }} size="4x" />;
            case 'mist':
            case 'haze':
            case 'fog':
                return <FontAwesomeIcon icon={faSmog} style={{ color: "#FFD43B", }} size="4x" />;
            case 'thunderstorm':
                return <FontAwesomeIcon icon={faBolt} style={{ color: "#FFD43B", }} size="4x" />;
            case 'windy':
            case 'strong wind':
                return <FontAwesomeIcon icon={faWind} style={{ color: "#FFD43B", }} size="4x" />;
            default:
                return null;
        }
    };

    const settings = {
        dots: true,
        infinite: false,
        speed: 500,
        slidesToShow: 3,
        slidesToScroll: 1,
    };


    // function to get the data weather
    const getWeather = async (lat, lon) => {
        const url = `https://api.openweathermap.org/data/2.5/weather?lat=${lat}&lon=${lon}&units=metric&appid=${apiKey}`;

        // Try get the data from the Api and save data
        try {
            const response = await fetch(url);
            const data = await response.json();

            // Values are asigned to variables
            console.log(data)
            setTemperature(data.main.temp);
            setMax(data.main.temp_max);
            setMin(data.main.temp_min);
            setWind(data.wind.speed);
            setHumidity(data.main.humidity);
            setFeel(data.main.feels_like);
            setDescription(data.weather[0].main)

        } catch (error) {
            console.log(error);
        }
    }

    // Call the functions
    useEffect(() => {
        getGeo(city, 1);
    }, [city]);

    useEffect(() => {
        if (lat !== 0 && lon !== 0) {
            getWeather(lat, lon);
        }
    }, [lat, lon]);

    const handleSearch = () => {
        setCity(searchQuery);
        getGeo(city, 1);
        getWeatherforecast(city);
    }

    useEffect(() => {
        getTemp(lat, lon);
    }, [lat, lon]);


    // Function to have the data from the next days
    // Function to have the data from the next 24 hours in 3-hour intervals
const getTemp = async (lat, lon) => {
    const username = 'utp_flores_alan';
    const password = '65KUEv7tRn';
    const currentDate = new Date();
    const endDate = new Date(currentDate.getTime() + 24 * 60 * 60 * 1000); // Next 24 hours
    const url = `https://api.meteomatics.com/${currentDate.toISOString()}--${endDate.toISOString()}:PT3H/t_2m:C/${lat},${lon}/json`;

    const credentials = `${username}:${password}`;
    const base64Credentials = btoa(credentials);

    try {
        const response = await fetch(url, {
            headers: {
                'Authorization': `Basic ${base64Credentials}`,
                'Content-Type': 'application/json',
            },
        });
        const result = await response.json();
        console.log('API response:', result);
        const { dates } = result.data[0].coordinates[0];
        console.log(dates);
        let fechas = [];
        let temperaturas = [];
        dates.forEach(date => {
            fechas.push(date.date);
            temperaturas.push(date.value);
        });
        console.log("Fechas: ", fechas, "Temperaturas:", temperaturas);
        setData({ labels: fechas, serie: temperaturas });
    } catch (error) {
        console.error('Error al obtener datos:', error);
    }
};



    return (
        <>
            <header className='header'>
                <div className="container">
                    <div className="cards">

                        <div className="search">
                            <input type="text" name="text" placeholder="Busca tu ciudad..." className="input" value={searchQuery} onChange={(e) => setSearchQuery(e.target.value)} />
                            <button className="btn-search" onClick={handleSearch}>
                                <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-search" width="40" height="40" viewBox="0 0 24 24" strokeWidth="1.5" stroke="#ffffff" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                    <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                    <path d="M10 10m-7 0a7 7 0 1 0 14 0a7 7 0 1 0 -14 0" />
                                    <path d="M21 21l-6 -6" />
                                </svg>
                            </button>
                        </div>

                        <h2 className='city_title'>{city}, {description}</h2>


                        <div className="datos w-100 row">
                            <div className='temperature col-lg-4 col-sm-12'>
                                <h3 className='temperature__title'>Temperatura Actual</h3>
                                <p className='temperature__data'>{temperature}°</p>
                                <img className='icon-w' src={Icons(description)} alt="" />
                            </div>


                            <div className='general_data col-lg-8 col-sm-12 row'>
                                <div className='wind col-lg-4 col-sm-12'>
                                    <h3>Viento: </h3>
                                    <p>{wind} km/h</p>
                                    <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-wind" width="40" height="40" viewBox="0 0 24 24" strokeWidth="1.5" stroke="#ffffff" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                        <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                        <path d="M5 8h8.5a2.5 2.5 0 1 0 -2.34 -3.24" />
                                        <path d="M3 12h15.5a2.5 2.5 0 1 1 -2.34 3.24" />
                                        <path d="M4 16h5.5a2.5 2.5 0 1 1 -2.34 3.24" />
                                    </svg>
                                </div>

                                <div className='wind col-lg-4 col-sm-12'>
                                    <h3>Humedad: </h3>
                                    <p>{humidity} %</p>
                                    <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-droplet" width="40" height="40" viewBox="0 0 24 24" strokeWidth="1.5" stroke="#ffffff" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                        <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                        <path d="M7.502 19.423c2.602 2.105 6.395 2.105 8.996 0c2.602 -2.105 3.262 -5.708 1.566 -8.546l-4.89 -7.26c-.42 -.625 -1.287 -.803 -1.936 -.397a1.376 1.376 0 0 0 -.41 .397l-4.893 7.26c-1.695 2.838 -1.035 6.441 1.567 8.546z" />
                                    </svg>
                                </div>

                                <div className='wind col-lg-4 col-sm-12'>
                                    <h3>Sensación térmica: </h3>
                                    <p>{feel}°</p>
                                    <svg xmlns="http://www.w3.org/2000/svg" className="icon icon-tabler icon-tabler-temperature" width="40" height="40" viewBox="0 0 24 24" strokeWidth="1.5" stroke="#ffffff" fill="none" strokeLinecap="round" strokeLinejoin="round">
                                        <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                        <path d="M10 13.5a4 4 0 1 0 4 0v-8.5a2 2 0 0 0 -4 0v8.5" />
                                        <path d="M10 9l4 0" />
                                    </svg>
                                </div>
                            </div>
                        </div>



                        <div className="minmaxContainer">
                            <div className="min">
                                <p className="minHeading">Min</p>
                                <p className="minTemp">{min}°</p>
                            </div>
                            <div className="max">
                                <p className="maxHeading">Max</p>
                                <p className="maxTemp">{max}°</p>
                            </div>
                        </div>

                        <div className="container mt-5">
                            <Slider {...settings}>
                                {forecast.map((day, index) => (
                                    <div key={index} className="col-md-12">
                                        <div className="card mb-4" >
                                            <div className="card-header bg-secondary text-white d-flex justify-content-center align-items-center">
                                                <h3 className="card-title">{obtenerDiaSemana(day.dt_txt)}</h3>
                                            </div>
                                            <div className="card-body bg-dark border-dark container d-flex flex-column justify-content-center align-items-center">
                                                <div className="mt-3 text-center">
                                                    {obtenerIconoClima(day.weather[0].description)}
                                                    <p className='text-lg'>{descripcionEnEspanol(day.weather[0].description)}</p>
                                                </div>
                                                <div className="d-flex justify-content-center">
                                                    <div className="text-lg mr-3">Max: {getConversion(day.main.temp_max)}°C</div>
                                                    <div className="text-lg">Min: {getConversion(day.main.temp_min)}°C</div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                ))}
                            </Slider>
                        </div>
                        <div>
                        </div>
                    </div>


                </div>
            </header >
            
            <div className='bg'>
                <h2 className='title'>Más información</h2>

                <div className='row-prueba'>
                    <div className='separacion prueba'>
                        <BarChart className='prueba' labels={data.labels} serie={data.serie} />
                    </div>
                    <div className='separacion prueba'>
                        <h2>Locacion buscada</h2>
                        <Mapa className='prueba' />
                    </div>
                </div>
            </div>


            <footer className='footer'>
                <p>Todos los derechos reservados</p>
            </footer>

        </>
    )
}

export default Home