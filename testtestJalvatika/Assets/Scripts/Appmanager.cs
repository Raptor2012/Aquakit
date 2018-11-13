using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Globalization;


public class Appmanager : MonoBehaviour {

    public string signUpMenu;
    public string languageselectionMenu;
    public string homeMenu;
    public string profileMenu;

    public GameObject weatherDropButton;
    public Animator animC;
    public Animator animArrow;
    private bool dowpdownIsactivated;

    public InputField newPassIF;
    public InputField confirmPass;
    public InputField LoginPass;
    public InputField DistrictIF;
    public InputField AddressIF;

    public Text date;

   // public GameObject shakepassword;
    public Text slidingprofilename;
    public GameObject dropdownLabel;
    public Text addressPlaceholder;
    public Text pincodePlaceholder;
    public Text districtPlaceholder;
    public Text namePlaceholder;
    public Text phonePlaceholder;
    public Text newPassPlaceholder;
    public Text confirmPassPlaceholder;
    public Text LoginEnter1;
    public Text EnterPassword1;
    public Text EnterName;
    public Text EnterLastName;
    public Text EnterLastNamePlaceholder;
    public Text EnterPhone;
    public Text EnterNewPass;
    public Text ConfirmPass;
    public Text FullNameLocked;
    public Text PhoneLocked;
    public Text Pincode;
    public Text District;
    public Text Address;
    public Text passwordsmatch;
    public Dropdown stateDropdown;
    private string storename;
    private string storelastName;
    private string storephone;

    public Image oceanClip_top;
    public float OTopSpeed;
    public Image oceanClip_Mid;
    public float OMidSpeed;
    public Image oceanClip_Bot;
    public float OBotSpeed;

    public GameObject slidingProfile;
    public GameObject slidingprofilePos;
    public GameObject slidingprofileoripos;
    private bool slidingmenuActive;

    public Text profileName;
    public Text profilePhone;
    public Text profileAddress;
    public Text profilePincode;

    public GameObject tapToGoToProfile;

    public GameObject pagepivot;
    public GameObject splashdestroy;
    public GameObject pos1;
    public GameObject pos2;
    private Transform pos1T;
    private Transform pos2T;
    private float pos1float;
    private float pos2float;

    private string Namefull;
    private string PhoneFull;
    private string PincodeFull;
    private string DistrictFull;
    private string adressHalftext;
    private GameObject slidebackButton;
    private string curScene;
    private string lastScene;

    private InputFieldMovement inptfldScript;

    private float LengthPond;
    private float BreadthPond;
    private float DepthPond;

    private bool isHectare;
    private bool isAcre;
    private bool isDecimal;
    private bool isGunta;
    private bool isBigha;
    private bool isKattha;
    private bool isSqMetre;
    private bool isSqFeet;

    public Text LengthText;
    public Text BreadthText;
    public Text WaterAvailabilityText;
    public Text AreaText;
    public Dropdown LengthUnit;
    public Dropdown BreadthUnit;
    public Dropdown AreaUnit;
    public Text selectedAreaUnit;
    public Text selectedLengthnUnit;
    public Text selectedBreadthUnit;

    public GameObject NurseryButton;
    public GameObject RearingButton;
    public GameObject GrowOutButtonFry;
    public GameObject GOBFingerling;

    public Text cowDungText;
    public Text TDysUrea;
    public Text TDysSSP;
    public Text TDysCowDung;
    public Text TDysOilCake;
    public Text SDysUrea;
    public Text SDysSSP;
    public Text SDysCowDung;
    public Text SDysOilCake;
    public Text TTYDysUrea;
    public Text TTYDysSSP;
    public Text TTYDysCowDung;
    public Text TTYDysOilCake;

    public Text LimeKGStxt;
    public Text SuitableDepthText;
    public Text SuitableTempratureText;
    public Text BleachingPowderText;


    public Button resetAreaButton;
    public InputField areaInputField;


    List<string> Areaunits = new List<string>() { "माप", "Hectare", "Acre", "Decimal", "Gunta", "Bigha", "Kattha", "Square Metre", "Square Feet" };
    List<string> Dimensionunits = new List<string>() {"Select Units", "Metre", "Feet" };
    List<string> SelectedState = new List<string>() { "Select State", "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal" };
    

    private float Length;
    private float Breadth;
    private float WaterAvailability;
    private float Area;
    private float convertedAreaF;
    private float AreaFloat;
    private int mDropdownValue_val = 0;

    private Camera maincamera;



    private void Awake()
    {
        if (splashdestroy != null)
        {
            Destroy(splashdestroy, 5f);
        }
        if (maincamera == null)
        {
           maincamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            maincamera.backgroundColor = Color.black;
        }
    }

    // Use this for initialization
    void Start () {

        
        curScene = SceneManager.GetActiveScene().name;

        Screen.fullScreen = false;
        if (curScene == "HomeScene 1")
        {
            //  if (LengthUnit != null && BreadthUnit != null)
            //  {
            //      LengthUnit.AddOptions(Dimensionunits);
            //      BreadthUnit.AddOptions(Dimensionunits);
            // AreaUnit.AddOptions(Areaunits);
            populateAreaList();
           // }
        }
        if (curScene == "LogInScene2")
        {
            pos1T = pos1.transform;
            pos2T = pos2.transform;
            pos1float = pos1T.transform.position.x;
            inptfldScript = this.gameObject.GetComponent<InputFieldMovement>();
            inptfldScript.enabled = false;
        }
        if (curScene == "SetPasswordScene")
        {
            inptfldScript = this.gameObject.GetComponent<InputFieldMovement>();
            inptfldScript.enabled = false;
            populateStateList();
        }
        if (curScene == "credentialsenter")
        {
            inptfldScript = this.gameObject.GetComponent<InputFieldMovement>();
            inptfldScript.enabled = false;
            storename = PlayerPrefs.GetString("Name");
            storephone = PlayerPrefs.GetString("Phone");
            FullNameLocked.text = storename;
            PhoneLocked.text = storephone;
        }
        if (curScene == "HomeScene")
        {
            dowpdownIsactivated = false;
            slidingmenuActive = false;
            slidebackButton = GameObject.Find("Slidingmenuclose");
            slidebackButton.SetActive(false);
            string localdate;
            localdate = System.DateTime.Now.ToShortDateString();
            date.text = localdate;


            if (slidingprofilename != null)
            {
                if (PlayerPrefs.HasKey("Name") == true)
                {
                    slidingprofilename.text = PlayerPrefs.GetString("Name");
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (oceanClip_top != null)
        {
            Vector2 offset = new Vector2(Time.time * OTopSpeed, 0);
            oceanClip_top.material.mainTextureOffset = offset;
        }
        if (oceanClip_Mid != null)
        {
            Vector2 offset2 = new Vector2(Time.time * OMidSpeed, 0);
            oceanClip_Mid.material.mainTextureOffset = offset2;
        }
        if (oceanClip_Bot != null)
        {
            Vector2 offset3 = new Vector2(Time.time * OBotSpeed, 0);
            oceanClip_Bot.material.mainTextureOffset = offset3;
        }

        
      if (curScene == "LogInScene2")
        {
           


                

            
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("LogInScene2");
            }
            if (LoginPass != null)
            {
                if (LoginPass.isFocused == true)
                {
                    inptfldScript.enabled = true;
                }
                else
                {
                    inptfldScript.enabled = false;
                }
            }
        }



        if (curScene == "credentialsenter")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("SetPasswordScene");
            }
            if (DistrictIF != null)
            {
                if (DistrictIF.isFocused == true || AddressIF.isFocused == true)
                {
                    inptfldScript.enabled = true;
                }
                else
                {
                    inptfldScript.enabled = false;
                }
            }

            if (AddressIF != null)
            {
                if (AddressIF.isFocused == true || DistrictIF.isFocused == true)
                {
                    inptfldScript.enabled = true;
                }
                else
                {
                    inptfldScript.enabled = false;
                }
            }


        }

        if (curScene == "SetPasswordScene")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("LogInScene2");
            }
            if (newPassIF != null)
            {
                if (newPassIF.isFocused == true || confirmPass.isFocused == true)
                {
                    inptfldScript.enabled = true;
                }
                else
                {
                    inptfldScript.enabled = false;
                }
            }
            if (confirmPass != null)
            {
                if (confirmPass.isFocused == true || newPassIF.isFocused == true)
                {
                    inptfldScript.enabled = true;
                }
                else
                {
                    inptfldScript.enabled = false;
                }
            }

            if (EnterNewPass.text == null)
            {
                passwordsmatch.text = null;
            }
            if (EnterNewPass.text != ConfirmPass.text && EnterNewPass.text != null && ConfirmPass.text != null)
            {
                if (confirmPass != null)
                {
                    if (confirmPass.isFocused == true && ConfirmPass.text != "")
                    {
                        passwordsmatch.color = Color.red;
                        passwordsmatch.text = "Passwords don't Match!";
                    }
                }
            }
            else if (EnterNewPass.text != "" && ConfirmPass.text != "")
            {
                if (EnterNewPass.text == ConfirmPass.text)
                {
                    Color darkgreen = new Color(0f, 0.54f, 0f);
                    passwordsmatch.color = darkgreen;
                    passwordsmatch.text = "Passwords Match!";
                }
                
            }

            
        }
        else if (curScene == "HomeScene")
        {
            if (tapToGoToProfile != null)
            {
                Destroy(tapToGoToProfile, 2.5f);
            }
            if (slidingmenuActive == true)
            {
                //slidebackButton = GameObject.Find("Slidingmenuclose");
                slidebackButton.SetActive(true);
            }
            else
            {
               // slidebackButton = GameObject.Find("Slidingmenuclose");
                slidebackButton.SetActive(false);
            }
        }
        else if (curScene == "ProfileScene")
        {

          profileName.text =  PlayerPrefs.GetString("Name");
         profilePhone.text =   PlayerPrefs.GetString("Phone");
         profilePincode.text =   PlayerPrefs.GetString("Pincode");
          profileAddress.text = PlayerPrefs.GetString("AddressHalf");
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("HomeScene");
            }

        } else if (curScene == "ProfileScene 1")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("HomeScene");
            }
        }
        else if (curScene == "ProfileScene 2")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("ProfileScene 1");
            }
        }
        else if (curScene == "ProfileScene 3")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("HomeScene");
            }
        }
        else if (curScene == "ProfileScene 4")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("ProfileScene 1");
            }
        }
        else if (curScene == "ProfileScene 5")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("ProfileScene 3");
            }
        }
        else if (curScene == "ProfileScene 6")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("ProfileScene 3");
            }
        } else if (curScene == "HomeScene 1")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("HomeScene");
            }

            

        }


    }           

    public void OnClickEnglish()
    {
        SceneManager.LoadScene(signUpMenu);
    }

    public void OnClickContinueOne()
    {
        SceneManager.LoadScene("SetPasswordScene");
        // pagepivot.transform.DOLocalMoveX(pos1T.position.x, 0.2f, false);
    }

    public void OnClickContinueTwo()
    {
        if (EnterNewPass.text == ConfirmPass.text && EnterNewPass.text != "" && ConfirmPass.text != "" && EnterName.text != "" && EnterPhone.text != "" && District.text != "" && EnterLastName.text != "" && stateDropdown.GetComponentInChildren<Text>().text != "Select State")
        {

            storename = EnterName.text;
            storephone = EnterPhone.text;
            storelastName = EnterLastName.text;
            PlayerPrefs.SetString("Password", ConfirmPass.text);
            PlayerPrefs.SetString("Name", storename);
            PlayerPrefs.SetString("LastName", storelastName);
            PlayerPrefs.SetString("Phone", storephone);
            PlayerPrefs.SetString("District", District.text);
            PlayerPrefs.SetString("State", stateDropdown.GetComponentInChildren<Text>().text);

            Namefull = PlayerPrefs.GetString("Name");
            if (Namefull != null)
            {
                PlayerPrefs.SetString("LOGINCHECK", "1");
            }
            // pagepivot.transform.DOLocalMoveX(pos2T.position.x, 0.2f, false);
            SceneManager.LoadScene("HomeScene");
        } else if (EnterNewPass.text == "" || ConfirmPass.text == "" || EnterName.text == "" || EnterPhone.text == "" || District.text == "" || EnterLastName.text == "" || stateDropdown.GetComponentInChildren<Text>().text == "Select State")
        {
            if (EnterName.text == "")
            {
                namePlaceholder.text = "Enter Name*";
                namePlaceholder.color = Color.red;
                namePlaceholder.gameObject.GetComponent<Transform>().DOShakePosition(1, 2, 10, 90, false);
            }

            if (EnterPhone.text == "")
            {
                phonePlaceholder.text = "Phone No.*";
                phonePlaceholder.color = Color.red;
                phonePlaceholder.gameObject.GetComponent<Transform>().DOShakePosition(1, 2, 10, 90, false);
            }

            if (EnterNewPass.text == "")
            {
                
                newPassPlaceholder.color = Color.red;
                newPassPlaceholder.gameObject.GetComponent<Transform>().DOShakePosition(1, 2, 10, 90, false);
            }

            if (ConfirmPass.text == "")
            {
                
                confirmPassPlaceholder.color = Color.red;
                confirmPassPlaceholder.gameObject.GetComponent<Transform>().DOShakePosition(1, 2, 10, 90, false);
            }

            if (EnterLastName.text == "")
            {
                EnterLastNamePlaceholder.color = Color.red;
                EnterLastNamePlaceholder.gameObject.GetComponent<Transform>().DOShakePosition(1, 2, 10, 90, false);
            }

            if (District.text == "")
            {
                districtPlaceholder.color = Color.red;
                districtPlaceholder.text = "District*";
                districtPlaceholder.gameObject.GetComponent<Transform>().DOShakePosition(1, 2, 10, 90, false);
            }
            if (stateDropdown.GetComponentInChildren<Text>().text == "Select State")
            {
                stateDropdown.GetComponentInChildren<Text>().color = Color.red;
                if (dropdownLabel != null)
                {
                    dropdownLabel.gameObject.GetComponent<Transform>().DOShakePosition(1, 2, 10, 90, false);
                }

            }

        }

        if (EnterNewPass.text != ConfirmPass.text)
        {
            passwordsmatch.GetComponent<Transform>().DOShakePosition(1, 2, 10, 90, false);
        }
    }

    public void OnClickContinueThree()
    {

      //  pagepivot.transform.DOLocalMoveX(-135.87f, 0.2f, false);
    }

    public void OnClickContinuefour()
    {
        if (Address.text != "" && Pincode.text != "" && District.text != "" && stateDropdown.GetComponentInChildren<Text>().text != "Select State")
        {
         //  PlayerPrefs.SetString("Name", storename);
         //  PlayerPrefs.SetString("Phone", storephone);
            PlayerPrefs.SetString("Pincode", Pincode.text);
            PlayerPrefs.SetString("District", District.text);
            PlayerPrefs.SetString("State", stateDropdown.GetComponentInChildren<Text>().text);
            PlayerPrefs.SetString("AddressHalf", Address.text);

            Namefull = PlayerPrefs.GetString("Name");

            PhoneFull = PlayerPrefs.GetString("Phone");
            PincodeFull = PlayerPrefs.GetString("Pincode");
            DistrictFull = PlayerPrefs.GetString("District");
            adressHalftext = PlayerPrefs.GetString("AddressHalf");
            if (Namefull != null)
            {
                PlayerPrefs.SetString("LOGINCHECK", "1");
            }

            SceneManager.LoadScene(homeMenu);

        } else if (Address.text == "" || Pincode.text == "" || District.text == "" || stateDropdown.GetComponentInChildren<Text>().text == "Select State")
        {
            if (Address.text == "")
            {
                addressPlaceholder.color = Color.red;
                addressPlaceholder.text = "Address*";
                addressPlaceholder.gameObject.GetComponent<Transform>().DOShakePosition(1, 2, 10, 90, false);
            }

            if (Pincode.text == "")
            {
                pincodePlaceholder.color = Color.red;
                pincodePlaceholder.text = "Pincode*";
                pincodePlaceholder.gameObject.GetComponent<Transform>().DOShakePosition(1, 2, 10, 90, false);
            }
            if (District.text == "")
            {
                districtPlaceholder.color = Color.red;
                districtPlaceholder.text = "District*";
                districtPlaceholder.gameObject.GetComponent<Transform>().DOShakePosition(1, 2, 10, 90, false);
            }
            if (stateDropdown.GetComponentInChildren<Text>().text == "Select State")
            {
                stateDropdown.GetComponentInChildren<Text>().color = Color.red;
                if (dropdownLabel != null)
                {
                    dropdownLabel.gameObject.GetComponent<Transform>().DOShakePosition(1, 2, 10, 90, false);
                }
                
            }

        }
    }

    public void OnClickProfileButton()
    {
        SceneManager.LoadScene(profileMenu);
    }

    public void OnClickSignOut()
    {
        //PlayerPrefs.SetString("Name", "");
        // PlayerPrefs.SetString("Password", "");
        // PlayerPrefs.SetString("Phone", "");
        // PlayerPrefs.SetString("Pincode", "");
        // PlayerPrefs.SetString("District", "");
        // PlayerPrefs.SetString("AddressHalf", "");
        PlayerPrefs.SetString("LOGINCHECK", "0");
        SceneManager.LoadScene(languageselectionMenu);
    }

    public void OnClickSignIn()
    {
        if (LoginEnter1.text != "" && EnterPassword1.text != "")
        {
            if (LoginEnter1.text == PlayerPrefs.GetString("Name") && EnterPassword1.text == PlayerPrefs.GetString("Password"))
            {
                SceneManager.LoadScene(homeMenu);
            }
        }
    }

    public void OnClickProfileHomeMenu()
    {
        if (curScene == "HomeScene")
        {
            if (slidingprofilePos != null)
            {
                slidingProfile.transform.DOMoveX(slidingprofilePos.transform.position.x, 0.35f, false);
                if (slidingmenuActive != true)
                {
                    slidingmenuActive = true;
                }
            }
        }
    }

    public void OnClickCloseProfileHomeMenu()
    {
        if (curScene == "HomeScene")
        {
            
                slidingProfile.transform.DOLocalMoveX(slidingprofileoripos.transform.position.x, 0.35f, false);
                slidingmenuActive = false;
            
        }
    }

    public void OnClickAdvisory()
    {
        if (curScene != "ProfileScene 1")
        {

            SceneManager.LoadScene("ProfileScene 1");

        }
    }

    public void OnClickDisease()
    {
        

            SceneManager.LoadScene("DiseasesMain");

        
    }

    public void OnClickDiseaseandPrevention()
    {
        if (curScene == "HomeScene")
        {

            SceneManager.LoadScene("ProfileScene 3");

        }
    }

    public void OnClickMachliRog()
    {
        if (curScene == "ProfileScene 3")
        {

            SceneManager.LoadScene("ProfileScene 5");

        }
    }

    public void OnClickcommonProblems()
    {
        if (curScene == "ProfileScene 3")
        {

            SceneManager.LoadScene("ProfileScene 6");

        }
    }

    public void OnClickBackToHome()
    {
        

            SceneManager.LoadScene("HomeScene");

        
    }

    public void OnClickTaalabTaiyari()
    {
        if (curScene == "ProfileScene 1")
        {

            SceneManager.LoadScene("ProfileScene 2");

        }
    }

    public void OnClickSpawnCollection()
    {
        if (curScene == "ProfileScene 1")
        {

            SceneManager.LoadScene("ProfileScene 4");

        }
    }

    public void backToSignup()
    {
        if (curScene == "SetPasswordScene")
        {
            SceneManager.LoadScene("LogInScene2");
        }
    }

    public void backtoProfile1()
    {
        SceneManager.LoadScene("ProfileScene 1");
    }

    public void backtoProfile2()
    {
        SceneManager.LoadScene("ProfileScene 2");
    }

    public void backtoProfile3()
    {
        SceneManager.LoadScene("ProfileScene 3");
    }

    public void backtoProfile4()
    {
        SceneManager.LoadScene("ProfileScene 4");
    }

    public void backtoProfile5()
    {
        SceneManager.LoadScene("ProfileScene 5");
    }

    public void backtoProfile6()
    {
        SceneManager.LoadScene("ProfileScene 6");
    }
    public void GotoWeather()
    {
        SceneManager.LoadScene("WeatherScene");
    }

    public void doropDownWeather()
    {
       if (dowpdownIsactivated == false)
       {
            animC.Play("BotBoxContainer_activated");
            animArrow.Play("DropdownButton_turned");
            

           dowpdownIsactivated = true;
       } else
       {
            animC.Play("BotBoxContainer_deactivated");
            animArrow.Play("DropdownButton_unturned");

            dowpdownIsactivated = false;
       }
    }

    public float sqmetreconvFromHectare( float inputN)
    {
        inputN = inputN * 10000f;

        return inputN;
    }

    public float HectareFromSqmetre(float inputN)
    {
        inputN = inputN / 10000f;

        return inputN;
    }

    public void CalculateArea ()
    {
     //if (LengthText.text != "" || BreadthText.text != "")
     //{
     //    Length = float.Parse(LengthText.text, CultureInfo.InvariantCulture);
     //    Breadth = float.Parse(BreadthText.text, CultureInfo.InvariantCulture);
     //
     //}
     //
     //float area1 = Length * Breadth;
     //Debug.Log(area1);
     //AreaText.text = area1.ToString();
    }
    public void SaveDimensions()
    {
        if (LengthText.text != "" || BreadthText.text != "")
        {
            //    Length = float.Parse(LengthText.text, CultureInfo.InvariantCulture);
            //    Breadth = float.Parse(BreadthText.text, CultureInfo.InvariantCulture);

            if (selectedLengthnUnit.text == "Metre" && selectedBreadthUnit.text == "Metre")
            {
                Length = float.Parse(LengthText.text, CultureInfo.InvariantCulture);
                float templength = Length;
                Length = templength * 10.7693f;

                Breadth = float.Parse(BreadthText.text, CultureInfo.InvariantCulture);
                float tempbreadth = Length;
                Breadth = tempbreadth * 10.7693f;
                PlayerPrefs.SetFloat("PondLength", Length);
                PlayerPrefs.SetFloat("PondBreadth", Breadth);
            }
            else if (selectedLengthnUnit.text == "Feet" && selectedBreadthUnit.text == "Feet")
            {
                Length = float.Parse(LengthText.text, CultureInfo.InvariantCulture);


                Breadth = float.Parse(BreadthText.text, CultureInfo.InvariantCulture);
                PlayerPrefs.SetFloat("PondLength", Length);
                PlayerPrefs.SetFloat("PondBreadth", Breadth);
            }



        }

    }


    public void saveWaterAvailability()
    {
        WaterAvailability = float.Parse(WaterAvailabilityText.text, CultureInfo.InvariantCulture);
        float waterAvailabilityFloat = WaterAvailability;
        if (WaterAvailabilityText.text != "") {
            if (waterAvailabilityFloat > 0 && waterAvailabilityFloat < 12)
            {
                PlayerPrefs.SetFloat("WaterAvailability", waterAvailabilityFloat);
            }
        }
    }


    public void SaveArea()
    {
        if (LengthText.text != "" || BreadthText.text != "")
        {
      //    Length = float.Parse(LengthText.text, CultureInfo.InvariantCulture);
      //    Breadth = float.Parse(BreadthText.text, CultureInfo.InvariantCulture);

            if (selectedLengthnUnit.text == "Metre" && selectedBreadthUnit.text == "Metre")
            {
                Length = float.Parse(LengthText.text, CultureInfo.InvariantCulture);
                float templength = Length;
                Length = templength * 10.7693f;
               
                Breadth = float.Parse(BreadthText.text, CultureInfo.InvariantCulture);
                float tempbreadth = Length;
                Breadth = tempbreadth * 10.7693f;
                PlayerPrefs.SetFloat("PondLength", Length);
                PlayerPrefs.SetFloat("PondBreadth", Breadth);
            } else if  (selectedLengthnUnit.text == "Feet" && selectedBreadthUnit.text == "Feet")
                {
                    Length = float.Parse(LengthText.text, CultureInfo.InvariantCulture);
                    

                    Breadth = float.Parse(BreadthText.text, CultureInfo.InvariantCulture);
                PlayerPrefs.SetFloat("PondLength", Length);
                PlayerPrefs.SetFloat("PondBreadth", Breadth);
            }

            

        }
     //   float area1 = Length * Breadth;
        
        if (selectedAreaUnit.text == "Hectare")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);

        }
        else if (selectedAreaUnit.text == "Acre")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 0.404686f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }
        else if (selectedAreaUnit.text == "Decimal")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 0.00404686f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }
        else if (selectedAreaUnit.text == "Gunta")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 0.01f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }
        else if (selectedAreaUnit.text == "Bigha")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 0.25f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }
        else if (selectedAreaUnit.text == "Kattha")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 0.0125f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }
        else if (selectedAreaUnit.text == "Square Metre")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 0.0001f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }
        else if (selectedAreaUnit.text == "Square Feet")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 9.2903e-6f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }

        //  Debug.Log(area1);
        //asdasfdsafsdfdsfdsfsdfdsfdsfsdf  AreaText.text = area1.ToString();
    }

    public void Dropdown_IndexChangedArea(int index)
    {
        selectedAreaUnit.text = Areaunits[index];
    }

    public void Dropdown_IndexChangedLength(int index)
    {
       // selectedLengthnUnit.text = Dimensionunits[index];
        selectedLengthnUnit.text = Dimensionunits[index];
    }

    public void Dropdown_IndexChangedBreadth(int index)
    {
      //  selectedLengthnUnit.text = Dimensionunits[index];
        selectedBreadthUnit.text = Dimensionunits[index];
    }
    public void Dropdown_IndexChangedState(int index)
    {
        //  selectedLengthnUnit.text = Dimensionunits[index];
       // SelectedState.text = Dimensionunits[index];
    }


    public void ConfirmArea()
    {


    
        //   float area1 = Length * Breadth;

        if (selectedAreaUnit.text == "Hectare")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);

        }
        else if (selectedAreaUnit.text == "Acre")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 0.404686f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }
        else if (selectedAreaUnit.text == "Decimal")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 0.00404686f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }
        else if (selectedAreaUnit.text == "Gunta")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 0.01f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }
        else if (selectedAreaUnit.text == "Bigha")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 0.25f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }
        else if (selectedAreaUnit.text == "Kattha")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 0.0125f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }
        else if (selectedAreaUnit.text == "Square Metre")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 0.0001f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }
        else if (selectedAreaUnit.text == "Square Feet")
        {
            Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
            float tempArea = Area;
            Area = tempArea * 9.2903e-6f;
            PlayerPrefs.SetFloat("ConvertedPondArea", Area);
        }

        //    convertedAreaF = 

        //   Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
        
        float AreaFloat = Area;
        AreaFloat = PlayerPrefs.GetFloat("ConvertedPondArea");
        if (AreaText.text != "")
        {
            if (Area > 0)
            {
                convertedAreaF = AreaFloat;
                if (convertedAreaF >= 0.01f && convertedAreaF <= 0.04f)
                {
                    if (NurseryButton != null)
                    {
                        NurseryButton.GetComponent<Image>().enabled = true;
                        RearingButton.GetComponent<Image>().enabled = false;
                        GrowOutButtonFry.GetComponent<Image>().enabled = false;
                        GOBFingerling.GetComponent<Image>().enabled = false;

                        NurseryButton.GetComponentInChildren<Text>().enabled = true;
                        RearingButton.GetComponentInChildren<Text>().enabled = false;
                        GrowOutButtonFry.GetComponentInChildren<Text>().enabled = false;
                        GOBFingerling.GetComponentInChildren<Text>().enabled = false;
                        // NurseryButton.GetComponent<Image>().color = Color.green;
                        NurseryButton.GetComponent<Button>().enabled = true;
                        GrowOutButtonFry.GetComponent<Button>().enabled = false;
                        GOBFingerling.GetComponent<Button>().enabled = false;
                       
                        RearingButton.GetComponent<Button>().enabled = false;
                        SuitableDepthText.text = "0.05-1.2 mt";
                        SuitableTempratureText.text = "20-30";
                        float cowdunginKGs = convertedAreaF * 500;
                        cowDungText.text = convertedAreaF.ToString();

                        float bleachingPowderKG = convertedAreaF * 350;
                        BleachingPowderText.text = bleachingPowderKG.ToString();


                        float threedaysUrea = convertedAreaF * 12.5f;
                        TDysUrea.text = threedaysUrea.ToString();

                        float threedaysSSP = convertedAreaF * 12.5f;
                        TDysSSP.text = threedaysSSP.ToString();

                        float threedaysCD = convertedAreaF * 50f;
                        TDysCowDung.text = threedaysCD.ToString();

                        float threedaysOC = convertedAreaF * 100f;
                        TDysOilCake.text = threedaysOC.ToString();

                        float sevendaysUrea = convertedAreaF * 12.5f;
                        TDysUrea.text = sevendaysUrea.ToString();

                        float sevendaysSSP = convertedAreaF * 12.5f;
                        TDysSSP.text = sevendaysSSP.ToString();

                        float sevendaysCD = convertedAreaF * 50f;
                        TDysCowDung.text = sevendaysCD.ToString();

                        float sevendaysOC = convertedAreaF * 100f;
                        TDysOilCake.text = sevendaysOC.ToString();
                    }
                    
                } else if (convertedAreaF > 0.04f && convertedAreaF <= 0.5f)
                {
                    if (RearingButton != null)
                    {
                        NurseryButton.GetComponent<Image>().enabled = false;
                        RearingButton.GetComponent<Image>().enabled = true;
                        GrowOutButtonFry.GetComponent<Image>().enabled = false;
                        GOBFingerling.GetComponent<Image>().enabled = false;

                        NurseryButton.GetComponentInChildren<Text>().enabled = false;
                        RearingButton.GetComponentInChildren<Text>().enabled = true;
                        GrowOutButtonFry.GetComponentInChildren<Text>().enabled = false;
                        GOBFingerling.GetComponentInChildren<Text>().enabled = false;
                        // RearingButton.GetComponent<Image>().color = Color.green;
                        GrowOutButtonFry.GetComponent<Button>().enabled = false;
                        GOBFingerling.GetComponent<Button>().enabled = false;
                        NurseryButton.GetComponent<Button>().enabled = false;
                        RearingButton.GetComponent<Button>().enabled = true;
                        SuitableDepthText.text = "1 mt -2 mt";
                        SuitableTempratureText.text = "20-35";
                        float cowdunginKGs = convertedAreaF * 500;
                        cowDungText.text = convertedAreaF.ToString();

                        BleachingPowderText.text = "Not Reqired";

                        float threedaysUrea = convertedAreaF * 12.5f;
                        TDysUrea.text = threedaysUrea.ToString();

                        float threedaysSSP = convertedAreaF * 12.5f;
                        TDysSSP.text = threedaysSSP.ToString();

                        float threedaysCD = convertedAreaF * 50f;
                        TDysCowDung.text = threedaysCD.ToString();

                        float threedaysOC = convertedAreaF * 100f;
                        TDysOilCake.text = threedaysOC.ToString();

                        float sevendaysUrea = convertedAreaF * 12.5f;
                        SDysUrea.text = sevendaysUrea.ToString();

                        float sevendaysSSP = convertedAreaF * 12.5f;
                        SDysSSP.text = sevendaysSSP.ToString();

                        float sevendaysCD = convertedAreaF * 50f;
                        SDysCowDung.text = sevendaysCD.ToString();

                        float sevendaysOC = convertedAreaF * 100f;
                        SDysOilCake.text = sevendaysOC.ToString();



                        float thirtydaysUrea = convertedAreaF * 12.5f;
                        TTYDysUrea.text = thirtydaysUrea.ToString();

                        float thirtydaysSSP = convertedAreaF * 12.5f;
                        TTYDysSSP.text = thirtydaysSSP.ToString();

                        float thirtydaysCD = convertedAreaF * 50f;
                        TTYDysCowDung.text = thirtydaysCD.ToString();

                        float thirtydaysOC = convertedAreaF * 100f;
                        TTYDysOilCake.text = thirtydaysOC.ToString();
                    }
                }
                else if (convertedAreaF > 0.5f && convertedAreaF <= 5f)
                {
                    NurseryButton.GetComponent<Image>().enabled = false;
                    RearingButton.GetComponent<Image>().enabled = false;
                    GrowOutButtonFry.GetComponent<Image>().enabled = true;
                    GOBFingerling.GetComponent<Image>().enabled = true;

                    NurseryButton.GetComponentInChildren<Text>().enabled = false;
                    RearingButton.GetComponentInChildren<Text>().enabled = false;
                    GrowOutButtonFry.GetComponentInChildren<Text>().enabled = true;
                    GOBFingerling.GetComponentInChildren<Text>().enabled = true;

                    // GrowOutButtonFry.GetComponent<Image>().color = Color.green;
                  //  GOBFingerling.GetComponent<Image>().color = Color.green;
                    GrowOutButtonFry.GetComponent<Button>().enabled = true;
                    GOBFingerling.GetComponent<Button>().enabled = true;
                    NurseryButton.GetComponent<Button>().enabled = false;
                    RearingButton.GetComponent<Button>().enabled = false;


                }
                else if (convertedAreaF > 5f)
                {
                    NurseryButton.GetComponent<Image>().enabled = false;
                    RearingButton.GetComponent<Image>().enabled = false;
                    GrowOutButtonFry.GetComponent<Image>().enabled = false;
                    GOBFingerling.GetComponent<Image>().enabled = true;

                    NurseryButton.GetComponentInChildren<Text>().enabled = false;
                    RearingButton.GetComponentInChildren<Text>().enabled = false;
                    GrowOutButtonFry.GetComponentInChildren<Text>().enabled = false;
                    GOBFingerling.GetComponentInChildren<Text>().enabled = true;
                    //GrowOutButtonFry.GetComponent<Image>().color = Color.green;
                    //GOBFingerling.GetComponent<Image>().color = Color.green;
                    GrowOutButtonFry.GetComponent<Button>().enabled = false;
                    GOBFingerling.GetComponent<Button>().enabled = true;
                    NurseryButton.GetComponent<Button>().enabled = false;
                    RearingButton.GetComponent<Button>().enabled = false;

                    
                }
                

            }
        }
    }
    
    public void GrowOutFryButton()
    {
        // RearingButton.GetComponent<Image>().color = Color.green;
        // RearingButton.GetComponent<Button>().enabled = true;
        SuitableDepthText.text = "2-2.5 mt";
        SuitableTempratureText.text = "20-35";
       // Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
        AreaFloat = PlayerPrefs.GetFloat("ConvertedPondArea");
        convertedAreaF = AreaFloat;
        float cowdunginKGs = convertedAreaF * 500;
        cowDungText.text = cowdunginKGs.ToString();


        
        BleachingPowderText.text = "Not Required";


        float threedaysUrea = convertedAreaF * 12.5f;
        TDysUrea.text = threedaysUrea.ToString();
        Debug.Log(threedaysUrea);
        float threedaysSSP = convertedAreaF * 12.5f;
        TDysSSP.text = threedaysSSP.ToString();

        float threedaysCD = convertedAreaF * 50f;
        TDysCowDung.text = threedaysCD.ToString();

        float threedaysOC = convertedAreaF * 100f;
        TDysOilCake.text = threedaysOC.ToString();

        float sevendaysUrea = convertedAreaF * 12.5f;
        SDysUrea.text = sevendaysUrea.ToString();

        float sevendaysSSP = convertedAreaF * 12.5f;
        SDysSSP.text = sevendaysSSP.ToString();

        float sevendaysCD = convertedAreaF * 50f;
        SDysCowDung.text = sevendaysCD.ToString();

        float sevendaysOC = convertedAreaF * 100f;
        SDysOilCake.text = sevendaysOC.ToString();



        float thirtydaysUrea = convertedAreaF * 12.5f;
        TTYDysUrea.text = thirtydaysUrea.ToString();

        float thirtydaysSSP = convertedAreaF * 12.5f;
        TTYDysSSP.text = thirtydaysSSP.ToString();

        float thirtydaysCD = convertedAreaF * 50f;
        TTYDysCowDung.text = thirtydaysCD.ToString();

        float thirtydaysOC = convertedAreaF * 100f;
        TTYDysOilCake.text = thirtydaysOC.ToString();
    }

    public void GrowOutFingerlingButton()
    {
        // RearingButton.GetComponent<Image>().color = Color.green;
        // RearingButton.GetComponent<Button>().enabled = true;
        SuitableDepthText.text = "2-2.5 mt";
        SuitableTempratureText.text = "20-35";
        //  Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
        AreaFloat = PlayerPrefs.GetFloat("ConvertedPondArea");
        convertedAreaF = AreaFloat;
        float cowdunginKGs = convertedAreaF * 1000;
        cowDungText.text = convertedAreaF.ToString();

        BleachingPowderText.text = "Not Required";

        float threedaysUrea = convertedAreaF * 12.5f;
        TDysUrea.text = threedaysUrea.ToString();
      //  Debug.Log(threedaysUrea);
        float threedaysSSP = convertedAreaF * 12.5f;
        TDysSSP.text = threedaysSSP.ToString();

        float threedaysCD = convertedAreaF * 50f;
        TDysCowDung.text = threedaysCD.ToString();

        float threedaysOC = convertedAreaF * 100f;
        TDysOilCake.text = threedaysOC.ToString();

        float sevendaysUrea = convertedAreaF * 12.5f;
        SDysUrea.text = sevendaysUrea.ToString();

        float sevendaysSSP = convertedAreaF * 12.5f;
        SDysSSP.text = sevendaysSSP.ToString();

        float sevendaysCD = convertedAreaF * 50f;
        SDysCowDung.text = sevendaysCD.ToString();

        float sevendaysOC = convertedAreaF * 100f;
        SDysOilCake.text = sevendaysOC.ToString();



        float thirtydaysUrea = convertedAreaF * 12.5f;
        TTYDysUrea.text = thirtydaysUrea.ToString();

        float thirtydaysSSP = convertedAreaF * 12.5f;
        TTYDysSSP.text = thirtydaysSSP.ToString();

        float thirtydaysCD = convertedAreaF * 50f;
        TTYDysCowDung.text = thirtydaysCD.ToString();

        float thirtydaysOC = convertedAreaF * 100f;
        TTYDysOilCake.text = thirtydaysOC.ToString();
    }

    public void phfour()
    {
        // Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
        AreaFloat = PlayerPrefs.GetFloat("ConvertedPondArea");
        convertedAreaF = Area;
        float limereqd = convertedAreaF * 1000f;
        //  convertedAreaF = PlayerPrefs.GetFloat("ConvertedPondArea");
        LimeKGStxt.text = "";
        LimeKGStxt.text = limereqd.ToString();
    }

    public void phfive()
    {
        //  Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
        AreaFloat = PlayerPrefs.GetFloat("ConvertedPondArea");
        convertedAreaF = Area;
        float limereqd = convertedAreaF * 700f;
        //  convertedAreaF = PlayerPrefs.GetFloat("ConvertedPondArea");
        LimeKGStxt.text = "";
        LimeKGStxt.text = limereqd.ToString();
    }

    public void phsix()
    {
        //   Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
        AreaFloat = PlayerPrefs.GetFloat("ConvertedPondArea");
        convertedAreaF = Area;
        float limereqd = convertedAreaF * 500f;
        //  convertedAreaF = PlayerPrefs.GetFloat("ConvertedPondArea");
        LimeKGStxt.text = "";
        LimeKGStxt.text = limereqd.ToString();
    }


    public void pheight()
    {
        //   Area = float.Parse(AreaText.text, CultureInfo.InvariantCulture);
        AreaFloat = PlayerPrefs.GetFloat("ConvertedPondArea");
        convertedAreaF = Area;
        float limereqd = convertedAreaF * 200f;
        //  convertedAreaF = PlayerPrefs.GetFloat("ConvertedPondArea");
        LimeKGStxt.text = "";
        LimeKGStxt.text = limereqd.ToString();
    }

    public void resetLock()
    {
        cowDungText.text = "";
        TDysUrea.text = "";
        TDysSSP.text = "";
        TDysCowDung.text = "";
        TDysOilCake.text = "";
        SDysUrea.text = "";
        SDysSSP.text = "";
        SDysCowDung.text = "";
        SDysOilCake.text = "";
        TTYDysUrea.text = "";
        TTYDysSSP.text = "";
        TTYDysCowDung.text = "";
        TTYDysOilCake.text = "";

        LimeKGStxt.text = "";
        SuitableDepthText.text = "";
        SuitableTempratureText.text = "";
        BleachingPowderText.text = "";

        LengthText.text = "";
        BreadthText.text = "";
        WaterAvailabilityText.text = "";
        AreaText.text = "";
        areaInputField.text = "";
        LengthUnit.value = mDropdownValue_val;
        BreadthUnit.value = mDropdownValue_val;
        AreaUnit.value = mDropdownValue_val;
    }

    public void onClicktoCal()
    {
        if (curScene == "HomeScene")
        {
            SceneManager.LoadScene("HomeScene 1");
        }
    }

    public void onclickM1()
    {
        SceneManager.LoadScene("M1");
    }

    public void onclickM2()
    {
        SceneManager.LoadScene("M2");
    }

    public void onclickM3()
    {
        SceneManager.LoadScene("M3");
    }

    public void onclickM11()
    {
        SceneManager.LoadScene("ProfileScene 5");
    }

    public void onclickM12()
    {
        SceneManager.LoadScene("1.2");
    }

    public void onclickM13()
    {
        SceneManager.LoadScene("1.3");
    }
    public void onclickM14()
    {
        SceneManager.LoadScene("1.4");
    }
    public void onclickM15()
    {
        SceneManager.LoadScene("1.5");
    }
    public void onclickM16()
    {
        SceneManager.LoadScene("1.6");
    }
    public void onclickM17()
    {
        SceneManager.LoadScene("1.7");
    }
    public void onclickM18()
    {
        SceneManager.LoadScene("1.8");
    }
    public void onclickM19()
    {
        SceneManager.LoadScene("1.9");
    }
    public void onclickM110()
    {
        SceneManager.LoadScene("1.10");
    }
    public void onclickM111()
    {
        SceneManager.LoadScene("1.11");
    }
    public void onclickM112()
    {
        SceneManager.LoadScene("1.12");
    }
    public void onclickM113()
    {
        SceneManager.LoadScene("1.13");
    }
    public void onclickM114()
    {
        SceneManager.LoadScene("1.14");
    }
    public void onclickM115()
    {
        SceneManager.LoadScene("1.15");
    }
    public void onclickM116()
    {
        SceneManager.LoadScene("1.16");
    }


    public void onclickM21()
    {
        SceneManager.LoadScene("2.1");
    }
    public void onclickM22()
    {
        SceneManager.LoadScene("2.2");
    }
    public void onclickM23()
    {
        SceneManager.LoadScene("2.3");
    }


    public void onclickM31()
    {
        SceneManager.LoadScene("3.1");
    }
    public void onclickM32()
    {
        SceneManager.LoadScene("3.2");
    }
    public void onclickM33()
    {
        SceneManager.LoadScene("3.3");
    }
    public void onclickM34()
    {
        SceneManager.LoadScene("3.4");
    }
    public void onclickM41()
    {
        SceneManager.LoadScene("4.1");
    }
    public void onclickM42()
    {
        SceneManager.LoadScene("4.2");
    }
    public void onclickM43()
    {
        SceneManager.LoadScene("4.3");
    }
    public void onclickM44()
    {
        SceneManager.LoadScene("4.4");
    }
    public void onclickM45()
    {
        SceneManager.LoadScene("4.5");
    }
    public void onclickM4()
    {
        SceneManager.LoadScene("M4");
    }
    public void onclickM5()
    {
        SceneManager.LoadScene("M5");
    }
    public void onclickM51()
    {
        SceneManager.LoadScene("5.1");
    }
    public void onclickM52()
    {
        SceneManager.LoadScene("5.2");
    }
    public void onclickM53()
    {
        SceneManager.LoadScene("5.3");
    }
    public void onclickM54()
    {
        SceneManager.LoadScene("5.4");
    }
    public void onclickM55()
    {
        SceneManager.LoadScene("5.5");
    }
    public void onclickM56()
    {
        SceneManager.LoadScene("5.6");
    }
    public void onclicktoadvisory()
    {
                

            SceneManager.LoadScene("ProfileScene 1");

        
    }
    public void onclickDiseasesMain()
    {
        SceneManager.LoadScene("DiseasesMain");
    }

    public void onclickD1()
    {
        SceneManager.LoadScene("D1");
    }
    public void onclickD2()
    {
        SceneManager.LoadScene("D2");
    }
    public void onclickD3()
    {
        SceneManager.LoadScene("D3");
    }
    public void onclickD4()
    {
        SceneManager.LoadScene("D4");
    }
    public void onclickD5()
    {
        SceneManager.LoadScene("D5");
    }
    public void onclickD6()
    {
        SceneManager.LoadScene("D6");
    }
    public void onclickD7()
    {
        SceneManager.LoadScene("D7");
    }
    public void onclickD11()
    {
        SceneManager.LoadScene("D1.1");
    }
    public void onclickD12()
    {
        SceneManager.LoadScene("D1.2");
    }
    public void onclickD21()
    {
        SceneManager.LoadScene("D2.1");
    }
    public void onclickD22()
    {
        SceneManager.LoadScene("D2.2");
    }
    public void onclickD23()
    {
        SceneManager.LoadScene("D2.3");
    }
    public void onclickD24()
    {
        SceneManager.LoadScene("D2.4");
    }
    public void onclickD25()
    {
        SceneManager.LoadScene("D2.5");
    }
    public void onclickD31()
    {
        SceneManager.LoadScene("D3.1");
    }
    public void onclickD32()
    {
        SceneManager.LoadScene("D3.2");
    }
    public void onclickD33()
    {
        SceneManager.LoadScene("D3.3");
    }
    public void onclickD34()
    {
        SceneManager.LoadScene("D3.4");
    }
    public void onclickD41()
    {
        SceneManager.LoadScene("D4.1");
    }
    public void onclickD42()
    {
        SceneManager.LoadScene("D4.2");
    }
    public void onclickD51()
    {
        SceneManager.LoadScene("D5.1");
    }
    public void onclickD52()
    {
        SceneManager.LoadScene("D5.2");
    }
    public void onclickD61()
    {
        SceneManager.LoadScene("D6.1");
    }
    public void onclickD62()
    {
        SceneManager.LoadScene("D6.2");
    }
    public void onclickD63()
    {
        SceneManager.LoadScene("D6.3");
    }
    public void onclickD64()
    {
        SceneManager.LoadScene("D6.4");
    }
    public void onclickD65()
    {
        SceneManager.LoadScene("D6.5");
    }
    public void onclickD66()
    {
        SceneManager.LoadScene("D6.6");
    }
    public void onclickD71()
    {
        SceneManager.LoadScene("D7.1");
    }
    public void onclickD72()
    {
        SceneManager.LoadScene("D7.2");
    }

    public void populateStateList()
    {
        stateDropdown.AddOptions(SelectedState);
    }

    public void populateAreaList()
    {
       // List<string> Areaunits = new List<string>() { "माप", "Hectare", "Acre", "Decimal", "Gunta", "Bigha", "Kattha", "Square Metre", "Square Feet" };
        AreaUnit.AddOptions(Areaunits);
    }

    public void populateUnitlist()
    {

    }
}
