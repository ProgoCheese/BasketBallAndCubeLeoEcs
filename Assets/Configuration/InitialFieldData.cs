using UnityEngine;
/*
namespace BasketBall
{
    public static class InitialFieldData
    {
        public static float fieldSide;
        public static int cellsCenterPerRow;
        public static float cellDistance;

        public static Vector3 fieldCoordinates = new(0f - _halfFieldSide, 0f - _halfFieldSide, 0f - _halfFieldSide);
        public static Vector3[,] CellCoordinates { get; private set; }
        public static float CellSide { get; private set; }

        public static float pressZoneZCoordinate;

        public static Vector3 TopPressZoneCoordinates { get; private set; }
        public static Vector3 BottomPressZoneCoordinates { get; private set; }
        public static Vector3 RightPressZoneCoordinates { get; private set; }
        public static Vector3 LeftPressZoneCoordinates { get; private set; }

        public static float PressZoneSide { get; private set; }


        private static float _halfFieldSide;

        public static void UpdateAllInitalField(float fieldSideParam, int cellsCenterPerRowParam, float cellDistanceParam)
        {
            fieldSide = fieldSideParam;
            cellsCenterPerRow = cellsCenterPerRowParam;
            cellDistance = cellDistanceParam;            

            SetAllData();
        }

        public static void SetAllData()
        {
            _halfFieldSide = fieldSide / 2;
            SetAll();
        }

        private static void CalculateCellSide()
        {
            int totalCellRowCount = cellsCenterPerRow * 3;
            float sumDistantBeetwenCells = (totalCellRowCount - 1) * cellDistance;

            float fieldSideLengthWithoutGaps = fieldSide - sumDistantBeetwenCells;

            CellSide = (int)fieldSideLengthWithoutGaps / totalCellRowCount;
        }

        private static void CalculateCellsCoordinates()
        {
            int totalCellRowCount = cellsCenterPerRow * 3;

            for (int i = 0; i < totalCellRowCount; i++)
            {
                for (int j = 0; j < totalCellRowCount; j++)
                {
                    float x = i * (CellSide + cellDistance) + CellSide / 2 - _halfFieldSide;
                    float y = j * (CellSide + cellDistance) + CellSide / 2 - _halfFieldSide;
                    float z = 0;
                    CellCoordinates[i, j] = new(x - _halfFieldSide, y - _halfFieldSide, z - _halfFieldSide);
                }
            }
        }

        private static void CalculatePressZonesCoordinate()
        {
            float halfSide = fieldSide / 2;
            float halfGroupCells = (cellsCenterPerRow * CellSide + (cellsCenterPerRow - 1) * cellDistance) / 2;

            TopPressZoneCoordinates = new Vector3(halfSide - _halfFieldSide, halfGroupCells - _halfFieldSide, pressZoneZCoordinate - _halfFieldSide);
            BottomPressZoneCoordinates = new Vector3(halfSide - _halfFieldSide, fieldSide - halfGroupCells - _halfFieldSide, pressZoneZCoordinate - _halfFieldSide);
            LeftPressZoneCoordinates = new Vector3(halfGroupCells - _halfFieldSide, halfSide - _halfFieldSide, pressZoneZCoordinate - _halfFieldSide); 
            RightPressZoneCoordinates = new Vector3(fieldSide - halfGroupCells - _halfFieldSide, halfSide - _halfFieldSide, pressZoneZCoordinate - _halfFieldSide); 
        }

        private static void CalculatePressZoneSide()
        {
            PressZoneSide = cellsCenterPerRow * CellSide + (cellsCenterPerRow - 1) * cellDistance;
        }

        private static void SetAll()
        {
            CalculateCellSide();
            CalculateCellsCoordinates();
            CalculatePressZonesCoordinate();
            CalculatePressZoneSide();
        }

        //

        //public GameObject cubeFloor;

        //public float sizeCell;

        //public Transform spawnTransform;

        //public int length;
    }
} */