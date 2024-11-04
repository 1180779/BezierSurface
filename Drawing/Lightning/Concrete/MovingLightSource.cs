using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;

using System.Threading;
using System.Threading.Tasks;


namespace Drawing.Lightning.Concrete
{
    public struct MovingLightSource : IMovingLightSource
    {
        private Color _color;
        private Vector3 _color0To1;
        public MovingLightSource(Vector3 location)
        {
            _threadData = new ThreadData(this);
            Location = location;
            Color = Color.FromArgb(1, 255, 255, 255);
        }
        public MovingLightSource(Vector3 location, Color color)
        {
            _threadData = new ThreadData(this);
            Location = location;
            Color = color;
        }
        private Vector3 _location;
        public Vector3 Location
        {
            get { return _location; }
            set
            {
                if (_location == value)
                    return;
                _location = value;
            }
        }
        public Color Color
        {
            get { return _color; }
            set
            {
                if (_color == value)
                    return;
                _color = value;
                _color0To1 = new Vector3(
                    (float)Color.R / 255,
                    (float)Color.G / 255,
                    (float)Color.B / 255);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }
        public Vector3 Color0To1 { get { return _color0To1; } }
        private ThreadData _threadData;
        
        public bool IsMoving => _threadData.Thread is not null;
        public float Parameter 
        { 
            get 
            {
                float res;
                lock(_threadData.ParameterLock)
                {
                    res = _threadData.Parameter;
                }
                return res; 
            } 
            set 
            {
                lock (_threadData.ParameterLock)
                {
                    _threadData.Parameter = value;
                }

                _location.X = _threadData.R * (float)Math.Cos(Parameter * 2 * Math.PI);
                _location.Y = _threadData.R * (float)Math.Sin(Parameter * 2 * Math.PI);
            }
        }
        public float Step 
        { 
            get { return _threadData.ParameterStep; }
            set
            {
                _threadData.ParameterStep = value;
                _threadData.SleepMiliseconds = 
                    (int)(TSeconds * _threadData.ParameterStep * 1000);
            }
        }

        public int TSeconds 
        { 
            get { return _threadData.TSeconds; } 
            set 
            { 
                _threadData.TSeconds = value;
                _threadData.SleepMiliseconds = (int)(TSeconds * Step * 1000);
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void StartMoving()
        {
            if(IsMoving) 
                return;
            _threadData.CancellationToken = _threadData.TokenSource.Token;
            _threadData.Thread = new Thread((obj) => 
            {
                if (obj is null)
                    throw new InvalidAsynchronousStateException();

                ThreadData tData = (ThreadData)obj;
                while(!tData.CancellationToken.IsCancellationRequested)
                {
                    Thread.Sleep(tData.SleepMiliseconds);
                    lock (tData.ParameterLock)
                    {
                        tData.Parameter += tData.ParameterStep;
                        if (tData.Parameter >= 1f)
                            tData.Parameter -= 1f;
                    }

                    tData.source.Location = new Vector3(
                        tData.R * (float)Math.Cos(tData.Parameter * 2 * Math.PI),
                        tData.R * (float)Math.Sin(tData.Parameter * 2 * Math.PI),
                        tData.source.Location.Z);
                }

                if (!tData.TokenSource.TryReset())
                {
                    tData.TokenSource.Dispose();
                    tData.TokenSource = new CancellationTokenSource();
                }
                tData.Thread = null;
            });
            _threadData.Thread.Start(_threadData);
        }

        public void StopMoving()
        {
            if (!IsMoving)
                return;
            _threadData.TokenSource.Cancel();
        }
    }

    internal class ThreadData
    {
        internal ThreadData(IMovingLightSource movingLightSource) 
        {
            source = movingLightSource;
        }
        internal int TSeconds { get; set; } = 20;
        internal float ParameterStep { get; set; } = 0.025f;
        internal int SleepMiliseconds { get; set; } = 500;
        internal object ParameterLock = new();
        internal float Parameter { get; set; } = 0f;
        internal float R { get; set; } = 250f;
        internal CancellationTokenSource TokenSource = new();
        internal CancellationToken CancellationToken { get; set; }
        internal Thread? Thread = null;
        internal IMovingLightSource source;
    }
}
