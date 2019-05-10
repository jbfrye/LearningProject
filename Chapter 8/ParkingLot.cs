using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_8
{
    // 8.4
    class ParkingLot
    {
        ParkingSpace[,] parking;

        public ParkingLot(int n, int m)
        {
            parking = new ParkingSpace[n, m];
        }

        public static void RunParkingLot()
        {

        }
    }

    class ParkingSpace
    {

    }

    abstract class Vehicle
    {

    }

    class Car : Vehicle
    {

    }

    class Bus : Vehicle
    {

    }

    class Motorcycle : Vehicle
    {

    }
}
