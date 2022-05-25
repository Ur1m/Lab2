

using System;
using System.ComponentModel.DataAnnotations;

namespace Play.Products.Service.Enteties
{
    public class Course
    {
        
        public int CourseId{get;set;}
        public string Name{get;set;}
        public string Description{get;set;}
        public string Image{get;set;}
        public int Difficulty{get;set;}
        public string CourseContent{get;set;}
        public DateTime CreatedOn{get;set;}
        public bool IsDeleted{get;set;}
        public int CategoryId{get;set;}
        public virtual Category Category{get;set;}
            }
}