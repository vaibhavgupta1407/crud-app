using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models.ViewModel
{
    public class ImageCreateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Choose Image/File")]
        [Display(Name ="Choose Image")]
        public IFormFile ImagePath { get; set; }
    }
}
