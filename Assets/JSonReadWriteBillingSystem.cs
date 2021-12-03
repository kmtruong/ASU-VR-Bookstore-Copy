using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;


public class JSonReadWriteBillingSystem : MonoBehaviour
{
    [SerializeField] Text firstNameInputField;
    [SerializeField] Text lastNameInputField;
    [SerializeField] Text streetInputField;
    [SerializeField] Text aptInputField;
    [SerializeField] Text cityInputField;
    [SerializeField] Text stateInputField;
    [SerializeField] Text zipCodeInputField;

    [SerializeField] Text cardNumberInputField;
    [SerializeField] Text monthExpireInputField;
    [SerializeField] Text yearExpireInputField;
    [SerializeField] Text cardNameInputField;
    [SerializeField] string filename = "UsersInformation.json";
    public Text applyMessage;


    private List<UserData> saveListUser = new List<UserData>();


    private void Start()
    {
        applyMessage.enabled = false;
    }

    public void AddInformationtoDatabase()
    {
        if (!checkValidAddress() || !checkValidCard())
        {
            applyMessage.text = "Invalid Info";
            applyMessage.enabled = true;
            return;
        }
        else
        {
            UserData newUser = new UserData();
            newUser.firstName = firstNameInputField.text;
            newUser.lastName = lastNameInputField.text;
            newUser.streetName = streetInputField.text;
            newUser.aptName = aptInputField.text;
            newUser.cityName = cityInputField.text;
            newUser.stateName = stateInputField.text;
            newUser.zipCode = int.Parse(zipCodeInputField.text);

            newUser.cardNumber = cardNumberInputField.text;
            newUser.monthExpire = int.Parse(monthExpireInputField.text);
            newUser.yearExpire = int.Parse(yearExpireInputField.text);
            newUser.cardName = cardNameInputField.text;

            saveListUser.Add(newUser);
            firstNameInputField.text = "";
            lastNameInputField.text = "";
            streetInputField.text = "";
            aptInputField.text = "";
            cityInputField.text = "";
            stateInputField.text = "";
            zipCodeInputField.text = "";
            cardNumberInputField.text = "";
            monthExpireInputField.text = "";
            yearExpireInputField.text = "";
            cardNameInputField.text = "";

            FileHandler.SaveItemtoJSON<UserData>(newUser, filename);
            applyMessage.text = "Success";
            applyMessage.enabled = true;
        }
    }

    public void AddAddresstoDatabase()
    {
        if (!checkValidAddress())
        {
            applyMessage.text = "Invalid Address";
            applyMessage.enabled = true;
            return;
        }
        else
        {
            UserData newUser = new UserData();
            newUser.firstName = firstNameInputField.text;
            newUser.lastName = lastNameInputField.text;
            newUser.streetName = streetInputField.text;
            newUser.aptName = aptInputField.text;
            newUser.cityName = cityInputField.text;
            newUser.stateName = stateInputField.text;
            newUser.zipCode = int.Parse(zipCodeInputField.text);

            saveListUser.Add(newUser);
            firstNameInputField.text = "";
            lastNameInputField.text = "";
            streetInputField.text = "";
            aptInputField.text = "";
            cityInputField.text = "";
            stateInputField.text = "";
            zipCodeInputField.text = "";

            FileHandler.SaveItemtoJSON<UserData>(newUser, filename);
            applyMessage.text = "Success";
            applyMessage.enabled = true;
        }
    }

    public void loadFromJSon()
    {
        UserData returnUser = FileHandler.ReadFromJSON<UserData>(filename);
        firstNameInputField.text = returnUser.firstName;
        lastNameInputField.text = returnUser.lastName;
        streetInputField.text = returnUser.streetName;
        aptInputField.text = returnUser.aptName;
        cityInputField.text = returnUser.cityName;
        stateInputField.text = returnUser.stateName;
        zipCodeInputField.text = returnUser.zipCode.ToString();

        cardNumberInputField.text = returnUser.cardNumber;
        monthExpireInputField.text = returnUser.monthExpire.ToString();
        yearExpireInputField.text = returnUser.yearExpire.ToString();
        cardNameInputField.text = returnUser.cardName.ToString();
        Debug.Log(firstNameInputField.text);
    }

    public void loadAddressFromJSon()
    {
        UserData returnUser = FileHandler.ReadFromJSON<UserData>(filename);
        firstNameInputField.text = returnUser.firstName;
        lastNameInputField.text = returnUser.lastName;
        streetInputField.text = returnUser.streetName;
        aptInputField.text = returnUser.aptName;
        cityInputField.text = returnUser.cityName;
        stateInputField.text = returnUser.stateName;
        zipCodeInputField.text = returnUser.zipCode.ToString();
    }

        private bool checkValidAddress()
    {
        string zipcode = zipCodeInputField.text;
        if (!checkCity() || !checkZipCode(zipcode) 
            || !checkEmptyField(firstNameInputField) || !checkEmptyField(lastNameInputField)
            || !checkEmptyField(streetInputField) || !checkEmptyField(cityInputField) 
            || !checkEmptyField(stateInputField) || !checkEmptyField(zipCodeInputField))
        {
            return false;
        }

        return true;
    }

    private bool checkCity()
    {
        if (Regex.IsMatch(cityInputField.text, @"^[a-zA-Z]+$"))
        {
            return true;
        }
        applyMessage.text = "Invalid City";
        return false;
    }

    private bool checkZipCode(string zipCode)
    {
        var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";

        if (!Regex.Match(zipCode, _usZipRegEx).Success)
        {
            applyMessage.text = "Invalid Zipcode";
            return false;
        }
        return true;
    }

    private bool checkValidCard()
    {
        DateTime today = DateTime.Today;
        var idRegex = "^[0-9]+$";
        if (cardNumberInputField.text.Length < 13 || cardNumberInputField.text.Length > 19 || !Regex.Match(cardNumberInputField.text, idRegex).Success
            || (int.Parse(monthExpireInputField.text) < today.Month && int.Parse(yearExpireInputField.text) == today.Year)
            || !checkEmptyField(cardNameInputField) || !checkEmptyField(cardNumberInputField) || !checkEmptyField(monthExpireInputField) || !checkEmptyField(yearExpireInputField))
        {
            Debug.Log("Nonvalid ID Number");
            applyMessage.text = "Invalid ID Number";
            return false;
        }

        return true;
    }

    private bool checkEmptyField(Text field)
    {
        if (String.Compare("", field.text) == 0)
        {
            return false;
        }
        return true;
    }

    

    


}
