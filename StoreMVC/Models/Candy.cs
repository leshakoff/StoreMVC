using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class Candy
    {
        //[Required(ErrorMessage = "Отсуствует наименование товара.")]
        //[StringLength(100, MinimumLength = 5, ErrorMessage = "Длина наименования должна быть не более 100 символов и не менее 5.")]
        //public string Name { get; set; }


        //[Required(ErrorMessage = "Отсутствует цена товара.")]
        //[Range(1, 10000, ErrorMessage = "Цена должна быть в диапазоне от 1 до 10000.")]
        //public float Price { get; set; }


        //[Required(ErrorMessage = "Отсутствует количество.")]
        //[Range(1, 10000, ErrorMessage = "Количество должно быть в диапазоне от 1 до 10000.")]
        //public float Amount { get; set; }
        public int CandyID { get; set; }

        [Required(ErrorMessage = "Наименование не может быть пустым.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Отсутствует цена.")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Отсутствует количество.")]
        public float Amount { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите категорию товара.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите наличие товара.")]
        public string Availability { get; set; }


    }
}
