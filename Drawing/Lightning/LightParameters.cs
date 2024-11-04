using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Lightning
{
    public struct LightParameters : INotifyPropertyChanged
    {
        private float _kd;
        public float KD 
        { 
            get { return _kd; } 
            set 
            {
                if (_kd == value)
                    return;
                _kd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(KD)));
            } 
        }
        private float _ks;
        public float KS 
        { 
            get { return _ks; } 
            set 
            {
                if (_ks == value)
                    return;
                _ks = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(KS)));
            } 
        }
        private float _m;
        public float M 
        {  
            get { return _m; }
            set 
            { 
                if(_m == value)
                    return;
                _m = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(M)));
            }
        }
        public LightParameters() 
        {
            KD = KS = 0.5f;
            M = 1;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
