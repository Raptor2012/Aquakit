using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;

public class GetMyWeather : MonoBehaviour
{

    public Text myWeatherLabel;
    public Text onlyWeatherCondition;
    public Image waetherimg;
    public Image weatherTxtImg;
    public GameObject WeatherImg_newObj;
    public Image WeatherImg_new;
    public Image ThunderStorm;
    public Image Drizzle;
    public Image Rain;
    public Image Snow;
    public Image Atmosphere;
    public Image Clear;
    public Image clouds;

    public Image ThunderStormtxt;
    public Image Drizzletxt;
    public Image Raintxt;
    public Image Snowtxt;
    public Image Atmospheretxt;
    public Image Cleartxt;
    public Image cloudstxt;

    private Texture2D myWeatherCondition;

    public string currentIP;
    public string currentCountry;
    public string currentCity;
    public string APPID = "&APPID=391013b34d8368540317a2dd0dd2536d";

    //retrieved from weather API
    public string retrievedCountry;
    public string retrievedCity;
    public int conditionID;
    public string conditionName;
    public string conditionImage;

    void Start()
    {
        StartCoroutine(SendRequest());

        WeatherImg_new = WeatherImg_newObj.GetComponent<Image>();
    }

    IEnumerator SendRequest()
    {
        //get the players IP, City, Country
        Network.Connect("http://google.com");
        currentIP = Network.player.externalIP;
        Network.Disconnect();

        WWW cityRequest = new WWW("http://www.geoplugin.net/json.gp?ip=" + currentIP); //get our location info
        yield return cityRequest;

        if (cityRequest.error == null || cityRequest.error == "")
        {
            var N = JSON.Parse(cityRequest.text);
            currentCity = N["geoplugin_city"].Value;
            currentCountry = N["geoplugin_countryName"].Value;
        }

        else
        {
            Debug.Log("WWW error: " + cityRequest.error);
        }

        //get the current weather
        WWW request = new WWW("http://api.openweathermap.org/data/2.5/weather?q=" + currentCity + APPID); //get our weather
        yield return request;

        if (request.error == null || request.error == "")
        {
            var N = JSON.Parse(request.text);

            retrievedCountry = N["sys"]["country"].Value; //get the country
            retrievedCity = N["name"].Value; //get the city

            string temp = N["main"]["temp"].Value; //get the temperature
            float tempTemp; //variable to hold the parsed temperature
            float.TryParse(temp, out tempTemp); //parse the temperature
            float finalTemp = Mathf.Round((tempTemp - 273.0f) * 10) / 10; //holds the actual converted temperature

            int.TryParse(N["weather"][0]["id"].Value, out conditionID); //get the current condition ID
            //conditionName = N["weather"][0]["main"].Value; //get the current condition Name
            conditionName = N["weather"][0]["description"].Value; //get the current condition Description
            conditionImage = N["weather"][0]["icon"].Value; //get the current condition Image

            //put all the retrieved stuff in the label
            myWeatherLabel.text =
                "Country: " + retrievedCountry
                + "\n" + retrievedCity //City
                + "\n" + finalTemp + " C" //\nTemperature: 
                + "\n" + conditionName;   //"\nCurrent Condition: "
                                          // + "\nCondition Code: " + conditionID;
            onlyWeatherCondition.text = conditionName;
            if (conditionID >= 200 && conditionID <= 232 )
            {
                WeatherImg_new.color = new Color(255f, 255f, 255f, 255f);
                weatherTxtImg.color = new Color(255f, 255f, 255f, 255f);
                WeatherImg_new.material = ThunderStorm.material;
                weatherTxtImg.material = ThunderStormtxt.material;


            }
            else if (conditionID >= 300 && conditionID <= 321)
            {
                WeatherImg_new.color = new Color(255f, 255f, 255f, 255f);
                weatherTxtImg.color = new Color(255f, 255f, 255f, 255f);
                WeatherImg_new.material = Drizzle.material;
                weatherTxtImg.material = Drizzletxt.material;
            }
            else if (conditionID >= 500 && conditionID <= 531)
            {
                WeatherImg_new.color = new Color(255f, 255f, 255f, 255f);
                weatherTxtImg.color = new Color(255f, 255f, 255f, 255f);
                WeatherImg_new.material = Rain.material;
                weatherTxtImg.material = Raintxt.material;
            }
            else if (conditionID >= 600 && conditionID <= 622)
            {
                WeatherImg_new.color = new Color(255f, 255f, 255f, 255f);
                weatherTxtImg.color = new Color(255f, 255f, 255f, 255f);
                WeatherImg_new.material = Snow.material;
                weatherTxtImg.material = Snowtxt.material;
            }
            else if (conditionID >= 701 && conditionID <= 781)
            {
                WeatherImg_new.color = new Color(255f, 255f, 255f, 255f);
                weatherTxtImg.color = new Color(255f, 255f, 255f, 255f);
                WeatherImg_new.material = Atmosphere.material;
                weatherTxtImg.material = Atmospheretxt.material;
            }
            else if (conditionID == 800)
            {
                WeatherImg_new.color = new Color(255f, 255f, 255f, 255f);
                weatherTxtImg.color = new Color(255f, 255f, 255f, 255f);
                WeatherImg_new.material = Clear.material;
                weatherTxtImg.material = Cleartxt.material;
            }
            else if (conditionID >= 801 && conditionID <= 804)
            {
                WeatherImg_new.color = new Color(255f, 255f, 255f, 255f);
                weatherTxtImg.color = new Color(255f, 255f, 255f, 255f);
                WeatherImg_new.material = clouds.material;
                weatherTxtImg.material = cloudstxt.material;
            }
        }
        else
        {
            Debug.Log("WWW error: " + request.error);
        }

        //get our weather image
        WWW conditionRequest = new WWW("http://openweathermap.org/img/w/" + conditionImage + ".png");
        yield return conditionRequest;

        if (conditionRequest.error == null || conditionRequest.error == "")
        {
            //create the material, put in the downloaded texture and make it visible
            var texture = conditionRequest.texture;
            Shader shader = Shader.Find("Unlit/Transparent");
            if (shader != null)
            {
                var material = new Material(shader);
                material.mainTexture = texture;
                myWeatherCondition = texture;
                //waetherimg.material = material;
          //    myWeatherCondition.color = Color.white;
          //    myWeatherCondition.MakePixelPerfect();
            }
        }
        else
        {
            Debug.Log("WWW error: " + conditionRequest.error);
        }
    }
}