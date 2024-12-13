using System.Collections.Generic;
using DecoratorPattern;
using DecoratorPattern.Extras;
using UnityEngine;

namespace FactoryPattern.CarFactory
{
    public class USFactory : _CarFactory
    {
        public override _Car ManufactureCar(CarInfo carInfo)
        {
            _Car car = null;

            if (carInfo.Model == CarModels.Cybertruck)
            {
                car = new Cybertruck();
            }
            else if (carInfo.Model == CarModels.ModelS)
            {
                car = new ModelS();
            }
            else if (carInfo.Model == CarModels.Roadster)
            {
                car = new Roadster();
            }

            if (car == null)
            {
                Debug.Log("Sorry but this factory can't manufacture this model :(");
                return car;
            }

            foreach (CarExtra carExtra in carInfo.Extras)
            {
                if (carExtra.Extra == CarExtras.DracoThruster)
                {
                    car = new DracoThruster(car, carExtra.Number);
                }
                else if (carExtra.Extra == CarExtras.EjectionSeat)
                {
                    Debug.Log("Sorry but this factory can't add this car extra :(");
                }
                else
                {
                    Debug.Log("Sorry but this factory can't add this car extra :(");
                }
            }

            return car;
        }
    }
}