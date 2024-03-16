using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasketBall
{
    public struct InitialFieldComponent
    {
        public float fieldSide;
        public int cellsCenterPerRow;
        public float cellDistance;

        public Vector3 fieldCoordinates;
        public Vector3[] cellCoordinates;

        public Vector3 topPressZoneCoordinates;
        public Vector3 bottomPressZoneCoordinates;
        public Vector3 rightPressZoneCoordinates;
        public Vector3 leftPressZoneCoordinates;

        public float pressZoneSide;


        //public CoordinateComponent[] cellCoordinates;

        //public CoordinateComponent topPressZoneCoordinates;
        //public CoordinateComponent bottomPressZoneCoordinates;
        //public CoordinateComponent rightPressZoneCoordinates;
        //public CoordinateComponent leftPressZoneCoordinates;



    }
}



