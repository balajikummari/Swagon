namespace Swagon.DataBase
{
    /// <summary>
    /// Colllection of rule sets for validations
    /// </summary>
    public static class RuleSets
    {
        /// <summary>
        /// Rulesets for user DataMoel
        /// </summary>
        public static class User
        {
            /// <summary>
            /// checks username and password
            /// </summary>
           public static readonly string crentials = "crentials";
            /// <summary>
            /// check the Profile attributes like firstname, lastname etc
            /// </summary>
           public static readonly string profile = "profile";
        }
        /// <summary>
        /// Rulesets for Rideoffer DataMoel
        /// </summary>
        public static class RideOffer
        {
            /// <summary>
            /// checks all the attributes 
            /// </summary>
            public static readonly string General = "crentials";
        }

        /// <summary>
        /// Rulesets for city datamodel
        /// </summary>
        public static class City
        {
            /// <summary>
            /// checks valid coordinates or not
            /// </summary>
            public static readonly string coordiantes = "coordiantes";

        }
            /// <summary>
            /// ruleSet for strings
            /// </summary>
        public static class String 
        {
            /// <summary>
            /// checks a string is empty or not
            /// </summary>
            public static readonly string EmptyString = "EmptyString";
        }

        /// <summary>
        /// ruleSet for booking model
        /// </summary>
        public static class Booking
        {
            /// <summary>
            /// checks a string is empty or not
            /// </summary>
            public static readonly string general = "general";
        }
    }
}
