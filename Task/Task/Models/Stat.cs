using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Stat
    {
        private float _currentValue;
        private float _maxValue;

        public float CurrentValue { get=> _currentValue; set => _currentValue = value;}
        public float MaxValue { get => _maxValue; set => _maxValue = value;}
        
        public Stat(float currentValue, float maxValue)
        {
            CurrentValue = currentValue;
            MaxValue = maxValue;
        }
    }
}
