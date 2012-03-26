﻿using UnityEngine;

namespace RealDedicated_UnityGameLibrary
{
    public class ScoreValueSheet : MonoBehaviour
    {
        [System.Serializable]
        public sealed class ValueItem
        {
            public string value;
            public float score;

            public ValueItem(string newValue, float newScore)
            {
                value = newValue;
                score = newScore;
            }
        }

        #region Members
        [UnityEngine.SerializeField]
        private string valueSheetName;
        [UnityEngine.SerializeField]
        private ValueItem[] valueMap;
        #endregion

        #region Properties
        public string ValueSheetName
        {
            get { return this.valueSheetName; }
            set { this.valueSheetName = value; }
        }

        public ValueItem[] ValueMap
        {
            get { return this.valueMap; }
            set { this.valueMap = value; }
        }
        #endregion
    }
}