﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Data.EntityEnums
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum HeightUnit
    {
        cm,
        inches,
        ft,
    }

    public enum TDEELevel
    {
        Inactive, // little to no exercise + work a desk job
        SomewhatActive, // light exercise 2-4 days / week
        Active // moderate exercise 5 days + / week
    }

    public enum WeightGoal
    {
        Lose,
        Maintain,
        Gain
    }

    public enum WeightUnit
    {
        Kg,
        Lbs
    }

    public enum GenoType
    {
        AA,
        AS,
        SS,
        SC
    }

    public enum BloodGroup
    {
        A,
        B,
        AB,
        O
    }

    public enum SubscriptionType
    {
        Basic,
        Standard,
        Premium
    }

    public enum TransactionType
    {
    }

    public enum TransactionChannel
    {
    }

    public enum WalletType
    {
    }

    public enum UnitType
    {
        Tablespoon,
        Ounce,
        Cup,
        Piece,
        // Add other unit types as needed
    }


	public enum DaysOfWeek
	{
        Sunday,
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday
		
	}

	public enum MealOfDay
	{
		Breakfast,
		Lunch,
		Dinner
	}
}