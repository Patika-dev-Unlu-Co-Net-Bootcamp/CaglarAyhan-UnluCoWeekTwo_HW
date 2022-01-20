﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCoWeekTwoHW.Error_Management
{
    public  class Messages
    {
        public static string EmptyResults = "Herhangi bir veri bulunamadı";
        public static string WrongRequest = "Id numarası bulunamadı";
        public static string updated(string name, int id) { return $"{id}id numaralı verinin ismi {name} olarak değiştirilmiştir "; }
        public static string WrongRequestById(int id) { return $"{id}id numaralısı sistemde bulunamamıstır."; }
        public static string ExistingData(string name) { return $"{name} isimli kullanıcı sistemde mevcuttur."; }
    }
}
