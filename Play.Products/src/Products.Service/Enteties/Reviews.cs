using System;
using System.ComponentModel.DataAnnotations;
namespace Play.Products.Service.Enteties
{
    public class Reviews
    {
        public int Id {get;set;}
        public string UserId{get;set;}
        public int CourseId{get;set;}
        public int NumberOfStarts{get;set;}
        public bool Like{get;set;}
        public bool Dislike{get;set;}
        public string Comment{get;set;}
    }
}