﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_primitive_paint
{
    class CircleFabric : Fabric
    {
        public override MainFigure FactoryMethod(float fatness, Color color, Point upperLeft, Point lowerRight)
        {
            return new Circle(fatness, color, upperLeft, lowerRight);
        }
    }
}
