using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Lightning
{
    public interface IMovingLightSource : ILightSource
    {
        public int TSeconds { get; set; }
        public float Step { get; set; } // > 0 && < 1 -> the amount of time passing between each movement
        public float Parameter { get; set; } // 0 to 1
        public bool IsMoving { get; }
        public void StartMoving();
        public void StopMoving();
    }
}
