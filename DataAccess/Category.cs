using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Category
    {

        public int Id { get; set; }

       // [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        public string Description { get; set; }

        

        //public bool IsValid()
        //{
        //    if (string.IsNullOrEmpty(Name))
        //    {
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(Job))
        //    {
        //        return false;
        //    }

        //    return true;
        //}

    }
}
