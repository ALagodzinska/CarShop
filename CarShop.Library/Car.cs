using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class Car
    {

        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public bool Sold { get; set; }

        private bool isAvailable = true;
        public bool IsAvailable
        {
            get => isAvailable;
            set => isAvailable = value;
        }
    }
}