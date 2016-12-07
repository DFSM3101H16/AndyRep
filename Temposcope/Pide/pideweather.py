import pyowm
from pyowm import timeutils
import pidetts
import sendweather
from time import gmtime


owm = pyowm.OWM('8d2e38c9f05d7fe51c4de7ef0557723c')


def weatherAtNow(location):
    observation = owm.weather_at_place(location)
    observation.get_reception_time(timeformat='date')
    weather = observation.get_weather()
    
    date = weather.get_reference_time('date')
    status = weather.get_status()
    detStat = weather.get_detailed_status()
    temp = weather.get_temperature('celsius')
    rain = weather.get_rain()
    snow = weather.get_snow()
    wind = weather.get_wind()
    sunrise = weather.get_sunrise_time('date')
    sunset = weather.get_sunset_time('date')
    cloud = weather.get_clouds()
    clock = gmtime()
        
    sen1 = (" This is the current weather forecast for " + str(location) +". ")
    sen2 = (" It is going to be " + str(status) + ". ")
    sen3 = (" Temperature will be of minimum " + str(temp.get('temp_min')))
    sen4 = (" and maximum " + str(temp.get('temp_max')) + " degrees celsius. ")
    sensnow = ''
    senrain = ''
    sencloud = ''
        
    if len(snow) is not 0:
        sensnow = (" Snow volume is going to be " + str(snow.get('3h')) + ". ")
    if len(rain) is not 0:
        senrain = (" Rain volume is going to be " + str(rain.get('3h')) + ". ")
    if cloud is not 0:
        sencloud = (" Cloud coverage is going to be " + str(cloud) + " percent. ")

    senclock = (" The clock is now " + str(clock.tm_hour) + " " + str(clock.tm_min))
    senrise = (" Sunrise at " + str(sunrise) + ". " )
    senset = (" Sunset at " + str(sunset) + ". " )
    senDet = (" Enjoy todays " + detStat + "! " )

    senfin = sen1 + sen2 + sen3 + sen4 + sensnow + senrain + sencloud
    pidetts.speak(sen1)
    pidetts.speak(sen2)
    pidetts.speak(sen3)
    pidetts.speak(sen4)
    pidetts.speak(sensnow + senrain + sencloud)
    pidetts.speak(senclock)
    pidetts.speak(senrise)
    pidetts.speak(senset)
    pidetts.speak(senDet)
    if "Rain" in status:       
        sendweather.sendWeather(1)
    else:
        sendweather.SendWeather(0)
    return 


def weatherAtDay(location, number):
    fc = owm.daily_forecast(location, limit=5)
    f = fc.get_forecast()
    iterator = 0
    for weather in f:
        iterator = iterator + 1
        if(iterator == number):
            print (weather.get_reference_time('iso'), weather.get_status(), weather.get_temperature('celsius'))
            date = weather.get_reference_time('date')
            status = weather.get_status()
            detStat = weather.get_detailed_status()
            temp = weather.get_temperature('celsius')
            rain = weather.get_rain()
            snow = weather.get_snow()
            wind = weather.get_wind()
            sunrise = weather.get_sunrise_time('iso')
            sunset = weather.get_sunset_time('iso')
            cloud = weather.get_clouds()

            #BOOLS
            snowing = fc.will_have_snow()
            raining = fc.will_have_rain()
            cloudy = fc.will_have_clouds()
            foggy = fc.will_have_fog()
                        
            sen1 = (" This is the weather forecast for " + str(location) +" at " + str(date) + ". ")
            sen2 = (" It is going to be " + str(status) + ". ")
            sen3 = (" Temperature will be of minimum " + str(temp.get('min')))
            sen4 = (" and maximum " + str(temp.get('max')) + " degrees celsius. ")
            sensnow = ''
            senrain = ''
            sencloud = ''
            senfoggy = ''
            if snowing == True and len(snow) is not 0:
                sensnow = (" Snow volume is going to be " + str(snow.get('3h')) + ". ")
            elif snowing == True and len(snow) is 0:
                  sensnow = (" It will be snow, but I don't know what the estimated volume will be. ")
            if raining == True and len(rain) is not 0:
                senrain = (" Rain volume is going to be " + str(rain.get('3h')) + ". ")
            elif raining == True and len(rain) is 0:
                  senrain = (" It will be raining, but I don't know what the volume is estimated to be. ")
            if cloudy == True:
                sencloud = (" Cloud coverage is going to be " + str(cloud) + " percent. ")
            if foggy == True:
                senfoggy = (" Watch out! It might become foggy! ")

            senrise = (" Sunrise at " + sunrise + ". " )
            senset = (" Sunset at " + sunset + ". " )
            senDet = (" Enjoy the " + detStat + "! " )

            pidetts.speak(sen1)
            pidetts.speak(sen2)
            pidetts.speak(sen3)
            pidetts.speak(sen4)
            pidetts.speak(sensnow + senrain + sencloud + senfoggy)

            #pidetts.speak(sensnow + senrain + sencloud)
            #pidetts.speak(senrise)
            #pidetts.speak(senset)
            pidetts.speak(senDet)
            if "Rain" in status:
                sendweather.sendWeather(1)
            else:
                sendweather.sendWeather(0)

    
            senfin = sen1 + sen2 + sen3 + sen4 + sensnow + senrain + sencloud + senfoggy
            return
        
#weatherAtNow('kongsberg')
#weatherAtTomorrow('kongsberg')
#weatherAtDay('kongsberg', 2)
