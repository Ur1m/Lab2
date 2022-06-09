using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCourseInteraction.ViewModels;

namespace UserCourseInteraction.Repositories
{
    public interface IOrderRepository
    {
        void Add(OrderViewModel model);
        void Update(OrderViewModel model);
        List<OrderViewModel> GetAll();
        OrderViewModel getbyId(int id);
        List<OrderViewModel> getbyUserId(string Id);
        void Remuve(int Id);
    }
}
