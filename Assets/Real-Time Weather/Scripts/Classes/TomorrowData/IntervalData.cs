﻿//
// Copyright(c) 2021 Real-Time Weather ASSIST-Software
// https://www.assist.ro
//
// For information about the licensing and copyright of this software please
// contact assist contact@assist.ro
//

using System;
using UnityEngine;

namespace RealTimeWeather.Tomorrow.Classes
{
    /// <summary>
    /// <para>
    /// This class manages Tomorrow interval data.
    /// </para>
    /// </summary>
    [Serializable]
    public class IntervalData
    {
        #region Constructors
        public IntervalData()
        {
            startTime = string.Empty;
            values = new TomorrowWeatherData();
        }

        public IntervalData(string startTime, TomorrowWeatherData values)
        {
            this.startTime = startTime;
            this.values = values;
        }
        #endregion

        #region Private Variables
        [SerializeField]
        private string startTime;
        [SerializeField]
        private TomorrowWeatherData values;
        #endregion

        #region Public Properties
        /// <summary>
        /// <para>
        /// It is a string value that indicates the start time.
        /// <br>Default is set to DateTime.Now.</br>
        /// </para>
        /// </summary>
        public string StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }

        /// <summary>
        /// <para>
        /// This is a TomorrowWeatherData instance.
        /// </para>
        /// </summary>
        public TomorrowWeatherData WeatherData
        {
            get
            {
                return values;
            }

            set
            {
                values = value;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Concatenates the attributes of the IntervalData class into a single string.
        /// </summary>
        public override string ToString()
        {
            return ("\n[Tomorrow Interval Data]\n" +
                 $"Start time: {startTime}\n" +
                 $"{values.ToString()}\n");
        }
        #endregion
    }
}