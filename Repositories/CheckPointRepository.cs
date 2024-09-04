﻿using BookingApp.Domain.Models;
using BookingApp.Domain.RepositoryInterfaces;
using BookingApp.Domain.Serializer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class CheckPointRepository : ICheckPointRepository
    {
        private const string FilePath = "../../../Resources/Data/checkPoints.csv";

        private readonly Serializer<CheckPoint> _serializer;

        private List<CheckPoint> _checkPoints;

        public CheckPointRepository()
        {
            _serializer = new Serializer<CheckPoint>();
            _checkPoints = _serializer.FromCSV(FilePath);
        }
        public List<CheckPoint> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public CheckPoint Save(CheckPoint checkPoint)
        {
            checkPoint.Id = NextId();
            _checkPoints = _serializer.FromCSV(FilePath);
            _checkPoints.Add(checkPoint);
            _serializer.ToCSV(FilePath, _checkPoints);
            return checkPoint;
        }

        public int NextId()
        {
            _checkPoints = _serializer.FromCSV(FilePath);
            if (_checkPoints.Count < 1)
            {
                return 1;
            }
            return _checkPoints.Max(c => c.Id) + 1;
        }

        public void Delete(CheckPoint checkPoint)
        {
            _checkPoints = _serializer.FromCSV(FilePath);
            CheckPoint founded = _checkPoints.Find(a => a.Id == checkPoint.Id);
            _checkPoints.Remove(founded);
            _serializer.ToCSV(FilePath, _checkPoints);
        }
        public void DeleteByTourId(int tourId)
        {
            _checkPoints = _serializer.FromCSV(FilePath);
            
            _checkPoints.RemoveAll(checkpoint=>checkpoint.TourId==tourId);
            _serializer.ToCSV(FilePath, _checkPoints);
        }

        public CheckPoint Update(CheckPoint checkPoint)
        {
            _checkPoints = _serializer.FromCSV(FilePath);
            CheckPoint current = _checkPoints.Find(a => a.Id == checkPoint.Id);
            int index = _checkPoints.IndexOf(current);
            _checkPoints.Remove(current);
            _checkPoints.Insert(index, checkPoint);       // keep ascending order of ids in file 
            _serializer.ToCSV(FilePath, _checkPoints);
            return checkPoint;
        }


        public CheckPoint GetCheckPointById(int? id)
        {
            _checkPoints = _serializer.FromCSV(FilePath);

            foreach (CheckPoint checkPoint in _checkPoints)
            {
                if (id == checkPoint.Id)
                {
                    return checkPoint;
                }
            }
            return null;
        }
    }
}

