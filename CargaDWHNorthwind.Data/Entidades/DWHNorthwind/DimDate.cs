﻿

using System.ComponentModel.DataAnnotations.Schema;

namespace CargaDWHNorthwind.Data.Entidades.DWHNorthwind
{
    [Table("DimDate")]
    public class DimDate
    {

        public int DateKey { get; set; }
        public int DateOrder { get; set; }
        public DateOnly? Date { get; set; }
        public string? DateName { get; set; }
        public int Mouth { get; set; }
        public string? MouthName { get; set; }
        public int Year { get; set; }
        public string? YearName { get; set; }

    }
}
