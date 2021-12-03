//Object of this class will hold the billing information from user
//And then this object will be converted to JSON
using System;

[Serializable]
public class UserData
{
    public string firstName;
    public string lastName;

    public string streetName;
    public string aptName;
    public string cityName;
    public string stateName;
    public int zipCode;

    public string cardNumber;
    public int monthExpire;
    public int yearExpire;
    public string cardName;


}
